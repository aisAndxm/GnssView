using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;

namespace GnssView
{
    public partial class FormCn0 : Form
    {
        public FormCn0(FormHome home)
        {
            InitializeComponent();
            homeTmp = home;
        }

        private FormHome homeTmp;

        private static byte[] nmeaMsgBuf = new byte[500];

        public double[] trueValue = new double[] { -2175140.5, 4386304.9, 4074142.8 };

        /// <summary>
        /// 异或校验
        /// </summary>
        /// <param name="data"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private int xorCheck(byte[] data, int start, int length)
        {
            int check = 0;

            if (length < 1) return -1;

            for (int i = start; i < length; i++)
                check ^= data[i];

            return check;
        }

        /// <summary>
        /// ASCII转换成int数据
        /// Convert.ToInt32(Encoding.ASCII.GetString(data, start, len));
        /// </summary>
        /// <param name="data"></param>
        /// <param name="start"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        private int ascii2Int(byte[] data, int start, int len)
        {
            if (len >= 16) return -1;

            int value = 0;

            /*先存储的数据是高位*/
            for (int i = 0; i < len; i++)
            {
                value <<= 4;
                if ((data[start + i] >= 48) && (data[start + i] <= 57))
                    value |= (data[start + i] - 48);
                else if ((data[start + i] >= 65) && (data[start + i] <= 70))
                    value |= (data[start + i] - 55);
                else if ((data[start + i] >= 97) && (data[start + i] <= 102))
                    value |= (data[start + i] - 87);
                else
                    return -1;
            }
            return value;
        }

        //private int byte2Deci(byte[] data, int start, int len)
        //{
        //    int value = 0;

        //    if (len >= 8) return -1;

        //    for (int i = 0; i < len; i++)
        //    {
        //        value *= 10;
        //        if ((data[start + i] >= 48) && (data[start + i] <= 57))
        //            value += (data[start + i] - 48);
        //        else
        //            return -1;
        //    }
        //    return value;
        //}

        double acc3D(double lat, double lon, double alt)
        {
            double N;
            double sinLat, cosLat, sinLon, cosLon;
            double x, y, z;
            double latFloor, lonFloor;

            lat /= 100.0;
            lon /= 100.0;

            latFloor = Math.Floor(lat);
            lonFloor = Math.Floor(lon);

            lat = latFloor + ((lat - latFloor) * 100.0 / 60.0);
            lon = lonFloor + ((lon - lonFloor) * 100.0 / 60.0);

            lat = lat * 3.1415926535898 / 180.0;
            lon = lon * 3.1415926535898 / 180.0;

            sinLat = Math.Sin(lat);
            cosLat = Math.Cos(lat);
            sinLon = Math.Sin(lon);
            cosLon = Math.Cos(lon);

            N = 6378137.0 / Math.Sqrt(1.0 - 0.00669437999014 * sinLat * sinLat);

            x = (N + alt) * cosLat * cosLon;
            y = (N + alt) * cosLat * sinLon;
            z = (N * (1.0 - 0.00669437999014) + alt) * sinLat;

            x -= trueValue[0];
            y -= trueValue[1];
            z -= trueValue[2];

            return (Math.Sqrt(x * x + y * y + z * z));
        }

        /// <summary>
        /// GGA语句解析
        /// 有时间把解析数据封装
        /// </summary>
        /// <param name="data"></param>
        /// <param name="len"></param>
        public void decGga(byte[] data, int len)
        {
            posInfo posTmp = new posInfo();

            len -= 2;
            if (len < 10) return;

            int check = xorCheck(data, 1, len - 3);
            int checkTmp = ascii2Int(data, len - 2, 2);
            if ((check & 0xff) != checkTmp) return;

            /*收到GGA之后刷新显示图*/
            if (homeTmp.bRefreshFlag)
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        if (homeTmp.formCn0 != null && !homeTmp.formCn0.IsDisposed) homeTmp.formCn0.refreshCn0();
                        if (homeTmp.formView != null && !homeTmp.formView.IsDisposed) homeTmp.formView.RefreshView();
                        if (homeTmp.form2D != null && !homeTmp.form2D.IsDisposed) homeTmp.form2D.refresh2D();
                        if ((homeTmp.formAcc != null) && (!homeTmp.formAcc.IsDisposed)) homeTmp.formAcc.refreshAxis(homeTmp.navGgaMsg.ggaCount, homeTmp.navGgaMsg.acc3D);
                    }));
                }
                catch { }
            }

            /*GGA数据解析*/
            homeTmp.navGgaMsg.init0Var();
            List<string> listData = new List<string>();
            getDataFromStr(listData, data, len);
            homeTmp.navGgaMsg.utcTime = double.Parse(listData[1]);
            homeTmp.navGgaMsg.lat = double.Parse(listData[2]);
            homeTmp.navGgaMsg.latMark = listData[3];
            homeTmp.navGgaMsg.lon = double.Parse(listData[4]);
            homeTmp.navGgaMsg.lonMark = listData[5];
            homeTmp.navGgaMsg.flag = listData[6];
            homeTmp.navGgaMsg.svNum = int.Parse(listData[7]);
            homeTmp.navGgaMsg.hdop = double.Parse(listData[8]);//Hdop
            homeTmp.navGgaMsg.alt = double.Parse(listData[9]);//高度
            homeTmp.navGgaMsg.valid = true;

            /*3D精度存储以后会更新删除这个变量*/
            if ((homeTmp.formAcc != null) && (!homeTmp.formAcc.IsDisposed))
            {
                homeTmp.navGgaMsg.acc3D = acc3D(homeTmp.navGgaMsg.lat, homeTmp.navGgaMsg.lon, homeTmp.navGgaMsg.alt);
                homeTmp.navGgaMsg.ggaCount++;
            }

            /*2D精度画图变量*/
            posTmp.lat = homeTmp.navGgaMsg.lat;
            posTmp.lon = homeTmp.navGgaMsg.lon;
            posTmp.alt = homeTmp.navGgaMsg.alt;
            homeTmp.posInfos.Add(posTmp);

            /*收到GGA语句之后清空GSA和GSV*/
            homeTmp.navGsaMsg.Clear();
            homeTmp.navGsvMsg.Clear();


        }

        /// <summary>
        /// GSA语句解析
        /// </summary>
        /// <param name="data"></param>
        /// <param name="len"></param>
        public void decGsa(byte[] data, int len)
        {
            len -= 2;
            if (len < 10) return;
            int check = xorCheck(data, 1, len - 3);
            int checkTmp = ascii2Int(data, len - 2, 2);
            if ((check & 0xff) != checkTmp) return;
            int svidId;

            gsaMsg gsaTmp = new gsaMsg();
            List<string> listData = new List<string>();
            getDataFromStr(listData, data, len);
            switch (data[2])
            {
                case 0x50://GP P
                    gsaTmp.type = 0;
                    break;
                case 0x44://BD D
                    gsaTmp.type = 1;
                    break;
                case 0x4C://GL L
                    gsaTmp.type = 2;
                    break;
                case 0x41://GA A
                    gsaTmp.type = 3;
                    break;
                default://GNGGA
                    gsaTmp.type = 4;
                    break;
            }

            gsaTmp.svNum = 0;
            for (int i = 0; i < 12; i ++)
            {
                if (listData[i + 3] == "-1") break;
                svidId = int.Parse(listData[i + 3]);
                gsaTmp.svidId[gsaTmp.svNum++] = svidId;
            }

            gsaTmp.pdop = 0;
            gsaTmp.hdop = 0;
            gsaTmp.vdop = 0;

            homeTmp.navGsaMsg.Add(gsaTmp);
        }

        /// <summary>
        /// GSV语句解析
        /// </summary>
        /// <param name="data"></param>
        /// <param name="len"></param>
        public void decGsv(byte[] data, int len)
        {
            int svidNum;
            int type;

            len -= 2;
            if (len < 12) return;
            int check = xorCheck(data, 1, len - 3);
            int checkTmp = ascii2Int(data, len - 2, 2);
            if ((check & 0xff) != checkTmp) return;

            switch (data[2])
            {
                case 0x50://GP P
                    type = 0;
                    break;
                case 0x44://BD D
                    type = 1;
                    break;
                case 0x4C://GL L
                    type = 2;
                    break;
                case 0x41://GA A
                    type = 3;
                    break;
                default:
                    return;
            }

            List<string> listData = new List<string>();
            getDataFromStr(listData, data, len);

            if (listData.Count > 4) svidNum = (listData.Count - 4) / 4;
            else return;

            for (int i = 0; i < svidNum; i++)
            {
                int svid = int.Parse(listData[4 + i * 4]);
                int el = int.Parse(listData[5 + i * 4]);
                int az = int.Parse(listData[6 + i * 4]);
                int cn0 = int.Parse(listData[7 + i * 4]);

                gsvMsg navMsgAdd = new gsvMsg
                {
                    svid = svid,
                    el = el,
                    az = az,
                    cn0 = cn0,
                    type = type
                };
                foreach (gsaMsg g in homeTmp.navGsaMsg)
                {
                    if (g.svidId.Contains(svid))
                    {
                        navMsgAdd.isInCh = 1;
                        break;
                    }
                }
                homeTmp.navGsvMsg.Add(navMsgAdd);
            }
        }

        /// <summary>
        /// BSI语句解析
        /// </summary>
        /// <param name="data"></param>
        /// <param name="len"></param>
        public void decBsi(byte[] data, int len)
        {
            //if (homeTmp.status_g["BSI"] == 0) 
            //    return;

            len -= 2;
            if (len < 12) return;
            int check = xorCheck(data, 1, len - 3);
            int checkTmp = ascii2Int(data, len - 2, 2);
            if ((check & 0xff) != checkTmp) return;

            List<string> listData = new List<string>();
            getDataFromStr(listData, data, len);

            if (homeTmp.formRd != null && !homeTmp.formRd.IsDisposed)
                homeTmp.formRd.bsiCmdShow(listData);

            homeTmp.decDataFlag["BSI"] = 0;
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="listData"></param>
        /// <param name="bData"></param>
        /// <param name="len"></param>
        private void getDataFromStr(List<string> listData, byte[] bData, int len)
        {
            int startPos = 0;

            if (bData.Length < 1) return;
            if (len < 1) return;

            for (int i = 0; i < len; i++)
            {
                if (bData[i] != ',' && i != (len - 1) && bData[i] != '*')
                {
                    if (bData[i] == ' ' || bData[i] == '=') startPos = i + 1;
                    continue;
                }
                else
                {
                    if (startPos == i)
                    {
                        listData.Add("-1");//若空值赋值-1，此处赋值可自行定义
                        startPos = i + 1;
                        if (i == len - 1)//若最后一个为逗号，需在加一个空值，即添加-1代表空
                        {
                            listData.Add("-1");
                        }
                    }
                    else
                    {
                        string s;
                        if (i == len - 1)//最后一个数时提取字符串
                        {
                            s = System.Text.Encoding.ASCII.GetString(bData.Skip(startPos).Take(i - startPos + 1).ToArray());
                        }
                        else
                        {
                            s = System.Text.Encoding.ASCII.GetString(bData.Skip(startPos).Take(i - startPos).ToArray());
                        }
                        startPos = i + 1;
                        listData.Add(s);
                    }

                    if (bData[i] == '*') break;
                }
            }
        }

        private int typeMask = 0xf;
        private void contextMenuStripCn0_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "GPS") typeMask ^= (1 << 0);
            else if (e.ClickedItem.Text == "BDS") typeMask ^= (1 << 1);
            else if (e.ClickedItem.Text == "GLO") typeMask ^= (1 << 2);
            else if (e.ClickedItem.Text == "GAL") typeMask ^= (1 << 3);
            else if (e.ClickedItem.Text == "ALL")
            {
                if (typeMask == 0xf) typeMask = 0;
                else typeMask = 0xf;
            }

            gpsToolStripMenuItem.Checked = (typeMask & (1 << 0)) == (1 << 0);
            bdsToolStripMenuItem.Checked = (typeMask & (1 << 1)) == (1 << 1);
            gloToolStripMenuItem.Checked = (typeMask & (1 << 2)) == (1 << 2);
            galToolStripMenuItem.Checked = (typeMask & (1 << 3)) == (1 << 3);
            allToolStripMenuItem.Checked = (typeMask & 0xf) == 0xf;
        }

        /// <summary>
        /// 显示信号强度载噪比
        /// </summary>
        private void displayCn0()
        { 
            if (homeTmp.navGsvMsg.Count <= 0) return;

            string s_head;
            chartCn0.ChartAreas[0].AxisX.LabelStyle.Enabled = true;

            chartCn0.Series[0].Points.Clear();

            for (int i = 0; i < homeTmp.navGsvMsg.Count; i++)
            {
                int svidId = homeTmp.navGsvMsg[i].svid;
                int cn0 = homeTmp.navGsvMsg[i].cn0;
                int type = homeTmp.navGsvMsg[i].type;

                if ((typeMask & (1 << type)) != (1 << type)) continue;
                switch (type)
                {
                    case 0:
                        //newImage = Image.FromFile("./images/US.png");
                        s_head = "L";
                        break;
                    case 1:
                        //Image newImage = Image.FromFile("./images/China.png");
                        s_head = "B";
                        break;
                    case 2:
                        //newImage = Image.FromFile("./images/Russia.png");
                        s_head = "G";
                        break;
                    case 3:
                        //Image newImage = Image.FromFile("./images/China.png");
                        s_head = "B";
                        break;
                    default:
                        return;
                }


                chartCn0.Series[0].Points.AddXY(s_head + svidId.ToString(), cn0);
                chartCn0.Series[0].MarkerColor = Color.Red;
                if (homeTmp.navGsvMsg[i].isInCh == 1) chartCn0.Series[0].Points[chartCn0.Series[0].Points.Count - 1].Color = Color.FromArgb(155, 187, 89);
            }
        }

        /// <summary>
        /// 重绘chart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chartCn0_Paint(object sender, PaintEventArgs e)
        {
            displayCn0();
        }

        /// <summary>
        /// 清空chart
        /// </summary>
        public void clearCn0()
        {
            homeTmp.navGsvMsg.Clear();
            chartCn0.Series[0].Points.Clear();
        }

        /// <summary>
        /// 刷新chart
        /// </summary>
        public void refreshCn0()
        {
            chartCn0.Refresh();
        }

        /// <summary>
        /// 改变大小时重绘图形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCn0_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        /// <summary>
        /// 关闭界面时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCn0_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
