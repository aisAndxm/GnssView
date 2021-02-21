using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.IO;
using System.Xml;



namespace GnssView
{
    public partial class FormQtp : Form
    {
        public FormQtp(FormHome home)
        {
            InitializeComponent();

            homeTmp = home;

            fromQtpInit();
        }
        private FormHome homeTmp;

        private readonly double WGS_LIGHT_SPEED = 299792458.0;
        /*V21命令*/
        private Dictionary<string, string> d_v21CmdGroup = new Dictionary<string, string> { 
            {"head", ""}, {"type", ""}, {"branch", ""}, {"rmoItem", ""}, {"rmoEn", ""}, {"rmoFreq", ""}, {"mssMode", ""},
            {"mssItem", ""}, {"mssFreq1", ""}, {"mssFreq2", ""}, {"mssFreq3", ""}, {"mssBranch1", ""}, {"mssBranch2", ""}, {"mssBranch3", ""},
        };

        private Dictionary<string, int> d_ectErrorRate = new Dictionary<string, int>() { {"totol", 0},{"error", 0}};

        private string strFileName = "";//生成文件名

        private int cmdSendTimer = 0;
        public struct_rcvrTime_t recvTime = new struct_rcvrTime_t();
        public static struct_utcTime_t utcTime = new struct_utcTime_t();

        private static e_strHeadId cmdHead = 0;
        private static int cmdMsgPos = 0;
        private static byte[] cmdMsgBuf = new byte[500];
        private static uartVar qtpRxBuf = new uartVar();
        private static int printCount = 0;

        /*监听串口标志*/
        private volatile bool is_serial_listening = false;//串口正在监听标记
        private volatile bool is_serial_closing = false;//串口正在关闭标记

        /*线程定义*/
        private Thread pThQtpUartRx;//串口数据接收
        static AutoResetEvent _waitHandleRx = new AutoResetEvent(false);//串口收和串口解析线程的信号
        private Thread pThQtpMain;
        static AutoResetEvent _waitHandleMain = new AutoResetEvent(false);//自动化测试线程的信号

        private FileStream fileTestResult;
        private bool saveFileFlag = false;
        public bool itemTestState = false;//开始测试
        private int itemNowTestCnt_g = 1;
        private int itemStatisticsFlag = 0;//开始统计

        private List<List<struct_mearMsg_t>> l_mearMsg = new List<List<struct_mearMsg_t>>();
        FormResult fMearResult;
        DataSetResult dataSetResultExa = new DataSetResult();
        string xmlPathString = "";
        string nowIntrCnt;//当前中断计数

        private struct_baseband_t varMin = new struct_baseband_t() { cn0Corr = 9999, pldCorr = 9999, cn0Data = 9999, pldData = 9999 };
        private struct_baseband_t varMax = new struct_baseband_t() { cn0Corr = 0, pldCorr = 0, cn0Data = 0, pldData = 0 };
        private UInt64 svidRef = 0;
        private UInt64 svidComp = 0;
        private UInt64 intrSvidRef = 0;
        private bool publicSvidFlag = true;
        private bool intrAcqCmd = false;

        //private List<MssItem> listItem = new List<MssItem>();
        private Dictionary<e_mssItem, List<string>> d_itemInfo = new Dictionary<e_mssItem, List<string>>();
        private int acqTestCnt = 0;
        int[,] cn0MaxMin = new int[2, 64];
        double[,] arryPsrij = new double[120, 64];
        double[,] arryCarrij = new double[120, 64];
        static int intrPos = 0;
        List<int> l_quitSvid = new List<int>();
        struct_qtpResultFlag_t resultFlag = new struct_qtpResultFlag_t();

        Dictionary<string, double> d_carryPeriod = new Dictionary<string, double>();

        private void fromQtpInit()
        {
            /* 初始化串口 */
            autoGetComName();
            if (comboBoxCom.Items.Count >= 1)
                comboBoxCom.SelectedIndex = 0;

            comboBoxBaud.SelectedIndex = 2;

            if (comboBoxCom.Items.Count >= 1)
                serialPortPro.PortName = comboBoxCom.SelectedItem.ToString();
            serialPortPro.BaudRate = int.Parse(comboBoxBaud.SelectedItem.ToString());
            serialPortPro.Parity = Parity.None;
            serialPortPro.DataBits = 8;
            serialPortPro.StopBits = StopBits.One;

            qtpRxBuf.buf = new byte[uartVar.MSG_MAX_LEN];
            qtpRxBuf.rd = 0;
            qtpRxBuf.wr = 0;

            /* 初始化comBox */
            comboBoxCmd.SelectedIndex = (int)e_v21Cmd.MSS;

            comboBoxAuthRefType.SelectedIndex = 0;
            comboBoxAuthTestType.SelectedIndex = 0;
            comboBoxAssist.SelectedIndex = 0;

            d_carryPeriod.Add("B3Q", CCarryCountDef.B3Q);
            d_carryPeriod.Add("B3I", CCarryCountDef.B3I);

            string path = Application.StartupPath + "\\data";

            if (!System.IO.Directory.Exists(path))
                Directory.CreateDirectory(path);//创建目录

            path = Application.StartupPath + "\\xml";

            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            fMearResult = new FormResult();//新建报表窗口

            Array.Clear(arryPsrij, 0, arryPsrij.Length);
            Array.Clear(arryCarrij, 0, arryCarrij.Length);

            /* 初始化线程 */
            pThQtpUartRx = new Thread(thQtpUartRx)
            {
                IsBackground = true,
                Name = "QtpUart thread",
                Priority = ThreadPriority.AboveNormal
            };
            pThQtpUartRx.Start();
        }

        private void autoGetComName()
        {
            string[] namesTmp = SerialPort.GetPortNames();
            string strTemp = "";

            if (comboBoxCom.SelectedIndex >= 0)
                strTemp = comboBoxCom.Text;

            comboBoxCom.Items.Clear();
            foreach (string tmp in namesTmp)
            {
                comboBoxCom.Items.Add(tmp);
                if (string.Equals(tmp, strTemp))
                {
                    comboBoxCom.SelectedIndex = comboBoxCom.Items.Count - 1;
                }
            }
        }

        private void comboBoxCom_DropDown(object sender, EventArgs e)
        {
            autoGetComName();
        }

        private void comboBoxCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCom.Items.Count == 0) return;
            if (serialPortPro.PortName == comboBoxCom.SelectedItem.ToString()) return;

            if (serialPortPro.IsOpen)
            {
                serialPortPro.Close();
                btnConnect.Text = "打开串口";
            }
            serialPortPro.PortName = comboBoxCom.SelectedItem.ToString();
        }

        private void comboBoxBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPortPro.BaudRate == int.Parse(comboBoxBaud.SelectedItem.ToString())) return;

            if (serialPortPro.IsOpen)
            {
                serialPortPro.Close();
                btnConnect.Text = "打开串口";
            }
            serialPortPro.BaudRate = int.Parse(comboBoxBaud.SelectedItem.ToString());
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serialPortPro.IsOpen)
                {
                    serialPortPro.Open();
                    btnConnect.Text = "关闭串口";
                }
                else if (serialPortPro.IsOpen)
                {
                    serialClose();
                    btnConnect.Text = "打开串口";
                }
            }
            catch (Exception ex)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show(ex.Message, "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerPC_Tick(object sender, EventArgs e)
        {
            richTextBoxSendCmdShow.AppendText("未收到命令");
            itemTestState = false;
            timerPC.Enabled = false;
        }

        private void timerAuth_Tick(object sender, EventArgs e)//命令定时器
        {
            cmdSendTimer++;//警惕越界

            if (d_itemInfo[e_mssItem.authTest][3].CompareTo("C") == 0)//军码授时直接在定时器完成
            {
                recvTime.seconds++;
                if (recvTime.seconds >= 604800)
                {
                    recvTime.seconds = 0;
                    recvTime.weekNum += 1;
                    if (recvTime.weekNum >= 1024)
                        recvTime.weekNum = 0;
                }

                if (cmdSendTimer > 6 && cmdSendTimer < 10)
                {
                    StringBuilder timBuf = new StringBuilder();
                    int checkSum = 0;

                    timBuf.AppendFormat("$CCTIM,{0},{1}", recvTime.weekNum, recvTime.seconds);

                    byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(timBuf.ToString());
                    for (int i = 1; i < byteArray.Length; i++)//添加校验
                        checkSum ^= byteArray[i];
                    timBuf.AppendFormat("*{0:X2}\r\n", (byte)(checkSum & 0xff));

                    serialPortPro.Write(timBuf.ToString());
                    richTextBoxSendCmdShow.AppendText(timBuf.ToString());
                }
            }

            _waitHandleMain.Set();//唤醒线程
        }

        private void btnAuthItem_Click(object sender, EventArgs e)
        {
            List<string> l_tmp = new List<string>();

            if (itemTestState)
            {
                if (MessageBox.Show("正在测试，重新启动？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    qtpStop();
                else
                    return;
            }
            Button buttonTmp = (Button)sender;

            d_itemInfo.Clear();
            strFileName = Application.StartupPath + "\\data\\Result-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            if (buttonTmp.Name.CompareTo(btnCold.Name) == 0)
            {
                try
                {
                    l_tmp.Clear();
                    l_tmp.Add(richTextBoxColdTime.Text);
                    l_tmp.Add(richTextBoxColdCnt.Text);
                    l_tmp.Add(comboBoxColdType.Text);
                    d_itemInfo.Add(e_mssItem.cold, l_tmp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "数据填写错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(strFileName + "-Cold.txt"))
                {
                    FileStream fs = File.Create(strFileName + "-Cold.txt");
                    fs.Close();
                }
            }
            else if (buttonTmp.Name.CompareTo(btnWarm.Name) == 0)
            {
                try
                {
                    l_tmp.Clear();
                    l_tmp.Add(richTextBoxWarmTime.Text);
                    l_tmp.Add(richTextBoxWarmCnt.Text);
                    l_tmp.Add(comboBoxWarmType.Text);
                    d_itemInfo.Add(e_mssItem.warm, l_tmp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "数据填写错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (buttonTmp.Name.CompareTo(btnHot.Name) == 0)
            {
                try
                {
                    l_tmp.Clear();
                    l_tmp.Add(richTextBoxHotTime.Text);
                    l_tmp.Add(richTextBoxHotCnt.Text);
                    l_tmp.Add(comboBoxHotType.Text);
                    d_itemInfo.Add(e_mssItem.hot, l_tmp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "数据填写错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (buttonTmp.Name.CompareTo(btnReAcQ.Name) == 0)
            {
                try
                {
                    l_tmp.Clear();
                    l_tmp.Add(richTextBoxReAcqTime.Text);
                    l_tmp.Add(richTextBoxReAcqCnt.Text);
                    l_tmp.Add(comboBoxReAcqType.Text);
                    d_itemInfo.Add(e_mssItem.reAcq, l_tmp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "数据填写错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (buttonTmp.Name.CompareTo(btnAuthTest.Name) == 0)
            {
                try
                {
                    l_tmp.Clear();
                    l_tmp.Add(comboBoxAuthRefType.Text);
                    l_tmp.Add(comboBoxAuthTestType.Text);
                    l_tmp.Add(richTextBoxAuthCnt.Text);
                    l_tmp.Add(comboBoxAssist.Text.Substring(0, 1));
                    d_itemInfo.Add(e_mssItem.authTest, l_tmp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "数据填写错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(strFileName + "-Auth.txt"))
                {
                    FileStream fs = File.Create(strFileName + "-Auth.txt");
                    fs.Close();
                }
            }
            else if (buttonTmp.Name.CompareTo(btnErrorRate.Name) == 0)
            {
                try
                {
                    l_tmp.Clear();
                    l_tmp.Add(richTextBoxErrorRateTime.Text);
                    l_tmp.Add(richTextBoxErrorRateCnt.Text);
                    l_tmp.Add(comboBoxErrorRateType.Text);
                    l_tmp.Add(comboBoxErrorRateNum.Text);
                    l_tmp.Add(comboBoxErrorRateBranch.Text);
                    d_itemInfo.Add(e_mssItem.errRate, l_tmp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "数据填写错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (buttonTmp.Name.CompareTo(btnProcessTest.Name) == 0)
            {
                if (checkBoxCold.Checked)
                {
                    try
                    {
                        l_tmp.Clear();
                        l_tmp.Add(richTextBoxColdTime.Text);
                        l_tmp.Add(richTextBoxColdCnt.Text);
                        l_tmp.Add(comboBoxColdType.Text);
                        d_itemInfo.Add(e_mssItem.cold, l_tmp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "数据填写错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!File.Exists(strFileName + "-Cold.txt"))
                    {
                        FileStream fs = File.Create(strFileName + "-Cold.txt");
                        fs.Close();
                    }
                }
                if (checkBoxWarm.Checked)
                {
                    try
                    {
                        l_tmp.Clear();
                        l_tmp.Add(richTextBoxWarmTime.Text);
                        l_tmp.Add(richTextBoxWarmCnt.Text);
                        l_tmp.Add(comboBoxWarmType.Text);
                        d_itemInfo.Add(e_mssItem.warm, l_tmp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "数据填写错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (checkBoxHot.Checked)
                {
                    try
                    {
                        l_tmp.Clear();
                        l_tmp.Add(richTextBoxHotTime.Text);
                        l_tmp.Add(richTextBoxHotCnt.Text);
                        l_tmp.Add(comboBoxHotType.Text);
                        d_itemInfo.Add(e_mssItem.hot, l_tmp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "数据填写错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (checkBoxReAcq.Checked)
                {
                    try
                    {
                        l_tmp.Clear();
                        l_tmp.Add(richTextBoxReAcqTime.Text);
                        l_tmp.Add(richTextBoxReAcqCnt.Text);
                        l_tmp.Add(comboBoxReAcqType.Text);
                        d_itemInfo.Add(e_mssItem.reAcq, l_tmp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "数据填写错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (checkBoxErrorRate.Checked)
                {
                    try
                    {
                        l_tmp.Clear();
                        l_tmp.Add(richTextBoxErrorRateTime.Text);
                        l_tmp.Add(richTextBoxErrorRateCnt.Text);
                        l_tmp.Add(comboBoxErrorRateType.Text);
                        l_tmp.Add(comboBoxErrorRateNum.Text);
                        l_tmp.Add(comboBoxErrorRateBranch.Text);
                        d_itemInfo.Add(e_mssItem.errRate, l_tmp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "数据填写错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("异常", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!serialPortPro.IsOpen)//发送串口没打开
            {
                MessageBox.Show("测试串口没打开", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            //if (!homeTmp.serialPort0.IsOpen)//发送串口没打开

            if (d_itemInfo.Count < 1)
            {
                MessageBox.Show("请选择测试项目", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            //开始测试后禁止输入
            foreach (Control n in xtraTabControlItem.Controls)
            {
                if (n.TabIndex >= 0 && n.TabIndex <= 38)
                    n.Enabled = false;
            }

            dataSetResultExa.DataTableAcq.Clear();
            xmlPathString = Application.StartupPath + "\\xml\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";//创建xml文件

            qtpRxBuf.rd = qtpRxBuf.wr;
            itemTestState = true;//测试开始标志

            /* 初始化线程 */
            pThQtpMain = new Thread(thQtpMain)
            {
                IsBackground = true,
                Name = "QtpMain thread",
                Priority = ThreadPriority.Highest
            };
            pThQtpMain.Start();//启动测试线程
        }

        private void qtpStop()
        {
            this.Invoke((MethodInvoker)delegate { richTextBoxSendCmdShow.AppendText("测试结束！"); });
            MessageBox.Show("测试结束！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            itemTestState = false;
            d_itemInfo.Clear();

            this.Invoke((MethodInvoker)delegate
            {
                foreach (Control n in xtraTabPageRnss.Controls)
                {
                    if (n.TabIndex >= 0 && n.TabIndex <= 38)
                        n.Enabled = true;
                }
            });

            Thread.Sleep(1000);

            if (pThQtpMain != null)//关闭测试线程
                pThQtpMain.Abort();
        }

        public void v21CmdPro(byte[] data, int len)//串口收到命令后在此处解析，置标志。
        {
            int i = 0;
            int weekNum = 0;//周计数
            int weekSec = 0;//秒计数

            if (!itemTestState) return;
            if (recvTime.weekValid) return;
            if (d_itemInfo[e_mssItem.authTest][3].CompareTo("C") != 0) return;

            recvTime.weekValid = false;
            if (Encoding.Default.GetString(data, 0, 6).CompareTo("$CCTIM") == 0)
            {
                byte[] tmp = new byte[20];

                for (i = 7; i < len; i++)
                {
                    if (data[i] == 0x2c) break;
                    weekNum *= 10;
                    weekNum += (data[i] - 48);
                }

                i++;
                for (; i < len; i++)
                {
                    if (data[i] == 42 || data[i] == 13) break;
                    weekSec *= 10;
                    weekSec += (data[i] - 48);
                }
            }
            else
                return;

            if (weekNum <= 0 || weekSec <= 0) return;
            if (weekNum >= 1024 || weekSec >= 604800) return;

            recvTime.weekNum = (UInt32)weekNum;
            recvTime.seconds = weekSec;
            recvTime.weekValid = true;

            //差几毫秒时间
            this.Invoke((MethodInvoker)delegate
            {
                timerPC.Enabled = false;//接收命令超时检测关闭
                timerAuth.Enabled = false;
                timerAuth.Interval = 1000;
                timerAuth.Enabled = true;
                timerAuth.Start();
            });
            cmdSendTimer = 0;
        }

        private void pquitCmdPro(byte[] data, int len)
        {
            if (itemStatisticsFlag != 1) return;
            if (len < 20) return;

            resultFlag.trkStatus = 1;

            List<string> listData = new List<string>();
            getDataFromStr(listData, data, len);

            int svid = int.Parse(listData[2]);
            bool b_exist = true;
            foreach (int id in l_quitSvid)
            {
                if (id == svid)
                {
                    b_exist = false;
                    break;
                }
            }
            if (b_exist)
                l_quitSvid.Add(svid);

        }

        private void IntrCmdPro(byte[] data, int len)//baseband数据在此处解析。
        {
            if (len < 10) return;

            if (!itemTestState) return;

            if (data[0] != 'i' || data[1] != 'n' || data[2] != 't' || data[3] != 'r') return;

            List<string> listData = new List<string>();
            getDataFromStr(listData, data, len);

            nowIntrCnt = listData[0];

            if (publicSvidFlag)//民码统计
                intrSvidRef = svidRef;

            if (!publicSvidFlag && svidComp == intrSvidRef && !intrAcqCmd)
            {
                resultFlag.svidCmp = 1;
                intrAcqCmd = true;
                serialPortPro.Write("$XLAUTHACQ,FFFFFFFFFFFFFFFF\r\n");
            }

            if (itemStatisticsFlag != 1) return;
            intrPos++;

            if (intrPos < 4 || intrPos > 116) return;

            if (varMax.cn0Corr - varMin.cn0Corr > CResultLimitDef.THIS_EPOCH_CN0CORR_DIFF)
                resultFlag.cn0Corr++;
            if (varMax.pldCorr - varMin.pldCorr > CResultLimitDef.THIS_EPOCH_PLDCORR_DIFF)
                resultFlag.pldCorr++;
            if (varMax.cn0Data - varMin.cn0Data > CResultLimitDef.THIS_EPOCH_CN0DATA_DIFF)
                resultFlag.cn0Data++;
            if (varMax.pldData - varMin.pldData > CResultLimitDef.THIS_EPOCH_PLDDATA_DIFF)
                resultFlag.pldData++;
        }

        private void bbmCmdPro(byte[] data, int len)//baseband数据在此处解析。
        {
            int svid = 0; //1开始
            UInt64 bitPos = 1;

            if (!itemTestState) return;

            if (len < 100) return;
            if (data[0] != '$' || data[1] != 'C' || data[2] != 'H' || data[3] != ',') return;

            List<string> listData = new List<string>();
            getDataFromStr(listData, data, len);

            if (publicSvidFlag && listData[1].CompareTo(d_itemInfo[e_mssItem.authTest][0]) == 0)//民码统计
            {
                svid = int.Parse(listData[2]);
                if (svid > 0 && svid < 65)
                    svidRef |= (bitPos << (svid - 1));
            }

            if (listData[1].CompareTo(d_itemInfo[e_mssItem.authTest][1]) != 0) return;//军码统计

            publicSvidFlag = false;//停止民码统计
            svid = int.Parse(listData[2]);
            if (svid > 0 && svid < 65)  svidComp |= (bitPos << (svid - 1));

            if (itemStatisticsFlag != 1) return;

            if (listData[3] != "12") resultFlag.trkStatus = 2;


            if (cn0MaxMin[0, svid - 1] < int.Parse(listData[4]))
                cn0MaxMin[0, svid - 1] = int.Parse(listData[4]);
            if (cn0MaxMin[1, svid - 1] > int.Parse(listData[4]))
                cn0MaxMin[1, svid - 1] = int.Parse(listData[4]);

            if (resultFlag.pld > int.Parse(listData[5]))
                resultFlag.pld = int.Parse(listData[5]);

            if (varMin.cn0Corr > int.Parse(listData[17]))
                varMin.cn0Corr = int.Parse(listData[17]);
            if (varMin.pldCorr > int.Parse(listData[18]))
                varMin.pldCorr = int.Parse(listData[18]);
            if (varMin.cn0Data > int.Parse(listData[19]))
                varMin.cn0Data = int.Parse(listData[19]);
            if (varMin.pldData > int.Parse(listData[20]))
                varMin.pldData = int.Parse(listData[20]);

            if (varMax.cn0Corr < int.Parse(listData[17]))
                varMax.cn0Corr = int.Parse(listData[17]);
            if (varMax.pldCorr < int.Parse(listData[18]))
                varMax.pldCorr = int.Parse(listData[18]);
            if (varMax.cn0Data < int.Parse(listData[19]))
                varMax.cn0Data = int.Parse(listData[19]);
            if (varMax.pldData < int.Parse(listData[20]))
                varMax.pldData = int.Parse(listData[20]);

            if (listData[3] != "12") return;
            if (intrPos >= 120) return;

            foreach (int id in l_quitSvid)
                if (id == svid) return;//本轮测试只要这个卫星退出过就不在使用

            double dMathTmp = 0.0;

            if (int.TryParse(listData[8], out int epochCount) && double.TryParse(listData[13], out double codeCount) && double.TryParse(listData[14], out double codePhase))
            {
                if (svid <= 5)//GEO
                {
                    dMathTmp = (double)(epochCount % CEpochCountDef.BD_GEO) * 0.001 + (codeCount + codePhase / Math.Pow(2.0, 32.0)) / (double)CCodeRateDef.BDS_B3Q_CODE_FREQ;

                    if (intrPos > 0 && arryPsrij[intrPos - 1, svid - 1] != 0)
                    {
                        if (dMathTmp - arryPsrij[intrPos - 1, svid - 1] > 0.001)
                            dMathTmp -= CEpochCountDef.BD_GEO * 0.001;
                        else if (dMathTmp - arryPsrij[intrPos - 1, svid - 1] < -0.001)
                            dMathTmp += CEpochCountDef.BD_GEO * 0.001;
                    }
                }
                else
                {
                    dMathTmp = (double)(epochCount % CEpochCountDef.BD_IGSO_MEO) * 0.001 + (codeCount + codePhase / Math.Pow(2.0, 32.0)) / (double)CCodeRateDef.BDS_B3Q_CODE_FREQ;

                    if (intrPos > 0 && arryPsrij[intrPos - 1, svid - 1] != 0)
                    {
                        if (dMathTmp - arryPsrij[intrPos - 1, svid - 1] > 0.019)
                            dMathTmp -= CEpochCountDef.BD_IGSO_MEO * 0.001;
                        else if (dMathTmp - arryPsrij[intrPos - 1, svid - 1] < -0.019)
                            dMathTmp += CEpochCountDef.BD_IGSO_MEO * 0.001;
                    }
                }

                arryPsrij[intrPos, svid - 1] = dMathTmp;
            }

            if (double.TryParse(listData[10], out double carrCount) && double.TryParse(listData[11], out double carrPhase))
            {
                dMathTmp = carrCount + carrPhase / Math.Pow(2.0, 32.0);

                if (intrPos > 0 && arryCarrij[intrPos - 1, svid - 1] != 0)
                {
                    if (dMathTmp - arryCarrij[intrPos - 1, svid - 1] < 0)
                        dMathTmp += d_carryPeriod[d_itemInfo[e_mssItem.authTest][1]];
                }

                arryCarrij[intrPos, svid - 1] = dMathTmp;
            }
        }

        private void acqCmdPro(byte[] data, int len)//baseband数据在此处解析。
        {
            //if (itemStatisticsFlag != 1) return;
            if (len < 18) return;

            if (data[0] != '$' || data[1] != 'A' || data[2] != 'U' || data[3] != 'T') return;

            List<string> listData = new List<string>();
            getDataFromStr(listData, data, len);

            int iSvidTmp = int.Parse(listData[3]);
            if (resultFlag.acqStatus < iSvidTmp)//统计最大捕获次数
                resultFlag.acqStatus = iSvidTmp;

            double dTimeTmp = double.Parse(listData[4]);
            if (resultFlag.firstTime > dTimeTmp)//统计最小捕获时间
                resultFlag.firstTime = dTimeTmp;
        }

        private void ectCmdPro(byte[] data, int len)
        {
            bool errorFlag = false;
            string type = "";
            string branch = "";

            if (len < 12) return;

            if (data[0] != '$' || data[1] != 'C' || data[2] != 'C' || data[3] != 'E') return;

            List<string> l_data = new List<string>();
            getDataFromStr(l_data, data, len);

            if (int.TryParse(l_data[1], out int svid) == false) return;/*命令漏数是否计算在总数中？*/
            type = l_data[2];
            if (int.TryParse(l_data[3], out int beam) == false) return;
            branch = l_data[4];

            /*校验电文*/
            uint[] uint_data;
            if (type == "S")/*北斗二代S1I频点*/
            {
                uint_data = new uint[16];/*实例化16个*/
                l_data[5] += "000";
                for (int i = 0; i < 61 + 3; i += 4)
                {
                    uint_data[i / 4] = Convert.ToUInt32(l_data[5].Substring(i, 4), 16);
                }

                /*CRC校验*/
                C_VerifyGroup crc = new C_VerifyGroup();
                uint crcVal = crc.getCrc16Check(uint_data, 1, 243);/*计算221个bit的CRC校验*/
                uint crcTmp = ((uint_data[6] & 0x3) << 14) | (uint_data[7] >> 18 & 0x3fff);
                if (crcVal != crcTmp) errorFlag = true;

		        /*检测卷尾是否为0*/
                uint tail = (uint_data[7] >> 12) & 0x3f;
                if (tail != 0) errorFlag = true;
            
            }

            d_ectErrorRate["totol"] += 1;
            if (errorFlag)
                d_ectErrorRate["error"] += 1;
        
        }

        private void thQtpUartRx()
        {
            while (true)
            {
                _waitHandleRx.WaitOne();
                uartRxPro();
            }
        }

        private void uartRxPro()
        {
            int wr = qtpRxBuf.wr;
            int dataLen = 0;

            if (wr != printCount)
            {
                if (printCount < wr)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        richTextBoxPro.AppendText(Encoding.ASCII.GetString(qtpRxBuf.buf, printCount, wr - printCount));
                    }));

                    if (saveFileFlag)
                    {
                        fileTestResult.Write(qtpRxBuf.buf, printCount, wr - printCount);
                        fileTestResult.Flush();
                    }
                }
                else if (printCount > wr)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        richTextBoxPro.AppendText(Encoding.ASCII.GetString(qtpRxBuf.buf, printCount, uartVar.MSG_MAX_LEN - printCount));
                        richTextBoxPro.AppendText(Encoding.ASCII.GetString(qtpRxBuf.buf, 0, wr));
                    }));

                    if (saveFileFlag)
                    {
                        fileTestResult.Write(qtpRxBuf.buf, printCount, uartVar.MSG_MAX_LEN - printCount);
                        fileTestResult.Write(qtpRxBuf.buf, 0, wr);
                        fileTestResult.Flush();
                    }
                }
                printCount = wr;
            }

            if (wr == qtpRxBuf.rd) return;

            while (true)
            {
                if (wr >= qtpRxBuf.rd) dataLen = wr - qtpRxBuf.rd;
                else dataLen = uartVar.MSG_MAX_LEN - qtpRxBuf.rd + wr;

                if (cmdHead == 0)
                {
                    if (dataLen < 6) break;

                    //解析字头
                    if ((qtpRxBuf.buf[qtpRxBuf.rd] == '$') &&
                            (qtpRxBuf.buf[(qtpRxBuf.rd + 1) % uartVar.MSG_MAX_LEN] == 'C') &&
                            (qtpRxBuf.buf[(qtpRxBuf.rd + 2) % uartVar.MSG_MAX_LEN] == 'H') &&
                            (qtpRxBuf.buf[(qtpRxBuf.rd + 3) % uartVar.MSG_MAX_LEN] == ','))
                    {
                        cmdHead = e_strHeadId.Bbm;
                    }
                    else if ((qtpRxBuf.buf[qtpRxBuf.rd] == '$') &&
                            (qtpRxBuf.buf[(qtpRxBuf.rd + 1) % uartVar.MSG_MAX_LEN] == 'A') &&
                            (qtpRxBuf.buf[(qtpRxBuf.rd + 2) % uartVar.MSG_MAX_LEN] == 'U') &&
                            (qtpRxBuf.buf[(qtpRxBuf.rd + 3) % uartVar.MSG_MAX_LEN] == 'T') &&
                            (qtpRxBuf.buf[(qtpRxBuf.rd + 4) % uartVar.MSG_MAX_LEN] == 'H'))
                    {
                        cmdHead = e_strHeadId.Acq;
                    }
                    else if ((qtpRxBuf.buf[qtpRxBuf.rd] == 'i') &&
                        (qtpRxBuf.buf[(qtpRxBuf.rd + 1) % uartVar.MSG_MAX_LEN] == 'n') &&
                        (qtpRxBuf.buf[(qtpRxBuf.rd + 2) % uartVar.MSG_MAX_LEN] == 't') &&
                        (qtpRxBuf.buf[(qtpRxBuf.rd + 3) % uartVar.MSG_MAX_LEN] == 'r'))
                    {
                        cmdHead = e_strHeadId.Intr;
                    }
                    else if ((qtpRxBuf.buf[qtpRxBuf.rd] == '$') &&
                    (qtpRxBuf.buf[(qtpRxBuf.rd + 1) % uartVar.MSG_MAX_LEN] == 'P') &&
                    (qtpRxBuf.buf[(qtpRxBuf.rd + 2) % uartVar.MSG_MAX_LEN] == 'Q') &&
                    (qtpRxBuf.buf[(qtpRxBuf.rd + 3) % uartVar.MSG_MAX_LEN] == 'U') &&
                    (qtpRxBuf.buf[(qtpRxBuf.rd + 4) % uartVar.MSG_MAX_LEN] == 'I'))
                    {
                        cmdHead = e_strHeadId.Pquit;
                    }
                    else if ((qtpRxBuf.buf[qtpRxBuf.rd] == '$') &&
                    (qtpRxBuf.buf[(qtpRxBuf.rd + 1) % uartVar.MSG_MAX_LEN] == 'C') &&
                    (qtpRxBuf.buf[(qtpRxBuf.rd + 2) % uartVar.MSG_MAX_LEN] == 'C') &&
                    (qtpRxBuf.buf[(qtpRxBuf.rd + 3) % uartVar.MSG_MAX_LEN] == 'E') &&
                    (qtpRxBuf.buf[(qtpRxBuf.rd + 4) % uartVar.MSG_MAX_LEN] == 'C') &&
                    (qtpRxBuf.buf[(qtpRxBuf.rd + 4) % uartVar.MSG_MAX_LEN] == 'T'))
                    {
                        cmdHead = e_strHeadId.Ect;
                    }
                    else
                    {
                        qtpRxBuf.rd++;
                        if (qtpRxBuf.rd >= uartVar.MSG_MAX_LEN)
                            qtpRxBuf.rd -= uartVar.MSG_MAX_LEN;
                        continue;
                    }

                    cmdMsgPos = 0;
                    Array.Clear(cmdMsgBuf, 0, cmdMsgBuf.Length);
                }//if (cmdHead == 0)
                else
                {
                    if (dataLen - cmdMsgPos < 2) break;

                    //命令长度是否超长
                    if (cmdMsgPos > 300)
                    {
                        qtpRxBuf.rd += cmdMsgPos;
                        if (qtpRxBuf.rd >= uartVar.MSG_MAX_LEN)
                            qtpRxBuf.rd -= uartVar.MSG_MAX_LEN;
                        cmdMsgPos = 0;
                        cmdHead = 0;
                        continue;
                    }

                    //解析字尾
                    cmdMsgBuf[cmdMsgPos] = qtpRxBuf.buf[(qtpRxBuf.rd + cmdMsgPos) % uartVar.MSG_MAX_LEN];
                    //回车换行字尾
                    if ((cmdMsgBuf[cmdMsgPos] == '\r') && (qtpRxBuf.buf[(qtpRxBuf.rd + cmdMsgPos + 1) % uartVar.MSG_MAX_LEN] == '\n'))
                    {
                        cmdMsgBuf[cmdMsgPos + 1] = qtpRxBuf.buf[(qtpRxBuf.rd + cmdMsgPos + 1) % uartVar.MSG_MAX_LEN];
                        cmdMsgPos += 2;

                        switch (cmdHead)
                        {
                            case e_strHeadId.Bbm:
                                bbmCmdPro(cmdMsgBuf, cmdMsgPos);
                                break;
                            case e_strHeadId.Acq:
                                acqCmdPro(cmdMsgBuf, cmdMsgPos);
                                break;
                            case e_strHeadId.Intr:
                                IntrCmdPro(cmdMsgBuf, cmdMsgPos);
                                break;
                            case e_strHeadId.Pquit:
                                pquitCmdPro(cmdMsgBuf, cmdMsgPos);
                                break;
                            case e_strHeadId.Ect:
                                ectCmdPro(cmdMsgBuf, cmdMsgPos);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        cmdMsgPos++;
                        continue;
                    }

                    qtpRxBuf.rd += cmdMsgPos;
                    if (qtpRxBuf.rd >= uartVar.MSG_MAX_LEN)
                        qtpRxBuf.rd -= uartVar.MSG_MAX_LEN;
                    cmdHead = 0;
                    cmdMsgPos = 0;
                }//else
            }//while(true)
        }

        //串口接收事件
        private void serialPortPro_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int wr = qtpRxBuf.wr;

            if (is_serial_closing)
            {
                is_serial_listening = false; //准备关闭串口时，reset串口侦听标记
                return;
            }
            try
            {
                is_serial_listening = true;

                if (serialPortPro.IsOpen)
                {
                    int rxLen = serialPortPro.BytesToRead;

                    if (rxLen <= uartVar.MSG_MAX_LEN - wr)
                    {
                        serialPortPro.Read(qtpRxBuf.buf, wr, rxLen);
                    }
                    else
                    {
                        serialPortPro.Read(qtpRxBuf.buf, wr, uartVar.MSG_MAX_LEN - wr);
                        serialPortPro.Read(qtpRxBuf.buf, 0, rxLen - (uartVar.MSG_MAX_LEN - wr));
                    }
                    qtpRxBuf.wr = (qtpRxBuf.wr + rxLen) % uartVar.MSG_MAX_LEN;
                    _waitHandleRx.Set();
                }
            }
            finally
            {
                is_serial_listening = false;//串口调用完毕后，reset串口侦听标记
            }
        }

        private void AfterPro()
        {
            FileStream fs = new FileStream(".\after.txt", FileMode.Open, FileAccess.Read);

            while (true)
            {
                if (cmdSendTimer >= 250) break;
                long rxLen = fs.Length - fs.Position;
                int wr = qtpRxBuf.wr;
                if (rxLen > 1024) rxLen = 1024;

                if (rxLen <= uartVar.MSG_MAX_LEN - wr)
                {
                    fs.Read(qtpRxBuf.buf, wr, (int)rxLen);
                }
                else
                {
                    fs.Read(qtpRxBuf.buf, wr, uartVar.MSG_MAX_LEN - wr);
                    fs.Read(qtpRxBuf.buf, 0, (int)rxLen - (uartVar.MSG_MAX_LEN - wr));
                }
                qtpRxBuf.wr = (qtpRxBuf.wr + (int)rxLen) % uartVar.MSG_MAX_LEN;
                fs.Position += rxLen;

                if (fs.Length == fs.Position) break;
            }
        }

        private void limitLine(RichTextBox box, int maxLength)
        {
            if (box.Lines.Length > maxLength)
            {
                int moreLines = box.Lines.Length - maxLength;
                string[] lines = box.Lines;
                Array.Copy(lines, moreLines, lines, 0, maxLength);
                Array.Resize(ref lines, maxLength);
                box.Lines = lines;
            }
        }

        //光标总在最新行
        private void richTextBoxPro_TextChanged(object sender, EventArgs e)
        {
            //limitLine(richTextBoxPro, 5000);
            if (richTextBoxPro.Lines.Length > 10000)
                richTextBoxPro.Clear();
            else
            {
                //将光标位置设置到当前内容的末尾
                richTextBoxPro.SelectionStart = richTextBoxPro.Text.Length;
                //滚动到光标位置
                richTextBoxPro.ScrollToCaret();
            }
        }

        private void richTextBoxSendCmdShow_TextChanged(object sender, EventArgs e)
        {
            limitLine(richTextBoxSendCmdShow, 5000);
            //将光标位置设置到当前内容的末尾
            richTextBoxSendCmdShow.SelectionStart = richTextBoxSendCmdShow.Text.Length;
            //滚动到光标位置
            richTextBoxSendCmdShow.ScrollToCaret();
        }

        //发送命令
        private void btnCmdSend_Click(object sender, EventArgs e)
        {
            if (richTextBoxV21Send.Text == null) return;

            if (serialPortPro.IsOpen)
                serialPortPro.Write(richTextBoxV21Send.Text.ToString() + "\r\n");
            else
                richTextBoxSendCmdShow.AppendText("串口未打开！");
        }

        //命令选择入口
        private void comboBoxCmdAccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBoxTmp = (ComboBox)sender;

            if (comboBoxTmp.Name.CompareTo(comboBoxCmd.Name) == 0)
            {
                //关闭所有ComBo控件
                foreach (Control n in splitContainerControl5.Panel2.Controls)
                {
                    if (n.TabIndex > 70 && n.TabIndex < 84)
                        n.Enabled = false;
                }

                switch ((e_v21Cmd)comboBoxCmd.SelectedIndex)
                {
                    case e_v21Cmd.RIS:
                        d_v21CmdGroup["head"] = "$CCRIS";
                        break;
                    case e_v21Cmd.MSS:
                        comboBoxRmoEn.SelectedIndex = 0;
                        comboBoxMssMode.SelectedIndex = 0;
                        comboBoxMssItem.SelectedIndex = 2;
                        comboBoxMssFreq1.SelectedIndex = 2;
                        comboBoxMssMode.Enabled = true;
                        comboBoxMssItem.Enabled = true;
                        comboBoxMssFreq1.Enabled = true;
                        comboBoxMssFreq2.Enabled = true;
                        comboBoxMssFreq3.Enabled = true;
                        comboBoxMssBranch1.Enabled = true;

                        d_v21CmdGroup["head"] = "$CCMSS";
                        break;
                    case e_v21Cmd.RMO:
                        comboBoxRmoItem.SelectedIndex = 0;
                        comboBoxRmoEn.SelectedIndex = 1;
                        comboBoxMeasFreq.SelectedIndex = 0;

                        comboBoxRmoItem.Enabled = true;
                        comboBoxRmoEn.Enabled = true;
                        comboBoxMeasFreq.Enabled = true;
                        d_v21CmdGroup["head"] = "$CCRMO";
                        break;
                    case e_v21Cmd.PRD:
                        break;
                    case e_v21Cmd.ECS:
                        break;
                    case e_v21Cmd.CPM:
                        break;
                    case e_v21Cmd.SPM:
                        break;
                    case e_v21Cmd.STM:
                        break;
                    default:
                        break;

                }
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxType.Name) == 0)
            {
                d_v21CmdGroup["type"] = comboBoxType.SelectedItem.ToString();
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxBranch.Name) == 0)
            {
                d_v21CmdGroup["branch"] = comboBoxBranch.SelectedItem.ToString();
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxRmoItem.Name) == 0)
            {
                d_v21CmdGroup["rmoItem"] = comboBoxRmoItem.SelectedItem.ToString().Substring(0, 3);
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxRmoEn.Name) == 0)
            {
                d_v21CmdGroup["rmoEn"] = (comboBoxRmoEn.SelectedIndex + 1).ToString();
                if (d_v21CmdGroup["rmoEn"] == "3" || d_v21CmdGroup["rmoEn"] == "4")
                    comboBoxRmoItem.Enabled = false;
                else
                    comboBoxRmoItem.Enabled = true;
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMeasFreq.Name) == 0)
            {
                d_v21CmdGroup["rmoFreq"] = comboBoxMeasFreq.SelectedItem.ToString();
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMssMode.Name) == 0)
            {
                if (comboBoxMssMode.SelectedIndex == 1)
                    d_v21CmdGroup["mssMode"] = "Z";
                else
                    d_v21CmdGroup["mssMode"] = "C";
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMssItem.Name) == 0)
            {
                d_v21CmdGroup["mssItem"] = comboBoxMssItem.SelectedIndex.ToString();
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMssFreq1.Name) == 0)
            {
                d_v21CmdGroup["mssFreq1"] = comboBoxMssFreq1.SelectedItem.ToString();
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMssFreq2.Name) == 0)
            {
                d_v21CmdGroup["mssFreq2"] = comboBoxMssFreq2.SelectedItem.ToString();
                comboBoxMssBranch2.Enabled = true;
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMssFreq3.Name) == 0)
            {
                d_v21CmdGroup["mssFreq3"] = comboBoxMssFreq3.SelectedItem.ToString();
                comboBoxMssBranch3.Enabled = true;
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMssBranch1.Name) == 0)
            {
                d_v21CmdGroup["mssBranch1"] = comboBoxMssBranch1.SelectedItem.ToString();
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMssBranch2.Name) == 0)
            {
                d_v21CmdGroup["mssBranch2"] = comboBoxMssBranch2.SelectedItem.ToString();
            }
            else if (comboBoxTmp.Name.CompareTo(comboBoxMssBranch3.Name) == 0)
            {
                d_v21CmdGroup["mssBranch3"] = comboBoxMssBranch3.SelectedItem.ToString();
            }
            else
                return;

            StringBuilder strCmdBuf = new StringBuilder();
            switch ((e_v21Cmd)comboBoxCmd.SelectedIndex)
            {
                case e_v21Cmd.RIS:
                    strCmdBuf.AppendFormat("{0},", d_v21CmdGroup["head"]);
                    break;
                case e_v21Cmd.MSS:
                    strCmdBuf.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8}", d_v21CmdGroup["head"], d_v21CmdGroup["mssMode"], d_v21CmdGroup["mssItem"],
                        d_v21CmdGroup["mssFreq1"], d_v21CmdGroup["mssBranch1"], d_v21CmdGroup["mssFreq2"], d_v21CmdGroup["mssBranch2"], d_v21CmdGroup["mssFreq3"], d_v21CmdGroup["mssBranch3"]);
                    break;
                case e_v21Cmd.RMO:
                    if (d_v21CmdGroup["rmoEn"] == "3" || d_v21CmdGroup["rmoEn"] == "4")
                        strCmdBuf.AppendFormat("{0},,{1},,", d_v21CmdGroup["head"], d_v21CmdGroup["rmoEn"]);
                    else
                        strCmdBuf.AppendFormat("{0},{1},{2},{3}", d_v21CmdGroup["head"], d_v21CmdGroup["rmoItem"], d_v21CmdGroup["rmoEn"], d_v21CmdGroup["rmoFreq"]);
                    break;
                case e_v21Cmd.PRD:
                    break;
                case e_v21Cmd.ECS:
                    break;
                case e_v21Cmd.CPM:
                    break;
                case e_v21Cmd.SPM:
                    break;
                case e_v21Cmd.STM:
                    break;
                default:
                    break;

            }

            int checkSum = 0;
            byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(strCmdBuf.ToString());
            for (int i = 1; i < byteArray.Length; i++)//添加校验
                checkSum ^= byteArray[i];
            strCmdBuf.AppendFormat("*{0:X2}", (byte)(checkSum & 0xff));

            richTextBoxV21Send.Text = strCmdBuf.ToString();
        }

        //关闭窗体
        private void FormProcess_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (itemTestState)
            {
                DialogResult msgBoxBtn = System.Windows.Forms.DialogResult.OK;
                msgBoxBtn = MessageBox.Show("测试进行中是否等待", "流程测试", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (msgBoxBtn == System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = true;
                    homeTmp.qtpCloseCancel = 1;
                    return;
                }
                else
                    qtpStop();
            }

            timerPC.Enabled = false;
            timerAuth.Enabled = false;

            if (serialPortPro.IsOpen) serialClose();

            if (fMearResult != null)
            {
                fMearResult.Close();
            }

            if (fileTestResult != null) fileTestResult.Dispose();
            if (pThQtpUartRx != null) pThQtpUartRx.Abort();
            if (pThQtpMain != null) pThQtpMain.Abort();

            homeTmp.qtpCloseCancel = 2;

            this.Dispose();
        }

        //串口关闭函数
        private void serialClose()
        {
            is_serial_closing = true;/* 关闭窗口时，置位is_serial_closing标记 */
            while (is_serial_listening) Application.DoEvents();

            serialPortPro.DiscardInBuffer();/* 丢弃缓冲区数据 */
            serialPortPro.Dispose();

            is_serial_closing = false;
        }

        //截取字符串
        private void getDataFromStr(List<string> listData, byte[] bData, int len)
        {
            int startPos = 0;

            if (bData.Length < 1) return;
            if (len < 1) return;

            for (int i = 0; i < len; i++)
            {
                if (bData[i] != ',' && i != (len - 1) && bData[i] != '\r')
                {
                    if (bData[i] == ' ' || bData[i] == '=') startPos = i + 1;
                    continue;
                }
                else
                {
                    if (startPos == i)
                    {
                        listData.Add("-1");//若空值赋值-1，此处赋值可自行定义
                        startPos = i + 1;
                        if (i == len - 1)//若最后一个为逗号，需在加一个空值，即添加-1代表空
                        {
                            listData.Add("-1");
                        }
                    }
                    else
                    {
                        string s;
                        if (i == len - 1)//最后一个数时提取字符串
                        {
                            s = System.Text.Encoding.ASCII.GetString(bData.Skip(startPos).Take(i - startPos + 1).ToArray());
                        }
                        else
                        {
                            s = System.Text.Encoding.ASCII.GetString(bData.Skip(startPos).Take(i - startPos).ToArray());
                        }
                        startPos = i + 1;
                        listData.Add(s);
                    }

                    if (bData[i] == '\r') break;
                }
            }
        }

        //生成实时结果报表
        private void btnTimeResult_Click(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath + "//xml";

            if (Directory.Exists(strPath))
            {
                DirectoryInfo root = new DirectoryInfo(strPath);
                FileInfo[] files = root.GetFiles();
            }

            fMearResult.WindowState = FormWindowState.Maximized;

            fMearResult.Show();
        }

        //清输出屏幕
        private void btnClear_Click(object sender, EventArgs e)
        {
            richTextBoxPro.Clear();
        }

        private double psrThreeSub(double[,] matrix, int row, int col)
        {
            int m = 0;
            int a = 0;
            int colRef = 0;

            row = (row / 4) * 4;
            a = (row / 4) - 2;//舍弃前后4个

            for (int j = 0; j < col; j++)//验证数据
            {
                for (int i = 4; i < row - 4; i++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[3, j] = 0;//数据不可用
                        break;//当前列不使用
                    }
                }
                if (matrix[3, j] != 0)
                {
                    m++;
                    if (m == 1)//选出第一列可用数据，其他列减去此列
                    {
                        colRef = j;
                        matrix[3, colRef] = 0;
                    }
                }
            }

            if (m < 8) return 999.0;

            for (int j = colRef; j < col; j++)//同一历元相减
            {
                if (matrix[3, j] == 0) continue;
                for (int i = 4; i < row - 4; i++)//开头结尾4个不用
                {
                    matrix[i, j] -= matrix[i, colRef];
                }
            }

            double acc = 0.0;
            for (int j = colRef; j < col; j++)//三差
            {
                if (matrix[3, j] == 0) continue;

                for (int i = 4; i < row - 4; i += 4)//开头结尾4个不用
                {
                    matrix[i + 3, j] = matrix[i + 3, j] - matrix[i + 2, j];
                    matrix[i + 2, j] = matrix[i + 2, j] - matrix[i + 1, j];
                    matrix[i + 1, j] = matrix[i + 1, j] - matrix[i, j];

                    matrix[i + 3, j] = matrix[i + 3, j] - matrix[i + 2, j];
                    matrix[i + 2, j] = matrix[i + 2, j] - matrix[i + 1, j];

                    matrix[i + 3, j] = matrix[i + 3, j] - matrix[i + 2, j];

                    acc += (matrix[i + 3, j] * matrix[i + 3, j]);
                }
            }

            acc = Math.Sqrt((acc / (double)(40 * (m - 1) * a)));//计算精度

            return acc;
        }

        private double carryThreeSub(double[,] matrix, int row, int col)
        {
            int m = 0;
            int a = 0;
            int colRef = 0;

            row = (row / 4) * 4;
            a = (row / 4) - 2;//舍弃前后4个

            for (int j = 0; j < col; j++)//验证数据
            {
                for (int i = 4; i < row - 4; i++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[3, j] = 0;//数据不可用
                        break;//当前列不使用
                    }
                }
                if (matrix[3, j] != 0)
                {
                    m++;
                    if (m == 1)//选出第一列可用数据，其他列减去此列
                    {
                        colRef = j;
                        matrix[3, colRef] = 0;
                    }
                }
            }

            if (m < 8) return 999.0;

            for (int j = colRef; j < col; j++)//同一历元相减
            {
                if (matrix[3, j] == 0) continue;
                for (int i = 4; i < row - 4; i++)//开头结尾4个不用
                {
                    matrix[i, j] -= matrix[i, colRef];
                }
            }

            double acc = 0.0;

            for (int j = colRef; j < col; j++)//三差
            {
                if (matrix[3, j] == 0) continue;

                for (int i = 4; i < row - 4; i += 4)//开头结尾4个不用
                {
                    matrix[i + 3, j] = matrix[i + 3, j] - matrix[i + 2, j];
                    matrix[i + 2, j] = matrix[i + 2, j] - matrix[i + 1, j];
                    matrix[i + 1, j] = matrix[i + 1, j] - matrix[i, j];

                    matrix[i + 3, j] = matrix[i + 3, j] - matrix[i + 2, j];
                    matrix[i + 2, j] = matrix[i + 2, j] - matrix[i + 1, j];

                    matrix[i + 3, j] = matrix[i + 3, j] - matrix[i + 2, j];

                    acc += (matrix[i + 3, j] * matrix[i + 3, j]);
                }
            }

            acc = Math.Sqrt((acc / (double)(40 * (m - 1) * a)));//计算精度

            return acc;
        }

        private void recordInit()
        {
            //初始化统计变量。
            varMin.cn0Corr = 9999;
            varMin.pldCorr = 9999;
            varMin.cn0Data = 9999;
            varMin.pldData = 9999;

            varMax.cn0Corr = 0;
            varMax.pldCorr = 0;
            varMax.cn0Data = 0;
            varMax.pldData = 0;

            svidRef = 0;
            svidComp = 0;

            for (int i = 0; i < 64; i++)
            {
                cn0MaxMin[0, i] = 0;
                cn0MaxMin[1, i] = 9999;
            }
            Array.Clear(arryPsrij, 0, arryPsrij.Length);
            Array.Clear(arryCarrij, 0, arryCarrij.Length);

            resultFlag.acqStatus = 0;
            resultFlag.firstTime = 9999.0;
            resultFlag.svidCmp = 0;
            resultFlag.trkStatus = 0;
            resultFlag.pld = 9999;
            resultFlag.cn0Corr = 0;
            resultFlag.pldCorr = 0;
            resultFlag.cn0Data = 0;
            resultFlag.pldData = 0;
            resultFlag.psrAcc = 0;
            resultFlag.carrAcc = 0;

            l_quitSvid.Clear();

            intrSvidRef = 0;
            publicSvidFlag = true;
            intrAcqCmd = false;

            cmdSendTimer = 0;
            intrPos = 0;
            itemStatisticsFlag = 0;
        }

        private void generateResults()
        {
            DataRow drAddTmp = dataSetResultExa.DataTableAcq.NewRow();//添加测试结果

            drAddTmp["name"] = d_itemInfo[e_mssItem.authTest][1];
            drAddTmp["order"] = itemNowTestCnt_g;
            drAddTmp["result"] = "合格";

            if (resultFlag.acqStatus > CResultLimitDef.ACQ_COUNT_MAX)
            {
                drAddTmp["acqStatus"] = "异常";
                drAddTmp["result"] = "不合格";
            }
            else
                drAddTmp["acqStatus"] = "正常";

            if (resultFlag.firstTime > 0 && resultFlag.firstTime < 9999)
                drAddTmp["firstTime"] = resultFlag.firstTime;
            else
                drAddTmp["firstTime"] = "无";

            if (resultFlag.svidCmp == 1)//每次测试完才能比较
                drAddTmp["svidCmp"] = "相同";
            else
            {
                drAddTmp["svidCmp"] = "异常";
                drAddTmp["result"] = "不合格";
            }

            if (resultFlag.trkStatus != 0)
            {
                drAddTmp["trkStatus"] = resultFlag.trkStatus.ToString();
                drAddTmp["result"] = "不合格";
            }
            else
                drAddTmp["trkStatus"] = "正常";


            drAddTmp["cn0"] = "正常";
            for (int i = 0; i < 64; i++)
            {
                if (cn0MaxMin[0, i] - cn0MaxMin[1, i] > CResultLimitDef.THIS_EPOCH_CN0_DIFF)
                {
                    drAddTmp["cn0"] = "异常";
                    drAddTmp["result"] = "不合格";
                    break;
                }     
            }

            if (resultFlag.pld < CResultLimitDef.THIS_EPOCH_PLD_DIFF)
            {
                drAddTmp["pld"] = "异常";
                drAddTmp["result"] = "不合格";
            }
            else
                drAddTmp["pld"] = "正常";

            if (resultFlag.cn0Corr > 0)
            {
                drAddTmp["cn0Corr"] = "异常";
                drAddTmp["result"] = "不合格";
            }
            else
                drAddTmp["cn0Corr"] = "正常";

            if (resultFlag.pldCorr > 0)
            {
                drAddTmp["pldCorr"] = "异常";
                drAddTmp["result"] = "不合格";
            }
            else
                drAddTmp["pldCorr"] = "正常";

            if (resultFlag.cn0Data > 0)
            {
                drAddTmp["cn0Data"] = "异常";
                drAddTmp["result"] = "不合格";
            }
            else
                drAddTmp["cn0Data"] = "正常";

            if (resultFlag.pldData > 0)
            {
                drAddTmp["pldData"] = "异常";
                drAddTmp["result"] = "不合格";
            }
            else
                drAddTmp["pldData"] = "正常";

            double accPsr = 0.0;

            accPsr = psrThreeSub(arryPsrij, 120, 64);
            if (accPsr == 999.0)
            {
                drAddTmp["psrAcc"] = "异常";
                drAddTmp["result"] = "不合格";
            }
            else
            {
                accPsr *= WGS_LIGHT_SPEED;
                drAddTmp["psrAcc"] = Math.Round(accPsr, 4).ToString();
                //drAddTmp["psrAcc"] = "正常";
            }

            double accCarry = 0.0;

            accCarry = carryThreeSub(arryCarrij, 120, 64);
            if (accCarry == 999.0)
            {
                drAddTmp["carrAcc"] = "异常";
                drAddTmp["result"] = "不合格";
            }
            else
            {
                drAddTmp["carrAcc"] = Math.Round(accCarry, 4).ToString();
                //drAddTmp["carrAcc"] = "正常";
            }

            dataSetResultExa.DataTableAcq.Rows.Add(drAddTmp);//添加数据表行
            dataSetResultExa.DataTableAcq.WriteXml(xmlPathString);//保存到XML
        }

        private void writeFile(FileStream fd, string str)
        {
            if (fd == null || str == null) return;
            fd.Write(System.Text.Encoding.ASCII.GetBytes(str), 0, str.Length);
        }

        private void thQtpMain()
        {
            StringBuilder cmdStrB = new StringBuilder();
            int checkSum = 0;
            byte[] byteArray;

            if (!itemTestState) return;

            foreach (KeyValuePair<e_mssItem, List<string>> d_tmp in d_itemInfo)
            {
                switch (d_tmp.Key)
                {
                    case e_mssItem.authTest:
                        fileTestResult = new FileStream(strFileName + "-Auth.txt", FileMode.Open, FileAccess.Write);
                        saveFileFlag = true;
                        itemNowTestCnt_g = 1;

                        while (itemNowTestCnt_g <= acqTestCnt)
                        {
                            this.Invoke((MethodInvoker)delegate { richTextBoxSendCmdShow.AppendText("开始第" + itemNowTestCnt_g.ToString() + "次测试\r\n"); });
                            writeFile(fileTestResult, "\r\n~~~~~~~~Start " + itemNowTestCnt_g.ToString() + " Auth Test~~~~~~~~\r\n");

                            recordInit();

                            if (d_itemInfo[e_mssItem.authTest][3].CompareTo("C") == 0)
                            {
                                recvTime.weekValid = false;
                                recvTime.seconds = 0.0;
                                recvTime.weekNum = 0;
                                homeTmp.serialSend("$XLTIM,1\r\n");
                                this.Invoke((MethodInvoker)delegate { richTextBoxSendCmdShow.AppendText("$XLTIM,1\r\n"); });
                                //开启接收命令超时检测
                                this.Invoke((MethodInvoker)delegate
                                {
                                    timerPC.Enabled = true;
                                    timerPC.Start();
                                });
                            }
                            else
                            {
                                //开启测试计数
                                this.Invoke((MethodInvoker)delegate
                                {
                                    timerAuth.Enabled = true;
                                    timerAuth.Start();
                                });
                            }

                            while (cmdSendTimer < 255)
                            {
                                _waitHandleMain.WaitOne();

                                if (cmdSendTimer <= 5)
                                {
                                    cmdStrB.Clear();
                                    checkSum = 0;
                                    if (cmdSendTimer <= 4)//测试命令发送3次
                                    {
                                        if (d_itemInfo[e_mssItem.authTest][1].CompareTo("B3Q") == 0)
                                            cmdStrB.AppendFormat("$CCMSS,{0},{1},{2},{3},,,,", d_itemInfo[e_mssItem.authTest][3], 2, "B3", "Q");
                                        else if (d_itemInfo[e_mssItem.authTest][1].CompareTo("B3I") == 0)
                                            cmdStrB.AppendFormat("$CCMSS,{0},{1},{2},{3},,,,", d_itemInfo[e_mssItem.authTest][3], 2, "B3", "I");
                                        else
                                            cmdStrB.AppendFormat("$CCMSS,{0},{1},{2},,,,,", d_itemInfo[e_mssItem.authTest][3], 2, d_itemInfo[e_mssItem.authTest][1]);
                                    }
                                    else if (cmdSendTimer == 5)//重启命令发送一次
                                        cmdStrB.AppendFormat("$CCRIS,");

                                    byteArray = System.Text.Encoding.ASCII.GetBytes(cmdStrB.ToString());
                                    for (int i = 1; i < byteArray.Length; i++)//添加校验
                                        checkSum ^= byteArray[i];
                                    cmdStrB.AppendFormat("*{0:X2}\r\n", (byte)(checkSum & 0xff));

                                    serialPortPro.Write(cmdStrB.ToString());

                                    this.Invoke((MethodInvoker)delegate { richTextBoxSendCmdShow.AppendText(cmdStrB.ToString()); });
                                }
                                else if (cmdSendTimer == 10)//命令发送完毕准备测试7~10在定时器里面发送命令
                                {
                                    this.Invoke((MethodInvoker)delegate { richTextBoxSendCmdShow.AppendText("命令发送完毕\r\n测试准备阶段\r\n"); });
                                }
                                else if (cmdSendTimer == 130)//发送完命令后接收数据120s,等待稳定，稳定后，开始测试
                                {
                                    this.Invoke((MethodInvoker)delegate { richTextBoxSendCmdShow.AppendText("开始测试\r\n"); });
                                    writeFile(fileTestResult, "\r\n~~~~~~~~Start Record " + itemNowTestCnt_g.ToString() + " Auth Test~~~~~~~~\r\n");
                                    itemStatisticsFlag = 1;//开始统计标志
                                }
                                else if (cmdSendTimer == 250)//统计120s (130~250s)后。开始统计ACQ。
                                {
                                    if (!intrAcqCmd)
                                        serialPortPro.Write("$XLAUTHACQ,FFFFFFFFFFFFFFFF\r\n");
                                }
                            }
                            //统计本次结果
                            this.Invoke((MethodInvoker)delegate { timerAuth.Enabled = false; });
                            recvTime.weekValid = false;

                            writeFile(fileTestResult, "\r\n~~~~~~~~End Record " + itemNowTestCnt_g.ToString() + " Auth Test~~~~~~~~\r\n");
                            itemStatisticsFlag = 0;//关闭统计

                            serialPortPro.Write("$CCMSS,C,2,B3Q,,,,,*1C\r\n");//TEST

                            generateResults();
                            Thread.Sleep(2000);//保证挂起的任务能完成
                            itemNowTestCnt_g++;
                        }
                        saveFileFlag = false;
                        Thread.Sleep(3000);//保证挂起的任务能完成
                        fileTestResult.Dispose();//关闭保存数据流

                        break;
                    case e_mssItem.cold:
                        cmdStrB.Clear();
                        checkSum = 0;
                        cmdStrB.AppendFormat("$CCMSS,C,{0},{1},{2},,,,", (int)(e_mssItem.cold), d_itemInfo[e_mssItem.cold][2].Substring(0, 2), d_itemInfo[e_mssItem.cold][2].Substring(2, 1));/*暂时只适用于V21协议*/
                        byteArray = System.Text.Encoding.ASCII.GetBytes(cmdStrB.ToString());
                        for (int i = 1; i < byteArray.Length; i++)//添加校验
                            checkSum ^= byteArray[i];
                        cmdStrB.AppendFormat("*{0:X2}\r\n", (byte)(checkSum & 0xff));
                        serialPortPro.Write(cmdStrB.ToString());

                        this.Invoke((MethodInvoker)delegate { richTextBoxSendCmdShow.AppendText(cmdStrB.ToString()); });

                        break;
                    case e_mssItem.errRate:
                        checkSum = 0;
                        cmdStrB.Clear();
                        d_ectErrorRate["totol"] = 0;
                        d_ectErrorRate["error"] = 0;

                        cmdStrB.AppendFormat("$CCECS,{0},{1},{2}", d_itemInfo[e_mssItem.errRate][2], d_itemInfo[e_mssItem.errRate][3], d_itemInfo[e_mssItem.errRate][4]);
                        byteArray = System.Text.Encoding.ASCII.GetBytes(cmdStrB.ToString());
                        for (int i = 1; i < byteArray.Length; i++)//添加校验
                            checkSum ^= byteArray[i];
                        cmdStrB.AppendFormat("*{0:X2}\r\n", (byte)(checkSum & 0xff));
                        serialPortPro.Write(cmdStrB.ToString());
                        this.Invoke((MethodInvoker)delegate { richTextBoxSendCmdShow.AppendText(cmdStrB.ToString()); });

                        checkSum = 0;
                        cmdStrB.Clear();
                        cmdStrB.AppendFormat("$CCMSS,C,0,{0},{1},,,", d_itemInfo[e_mssItem.errRate][2], d_itemInfo[e_mssItem.errRate][4]);
                        byteArray = System.Text.Encoding.ASCII.GetBytes(cmdStrB.ToString());
                        for (int i = 1; i < byteArray.Length; i++)//添加校验
                            checkSum ^= byteArray[i];
                        cmdStrB.AppendFormat("*{0:X2}\r\n", (byte)(checkSum & 0xff));
                        serialPortPro.Write(cmdStrB.ToString());

                        homeTmp.decDataFlag["ECT"] = 1;

                        this.Invoke((MethodInvoker)delegate { richTextBoxSendCmdShow.AppendText(cmdStrB.ToString()); });

                        break;
                    default:
                        break;
                }
            }

            qtpStop();
        }

        private void btnQtpAllResult_Click(object sender, EventArgs e)
        {
            FormQtpAllResult formAllResult = new FormQtpAllResult();
            formAllResult.Show();
        }

        private void comboBoxErrorRateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int start = 0, end = 0;

            comboBoxErrorRateNum.Enabled = true;
            comboBoxErrorRateNum.Items.Clear();
            start = 1;
            switch (comboBoxErrorRateType.SelectedIndex)
            {
                case 0:
                case 1:
                    end = 12;
                    break;
                case 2:
                    end = 64;
                    break;
                case 3:
                    end = 10;
                    break;
                case 4:
                    end = 37;
                    break;
                default:
                    comboBoxErrorRateNum.Enabled = false;
                    return;
                    //break;
            }
            for (int i = start; i <= end; i ++)
            {
                comboBoxErrorRateNum.Items.Add(i.ToString());
            }
        }
    }
}
