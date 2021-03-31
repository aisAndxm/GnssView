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
        }

        private FormHome homeTmp;
        /*V21命令*/
        private Dictionary<string, string> d_v21CmdGroup = new Dictionary<string, string> {
            {"head", ""}, {"type", ""}, {"branch", ""}, {"rmoItem", ""}, {"rmoEn", ""}, {"rmoFreq", ""}, {"mssMode", ""},
            {"mssItem", ""}, {"mssFreq1", ""}, {"mssFreq2", ""}, {"mssFreq3", ""}, {"mssBranch1", ""}, {"mssBranch2", ""}, {"mssBranch3", ""},
        };

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (richTextBoxSend.Text == null) return;

            if (checkBoxHex.Checked)
            {
                string strCmdSend = richTextBoxSend.Text;

                if (strCmdSend.Length < 3)
                    return;

                int hexNum = (strCmdSend.Length + 2) / 3;/*"A2 A2"长度为5*/
                byte[] hexBuf = new byte[hexNum + 2];/*预留回车换行*/

                for (int i = 0; i < strCmdSend.Length - 1; i++)
                {
                    if ((i % 3) != 0) continue;
                    if (byte.TryParse(strCmdSend.Substring(i, 2), out byte hex)) hexBuf[i / 3] = hex;
                }

                if (checkBoxCRLF.Checked)
                {
                    hexBuf[hexNum] = 0x0d;
                    hexBuf[hexNum + 1] = 0x0a;
                    homeTmp.serialSend(hexBuf, 0, hexNum + 2);
                }
                else
                    homeTmp.serialSend(hexBuf, 0, hexNum);

            }
            else
            {
                if (checkBoxCRLF.Checked)
                    homeTmp.serialSend(richTextBoxSend.Text.ToString() + "\r\n");
                else
                    homeTmp.serialSend(richTextBoxSend.Text.ToString());
            }
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

        private void treeListView_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            this.splitContainerControl2.Panel2.Controls.Clear();/*清空控件上的控件，添加新的组*/

            switch (e.Node.Id)
            {
                case 0:
                    groupControlMsg.Dock = DockStyle.Fill;
                    groupControlMsg.Visible = true;
                    this.splitContainerControl2.Panel2.Controls.Add(groupControlMsg);
                    break;
                case 1:
                    groupControlUart.Dock = DockStyle.Fill;
                    groupControlUart.Visible = true;
                    this.splitContainerControl2.Panel2.Controls.Add(groupControlUart);
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;


                default:
                    break;
            }
        }

        //命令选择入口
        private void comboBoxCmdAccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBoxTmp = (ComboBox)sender;

            if (comboBoxTmp.Name.CompareTo(comboBoxCmd.Name) == 0)
            {
                //关闭所有ComBo控件
                foreach (Control n in groupControlMsg.Controls)
                {
                    if (n.Name == "comboBoxCmd") continue;
                    if (n.GetType().Name == "ComboBox")
                        n.Enabled = false;
                }

                switch ((e_v21Cmd)comboBoxCmd.SelectedIndex)
                {
                    case e_v21Cmd.RIS:
                        d_v21CmdGroup["head"] = "$CCRIS";
                        break;
                    case e_v21Cmd.MSS:
                        comboBoxRmoEn.SelectedIndex = 0;
                        comboBoxMssMode.SelectedIndex = 0;
                        comboBoxMssItem.SelectedIndex = 2;
                        comboBoxMssFreq1.SelectedIndex = 2;
                        comboBoxMssMode.Enabled = true;
                        comboBoxMssItem.Enabled = true;
                        comboBoxMssFreq1.Enabled = true;
                        comboBoxMssFreq2.Enabled = true;
                        comboBoxMssFreq3.Enabled = true;
                        comboBoxMssBranch1.Enabled = true;

                        d_v21CmdGroup["head"] = "$CCMSS";
                        break;
                    case e_v21Cmd.RMO:
                        comboBoxRmoItem.SelectedIndex = 0;
                        comboBoxRmoEn.SelectedIndex = 1;
                        comboBoxMeasFreq.SelectedIndex = 0;

                        comboBoxRmoItem.Enabled = true;
                        comboBoxRmoEn.Enabled = true;
                        comboBoxMeasFreq.Enabled = true;
                        d_v21CmdGroup["head"] = "$CCRMO";
                        break;
                    case e_v21Cmd.PRD:
                        break;
                    case e_v21Cmd.ECS:
                        break;
                    case e_v21Cmd.CPM:
                        break;
                    case e_v21Cmd.SPM:
                        break;
                    case e_v21Cmd.STM:
                        break;
                    default:
                        break;

                }
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxType.Name) == 0)
            {
                d_v21CmdGroup["type"] = comboBoxType.SelectedItem.ToString();
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxBranch.Name) == 0)
            {
                d_v21CmdGroup["branch"] = comboBoxBranch.SelectedItem.ToString();
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxRmoItem.Name) == 0)
            {
                d_v21CmdGroup["rmoItem"] = comboBoxRmoItem.SelectedItem.ToString().Substring(0, 3);
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxRmoEn.Name) == 0)
            {
                d_v21CmdGroup["rmoEn"] = (comboBoxRmoEn.SelectedIndex + 1).ToString();
                if (d_v21CmdGroup["rmoEn"] == "3" || d_v21CmdGroup["rmoEn"] == "4")
                    comboBoxRmoItem.Enabled = false;
                else
                    comboBoxRmoItem.Enabled = true;
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMeasFreq.Name) == 0)
            {
                d_v21CmdGroup["rmoFreq"] = comboBoxMeasFreq.SelectedItem.ToString();
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMssMode.Name) == 0)
            {
                if (comboBoxMssMode.SelectedIndex == 1)
                    d_v21CmdGroup["mssMode"] = "Z";
                else
                    d_v21CmdGroup["mssMode"] = "C";
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMssItem.Name) == 0)
            {
                d_v21CmdGroup["mssItem"] = comboBoxMssItem.SelectedIndex.ToString();
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMssFreq1.Name) == 0)
            {
                d_v21CmdGroup["mssFreq1"] = comboBoxMssFreq1.SelectedItem.ToString();
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMssFreq2.Name) == 0)
            {
                d_v21CmdGroup["mssFreq2"] = comboBoxMssFreq2.SelectedItem.ToString();
                comboBoxMssBranch2.Enabled = true;
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMssFreq3.Name) == 0)
            {
                d_v21CmdGroup["mssFreq3"] = comboBoxMssFreq3.SelectedItem.ToString();
                comboBoxMssBranch3.Enabled = true;
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMssBranch1.Name) == 0)
            {
                d_v21CmdGroup["mssBranch1"] = comboBoxMssBranch1.SelectedItem.ToString();
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMssBranch2.Name) == 0)
            {
                d_v21CmdGroup["mssBranch2"] = comboBoxMssBranch2.SelectedItem.ToString();
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMssBranch3.Name) == 0)
            {
                d_v21CmdGroup["mssBranch3"] = comboBoxMssBranch3.SelectedItem.ToString();
            }
            else
                return;

            StringBuilder strCmdBuf = new StringBuilder();
            switch ((e_v21Cmd)comboBoxCmd.SelectedIndex)
            {
                case e_v21Cmd.RIS:
                    strCmdBuf.AppendFormat("{0},", d_v21CmdGroup["head"]);
                    break;
                case e_v21Cmd.MSS:
                    strCmdBuf.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8}", d_v21CmdGroup["head"], d_v21CmdGroup["mssMode"], d_v21CmdGroup["mssItem"],
                        d_v21CmdGroup["mssFreq1"], d_v21CmdGroup["mssBranch1"], d_v21CmdGroup["mssFreq2"], d_v21CmdGroup["mssBranch2"], d_v21CmdGroup["mssFreq3"], d_v21CmdGroup["mssBranch3"]);
                    break;
                case e_v21Cmd.RMO:
                    if (d_v21CmdGroup["rmoEn"] == "3" || d_v21CmdGroup["rmoEn"] == "4")
                        strCmdBuf.AppendFormat("{0},,{1},,", d_v21CmdGroup["head"], d_v21CmdGroup["rmoEn"]);
                    else
                        strCmdBuf.AppendFormat("{0},{1},{2},{3}", d_v21CmdGroup["head"], d_v21CmdGroup["rmoItem"], d_v21CmdGroup["rmoEn"], d_v21CmdGroup["rmoFreq"]);
                    break;
                case e_v21Cmd.PRD:
                    break;
                case e_v21Cmd.ECS:
                    break;
                case e_v21Cmd.CPM:
                    break;
                case e_v21Cmd.SPM:
                    break;
                case e_v21Cmd.STM:
                    break;
                default:
                    break;

            }

            int checkSum = 0;
            byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(strCmdBuf.ToString());
            for (int i = 1; i < byteArray.Length; i++)//添加校验
                checkSum ^= byteArray[i];
            strCmdBuf.AppendFormat("*{0:X2}", (byte)(checkSum & 0xff));

            richTextBoxSend.Text = strCmdBuf.ToString();
        }

        private void FormCtrl_Load(object sender, EventArgs e)
        {
            this.splitContainerControl2.Panel2.Controls.Clear();/*清空控件上的控件，添加新的组*/
            groupControlMsg.Dock = DockStyle.Fill;
            groupControlMsg.Visible = true;
            this.splitContainerControl2.Panel2.Controls.Add(groupControlMsg);

            this.comboBoxCmd.SelectedIndexChanged += new System.EventHandler(this.comboBoxCmdAccess_SelectedIndexChanged);
            this.comboBoxMssMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxCmdAccess_SelectedIndexChanged);
            this.comboBoxMssItem.SelectedIndexChanged += new System.EventHandler(this.comboBoxCmdAccess_SelectedIndexChanged);
            this.comboBoxRmoItem.SelectedIndexChanged += new System.EventHandler(this.comboBoxCmdAccess_SelectedIndexChanged);
            this.comboBoxRmoEn.SelectedIndexChanged += new System.EventHandler(this.comboBoxCmdAccess_SelectedIndexChanged);
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxCmdAccess_SelectedIndexChanged);
            this.comboBoxBranch.SelectedIndexChanged += new System.EventHandler(this.comboBoxCmdAccess_SelectedIndexChanged);
            this.comboBoxMssFreq1.SelectedIndexChanged += new System.EventHandler(this.comboBoxCmdAccess_SelectedIndexChanged);
            this.comboBoxMssFreq2.SelectedIndexChanged += new System.EventHandler(this.comboBoxCmdAccess_SelectedIndexChanged);
            this.comboBoxMssFreq3.SelectedIndexChanged += new System.EventHandler(this.comboBoxCmdAccess_SelectedIndexChanged);
            this.comboBoxMssBranch1.SelectedIndexChanged += new System.EventHandler(this.comboBoxCmdAccess_SelectedIndexChanged);
            this.comboBoxMssBranch2.SelectedIndexChanged += new System.EventHandler(this.comboBoxCmdAccess_SelectedIndexChanged);
            this.comboBoxMssBranch3.SelectedIndexChanged += new System.EventHandler(this.comboBoxCmdAccess_SelectedIndexChanged);
            this.comboBoxMeasFreq.SelectedIndexChanged += new System.EventHandler(this.comboBoxCmdAccess_SelectedIndexChanged);
        }
    }
}
