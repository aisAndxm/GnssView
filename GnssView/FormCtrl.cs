using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace GnssView
{
    public partial class FormCtrl : Form
    {
        public FormCtrl(FormHome home)
        {
            InitializeComponent();

            homeTmp = home;
            /* 初始化窗口 */
        }

        private FormHome homeTmp;

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (richTextBoxSend.Text == null) return;

            if (checkBoxHex.Checked)
            {
                string strCmdSend = richTextBoxSend.Text;

                if (strCmdSend.Length < 3)
                    return;

                byte[] hexBuf = new byte[strCmdSend.Length / 3 + 2];

                for (int i = 0; i < strCmdSend.Length - 1; i++)
                {
                    if (i % 3 == 0) hexBuf[i / 3] = byte.Parse(strCmdSend.Substring(i, 2));
                }
                homeTmp.serialSend(hexBuf, 0, hexBuf.Length);
            }
            else
            {
                homeTmp.serialSend(richTextBoxSend.Text.ToString());
            }
            if (checkBoxCRLF.Checked)
                homeTmp.serialSend("\r\n");
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "打开文件",
                Filter = "所有文件(*.*)|*.*",
                AutoUpgradeEnabled = false
            };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                richTextBoxOpenPath.Text = dialog.FileName;
            dialog.Dispose();
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            if (richTextBoxOpenPath.Text != null && homeTmp.fileStreamSend == null)
                homeTmp.fileStreamSend = new FileStream(richTextBoxOpenPath.Text, FileMode.Open, FileAccess.Read);
            else if (homeTmp.fileStreamSend == null)
            {
                MessageBox.Show("文件状态", "文件未打开", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            homeTmp.fileStreamSend.Seek(0, SeekOrigin.Begin);//重复发送时回复到文件开始

            if (homeTmp.fileStreamSend.Length > 2147483648) MessageBox.Show("文件状态", "发送文件过大", MessageBoxButtons.OK, MessageBoxIcon.Error);

            byte[] sendByte = new byte[homeTmp.fileStreamSend.Length];

            homeTmp.fileStreamSend.Read(sendByte, 0, sendByte.Length);

            homeTmp.serialSend(sendByte, 0, sendByte.Length);

            homeTmp.fileStreamSend.Dispose();

            //显示发送数据
            //if (homeTmp.formOut.toolStripMenuItemHex.Checked)
            //{
            //    StringBuilder strbTmp = new StringBuilder();
            //    for (int i = 0; i < sendByte.Length; i++)
            //    {
            //        strbTmp.AppendFormat("{0:X2}" + " ", sendByte[i]);
            //    }
            //    try
            //    {
            //        this.Invoke(new MethodInvoker(delegate
            //        {
            //            homeTmp.formOut.textBoxOut.AppendText(strbTmp.ToString().ToUpper());
            //        }));
            //    }
            //    catch { }
            //}
            //else
            //{
            //    try
            //    {
            //        this.Invoke(new MethodInvoker(delegate
            //        {
            //            homeTmp.formOut.textBoxOut.AppendText(Encoding.ASCII.GetString(sendByte));
            //        }));
            //    }
            //    catch { }
            //}
        }

        private void richTextBoxSend_TextChanged(object sender, EventArgs e)
        {
            //将光标位置设置到当前内容的末尾
            richTextBoxSend.SelectionStart = richTextBoxSend.Text.Length;
            //滚动到光标位置
            richTextBoxSend.ScrollToCaret();
        }

        private void FormCtrl_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
