using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GnssView
{
    public partial class FormOut : Form
    {
        public FormOut(FormHome home)
        {
            InitializeComponent();

            homeTmp = home;

            toolStripStatusLabelRxLen.Text = "0";

            /* 初始化线程 */
            pThUartOut = new Thread(thShowUart)
            {
                IsBackground = true,
                Name = "uart_out_thread",
                Priority = ThreadPriority.Normal
            };
            pThUartOut.Start();
        }

        private FormHome homeTmp;
        readonly Thread pThUartOut;


        //private void limitLine(TextBox box, int maxLength)
        //{
        //    if (box.Lines.Length > maxLength)
        //    {
        //        int moreLines = box.Lines.Length - maxLength;
        //        string[] lines = box.Lines;
        //        Array.Copy(lines, moreLines, lines, 0, maxLength);
        //        Array.Resize(ref lines, maxLength);
                
        //        box.Lines = lines;
        //    }
        //}

        private void textBoxOut_TextChanged(object sender, EventArgs e)
        {
            if (textBoxOut.Lines.Length > 100000)
            {
                textBoxOut.Clear();
                //limitLine(textBoxOut, 100);
            }
            ///*将光标位置设置到当前内容的末尾，滚动条抖动*/
            //textBoxOut.SelectionStart = textBoxOut.Text.Length;
            ///*滚动到光标位置*/
            //textBoxOut.ScrollToCaret();

            //this.textBoxOut.Focus();/*获取焦点*/
            //this.textBoxOut.Select(this.textBoxOut.TextLength, 0);/*光标定位到文本最后*/
            this.textBoxOut.ScrollToCaret();/*滚动到光标处*/
        }

        /// <summary>
        /// 显示串口数据线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void thShowUart()
        {
            while (true)
            {
                homeTmp._autoResetOut.WaitOne();
                int rxLen = 0;
                int wr = homeTmp.uartRxBuf.wr;
                int rdOut = homeTmp.uartRxBuf.rdOut;
                if (wr == rdOut) continue;

                if (rdOut < wr)
                {
                    rxLen = wr - rdOut;
                    standardShowFormat(homeTmp.uartRxBuf.buf, rdOut, rxLen);
                }
                else if (rdOut > wr)
                {
                    rxLen = uartVar.MSG_MAX_LEN - rdOut;
                    standardShowFormat(homeTmp.uartRxBuf.buf, rdOut, uartVar.MSG_MAX_LEN - rdOut);
                    standardShowFormat(homeTmp.uartRxBuf.buf, 0, wr);
                    rxLen += wr;
                }
                homeTmp.uartRxBuf.rdOut = wr;

                //显示接收字长
                int lenTmp = 0;
                try
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        lenTmp = int.Parse(toolStripStatusLabelRxLen.Text.ToString());
                        if (lenTmp < 0 || lenTmp > 2147483647) lenTmp = 0;
                        toolStripStatusLabelRxLen.Text = (lenTmp + rxLen).ToString();
                    }));
                }
                catch { }
            }
        }

        /// <summary>
        /// 格式化输出
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        private void standardShowFormat(byte[] array, int offset, int count)
        {
            if (toolStripMenuItemHex.Checked)
                uartRxPrint(BitConverter.ToString(array, offset, count).Replace("-", " ") + ' ');/*输出结束后加空格，保证下次输出时格式一致*/
            else
                uartRxPrint(Encoding.ASCII.GetString(array, offset, count));
        }
        /// <summary>
        /// 委托输出结果到文本框
        /// </summary>
        /// <param name="data"></param>
        private void uartRxPrint(string data)
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate { textBoxOut.AppendText(data); }));
            }
            catch
            { }
        }

        public void clearOut()
        {
            textBoxOut.Clear();
            toolStripStatusLabelRxLen.Text = "0";
        }

        //private void toolStripMenuItemCut_Click(object sender, EventArgs e)
        //{
        //    textBoxOut.Cut();
        //}

        //private void toolStripMenuItemPaste_Click(object sender, EventArgs e)
        //{
        //    textBoxOut.Paste();
        //}

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            textBoxOut.Copy();
        }

        private void toolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            textBoxOut.Clear();
            toolStripStatusLabelRxLen.Text = "0";
        }

        private void FormOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pThUartOut != null) pThUartOut.Abort();

            this.Dispose();
        }

        private void toolStripMenuItemHex_Click(object sender, EventArgs e)
        {
            toolStripMenuItemHex.Checked = !toolStripMenuItemHex.Checked;
        }

        private void textBoxCmd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                string strTmp = textBoxCmd.Text + "\r\n";
                homeTmp.serialSend(strTmp);
            }
        }
    }
}
