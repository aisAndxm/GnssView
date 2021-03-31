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
            this.groupControlMsg = new DevExpress.XtraEditors.GroupControl();
            this.comboBoxMeasFreq = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxMssFreq3 = new System.Windows.Forms.ComboBox();
            this.comboBoxMssFreq2 = new System.Windows.Forms.ComboBox();
            this.comboBoxMssFreq1 = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.comboBoxMssBranch3 = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.comboBoxMssBranch2 = new System.Windows.Forms.ComboBox();
            this.comboBoxMssBranch1 = new System.Windows.Forms.ComboBox();
            this.comboBoxMssItem = new System.Windows.Forms.ComboBox();
            this.comboBoxMssMode = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.comboBoxRmoEn = new System.Windows.Forms.ComboBox();
            this.comboBoxRmoItem = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.comboBoxBranch = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.comboBoxCmd = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.groupControlUart = new DevExpress.XtraEditors.GroupControl();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox14 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBoxSend = new System.Windows.Forms.RichTextBox();
            this.richTextBoxOpenPath = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.checkBoxCRLF = new System.Windows.Forms.CheckBox();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.checkBoxHex = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMsg)).BeginInit();
            this.groupControlMsg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlUart)).BeginInit();
            this.groupControlUart.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.splitContainerControl1.Size = new System.Drawing.Size(1050, 491);
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
            this.splitContainerControl2.Panel2.Controls.Add(this.groupControlMsg);
            this.splitContainerControl2.Panel2.Controls.Add(this.groupControlUart);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(1050, 369);
            this.splitContainerControl2.SplitterPosition = 160;
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
            "消息配置"}, -1);
            this.treeListView.AppendNode(new object[] {
            "串口配置"}, -1);
            this.treeListView.AppendNode(new object[] {
            "系统配置"}, -1);
            this.treeListView.EndUnboundLoad();
            this.treeListView.OptionsBehavior.Editable = false;
            this.treeListView.OptionsSelection.InvertSelection = true;
            this.treeListView.OptionsView.ShowColumns = false;
            this.treeListView.OptionsView.ShowHorzLines = false;
            this.treeListView.OptionsView.ShowIndicator = false;
            this.treeListView.OptionsView.ShowVertLines = false;
            this.treeListView.SelectImageList = this.imageListView;
            this.treeListView.Size = new System.Drawing.Size(160, 369);
            this.treeListView.TabIndex = 0;
            this.treeListView.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListView_FocusedNodeChanged);
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
            // groupControlMsg
            // 
            this.groupControlMsg.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupControlMsg.Appearance.Options.UseBackColor = true;
            this.groupControlMsg.Controls.Add(this.comboBoxMeasFreq);
            this.groupControlMsg.Controls.Add(this.label16);
            this.groupControlMsg.Controls.Add(this.comboBoxMssFreq3);
            this.groupControlMsg.Controls.Add(this.comboBoxMssFreq2);
            this.groupControlMsg.Controls.Add(this.comboBoxMssFreq1);
            this.groupControlMsg.Controls.Add(this.label21);
            this.groupControlMsg.Controls.Add(this.comboBoxMssBranch3);
            this.groupControlMsg.Controls.Add(this.label22);
            this.groupControlMsg.Controls.Add(this.comboBoxMssBranch2);
            this.groupControlMsg.Controls.Add(this.comboBoxMssBranch1);
            this.groupControlMsg.Controls.Add(this.comboBoxMssItem);
            this.groupControlMsg.Controls.Add(this.comboBoxMssMode);
            this.groupControlMsg.Controls.Add(this.label23);
            this.groupControlMsg.Controls.Add(this.comboBoxType);
            this.groupControlMsg.Controls.Add(this.label24);
            this.groupControlMsg.Controls.Add(this.comboBoxRmoEn);
            this.groupControlMsg.Controls.Add(this.comboBoxRmoItem);
            this.groupControlMsg.Controls.Add(this.label25);
            this.groupControlMsg.Controls.Add(this.comboBoxBranch);
            this.groupControlMsg.Controls.Add(this.label26);
            this.groupControlMsg.Controls.Add(this.comboBoxCmd);
            this.groupControlMsg.Controls.Add(this.label27);
            this.groupControlMsg.Location = new System.Drawing.Point(9, 12);
            this.groupControlMsg.Name = "groupControlMsg";
            this.groupControlMsg.Size = new System.Drawing.Size(76, 33);
            this.groupControlMsg.TabIndex = 122;
            this.groupControlMsg.Text = "消息配置";
            this.groupControlMsg.Visible = false;
            // 
            // comboBoxMeasFreq
            // 
            this.comboBoxMeasFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMeasFreq.FormattingEnabled = true;
            this.comboBoxMeasFreq.Items.AddRange(new object[] {
            "1",
            "0.5",
            "0.2",
            "0.1"});
            this.comboBoxMeasFreq.Location = new System.Drawing.Point(304, 125);
            this.comboBoxMeasFreq.Name = "comboBoxMeasFreq";
            this.comboBoxMeasFreq.Size = new System.Drawing.Size(50, 22);
            this.comboBoxMeasFreq.TabIndex = 106;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(235, 130);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 14);
            this.label16.TabIndex = 119;
            this.label16.Text = "RMO频率：";
            // 
            // comboBoxMssFreq3
            // 
            this.comboBoxMssFreq3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMssFreq3.FormattingEnabled = true;
            this.comboBoxMssFreq3.Items.AddRange(new object[] {
            "L1CA",
            "B1C",
            "B3Q",
            "B3I",
            "B1A",
            "B1I",
            "B2a",
            "G1",
            "G2",
            "E1OS",
            "空"});
            this.comboBoxMssFreq3.Location = new System.Drawing.Point(424, 65);
            this.comboBoxMssFreq3.Name = "comboBoxMssFreq3";
            this.comboBoxMssFreq3.Size = new System.Drawing.Size(50, 22);
            this.comboBoxMssFreq3.TabIndex = 103;
            // 
            // comboBoxMssFreq2
            // 
            this.comboBoxMssFreq2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMssFreq2.FormattingEnabled = true;
            this.comboBoxMssFreq2.Items.AddRange(new object[] {
            "L1CA",
            "B1C",
            "B3Q",
            "B3I",
            "B1A",
            "B1I",
            "B2a",
            "G1",
            "G2",
            "E1OS",
            "空"});
            this.comboBoxMssFreq2.Location = new System.Drawing.Point(364, 65);
            this.comboBoxMssFreq2.Name = "comboBoxMssFreq2";
            this.comboBoxMssFreq2.Size = new System.Drawing.Size(50, 22);
            this.comboBoxMssFreq2.TabIndex = 102;
            // 
            // comboBoxMssFreq1
            // 
            this.comboBoxMssFreq1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMssFreq1.FormattingEnabled = true;
            this.comboBoxMssFreq1.Items.AddRange(new object[] {
            "L1CA",
            "B1C",
            "B3Q",
            "B3I",
            "B1A",
            "B1I",
            "B2a",
            "G1",
            "G2",
            "E1OS",
            "空"});
            this.comboBoxMssFreq1.Location = new System.Drawing.Point(304, 65);
            this.comboBoxMssFreq1.Name = "comboBoxMssFreq1";
            this.comboBoxMssFreq1.Size = new System.Drawing.Size(50, 22);
            this.comboBoxMssFreq1.TabIndex = 99;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(237, 70);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(66, 14);
            this.label21.TabIndex = 117;
            this.label21.Text = "MSS频点：";
            // 
            // comboBoxMssBranch3
            // 
            this.comboBoxMssBranch3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMssBranch3.FormattingEnabled = true;
            this.comboBoxMssBranch3.Items.AddRange(new object[] {
            "",
            "C",
            "P",
            "A",
            "U"});
            this.comboBoxMssBranch3.Location = new System.Drawing.Point(424, 95);
            this.comboBoxMssBranch3.Name = "comboBoxMssBranch3";
            this.comboBoxMssBranch3.Size = new System.Drawing.Size(50, 22);
            this.comboBoxMssBranch3.TabIndex = 104;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(237, 100);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(66, 14);
            this.label22.TabIndex = 116;
            this.label22.Text = "MSS支路：";
            // 
            // comboBoxMssBranch2
            // 
            this.comboBoxMssBranch2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMssBranch2.FormattingEnabled = true;
            this.comboBoxMssBranch2.Items.AddRange(new object[] {
            "",
            "C",
            "P",
            "A",
            "U"});
            this.comboBoxMssBranch2.Location = new System.Drawing.Point(364, 95);
            this.comboBoxMssBranch2.Name = "comboBoxMssBranch2";
            this.comboBoxMssBranch2.Size = new System.Drawing.Size(50, 22);
            this.comboBoxMssBranch2.TabIndex = 101;
            // 
            // comboBoxMssBranch1
            // 
            this.comboBoxMssBranch1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMssBranch1.FormattingEnabled = true;
            this.comboBoxMssBranch1.Items.AddRange(new object[] {
            "",
            "C",
            "P",
            "A",
            "U"});
            this.comboBoxMssBranch1.Location = new System.Drawing.Point(304, 95);
            this.comboBoxMssBranch1.Name = "comboBoxMssBranch1";
            this.comboBoxMssBranch1.Size = new System.Drawing.Size(50, 22);
            this.comboBoxMssBranch1.TabIndex = 100;
            // 
            // comboBoxMssItem
            // 
            this.comboBoxMssItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMssItem.DropDownWidth = 130;
            this.comboBoxMssItem.FormattingEnabled = true;
            this.comboBoxMssItem.Items.AddRange(new object[] {
            "0（误码率）",
            "1（定位/RD通信/首捕）",
            "2（冷启动）",
            "3（温启动）",
            "4（热启动）",
            "5（测距）",
            "6（定时）",
            "7（重补/RD重补）",
            "8（raim）",
            "9（中动态）"});
            this.comboBoxMssItem.Location = new System.Drawing.Point(104, 95);
            this.comboBoxMssItem.Name = "comboBoxMssItem";
            this.comboBoxMssItem.Size = new System.Drawing.Size(115, 22);
            this.comboBoxMssItem.TabIndex = 97;
            // 
            // comboBoxMssMode
            // 
            this.comboBoxMssMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMssMode.FormattingEnabled = true;
            this.comboBoxMssMode.Items.AddRange(new object[] {
            "C（测试模式）",
            "Z（正式工作模式）"});
            this.comboBoxMssMode.Location = new System.Drawing.Point(104, 65);
            this.comboBoxMssMode.Name = "comboBoxMssMode";
            this.comboBoxMssMode.Size = new System.Drawing.Size(115, 22);
            this.comboBoxMssMode.TabIndex = 96;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 70);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(90, 14);
            this.label23.TabIndex = 113;
            this.label23.Text = "MSS指令参数：";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "L1CA",
            "B1C",
            "B3Q",
            "B3I",
            "B1A",
            "B1I",
            "B2a",
            "G1",
            "G2",
            "E1OS",
            "空"});
            this.comboBoxType.Location = new System.Drawing.Point(284, 35);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(70, 22);
            this.comboBoxType.TabIndex = 98;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(237, 40);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 14);
            this.label24.TabIndex = 112;
            this.label24.Text = "频点：";
            // 
            // comboBoxRmoEn
            // 
            this.comboBoxRmoEn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRmoEn.FormattingEnabled = true;
            this.comboBoxRmoEn.Items.AddRange(new object[] {
            "关闭指定语句",
            "打开指定语句",
            "关闭全部语句",
            "打开全部语句"});
            this.comboBoxRmoEn.Location = new System.Drawing.Point(104, 155);
            this.comboBoxRmoEn.Name = "comboBoxRmoEn";
            this.comboBoxRmoEn.Size = new System.Drawing.Size(115, 22);
            this.comboBoxRmoEn.TabIndex = 107;
            // 
            // comboBoxRmoItem
            // 
            this.comboBoxRmoItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRmoItem.FormattingEnabled = true;
            this.comboBoxRmoItem.Items.AddRange(new object[] {
            "GGA（定位数据）",
            "GSA（精度因子）",
            "GSV（卫星状态）",
            "DHV（速度信息）",
            "RMC（导航数据）",
            "GBS（故障卫星）",
            "BSI（波束状态）",
            "SBX（设备信息）",
            "ZTI（设备状态）",
            "PMU（PRM时效）"});
            this.comboBoxRmoItem.Location = new System.Drawing.Point(104, 125);
            this.comboBoxRmoItem.Name = "comboBoxRmoItem";
            this.comboBoxRmoItem.Size = new System.Drawing.Size(115, 22);
            this.comboBoxRmoItem.TabIndex = 108;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(12, 130);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(92, 14);
            this.label25.TabIndex = 111;
            this.label25.Text = "RMO指令参数：";
            // 
            // comboBoxBranch
            // 
            this.comboBoxBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBranch.FormattingEnabled = true;
            this.comboBoxBranch.Items.AddRange(new object[] {
            "",
            "C",
            "P",
            "A",
            "U"});
            this.comboBoxBranch.Location = new System.Drawing.Point(424, 35);
            this.comboBoxBranch.Name = "comboBoxBranch";
            this.comboBoxBranch.Size = new System.Drawing.Size(50, 22);
            this.comboBoxBranch.TabIndex = 105;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(380, 40);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(43, 14);
            this.label26.TabIndex = 110;
            this.label26.Text = "支路：";
            // 
            // comboBoxCmd
            // 
            this.comboBoxCmd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCmd.DropDownWidth = 140;
            this.comboBoxCmd.FormattingEnabled = true;
            this.comboBoxCmd.Items.AddRange(new object[] {
            "RIS（复位）",
            "MSS（设置定位方式）",
            "RMO（输出信息设置）",
            "PRD（输出观测量）",
            "ECS（获取导航信息）",
            "CPM（查询XXX）",
            "SPM（设置正式码）",
            "STM（设置测试码）"});
            this.comboBoxCmd.Location = new System.Drawing.Point(104, 35);
            this.comboBoxCmd.Name = "comboBoxCmd";
            this.comboBoxCmd.Size = new System.Drawing.Size(114, 22);
            this.comboBoxCmd.TabIndex = 95;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(12, 40);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(65, 14);
            this.label27.TabIndex = 109;
            this.label27.Text = "指令V21：";
            // 
            // groupControlUart
            // 
            this.groupControlUart.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupControlUart.Appearance.Options.UseBackColor = true;
            this.groupControlUart.Controls.Add(this.button1);
            this.groupControlUart.Controls.Add(this.groupBox2);
            this.groupControlUart.Controls.Add(this.groupBox1);
            this.groupControlUart.Controls.Add(this.comboBox9);
            this.groupControlUart.Controls.Add(this.label5);
            this.groupControlUart.Controls.Add(this.comboBox14);
            this.groupControlUart.Controls.Add(this.label9);
            this.groupControlUart.Location = new System.Drawing.Point(102, 12);
            this.groupControlUart.Name = "groupControlUart";
            this.groupControlUart.Size = new System.Drawing.Size(78, 33);
            this.groupControlUart.TabIndex = 123;
            this.groupControlUart.Text = "串口配置";
            this.groupControlUart.Visible = false;
            // 
            // comboBox9
            // 
            this.comboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Items.AddRange(new object[] {
            "C（测试模式）",
            "Z（正式工作模式）"});
            this.comboBox9.Location = new System.Drawing.Point(358, 35);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(115, 22);
            this.comboBox9.TabIndex = 96;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(266, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 14);
            this.label5.TabIndex = 113;
            this.label5.Text = "波特率：";
            // 
            // comboBox14
            // 
            this.comboBox14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox14.DropDownWidth = 140;
            this.comboBox14.FormattingEnabled = true;
            this.comboBox14.Items.AddRange(new object[] {
            "RIS（复位）",
            "MSS（设置定位方式）",
            "RMO（输出信息设置）",
            "PRD（输出观测量）",
            "ECS（获取导航信息）",
            "CPM（查询XXX）",
            "SPM（设置正式码）",
            "STM（设置测试码）"});
            this.comboBox14.Location = new System.Drawing.Point(104, 35);
            this.comboBox14.Name = "comboBox14";
            this.comboBox14.Size = new System.Drawing.Size(114, 22);
            this.comboBox14.TabIndex = 95;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 14);
            this.label9.TabIndex = 109;
            this.label9.Text = "串口号：";
            // 
            // richTextBoxSend
            // 
            this.richTextBoxSend.BackColor = System.Drawing.SystemColors.HighlightText;
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
            this.btnSend.Location = new System.Drawing.Point(565, 39);
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
            this.checkBoxCRLF.Location = new System.Drawing.Point(482, 15);
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
            this.checkBoxHex.Location = new System.Drawing.Point(482, 43);
            this.checkBoxHex.Name = "checkBoxHex";
            this.checkBoxHex.Size = new System.Drawing.Size(72, 18);
            this.checkBoxHex.TabIndex = 18;
            this.checkBoxHex.Text = "HEX发送";
            this.checkBoxHex.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(11, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(598, 101);
            this.groupBox1.TabIndex = 114;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入协议";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Location = new System.Drawing.Point(11, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(598, 101);
            this.groupBox2.TabIndex = 115;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输出协议";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(6, 21);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(63, 18);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "BDV21";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(6, 21);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(63, 18);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "BDV21";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(534, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 116;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 491);
            this.Controls.Add(this.splitContainerControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCtrl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCtrl_FormClosing);
            this.Load += new System.EventHandler(this.FormCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMsg)).EndInit();
            this.groupControlMsg.ResumeLayout(false);
            this.groupControlMsg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlUart)).EndInit();
            this.groupControlUart.ResumeLayout(false);
            this.groupControlUart.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private DevExpress.XtraEditors.GroupControl groupControlMsg;
        private System.Windows.Forms.ComboBox comboBoxMeasFreq;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBoxMssFreq3;
        private System.Windows.Forms.ComboBox comboBoxMssFreq2;
        private System.Windows.Forms.ComboBox comboBoxMssFreq1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox comboBoxMssBranch3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox comboBoxMssBranch2;
        private System.Windows.Forms.ComboBox comboBoxMssBranch1;
        private System.Windows.Forms.ComboBox comboBoxMssItem;
        private System.Windows.Forms.ComboBox comboBoxMssMode;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox comboBoxRmoEn;
        private System.Windows.Forms.ComboBox comboBoxRmoItem;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox comboBoxBranch;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox comboBoxCmd;
        private System.Windows.Forms.Label label27;
        private DevExpress.XtraEditors.GroupControl groupControlUart;
        private System.Windows.Forms.ComboBox comboBox9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
    }
}