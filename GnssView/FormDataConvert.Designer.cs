namespace GnssView
{
    partial class FormDataConvert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataConvert));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBoxCapital = new System.Windows.Forms.CheckBox();
            this.checkBoxAlign = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.textBoxMoveNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxConvert = new System.Windows.Forms.ComboBox();
            this.comboBoxOri = new System.Windows.Forms.ComboBox();
            this.richTextBoxResult = new System.Windows.Forms.RichTextBox();
            this.richTextBoxOri = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxSel = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.richTextBoxU = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.richTextBoxN = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.richTextBoxE = new System.Windows.Forms.RichTextBox();
            this.richTextBoxLat = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBoxLon = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.richTextBoxAlt = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCoor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBoxZ = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxY = new System.Windows.Forms.RichTextBox();
            this.richTextBoxX = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(896, 442);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBoxCapital);
            this.tabPage1.Controls.Add(this.checkBoxAlign);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Controls.Add(this.textBoxMoveNum);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.comboBoxConvert);
            this.tabPage1.Controls.Add(this.comboBoxOri);
            this.tabPage1.Controls.Add(this.richTextBoxResult);
            this.tabPage1.Controls.Add(this.richTextBoxOri);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(888, 416);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "进制转换";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBoxCapital
            // 
            this.checkBoxCapital.AutoSize = true;
            this.checkBoxCapital.Location = new System.Drawing.Point(459, 310);
            this.checkBoxCapital.Name = "checkBoxCapital";
            this.checkBoxCapital.Size = new System.Drawing.Size(96, 16);
            this.checkBoxCapital.TabIndex = 23;
            this.checkBoxCapital.Text = "十六进制大写";
            this.checkBoxCapital.UseVisualStyleBackColor = true;
            // 
            // checkBoxAlign
            // 
            this.checkBoxAlign.AutoSize = true;
            this.checkBoxAlign.Location = new System.Drawing.Point(381, 310);
            this.checkBoxAlign.Name = "checkBoxAlign";
            this.checkBoxAlign.Size = new System.Drawing.Size(72, 16);
            this.checkBoxAlign.TabIndex = 22;
            this.checkBoxAlign.Text = "高位对齐";
            this.checkBoxAlign.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "原始数据移位数(负数左移，正数右移，最大移动31位)：";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(764, 310);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 20;
            this.btnStart.Text = "开始转换";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBoxMoveNum
            // 
            this.textBoxMoveNum.Location = new System.Drawing.Point(324, 308);
            this.textBoxMoveNum.Name = "textBoxMoveNum";
            this.textBoxMoveNum.Size = new System.Drawing.Size(51, 21);
            this.textBoxMoveNum.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(402, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 72);
            this.label2.TabIndex = 18;
            this.label2.Text = ">>>>>>>\r\n数据以\r\n逗号\r\n空格\r\n回车换行\r\n分割";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(402, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "转换为";
            // 
            // comboBoxConvert
            // 
            this.comboBoxConvert.FormattingEnabled = true;
            this.comboBoxConvert.Items.AddRange(new object[] {
            "十六进制",
            "十进制",
            "八进制",
            "二进制"});
            this.comboBoxConvert.Location = new System.Drawing.Point(597, 17);
            this.comboBoxConvert.Name = "comboBoxConvert";
            this.comboBoxConvert.Size = new System.Drawing.Size(121, 20);
            this.comboBoxConvert.TabIndex = 16;
            // 
            // comboBoxOri
            // 
            this.comboBoxOri.FormattingEnabled = true;
            this.comboBoxOri.Items.AddRange(new object[] {
            "十六进制",
            "十进制",
            "八进制",
            "二进制"});
            this.comboBoxOri.Location = new System.Drawing.Point(114, 17);
            this.comboBoxOri.Name = "comboBoxOri";
            this.comboBoxOri.Size = new System.Drawing.Size(121, 20);
            this.comboBoxOri.TabIndex = 15;
            // 
            // richTextBoxResult
            // 
            this.richTextBoxResult.BackColor = System.Drawing.SystemColors.HighlightText;
            this.richTextBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxResult.Location = new System.Drawing.Point(494, 56);
            this.richTextBoxResult.Name = "richTextBoxResult";
            this.richTextBoxResult.Size = new System.Drawing.Size(345, 217);
            this.richTextBoxResult.TabIndex = 14;
            this.richTextBoxResult.Text = "";
            // 
            // richTextBoxOri
            // 
            this.richTextBoxOri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.richTextBoxOri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxOri.Location = new System.Drawing.Point(15, 56);
            this.richTextBoxOri.Name = "richTextBoxOri";
            this.richTextBoxOri.Size = new System.Drawing.Size(345, 217);
            this.richTextBoxOri.TabIndex = 13;
            this.richTextBoxOri.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(888, 416);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "坐标系转换";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxSel);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.richTextBoxU);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.richTextBoxN);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.richTextBoxE);
            this.groupBox1.Controls.Add(this.richTextBoxLat);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.richTextBoxLon);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.richTextBoxAlt);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnCoor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.richTextBoxZ);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.richTextBoxY);
            this.groupBox1.Controls.Add(this.richTextBoxX);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 402);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "位置";
            // 
            // comboBoxSel
            // 
            this.comboBoxSel.FormattingEnabled = true;
            this.comboBoxSel.Items.AddRange(new object[] {
            "经纬度",
            "XYZ"});
            this.comboBoxSel.Location = new System.Drawing.Point(198, 302);
            this.comboBoxSel.Name = "comboBoxSel";
            this.comboBoxSel.Size = new System.Drawing.Size(110, 20);
            this.comboBoxSel.TabIndex = 39;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(37, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 20;
            this.label12.Text = "纬度(度)：";
            // 
            // richTextBoxU
            // 
            this.richTextBoxU.Location = new System.Drawing.Point(125, 250);
            this.richTextBoxU.Name = "richTextBoxU";
            this.richTextBoxU.Size = new System.Drawing.Size(183, 23);
            this.richTextBoxU.TabIndex = 38;
            this.richTextBoxU.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(37, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "经度(度)：";
            // 
            // richTextBoxN
            // 
            this.richTextBoxN.Location = new System.Drawing.Point(125, 221);
            this.richTextBoxN.Name = "richTextBoxN";
            this.richTextBoxN.Size = new System.Drawing.Size(183, 23);
            this.richTextBoxN.TabIndex = 37;
            this.richTextBoxN.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "高度(度)：";
            // 
            // richTextBoxE
            // 
            this.richTextBoxE.Location = new System.Drawing.Point(125, 192);
            this.richTextBoxE.Name = "richTextBoxE";
            this.richTextBoxE.Size = new System.Drawing.Size(183, 23);
            this.richTextBoxE.TabIndex = 36;
            this.richTextBoxE.Text = "";
            // 
            // richTextBoxLat
            // 
            this.richTextBoxLat.Location = new System.Drawing.Point(125, 21);
            this.richTextBoxLat.Name = "richTextBoxLat";
            this.richTextBoxLat.Size = new System.Drawing.Size(183, 23);
            this.richTextBoxLat.TabIndex = 23;
            this.richTextBoxLat.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 35;
            this.label7.Text = "天(米)：";
            // 
            // richTextBoxLon
            // 
            this.richTextBoxLon.Location = new System.Drawing.Point(125, 50);
            this.richTextBoxLon.Name = "richTextBoxLon";
            this.richTextBoxLon.Size = new System.Drawing.Size(183, 23);
            this.richTextBoxLon.TabIndex = 24;
            this.richTextBoxLon.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 34;
            this.label8.Text = "北(米)：";
            // 
            // richTextBoxAlt
            // 
            this.richTextBoxAlt.Location = new System.Drawing.Point(125, 79);
            this.richTextBoxAlt.Name = "richTextBoxAlt";
            this.richTextBoxAlt.Size = new System.Drawing.Size(183, 23);
            this.richTextBoxAlt.TabIndex = 25;
            this.richTextBoxAlt.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 33;
            this.label9.Text = "东(米)：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "X(米)：";
            // 
            // btnCoor
            // 
            this.btnCoor.Location = new System.Drawing.Point(198, 328);
            this.btnCoor.Name = "btnCoor";
            this.btnCoor.Size = new System.Drawing.Size(110, 23);
            this.btnCoor.TabIndex = 32;
            this.btnCoor.Text = "转换数据";
            this.btnCoor.UseVisualStyleBackColor = true;
            this.btnCoor.Click += new System.EventHandler(this.btnCoor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "Y(米)：";
            // 
            // richTextBoxZ
            // 
            this.richTextBoxZ.Location = new System.Drawing.Point(125, 164);
            this.richTextBoxZ.Name = "richTextBoxZ";
            this.richTextBoxZ.Size = new System.Drawing.Size(183, 22);
            this.richTextBoxZ.TabIndex = 31;
            this.richTextBoxZ.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "Z(米)：";
            // 
            // richTextBoxY
            // 
            this.richTextBoxY.Location = new System.Drawing.Point(125, 136);
            this.richTextBoxY.Name = "richTextBoxY";
            this.richTextBoxY.Size = new System.Drawing.Size(183, 22);
            this.richTextBoxY.TabIndex = 30;
            this.richTextBoxY.Text = "";
            // 
            // richTextBoxX
            // 
            this.richTextBoxX.Location = new System.Drawing.Point(125, 108);
            this.richTextBoxX.Name = "richTextBoxX";
            this.richTextBoxX.Size = new System.Drawing.Size(183, 22);
            this.richTextBoxX.TabIndex = 29;
            this.richTextBoxX.Text = "";
            // 
            // FormDataConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(896, 442);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDataConvert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "数据转换";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox checkBoxCapital;
        private System.Windows.Forms.CheckBox checkBoxAlign;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBoxMoveNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxConvert;
        private System.Windows.Forms.ComboBox comboBoxOri;
        public System.Windows.Forms.RichTextBox richTextBoxResult;
        public System.Windows.Forms.RichTextBox richTextBoxOri;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox richTextBoxU;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox richTextBoxN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox richTextBoxE;
        private System.Windows.Forms.RichTextBox richTextBoxLat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBoxLon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox richTextBoxAlt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCoor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBoxZ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBoxY;
        private System.Windows.Forms.RichTextBox richTextBoxX;
        private System.Windows.Forms.ComboBox comboBoxSel;

    }
}