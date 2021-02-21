using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.IO;

namespace GnssView.project
{
    public partial class FormHT1902 : Form
    {
        public FormHT1902(FormHome home)
        {
            InitializeComponent();
            homeTmp = home;
            cbWorkMode.SelectedIndex = 0;
        }

        private FormHome homeTmp;

        private byte[] setWeek = new byte[2];
        private byte[] setSec = new byte[4];
        private byte[] setLat = new byte[8];
        private byte[] setLon = new byte[8];
        private byte[] setHeight = new byte[4];

        /* 切换模式命令 */
        private void buttonSetMode_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] cmdByte = new byte[14] { 0x24, 0x42, 0x49, 0x4E, 0x45, 0x00, 0x02, 0x00, 0x00, 0x04, 0x04, 0x00, 0x0D, 0x0A };
                string strTmp = cbWorkMode.SelectedItem.ToString();
                byte bTmp = Convert.ToByte(strTmp.Substring(2, 2), 16);

                cmdByte[9] = bTmp;/*模式*/
                cmdByte[10] = bTmp;/*校验和*/
                homeTmp.serialSend(cmdByte, 0, 14);

            }
            catch
            {
                return;
            }
        }

        /* 时间位置设置 */
        private void buttonSetTimePos_Click(object sender, EventArgs e)
        {
            byte[] bData = new byte[39];

            bData[0] = 0x24;
            bData[1] = 0x42;
            bData[2] = 0x49;
            bData[3] = 0x4E;
            bData[4] = 0x35;
            bData[5] = 0x00;
            bData[6] = 0x18;
            bData[7] = 0x00;

            bData[8] = 0x00;//序号

            bData[9] = setWeek[0];
            bData[10] = setWeek[1];

            bData[11] = setSec[0];
            bData[12] = setSec[1];
            bData[13] = setSec[2];
            bData[14] = setSec[3];

            bData[15] = setLat[0];
            bData[16] = setLat[1];
            bData[17] = setLat[2];
            bData[18] = setLat[3];
            bData[19] = setLat[4];
            bData[20] = setLat[5];
            bData[21] = setLat[6];
            bData[22] = setLat[7];

            bData[23] = setLon[0];
            bData[24] = setLon[1];
            bData[25] = setLon[2];
            bData[26] = setLon[3];
            bData[27] = setLon[4];
            bData[28] = setLon[5];
            bData[29] = setLon[6];
            bData[30] = setLon[7];

            bData[31] = setHeight[0];
            bData[32] = setHeight[1];
            bData[33] = setHeight[2];
            bData[34] = setHeight[3];

            UInt16 check = 0;
            for (int i = 8; i <= 34; i ++) check += bData[i];

            bData[35] = (byte)(check & 0xff);
            bData[36] = (byte)((check >> 8) & 0xff);

            bData[37] = 0x0D;
            bData[38] = 0x0A;
        }

        /* 发送电文 */
        private void btnLoadMsg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.AutoUpgradeEnabled = false;
            dialog.Title = "加载文件";
            dialog.Filter = "*.*|*.*|*.txt|*.txt|*.dat|*.dat|*.log|*.log";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string localFilePath = dialog.FileName.ToString();
                try
                {
                    /*创建一个 StreamReader 的实例来读取文件，using 语句也能关闭 StreamReader*/
                    using (FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
                    {
                        int len = (int)fs.Length;
                        byte[] fData = new byte[len];

                        fs.Read(fData, 0, len);
                        fs.Close();

                        for (int i = 0; i < len; i++)
                        {
                            if (len - i < 8) break;
                            if ((fData[i] == 0x24) && (fData[i + 1] == 0x42) && (fData[i + 2] == 0x49) && (fData[i + 3] == 0x4E))
                            {
                                switch (fData[i + 4])
                                {
                                    case 0x37:
                                        if (checkBoxGPS.Checked)
                                        {
                                            homeTmp.serialSend(fData, i, 134);
                                            i += 133;
                                        }
                                        break;
                                    case 0x39:
                                        if (checkBoxB1D1.Checked)
                                        {
                                            homeTmp.serialSend(fData, i, 134);
                                            i += 133;
                                        }
                                        break;
                                    case 0x43:
                                        if (checkBoxB1D2.Checked)
                                        {
                                            homeTmp.serialSend(fData, i, 414);
                                            i += 413;
                                        }
                                        break;
                                    default:
                                        break;

                                }
                            }
                        }
                    }
                }
                catch { }
            }
        }

        /* 1902界面显示 */
        public void ht1902DecPro(byte[] ht1902MsgBuf, int len)
        {
            int check = 0, checkTmp = 0, lenTmp = 0, byteTmp;

            for (int i = 8; i < len - 4; i++) check += ht1902MsgBuf[i];

            byteTmp = int.Parse(ht1902MsgBuf[len - 3].ToString());
            checkTmp = ht1902MsgBuf[len - 4] + (byteTmp << 8);
            byteTmp = int.Parse(ht1902MsgBuf[7].ToString());
            lenTmp = ht1902MsgBuf[6] + ht1902MsgBuf[7];

            if (checkTmp != check) return;
            if (lenTmp != len - 12) return;

            setWeek = ht1902MsgBuf.Skip(17).Take(2).ToArray();
            setSec = BitConverter.GetBytes((int)(BitConverter.ToDouble(ht1902MsgBuf, 9)));
            setLat = ht1902MsgBuf.Skip(19).Take(8).ToArray();
            setLon = ht1902MsgBuf.Skip(27).Take(8).ToArray();
            setHeight = ht1902MsgBuf.Skip(35).Take(4).ToArray();

            try
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    labelSvid.Text = (ht1902MsgBuf[8]).ToString();
                    labelGPSSec.Text = (BitConverter.ToDouble(ht1902MsgBuf, 9)).ToString();
                    labelGPSWeek.Text = (BitConverter.ToInt16(ht1902MsgBuf, 17)).ToString();
                    labelLat.Text = (BitConverter.ToDouble(ht1902MsgBuf, 19) * 180 / Math.PI).ToString();
                    labelLon.Text = (BitConverter.ToDouble(ht1902MsgBuf, 27) * 180 / Math.PI).ToString();
                    labelHeight.Text = (BitConverter.ToSingle(ht1902MsgBuf, 35)).ToString();
                    labelNorthV.Text = (BitConverter.ToSingle(ht1902MsgBuf, 39)).ToString();
                    labelEastV.Text = (BitConverter.ToSingle(ht1902MsgBuf, 43)).ToString();
                    labelUp.Text = (BitConverter.ToSingle(ht1902MsgBuf, 47)).ToString();
                    labelPdop.Text = (BitConverter.ToInt16(ht1902MsgBuf, 51)).ToString();// / 10
                    labelGnssMode.Text = (BitConverter.ToInt16(ht1902MsgBuf, 53).ToString());
                }));
            }
            catch { }

            for (int i = 31; i <= 66; i++)
            {
                foreach (Control cn in this.panelBottom.Controls)
                {
                    if (cn.TabIndex != i) continue;

                    StringBuilder strSvidTmp = new StringBuilder();

                    strSvidTmp.AppendFormat("{0:D3}" + " " + "{1:D3}" + " " + "{2:D3}" + " " + "{3:D3}" + " ", ht1902MsgBuf[55 + (i - 31) * 4], ht1902MsgBuf[56 + (i - 31) * 4],
                        ht1902MsgBuf[57 + (i - 31) * 4], ht1902MsgBuf[58 + (i - 31) * 4]);
                    this.Invoke(new MethodInvoker(delegate
                    {
                        cn.Text = strSvidTmp.ToString();
                    }));
                }
            }
        }

        private void FormHT1902_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
