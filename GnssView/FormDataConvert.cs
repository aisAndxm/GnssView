﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace GnssView
{
    public partial class FormDataConvert : Form
    {
        public FormDataConvert()
        {
            InitializeComponent();

            comboBoxOri.SelectedIndex = 0;
            comboBoxConvert.SelectedIndex = 1;
            textBoxMoveNum.Text = "0";
            comboBoxSel.SelectedIndex = 0;
        }

        private int DataTypeflag = 0;
        string[] strPathName = new string[3];
        string[] strFolderName = new string[3];
        byte[] dataTab = { 1, 3, 0xFF, 0xFD };

        /*list实体类深复制*/
        public List<char> CopyList(List<char> srcList)
        {
            List<char> list = new List<char>();
            foreach (char obj in srcList)
                list.Add(obj);
            return list;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int oriType, convType;
            int moveNum, dataLen;
            string outStrData = null;

            oriType = comboBoxOri.SelectedIndex;
            convType = comboBoxConvert.SelectedIndex;

            if (oriType == -1 || convType == -1)
            {
                MessageBox.Show("请选择转换类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxMoveNum.Text, out moveNum))
            {
                MessageBox.Show("移位数错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string strOriData = richTextBoxOri.Text;
            if (strOriData == null)
            {
                MessageBox.Show("填写数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<char> charList = new List<char>();

            for (dataLen = 0; dataLen < strOriData.Length; dataLen++)
            {
                if ((strOriData[dataLen] == ',') || (strOriData[dataLen] == ' ') || (strOriData[dataLen] == '\r') 
                    || (strOriData[dataLen] == '\n') || (dataLen + 1 == strOriData.Length))
                {
                    if (charList.Count == 0) continue;

                    if (dataLen + 1 == strOriData.Length) charList.Add(strOriData[dataLen]);

                    /*把所有数据转换为二进制字符串数据，这样可以保证所转换的数据可以无限长*/
                    List<char> binaryList = new List<char>();
                    switch (comboBoxOri.SelectedIndex)
                    { 
                        case 0:/*十六进制*/
                            break;
                        case 1:/*十进制*/
                            break;
                        case 2:/*八进制*/
                            break;
                        case 3:/*二进制*/
                            binaryList = CopyList(charList);
                            break;
                        default:
                            MessageBox.Show("选择数据格式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                    }
                    charList.Clear();

                    /*移位位数*/
                    if (moveNum > 0)
                    {
                        char[] charArray = Enumerable.Repeat('0', moveNum).ToArray();
                        binaryList.AddRange(charArray);
                    }
                    else if (moveNum < 0 && moveNum < binaryList.Count)
                        binaryList.RemoveRange(binaryList.Count - moveNum, moveNum);
                    else if (moveNum < 0 && moveNum >= binaryList.Count)
                        binaryList.Clear();

                    /*输出数据进制数*/
                    int bitAlign = 0;
                    switch (comboBoxConvert.SelectedIndex)
                    {
                        case 0:/*十六进制*/
                            bitAlign = 4;
                            outStrData += "0x";
                            break;
                        case 1:/*十进制*/
                            if (binaryList.Count > 64)
                            {
                                MessageBox.Show("转换成十进制的数据位数过大", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            break;
                        case 2:/*八进制*/
                            bitAlign = 4;
                            break;
                        case 3:/*二进制*/
                            outStrData += string.Join(null,binaryList.ToArray());
                            if (dataLen + 1 != strOriData.Length) 
                                outStrData += strOriData[dataLen];
                            continue;
                        default:
                            MessageBox.Show("选择数据格式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                    }

                    /*高低位对齐*/
                    int intTmp = 0;
                    int bitLen = binaryList.Count % bitAlign;
                    if (checkBoxAlign.Checked)
                    {
                        for (int pos = 0; pos < binaryList.Count / bitAlign; pos++)
                        {
                            intTmp = 0;
                            intTmp = ((binaryList[bitAlign * pos] - 48) << 3) + ((binaryList[bitAlign * pos + 1] - 48) << 2) +
                                ((binaryList[bitAlign * pos + 2] - 48) << 1) + (binaryList[bitAlign * pos + 3] - 48);

                            outStrData += Convert.ToString(intTmp, 16);
                        }

                        if (bitLen > 0)
                        {
                            for (int pos = 0; pos < bitLen; pos++)
                            {
                                intTmp <<= 1;
                                intTmp += binaryList[pos] - 48;
                            }
                            outStrData += Convert.ToString(intTmp, 16);
                        }
                    }
                    else 
                    {
                        if (bitLen > 0)
                        {
                            for (int pos = 0; pos < bitLen; pos++)
                            {
                                intTmp <<= 1;
                                intTmp += binaryList[pos] - 48;
                            }
                            outStrData += Convert.ToString(intTmp, 16);
                        }

                        for (int pos = 0; pos < binaryList.Count / bitAlign; pos++)
                        {
                            intTmp = 0;
                            intTmp = ((binaryList[bitAlign * pos + bitLen] - 48) << 3) + ((binaryList[bitAlign * pos + bitLen + 1] - 48) << 2) +
                                ((binaryList[bitAlign * pos + bitLen + 2] - 48) << 1) + (binaryList[bitAlign * pos + bitLen + 3] - 48);

                            outStrData += Convert.ToString(intTmp, 16);
                        }
                    }
                    if (dataLen + 1 == strOriData.Length) break;
                    outStrData += strOriData[dataLen];
                }
                else
                {
                    charList.Add(strOriData[dataLen]);
                }
            }

            richTextBoxResult.Text = outStrData;
        }

        const double WGS_MAJOR = 6378137.0;			//a - WGS-84 earth's semi major axis
        const double WGS_MINOR = 6356752.3142;		//b - WGS-84 earth's semi minor axis
        const double WGS_E1_SQRT = 0.00669437999014;		// first  numerical eccentricity
        const double WGS_E2_SQRT = 0.0067394967422751;		// second numerical eccentricity

        /// <summary>
        /// 经纬高转换为XYZ
        /// </summary>
        /// <param name="lla">经纬高</param>
        /// <param name="ecef">XYZ坐标</param>
        void llaToEcef(struct_lla_coord lla, out struct_ecef_coord ecef)
        {
            double N = 0.0;
            double sinLat, cosLat;
            double sinLon, cosLon;

            sinLat = Math.Sin(lla.lat);
            cosLat = Math.Cos(lla.lat);
            sinLon = Math.Sin(lla.lon);
            cosLon = Math.Cos(lla.lon);

            N = WGS_MAJOR / Math.Sqrt(1.0 - WGS_E1_SQRT * sinLat * sinLat);

            ecef.x = (N + lla.alt) * cosLat * cosLon;
            ecef.y = (N + lla.alt) * cosLat * sinLon;
            ecef.z = (N * (1.0 - WGS_E1_SQRT) + lla.alt) * sinLat;
        }

        /// <summary>
        /// ENU坐标转化为XYZ坐标
        /// </summary>
        /// <param name="enu">ENU坐标</param>
        /// <param name="lla">经纬高</param>
        /// <param name="xyz">XYZ坐标</param>
        void enuToEcef(struct_enu_coord enu, struct_lla_coord lla, out struct_ecef_coord xyz)
        {
            double sinLat = 0.0, cosLat = 0.0, sinLon = 0.0, cosLon = 0.0;

            /* ENU坐标系转化为XYZ坐标系的转化矩阵 */
            sinLat = Math.Sin(lla.lat);//fai lat
            cosLat = Math.Cos(lla.lat);
            sinLon = Math.Sin(lla.lon);//lamda lon
            cosLon = Math.Cos(lla.lon);

            /* xyz坐标等于转化矩阵乘以enu */
            xyz.x = -sinLon * enu.e - sinLat * cosLon * enu.n + cosLat * cosLon * enu.u;
            xyz.y = cosLon * enu.e - sinLat * sinLon * enu.n + sinLon * cosLat * enu.u;
            xyz.z = cosLat * enu.n + sinLat * enu.u;
        }

        /// <summary>
        /// xyz坐标转化为ENU坐标
        /// </summary>
        /// <param name="xyz">xyz坐标</param>
        /// <param name="lla">经纬高</param>
        /// <param name="enu">enu坐标</param>
        void ecefToEnu(struct_ecef_coord xyz, struct_lla_coord lla, out struct_enu_coord enu)
        {
            double sinLat = 0.0, cosLat = 0.0, sinLon = 0.0, cosLon = 0.0;

            /*计算ECEF直角坐标与ENU坐标系之间的转换矩阵*/
            sinLat = Math.Sin(lla.lat);
            cosLat = Math.Cos(lla.lat);
            sinLon = Math.Sin(lla.lon);
            cosLon = Math.Cos(lla.lon);

            /*enu坐标等于转化矩阵乘以xyz*/
            enu.e = (-sinLon) * xyz.x + cosLon * xyz.y;
            enu.n = (-sinLat) * cosLon * xyz.x - sinLat * sinLon * xyz.y + cosLat * xyz.z;
            enu.u = cosLat * cosLon * xyz.x + sinLon * cosLat * xyz.y + sinLat * xyz.z;
        }

        /// <summary>
        /// XYZ坐标转换为经纬高
        /// </summary>
        /// <param name="ecef">ecef坐标系的xyz </param>
        /// <param name="lla">经纬高</param>
        void ecefToLla(struct_ecef_coord ecef, out struct_lla_coord lla)
        {
            double p = 0.0, theta = 0.0, sinTheta = 0.0, cosTheta = 0.0, temp = 0.0, temp1 = 0.0, sinLat = 0.0;
            double up_lat = 0.0, low_lat = 0.0;
            double x = 0.0, y = 0.0, z = 0.0, r = 0.0;

            lla.lat = 0;
            lla.lon = 0;
            lla.alt = 0;

            x = ecef.x;
            y = ecef.y;
            z = ecef.z;
            r = x * x + y * y;

            if (Math.Abs(r) < 1e-12) return;

            p = Math.Sqrt(r);
            temp = (z * WGS_MAJOR) / (p * WGS_MINOR);
            theta = Math.Atan(temp);
            sinTheta = Math.Sin(theta);
            cosTheta = Math.Cos(theta);
            up_lat = z + WGS_E2_SQRT * WGS_MINOR * sinTheta * sinTheta * sinTheta;
            low_lat = p - WGS_E1_SQRT * WGS_MAJOR * cosTheta * cosTheta * cosTheta;

            lla.lat = Math.Atan2(up_lat, low_lat);
            lla.lon = Math.Atan2(y, x);

            sinLat = Math.Sin(lla.lat);
            temp = WGS_MAJOR / Math.Sqrt(1.0 - WGS_E1_SQRT * sinLat * sinLat);
            temp1 = Math.Cos(lla.lat);

            if (Math.Abs(r) < 1e-12) return;

            lla.alt = (p / temp1) - temp;
        }


        private void btnCoor_Click(object sender, EventArgs e)
        {
            struct_lla_coord lla;
            struct_ecef_coord xyz;
            struct_enu_coord enu;

            switch (comboBoxSel.SelectedIndex)
            { 
                case 0:
                    if (!double.TryParse(richTextBoxLat.Text, out lla.lat) || !double.TryParse(richTextBoxLon.Text, out lla.lon) || !double.TryParse(richTextBoxAlt.Text, out lla.alt))
                        break;
                    lla.lat /= (180.0 / Math.PI);
                    lla.lon /= (180.0 / Math.PI);
                    llaToEcef(lla, out xyz);
                    richTextBoxX.Text = xyz.x.ToString("f6");
                    richTextBoxY.Text = xyz.y.ToString("f6");
                    richTextBoxZ.Text = xyz.z.ToString("f6");
                    ecefToEnu(xyz, lla, out enu);
                    richTextBoxE.Text = enu.e.ToString("f6");
                    richTextBoxN.Text = enu.n.ToString("f6");
                    richTextBoxU.Text = enu.u.ToString("f6");
                    break;
                case 1:
                    if (!double.TryParse(richTextBoxX.Text, out xyz.x) || !double.TryParse(richTextBoxY.Text, out xyz.y) || !double.TryParse(richTextBoxZ.Text, out xyz.z))
                        break;
                    ecefToLla(xyz, out lla);
                    ecefToEnu(xyz, lla, out enu);
                    richTextBoxLat.Text = (lla.lat * (180.0 / Math.PI)).ToString("f6");
                    richTextBoxLon.Text = (lla.lon * (180.0 / Math.PI)).ToString("f6");
                    richTextBoxAlt.Text = lla.alt.ToString("f6");
                    richTextBoxE.Text = enu.e.ToString("f6");
                    richTextBoxN.Text = enu.n.ToString("f6");
                    richTextBoxU.Text = enu.u.ToString("f6");
                    break;
                case 2:
                    if (!double.TryParse(richTextBoxE.Text, out enu.e) || !double.TryParse(richTextBoxN.Text, out enu.n) || !double.TryParse(richTextBoxU.Text, out enu.u))
                        break;
                    //enuToEcef(enu, 
                    //richTextBoxE.Text = xyz.x.ToString("f6");
                    //richTextBoxN.Text = xyz.y.ToString("f6");
                    //richTextBoxU.Text = xyz.z.ToString("f6");
                    //richTextBoxLat.Text = lla.lat.ToString("f6");
                    //richTextBoxLon.Text = lla.lon.ToString("f6");
                    //richTextBoxAlt.Text = lla.alt.ToString("f6");
                    break;
                default:
                    break;
            }
        }

        void rfDataConvert()
        {
            string strFolderNameTmp;

            strFolderNameTmp = strFolderName[2] + "\\rfDataOut-" + System.DateTime.Now.ToString("yyyyMMddTHHmmss") + ".bin";
            try
            {
                using (StreamReader fpDataIn = new StreamReader(new FileStream(strPathName[2], FileMode.Open, FileAccess.Read)))
                {
                    BinaryWriter fpDataOut = new BinaryWriter(new FileStream(strFolderNameTmp, FileMode.OpenOrCreate, FileAccess.Write));
                    while (true)
                    {
                        string strTmp;
                        while (true)
                        {
                            strTmp = fpDataIn.ReadLine();

                            if (string.Compare(strTmp, 0, "0x", 0, 2) == 0) break;
                        }

                        if (UInt32.TryParse(strTmp, NumberStyles.HexNumber, new CultureInfo("en-US"), out UInt32 data))
                        {
                            for (UInt32 count = 0; count < 16; count++)
                            {
                                byte dataOut = (byte)((data >> (int)(30 - count * 2)) & 3);
                                fpDataOut.Write(dataTab[dataOut]);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        void rfBin2Bin()
        {
            string strFolderNameTmp;

            strFolderNameTmp = strFolderName[2] + "\\rfDataOut-" + System.DateTime.Now.ToString("yyyyMMddTHHmmss") + ".bin";
            try
            {
                using (StreamReader fpDataIn = new StreamReader(new FileStream(strPathName[2], FileMode.Open, FileAccess.Read)))
                {
                    BinaryWriter fpDataOut = new BinaryWriter(new FileStream(strFolderNameTmp, FileMode.OpenOrCreate, FileAccess.Write));
                    while (true)
                    {
                        int msg = fpDataIn.Read();

                        if (msg == 0x0a)
                        {
                            msg = fpDataIn.Read();
                            if (msg == 0x0d)
                            {
                                msg = fpDataIn.Read();
                                if (msg == 0x0a)
                                    break;
                            }
                        }
                    }
                    while (true)
                    {
                        char[] charMsg = new char[4];
                        fpDataIn.Read(charMsg, 0, 4);

                        UInt32 data = 0;
                        for (UInt32 i = 0; i < 4; i++)
                        {
                            data <<= 8;
                            data |= (byte)(charMsg[i] & 0xff);
                        }

                        for (UInt32 count = 0; count < 16; count++)
                        {
                            byte dataOut = (byte)((data >> (int)(30 - count * 2)) & 3);
                            fpDataOut.Write(dataTab[dataOut]);
                        }
                    }
                }
            }
            catch { }
        }

        void rfBinDataConvert()
        {
            byte dataOut;
            byte[] dataTmp = new byte[64];
            byte[] data = new byte[64];
            UInt32 count, dataLen = 0, wr = 0, rd = 0;
            bool startFlag = true;
            string strFolderNameTmp;

            strFolderNameTmp = strFolderName[2] + "\\rfInDataI-" + System.DateTime.Now.ToString("yyyyMMddTHHmmss") + ".bin";
            try
            {
                using (BinaryReader fpDataIn = new BinaryReader(new FileStream(strPathName[2], FileMode.Open, FileAccess.Read)))
                {
                    BinaryWriter fpDataOut = new BinaryWriter(new FileStream(strFolderNameTmp, FileMode.OpenOrCreate, FileAccess.Write));
                    Array.Clear(data, 0, 64);
                    while (true)
                    {
                        if (fpDataIn.PeekChar() == -1) break;
                        data[wr++] = fpDataIn.ReadByte();
                        if (wr >= 64) wr = 0;

                        if (wr > rd) dataLen = wr - rd;
                        else dataLen = wr + 64 - rd;
                        if (dataLen < 20) continue;

                        if (startFlag)
                        {
                            if (data[rd] == 'r')
                            {
                                for (int i = 0; i < 16; i++)
                                    dataTmp[i] = data[(rd + i) % 64];
                                if (string.Compare(dataTmp.ToString(), "rf rd start...\r\n") == 0)
                                {
                                    rd += 16; if (rd >= 64) rd = 0;
                                    startFlag = false;
                                    continue;
                                }
                            }
                            rd += 1; if (rd >= 64) rd = 0;
                            continue;
                        }

                        if (data[rd] == 'r')
                        {
                            for (int i = 0; i < 20; i++)
                                dataTmp[i] = data[(rd + i) % 64];
                            if (string.Compare(dataTmp.ToString(), "rf dataI rd end...\r\n") == 0)
                            {
                                rd += 20; if (rd >= 64) rd = 0;
                                fpDataOut.Close();
                                strFolderNameTmp = strFolderName[2] + "\\rfInDataQ-" + System.DateTime.Now.ToString("yyyyMMddTHHmmss") + ".bin";
                                fpDataOut = new BinaryWriter(new FileStream(strFolderNameTmp, FileMode.OpenOrCreate, FileAccess.Write));
                                continue;
                            }
                            else if (string.Compare(dataTmp.ToString(), "rf dataQ rd end...\r\n") == 0)
                            { 
                                rd += 20; if (rd >= 64) rd = 0;
                                //fpDataOut.Close();
                                //strFolderNameTmp = strFolderName[2] + "\\rfInDataI-" + System.DateTime.Now.ToString("yyyyMMddTHHmmss") + ".bin";
                                //fpDataOut = new BinaryWriter(new FileStream(strFolderNameTmp, FileMode.OpenOrCreate, FileAccess.Write));
                                continue;
                            }
                        }

                        for (count = 0; count < 4; count++)
                        {
                            dataOut = (byte)((data[rd] >> (byte)(6 - count * 2)) & 3);
                            fpDataOut.Write(dataTab[dataOut]);
                        }

                        rd++; if (rd >= 64) rd = 0;
                    }

                }


            }
            catch { }

        }

        private void btnStartConvert_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i ++)
            {
                if ((DataTypeflag & (1 << i)) == 0) continue;
                switch (i)
                {
                    case 0:
                        rfDataConvert();
                        break;
                    case 1:
                        rfBin2Bin();
                        break;
                    case 2:
                        rfBinDataConvert();
                        break;
                    default:
                        break;

                }
                DataTypeflag &= ~(1 << i);
            }
        }

        private void btnSelect1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "加载文件",
                Filter = "*.*|*.*|*.txt|*.txt|*.dat|*.dat|*.log|*.log",
                FilterIndex = 1,
                RestoreDirectory = true,
                AutoUpgradeEnabled = false
            };

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    int pos = ((Button)sender).TabIndex - btnSelect1.TabIndex;
                    strPathName[pos] = dialog.FileName.ToString();
                    switch (pos)
                    {
                        case 0:
                            textBox1.Text = strPathName[pos];       //显示文件路径到编辑框
                            break;
                        case 1:
                            textBox2.Text = strPathName[pos];       //显示文件路径到编辑框
                            break;
                        case 2:
                            textBox3.Text = strPathName[pos];       //显示文件路径到编辑框
                            break;
                        default:
                            break;
                    }
                    strFolderName[pos] = new DirectoryInfo(strPathName[pos]).Parent.FullName.ToString();

                    DataTypeflag |= (1 << pos);

                }
                catch
                { }
            }
        }
    }
}
