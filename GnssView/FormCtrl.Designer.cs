namespace GnssView
{
    partial class FormCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCtrl));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeListView = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnTool = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageListView = new System.Windows.Forms.ImageList(this.components);
            this.groupControlView = new DevExpress.XtraEditors.GroupControl();
            this.richTextBoxSend = new System.Windows.Forms.RichTextBox();
            this.richTextBoxOpenPath = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.checkBoxCRLF = new System.Windows.Forms.CheckBox();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.checkBoxHex = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Appearance.BackColor = System.Drawing.SystemColors.HighlightText;
            this.splitContainerControl1.Appearance.Options.UseBackColor = true;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.richTextBoxSend);
            this.splitContainerControl1.Panel2.Controls.Add(this.richTextBoxOpenPath);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnSend);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnOpenFile);
            this.splitContainerControl1.Panel2.Controls.Add(this.checkBoxCRLF);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnSendFile);
            this.splitContainerControl1.Panel2.Controls.Add(this.checkBoxHex);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(843, 424);
            this.splitContainerControl1.SplitterPosition = 112;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.treeListView);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.groupControlView);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(843, 307);
            this.splitContainerControl2.SplitterPosition = 193;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // treeListView
            // 
            this.treeListView.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnTool});
            this.treeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView.Location = new System.Drawing.Point(0, 0);
            this.treeListView.Name = "treeListView";
            this.treeListView.BeginUnboundLoad();
            this.treeListView.AppendNode(new object[] {
            "串口配置(XLCOM)"}, -1);
            this.treeListView.AppendNode(new object[] {
            "获取电文(XLNAV)"}, -1);
            this.treeListView.EndUnboundLoad();
            this.treeListView.OptionsBehavior.Editable = false;
            this.treeListView.OptionsSelection.InvertSelection = true;
            this.treeListView.OptionsView.ShowColumns = false;
            this.treeListView.OptionsView.ShowHorzLines = false;
            this.treeListView.OptionsView.ShowIndicator = false;
            this.treeListView.OptionsView.ShowVertLines = false;
            this.treeListView.SelectImageList = this.imageListView;
            this.treeListView.Size = new System.Drawing.Size(193, 307);
            this.treeListView.TabIndex = 0;
            // 
            // treeListColumnTool
            // 
            this.treeListColumnTool.Caption = "功能配置";
            this.treeListColumnTool.FieldName = "功能配置";
            this.treeListColumnTool.Name = "treeListColumnTool";
            this.treeListColumnTool.Visible = true;
            this.treeListColumnTool.VisibleIndex = 0;
            // 
            // imageListView
            // 
            this.imageListView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListView.ImageStream")));
            this.imageListView.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListView.Images.SetKeyName(0, "RD树.png");
            // 
            // groupControlView
            // 
            this.groupControlView.Appearance.BackColor = System.Drawing.SystemColors.HighlightText;
            this.groupControlView.Appearance.Options.UseBackColor = true;
            this.groupControlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlView.Location = new System.Drawing.Point(0, 0);
            this.groupControlView.Name = "groupControlView";
            this.groupControlView.ShowCaption = false;
            this.groupControlView.Size = new System.Drawing.Size(645, 307);
            this.groupControlView.TabIndex = 0;
            this.groupControlView.Text = "groupControl";
            // 
            // richTextBoxSend
            // 
            this.richTextBoxSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxSend.Location = new System.Drawing.Point(11, 11);
            this.richTextBoxSend.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxSend.Name = "richTextBoxSend";
            this.richTextBoxSend.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxSend.Size = new System.Drawing.Size(456, 54);
            this.richTextBoxSend.TabIndex = 21;
            this.richTextBoxSend.Text = "";
            this.richTextBoxSend.TextChanged += new System.EventHandler(this.richTextBoxSend_TextChanged);
            // 
            // richTextBoxOpenPath
            // 
            this.richTextBoxOpenPath.BackColor = System.Drawing.SystemColors.HighlightText;
            this.richTextBoxOpenPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxOpenPath.Location = new System.Drawing.Point(11, 70);
            this.richTextBoxOpenPath.Name = "richTextBoxOpenPath";
            this.richTextBoxOpenPath.ReadOnly = true;
            this.richTextBoxOpenPath.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxOpenPath.Size = new System.Drawing.Size(456, 24);
            this.richTextBoxOpenPath.TabIndex = 17;
            this.richTextBoxOpenPath.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(482, 39);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 24);
            this.btnSend.TabIndex = 20;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(482, 69);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 24);
            this.btnOpenFile.TabIndex = 15;
            this.btnOpenFile.Text = "打开文件";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // checkBoxCRLF
            // 
            this.checkBoxCRLF.AutoSize = true;
            this.checkBoxCRLF.Location = new System.Drawing.Point(483, 15);
            this.checkBoxCRLF.Name = "checkBoxCRLF";
            this.checkBoxCRLF.Size = new System.Drawing.Size(74, 18);
            this.checkBoxCRLF.TabIndex = 19;
            this.checkBoxCRLF.Text = "回车换行";
            this.checkBoxCRLF.UseVisualStyleBackColor = true;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(565, 69);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(75, 24);
            this.btnSendFile.TabIndex = 16;
            this.btnSendFile.Text = "发送文件";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // checkBoxHex
            // 
            this.checkBoxHex.AutoSize = true;
            this.checkBoxHex.Location = new System.Drawing.Point(568, 15);
            this.checkBoxHex.Name = "checkBoxHex";
            this.checkBoxHex.Size = new System.Drawing.Size(72, 18);
            this.checkBoxHex.TabIndex = 18;
            this.checkBoxHex.Text = "HEX发送";
            this.checkBoxHex.UseVisualStyleBackColor = true;
            // 
            // FormCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 424);
            this.Controls.Add(this.splitContainerControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCtrl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCtrl_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        public System.Windows.Forms.RichTextBox richTextBoxSend;
        private System.Windows.Forms.RichTextBox richTextBoxOpenPath;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnOpenFile;
        public System.Windows.Forms.CheckBox checkBoxCRLF;
        private System.Windows.Forms.Button btnSendFile;
        public System.Windows.Forms.CheckBox checkBoxHex;
        private DevExpress.XtraTreeList.TreeList treeListView;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnTool;
        private System.Windows.Forms.ImageList imageListView;
        private DevExpress.XtraEditors.GroupControl groupControlView;

    }
}