using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Reporting.WinForms;

namespace GnssView
{
    public partial class FormQtpAllResult : Form
    {
        public FormQtpAllResult()
        {
            InitializeComponent();
        }

        private void FormQtpAllResult_Load(object sender, EventArgs e)
        {
            this.reportViewerQtp.RefreshReport();
        }

        private void FormQtpAllResult_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void FormQtpAllResult_VisibleChanged(object sender, EventArgs e)
        {
            treeViewQtp.Nodes.Clear();
            string strPath = Application.StartupPath + "\\xml";
            DirectoryInfo root = new DirectoryInfo(strPath);
            foreach (FileInfo f in root.GetFiles())
            {
                treeViewQtp.Nodes.Add(f.Name);
            }

            if (treeViewQtp.Nodes.Count > 0)
            {
                strPath += "\\" + treeViewQtp.Nodes[0].Text;
                DataSetResult.Clear();
                DataSetResult.ReadXml(strPath);
                this.reportViewerQtp.RefreshReport();
            }
        }

        private void treeViewQtp_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string strPath = Application.StartupPath + "\\xml\\" + treeViewQtp.SelectedNode.Text;

            DataSetResult.Clear();
            DataSetResult.ReadXml(strPath);
            this.reportViewerQtp.RefreshReport();
        }
    }
}
