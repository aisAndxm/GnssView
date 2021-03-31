
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Globalization;


namespace GnssView
{
    public partial class FormFPGA : Form
    {
        public FormFPGA(FormHome home)
        {
            InitializeComponent();
            homeTmp = home;

            progBarUpdate.Step = 1;/*设置每次进度条增长多少*/
            comboBoxWRRD.SelectedIndex = 0;
        }

        readonly UInt16[] crc16Table = new UInt16[]
        {
            0x0000,0x1021,0x2042,0x3063,0x4084,0x50a5,0x60c6,0x70e7,
            0x8108,0x9129,0xa14a,0xb16b,0xc18c,0xd1ad,0xe1ce,0xf1ef,
            0x1231,0x0210,0x3273,0x2252,0x52b5,0x4294,0x72f7,0x62d6,
            0x9339,0x8318,0xb37b,0xa35a,0xd3bd,0xc39c,0xf3ff,0xe3de,
            0x2462,0x3443,0x0420,0x1401,0x64e6,0x74c7,0x44a4,0x5485,
            0xa56a,0xb54b,0x8528,0x9509,0xe5ee,0xf5cf,0xc5ac,0xd58d,
            0x3653,0x2672,0x1611,0x0630,0x76d7,0x66f6,0x5695,0x46b4,
            0xb75b,0xa77a,0x9719,0x8738,0xf7df,0xe7fe,0xd79d,0xc7bc,
            0x48c4,0x58e5,0x6886,0x78a7,0x0840,0x1861,0x2802,0x3823,
            0xc9cc,0xd9ed,0xe98e,0xf9af,0x8948,0x9969,0xa90a,0xb92b,
            0x5af5,0x4ad4,0x7ab7,0x6a96,0x1a71,0x0a50,0x3a33,0x2a12,
            0xdbfd,0xcbdc,0xfbbf,0xeb9e,0x9b79,0x8b58,0xbb3b,0xab1a,
            0x6ca6,0x7c87,0x4ce4,0x5cc5,0x2c22,0x3c03,0x0c60,0x1c41,
            0xedae,0xfd8f,0xcdec,0xddcd,0xad2a,0xbd0b,0x8d68,0x9d49,
            0x7e97,0x6eb6,0x5ed5,0x4ef4,0x3e13,0x2e32,0x1e51,0x0e70,
            0xff9f,0xefbe,0xdfdd,0xcffc,0xbf1b,0xaf3a,0x9f59,0x8f78,
            0x9188,0x81a9,0xb1ca,0xa1eb,0xd10c,0xc12d,0xf14e,0xe16f,
            0x1080,0x00a1,0x30c2,0x20e3,0x5004,0x4025,0x7046,0x6067,
            0x83b9,0x9398,0xa3fb,0xb3da,0xc33d,0xd31c,0xe37f,0xf35e,
            0x02b1,0x1290,0x22f3,0x32d2,0x4235,0x5214,0x6277,0x7256,
            0xb5ea,0xa5cb,0x95a8,0x8589,0xf56e,0xe54f,0xd52c,0xc50d,
            0x34e2,0x24c3,0x14a0,0x0481,0x7466,0x6447,0x5424,0x4405,
            0xa7db,0xb7fa,0x8799,0x97b8,0xe75f,0xf77e,0xc71d,0xd73c,
            0x26d3,0x36f2,0x0691,0x16b0,0x6657,0x7676,0x4615,0x5634,
            0xd94c,0xc96d,0xf90e,0xe92f,0x99c8,0x89e9,0xb98a,0xa9ab,
            0x5844,0x4865,0x7806,0x6827,0x18c0,0x08e1,0x3882,0x28a3,
            0xcb7d,0xdb5c,0xeb3f,0xfb1e,0x8bf9,0x9bd8,0xabbb,0xbb9a,
            0x4a75,0x5a54,0x6a37,0x7a16,0x0af1,0x1ad0,0x2ab3,0x3a92,
            0xfd2e,0xed0f,0xdd6c,0xcd4d,0xbdaa,0xad8b,0x9de8,0x8dc9,
            0x7c26,0x6c07,0x5c64,0x4c45,0x3ca2,0x2c83,0x1ce0,0x0cc1,
            0xef1f,0xff3e,0xcf5d,0xdf7c,0xaf9b,0xbfba,0x8fd9,0x9ff8,
            0x6e17,0x7e36,0x4e55,0x5e74,0x2e93,0x3eb2,0x0ed1,0x1ef0
        };

        enum ProcessState
        {
            idel = 0,/*空闲*/
            ask = 1,/*发送自检*/
            start = 2,/*开始发送bin*/
            reTran = 3,/*重新发送*/
            end = 4,/*bin发送完成*/
            finish = 5,/*发送完成命令*/
            fail = 6,/*出现错误停止更新*/
        };

        private FormHome homeTmp;
        //private UInt32 swVersion = 0;/*bin文件的版本类型*/
        private ProcessState procFlag = ProcessState.idel;/*发送进程标志*/
        private bool selfCheckFlag = false;/*自检标志*/
        private UInt16 selfCheckState = 0;/*自检结果*/
        private bool CheckFrameId = false;/*检测帧ID*/
        private bool updateState = false;/*更新状态*/
        private UInt16 errorState = 0;/*错误状态*/
        private UInt16 txDataFrameId = 0;/*发送帧号*/
        private UInt16 rxDataFrameId = 0;/*接收帧号*/
        private UInt16 rxState = 1;/*接收状态, 1成功继续发送, 2请求重传， 10结束传送*/
        private UInt16 txMode = 0;/*1 采用握手模式*/
        private BinaryReader brBootLoader;/*读bin文件句柄*/
        private int timerTick = 0;/*烧写两个程序之间的间隔*/
        private byte[] byteCmdBuf = new byte[1124];
        private int cmdLen = 0;/*命令长度*/
        private readonly int rdFileLen = 1022;/*一次读取bin长度*/
        private int waitTimeUpdate = 10;/*两条命令间隔，超时时间*/
        private int waitTimeInterval = 600;/*等待烧写成功回复超时时间；两个程序烧写之间的间隔，超时时间*/
        private readonly int timerInterVal = 100;
        private readonly string strProtHead = "$XLBIN";/*字头*/
        private bool connectFlag = false;
        private int waitFlashEraseCnt = 0;


        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                AutoUpgradeEnabled = false,
                Title = "打开文件",
                Filter = "所有文件(*.*)|*.*"
            };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
                int index = dataGridViewPath.Rows.Add();
                dataGridViewPath.Rows[index].Cells[0].Value = path;
                dataGridViewPath.Rows[index].Cells[3].Value = fileInfo.Length;
                dataGridViewPath.Rows[index].Cells[2].Value = fileInfo.CreationTime;
            }
            dialog.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewPath.Rows.Count < 1) return;
            foreach (DataGridViewRow row in dataGridViewPath.SelectedRows)
                dataGridViewPath.Rows.Remove(row);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewPath.SelectedRows.Count > 1) return;

            OpenFileDialog dialog = new OpenFileDialog
            {
                AutoUpgradeEnabled = false,
                Title = "打开文件",
                Filter = "所有文件(*.*)|*.*"
            };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
                dataGridViewPath.SelectedRows[0].Cells[0].Value = path;
                dataGridViewPath.SelectedRows[0].Cells[2].Value = fileInfo.CreationTime;
                dataGridViewPath.SelectedRows[0].Cells[3].Value = fileInfo.Length;
            }
            dialog.Dispose();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (dataGridViewPath.SelectedRows.Count > 1) return;
            if (dataGridViewPath.Rows.Count <= 1) return;

            try
            {
                DataGridViewSelectedRowCollection dgvsrc = dataGridViewPath.SelectedRows;//获取选中行的集合
                if (dgvsrc.Count > 0)
                {
                    int index = dataGridViewPath.SelectedRows[0].Index;//获取当前选中行的索引
                    if (index > 0)//如果该行不是第一行
                    {
                        DataGridViewRow dgvr = dataGridViewPath.Rows[index - dgvsrc.Count];//获取选中行的上一行
                        dataGridViewPath.Rows.RemoveAt(index - dgvsrc.Count);//删除原选中行的上一行
                        dataGridViewPath.Rows.Insert((index), dgvr);//将选中行的上一行插入到选中行的后面
                        for (int i = 0; i < dgvsrc.Count; i++)//选中移动后的行
                        {
                            dataGridViewPath.Rows[index - i - 1].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                messageLabel(ex.ToString());
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (dataGridViewPath.SelectedRows.Count > 1) return;
            if (dataGridViewPath.Rows.Count <= 1) return;

            try
            {
                DataGridViewSelectedRowCollection dgvsrc = dataGridViewPath.SelectedRows;//获取选中行的集合
                if (dgvsrc.Count > 0)
                {
                    int index = dataGridViewPath.SelectedRows[0].Index;//获取当前选中行的索引
                    if (index >= 0 & (dataGridViewPath.RowCount - 1) != index)//如果该行不是最后一行
                    {
                        DataGridViewRow dgvr = dataGridViewPath.Rows[index + 1];//获取选中行的下一行
                        dataGridViewPath.Rows.RemoveAt(index + 1);//删除原选中行的上一行
                        dataGridViewPath.Rows.Insert((index + 1 - dgvsrc.Count), dgvr);//将选中行的上一行插入到选中行的后面
                        for (int i = 0; i < dgvsrc.Count; i++)//选中移动后的行
                        {
                            dataGridViewPath.Rows[index + 1 - i].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                messageLabel(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            long sendFileLen = 0;/*发送文件的大小Byte单位*/

            if (dataGridViewPath.Rows.Count < 1)
            {
                messageLabel("添加bin文件\r\n");
                return;
            }

            if (homeTmp.serialState() == false)
            {
                messageLabel("打开串口\r\n");
                return;
            }

            try// 读取文件
            {
                FileStream fileFd = new FileStream(dataGridViewPath.SelectedRows[0].Cells[0].Value.ToString(), FileMode.Open);
                brBootLoader = new BinaryReader(fileFd);
                sendFileLen += fileFd.Length;
            }
            catch
            {
                messageLabel("打开Bin文件失败\r\n");
                return;
            }

            if (checkBoxSelfCheck.Checked) selfCheckFlag = true;
            else selfCheckFlag = false;
            if (radioTransNormal.Checked) txMode = 1;
            else if (radioTransFast.Checked) txMode = 0;
            if (checkBoxCheckID.Checked) CheckFrameId = true;
            else CheckFrameId = false;
            if (textBoxWaitTime.Text.Length > 0) waitTimeUpdate = int.Parse(textBoxWaitTime.Text) / timerInterVal;

            if (int.TryParse(textBoxWaitTime.Text, out int data))
            {
                waitTimeUpdate = (Int32)(data / timerInterVal);
            }
            else return;

            initGlobalVar();

            progBarUpdate.Maximum = (int)(sendFileLen / rdFileLen) + 4;/*设置最大长度值*/
            progBarUpdate.Value = 0;/*设置进度条当前值*/

            waitTimeInterval = (int)(((sendFileLen / rdFileLen) * 1100 + 8000) / timerInterVal);/* 估计烧写时间单位是ms*/

            waitFlashEraseCnt = 0;

            messageLabel("开始升级\r\n");

            timerSend.Interval = timerInterVal;
            timerSend.Enabled = true;
            timerSend.Start();
            btnEnable(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (timerSend.Enabled == false) return;
            clearGlobalVar();

            timerSend.Enabled = false;//接收命令超时检测关闭
            btnEnable(true);
            messageLabel("取消升级\r\n");
            progBarUpdate.Value = 0;/*设置进度条当前值*/
        }

        private void btnEnable(bool state)
        {
            groupBoxProperty.Enabled = state;
            groupBoxTransMode.Enabled = state;
            groupBoxProcess.Enabled = state;
            btnQuery.Enabled = state;
            btnCheck.Enabled = state;
            groupBoxReg.Enabled = state;
            groupBoxType.Enabled = state;
            btnUpdate.Enabled = state;
        }

        private void initGlobalVar()
        {
            updateState = false;
            rxDataFrameId = 0;
            txDataFrameId = 0;
            errorState = 0;
            rxState = 1;/*空*/
            timerTick = 0;
            procFlag = ProcessState.ask;
        }

        private void clearGlobalVar()
        {
            procFlag = ProcessState.idel;
            rxState = 0;
            updateState = false;
            if (brBootLoader != null) brBootLoader.Dispose();
        }

        private void timerSend_Tick(object sender, EventArgs e)
        {
            switch(procFlag)
            {
                case ProcessState.idel:
                    if (!updateState) break;/*更新完成*/
                    clearGlobalVar();
                    timerSend.Enabled = false;
                    btnEnable(true);
                    messageLabel("~~~升级成功！~~~\r\n");
                    progBarUpdate.Value = progBarUpdate.Maximum;
                    break;
                case ProcessState.fail:
                    clearGlobalVar();
                    timerSend.Enabled = false;
                    btnEnable(true);
                    progBarUpdate.Value = 0;
                    procFlag = ProcessState.idel;
                    break;
                default:
                    switch (rxState)
                    {
                        case 0:/*等待超时退出*/
                            timerTick++;
                            if (timerTick > waitTimeUpdate)
                            {
                                if (procFlag == ProcessState.end)
                                    break;/*发送完最后一条命令后等待一段时间，是否有其他命令，此时rxState = 0，时间到达后再去执行updatePro*/

                                clearGlobalVar();
                                timerSend.Enabled = false;
                                btnEnable(true);
                                progBarUpdate.Value = 0;
                                messageLabel(String.Format("等待超时{0,2:X2}\r\n", errorState));
                            }
                            return;
                        case 3:/*请求发送的id错误*/
                            clearGlobalVar();
                            timerSend.Enabled = false;
                            btnEnable(true);
                            progBarUpdate.Value = 0;
                            messageLabel(String.Format("请求ID错误{0,2:X2}\r\n", errorState));
                            return;
                        case 10:/*用户设备请求结束*/
                            clearGlobalVar();
                            timerSend.Enabled = false;
                            btnEnable(true);
                            progBarUpdate.Value = 0;
                            messageLabel(String.Format("用户设备请求结束\r\n"));
                            return;
                        case 0xF0:/*等待连接*/
                            timerTick++;
                            if (timerTick > waitTimeUpdate * 10)
                            {
                                clearGlobalVar();
                                timerSend.Enabled = false;
                                btnEnable(true);
                                progBarUpdate.Value = 0;
                                messageLabel(String.Format("等待连接超时{0,2:X2}\r\n", errorState));
                            }
                            return;
                        case 0xDD:/*等待擦除*/
                            waitFlashEraseCnt++;
                            if (waitFlashEraseCnt > waitTimeUpdate * 60)
                            {
                                clearGlobalVar();
                                timerSend.Enabled = false;
                                btnEnable(true);
                                progBarUpdate.Value = 0;
                                messageLabel(String.Format("等待擦除超时{0,2:X2}\r\n", errorState));
                            }
                            return;
                        case 2:/*重传*/
                            procFlag = ProcessState.reTran;
                            break;
                        case 1:/*正常传输*/
                            break;
                        default:
                            return;

                    }
                    updatePro();
                    timerTick = 0;
                    break;
            }
        }

        private void updatePro()
        {
            if (procFlag < ProcessState.ask) return;

            byte[] bytesBin = new byte[] { 0x0 };
            UInt16 rdLen = 0;
            byte para0 = 0x00;
            UInt16 para1 = 0x0000, para2 = 0x0000;

            if (txMode == 1) rxState = 0;/*如果是应答模式，清除接收状态位等待状态*/

            if (selfCheckFlag)
            {
                para0 = 0x50;
                para1 = 0x0000;
                selfCheckFlag = false;
            }
            else if (procFlag == ProcessState.ask)/*para0 = 0x00*/
            {
                if (!connectFlag)
                {
                    rxState = 0xF0;/*等待连接设备*/
                    messageLabel("等待连接设备\r\n");
                    return;
                }
                else rxState = 0xDD;/*设备已经连接开始更新*/
                messageLabel("等待擦除设备\r\n");
                para0 = 0x00;
                if (radioTransNormal.Checked) para1 = 1;/*是否握手传输*/
                if (radioBtnBoot.Checked) para1 |= (0 << 2);
                else if (radioBtnApp.Checked) para1 |= (1 << 2);
                else para1 |= (3 << 2);

                txDataFrameId = 0;/*重新发送清除帧号*/
                procFlag = ProcessState.start;

            }
            else if (procFlag == ProcessState.start)/*烧写BIN文件*/
            {
                para0 = 0x01;/*para0*/
                para1 = txDataFrameId;

                try// 读取文件
                {
                    bytesBin = brBootLoader.ReadBytes(rdFileLen);
                    rdLen = (UInt16)bytesBin.Length;
                    para2 = (UInt16)(rdLen + 2);/*长度加上校验2Byte*/

                    if (rdLen == 0)
                    {
                        brBootLoader.Dispose();
                    }
                }
                catch
                {
                    messageLabel("打开bootLoader文件失败\r\n");
                    return;
                }

                if (rdLen == 0)/*发送完成，变成end*/
                {
                    procFlag = ProcessState.end;
                    return;
                }

                progBarUpdate.Value += progBarUpdate.Step;
            }
            else if (procFlag == ProcessState.reTran)
            {
                if (homeTmp.serialState()) homeTmp.serialSend(byteCmdBuf, 0, cmdLen);
                procFlag = ProcessState.start;/*重新发送后，把流程切换到开始，就算是最后一条语句，也会在start里面切换到end*/
                return;
            }
            else if (procFlag == ProcessState.end)/*发送bin完成*/
            {
                procFlag = ProcessState.idel;
                para0 = 0x0F;/*数据读取完成,发送完成标志*/
                if (txMode == 0) updateState = true;
            }

            byte[] protHead = System.Text.Encoding.ASCII.GetBytes(strProtHead);
            cmdLen = strProtHead.Length;
            /*字头*/
            Array.Copy(protHead, 0, byteCmdBuf, 0, cmdLen);
            /*para0*/
            byteCmdBuf[cmdLen++] = para0;
            /*para1*/
            byteCmdBuf[cmdLen++] = (byte)((para1 >> 8) & 0xff);
            byteCmdBuf[cmdLen++] = (byte)(para1 & 0xff);
            /*para2*/
            byteCmdBuf[cmdLen++] = (byte)((para2 >> 8) & 0xff);
            byteCmdBuf[cmdLen++] = (byte)(para2 & 0xff);
            /*para3*/
            if (rdLen > 0)
            {
                Array.Copy(bytesBin, 0, byteCmdBuf, cmdLen, rdLen);/*para3发送数据和校验crc16*/
                cmdLen += rdLen;
                UInt16 crcValue = crc16Check(bytesBin, rdLen);/*crc16*/
                byteCmdBuf[cmdLen++] = (byte)((crcValue >> 8) & 0xff);
                byteCmdBuf[cmdLen++] = (byte)(crcValue & 0xff);

                if (txMode == 1) txDataFrameId++;
            }

            /*添加校验*/
            byte xorValue = (byte)xorCheck(byteCmdBuf, 0, cmdLen);/*校验$和*之间的*/
            byteCmdBuf[cmdLen++] = xorValue;

            if (homeTmp.serialState())
            {
                homeTmp.serialSend(byteCmdBuf, 0, cmdLen);
                messageLabel(String.Format("发送命令 {0,2:X2} {1,2:X2} {2,2:X2} {3,2:X2} {4,2:X2} {5,2:X2} {6,2:X2} {7,2:X2} {8,2:X2} {9,2:X2} {10,2:X2} {11,2:X2} \r\n",
                    byteCmdBuf[0], byteCmdBuf[1], byteCmdBuf[2], byteCmdBuf[3], byteCmdBuf[4], byteCmdBuf[5],
                    byteCmdBuf[6], byteCmdBuf[7], byteCmdBuf[8], byteCmdBuf[9], byteCmdBuf[10], byteCmdBuf[cmdLen - 1]));
            }
            else
                messageLabel("串口未打开\r\n");
        }

        public int xlbinDec(byte[] data, int len)
        {
            if (len < 12)
            {
                messageLabel(String.Format("接收命令长度0x{0,2:X2}", len));
                return 1;
            }
            messageLabel(String.Format("接收命令 {0,2:X2} {1,2:X2} {2,2:X2} {3,2:X2} {4,2:X2} {5,2:X2} {6,2:X2} {7,2:X2} {8,2:X2} {9,2:X2} {10,2:X2} {11,2:X2} \r\n",
                data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8], data[9], data[10], data[len - 1]));
            byte[] bTemp = new byte[2];
            //UInt16 crcValue = crc16Check(data, 11, 1024);/*crc16*/
            int check = xorCheck(data, 0, len - 1);
            if ((check & 0xff) != data[11])
            {
                messageLabel(String.Format("接收命令校验错误0x{0,2:X2}", (check & 0xff)));
                return 2;
            }
            switch (data[6])
            {
                case 0x10:
                    rxState = 1;
                    rxDataFrameId = BitConverter.ToUInt16(bTemp, 0);
                    if ((txMode == 1) && (rxDataFrameId != txDataFrameId) && CheckFrameId) rxState = 3;/*请求发送的BIN的ID错误*/
                    break;
                case 0x11:
                    bTemp[0] = data[8];
                    bTemp[1] = data[7];
                    rxDataFrameId = BitConverter.ToUInt16(bTemp, 0);
                    rxState = 2;
                    break;
                case 0x12:
                    rxState = 10;
                    break;
                case 0x51:
                    bTemp[0] = data[8];
                    bTemp[1] = data[7];
                    selfCheckState = BitConverter.ToUInt16(bTemp, 0);
                    break;
                case 0x61:
                    bTemp[0] = data[8];
                    bTemp[1] = data[7];
                    errorState = BitConverter.ToUInt16(bTemp, 0);
                    break;
                case 0x71:
                    bTemp[0] = data[8];
                    bTemp[1] = data[7];
                    UInt16 stateTemp = BitConverter.ToUInt16(bTemp, 0);
                    if (stateTemp == 1)
                        updateState = true;
                    else if (stateTemp == 0)
                        updateState = false;
                    break;
                case 0xF1:
                    cmdPack(0xF0, 0x0000, 0x0000);
                    rxState = 1;/*如果更新等待连接，变成连接成功*/
                    connectFlag = true;
                    messageLabel("连接成功\r\n");
                    break;
                case 0x81:
                    messageLabel(BitConverter.ToString(data, 11, len - 12).Replace("-", " ") + ' ');
                    break;
                default:
                    return 3;
            }

            return 0;
        }

        private UInt16 crc16Check(byte[] buffer, int len)
        {
            int counter;
            UInt16 crc = 0;
            for (counter = 0; counter < len; counter++)
                crc = (UInt16)((crc << 8) ^ crc16Table[((crc >> 8) ^ buffer[counter]) & 0x00FF]);
            return crc;
        }

        private UInt16 crc16Check(byte[] buffer, int start, int len)
        {
            int counter;
            UInt16 crc = 0;
            for (counter = start; counter < len; counter++)
                crc = (UInt16)((crc << 8) ^ crc16Table[((crc >> 8) ^ buffer[counter]) & 0x00FF]);
            return crc;
        }

        private int xorCheck(byte[] data, int start, int length)
        {
            int check = 0;

            if (length < 1) return -1;

            for (int i = start; i < length; i++)
                check ^= data[i];

            return check;
        }

        private void cmdPack(byte para0, UInt16 para1, UInt16 para2)
        {
            byte[] byteCmdBufPack = new byte[64];
            byte[] protHead = System.Text.Encoding.ASCII.GetBytes(strProtHead);
            int cmdLenPack = strProtHead.Length;

            /*字头*/
            Array.Copy(protHead, 0, byteCmdBufPack, 0, cmdLenPack);
            /*para0*/
            byteCmdBufPack[cmdLenPack++] = para0;
            /*para1*/
            byteCmdBufPack[cmdLenPack++] = (byte)((para1 >> 8) & 0xff);
            byteCmdBufPack[cmdLenPack++] = (byte)(para1 & 0xff);
            /*para2*/
            byteCmdBufPack[cmdLenPack++] = (byte)((para2 >> 8) & 0xff);
            byteCmdBufPack[cmdLenPack++] = (byte)(para2 & 0xff);
            byte xorValue = (byte)xorCheck(byteCmdBufPack, 0, cmdLenPack);/*校验$和*之间的*/
            byteCmdBufPack[cmdLenPack++] = xorValue;

            if (homeTmp.serialState())
                homeTmp.serialSend(byteCmdBufPack, 0, cmdLenPack);
        }

        private void messageLabel(string message)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate { textBoxOut.Text += message; });
            }
            catch { }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            cmdPack(0x50, 0x0000, 0x0000);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            cmdPack(0x60, 0x0000, 0x0000);
        }

        private void FormUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (brBootLoader != null) brBootLoader.Dispose();

            this.Dispose();
        }

        private void textBoxOut_TextChanged(object sender, EventArgs e)
        {
            if (textBoxOut.Lines.Length > 10000)
                textBoxOut.Clear();
            else
            {
                //将光标位置设置到当前内容的末尾
                textBoxOut.SelectionStart = textBoxOut.Text.Length;
                //滚动到光标位置
                textBoxOut.ScrollToCaret();
            }
        }

        private void btnSendCmd_Click(object sender, EventArgs e)
        {
            byte para0 = 0;
            UInt16 para1 = 0, para2 = 0;

            para0 = (byte)(comboBoxWRRD.SelectedIndex + 2);

            if (!comboBoxRegAddr.Items.Contains(comboBoxRegAddr.Text))
            {
                if (int.TryParse(comboBoxRegAddr.Text, NumberStyles.HexNumber, new CultureInfo("en-US"), out int data))
                {
                    para1 = (UInt16)(data & 0xffff);
                }
                else return;
            }

            if (!comboBoxRegVal.Items.Contains(comboBoxRegVal.Text))
            {
                if (int.TryParse(comboBoxRegVal.Text, NumberStyles.HexNumber, new CultureInfo("en-US"), out int data))
                {
                    para2 = (UInt16)(data & 0xffff);
                }
                else return;
            }

            cmdPack(para0, para1, para2);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            cmdPack(0xF0, 0x0000, 0x0000);
            connectFlag = false;
            messageLabel("等待设备\r\n");
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            cmdPack(0x00, 0x000c, 0x0000); //3表示正常加载默认app程序
        }

        private void btnReadFlash_Click(object sender, EventArgs e)
        {
            UInt16 para1 = 0;
            if (radioTransNormal.Checked) para1 = 1;/*是否握手传输*/
            if (radioBtnBoot.Checked) para1 |= (0 << 2);
            else if (radioBtnApp.Checked) para1 |= (1 << 2);
            cmdPack(0x80, para1, 0x0000); //3表示正常加载默认app程序
        }
    }
}
