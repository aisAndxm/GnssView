
namespace GnssView
{
    partial class FormFPGA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFPGA));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxWaitTime = new System.Windows.Forms.TextBox();
            this.checkBoxCheckID = new System.Windows.Forms.CheckBox();
            this.checkBoxSelfCheck = new System.Windows.Forms.CheckBox();
            this.timerSend = new System.Windows.Forms.Timer(this.components);
            this.btnDown = new System.Windows.Forms.Button();
            this.groupBoxProperty = new System.Windows.Forms.GroupBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridViewPath = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxProcess = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.progBarUpdate = new System.Windows.Forms.ProgressBar();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxTransMode = new System.Windows.Forms.GroupBox();
            this.radioTransFast = new System.Windows.Forms.RadioButton();
            this.radioTransNormal = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.radioBtnApp = new System.Windows.Forms.RadioButton();
            this.radioBtnBoot = new System.Windows.Forms.RadioButton();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.groupBoxReg = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxWRRD = new System.Windows.Forms.ComboBox();
            this.btnSendCmd = new System.Windows.Forms.Button();
            this.comboBoxRegAddr = new System.Windows.Forms.ComboBox();
            this.comboBoxRegVal = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnReadFlash = new System.Windows.Forms.Button();
            this.groupBoxProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPath)).BeginInit();
            this.groupBoxProcess.SuspendLayout();
            this.groupBoxTransMode.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBoxType.SuspendLayout();
            this.groupBoxReg.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "传输间隔(ms):";
            // 
            // textBoxWaitTime
            // 
            this.textBoxWaitTime.Location = new System.Drawing.Point(95, 45);
            this.textBoxWaitTime.MaxLength = 7;
            this.textBoxWaitTime.Name = "textBoxWaitTime";
            this.textBoxWaitTime.Size = new System.Drawing.Size(48, 21);
            this.textBoxWaitTime.TabIndex = 5;
            this.textBoxWaitTime.Text = "1000";
            // 
            // checkBoxCheckID
            // 
            this.checkBoxCheckID.AutoSize = true;
            this.checkBoxCheckID.Location = new System.Drawing.Point(60, 20);
            this.checkBoxCheckID.Name = "checkBoxCheckID";
            this.checkBoxCheckID.Size = new System.Drawing.Size(72, 16);
            this.checkBoxCheckID.TabIndex = 4;
            this.checkBoxCheckID.Text = "校验帧号";
            this.checkBoxCheckID.UseVisualStyleBackColor = true;
            // 
            // checkBoxSelfCheck
            // 
            this.checkBoxSelfCheck.AutoSize = true;
            this.checkBoxSelfCheck.Location = new System.Drawing.Point(6, 20);
            this.checkBoxSelfCheck.Name = "checkBoxSelfCheck";
            this.checkBoxSelfCheck.Size = new System.Drawing.Size(48, 16);
            this.checkBoxSelfCheck.TabIndex = 3;
            this.checkBoxSelfCheck.Text = "自检";
            this.checkBoxSelfCheck.UseVisualStyleBackColor = true;
            // 
            // timerSend
            // 
            this.timerSend.Tick += new System.EventHandler(this.timerSend_Tick);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.Location = new System.Drawing.Point(647, 136);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(53, 23);
            this.btnDown.TabIndex = 26;
            this.btnDown.Text = "向下";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // groupBoxProperty
            // 
            this.groupBoxProperty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxProperty.Controls.Add(this.btnDown);
            this.groupBoxProperty.Controls.Add(this.btnUp);
            this.groupBoxProperty.Controls.Add(this.btnEdit);
            this.groupBoxProperty.Controls.Add(this.btnDelete);
            this.groupBoxProperty.Controls.Add(this.btnAdd);
            this.groupBoxProperty.Controls.Add(this.dataGridViewPath);
            this.groupBoxProperty.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxProperty.Location = new System.Drawing.Point(12, 5);
            this.groupBoxProperty.Name = "groupBoxProperty";
            this.groupBoxProperty.Size = new System.Drawing.Size(706, 176);
            this.groupBoxProperty.TabIndex = 36;
            this.groupBoxProperty.TabStop = false;
            this.groupBoxProperty.Text = "烧写文件分区";
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.Location = new System.Drawing.Point(647, 107);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(53, 23);
            this.btnUp.TabIndex = 25;
            this.btnUp.Text = "向上";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(647, 78);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(53, 23);
            this.btnEdit.TabIndex = 24;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(647, 49);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(53, 23);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(647, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(53, 23);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridViewPath
            // 
            this.dataGridViewPath.AllowUserToAddRows = false;
            this.dataGridViewPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPath.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPath.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridViewPath.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPath.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPath.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewPath.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridViewPath.Location = new System.Drawing.Point(6, 20);
            this.dataGridViewPath.Name = "dataGridViewPath";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPath.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewPath.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewPath.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewPath.RowTemplate.Height = 23;
            this.dataGridViewPath.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPath.Size = new System.Drawing.Size(635, 150);
            this.dataGridViewPath.TabIndex = 21;
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.FillWeight = 203.0457F;
            this.Column1.HeaderText = "文件路径";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.FillWeight = 50F;
            this.Column2.HeaderText = "加密";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.FillWeight = 80F;
            this.Column3.HeaderText = "日期";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column4.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column4.FillWeight = 50F;
            this.Column4.HeaderText = "大小";
            this.Column4.Name = "Column4";
            // 
            // groupBoxProcess
            // 
            this.groupBoxProcess.Controls.Add(this.label1);
            this.groupBoxProcess.Controls.Add(this.checkBoxCheckID);
            this.groupBoxProcess.Controls.Add(this.textBoxWaitTime);
            this.groupBoxProcess.Controls.Add(this.checkBoxSelfCheck);
            this.groupBoxProcess.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxProcess.Location = new System.Drawing.Point(12, 283);
            this.groupBoxProcess.Name = "groupBoxProcess";
            this.groupBoxProcess.Size = new System.Drawing.Size(237, 114);
            this.groupBoxProcess.TabIndex = 33;
            this.groupBoxProcess.TabStop = false;
            this.groupBoxProcess.Text = "流程";
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQuery.Location = new System.Drawing.Point(322, 124);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(64, 23);
            this.btnQuery.TabIndex = 24;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // progBarUpdate
            // 
            this.progBarUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progBarUpdate.ForeColor = System.Drawing.Color.Teal;
            this.progBarUpdate.Location = new System.Drawing.Point(15, 416);
            this.progBarUpdate.Name = "progBarUpdate";
            this.progBarUpdate.Size = new System.Drawing.Size(703, 23);
            this.progBarUpdate.TabIndex = 28;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(520, 445);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(96, 23);
            this.btnUpdate.TabIndex = 26;
            this.btnUpdate.Text = "开始更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(622, 445);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 23);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBoxTransMode
            // 
            this.groupBoxTransMode.Controls.Add(this.radioTransFast);
            this.groupBoxTransMode.Controls.Add(this.radioTransNormal);
            this.groupBoxTransMode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxTransMode.Location = new System.Drawing.Point(12, 187);
            this.groupBoxTransMode.Name = "groupBoxTransMode";
            this.groupBoxTransMode.Size = new System.Drawing.Size(130, 90);
            this.groupBoxTransMode.TabIndex = 30;
            this.groupBoxTransMode.TabStop = false;
            this.groupBoxTransMode.Text = "传输方式";
            // 
            // radioTransFast
            // 
            this.radioTransFast.AutoSize = true;
            this.radioTransFast.Location = new System.Drawing.Point(6, 42);
            this.radioTransFast.Name = "radioTransFast";
            this.radioTransFast.Size = new System.Drawing.Size(71, 16);
            this.radioTransFast.TabIndex = 1;
            this.radioTransFast.Text = "静默传输";
            this.radioTransFast.UseVisualStyleBackColor = true;
            // 
            // radioTransNormal
            // 
            this.radioTransNormal.AutoSize = true;
            this.radioTransNormal.Checked = true;
            this.radioTransNormal.Location = new System.Drawing.Point(6, 20);
            this.radioTransNormal.Name = "radioTransNormal";
            this.radioTransNormal.Size = new System.Drawing.Size(71, 16);
            this.radioTransNormal.TabIndex = 0;
            this.radioTransNormal.TabStop = true;
            this.radioTransNormal.Text = "应答模式";
            this.radioTransNormal.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.btnReadFlash);
            this.groupBox5.Controls.Add(this.btnDefault);
            this.groupBox5.Controls.Add(this.textBoxOut);
            this.groupBox5.Controls.Add(this.btnQuery);
            this.groupBox5.Controls.Add(this.btnCheck);
            this.groupBox5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(255, 187);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(463, 154);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "消息";
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCheck.Location = new System.Drawing.Point(392, 124);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(64, 23);
            this.btnCheck.TabIndex = 23;
            this.btnCheck.Text = "自检";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // groupBoxType
            // 
            this.groupBoxType.Controls.Add(this.radioBtnApp);
            this.groupBoxType.Controls.Add(this.radioBtnBoot);
            this.groupBoxType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxType.Location = new System.Drawing.Point(148, 187);
            this.groupBoxType.Name = "groupBoxType";
            this.groupBoxType.Size = new System.Drawing.Size(101, 90);
            this.groupBoxType.TabIndex = 37;
            this.groupBoxType.TabStop = false;
            this.groupBoxType.Text = "更新类型";
            // 
            // radioBtnApp
            // 
            this.radioBtnApp.AutoSize = true;
            this.radioBtnApp.Location = new System.Drawing.Point(6, 42);
            this.radioBtnApp.Name = "radioBtnApp";
            this.radioBtnApp.Size = new System.Drawing.Size(41, 16);
            this.radioBtnApp.TabIndex = 1;
            this.radioBtnApp.Text = "App";
            this.radioBtnApp.UseVisualStyleBackColor = true;
            // 
            // radioBtnBoot
            // 
            this.radioBtnBoot.AutoSize = true;
            this.radioBtnBoot.Checked = true;
            this.radioBtnBoot.Location = new System.Drawing.Point(6, 20);
            this.radioBtnBoot.Name = "radioBtnBoot";
            this.radioBtnBoot.Size = new System.Drawing.Size(83, 16);
            this.radioBtnBoot.TabIndex = 0;
            this.radioBtnBoot.TabStop = true;
            this.radioBtnBoot.Text = "BootLoader";
            this.radioBtnBoot.UseVisualStyleBackColor = true;
            // 
            // textBoxOut
            // 
            this.textBoxOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOut.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOut.Location = new System.Drawing.Point(6, 19);
            this.textBoxOut.Multiline = true;
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOut.Size = new System.Drawing.Size(451, 99);
            this.textBoxOut.TabIndex = 25;
            this.textBoxOut.TextChanged += new System.EventHandler(this.textBoxOut_TextChanged);
            // 
            // groupBoxReg
            // 
            this.groupBoxReg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxReg.Controls.Add(this.comboBoxRegVal);
            this.groupBoxReg.Controls.Add(this.comboBoxRegAddr);
            this.groupBoxReg.Controls.Add(this.label3);
            this.groupBoxReg.Controls.Add(this.label2);
            this.groupBoxReg.Controls.Add(this.comboBoxWRRD);
            this.groupBoxReg.Controls.Add(this.btnSendCmd);
            this.groupBoxReg.Location = new System.Drawing.Point(255, 347);
            this.groupBoxReg.Name = "groupBoxReg";
            this.groupBoxReg.Size = new System.Drawing.Size(463, 50);
            this.groupBoxReg.TabIndex = 38;
            this.groupBoxReg.TabStop = false;
            this.groupBoxReg.Text = "读写设备寄存器";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 48;
            this.label3.Text = "寄存器数据：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 46;
            this.label2.Text = "寄存器地址：";
            // 
            // comboBoxWRRD
            // 
            this.comboBoxWRRD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWRRD.FormattingEnabled = true;
            this.comboBoxWRRD.Items.AddRange(new object[] {
            "写",
            "读"});
            this.comboBoxWRRD.Location = new System.Drawing.Point(5, 19);
            this.comboBoxWRRD.Name = "comboBoxWRRD";
            this.comboBoxWRRD.Size = new System.Drawing.Size(45, 20);
            this.comboBoxWRRD.TabIndex = 45;
            // 
            // btnSendCmd
            // 
            this.btnSendCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendCmd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSendCmd.Location = new System.Drawing.Point(392, 18);
            this.btnSendCmd.Name = "btnSendCmd";
            this.btnSendCmd.Size = new System.Drawing.Size(64, 23);
            this.btnSendCmd.TabIndex = 44;
            this.btnSendCmd.Text = "发送";
            this.btnSendCmd.UseVisualStyleBackColor = true;
            this.btnSendCmd.Click += new System.EventHandler(this.btnSendCmd_Click);
            // 
            // comboBoxRegAddr
            // 
            this.comboBoxRegAddr.DropDownWidth = 180;
            this.comboBoxRegAddr.FormattingEnabled = true;
            this.comboBoxRegAddr.Items.AddRange(new object[] {
            "0x0000（用户软复位）",
            "0x0010（擦除空间的起始地址）",
            "0x0011（擦除空间的起始地址）",
            "0x0014（擦除空间的长度）",
            "0x0015（擦除空间的长度）"});
            this.comboBoxRegAddr.Location = new System.Drawing.Point(139, 19);
            this.comboBoxRegAddr.Name = "comboBoxRegAddr";
            this.comboBoxRegAddr.Size = new System.Drawing.Size(64, 20);
            this.comboBoxRegAddr.TabIndex = 49;
            // 
            // comboBoxRegVal
            // 
            this.comboBoxRegVal.DropDownWidth = 100;
            this.comboBoxRegVal.FormattingEnabled = true;
            this.comboBoxRegVal.Items.AddRange(new object[] {
            "0x0001（复位）"});
            this.comboBoxRegVal.Location = new System.Drawing.Point(292, 19);
            this.comboBoxRegVal.Name = "comboBoxRegVal";
            this.comboBoxRegVal.Size = new System.Drawing.Size(64, 20);
            this.comboBoxRegVal.TabIndex = 50;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(418, 445);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(96, 23);
            this.btnConnect.TabIndex = 39;
            this.btnConnect.Text = "连接设备";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefault.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefault.Location = new System.Drawing.Point(220, 125);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(96, 23);
            this.btnDefault.TabIndex = 40;
            this.btnDefault.Text = "加载默认程序";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnReadFlash
            // 
            this.btnReadFlash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadFlash.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadFlash.Location = new System.Drawing.Point(139, 125);
            this.btnReadFlash.Name = "btnReadFlash";
            this.btnReadFlash.Size = new System.Drawing.Size(75, 23);
            this.btnReadFlash.TabIndex = 41;
            this.btnReadFlash.Text = "读Flash";
            this.btnReadFlash.UseVisualStyleBackColor = true;
            this.btnReadFlash.Click += new System.EventHandler(this.btnReadFlash_Click);
            // 
            // FormFPGA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(730, 472);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.groupBoxReg);
            this.Controls.Add(this.groupBoxType);
            this.Controls.Add(this.groupBoxProperty);
            this.Controls.Add(this.groupBoxProcess);
            this.Controls.Add(this.progBarUpdate);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBoxTransMode);
            this.Controls.Add(this.groupBox5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFPGA";
            this.Text = "FormFPGA";
            this.groupBoxProperty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPath)).EndInit();
            this.groupBoxProcess.ResumeLayout(false);
            this.groupBoxProcess.PerformLayout();
            this.groupBoxTransMode.ResumeLayout(false);
            this.groupBoxTransMode.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBoxType.ResumeLayout(false);
            this.groupBoxType.PerformLayout();
            this.groupBoxReg.ResumeLayout(false);
            this.groupBoxReg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxWaitTime;
        private System.Windows.Forms.CheckBox checkBoxCheckID;
        private System.Windows.Forms.CheckBox checkBoxSelfCheck;
        private System.Windows.Forms.Timer timerSend;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.GroupBox groupBoxProperty;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridViewPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.GroupBox groupBoxProcess;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ProgressBar progBarUpdate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBoxTransMode;
        private System.Windows.Forms.RadioButton radioTransFast;
        private System.Windows.Forms.RadioButton radioTransNormal;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.GroupBox groupBoxType;
        private System.Windows.Forms.RadioButton radioBtnApp;
        private System.Windows.Forms.RadioButton radioBtnBoot;
        private System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.GroupBox groupBoxReg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxWRRD;
        private System.Windows.Forms.Button btnSendCmd;
        private System.Windows.Forms.ComboBox comboBoxRegVal;
        private System.Windows.Forms.ComboBox comboBoxRegAddr;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnReadFlash;
    }
}