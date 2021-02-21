using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace GnssView
{
    public partial class FormGetMsg : Form
    {
        private FormHome msgHome;
        public FormGetMsg(FormHome home)
        {
            InitializeComponent();
            msgHome = home;
        }

        /// <summary>
        /// 1902数据解析
        /// </summary>
        public void ht1902MsgPro(byte[] data, int len)
        {
            uint cmdType = data[3];

            //string mode = "LL";

            uint lenTmp = BitConverter.ToUInt16(data, 4);

            uint checkTmp = 0;
            for (int i = 0; i < len - 5; i++)
                checkTmp += data[i];
            if ((checkTmp & 0xff) != data[len - 5]) return;
            if (lenTmp != len - 11) return;

            richTextBoxMSG.AppendText(BitConverter.ToString(data, 0, len).Replace("-", " ") + "\r\n");/*显示*/

            byte[] ht1902Msg = new byte[600];

            ht1902Msg[0] = 0x24;//$
            ht1902Msg[1] = 0x42;//B
            ht1902Msg[2] = 0x49;//I
            ht1902Msg[3] = 0x4E;//N

            /*标志两个字节*/
            if (data[6] == 0)
            {
                ht1902Msg[4] = 0x37;//标识符
                //mode = "L1";
            }
            else if (data[6] == 9)
            {
                if ((data[9] <= 5) && (data[9] >= 1))//GEO
                    ht1902Msg[4] = 0x43;//标识符
                else
                    ht1902Msg[4] = 0x39;//标识符
                //mode = "B1";
            }
            ht1902Msg[5] = 0x00;
            
            /*长度*/
            ht1902Msg[6] = (byte)((lenTmp - 2)&0xff);//长度
            ht1902Msg[7] = (byte)(((lenTmp - 2) >> 8) & 0xff);

            ht1902Msg[8] = (byte)(data[8] - 1);//帧号
            ht1902Msg[9] = data[9];//卫星号

            checkTmp = ht1902Msg[8];
            checkTmp += ht1902Msg[9];
            for (int i = 0; i < lenTmp - 4; i++)
            {
                ht1902Msg[10 + i] = data[10 + i];
                checkTmp += ht1902Msg[10 + i];
            }

            ht1902Msg[lenTmp + 6] = (byte)(checkTmp & 0xff);//校验和
            ht1902Msg[lenTmp + 7] = (byte)((checkTmp >> 8) & 0xff);
            ht1902Msg[lenTmp + 8] = 0x0D;
            ht1902Msg[lenTmp + 9] = 0x0A;

            FileStream fd = new FileStream("./ht1902msgfile.txt", FileMode.OpenOrCreate, FileAccess.Write);
            fd.Seek(0, SeekOrigin.End);
            fd.Write(ht1902Msg, 0, (int)(lenTmp + 10));
            fd.Close();

            /*ECT拼接不够详尽，严格按照手册修改后在添加*/
            //FileStream fdEct = new FileStream("./ECT.txt", FileMode.OpenOrCreate, FileAccess.Write);

            //for (int j = 0; j < 3; j++)
            //{
            //    StringBuilder strEct = new StringBuilder();
            //    strEct.AppendFormat("$ECT" + "," + "{0:D2}" + "," + "{1}" + "," + "00" + "," + "I" + "," + "{2:X8}" + "," + "{3:X8}" + "," + "{4:X8}" + "," + "{5:X8}"
            //         + "," + "{6:X8}" + "," + "{7:X8}" + "," + "{8:X8}" + "," + "{9:X8}" + "," + "{10:X8}" + "," + "{11:X8}",
            //        ht1902Msg[9], mode, BitConverter.ToInt32(ht1902Msg, 10 + j * 40),
            //        BitConverter.ToInt32(ht1902Msg, 14 + j * 40), BitConverter.ToInt32(ht1902Msg, 18 + j * 40), BitConverter.ToInt32(ht1902Msg, 22 + j * 40),
            //        BitConverter.ToInt32(ht1902Msg, 26 + j * 40), BitConverter.ToInt32(ht1902Msg, 30 + j * 40), BitConverter.ToInt32(ht1902Msg, 34 + j * 40),
            //        BitConverter.ToInt32(ht1902Msg, 38 + j * 40), BitConverter.ToInt32(ht1902Msg, 42 + j * 40), BitConverter.ToInt32(ht1902Msg, 46 + j * 40));

            //    UInt32 checkEct = 0;
            //    for (int k = 1; k < strEct.Length; k++)
            //    {
            //        checkEct ^= strEct[k];
            //    }

            //    strEct.AppendFormat("*" + "{0:X2}" + "\r\n", checkEct & 0xff);
            //    fdEct.Seek(0, SeekOrigin.End);
            //    fdEct.Write(System.Text.Encoding.Default.GetBytes(strEct.ToString()), 0, strEct.Length);
            //}
            //fdEct.Close();
        }

        private void buttonMsgSend_Click(object sender, EventArgs e)
        {
            UInt32 mode = 0;

            foreach (Control cb in this.groupBoxCompany.Controls)
            {
                if (cb is CheckBox)
                {
                    if (((CheckBox)cb).Checked) 
                        mode |= ((UInt32)1 << cb.TabIndex);
                }
            }

            if (mode > 0)
            {
                StringBuilder cmdData = new StringBuilder();
                cmdData.AppendFormat("$XLNAV," + "{0}" + "\r\n", mode);

                msgHome.serialSend(cmdData.ToString());

                if (File.Exists("./msgfile.txt"))
                    File.Delete("./msgfile.txt");

                if (File.Exists("./ht1902msgfile.txt"))
                    File.Delete("./ht1902msgfile.txt");

                //if (File.Exists("./ECT.txt"))
                //    File.Delete("./ECT.txt");
            }
        }

        private void FormGetMsg_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
