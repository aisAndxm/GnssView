namespace GnssView
{
    partial class FormResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResult));
            this.DataTableAcqBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetResult = new GnssView.DataSetResult();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewReport = new System.Windows.Forms.TreeView();
            this.reportViewerSingle = new Microsoft.Reporting.WinForms.ReportViewer();
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
            this.splitContainer1.Panel1.Controls.Add(this.treeViewReport);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reportViewerSingle);
            this.splitContainer1.Size = new System.Drawing.Size(652, 350);
            this.splitContainer1.SplitterDistance = 217;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeViewReport
            // 
            this.treeViewReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewReport.Location = new System.Drawing.Point(0, 0);
            this.treeViewReport.Name = "treeViewReport";
            this.treeViewReport.Size = new System.Drawing.Size(217, 350);
            this.treeViewReport.TabIndex = 0;
            this.treeViewReport.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewReport_AfterSelect);
            // 
            // reportViewerSingle
            // 
            this.reportViewerSingle.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetQtp";
            reportDataSource1.Value = this.DataTableAcqBindingSource;
            this.reportViewerSingle.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerSingle.LocalReport.ReportEmbeddedResource = "GnssView.ReportQtp.rdlc";
            this.reportViewerSingle.Location = new System.Drawing.Point(0, 0);
            this.reportViewerSingle.Name = "reportViewerSingle";
            this.reportViewerSingle.Size = new System.Drawing.Size(431, 350);
            this.reportViewerSingle.TabIndex = 0;
            // 
            // FormResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 350);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormResult";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormResult_FormClosing);
            this.Load += new System.EventHandler(this.FormResult_Load);
            this.VisibleChanged += new System.EventHandler(this.FormResult_VisibleChanged);
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
        private System.Windows.Forms.TreeView treeViewReport;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerSingle;
        private System.Windows.Forms.BindingSource DataTableAcqBindingSource;
        private DataSetResult DataSetResult;
    }
}