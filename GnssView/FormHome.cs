//#define DEBUG_UART_RX

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Configuration;
using System.Management;


namespace GnssView
{
    public partial class FormHome : Form
    {
        /// <summary>
        /// 入口函数
        /// </summary>
        public FormHome()
        {
            InitializeComponent();/*主窗口标题版本号，最好在入口第一行*/
            homeInit();/*其他初始化*/
        }

        /// <summary>
        /// *****************变量***************
        /// 子窗口定义
        /// </summary>
        public FormAcc formAcc;
        public FormCn0 formCn0;
        public FormOut formOut;
        public FormCtrl formCtrl;
        private FormQtp formQtp;
        public FormView formView;
        public FormRd formRd;
        public Form2D form2D;
        private FormDataConvert formDataConv;
        private FormMsgCheck formMsgCheck;
        public FormUpdate formUpdate;
        public FormDebug formDebug;
        private FormPPS formPps;
        private FormGetMsg formGetMsg;
        private replay.FormReplay formReplay;
        private project.FormHT1902 formHt1902;
        private project.FormHt103 formHt103;
        private FormEarth formEarth;
        public FormFPGA formFPGA;

        Size homeSize;
        readonly int marginWidth = 4;/*像素点*/

        /// <summary>
        /// 显示界面信息存储变量
        /// </summary>
        public ggaMsg navGgaMsg = new ggaMsg();
        public List<gsaMsg> navGsaMsg = new List<gsaMsg>();
        public List<gsvMsg> navGsvMsg = new List<gsvMsg>();
        //public navInfo navInfos = new navInfo();
        public List<posInfo> posInfos = new List<posInfo>();
        public Dictionary<string, int> decDataFlag = new Dictionary<string, int>();/*输出语句是否解析*/

        public int qtpCloseCancel = 0;

        /// <summary>
        /// 串口监听标志
        /// </summary>
        private volatile bool is_serial_listening = false;/*串口正在监听标记*/
        private volatile bool is_serial_closing = false;/*串口正在关闭标记*/

        /// <summary>
        /// 串口相关信息定义
        /// </summary>
        public uartVar uartRxBuf = new uartVar();
        private bool uartAutoConnect = false;

        /// <summary>
        /// 串口命令解析用到的变量
        /// </summary>
        private static e_strHeadId cmdHeadType = 0;
        private static int cmdMsgPos = 0;
        readonly static byte[] cmdMsgBuf = new byte[600];

        /// <summary>
        /// 文件流变量
        /// </summary>
        public FileStream fileStreamSend;
        private FileStream fileStreamMsg;
        string fileSavePath_g;

        /// <summary>
        /// 线程定义
        /// </summary>
        private Thread pThUartRx;
        private Thread pThWriteFile;
        private bool saveFileFlag = false;/*存储文件*/
        readonly static AutoResetEvent _autoResetUartRx = new AutoResetEvent(false);
        public AutoResetEvent _autoResetOut = new AutoResetEvent(false);
        public AutoResetEvent _autoResetWriteFile = new AutoResetEvent(false);

        /*大数据存储，用于load文件使用*/
        public int nmeaLoadSecond = 0;
        private List<byte[]> loadDataMemory = new List<byte[]>();
        public List<int> loadDataUtc = new List<int>();
        private int loadByteLen = 0;
        public int loadDataType = 0;/*1:加载完成 2:nmea 3:baseband*/


        /// <summary>
        /// 初始化入口
        /// </summary>
        private void homeInit()
        {
            this.Text = "GnssView" + " " + Application.ProductVersion;

            varInit();/*初始化变量*/
            sonFormInit();/*初始化子窗口*/
            uartInfoInit();/*初始化串口*/
            threadInit();/*初始化线程*/
        }

        /// <summary>
        /// 初始化变量
        /// </summary>
        private void varInit()
        {
            decDataFlag.Add("GGA", 0);/*串口是否监听GGA语句*/
            decDataFlag.Add("GLL", 0);/*串口是否监听GLL语句*/
            decDataFlag.Add("GBS", 0);/*串口是否监听GBS语句*/
            decDataFlag.Add("GSA", 0);/*串口是否监听GSA语句*/
            decDataFlag.Add("GSV", 0);/*串口是否监听GSV语句*/
            decDataFlag.Add("RMC", 0);/*串口是否监听RMC语句*/
            decDataFlag.Add("DHV", 0);/*串口是否监听DHV语句*/
            decDataFlag.Add("BSI", 0);/*串口是否监听BSI语句*/
            decDataFlag.Add("DWR", 0);/*串口是否监听DWR语句*/
            decDataFlag.Add("FKI", 0);/*串口是否监听FKI语句*/
            decDataFlag.Add("ICZ", 0);/*串口是否监听ICZ语句*/
            decDataFlag.Add("TXR", 0);/*串口是否监听TXR语句*/
            decDataFlag.Add("ECT", 0);/*串口是否监听ECT语句*/
            decDataFlag.Add("PRO", 0);/*串口是否监听PRO语句*/
            decDataFlag.Add("RMO", 0);/*串口是否监听RMO语句*/

            navGgaMsg.init0Var();
            trackBarHome.Enabled = false;
        }

        /// <summary>
        /// 初始化子窗口
        /// </summary>
        private void sonFormInit()
        {
            this.IsMdiContainer = true;

            //formAcc = new FormAcc(this);
            //formAcc.TopLevel = false;
            //formAcc.MdiParent = this;

            //formCtrl = new FormCtrl(this);
            //formCtrl.TopLevel = false;
            //formCtrl.MdiParent = this;

            form2D = new Form2D(this)
            {
                TopLevel = false,
                MdiParent = this
            };

            formCn0 = new FormCn0(this)
            {
                TopLevel = false,
                MdiParent = this
            };

            formOut = new FormOut(this)
            {
                TopLevel = false,
                MdiParent = this
            };

            formView = new FormView(this)
            {
                TopLevel = false,
                MdiParent = this
            };

            /*窗体显示在load里面做*/
        }

        /// <summary>
        /// 初始化串口
        /// </summary>
        private void uartInfoInit()
        {
            autoGetComName();/*自动获取串口号*/
            
            try/*读取串口配置文件*/
            {
                string port = ConfigurationManager.AppSettings["port"];
                int baud = int.Parse(ConfigurationManager.AppSettings["baud"]);
                int parity = int.Parse(ConfigurationManager.AppSettings["parity"]);
                int dataBit = int.Parse(ConfigurationManager.AppSettings["dataBit"]);
                int stop = int.Parse(ConfigurationManager.AppSettings["stop"]);
                int state = int.Parse(ConfigurationManager.AppSettings["state"]);

                toolStripComboBoxBaud.SelectedIndex = baud;
                toolStripComboBoxParity.SelectedIndex = parity;
                toolStripComboBoxData.SelectedIndex = dataBit;
                toolStripComboBoxStop.SelectedIndex = stop;

                if (port != null && toolStripComboBoxCom.Items.Count > 0)
                {
                    for(int i = 0; i < toolStripComboBoxCom.Items.Count; i ++)
                    {
                        if (port.CompareTo(toolStripComboBoxCom.Items[i].ToString()) == 0)
                            toolStripComboBoxCom.SelectedIndex = i;
                    }
                    if (toolStripComboBoxCom.SelectedIndex == -1) toolStripComboBoxCom.SelectedIndex = 0;
                    else if (state == 1) uartAutoConnect = true;

                    serialPort0.PortName = toolStripComboBoxCom.SelectedItem.ToString();
                }
            }
            catch
            {
                if (toolStripComboBoxCom.Items.Count > 0)
                {
                    toolStripComboBoxCom.SelectedIndex = 0;
                    serialPort0.PortName = toolStripComboBoxCom.SelectedItem.ToString();
                }

                toolStripComboBoxBaud.SelectedIndex = 4;
                toolStripComboBoxParity.SelectedIndex = 0;
                toolStripComboBoxData.SelectedIndex = 3;
                toolStripComboBoxStop.SelectedIndex = 0;
                serialPort0.BaudRate = 115200;
                serialPort0.Parity = Parity.None;
                serialPort0.DataBits = 8;
                serialPort0.StopBits = StopBits.One;
            }

            /*初始化串口buf*/
            uartRxBuf.wr = 0;
            uartRxBuf.rd = 0;
            uartRxBuf.buf = new byte[uartVar.MSG_MAX_LEN];
            uartRxBuf.rdOut = 0;

            /*存储数据线程，可以和输出线程合并*/
            pThWriteFile = new Thread(thWriteFile)
            {
                IsBackground = true,
                Name = "SaveRx thread",
                Priority = ThreadPriority.BelowNormal
            };
            pThWriteFile.Start();
        }

        /// <summary>
        /// 初始化线程
        /// </summary>
        private void threadInit()
        {
            pThUartRx = new Thread(thUartRx)
            {
                IsBackground = true,
                Name = "HomeUart thread",
                Priority = ThreadPriority.Normal
            };
            pThUartRx.Start();

            /*命令调试时打开，模拟串口接收到的命令*/
#if DEBUG_UART_RX
            //if ((formRd == null) || (formRd.IsDisposed))
            //    formRd = new FormRd(this);

            //formRd.TopLevel = false;
            //formRd.MdiParent = this;

            //formRd.Size = new Size(homeSize.Width * 6 / 5, homeSize.Height * 7 / 5);
            //formRd.Location = formRd.Location = new Point((this.ClientSize.Width - formRd.Width) / 2, 200);
            //formRd.BringToFront();//将控件放置所有控件最前端
            //formRd.Show();

            //string cmd = "$CCBSI,1,2,45,46,46,46,45,44,0,45,45,0*59\r\n";
            //uartRxBuf.buf = System.Text.Encoding.ASCII.GetBytes(cmd);
            //uartRxBuf.wr = cmd.Length;
            //_autoResetUartRx.Set();
#endif
        }

        /// <summary>
        /// 自动获取串口号
        /// </summary>
        private void autoGetComName()
        {
            List<string> coms = new List<string>();

            try
            {
                //搜索设备管理器中的所有条目
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PnPEntity"))
                {
                    var hardInfos = searcher.Get();
                    foreach (var hardInfo in hardInfos)
                    {
                        if (hardInfo.Properties["Name"].Value != null)
                        {
                            string strTmp = hardInfo.Properties["Name"].Value.ToString();
                            if (strTmp.Contains("(COM"))
                            {
                                strTmp = strTmp.Substring(strTmp.IndexOf('(') + 1, strTmp.IndexOf(')') - strTmp.IndexOf('(') - 1);
                                if (strTmp.Contains("->"))
                                    strTmp = strTmp.Substring(strTmp.IndexOf('(') + 1, strTmp.IndexOf('-') - strTmp.IndexOf('(') - 1);
                                coms.Add(strTmp);
                            }
                        }
                    }
                    searcher.Dispose();
                }

                if (coms.Count < 1) return;
                coms.Sort();

                string strTemp = "";
                if (toolStripComboBoxCom.SelectedIndex >= 0)
                    strTemp = toolStripComboBoxCom.Text;

                toolStripComboBoxCom.Items.Clear();
                foreach (string tmp in coms)
                {
                    toolStripComboBoxCom.Items.Add(tmp);
                    if (string.Equals(tmp, strTemp))
                    {
                        toolStripComboBoxCom.SelectedIndex = toolStripComboBoxCom.Items.Count - 1;
                    }
                }
                if (toolStripComboBoxCom.SelectedIndex < 0) toolStripComboBoxCom.SelectedIndex = 0;
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// 点击串口号下拉框时更新串口号
        /// </summary>
        private void toolStripComboBoxCom_DropDown(object sender, EventArgs e)
        {
            autoGetComName();
        }

        /// <summary>
        /// 选中下拉框中的选项时触发
        /// </summary>
        private void toolStripComboBoxCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxCom.Items.Count < 1) return;
            if (serialPort0.PortName == toolStripComboBoxCom.SelectedItem.ToString()) return;

            if (serialPort0.IsOpen) serialClose();

            serialPort0.PortName = toolStripComboBoxCom.SelectedItem.ToString();
        }

        private void toolStripComboBoxBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort0.BaudRate == int.Parse(toolStripComboBoxBaud.SelectedItem.ToString())) return;

            if (serialPort0.IsOpen)
                serialClose();

            serialPort0.BaudRate = int.Parse(toolStripComboBoxBaud.SelectedItem.ToString());
        }

        private void toolStripComboBoxParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxParity.SelectedIndex == (int)serialPort0.Parity) return;
            if (serialPort0.IsOpen)
                serialClose();
            serialPort0.Parity = (Parity)toolStripComboBoxParity.SelectedIndex;
        }

        private void toolStripComboBoxData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort0.DataBits == int.Parse(toolStripComboBoxData.SelectedItem.ToString())) return;
            if (serialPort0.IsOpen)
                serialClose();
            serialPort0.DataBits = int.Parse(toolStripComboBoxData.SelectedItem.ToString());
        }

        private void toolStripComboBoxStop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort0.IsOpen)
                serialClose();

            switch (toolStripComboBoxStop.SelectedIndex)
            {
                case 0:
                    serialPort0.StopBits = StopBits.One;
                    break;
                case 1:
                    serialPort0.StopBits = StopBits.OnePointFive;
                    break;
                case 2:
                    serialPort0.StopBits = StopBits.Two;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 串口关闭函数
        /// </summary>
        private void serialClose()
        {
            if (serialPort0.IsOpen)
            {
                is_serial_closing = true;/* 关闭窗口时，置位is_serial_closing标记 */
                while (is_serial_listening) Application.DoEvents();

                serialPort0.DiscardInBuffer();/* 丢弃缓冲区数据 */
                serialPort0.Dispose();
            }
            uartRxBuf.Clear();/*清空串口数据*/
            is_serial_closing = false;
            is_serial_listening = false;
            toolStripComboBoxCom.Enabled = true;
            toolStripComboBoxBaud.Enabled = true;
            toolStripComboBoxParity.Enabled = true;
            toolStripComboBoxData.Enabled = true;
            toolStripComboBoxStop.Enabled = true;

            toolStripBtnConnect.ForeColor = Color.Brown;/*按钮连接时变成绿色图片位断开*/
            toolStripBtnConnect.Image = GnssView.Properties.Resources.断开;
        }

        /// <summary>
        /// 串口连接按钮
        /// </summary>
        private void toolStripBtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort0.IsOpen) serialClose();
                else
                {
                    loadDataType = 0;
                    uartRxBuf.wr = 0;
                    uartRxBuf.rd = 0;
                    uartRxBuf.rdOut = 0;
                    uartRxBuf.rdSave = 0;
                    autoGetComName();

                    if (!toolStripComboBoxBaud.Items.Contains(toolStripComboBoxBaud.Text))
                    {
                        if (int.TryParse(toolStripComboBoxBaud.Text, out int baud))
                        {
                            serialPort0.BaudRate = baud;
                        }
                        else return;
                    }
                    serialPort0.Open();
                    toolStripComboBoxCom.Enabled = false;
                    toolStripComboBoxBaud.Enabled = false;
                    toolStripComboBoxParity.Enabled = false;
                    toolStripComboBoxData.Enabled = false;
                    toolStripComboBoxStop.Enabled = false;

                    toolStripBtnConnect.ForeColor = Color.ForestGreen;/*按钮连接时变成红色图片位连接*/
                    toolStripBtnConnect.Image = GnssView.Properties.Resources.连接;

                    trackBarHome.Enabled = false;/*打开串口时不使能进度条*/
                }
            }
            catch{ }
        }

        /// <summary>
        /// 主界面串口的接收事件
        /// </summary>
        private void serialPort0_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (is_serial_closing)
            {
                is_serial_listening = false; //准备关闭串口时，reset串口侦听标记
                return;
            }
            try
            {
                if (serialPort0.IsOpen)
                {
                    is_serial_listening = true;

                    int wr = uartRxBuf.wr;
                    int rxLen = serialPort0.BytesToRead;

                    //if (rxLen >= serialPort0.ReadBufferSize) return ;

                    if (rxLen <= uartVar.MSG_MAX_LEN - wr)
                        serialPort0.Read(uartRxBuf.buf, wr, rxLen);
                    else
                    {
                        serialPort0.Read(uartRxBuf.buf, wr, uartVar.MSG_MAX_LEN - wr);
                        serialPort0.Read(uartRxBuf.buf, 0, rxLen - (uartVar.MSG_MAX_LEN - wr));
                    }

                    uartRxBuf.wr = (uartRxBuf.wr + rxLen) % uartVar.MSG_MAX_LEN;

                    //发送唤醒线程信号量
                    if (formOut != null && !formOut.IsDisposed) _autoResetOut.Set();
                    _autoResetUartRx.Set();
                    if (saveFileFlag) _autoResetWriteFile.Set();
                }
            }
            finally
            {
                is_serial_listening = false;//串口调用完毕后，reset串口侦听标记
            }
        }

        /// <summary>
        /// 串口发送数据 byte
        /// </summary>
        public void serialSend(byte[] data, int start, int len)
        {
            if (serialPort0.IsOpen)
            {
                try
                {
                    serialPort0.Write(data, start, len);//发送数据
                }
                catch
                {
                    serialClose();
                }
            }
        }

        /// <summary>
        /// 串口当前状态
        /// </summary>
        public bool serialState() 
        {
            if (serialPort0.IsOpen) return true;
            else return false;
        }

        /// <summary>
        /// 串口发送重定义数据 string
        /// </summary>
        public void serialSend(string data)
        {
            if (serialPort0.IsOpen)
            {
                try
                {
                    serialPort0.Write(data);//发送数据
                }
                catch
                {
                    serialClose();
                }
            }
        }

        /// <summary>
        /// 串口数据解析线程
        /// </summary>
        private void thUartRx()
        {
            while (true)
            {
                _autoResetUartRx.WaitOne();
                uartRxDecPro();
            }
        }

        /// <summary>
        /// 串口数据解析入口
        /// </summary>
        private void uartRxDecPro()
        {
            int wr = uartRxBuf.wr;
            int dataLen;
            byte[] headTmp = new byte[6];

            if (wr == uartRxBuf.rd) return;

            while (true)
            {
                if (wr >= uartRxBuf.rd) dataLen = wr - uartRxBuf.rd;
                else dataLen = uartVar.MSG_MAX_LEN - uartRxBuf.rd + wr;

                if (cmdHeadType == 0)
                {
                    if (dataLen < 6) break;

                    /*存储字头*/
                    for (int k = 0; k < 6; k++) headTmp[k] = uartRxBuf.buf[(uartRxBuf.rd + k) % uartVar.MSG_MAX_LEN];
                    /*解析字头*/
                    if ((headTmp[0] == '$') && (headTmp[1] == 'B') && (headTmp[2] == 'I') && (headTmp[3] == 'N') && (headTmp[4] == 0x21))
                    {
                        cmdHeadType = e_strHeadId.Ht1902;
                    }
                    else if ((headTmp[0] == 0xEB) && (headTmp[1] == 0x90) && (headTmp[2] == 62))
                    {
                        cmdHeadType = e_strHeadId.Ht103;
                    }
                    else if ((headTmp[0] == '$') && (headTmp[1] == 'X') && (headTmp[2] == 'L') && (headTmp[3] == 'B') && (headTmp[4] == 'I') && (headTmp[5] == 'N'))
                    {
                        cmdHeadType = e_strHeadId.update;
                    }
                    else if ((headTmp[0] == '$') && (headTmp[3] == 'P') && (headTmp[4] == 'P') && (headTmp[5] == 'S'))
                    {
                        cmdHeadType = e_strHeadId.pps;
                    }
                    else if ((headTmp[0] == '$') && (headTmp[1] == 'X') && (headTmp[2] == 'L'))
                    {
                        cmdHeadType = e_strHeadId.Msg;
                    }
                    else if ((headTmp[0] == '$') && (headTmp[3] == 'G') && (headTmp[4] == 'G') && (headTmp[5] == 'A'))/*nmea0183*/
                    {
                        cmdHeadType = e_strHeadId.Gga;
                    }
                    else if ((headTmp[0] == '$') && (headTmp[3] == 'G') && (headTmp[4] == 'S') && (headTmp[5] == 'A'))
                    {
                        cmdHeadType = e_strHeadId.Gsa;
                    }
                    else if ((headTmp[0] == '$') && (headTmp[3] == 'G') && (headTmp[4] == 'S') && (headTmp[5] == 'V'))
                    {
                        cmdHeadType = e_strHeadId.Gsv;
                    }
                    else if ((headTmp[0] == '$') && (headTmp[3] == 'R') && (headTmp[4] == 'M') && (headTmp[5] == 'C'))
                    {
                        cmdHeadType = e_strHeadId.Rmc;
                    }
                    else if ((headTmp[0] == '$') && (headTmp[3] == 'B') && (headTmp[4] == 'S') && (headTmp[5] == 'I'))
                    {
                        cmdHeadType = e_strHeadId.Bsi;
                    }
                    else if ((headTmp[0] == '$') && (headTmp[3] == 'E') && (headTmp[4] == 'C') && (headTmp[5] == 'T'))
                    {
                        cmdHeadType = e_strHeadId.Ect;
                    }
                    else if ((headTmp[0] == '$') && (headTmp[1] == 'C') && (headTmp[2] == 'C'))/*v2.1*/
                    {
                        cmdHeadType = e_strHeadId.V21;
                    }
                    else if ((headTmp[0] == '~') && (headTmp[1] == '~') && (headTmp[2] == '~') && (headTmp[3] == '~') && (headTmp[4] == '~'))
                    {
                        cmdHeadType = e_strHeadId.baseband;
                    }
                    else
                    {
                        uartRxBuf.rd++;
                        if (uartRxBuf.rd >= uartVar.MSG_MAX_LEN) uartRxBuf.rd -= uartVar.MSG_MAX_LEN;
                        continue;
                    }

                    cmdMsgPos = 0;
                    Array.Clear(cmdMsgBuf, 0, cmdMsgBuf.Length);

                    if ((((cmdHeadType == e_strHeadId.Gga) && (loadDataType == 2))
                        || ((cmdHeadType == e_strHeadId.baseband) && (loadDataType == 3))))/*加载数据时存储数据使用*/
                    {
                        if (uartRxBuf.rd > loadByteLen)/*截取读到之前的数据*/
                        {
                            byte[] bsTmp = new byte[uartRxBuf.rd - loadByteLen];
                            Array.Copy(uartRxBuf.buf, loadByteLen, bsTmp, 0, uartRxBuf.rd - loadByteLen);
                            loadDataMemory.Add(bsTmp);
                        }
                        else if (uartRxBuf.rd < loadByteLen)
                        {
                            byte[] bsTmp = new byte[uartVar.MSG_MAX_LEN - loadByteLen + uartRxBuf.rd];
                            Array.Copy(uartRxBuf.buf, loadByteLen, bsTmp, 0, uartVar.MSG_MAX_LEN - loadByteLen);
                            Array.Copy(uartRxBuf.buf, 0, bsTmp, uartVar.MSG_MAX_LEN - loadByteLen, uartRxBuf.rd);
                            loadDataMemory.Add(bsTmp);
                        }
                        nmeaLoadSecond++;
                        loadByteLen = uartRxBuf.rd;
                    }
                }
                else
                {
                    if (dataLen - cmdMsgPos < 2) break;

                    /*命令长度是否超长*/
                    bool overflowFlag = false;/*串口命令长度溢出标志*/
                    switch (cmdHeadType)
                    {
                        case e_strHeadId.Ht1902:
                            if (cmdMsgPos > 203) overflowFlag = true;
                            break;
                        case e_strHeadId.Ht103:
                            if (cmdMsgPos > 65) overflowFlag = true;
                            break;
                        case e_strHeadId.Msg:
                            if (cmdMsgPos > 500) overflowFlag = true;/*GEO D1最长413电文*/
                            break;
                        case e_strHeadId.Gga:
                        case e_strHeadId.Gsa:
                        case e_strHeadId.Gsv:
                            if (cmdMsgPos > 100) overflowFlag = true;
                            break;
                        default:
                            break;
                    }

                    if (overflowFlag)
                    {
                        uartRxBuf.rd += cmdMsgPos;
                        if (uartRxBuf.rd >= uartVar.MSG_MAX_LEN) uartRxBuf.rd -= uartVar.MSG_MAX_LEN;
                        cmdMsgPos = 0;
                        cmdHeadType = 0;
                        overflowFlag = false;

                        continue;
                    }

                    /*解析字尾*/
                    cmdMsgBuf[cmdMsgPos] = uartRxBuf.buf[(uartRxBuf.rd + cmdMsgPos) % uartVar.MSG_MAX_LEN];

                    if (cmdHeadType == e_strHeadId.update)
                    {
                        cmdMsgBuf[cmdMsgPos + 1] = uartRxBuf.buf[(uartRxBuf.rd + cmdMsgPos + 1) % uartVar.MSG_MAX_LEN];
                        cmdMsgPos += 2;
                        if (formUpdate != null && !formUpdate.IsDisposed && (cmdMsgPos == 12))
                        {
                            if (0 != formUpdate.xlbinDec(cmdMsgBuf, cmdMsgPos)) cmdMsgPos = 6;/*丢掉字头继续查找防止找错头*/
                        }
                        else if (formFPGA != null && !formFPGA.IsDisposed)
                        {
                            if (0 != formFPGA.xlbinDec(cmdMsgBuf, cmdMsgPos)) cmdMsgPos = 6;/*丢掉字头继续查找防止找错头*/
                        }
                    }
                    else if ((cmdHeadType == e_strHeadId.Msg) && (cmdMsgBuf[cmdMsgPos] == 'H') && (uartRxBuf.buf[(uartRxBuf.rd + cmdMsgPos + 1) % uartVar.MSG_MAX_LEN] == 'T'))//公司内部命令“HT”字尾
                    {
                        if (dataLen - cmdMsgPos < 4) break;
                        cmdMsgBuf[cmdMsgPos + 1] = uartRxBuf.buf[(uartRxBuf.rd + cmdMsgPos + 1) % uartVar.MSG_MAX_LEN];
                        cmdMsgPos += 2;

                        cmdMsgBuf[cmdMsgPos] = uartRxBuf.buf[(uartRxBuf.rd + cmdMsgPos) % uartVar.MSG_MAX_LEN];
                        if ((cmdMsgBuf[cmdMsgPos] != '\r') || (uartRxBuf.buf[(uartRxBuf.rd + cmdMsgPos + 1) % uartVar.MSG_MAX_LEN] != '\n')) continue;
                        cmdMsgBuf[cmdMsgPos + 1] = uartRxBuf.buf[(uartRxBuf.rd + cmdMsgPos + 1) % uartVar.MSG_MAX_LEN];
                        cmdMsgPos += 2;

                        /*写文件*/
                        fileStreamMsg = new FileStream("./msgfile.txt", FileMode.OpenOrCreate, FileAccess.Write);
                        fileStreamMsg.Seek(0, SeekOrigin.End);
                        fileStreamMsg.Write(cmdMsgBuf, 0, cmdMsgPos);
                        fileStreamMsg.Flush();
                        fileStreamMsg.Dispose();

                        /*解析命令*/
                        if ((formGetMsg != null) && (!formGetMsg.IsDisposed)) formGetMsg.ht1902MsgPro(cmdMsgBuf, cmdMsgPos);
                    }
                    else if ((cmdMsgBuf[cmdMsgPos] == '\r') && (uartRxBuf.buf[(uartRxBuf.rd + cmdMsgPos + 1) % uartVar.MSG_MAX_LEN] == '\n'))/*回车换行字尾*/
                    {
                        cmdMsgBuf[cmdMsgPos + 1] = uartRxBuf.buf[(uartRxBuf.rd + cmdMsgPos + 1) % uartVar.MSG_MAX_LEN];
                        cmdMsgPos += 2;/*带回车换行的命令总数*/

                        switch (cmdHeadType)
                        {
                            case e_strHeadId.Ht1902:
                                if ((formHt1902 != null) && (!formHt1902.IsDisposed))
                                    formHt1902.ht1902DecPro(cmdMsgBuf, cmdMsgPos);
                                break;
                            case e_strHeadId.Gga:
                                if ((formCn0 != null) && (!formCn0.IsDisposed))
                                    formCn0.decGga(cmdMsgBuf, cmdMsgPos);
                                break;
                            case e_strHeadId.Gsa:
                                if ((formCn0 != null) && (!formCn0.IsDisposed))
                                    formCn0.decGsa(cmdMsgBuf, cmdMsgPos);
                                break;
                            case e_strHeadId.Gsv:
                                if ((formCn0 != null) && (!formCn0.IsDisposed))
                                    formCn0.decGsv(cmdMsgBuf, cmdMsgPos);
                                break;
                            case e_strHeadId.Rmc:

                                break;
                            case e_strHeadId.Bsi:
                                if ((formCn0 != null) && (!formCn0.IsDisposed))
                                    formCn0.decBsi(cmdMsgBuf, cmdMsgPos);
                                break;
                            case e_strHeadId.Ect:
                                if ((formMsgCheck != null) && (!formMsgCheck.IsDisposed))
                                    formMsgCheck.msgCheckPro(cmdMsgBuf, cmdMsgPos);
                                break;
                            case e_strHeadId.V21:
                                if (formQtp != null && !formQtp.IsDisposed)
                                    formQtp.v21CmdPro(cmdMsgBuf, cmdMsgPos);
                                break;
                            case e_strHeadId.pps:
                                if ((formPps != null) && (!formPps.IsDisposed))
                                    formPps.ppsMsgPro(cmdMsgBuf, cmdMsgPos);
                                break;
                            case e_strHeadId.baseband:
                                break;
                            default:
                                break;
                        }
                    }
                    else if ((cmdHeadType == e_strHeadId.Ht103) && (cmdMsgPos == 62))
                    {
                        cmdMsgBuf[cmdMsgPos + 1] = uartRxBuf.buf[(uartRxBuf.rd + cmdMsgPos + 1) % uartVar.MSG_MAX_LEN];
                        if ((formHt103 != null) && (!formHt103.IsDisposed))
                            formHt103.ht103CmdDec(cmdMsgBuf, 64);
                    }
                    else
                    {
                        cmdMsgPos++;
                        continue;
                    }

                    uartRxBuf.rd += cmdMsgPos;
                    if (uartRxBuf.rd >= uartVar.MSG_MAX_LEN) uartRxBuf.rd -= uartVar.MSG_MAX_LEN;
                    cmdHeadType = 0;
                    cmdMsgPos = 0;
                }
            }/*while end*/
        }/*uartDataDecPro end*/

        /// <summary>
        /// 菜单栏按钮
        /// </summary>
        private void toolStripMenuItemLoad_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            if (tsmi.Text.Contains("nmea"))
                loadDataType = 2;
            else if (tsmi.Text.Contains("baseband"))
                loadDataType = 3;
            else
                return;

            serialClose();
            if (saveFileFlag)/*加载和存储不同时打开*/
            {
                saveFileFlag = false;
                toolStripBtnSave.Text = "Save";
            }
            uartRxBuf.wr = 0;
            uartRxBuf.rd = 0;

            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "加载文件",
                Filter = "*.*|*.*|*.txt|*.txt|*.dat|*.dat|*.log|*.log",
                FilterIndex = 1,
                RestoreDirectory = true,
                AutoUpgradeEnabled = false
            };

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                nmeaLoadSecond = 0;
                loadDataUtc.Clear();
                trackBarHome.Enabled = false;

                string localFilePath = dialog.FileName.ToString();
                try
                {
                    /*创建一个 StreamReader 的实例来读取文件，using 语句也能关闭 StreamReader*/
                    using (FileStream fsLoad = new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
                    {
                        long loadLen = fsLoad.Length / 100;
                        long recordLen = 0;
                        int progress = 0;
                        DevExpress.Utils.WaitDialogForm frm = new DevExpress.Utils.WaitDialogForm("加载进度0%", "正在加载数据")
                        {
                            Visible = true
                        };

                        while (true)
                        {
                            int wr = uartRxBuf.wr;
                            int rxLen = 1024;
                            int rxLenReal = 0;

                            if (rxLen <= uartVar.MSG_MAX_LEN - wr)
                                rxLenReal = fsLoad.Read(uartRxBuf.buf, wr, rxLen);
                            else
                            {
                                rxLenReal = fsLoad.Read(uartRxBuf.buf, wr, uartVar.MSG_MAX_LEN - wr);
                                rxLenReal += fsLoad.Read(uartRxBuf.buf, 0, rxLen - (uartVar.MSG_MAX_LEN - wr));
                            }

                            uartRxBuf.wr += rxLenReal;
                            uartRxBuf.wr %= uartVar.MSG_MAX_LEN;
                            /*处理数据*/
                            uartRxDecPro();

                            /*加载进度条*/
                            recordLen += rxLenReal;
                            if (recordLen > loadLen)
                            {
                                recordLen -= loadLen;
                                progress += 1;
                                if (progress > 100) progress = 100;
                                frm.Caption = "加载进度" + progress.ToString() + "%";
                            }

                            if (rxLenReal < rxLen) break;
                        }
                        frm.Visible = false;
                    }

                    uartRxBuf.wr = 0;
                    uartRxBuf.rd = 0;
                    trackBarHome.Enabled = true;
                    trackBarHome.Maximum = nmeaLoadSecond;
                    trackBarHome.Value = nmeaLoadSecond - 1;
                    loadDataType = 1;
                }
                catch
                { }
            }
        }

        public int trackValueCtrl
        {
            get { return trackBarHome.Value; }
            set { trackBarHome.Value = value; }
        }

        /// <summary>
        /// 滚动条操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarHome_ValueChanged(object sender, EventArgs e)
        {
            int valueTmp = trackBarHome.Value;
            if ((valueTmp < 0) || (valueTmp > trackBarHome.Maximum)) return;

            byte[] bytesTmp = loadDataMemory[valueTmp];
            int wr = uartRxBuf.wr;
            int rxLen = bytesTmp.Length;

            if (rxLen <= uartVar.MSG_MAX_LEN - wr)
                Array.Copy(bytesTmp, 0, uartRxBuf.buf, wr, rxLen);
            else
            {
                Array.Copy(bytesTmp, 0, uartRxBuf.buf, wr, uartVar.MSG_MAX_LEN - wr);
                Array.Copy(bytesTmp, uartVar.MSG_MAX_LEN - wr, uartRxBuf.buf, 0, rxLen - (uartVar.MSG_MAX_LEN - wr));
            }

            uartRxBuf.rdOut = uartRxBuf.wr;
            uartRxBuf.wr = (uartRxBuf.wr + rxLen) % uartVar.MSG_MAX_LEN;
            uartRxDecPro();

            try
            {
                /*加载模式时都在滚动条事件中刷新，在GGA中不刷新，实时数据时收到GGA后刷新*/
                if (formOut != null && !formOut.IsDisposed)/*发送唤醒线程信号量*/
                {
                    formOut.ClearOut();
                    formOut.textBoxShow();
                }
                if (formCn0 != null && !formCn0.IsDisposed) formCn0.RefreshCn0();
                if (formView != null && !formView.IsDisposed) formView.RefreshView();
                if (form2D != null && !form2D.IsDisposed) form2D.Refresh2D();
                if ((formAcc != null) && (!formAcc.IsDisposed)) formAcc.RefreshAxis(navGgaMsg.ggaCount, navGgaMsg.acc3D);
            }
            catch { }
        }

        /// <summary>
        /// 写文件线程
        /// </summary>
        public void thWriteFile()
        {
            while (true)
            {
                _autoResetWriteFile.WaitOne();
                int wr = uartRxBuf.wr;
                int fileRdPos = uartRxBuf.rdSave;

                if (wr == fileRdPos) continue;

                try
                {
                    using (FileStream fs = new FileStream(fileSavePath_g, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        fs.Seek(0, SeekOrigin.End);
                        if (fileRdPos < wr)
                            fs.Write(uartRxBuf.buf, fileRdPos, wr - fileRdPos);
                        else if (fileRdPos > wr)
                        {
                            fs.Write(uartRxBuf.buf, fileRdPos, uartVar.MSG_MAX_LEN - fileRdPos);
                            fs.Write(uartRxBuf.buf, 0, wr);
                        }

                        fs.Flush();
                        uartRxBuf.rdSave = wr;
                    }
                }
                catch
                {
                    this.Invoke((MethodInvoker)delegate { toolStripBtnSave.Text = "Save"; });
                }
            }
        }

        /// <summary>
        /// 执行完后会销毁
        /// 当存在多线程时，showdialog()会卡卡死线程，所以把此过程放到线程中执行
        /// </summary>
        private void saveDialog()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "保存文件";
                dialog.Filter = "文本文件(*.txt)|*.txt|二进制文件(*.bin)|*.bin|所有文件(*.*)|*.*";
                dialog.FilterIndex = 3;
                dialog.RestoreDirectory = true;
                dialog.AutoUpgradeEnabled = false;

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    fileSavePath_g = dialog.FileName.ToString();
                    FileStream fs = new FileStream(fileSavePath_g, FileMode.Create, FileAccess.Write);
                    this.Invoke((MethodInvoker)delegate { toolStripBtnSave.Text = fileSavePath_g; });
                    uartRxBuf.rdSave = uartRxBuf.wr;
                    saveFileFlag = true;
                }
            }
        }

        private void toolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            if (loadDataType > 0)/*加载数据使能*/
            {
                loadDataType = 0;
                trackBarHome.Enabled = false;
                toolStripBtnSave.Text = "Save";
            }

            if (toolStripBtnSave.Text.CompareTo("Save") == 0)
            {
                Thread t = new Thread(saveDialog)
                {
                    IsBackground = true
                };
                t.SetApartmentState(ApartmentState.STA);//缺少这句话，就会出错误。
                t.Start();
            }
            else
            {
                toolStripBtnSave.Text = "Save";
                saveFileFlag = false;
            }
        }

        private void toolStripMenuItemHt1902_Click(object sender, EventArgs e)
        {
            if ((formHt1902 == null) || (formHt1902.IsDisposed)) 
                formHt1902 = new project.FormHT1902(this);

            formHt1902.TopLevel = false;
            formHt1902.MdiParent = this;

            //formHt1902.Size = new Size(homeSize.Width * 2, homeSize.Height * 2);
            formHt1902.Location = new Point(0, 0);

            formHt1902.BringToFront();//将控件放置所有控件最前端 
            formHt1902.Show();
        }

        private void toolStripMenuItemHt103_Click(object sender, EventArgs e)
        {
            if (formHt103 == null || formHt103.IsDisposed)
            {
                formHt103 = new project.FormHt103(this)
                {
                    TopLevel = false,
                    MdiParent = this,
                };
                formHt103.Show();
            }
            else if (formHt103.WindowState == FormWindowState.Minimized)
            {
                formHt103.WindowState = FormWindowState.Normal;
            }
            formHt103.BringToFront();//将控件放置所有控件最前端 

            //byte[] cmd = new byte[]{0xEB, 0x90, 0x3E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x06, 0x3A,
            //                        0x20, 0x4E, 0x00, 0x00, 0x08, 0x02, 0xE5, 0x07, 0x07, 0x20, 0x20, 0x20, 0x4E, 0x8F, 0xD0, 0x17,
            //                        0xCD, 0xA5, 0x5D, 0x45, 0x45, 0x1E, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00,
            //                        0xFF, 0xFF, 0xFF, 0xFF, 0x82, 0x00, 0x46, 0x00, 0x00, 0x00, 0x9E, 0xFF, 0xE6, 0x11, 0x5F, 0x32};
            //Array.Copy(cmd, uartRxBuf.buf, 64);
            //uartRxBuf.wr = cmd.Length;
            //_autoResetUartRx.Set();
        }

        private void toolStripMenuItemQtp_Click(object sender, EventArgs e)
        {
            if ((formQtp == null) || (formQtp.IsDisposed))
                formQtp = new FormQtp(this);

            qtpCloseCancel = 0;

            formQtp.TopLevel = false;
            formQtp.MdiParent = this;

            formQtp.Size = new Size(homeSize.Width * 2, homeSize.Height * 2);
            formQtp.Location = new Point(0, 0);

            formQtp.BringToFront();//将控件放置所有控件最前端 
            formQtp.Show();
        }

        private void toolStripMenuItemOut_Click(object sender, EventArgs e)
        {
            if (formOut == null || formOut.IsDisposed)
            {
                formOut = new FormOut(this)
                {
                    TopLevel = false,
                    MdiParent = this,
                    Size = homeSize,
                    Location = new Point(0, homeSize.Height)
                };
                formOut.Show();
            }
            else if (formOut.WindowState == FormWindowState.Minimized)
            {
                formOut.WindowState = FormWindowState.Normal;
            }
        }

        private void toolStripMenuItemCn0_Click(object sender, EventArgs e)
        {
            if (formCn0 == null || formCn0.IsDisposed)
            {
                formCn0 = new FormCn0(this)
                {
                    TopLevel = false,
                    MdiParent = this,
                    Size = homeSize,
                    Location = new Point(homeSize.Width, 0)
                };
                formCn0.Show();
            }
            else if (formCn0.WindowState == FormWindowState.Minimized)
            {
                formCn0.WindowState = FormWindowState.Normal;
            }
        }

        private void toolStripMenuItemCtrl_Click(object sender, EventArgs e)
        {
            if (formCtrl == null || formCtrl.IsDisposed)
            {
                formCtrl = new FormCtrl(this)
                {
                    TopLevel = false,
                    MdiParent = this,
                    Size = homeSize,
                    Location = new Point(homeSize.Width, homeSize.Height)
                };
                formCtrl.Show();
            }
            else if (formCtrl.WindowState == FormWindowState.Minimized)
            {
                formCtrl.WindowState = FormWindowState.Normal;
            }
        }

        private void toolStripMenuItemAcc_Click(object sender, EventArgs e)
        {
            if (formAcc == null || formAcc.IsDisposed)
            {
                formAcc = new FormAcc(this)
                {
                    TopLevel = false,
                    MdiParent = this,
                    Size = homeSize,
                    Location = new Point(homeSize.Width, homeSize.Height)
                };
                formAcc.Show();
            }
            else if (formAcc.WindowState == FormWindowState.Minimized)
            {
                formAcc.WindowState = FormWindowState.Normal;
            }
        }

        private void toolStripMenuItemView_Click(object sender, EventArgs e)
        {
            if (formView == null || formView.IsDisposed)
            {
                formView = new FormView(this)
                {
                    TopLevel = false,
                    MdiParent = this,
                    Size = homeSize,
                    Location = new Point(0, 0)
                };
                formView.Show();
            }
            else if (formView.WindowState == FormWindowState.Minimized)
            {
                formView.WindowState = FormWindowState.Normal;
            }
        }

        private void toolStripMenuItemRdss_Click(object sender, EventArgs e)
        {
            if ((formRd == null) || (formRd.IsDisposed))
                formRd = new FormRd(this);

            formRd.TopLevel = false;
            formRd.MdiParent = this;

            formRd.Size = new Size(homeSize.Width * 6 / 5, homeSize.Height * 7 / 5);
            formRd.Location = new Point((this.ClientSize.Width - formRd.Width) / 2, 200);
            formRd.BringToFront();//将控件放置所有控件最前端
            formRd.Show();
        }

        private void toolStripMenuItem2D_Click(object sender, EventArgs e)
        {
            if (form2D == null || form2D.IsDisposed)
            {
                form2D = new Form2D(this)
                {
                    TopLevel = false,
                    MdiParent = this,
                    Size = homeSize,
                    Location = new Point(homeSize.Width, homeSize.Height)
                };
                form2D.Show();
            }
            else if (form2D.WindowState == FormWindowState.Minimized)
            {
                form2D.WindowState = FormWindowState.Normal;
            }
            form2D.BringToFront();//将控件放置所有控件最前端
        }

        private void toolStripMenuItemDataConv_Click(object sender, EventArgs e)
        {
            if ((formDataConv == null) || (formDataConv.IsDisposed))
                formDataConv = new FormDataConvert();

            formDataConv.TopLevel = false;
            formDataConv.MdiParent = this;

            formDataConv.Location = new Point(homeSize.Width - formDataConv.Width / 2, homeSize.Height - formDataConv.Height/2);
            formDataConv.BringToFront();//将控件放置所有控件最前端 
            formDataConv.Show();
        }

        private void toolStripMenuItemMsgCheck_Click(object sender, EventArgs e)
        {
            if ((formMsgCheck == null) || (formMsgCheck.IsDisposed))
                formMsgCheck = new FormMsgCheck();

            formMsgCheck.TopLevel = false;
            formMsgCheck.MdiParent = this;

            formMsgCheck.Location = new Point(homeSize.Width - formMsgCheck.Width / 2, homeSize.Height - formMsgCheck.Height / 2);
            formMsgCheck.BringToFront();//将控件放置所有控件最前端 
            formMsgCheck.Show();
            
        }

        private void toolStripMenuItemUpdate_Click(object sender, EventArgs e)
        {
            if (formUpdate == null || formUpdate.IsDisposed)
            {
                formUpdate = new FormUpdate(this)
                {
                    MdiParent = this
                };
                formUpdate.Location = new Point(homeSize.Width - formUpdate.Width / 2, homeSize.Height - formUpdate.Height / 2);
                formUpdate.Show();
            }
            else if (formUpdate.WindowState == FormWindowState.Minimized)
            {
                formUpdate.WindowState = FormWindowState.Normal;
            }
            formUpdate.BringToFront();//将控件放置所有控件最前端 
        }

        private void toolStripMenuItemFPGA_Click(object sender, EventArgs e)
        {
            if (formFPGA == null || formFPGA.IsDisposed)
            {
                formFPGA = new FormFPGA(this)
                {
                    MdiParent = this
                };
                formFPGA.Location = new Point(homeSize.Width - formFPGA.Width / 2, homeSize.Height - formFPGA.Height / 2);
                formFPGA.Show();
            }
            else if (formFPGA.WindowState == FormWindowState.Minimized)
            {
                formFPGA.WindowState = FormWindowState.Normal;
            }
            formFPGA.BringToFront();//将控件放置所有控件最前端 
        }

        private void toolStripMenuItemDebug_Click(object sender, EventArgs e)
        {
            if (formDebug == null || formDebug.IsDisposed)
            {
                formDebug = new FormDebug(this)
                {
                    TopLevel = false,
                    MdiParent = this
                };
                formDebug.Location = new Point(homeSize.Width - formDebug.Width / 2, homeSize.Height - formDebug.Height / 2);
                formDebug.Show();
            }
            else if (formDebug.WindowState == FormWindowState.Minimized)
            {
                formDebug.WindowState = FormWindowState.Normal;
            }
            formDebug.BringToFront();//将控件放置所有控件最前端 
        }

        private void toolStripMenuItemPps_Click(object sender, EventArgs e)
        {
            if (formPps == null || formPps.IsDisposed)
            {
                formPps = new FormPPS(this)
                {
                    TopLevel = false,
                    MdiParent = this,
                    Size = new Size(homeSize.Width * 6 / 5, homeSize.Height * 7 / 5)
                };
                formPps.Location = new Point((this.ClientSize.Width - formPps.Width) / 2, 200);
                formPps.Show();
            }
            else if (formPps.WindowState == FormWindowState.Minimized)
            {
                formPps.WindowState = FormWindowState.Normal;
            }
            formPps.BringToFront();//将控件放置所有控件最前端 

            //try
            //{
            //    FileStream fileStreamLoad = new FileStream(loadFilePath, FileMode.Open, FileAccess.Read);
            //    using (StreamReader sr = new StreamReader(fileStreamLoad)) 
            //    {
            //        string line;
            //        while ((line = sr.ReadLine()) != null)/*从文件读取并显示行，直到文件的末尾*/
            //        {
            //            if (String.Compare(line, 0, "$GNPPS", 0, 5) == 0)
            //            {
            //                List<string> listData = new List<string>();
            //                C_ProjectFun tmp = new C_ProjectFun();
            //                tmp.getStrFromStr(listData, System.Text.Encoding.ASCII.GetBytes(line), line.Length);
            //                if (UInt32.Parse(listData[2]) < 6) continue;
            //                double dTemp = double.Parse(listData[8]);
            //                //UInt32 iTemp = UInt32.Parse(listData[16]);
            //                //if (iTemp > 50000) dTemp = dTemp - (double)(iTemp - 2000) / 10.0;
            //                formPps.chart1.Series[0].Points.AddY(dTemp);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)/*向用户显示出错消息*/
            //{
            //    MessageBox.Show(ex.Message, "文件加载失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void toolStripMenuItemGetMsg_Click(object sender, EventArgs e)
        {
            if (formGetMsg == null || formGetMsg.IsDisposed)
            {
                formGetMsg = new FormGetMsg(this)
                {
                    MdiParent = this
                };
                formGetMsg.Location = new Point(homeSize.Width - formGetMsg.Width / 2, homeSize.Height - formGetMsg.Height / 2);
                formGetMsg.Show();
            }
            else if (formGetMsg.WindowState == FormWindowState.Minimized)
            {
                formGetMsg.WindowState = FormWindowState.Normal;
            }
            formGetMsg.BringToFront();//将控件放置所有控件最前端 
        }

        private void toolStripMenuItemHorizon_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void toolStripMenuItemVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void toolStripMenuItemCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void toolStripMenuItemFit_Click(object sender, EventArgs e)
        {
            homeSize = this.ClientSize;
            homeSize.Width = (homeSize.Width - marginWidth) / CSonFormtInfo.SON_WIN_ROW_NUM;
            homeSize.Height = (homeSize.Height - menuStripHome.Size.Height - toolStripHome.Size.Height - trackBarHome.Size.Height - marginWidth) / CSonFormtInfo.SON_WIN_COL_NUM;

            if (formAcc != null && !formAcc.IsDisposed)
            {
                formAcc.Size = homeSize;
                formAcc.Location = new Point(homeSize.Width, homeSize.Height);
                formAcc.Show();
            }

            if (formCn0 != null && !formCn0.IsDisposed)
            {
                formCn0.Size = homeSize;
                formCn0.Location = new Point(homeSize.Width, 0);
                formCn0.Show();
            }

            if (formOut != null && !formOut.IsDisposed)
            {
                formOut.Size = homeSize;
                formOut.Location = new Point(0, homeSize.Height);
                formOut.Show();
            }

            if (formCtrl != null && !formCtrl.IsDisposed)
            {
                formCtrl.Size = homeSize;
                formCtrl.Location = new Point(homeSize.Width, homeSize.Height);
                formCtrl.Show();
            }

            if (formHt1902 != null && !formHt1902.IsDisposed)
            {
                /*formHt1902.Size = new Size(homeSize.Width * 2, homeSize.Height * 2);*/
                formHt1902.Location = new Point(0, 0);
                formHt1902.Show();
            }

            if (formQtp != null && !formQtp.IsDisposed)
            {
                formQtp.Size = new Size(homeSize.Width * 2, homeSize.Height * 2);
                formQtp.Location = new Point(0, 0);
                formQtp.Show();
            }

            if (formView != null && !formView.IsDisposed)
            {
                formView.Size = homeSize;
                formView.Location = new Point(0, 0);
                formView.Show();
            }

            if (form2D != null && !form2D.IsDisposed)
            {
                form2D.Size = homeSize;
                form2D.Location = new Point(homeSize.Width, homeSize.Height);
                form2D.Show();
            }
        }

        private void toolStripMenuItemContent_Click(object sender, EventArgs e)
        {
            FormContent content = new FormContent();
            content.history();
            content.StartPosition = FormStartPosition.CenterScreen;
            content.Show();
        }

        private void toolStripMenuItemReplay_Click(object sender, EventArgs e)
        {
            if (formReplay == null || formReplay.IsDisposed)
            {
                formReplay = new replay.FormReplay(this)
                {
                    TopLevel = false,
                    MdiParent = this,
                };
                formReplay.Show();
            }
            else if (formReplay.WindowState == FormWindowState.Minimized)
            {
                formReplay.WindowState = FormWindowState.Normal;
            }
            formReplay.BringToFront();//将控件放置所有控件最前端 
        }

        private void toolStripMenuItemReport_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItemTrue_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemEarth_Click(object sender, EventArgs e)
        {
            if (formEarth == null || formEarth.IsDisposed)
            {
                formEarth = new FormEarth(this)
                {
                    MdiParent = this
                };
                formEarth.Location = new Point(homeSize.Width - formEarth.Width / 2, homeSize.Height - formEarth.Height / 2);
                formEarth.Show();
            }
            else if (formEarth.WindowState == FormWindowState.Minimized)
            {
                formEarth.WindowState = FormWindowState.Normal;
            }
            formEarth.BringToFront();//将控件放置所有控件最前端
        }

        /// <summary>
        /// 工具栏按钮
        /// </summary>
        private void toolStripBtnCls_Click(object sender, EventArgs e)
        {
            if (formOut != null && !formOut.IsDisposed) formOut.ClearOut();
            if (formAcc != null && !formAcc.IsDisposed) formAcc.clearGnss();
            if (formCn0 != null && !formCn0.IsDisposed) formCn0.clearCn0();
            if (form2D != null && !form2D.IsDisposed) form2D.clear2D();
            if (formView != null && !formView.IsDisposed) formView.clearView();
        }

        /// <summary>
        /// 保存串口参数
        /// </summary>
        private void saveSerialCfg()
        {
            Configuration serialCfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (toolStripComboBoxCom.Items.Count > 0)
                serialCfg.AppSettings.Settings["port"].Value = toolStripComboBoxCom.SelectedItem.ToString();
            serialCfg.AppSettings.Settings["baud"].Value = toolStripComboBoxBaud.SelectedIndex.ToString();
            serialCfg.AppSettings.Settings["parity"].Value = toolStripComboBoxParity.SelectedIndex.ToString();
            serialCfg.AppSettings.Settings["dataBit"].Value = toolStripComboBoxData.SelectedIndex.ToString();
            serialCfg.AppSettings.Settings["stop"].Value = toolStripComboBoxStop.SelectedIndex.ToString();
            if (serialPort0.IsOpen)
                serialCfg.AppSettings.Settings["state"].Value = "1";
            else
                serialCfg.AppSettings.Settings["state"].Value = "0";
            serialCfg.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 主窗体加载事件函数
        /// </summary>
        private void FormHome_Load(object sender, EventArgs e)
        {
            ///*取消跨线程警告，不用使用委托*/
            //Control.CheckForIllegalCrossThreadCalls = false;
            homeSize = this.ClientSize;
            homeSize.Width = (homeSize.Width - marginWidth) / CSonFormtInfo.SON_WIN_ROW_NUM;
            homeSize.Height = (homeSize.Height - menuStripHome.Size.Height - toolStripHome.Size.Height - trackBarHome.Size.Height - marginWidth) / CSonFormtInfo.SON_WIN_COL_NUM;

            formView.Size = homeSize;
            formView.Location = new Point(0, 0);
            formView.Show();
            formCn0.Size = homeSize;
            formCn0.Location = new Point(homeSize.Width, 0);
            formCn0.Show();
            formOut.Size = homeSize;
            formOut.Location = new Point(0, homeSize.Height);
            formOut.Show();
            form2D.Size = homeSize;
            form2D.Location = new Point(homeSize.Width, homeSize.Height);
            form2D.Show();

            if (uartAutoConnect) toolStripBtnConnect.PerformClick();
        }

        /// <summary>
        /// 主窗体关闭事件函数
        /// </summary>
        private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formQtp != null && !formQtp.IsDisposed)
            {
                formQtp.Close();
                while (qtpCloseCancel == 0) ;
                if (qtpCloseCancel == 1)
                {
                    e.Cancel = true;
                    return;
                }
            }

            saveSerialCfg();
            if (serialPort0.IsOpen) serialClose();

            if (fileStreamSend != null) fileStreamSend.Dispose();
            if (fileStreamMsg != null) fileStreamMsg.Dispose();

            if (pThWriteFile != null) pThWriteFile.Abort();

            if (pThUartRx != null) pThUartRx.Abort();

            if (formAcc != null) formAcc.Close();
            if (formCn0 != null) formCn0.Close();
            if (formOut != null) formOut.Close();
            if (formCtrl != null) formCtrl.Close();
            if (formView != null) formView.Close();
            if (formRd != null) formRd.Close();
            if (form2D != null) form2D.Close();

            //System.Environment.Exit(System.Environment.ExitCode);
        }
    }
}


/// <summary>
/// 定时器
/// </summary>
/// <param name="source"></param>
/// <param name="e"></param>
///             
//System.Timers.Timer refreshTimer;
//refreshTimer = new System.Timers.Timer(500);//实例化Timer类，设置间隔时间为100毫秒；
//refreshTimer.Elapsed += new System.Timers.ElapsedEventHandler(refreshExecute);//到达时间的时候执行事件；
//refreshTimer.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；
//public void refreshExecute(object source, System.Timers.ElapsedEventArgs e)
//{
//    refreshTimer.Stop(); //先关闭定时器
//    //if (formCn0 != null && !formCn0.IsDisposed) formCn0.cn0Refresh();
//    //if (formView != null && !formView.IsDisposed) formView.viewRefresh();
//    //if (form2D != null && !form2D.IsDisposed) form2D.panelRefresh();
//}

