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
    public partial class FormResult : Form
    {
        public FormResult()
        {
            InitializeComponent();
        }

        private void FormResult_Load(object sender, EventArgs e)
        {
            this.reportViewerSingle.RefreshReport();
            this.reportViewerSingle.RefreshReport();
            this.reportViewerSingle.RefreshReport();
        }

        private void FormResult_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void FormResult_VisibleChanged(object sender, EventArgs e)
        {
            treeViewReport.Nodes.Clear();
            string strPath = Application.StartupPath + "\\xml";
            DirectoryInfo root = new DirectoryInfo(strPath);
            foreach (FileInfo f in root.GetFiles())
            {
                treeViewReport.Nodes.Add(f.Name);
            }

            if (treeViewReport.Nodes.Count > 0)
            {
                strPath += "\\" + treeViewReport.Nodes[0].Text;
                DataSetResult.Clear();
                DataSetResult.ReadXml(strPath);
                this.reportViewerSingle.RefreshReport();
            }
        }

        private void treeViewReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string strPath = Application.StartupPath + "\\xml\\" + treeViewReport.SelectedNode.Text;

            DataSetResult.Clear();
            DataSetResult.ReadXml(strPath);
            this.reportViewerSingle.RefreshReport();
        }
    }
}
