using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GnssView
{
    public partial class FormRd : Form
    {
        public FormRd(FormHome home)
        {
            InitializeComponent();
            homeTmp = home;

            groupControlLocal.Dock = DockStyle.Fill;
            groupControlLocal.Visible = true;
            this.splitContainerControl2.Panel2.Controls.Add(groupControlLocal);
        }

        private FormHome homeTmp;

        private int xorCheck(byte[] data, int start, int length)
        {
            int check = 0;

            if (length < 1) return -1;

            for (int i = start; i < length; i++)
                check ^= data[i];

            return check;
        }

        /// <summary>
        /// 处理接收的BSI语句进行显示
        /// </summary>
        public void bsiCmdShow(List<string> list_data)
        {
            int resBeam = 0;
            int timeBeam = 0;
            int beamCn0 = 0;

            resBeam = int.Parse(list_data[1]);
            if (resBeam < 1 && resBeam > 10) return;
            timeBeam = int.Parse(list_data[2]);
            if (timeBeam < 1 && timeBeam > 10) return;
            for (int i = 3; i < list_data.Count; i++)
            {
                beamCn0 = int.Parse(list_data[i]);
                if (beamCn0 < 0 && beamCn0 > 60) return;
            }

            this.Invoke(new MethodInvoker(delegate
            {
                labelRes.Text = list_data[1];
                labelTime.Text = list_data[2];
                labelBeam1.Text = list_data[3];
                labelBeam2.Text = list_data[4];
                labelBeam3.Text = list_data[5];
                labelBeam4.Text = list_data[6];
                labelBeam5.Text = list_data[7];
                labelBeam6.Text = list_data[8];
                labelBeam7.Text = list_data[9];
                labelBeam8.Text = list_data[10];
                labelBeam9.Text = list_data[11];
                labelBeam10.Text = list_data[12];
            }));
        }

        /// <summary>
        /// 设置响应波束和时差波束
        /// </summary>
        private void btnSetBeam_Click(object sender, EventArgs e)
        {
            int resBeam = 0, timeBeam = 0;
            int check = 0;
            
            resBeam = comboBoxRes.SelectedIndex;
            timeBeam = comboBoxTime.SelectedIndex;

            if (resBeam < 1 || resBeam > 10) return;
            if (timeBeam < 1 || timeBeam > 10) return;

            StringBuilder strCmd = new StringBuilder();
            strCmd.AppendFormat("$CCBSS,");

            strCmd.AppendFormat(resBeam.ToString() + ',' + "{0:d}", timeBeam);

            check = xorCheck(System.Text.Encoding.ASCII.GetBytes(strCmd.ToString()), 1, strCmd.Length - 1);

            strCmd.AppendFormat("*{0:x2}\r\n", check);

            homeTmp.serialSend(strCmd.ToString());
        }

        /// <summary>
        /// 定位申请
        /// </summary>
        private void btnPosCmd_Click(object sender, EventArgs e)
        {
            ulong usrAddr = 0;
            double alt, ante, press, temp, rate;
            int check = 0;

            StringBuilder strCmd = new StringBuilder();
            strCmd.AppendFormat("$CCDWA,");

            try
            {
                usrAddr = ulong.Parse(richTextBoxAddr.Text);
                alt = double.Parse(richTextBoxAltData.Text);
                ante = double.Parse(richTextBoxAnteData.Text);
                press = double.Parse(richTextBoxPressData.Text);
                temp = double.Parse(richTextBoxTempData.Text);
                rate = double.Parse(richTextBoxRate.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "数据填写错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            strCmd.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                usrAddr, comboBoxPosType.Text[0], comboBoxAltType.Text[0], comboBoxAltInstr.Text[0],
                alt, ante, press, temp, rate);

            check = xorCheck(System.Text.Encoding.ASCII.GetBytes(strCmd.ToString()), 1, strCmd.Length - 1);
            strCmd.AppendFormat("*{0:x2}\r\n", check);
            homeTmp.serialSend(strCmd.ToString());

        }

        /// <summary>
        /// 查询当前波束状态
        /// </summary>
        private void btnPower_Click(object sender, EventArgs e)
        {
            homeTmp.serialSend("$CCRMO,BSI,2,0*A5\r\n");
            homeTmp.decDataFlag["BSI"] = 1;
        }

        /// <summary>
        /// 通讯申请
        /// </summary>
        private void buttonCommCmd_Click(object sender, EventArgs e)
        {
            ulong usrAddr = 0;
            int check;

            StringBuilder strCmd = new StringBuilder();
            strCmd.AppendFormat("$CCTXA,");

            try
            {
                usrAddr = ulong.Parse(richTextBoxCommAddr.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "数据填写错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxCommMode.Text[0] == '0')
            {
                for (int i = 0; i < richTextBoxComm.Text.Length; i++)
                {
                    if ((int)richTextBoxComm.Text[i] < 127)
                    {
                        MessageBox.Show("请输入汉字", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else if(comboBoxCommMode.Text[0] == '1')
            {
                for (int i = 0; i < richTextBoxComm.Text.Length; i++)
                {
                    if ((int)richTextBoxComm.Text[i] > 127)
                    {
                        MessageBox.Show("请输入代码", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            strCmd.AppendFormat("{0},{1},{2}, {3}", usrAddr, comboBoxCommType.Text[0], comboBoxCommMode.Text[0], richTextBoxComm.Text);
            check = xorCheck(System.Text.Encoding.ASCII.GetBytes(strCmd.ToString()), 1, strCmd.Length - 1);
            strCmd.AppendFormat("*{0:x2}\r\n", check);
            homeTmp.serialSend(strCmd.ToString());
        }

        /// <summary>
        /// 用户查询
        /// </summary>
        private void buttonSearAddr_Click(object sender, EventArgs e)
        {
            ulong usrAddr = 0;
            int check;

            StringBuilder strCmd = new StringBuilder();
            strCmd.AppendFormat("$CCCXA,");

            try
            {
                usrAddr = ulong.Parse(richTextBoxSearAddr.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "数据填写错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            strCmd.AppendFormat("{0},{1},{2}", usrAddr, comboBoxSearType.Text[0], comboBoxSearMode.Text[0]);
            check = xorCheck(System.Text.Encoding.ASCII.GetBytes(strCmd.ToString()), 1, strCmd.Length - 1);
            strCmd.AppendFormat("*{0:x2}\r\n", check);
            homeTmp.serialSend(strCmd.ToString());
        }

        private void treeListRdss_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            this.splitContainerControl2.Panel2.Controls.Clear();/*清空控件上的控件，添加新的组*/

            switch (e.Node.Id)
            {
                case 0:
                    groupControlLocal.Dock = DockStyle.Fill;
                    groupControlLocal.Visible = true;
                    this.splitContainerControl2.Panel2.Controls.Add(groupControlLocal);
                    break;
                case 1:
                    comboBoxPosType.SelectedIndex = 0;
                    comboBoxAltType.SelectedIndex = 0;
                    comboBoxAltInstr.SelectedIndex = 0;
                    groupControlPosSet.Dock = DockStyle.Fill;
                    groupControlPosSet.Visible = true;
                    this.splitContainerControl2.Panel2.Controls.Add(groupControlPosSet);
                    break;
                case 2:
                    comboBoxCommType.SelectedIndex = 0;
                    comboBoxCommMode.SelectedIndex = 0;
                    groupControlComm.Dock = DockStyle.Fill;
                    groupControlComm.Visible = true;
                    this.splitContainerControl2.Panel2.Controls.Add(groupControlComm);
                    break;
                case 3:
                    groupControlRdssBeamSet.Dock = DockStyle.Fill;
                    groupControlRdssBeamSet.Visible = true;
                    this.splitContainerControl2.Panel2.Controls.Add(groupControlRdssBeamSet);
                    break;
                case 4:
                    comboBoxSearType.SelectedIndex = 0;
                    comboBoxSearMode.SelectedIndex = 0;
                    groupControlUsrSear.Dock = DockStyle.Fill;
                    groupControlUsrSear.Visible = true;
                    this.splitContainerControl2.Panel2.Controls.Add(groupControlUsrSear);
                    break;


                default:
                    break;
            }
        }

        private void FormRd_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void treeListRdss3_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            this.splitContainerControl3.Panel2.Controls.Clear();/*清空控件上的控件，添加新的组*/

            switch (e.Node.Id)
            {
                case 0:

                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:
                    comboBoxSearTypeRdss3.SelectedIndex = 0;
                    groupControlUsrSearRdss3.Dock = DockStyle.Fill;
                    groupControlUsrSearRdss3.Visible = true;
                    this.splitContainerControl3.Panel2.Controls.Add(groupControlUsrSearRdss3);
                    break;
                default:
                    break;
            }
        }
    }
}
