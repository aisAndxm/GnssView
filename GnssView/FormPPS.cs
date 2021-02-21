using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GnssView
{
    public partial class FormPPS : Form
    {
        public FormPPS(FormHome home)
        {
            InitializeComponent();
            homeTmp = home;
        }

        private FormHome homeTmp;

        double recvTimeLast = -100.0;

        public void ppsMsgPro(byte[] data, int len)
        {
            List<string> listData = new List<string>();
            getDataFromStr(listData, data, len);
            double clkErr = 0.0, decimals = 0.0;
            if (UInt32.Parse(listData[2]) < 6) return;
            /*画钟差*/
            double recvTime = double.Parse(listData[1]);
            decimals = recvTime - Math.Truncate(recvTime);
            if ((decimals < 0.001 || decimals > 0.009) && (recvTimeLast > 0))
            {
                clkErr = (recvTime - recvTimeLast - 1) * 1e9;
                if (clkErr < 10000)
                {
                    try
                    {
                        this.Invoke((MethodInvoker)delegate { chartRecv.Series[0].Points.AddY(clkErr); });
                    }
                    catch { }
                }
            }
            recvTimeLast = recvTime;
            /*画pps*/
            double dTemp = double.Parse(listData[7]);
            try
            {
                this.Invoke((MethodInvoker)delegate { chartAdjust.Series[0].Points.AddY(dTemp); });
            }
            catch { }
        }

        private void FormPPS_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        //截取字符串
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

    }
}
