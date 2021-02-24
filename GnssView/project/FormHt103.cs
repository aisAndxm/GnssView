using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GnssView.project
{
    public partial class FormHt103 : Form
    {
        public FormHt103(FormHome home)
        {
            InitializeComponent();
            homeTmp = home;
        }

        FormHome homeTmp;

        public void ht103CmdDec(byte[] data, int len)
        {
            uint check, checkTmp;

            if (len < 64) return;
            if (data[2] != 62) return;
            check = crcCheck(data, 0, 60);
            checkTmp = BitConverter.ToUInt32(data, 60);
            if (check != checkTmp) return;

            try
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    label2.Text = BitConverter.ToString(data, 0, 2);/*十六进制*/
                    label6.Text = data[2].ToString();/*十进制*/
                    label10.Text = data[3].ToString();
                    label14.Text = BitConverter.ToUInt16(data, 4).ToString();
                    label18.Text = data[6].ToString();
                    label22.Text = (BitConverter.ToSingle(data, 7) * 0.001).ToString();
                    label26.Text = BitConverter.ToUInt16(data, 11).ToString();
                    label4.Text = data[13].ToString();
                    label8.Text = data[14].ToString();
                    label12.Text = data[15].ToString();
                    label16.Text = (BitConverter.ToUInt32(data, 16) / 1000.0).ToString("f3");/*秒*/
                    label20.Text = data[20].ToString();
                    label24.Text = data[21].ToString();
                    label28.Text = BitConverter.ToUInt16(data, 22).ToString();
                    label30.Text = ((data[24]>>4) & 0x3).ToString() + "/" + ((data[24]>>2) & 0x3).ToString() + "/" + (data[24]&0x3).ToString();
                    label32.Text = data[25].ToString();
                    label34.Text = data[26].ToString();
                    label36.Text = data[27].ToString();
                    label38.Text = (BitConverter.ToInt32(data, 28) * 1.0e-7).ToString("f8");
                    label40.Text = (BitConverter.ToInt32(data, 32) * 1.0e-7).ToString("f8");
                    label42.Text = (BitConverter.ToInt32(data, 36) * 1.0e-2).ToString("f8");
                    label44.Text = (BitConverter.ToInt32(data, 40) * 1.0e-2).ToString("f8");
                    label46.Text = (BitConverter.ToInt32(data, 44) * 1.0e-2).ToString("f8");
                    label48.Text = (BitConverter.ToInt32(data, 48) * 1.0e-2).ToString("f8");
                    label50.Text = (BitConverter.ToUInt16(data, 52) * 0.01).ToString("f8");
                    label52.Text = (BitConverter.ToUInt16(data, 54) * 0.01).ToString("f8");
                    label54.Text = (BitConverter.ToUInt16(data, 56) * 0.01).ToString("f8");
                    label56.Text = (BitConverter.ToUInt16(data, 58) * 0.1).ToString("f8");
                }));
            }
            catch { }
        }

        UInt32 CRC32Value(UInt32 value)
        {
            UInt32 u1CRC;
            UInt32 CRC32_POLYMNOMIAL = 0xEDB88320;

            u1CRC = value;
            for (int j = 0; j < 8; j ++)
            {
                if ((u1CRC & 1) == 1)
                    u1CRC = (u1CRC >> 1) ^ CRC32_POLYMNOMIAL;
                else
                    u1CRC >>= 1;
            }

            return u1CRC;
        }


        /// <summary>
        /// CRC校验
        /// </summary>
        /// <param name="data"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private uint crcCheck(byte[] data, int start, int length)
        {
            UInt32 u1Temp1;
            UInt32 u1Temp2;
            UInt32 u1CRC = 0;
            for (int i = start; i < start + length; i++)
            {
                u1Temp1 = (u1CRC >> 8) & 0x00FFFFFF;
                u1Temp2 = CRC32Value((UInt32)((u1CRC ^ data[i]) & 0xff));
                u1CRC = u1Temp1 ^ u1Temp2;
            }

            return (u1CRC);
        }

        private void FormHt103_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
