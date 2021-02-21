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
    public partial class FormMsgCheck : Form
    {
        public FormMsgCheck()
        {
            InitializeComponent();
        }


        private int xorCheck(byte[] data, int start, int length)
        {
            int check = 0;

            if (length < 1) return -1;

            for (int i = start; i < length; i++)
                check ^= data[i];

            return check;
        }

        private int ascii2Int(byte[] data, int start, int len)
        {
            int value = 0;

            if (len >= 16) return -1;

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

        public UInt32 msgCheckPro(byte[] data, int len)
        {
            UInt32 failFlag = 0;
            if (checkBoxB2BI.Checked)
            {
                len -= 2;
                if (len < 40) return failFlag;

                int check = xorCheck(data, 1, len - 3);
                int checkTmp = ascii2Int(data, len - 2, 2);
                if ((check & 0xff) != checkTmp) return failFlag;

                List<string> listData = new List<string>();
                getDataFromStr(listData, data, len);

                uint svid = 0, msgType = 0, branch, intTemp, secWeek;
                if (!uint.TryParse(listData[1], out svid)) failFlag = 1;
                if (!uint.TryParse(listData[3], out branch)) failFlag = 1;

                intTemp = Convert.ToUInt32(listData[5].Substring(0, 8), 16);
                //if (!uint.TryParse(listData[5].Substring(0, 8), out intTemp)) failFlag = 1;

                if ((intTemp >> 24) != svid) failFlag = 1;
                msgType = (intTemp >> 12)&0x3f;

                //if (!uint.TryParse(listData[5].Substring(2, 8), out secWeek)) failFlag = 1;
                intTemp = Convert.ToUInt32(listData[5].Substring(2, 8), 16);
                secWeek = intTemp&0xfffff;

                string strOut = string.Format("{0}, {1}, {2}, {3}\r\n", listData[2], svid, msgType, secWeek);
                this.Invoke((MethodInvoker)delegate {
                    textBoxCrcResult.Text += strOut;
                });

                return failFlag;
            }

            if (checkBoxS1I.Checked)
            {


            }

            if (checkBoxS1Q.Checked)
            {


            }

            return failFlag;
        }

        private void textBoxCrcResult_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCrcResult.Lines.Length > 10000)
                textBoxCrcResult.Clear();
            else
            {
                //将光标位置设置到当前内容的末尾
                textBoxCrcResult.SelectionStart = textBoxCrcResult.Text.Length;
                //滚动到光标位置
                textBoxCrcResult.ScrollToCaret();
            }
        }

    }
}
