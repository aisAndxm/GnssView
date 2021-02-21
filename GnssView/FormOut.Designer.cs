namespace GnssView
{
    partial class FormOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOut));
            this.contextMenuStripOut = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControlOut = new DevExpress.XtraEditors.PanelControl();
            this.textBoxCmd = new System.Windows.Forms.TextBox();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.statusStripOut = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRxLen = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitBtnCtrl = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItemHex = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStripOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlOut)).BeginInit();
            this.panelControlOut.SuspendLayout();
            this.statusStripOut.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripOut
            // 
            this.contextMenuStripOut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCopy,
            this.toolStripMenuItemClear});
            this.contextMenuStripOut.Name = "contextMenuStripOut";
            this.contextMenuStripOut.Size = new System.Drawing.Size(101, 48);
            // 
            // toolStripMenuItemCopy
            // 
            this.toolStripMenuItemCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemCopy.Image")));
            this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            this.toolStripMenuItemCopy.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItemCopy.Text = "复制";
            this.toolStripMenuItemCopy.Click += new System.EventHandler(this.toolStripMenuItemCopy_Click);
            // 
            // toolStripMenuItemClear
            // 
            this.toolStripMenuItemClear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemClear.Image")));
            this.toolStripMenuItemClear.Name = "toolStripMenuItemClear";
            this.toolStripMenuItemClear.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItemClear.Text = "清空";
            this.toolStripMenuItemClear.Click += new System.EventHandler(this.toolStripMenuItemClear_Click);
            // 
            // panelControlOut
            // 
            this.panelControlOut.Controls.Add(this.textBoxCmd);
            this.panelControlOut.Controls.Add(this.textBoxOut);
            this.panelControlOut.Controls.Add(this.statusStripOut);
            this.panelControlOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlOut.Location = new System.Drawing.Point(0, 0);
            this.panelControlOut.Name = "panelControlOut";
            this.panelControlOut.Size = new System.Drawing.Size(536, 256);
            this.panelControlOut.TabIndex = 1;
            // 
            // textBoxCmd
            // 
            this.textBoxCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCmd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCmd.Location = new System.Drawing.Point(292, 232);
            this.textBoxCmd.Name = "textBoxCmd";
            this.textBoxCmd.Size = new System.Drawing.Size(199, 22);
            this.textBoxCmd.TabIndex = 27;
            this.textBoxCmd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCmd_KeyDown);
            // 
            // textBoxOut
            // 
            this.textBoxOut.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBoxOut.ContextMenuStrip = this.contextMenuStripOut;
            this.textBoxOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOut.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOut.Location = new System.Drawing.Point(2, 2);
            this.textBoxOut.Multiline = true;
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.ReadOnly = true;
            this.textBoxOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOut.Size = new System.Drawing.Size(532, 229);
            this.textBoxOut.TabIndex = 26;
            this.textBoxOut.TextChanged += new System.EventHandler(this.textBoxOut_TextChanged);
            // 
            // statusStripOut
            // 
            this.statusStripOut.BackColor = System.Drawing.SystemColors.HighlightText;
            this.statusStripOut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelRxLen,
            this.toolStripStatusLabel2,
            this.toolStripSplitBtnCtrl,
            this.toolStripStatusLabel3});
            this.statusStripOut.Location = new System.Drawing.Point(2, 231);
            this.statusStripOut.Name = "statusStripOut";
            this.statusStripOut.Size = new System.Drawing.Size(532, 23);
            this.statusStripOut.TabIndex = 25;
            this.statusStripOut.Text = "statusStripOut";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 18);
            this.toolStripStatusLabel1.Text = "接收长度：";
            // 
            // toolStripStatusLabelRxLen
            // 
            this.toolStripStatusLabelRxLen.AutoSize = false;
            this.toolStripStatusLabelRxLen.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelRxLen.Name = "toolStripStatusLabelRxLen";
            this.toolStripStatusLabelRxLen.Size = new System.Drawing.Size(120, 18);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(32, 18);
            this.toolStripStatusLabel2.Text = "字节";
            // 
            // toolStripSplitBtnCtrl
            // 
            this.toolStripSplitBtnCtrl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitBtnCtrl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemHex});
            this.toolStripSplitBtnCtrl.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitBtnCtrl.Image")));
            this.toolStripSplitBtnCtrl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitBtnCtrl.Name = "toolStripSplitBtnCtrl";
            this.toolStripSplitBtnCtrl.Size = new System.Drawing.Size(32, 21);
            this.toolStripSplitBtnCtrl.Text = "设置";
            this.toolStripSplitBtnCtrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripMenuItemHex
            // 
            this.toolStripMenuItemHex.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toolStripMenuItemHex.Name = "toolStripMenuItemHex";
            this.toolStripMenuItemHex.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItemHex.Text = "HEX显示";
            this.toolStripMenuItemHex.Click += new System.EventHandler(this.toolStripMenuItemHex_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(35, 18);
            this.toolStripStatusLabel3.Text = "命令:";
            // 
            // FormOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 256);
            this.Controls.Add(this.panelControlOut);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "输出";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOut_FormClosing);
            this.contextMenuStripOut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlOut)).EndInit();
            this.panelControlOut.ResumeLayout(false);
            this.panelControlOut.PerformLayout();
            this.statusStripOut.ResumeLayout(false);
            this.statusStripOut.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStripOut;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClear;
        private DevExpress.XtraEditors.PanelControl panelControlOut;
        private System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.StatusStrip statusStripOut;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRxLen;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitBtnCtrl;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHex;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.TextBox textBoxCmd;
    }
}