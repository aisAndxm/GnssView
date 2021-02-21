namespace GnssView
{
    partial class FormUpdate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUpdate));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.progBarUpdate = new System.Windows.Forms.ProgressBar();
            this.groupBoxConnect = new System.Windows.Forms.GroupBox();
            this.radioBootFlash = new System.Windows.Forms.RadioButton();
            this.radioBootUart = new System.Windows.Forms.RadioButton();
            this.groupBoxTransMode = new System.Windows.Forms.GroupBox();
            this.radioTransFast = new System.Windows.Forms.RadioButton();
            this.radioTransNormal = new System.Windows.Forms.RadioButton();
            this.groupBoxUpdateImage = new System.Windows.Forms.GroupBox();
            this.checkBoxFpga = new System.Windows.Forms.CheckBox();
            this.checkBoxFirm = new System.Windows.Forms.CheckBox();
            this.checkBoxBoot = new System.Windows.Forms.CheckBox();
            this.groupBoxMemory = new System.Windows.Forms.GroupBox();
            this.radioSram = new System.Windows.Forms.RadioButton();
            this.radioWrFlash = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.groupBoxProcess = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxWaitTime = new System.Windows.Forms.TextBox();
            this.checkBoxCheckID = new System.Windows.Forms.CheckBox();
            this.checkBoxSelfCheck = new System.Windows.Forms.CheckBox();
            this.groupBoxSwVersion = new System.Windows.Forms.GroupBox();
            this.comboBoxSwVer = new System.Windows.Forms.ComboBox();
            this.timerSend = new System.Windows.Forms.Timer(this.components);
            this.groupBoxProperty = new System.Windows.Forms.GroupBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridViewPath = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxConnect.SuspendLayout();
            this.groupBoxTransMode.SuspendLayout();
            this.groupBoxUpdateImage.SuspendLayout();
            this.groupBoxMemory.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBoxProcess.SuspendLayout();
            this.groupBoxSwVersion.SuspendLayout();
            this.groupBoxProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPath)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(622, 442);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(520, 442);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(96, 23);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "开始更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(418, 442);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(96, 23);
            this.btnCreate.TabIndex = 12;
            this.btnCreate.Text = "生成加密文件";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // progBarUpdate
            // 
            this.progBarUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progBarUpdate.ForeColor = System.Drawing.Color.Teal;
            this.progBarUpdate.Location = new System.Drawing.Point(15, 413);
            this.progBarUpdate.Name = "progBarUpdate";
            this.progBarUpdate.Size = new System.Drawing.Size(703, 23);
            this.progBarUpdate.TabIndex = 13;
            // 
            // groupBoxConnect
            // 
            this.groupBoxConnect.Controls.Add(this.radioBootFlash);
            this.groupBoxConnect.Controls.Add(this.radioBootUart);
            this.groupBoxConnect.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxConnect.Location = new System.Drawing.Point(12, 184);
            this.groupBoxConnect.Name = "groupBoxConnect";
            this.groupBoxConnect.Size = new System.Drawing.Size(90, 90);
            this.groupBoxConnect.TabIndex = 16;
            this.groupBoxConnect.TabStop = false;
            this.groupBoxConnect.Text = "通信方式";
            // 
            // radioBootFlash
            // 
            this.radioBootFlash.AutoSize = true;
            this.radioBootFlash.Location = new System.Drawing.Point(6, 42);
            this.radioBootFlash.Name = "radioBootFlash";
            this.radioBootFlash.Size = new System.Drawing.Size(47, 16);
            this.radioBootFlash.TabIndex = 1;
            this.radioBootFlash.Text = "网口";
            this.radioBootFlash.UseVisualStyleBackColor = true;
            // 
            // radioBootUart
            // 
            this.radioBootUart.AutoSize = true;
            this.radioBootUart.Checked = true;
            this.radioBootUart.Location = new System.Drawing.Point(6, 20);
            this.radioBootUart.Name = "radioBootUart";
            this.radioBootUart.Size = new System.Drawing.Size(47, 16);
            this.radioBootUart.TabIndex = 0;
            this.radioBootUart.TabStop = true;
            this.radioBootUart.Text = "串口";
            this.radioBootUart.UseVisualStyleBackColor = true;
            // 
            // groupBoxTransMode
            // 
            this.groupBoxTransMode.Controls.Add(this.radioTransFast);
            this.groupBoxTransMode.Controls.Add(this.radioTransNormal);
            this.groupBoxTransMode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxTransMode.Location = new System.Drawing.Point(108, 184);
            this.groupBoxTransMode.Name = "groupBoxTransMode";
            this.groupBoxTransMode.Size = new System.Drawing.Size(100, 90);
            this.groupBoxTransMode.TabIndex = 17;
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
            // groupBoxUpdateImage
            // 
            this.groupBoxUpdateImage.Controls.Add(this.checkBoxFpga);
            this.groupBoxUpdateImage.Controls.Add(this.checkBoxFirm);
            this.groupBoxUpdateImage.Controls.Add(this.checkBoxBoot);
            this.groupBoxUpdateImage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxUpdateImage.Location = new System.Drawing.Point(214, 184);
            this.groupBoxUpdateImage.Name = "groupBoxUpdateImage";
            this.groupBoxUpdateImage.Size = new System.Drawing.Size(120, 90);
            this.groupBoxUpdateImage.TabIndex = 18;
            this.groupBoxUpdateImage.TabStop = false;
            this.groupBoxUpdateImage.Text = "更新类型";
            // 
            // checkBoxFpga
            // 
            this.checkBoxFpga.AutoSize = true;
            this.checkBoxFpga.Location = new System.Drawing.Point(6, 64);
            this.checkBoxFpga.Name = "checkBoxFpga";
            this.checkBoxFpga.Size = new System.Drawing.Size(48, 16);
            this.checkBoxFpga.TabIndex = 2;
            this.checkBoxFpga.Text = "FPGA";
            this.checkBoxFpga.UseVisualStyleBackColor = true;
            // 
            // checkBoxFirm
            // 
            this.checkBoxFirm.AutoSize = true;
            this.checkBoxFirm.Location = new System.Drawing.Point(6, 42);
            this.checkBoxFirm.Name = "checkBoxFirm";
            this.checkBoxFirm.Size = new System.Drawing.Size(72, 16);
            this.checkBoxFirm.TabIndex = 1;
            this.checkBoxFirm.Text = "Firmware";
            this.checkBoxFirm.UseVisualStyleBackColor = true;
            // 
            // checkBoxBoot
            // 
            this.checkBoxBoot.AutoSize = true;
            this.checkBoxBoot.Checked = true;
            this.checkBoxBoot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBoot.Location = new System.Drawing.Point(6, 20);
            this.checkBoxBoot.Name = "checkBoxBoot";
            this.checkBoxBoot.Size = new System.Drawing.Size(84, 16);
            this.checkBoxBoot.TabIndex = 0;
            this.checkBoxBoot.Text = "BootLoader";
            this.checkBoxBoot.UseVisualStyleBackColor = true;
            // 
            // groupBoxMemory
            // 
            this.groupBoxMemory.Controls.Add(this.radioSram);
            this.groupBoxMemory.Controls.Add(this.radioWrFlash);
            this.groupBoxMemory.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxMemory.Location = new System.Drawing.Point(340, 184);
            this.groupBoxMemory.Name = "groupBoxMemory";
            this.groupBoxMemory.Size = new System.Drawing.Size(120, 90);
            this.groupBoxMemory.TabIndex = 18;
            this.groupBoxMemory.TabStop = false;
            this.groupBoxMemory.Text = "存储位置";
            // 
            // radioSram
            // 
            this.radioSram.AutoSize = true;
            this.radioSram.Location = new System.Drawing.Point(6, 42);
            this.radioSram.Name = "radioSram";
            this.radioSram.Size = new System.Drawing.Size(47, 16);
            this.radioSram.TabIndex = 1;
            this.radioSram.Text = "Sram";
            this.radioSram.UseVisualStyleBackColor = true;
            // 
            // radioWrFlash
            // 
            this.radioWrFlash.AutoSize = true;
            this.radioWrFlash.Checked = true;
            this.radioWrFlash.Location = new System.Drawing.Point(6, 20);
            this.radioWrFlash.Name = "radioWrFlash";
            this.radioWrFlash.Size = new System.Drawing.Size(53, 16);
            this.radioWrFlash.TabIndex = 0;
            this.radioWrFlash.TabStop = true;
            this.radioWrFlash.Text = "Flash";
            this.radioWrFlash.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.textBoxOut);
            this.groupBox5.Controls.Add(this.btnQuery);
            this.groupBox5.Controls.Add(this.btnCheck);
            this.groupBox5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(466, 184);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(252, 175);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "消息";
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
            this.textBoxOut.Size = new System.Drawing.Size(240, 112);
            this.textBoxOut.TabIndex = 25;
            this.textBoxOut.TextChanged += new System.EventHandler(this.textBoxOut_TextChanged);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQuery.Location = new System.Drawing.Point(48, 146);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(96, 23);
            this.btnQuery.TabIndex = 24;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCheck.Location = new System.Drawing.Point(150, 146);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(96, 23);
            this.btnCheck.TabIndex = 23;
            this.btnCheck.Text = "自检";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // groupBoxProcess
            // 
            this.groupBoxProcess.Controls.Add(this.label1);
            this.groupBoxProcess.Controls.Add(this.textBoxWaitTime);
            this.groupBoxProcess.Controls.Add(this.checkBoxCheckID);
            this.groupBoxProcess.Controls.Add(this.checkBoxSelfCheck);
            this.groupBoxProcess.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxProcess.Location = new System.Drawing.Point(12, 280);
            this.groupBoxProcess.Name = "groupBoxProcess";
            this.groupBoxProcess.Size = new System.Drawing.Size(252, 79);
            this.groupBoxProcess.TabIndex = 19;
            this.groupBoxProcess.TabStop = false;
            this.groupBoxProcess.Text = "流程";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "传输间隔(ms)";
            // 
            // textBoxWaitTime
            // 
            this.textBoxWaitTime.Location = new System.Drawing.Point(183, 18);
            this.textBoxWaitTime.MaxLength = 7;
            this.textBoxWaitTime.Name = "textBoxWaitTime";
            this.textBoxWaitTime.Size = new System.Drawing.Size(48, 21);
            this.textBoxWaitTime.TabIndex = 5;
            this.textBoxWaitTime.Text = "1000";
            // 
            // checkBoxCheckID
            // 
            this.checkBoxCheckID.AutoSize = true;
            this.checkBoxCheckID.Location = new System.Drawing.Point(6, 44);
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
            // groupBoxSwVersion
            // 
            this.groupBoxSwVersion.Controls.Add(this.comboBoxSwVer);
            this.groupBoxSwVersion.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxSwVersion.Location = new System.Drawing.Point(270, 280);
            this.groupBoxSwVersion.Name = "groupBoxSwVersion";
            this.groupBoxSwVersion.Size = new System.Drawing.Size(190, 79);
            this.groupBoxSwVersion.TabIndex = 23;
            this.groupBoxSwVersion.TabStop = false;
            this.groupBoxSwVersion.Text = "软件版本";
            // 
            // comboBoxSwVer
            // 
            this.comboBoxSwVer.FormattingEnabled = true;
            this.comboBoxSwVer.Items.AddRange(new object[] {
            "Normal",
            "Precision",
            "Auth"});
            this.comboBoxSwVer.Location = new System.Drawing.Point(6, 16);
            this.comboBoxSwVer.Name = "comboBoxSwVer";
            this.comboBoxSwVer.Size = new System.Drawing.Size(89, 20);
            this.comboBoxSwVer.TabIndex = 23;
            // 
            // timerSend
            // 
            this.timerSend.Interval = 10;
            this.timerSend.Tick += new System.EventHandler(this.timerSend_Tick);
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
            this.groupBoxProperty.Location = new System.Drawing.Point(12, 2);
            this.groupBoxProperty.Name = "groupBoxProperty";
            this.groupBoxProperty.Size = new System.Drawing.Size(706, 176);
            this.groupBoxProperty.TabIndex = 24;
            this.groupBoxProperty.TabStop = false;
            this.groupBoxProperty.Text = "烧写文件分区";
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
            this.dataGridViewPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridViewPath.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridViewPath.Location = new System.Drawing.Point(6, 20);
            this.dataGridViewPath.Name = "dataGridViewPath";
            this.dataGridViewPath.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewPath.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewPath.RowTemplate.Height = 23;
            this.dataGridViewPath.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPath.Size = new System.Drawing.Size(635, 150);
            this.dataGridViewPath.TabIndex = 21;
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.FillWeight = 203.0457F;
            this.Column1.HeaderText = "文件路径";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.FillWeight = 50F;
            this.Column2.HeaderText = "加密";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.FillWeight = 80F;
            this.Column3.HeaderText = "日期";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.FillWeight = 50F;
            this.Column4.HeaderText = "大小";
            this.Column4.Name = "Column4";
            // 
            // FormUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(730, 472);
            this.Controls.Add(this.groupBoxProperty);
            this.Controls.Add(this.groupBoxSwVersion);
            this.Controls.Add(this.groupBoxProcess);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBoxMemory);
            this.Controls.Add(this.groupBoxUpdateImage);
            this.Controls.Add(this.groupBoxTransMode);
            this.Controls.Add(this.groupBoxConnect);
            this.Controls.Add(this.progBarUpdate);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "  固件更新";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUpdate_FormClosing);
            this.groupBoxConnect.ResumeLayout(false);
            this.groupBoxConnect.PerformLayout();
            this.groupBoxTransMode.ResumeLayout(false);
            this.groupBoxTransMode.PerformLayout();
            this.groupBoxUpdateImage.ResumeLayout(false);
            this.groupBoxUpdateImage.PerformLayout();
            this.groupBoxMemory.ResumeLayout(false);
            this.groupBoxMemory.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBoxProcess.ResumeLayout(false);
            this.groupBoxProcess.PerformLayout();
            this.groupBoxSwVersion.ResumeLayout(false);
            this.groupBoxProperty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPath)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ProgressBar progBarUpdate;
        private System.Windows.Forms.GroupBox groupBoxConnect;
        private System.Windows.Forms.RadioButton radioBootFlash;
        private System.Windows.Forms.RadioButton radioBootUart;
        private System.Windows.Forms.GroupBox groupBoxTransMode;
        private System.Windows.Forms.RadioButton radioTransFast;
        private System.Windows.Forms.RadioButton radioTransNormal;
        private System.Windows.Forms.GroupBox groupBoxUpdateImage;
        private System.Windows.Forms.CheckBox checkBoxFirm;
        private System.Windows.Forms.CheckBox checkBoxBoot;
        private System.Windows.Forms.CheckBox checkBoxFpga;
        private System.Windows.Forms.GroupBox groupBoxMemory;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.RadioButton radioSram;
        private System.Windows.Forms.RadioButton radioWrFlash;
        private System.Windows.Forms.GroupBox groupBoxProcess;
        private System.Windows.Forms.CheckBox checkBoxSelfCheck;
        private System.Windows.Forms.GroupBox groupBoxSwVersion;
        private System.Windows.Forms.ComboBox comboBoxSwVer;
        private System.Windows.Forms.Timer timerSend;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.GroupBox groupBoxProperty;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridViewPath;
        private System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.CheckBox checkBoxCheckID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxWaitTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;


    }
}