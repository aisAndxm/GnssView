namespace GnssView
{
    partial class Form2D
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2D));
            this.splitContainerControl2D = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.textBoxLon = new System.Windows.Forms.TextBox();
            this.textBoxLat = new System.Windows.Forms.TextBox();
            this.labelLon = new System.Windows.Forms.Label();
            this.labelLat = new System.Windows.Forms.Label();
            this.radioBtnFirst = new System.Windows.Forms.RadioButton();
            this.radioBtnTrue = new System.Windows.Forms.RadioButton();
            this.radioBtnCurrent = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2D)).BeginInit();
            this.splitContainerControl2D.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl2D
            // 
            this.splitContainerControl2D.Appearance.BackColor = System.Drawing.Color.White;
            this.splitContainerControl2D.Appearance.Options.UseBackColor = true;
            this.splitContainerControl2D.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            this.splitContainerControl2D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2D.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl2D.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2D.Name = "splitContainerControl2D";
            this.splitContainerControl2D.Panel1.Text = "Panel1";
            this.splitContainerControl2D.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainerControl2D_Panel1_Paint);
            this.splitContainerControl2D.Panel2.Controls.Add(this.groupBox1);
            this.splitContainerControl2D.Panel2.Text = "Panel2";
            this.splitContainerControl2D.Size = new System.Drawing.Size(935, 442);
            this.splitContainerControl2D.SplitterPosition = 196;
            this.splitContainerControl2D.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.textBoxLon);
            this.groupBox1.Controls.Add(this.textBoxLat);
            this.groupBox1.Controls.Add(this.labelLon);
            this.groupBox1.Controls.Add(this.labelLat);
            this.groupBox1.Controls.Add(this.radioBtnFirst);
            this.groupBox1.Controls.Add(this.radioBtnTrue);
            this.groupBox1.Controls.Add(this.radioBtnCurrent);
            this.groupBox1.Location = new System.Drawing.Point(24, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 246);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "中心点选择";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(87, 204);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(45, 23);
            this.btnApply.TabIndex = 7;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Visible = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // textBoxLon
            // 
            this.textBoxLon.Location = new System.Drawing.Point(20, 176);
            this.textBoxLon.Name = "textBoxLon";
            this.textBoxLon.Size = new System.Drawing.Size(112, 22);
            this.textBoxLon.TabIndex = 6;
            this.textBoxLon.Text = "11622.59042752";
            this.textBoxLon.Visible = false;
            // 
            // textBoxLat
            // 
            this.textBoxLat.Location = new System.Drawing.Point(20, 134);
            this.textBoxLat.Name = "textBoxLat";
            this.textBoxLat.Size = new System.Drawing.Size(112, 22);
            this.textBoxLat.TabIndex = 5;
            this.textBoxLat.Text = "3957.26395668";
            this.textBoxLat.Visible = false;
            // 
            // labelLon
            // 
            this.labelLon.AutoSize = true;
            this.labelLon.Location = new System.Drawing.Point(17, 159);
            this.labelLon.Name = "labelLon";
            this.labelLon.Size = new System.Drawing.Size(115, 14);
            this.labelLon.TabIndex = 4;
            this.labelLon.Text = "经度(DDMM.MMMM)";
            this.labelLon.Visible = false;
            // 
            // labelLat
            // 
            this.labelLat.AutoSize = true;
            this.labelLat.Location = new System.Drawing.Point(17, 117);
            this.labelLat.Name = "labelLat";
            this.labelLat.Size = new System.Drawing.Size(115, 14);
            this.labelLat.TabIndex = 3;
            this.labelLat.Text = "纬度(DDMM.MMMM)";
            this.labelLat.Visible = false;
            // 
            // radioBtnFirst
            // 
            this.radioBtnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnFirst.AutoSize = true;
            this.radioBtnFirst.Location = new System.Drawing.Point(26, 60);
            this.radioBtnFirst.Name = "radioBtnFirst";
            this.radioBtnFirst.Size = new System.Drawing.Size(61, 18);
            this.radioBtnFirst.TabIndex = 1;
            this.radioBtnFirst.Text = "第一点";
            this.radioBtnFirst.UseVisualStyleBackColor = true;
            // 
            // radioBtnTrue
            // 
            this.radioBtnTrue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnTrue.AutoSize = true;
            this.radioBtnTrue.Location = new System.Drawing.Point(26, 84);
            this.radioBtnTrue.Name = "radioBtnTrue";
            this.radioBtnTrue.Size = new System.Drawing.Size(61, 18);
            this.radioBtnTrue.TabIndex = 2;
            this.radioBtnTrue.Text = "真值点";
            this.radioBtnTrue.UseVisualStyleBackColor = true;
            this.radioBtnTrue.CheckedChanged += new System.EventHandler(this.radioBtnTrue_CheckedChanged);
            // 
            // radioBtnCurrent
            // 
            this.radioBtnCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnCurrent.AutoSize = true;
            this.radioBtnCurrent.Checked = true;
            this.radioBtnCurrent.Location = new System.Drawing.Point(26, 36);
            this.radioBtnCurrent.Name = "radioBtnCurrent";
            this.radioBtnCurrent.Size = new System.Drawing.Size(61, 18);
            this.radioBtnCurrent.TabIndex = 0;
            this.radioBtnCurrent.TabStop = true;
            this.radioBtnCurrent.Text = "当前点";
            this.radioBtnCurrent.UseVisualStyleBackColor = true;
            // 
            // Form2D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 442);
            this.Controls.Add(this.splitContainerControl2D);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2D";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "水平精度";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2D_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2D)).EndInit();
            this.splitContainerControl2D.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }











        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2D;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox textBoxLon;
        private System.Windows.Forms.TextBox textBoxLat;
        private System.Windows.Forms.Label labelLon;
        private System.Windows.Forms.Label labelLat;
        private System.Windows.Forms.RadioButton radioBtnFirst;
        private System.Windows.Forms.RadioButton radioBtnTrue;
        private System.Windows.Forms.RadioButton radioBtnCurrent;
    }
}