using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using DevExpress.XtraEditors;
using System.Windows.Forms.DataVisualization.Charting;



namespace GnssView
{
    public partial class FormView : Form
    {
        public FormView(FormHome home)
        {
            InitializeComponent();
            homeTmp = home;
        }

        private FormHome homeTmp;
        private int typeMask = 0xf;

        private void DataGridInit()
        {
            string[] str = { "UTC", "纬度", "南北", "经度", "东西", "标志", "星数", "HDOP", "高度" };
            dataGridViewGga.Rows.Clear();
            for (int index = 0; index < 9; index++)
            {
                int rowId = dataGridViewGga.Rows.Add();
                dataGridViewGga.Rows[rowId].Cells[0].Value = str[index];
            }
            dataGridViewGga.ClearSelection();/*只能在load里起作用*/
        }

        private void MsgPerSec()
        {
            dataGridViewGga.Rows[0].Cells[1].Value = homeTmp.navGgaMsg.utcTime.ToString("f3").PadLeft(10, '0');
            dataGridViewGga.Rows[1].Cells[1].Value = homeTmp.navGgaMsg.lat.ToString("f4");
            dataGridViewGga.Rows[2].Cells[1].Value = homeTmp.navGgaMsg.latMark;
            dataGridViewGga.Rows[3].Cells[1].Value = homeTmp.navGgaMsg.lon.ToString("f4");
            dataGridViewGga.Rows[4].Cells[1].Value = homeTmp.navGgaMsg.lonMark;
            dataGridViewGga.Rows[5].Cells[1].Value = homeTmp.navGgaMsg.flag;
            dataGridViewGga.Rows[6].Cells[1].Value = homeTmp.navGgaMsg.svNum.ToString();
            dataGridViewGga.Rows[7].Cells[1].Value = homeTmp.navGgaMsg.hdop.ToString("f1");
            dataGridViewGga.Rows[8].Cells[1].Value = homeTmp.navGgaMsg.alt.ToString("f4");
            dataGridViewGga.Refresh();
        }

        public void RefreshView()
        {
            MsgPerSec();
            splitContainerControlView.Refresh();
        }

        private void displayView()
        {
            if (homeTmp.navGsvMsg.Count <= 0) return;

            for (int i = 0; i < 5; i++)
                chartView.Series[i].Points.Clear();

            for (int i = 0; i < homeTmp.navGsvMsg.Count; i++)
            {
                int svidId = homeTmp.navGsvMsg[i].svid;
                int type = homeTmp.navGsvMsg[i].type;
                int az = homeTmp.navGsvMsg[i].az;
                int el = homeTmp.navGsvMsg[i].el;
                if ((typeMask & (1 << type)) != (1 << type)) continue;

                bool isInCh = false;
                foreach (gsaMsg g in homeTmp.navGsaMsg)
                {
                    if (g.svidId.Contains(svidId))
                    {
                        chartView.Series[type].Points.AddXY(az, el);
                        chartView.Series[type].Points[chartView.Series[type].Points.Count - 1].Label = svidId.ToString();
                        isInCh = true;
                        break;
                    }
                }
                if (!isInCh)
                {
                    chartView.Series[4].Points.AddXY(az, el);
                    chartView.Series[4].Points[chartView.Series[4].Points.Count - 1].Label = svidId.ToString();
                    chartView.Series[4].Points[chartView.Series[4].Points.Count - 1].LabelForeColor = chartView.Series[type].MarkerColor;
                }
            }
        }

        public void clearView()
        {
            for (int i = 0; i < 5; i++) chartView.Series[i].Points.Clear();
        }

        private void splitContainerControlView_Paint(object sender, PaintEventArgs e)
        {
            displayView();
        }

        private void contextMenuStripView_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "GPS") typeMask ^= (1 << 0);
            else if (e.ClickedItem.Text == "BDS") typeMask ^= (1 << 1);
            else if (e.ClickedItem.Text == "GLO") typeMask ^= (1 << 2);
            else if (e.ClickedItem.Text == "GAL") typeMask ^= (1 << 3);
            else if (e.ClickedItem.Text == "ALL")
            {
                if (typeMask == 0xf) typeMask = 0;
                else typeMask = 0xf;
            }

            for (int i = 0; i < 4; i++)
            {
                chartView.Series[0].Enabled = (typeMask & (1 << 0)) == (1 << 0);
                chartView.Series[1].Enabled = (typeMask & (1 << 1)) == (1 << 1);
                chartView.Series[2].Enabled = (typeMask & (1 << 2)) == (1 << 2);
                chartView.Series[3].Enabled = (typeMask & (1 << 3)) == (1 << 3);
            }

            gpsToolStripMenuItem.Checked = (typeMask & (1 << 0)) == (1 << 0);
            bdsToolStripMenuItem.Checked = (typeMask & (1 << 1)) == (1 << 1);
            gloToolStripMenuItem.Checked = (typeMask & (1 << 2)) == (1 << 2);
            galToolStripMenuItem.Checked = (typeMask & (1 << 3)) == (1 << 3);
            allToolStripMenuItem.Checked = (typeMask & 0xf) == 0xf;
        }

        private void FormView_Load(object sender, EventArgs e)
        {
            DataGridInit();
        }

        private void FormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
