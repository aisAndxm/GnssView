namespace GnssView
{
    partial class FormMsgCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMsgCheck));
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.checkBoxS1Q = new System.Windows.Forms.CheckBox();
            this.checkBoxS1I = new System.Windows.Forms.CheckBox();
            this.checkBoxB2BI = new System.Windows.Forms.CheckBox();
            this.textBoxCrcResult = new System.Windows.Forms.TextBox();
            this.groupBoxType.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxType
            // 
            this.groupBoxType.Controls.Add(this.checkBoxS1Q);
            this.groupBoxType.Controls.Add(this.checkBoxS1I);
            this.groupBoxType.Controls.Add(this.checkBoxB2BI);
            this.groupBoxType.Location = new System.Drawing.Point(12, 12);
            this.groupBoxType.Name = "groupBoxType";
            this.groupBoxType.Size = new System.Drawing.Size(517, 50);
            this.groupBoxType.TabIndex = 0;
            this.groupBoxType.TabStop = false;
            this.groupBoxType.Text = "测试类型";
            // 
            // checkBoxS1Q
            // 
            this.checkBoxS1Q.AutoSize = true;
            this.checkBoxS1Q.Location = new System.Drawing.Point(200, 20);
            this.checkBoxS1Q.Name = "checkBoxS1Q";
            this.checkBoxS1Q.Size = new System.Drawing.Size(42, 16);
            this.checkBoxS1Q.TabIndex = 2;
            this.checkBoxS1Q.Text = "S1Q";
            this.checkBoxS1Q.UseVisualStyleBackColor = true;
            // 
            // checkBoxS1I
            // 
            this.checkBoxS1I.AutoSize = true;
            this.checkBoxS1I.Location = new System.Drawing.Point(120, 20);
            this.checkBoxS1I.Name = "checkBoxS1I";
            this.checkBoxS1I.Size = new System.Drawing.Size(42, 16);
            this.checkBoxS1I.TabIndex = 1;
            this.checkBoxS1I.Text = "S1I";
            this.checkBoxS1I.UseVisualStyleBackColor = true;
            // 
            // checkBoxB2BI
            // 
            this.checkBoxB2BI.AutoSize = true;
            this.checkBoxB2BI.Location = new System.Drawing.Point(40, 20);
            this.checkBoxB2BI.Name = "checkBoxB2BI";
            this.checkBoxB2BI.Size = new System.Drawing.Size(48, 16);
            this.checkBoxB2BI.TabIndex = 0;
            this.checkBoxB2BI.Text = "B2BI";
            this.checkBoxB2BI.UseVisualStyleBackColor = true;
            // 
            // textBoxCrcResult
            // 
            this.textBoxCrcResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCrcResult.Location = new System.Drawing.Point(12, 68);
            this.textBoxCrcResult.Multiline = true;
            this.textBoxCrcResult.Name = "textBoxCrcResult";
            this.textBoxCrcResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCrcResult.Size = new System.Drawing.Size(516, 198);
            this.textBoxCrcResult.TabIndex = 1;
            this.textBoxCrcResult.TextChanged += new System.EventHandler(this.textBoxCrcResult_TextChanged);
            // 
            // FormMsgCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 278);
            this.Controls.Add(this.textBoxCrcResult);
            this.Controls.Add(this.groupBoxType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMsgCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "电文检测";
            this.groupBoxType.ResumeLayout(false);
            this.groupBoxType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxType;
        private System.Windows.Forms.CheckBox checkBoxS1Q;
        private System.Windows.Forms.CheckBox checkBoxS1I;
        private System.Windows.Forms.CheckBox checkBoxB2BI;
        private System.Windows.Forms.TextBox textBoxCrcResult;
    }
}