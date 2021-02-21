namespace GnssView
{
    partial class FormQtpAllResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DataTableAcqBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetResult = new GnssView.DataSetResult();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewQtp = new System.Windows.Forms.TreeView();
            this.reportViewerQtp = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableAcqBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataTableAcqBindingSource
            // 
            this.DataTableAcqBindingSource.DataMember = "DataTableAcq";
            this.DataTableAcqBindingSource.DataSource = this.DataSetResult;
            // 
            // DataSetResult
            // 
            this.DataSetResult.DataSetName = "DataSetResult";
            this.DataSetResult.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewQtp);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reportViewerQtp);
            this.splitContainer1.Size = new System.Drawing.Size(781, 490);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeViewQtp
            // 
            this.treeViewQtp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewQtp.Location = new System.Drawing.Point(0, 0);
            this.treeViewQtp.Name = "treeViewQtp";
            this.treeViewQtp.Size = new System.Drawing.Size(260, 490);
            this.treeViewQtp.TabIndex = 0;
            this.treeViewQtp.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewQtp_AfterSelect);
            // 
            // reportViewerQtp
            // 
            this.reportViewerQtp.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetQtp";
            reportDataSource1.Value = this.DataTableAcqBindingSource;
            this.reportViewerQtp.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerQtp.LocalReport.ReportEmbeddedResource = "GnssView.ReportQtp.rdlc";
            this.reportViewerQtp.Location = new System.Drawing.Point(0, 0);
            this.reportViewerQtp.Name = "reportViewerQtp";
            this.reportViewerQtp.Size = new System.Drawing.Size(517, 490);
            this.reportViewerQtp.TabIndex = 0;
            // 
            // FormQtpAllResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 490);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormQtpAllResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormQtpAllResult";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormQtpAllResult_FormClosing);
            this.Load += new System.EventHandler(this.FormQtpAllResult_Load);
            this.VisibleChanged += new System.EventHandler(this.FormQtpAllResult_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.DataTableAcqBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetResult)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewQtp;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerQtp;
        private System.Windows.Forms.BindingSource DataTableAcqBindingSource;
        private DataSetResult DataSetResult;
    }
}