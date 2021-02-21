namespace GnssView
{
    partial class FormAcc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAcc));
            this.pictureBoxXy = new System.Windows.Forms.PictureBox();
            this.splitContainerControlBottom = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnSet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAlt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLat = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBottom)).BeginInit();
            this.splitContainerControlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxXy
            // 
            this.pictureBoxXy.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pictureBoxXy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxXy.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxXy.Name = "pictureBoxXy";
            this.pictureBoxXy.Size = new System.Drawing.Size(381, 256);
            this.pictureBoxXy.TabIndex = 0;
            this.pictureBoxXy.TabStop = false;
            this.pictureBoxXy.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxXy_Paint);
            this.pictureBoxXy.Resize += new System.EventHandler(this.pictureBoxXy_Resize);
            // 
            // splitContainerControlBottom
            // 
            this.splitContainerControlBottom.Appearance.BackColor = System.Drawing.SystemColors.HighlightText;
            this.splitContainerControlBottom.Appearance.Options.UseBackColor = true;
            this.splitContainerControlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlBottom.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControlBottom.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlBottom.Name = "splitContainerControlBottom";
            this.splitContainerControlBottom.Panel1.Controls.Add(this.pictureBoxXy);
            this.splitContainerControlBottom.Panel1.Text = "Panel1";
            this.splitContainerControlBottom.Panel2.Controls.Add(this.btnSet);
            this.splitContainerControlBottom.Panel2.Controls.Add(this.label3);
            this.splitContainerControlBottom.Panel2.Controls.Add(this.textBoxAlt);
            this.splitContainerControlBottom.Panel2.Controls.Add(this.label2);
            this.splitContainerControlBottom.Panel2.Controls.Add(this.textBoxLon);
            this.splitContainerControlBottom.Panel2.Controls.Add(this.label1);
            this.splitContainerControlBottom.Panel2.Controls.Add(this.textBoxLat);
            this.splitContainerControlBottom.Panel2.Text = "Panel2";
            this.splitContainerControlBottom.Size = new System.Drawing.Size(506, 256);
            this.splitContainerControlBottom.SplitterPosition = 120;
            this.splitContainerControlBottom.TabIndex = 1;
            this.splitContainerControlBottom.Text = "splitContainerControl1";
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.Location = new System.Drawing.Point(18, 181);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 14;
            this.btnSet.Text = "设置";
            this.btnSet.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 14);
            this.label3.TabIndex = 13;
            this.label3.Text = "高度(M)";
            // 
            // textBoxAlt
            // 
            this.textBoxAlt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAlt.Location = new System.Drawing.Point(4, 142);
            this.textBoxAlt.Name = "textBoxAlt";
            this.textBoxAlt.Size = new System.Drawing.Size(100, 22);
            this.textBoxAlt.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "经度(DDMM.MMMM)";
            // 
            // textBoxLon
            // 
            this.textBoxLon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLon.Location = new System.Drawing.Point(4, 89);
            this.textBoxLon.Name = "textBoxLon";
            this.textBoxLon.Size = new System.Drawing.Size(100, 22);
            this.textBoxLon.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "纬度(DDMM.MMMM)";
            // 
            // textBoxLat
            // 
            this.textBoxLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLat.Location = new System.Drawing.Point(4, 36);
            this.textBoxLat.Name = "textBoxLat";
            this.textBoxLat.Size = new System.Drawing.Size(100, 22);
            this.textBoxLat.TabIndex = 8;
            // 
            // FormAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 256);
            this.Controls.Add(this.splitContainerControlBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAcc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "精度";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGnss_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBottom)).EndInit();
            this.splitContainerControlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxXy;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlBottom;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAlt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLat;

    }
}