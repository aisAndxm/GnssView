using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace GnssView
{
    public partial class FormDataConvert : Form
    {
        public FormDataConvert()
        {
            InitializeComponent();

            comboBoxOri.SelectedIndex = 0;
            comboBoxConvert.SelectedIndex = 1;
            textBoxMoveNum.Text = "0";
            comboBoxSel.SelectedIndex = 0;
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

        private int DataTypeflag = 0;
        string[] strPathName = new string[3];
        string[] strFolderName = new string[3];
        byte[] dataTab = { 1, 3, 0xFF, 0xFD };

        /*list实体类深复制*/
        public List<char> CopyList(List<char> srcList)
        {
            List<char> list = new List<char>();
            foreach (char obj in srcList)
                list.Add(obj);
            return list;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int oriType, convType;
            int moveNum, dataLen;
            string outStrData = null;

            oriType = comboBoxOri.SelectedIndex;
            convType = comboBoxConvert.SelectedIndex;

            if (oriType == -1 || convType == -1)
            {
                MessageBox.Show("请选择转换类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxMoveNum.Text, out moveNum))
            {
                MessageBox.Show("移位数错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string strOriData = richTextBoxOri.Text;
            if (strOriData == null)
            {
                MessageBox.Show("填写数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<char> charList = new List<char>();

            for (dataLen = 0; dataLen < strOriData.Length; dataLen++)
            {
                if ((strOriData[dataLen] == ',') || (strOriData[dataLen] == ' ') || (strOriData[dataLen] == '\r') 
                    || (strOriData[dataLen] == '\n') || (dataLen + 1 == strOriData.Length))
                {
                    if (charList.Count == 0) continue;

                    if (dataLen + 1 == strOriData.Length) charList.Add(strOriData[dataLen]);

                    /*把所有数据转换为二进制字符串数据，这样可以保证所转换的数据可以无限长*/
                    List<char> binaryList = new List<char>();
                    switch (comboBoxOri.SelectedIndex)
                    { 
                        case 0:/*十六进制*/
                            break;
                        case 1:/*十进制*/
                            break;
                        case 2:/*八进制*/
                            break;
                        case 3:/*二进制*/
                            binaryList = CopyList(charList);
                            break;
                        default:
                            MessageBox.Show("选择数据格式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                    }
                    charList.Clear();

                    /*移位位数*/
                    if (moveNum > 0)
                    {
                        char[] charArray = Enumerable.Repeat('0', moveNum).ToArray();
                        binaryList.AddRange(charArray);
                    }
                    else if (moveNum < 0 && moveNum < binaryList.Count)
                        binaryList.RemoveRange(binaryList.Count - moveNum, moveNum);
                    else if (moveNum < 0 && moveNum >= binaryList.Count)
                        binaryList.Clear();

                    /*输出数据进制数*/
                    int bitAlign = 0;
                    switch (comboBoxConvert.SelectedIndex)
                    {
                        case 0:/*十六进制*/
                            bitAlign = 4;
                            outStrData += "0x";
                            break;
                        case 1:/*十进制*/
                            if (binaryList.Count > 64)
                            {
                                MessageBox.Show("转换成十进制的数据位数过大", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            break;
                        case 2:/*八进制*/
                            bitAlign = 4;
                            break;
                        case 3:/*二进制*/
                            outStrData += string.Join(null,binaryList.ToArray());
                            if (dataLen + 1 != strOriData.Length) 
                                outStrData += strOriData[dataLen];
                            continue;
                        default:
                            MessageBox.Show("选择数据格式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                    }

                    /*高低位对齐*/
                    int intTmp = 0;
                    int bitLen = binaryList.Count % bitAlign;
                    if (checkBoxAlign.Checked)
                    {
                        for (int pos = 0; pos < binaryList.Count / bitAlign; pos++)
                        {
                            intTmp = 0;
                            intTmp = ((binaryList[bitAlign * pos] - 48) << 3) + ((binaryList[bitAlign * pos + 1] - 48) << 2) +
                                ((binaryList[bitAlign * pos + 2] - 48) << 1) + (binaryList[bitAlign * pos + 3] - 48);

                            outStrData += Convert.ToString(intTmp, 16);
                        }

                        if (bitLen > 0)
                        {
                            for (int pos = 0; pos < bitLen; pos++)
                            {
                                intTmp <<= 1;
                                intTmp += binaryList[pos] - 48;
                            }
                            outStrData += Convert.ToString(intTmp, 16);
                        }
                    }
                    else 
                    {
                        if (bitLen > 0)
                        {
                            for (int pos = 0; pos < bitLen; pos++)
                            {
                                intTmp <<= 1;
                                intTmp += binaryList[pos] - 48;
                            }
                            outStrData += Convert.ToString(intTmp, 16);
                        }

                        for (int pos = 0; pos < binaryList.Count / bitAlign; pos++)
                        {
                            intTmp = 0;
                            intTmp = ((binaryList[bitAlign * pos + bitLen] - 48) << 3) + ((binaryList[bitAlign * pos + bitLen + 1] - 48) << 2) +
                                ((binaryList[bitAlign * pos + bitLen + 2] - 48) << 1) + (binaryList[bitAlign * pos + bitLen + 3] - 48);

                            outStrData += Convert.ToString(intTmp, 16);
                        }
                    }
                    if (dataLen + 1 == strOriData.Length) break;
                    outStrData += strOriData[dataLen];
                }
                else
                {
                    charList.Add(strOriData[dataLen]);
                }
            }

            richTextBoxResult.Text = outStrData;
        }

        const double WGS_MAJOR = 6378137.0;			//a - WGS-84 earth's semi major axis
        const double WGS_MINOR = 6356752.3142;		//b - WGS-84 earth's semi minor axis
        const double WGS_E1_SQRT = 0.00669437999014;		// first  numerical eccentricity
        const double WGS_E2_SQRT = 0.0067394967422751;		// second numerical eccentricity

        /// <summary>
        /// 经纬高转换为XYZ
        /// </summary>
        /// <param name="lla">经纬高</param>
        /// <param name="ecef">XYZ坐标</param>
        void llaToEcef(struct_lla_coord lla, out struct_ecef_coord ecef)
        {
            double N = 0.0;
            double sinLat, cosLat;
            double sinLon, cosLon;

            sinLat = Math.Sin(lla.lat);
            cosLat = Math.Cos(lla.lat);
            sinLon = Math.Sin(lla.lon);
            cosLon = Math.Cos(lla.lon);

            N = WGS_MAJOR / Math.Sqrt(1.0 - WGS_E1_SQRT * sinLat * sinLat);

            ecef.x = (N + lla.alt) * cosLat * cosLon;
            ecef.y = (N + lla.alt) * cosLat * sinLon;
            ecef.z = (N * (1.0 - WGS_E1_SQRT) + lla.alt) * sinLat;
        }

        /// <summary>
        /// ENU坐标转化为XYZ坐标
        /// </summary>
        /// <param name="enu">ENU坐标</param>
        /// <param name="lla">经纬高</param>
        /// <param name="xyz">XYZ坐标</param>
        void enuToEcef(struct_enu_coord enu, struct_lla_coord lla, out struct_ecef_coord xyz)
        {
            double sinLat = 0.0, cosLat = 0.0, sinLon = 0.0, cosLon = 0.0;

            /* ENU坐标系转化为XYZ坐标系的转化矩阵 */
            sinLat = Math.Sin(lla.lat);//fai lat
            cosLat = Math.Cos(lla.lat);
            sinLon = Math.Sin(lla.lon);//lamda lon
            cosLon = Math.Cos(lla.lon);

            /* xyz坐标等于转化矩阵乘以enu */
            xyz.x = -sinLon * enu.e - sinLat * cosLon * enu.n + cosLat * cosLon * enu.u;
            xyz.y = cosLon * enu.e - sinLat * sinLon * enu.n + sinLon * cosLat * enu.u;
            xyz.z = cosLat * enu.n + sinLat * enu.u;
        }

        /// <summary>
        /// xyz坐标转化为ENU坐标
        /// </summary>
        /// <param name="xyz">xyz坐标</param>
        /// <param name="lla">经纬高</param>
        /// <param name="enu">enu坐标</param>
        void ecefToEnu(struct_ecef_coord xyz, struct_lla_coord lla, out struct_enu_coord enu)
        {
            double sinLat = 0.0, cosLat = 0.0, sinLon = 0.0, cosLon = 0.0;

            /*计算ECEF直角坐标与ENU坐标系之间的转换矩阵*/
            sinLat = Math.Sin(lla.lat);
            cosLat = Math.Cos(lla.lat);
            sinLon = Math.Sin(lla.lon);
            cosLon = Math.Cos(lla.lon);

            /*enu坐标等于转化矩阵乘以xyz*/
            enu.e = (-sinLon) * xyz.x + cosLon * xyz.y;
            enu.n = (-sinLat) * cosLon * xyz.x - sinLat * sinLon * xyz.y + cosLat * xyz.z;
            enu.u = cosLat * cosLon * xyz.x + sinLon * cosLat * xyz.y + sinLat * xyz.z;
        }

        /// <summary>
        /// XYZ坐标转换为经纬高
        /// </summary>
        /// <param name="ecef">ecef坐标系的xyz </param>
        /// <param name="lla">经纬高</param>
        void ecefToLla(struct_ecef_coord ecef, out struct_lla_coord lla)
        {
            double p = 0.0, theta = 0.0, sinTheta = 0.0, cosTheta = 0.0, temp = 0.0, temp1 = 0.0, sinLat = 0.0;
            double up_lat = 0.0, low_lat = 0.0;
            double x = 0.0, y = 0.0, z = 0.0, r = 0.0;

            lla.lat = 0;
            lla.lon = 0;
            lla.alt = 0;

            x = ecef.x;
            y = ecef.y;
            z = ecef.z;
            r = x * x + y * y;

            if (Math.Abs(r) < 1e-12) return;

            p = Math.Sqrt(r);
            temp = (z * WGS_MAJOR) / (p * WGS_MINOR);
            theta = Math.Atan(temp);
            sinTheta = Math.Sin(theta);
            cosTheta = Math.Cos(theta);
            up_lat = z + WGS_E2_SQRT * WGS_MINOR * sinTheta * sinTheta * sinTheta;
            low_lat = p - WGS_E1_SQRT * WGS_MAJOR * cosTheta * cosTheta * cosTheta;

            lla.lat = Math.Atan2(up_lat, low_lat);
            lla.lon = Math.Atan2(y, x);

            sinLat = Math.Sin(lla.lat);
            temp = WGS_MAJOR / Math.Sqrt(1.0 - WGS_E1_SQRT * sinLat * sinLat);
            temp1 = Math.Cos(lla.lat);

            if (Math.Abs(r) < 1e-12) return;

            lla.alt = (p / temp1) - temp;
        }


        private void btnCoor_Click(object sender, EventArgs e)
        {
            struct_lla_coord lla;
            struct_ecef_coord xyz;
            struct_enu_coord enu;

            switch (comboBoxSel.SelectedIndex)
            { 
                case 0:
                    if (!double.TryParse(richTextBoxLat.Text, out lla.lat) || !double.TryParse(richTextBoxLon.Text, out lla.lon) || !double.TryParse(richTextBoxAlt.Text, out lla.alt))
                        break;
                    lla.lat /= (180.0 / Math.PI);
                    lla.lon /= (180.0 / Math.PI);
                    llaToEcef(lla, out xyz);
                    richTextBoxX.Text = xyz.x.ToString("f6");
                    richTextBoxY.Text = xyz.y.ToString("f6");
                    richTextBoxZ.Text = xyz.z.ToString("f6");
                    ecefToEnu(xyz, lla, out enu);
                    richTextBoxE.Text = enu.e.ToString("f6");
                    richTextBoxN.Text = enu.n.ToString("f6");
                    richTextBoxU.Text = enu.u.ToString("f6");
                    break;
                case 1:
                    if (!double.TryParse(richTextBoxX.Text, out xyz.x) || !double.TryParse(richTextBoxY.Text, out xyz.y) || !double.TryParse(richTextBoxZ.Text, out xyz.z))
                        break;
                    ecefToLla(xyz, out lla);
                    ecefToEnu(xyz, lla, out enu);
                    richTextBoxLat.Text = (lla.lat * (180.0 / Math.PI)).ToString("f6");
                    richTextBoxLon.Text = (lla.lon * (180.0 / Math.PI)).ToString("f6");
                    richTextBoxAlt.Text = lla.alt.ToString("f6");
                    richTextBoxE.Text = enu.e.ToString("f6");
                    richTextBoxN.Text = enu.n.ToString("f6");
                    richTextBoxU.Text = enu.u.ToString("f6");
                    break;
                case 2:
                    if (!double.TryParse(richTextBoxE.Text, out enu.e) || !double.TryParse(richTextBoxN.Text, out enu.n) || !double.TryParse(richTextBoxU.Text, out enu.u))
                        break;
                    //enuToEcef(enu, 
                    //richTextBoxE.Text = xyz.x.ToString("f6");
                    //richTextBoxN.Text = xyz.y.ToString("f6");
                    //richTextBoxU.Text = xyz.z.ToString("f6");
                    //richTextBoxLat.Text = lla.lat.ToString("f6");
                    //richTextBoxLon.Text = lla.lon.ToString("f6");
                    //richTextBoxAlt.Text = lla.alt.ToString("f6");
                    break;
                default:
                    break;
            }
        }

        void rfDataConvert()
        {
            string strFolderNameTmp;

            strFolderNameTmp = strFolderName[2] + "\\rfDataOut-" + System.DateTime.Now.ToString("yyyyMMddTHHmmss") + ".bin";
            try
            {
                using (StreamReader fpDataIn = new StreamReader(new FileStream(strPathName[2], FileMode.Open, FileAccess.Read)))
                {
                    BinaryWriter fpDataOut = new BinaryWriter(new FileStream(strFolderNameTmp, FileMode.OpenOrCreate, FileAccess.Write));
                    while (true)
                    {
                        string strTmp;
                        while (true)
                        {
                            strTmp = fpDataIn.ReadLine();

                            if (string.Compare(strTmp, 0, "0x", 0, 2) == 0) break;
                        }

                        if (UInt32.TryParse(strTmp, NumberStyles.HexNumber, new CultureInfo("en-US"), out UInt32 data))
                        {
                            for (UInt32 count = 0; count < 16; count++)
                            {
                                byte dataOut = (byte)((data >> (int)(30 - count * 2)) & 3);
                                fpDataOut.Write(dataTab[dataOut]);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        void rfBin2Bin()
        {
            string strFolderNameTmp;

            strFolderNameTmp = strFolderName[2] + "\\rfDataOut-" + System.DateTime.Now.ToString("yyyyMMddTHHmmss") + ".bin";
            try
            {
                using (StreamReader fpDataIn = new StreamReader(new FileStream(strPathName[2], FileMode.Open, FileAccess.Read)))
                {
                    BinaryWriter fpDataOut = new BinaryWriter(new FileStream(strFolderNameTmp, FileMode.OpenOrCreate, FileAccess.Write));
                    while (true)
                    {
                        int msg = fpDataIn.Read();

                        if (msg == 0x0a)
                        {
                            msg = fpDataIn.Read();
                            if (msg == 0x0d)
                            {
                                msg = fpDataIn.Read();
                                if (msg == 0x0a)
                                    break;
                            }
                        }
                    }
                    while (true)
                    {
                        char[] charMsg = new char[4];
                        fpDataIn.Read(charMsg, 0, 4);

                        UInt32 data = 0;
                        for (UInt32 i = 0; i < 4; i++)
                        {
                            data <<= 8;
                            data |= (byte)(charMsg[i] & 0xff);
                        }

                        for (UInt32 count = 0; count < 16; count++)
                        {
                            byte dataOut = (byte)((data >> (int)(30 - count * 2)) & 3);
                            fpDataOut.Write(dataTab[dataOut]);
                        }
                    }
                }
            }
            catch { }
        }

        void rfBinDataConvert()
        {
            byte dataOut;
            byte[] dataTmp = new byte[64];
            byte[] data = new byte[64];
            UInt32 count, dataLen = 0, wr = 0, rd = 0;
            bool startFlag = true;
            string strFolderNameTmp;

            strFolderNameTmp = strFolderName[2] + "\\rfInDataI-" + System.DateTime.Now.ToString("yyyyMMddTHHmmss") + ".bin";
            try
            {
                using (BinaryReader fpDataIn = new BinaryReader(new FileStream(strPathName[2], FileMode.Open, FileAccess.Read)))
                {
                    BinaryWriter fpDataOut = new BinaryWriter(new FileStream(strFolderNameTmp, FileMode.OpenOrCreate, FileAccess.Write));
                    Array.Clear(data, 0, 64);
                    while (true)
                    {
                        if (fpDataIn.PeekChar() == -1) break;
                        data[wr++] = fpDataIn.ReadByte();
                        if (wr >= 64) wr = 0;

                        if (wr > rd) dataLen = wr - rd;
                        else dataLen = wr + 64 - rd;
                        if (dataLen < 20) continue;

                        if (startFlag)
                        {
                            if (data[rd] == 'r')
                            {
                                for (int i = 0; i < 16; i++)
                                    dataTmp[i] = data[(rd + i) % 64];
                                if (string.Compare(dataTmp.ToString(), "rf rd start...\r\n") == 0)
                                {
                                    rd += 16; if (rd >= 64) rd = 0;
                                    startFlag = false;
                                    continue;
                                }
                            }
                            rd += 1; if (rd >= 64) rd = 0;
                            continue;
                        }

                        if (data[rd] == 'r')
                        {
                            for (int i = 0; i < 20; i++)
                                dataTmp[i] = data[(rd + i) % 64];
                            if (string.Compare(dataTmp.ToString(), "rf dataI rd end...\r\n") == 0)
                            {
                                rd += 20; if (rd >= 64) rd = 0;
                                fpDataOut.Close();
                                strFolderNameTmp = strFolderName[2] + "\\rfInDataQ-" + System.DateTime.Now.ToString("yyyyMMddTHHmmss") + ".bin";
                                fpDataOut = new BinaryWriter(new FileStream(strFolderNameTmp, FileMode.OpenOrCreate, FileAccess.Write));
                                continue;
                            }
                            else if (string.Compare(dataTmp.ToString(), "rf dataQ rd end...\r\n") == 0)
                            { 
                                rd += 20; if (rd >= 64) rd = 0;
                                //fpDataOut.Close();
                                //strFolderNameTmp = strFolderName[2] + "\\rfInDataI-" + System.DateTime.Now.ToString("yyyyMMddTHHmmss") + ".bin";
                                //fpDataOut = new BinaryWriter(new FileStream(strFolderNameTmp, FileMode.OpenOrCreate, FileAccess.Write));
                                continue;
                            }
                        }

                        for (count = 0; count < 4; count++)
                        {
                            dataOut = (byte)((data[rd] >> (byte)(6 - count * 2)) & 3);
                            fpDataOut.Write(dataTab[dataOut]);
                        }

                        rd++; if (rd >= 64) rd = 0;
                    }

                }


            }
            catch { }

        }

        private void btnStartConvert_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i ++)
            {
                if ((DataTypeflag & (1 << i)) == 0) continue;
                switch (i)
                {
                    case 0:
                        rfDataConvert();
                        break;
                    case 1:
                        rfBin2Bin();
                        break;
                    case 2:
                        rfBinDataConvert();
                        break;
                    default:
                        break;

                }
                DataTypeflag &= ~(1 << i);
            }
        }

        private void btnSelect1_Click(object sender, EventArgs e)
        {
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
                try
                {
                    int pos = ((Button)sender).TabIndex - btnSelect1.TabIndex;
                    strPathName[pos] = dialog.FileName.ToString();
                    switch (pos)
                    {
                        case 0:
                            textBox1.Text = strPathName[pos];       //显示文件路径到编辑框
                            break;
                        case 1:
                            textBox2.Text = strPathName[pos];       //显示文件路径到编辑框
                            break;
                        case 2:
                            textBox3.Text = strPathName[pos];       //显示文件路径到编辑框
                            break;
                        default:
                            break;
                    }
                    strFolderName[pos] = new DirectoryInfo(strPathName[pos]).Parent.FullName.ToString();

                    DataTypeflag |= (1 << pos);

                }
                catch
                { }
            }
        }

        private UInt16 crc16Check(byte[] buffer, int len)
        {
            int counter;
            UInt16 crc = 0;
            for (counter = 0; counter < len; counter++)
                crc = (UInt16)((crc << 8) ^ crc16Table[((crc >> 8) ^ buffer[counter]) & 0x00FF]);
            return crc;
        }

        private void btnCRC_Click(object sender, EventArgs e)
        {
            int len = richTextBoxCRCInput.Text.Length;
            string strData = richTextBoxCRCInput.Text;
            byte[] byteData = new byte[(len + 2) / 3];

            for (int i = 0; i < len; i += 3)
            {
                if (byte.TryParse(strData.Substring(i, 2), out byte result))
                    byteData[i / 3] = result;
            }

            UInt32 res = crc16Check(byteData, byteData.Length);

            richTextBoxCRCResult.Text = "0X" + res.ToString("X") ;
        }
    }
}
