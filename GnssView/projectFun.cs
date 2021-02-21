using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace GnssView
{
    class C_ProjectFun
    {
        /************************************************************************************************************
        函数功能：		判断是否为闰年

        输入参数：
				        year：				年
        输出参数：
				        BOOL：				闰年：TRUE，不是闰年：FALSE
        *************************************************************************************************************/
        public bool isLeapYear(UInt32 year)
        {
	        if ((year % 100) == 0)
	        {
		        if ((year % 400) == 0) return true;
		        else return false;
	        }
	        else
	        {
                if ((year % 4) == 0) return true;
                else return false;
	        }
        }

        /// <summary>
        ///函数功能：		接收机时间转化为UTC
        ///
        ///输入参数：
		///		        rcvrTime：				接收机时间
		///		        utcParam：              UTC参数
        ///
        ///输出参数：
		///		        utcTime：				UTC时间
        /// </summary>

        public void rcvrTimeToUtc(struct_rcvrTime_t rcvrTime, ref struct_utcTime_t utcTime)
        {
	        UInt32 year = 0, month = 0, day = 0;
	        UInt32 hour = 0, minute = 0;
	        UInt32 DaysOfSecond = 0;
	        UInt32 days = 0;
	        UInt32 i = 0;
	        double seconds = 0.0;
	        UInt32[] firstDayOfMonth = {0, 1, 32, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335};
            UInt32 deltaUtc = 4;
            UInt32 WEEKS_BD_OFFSET_GPS = 1356;                          /* BD和GPS时间差的秒数*/
            double SECONDS_IN_HOUR = 3600.0;							/* 一个小时的秒数 */
            double SECONDS_IN_DAY = 86400.0;							/* 一天的秒数 */

	        year = 1980;
            days = (WEEKS_BD_OFFSET_GPS + rcvrTime.weekNum) * 7;

	        /*leap seconds, 12, will be replace with params from subfrm 4 */
	        /* i.e. pUtcParam.deltaTLSF */
            seconds = rcvrTime.seconds - deltaUtc;

	        if (seconds < 0)
	        {
		        seconds += SECONDS_IN_DAY;
		        days --;
	        }

	        /* 一周的周内秒转化成天和秒 */
	        DaysOfSecond = (UInt32)(seconds / SECONDS_IN_DAY);	
	        seconds -= DaysOfSecond * SECONDS_IN_DAY;
	        days += DaysOfSecond;

	        if (days < 360)
	        {
		        // This program handles the date from Jan. 1, 1981 00:00:00.00 UTC
		        utcTime.year = 0;
		        utcTime.month = 0;
		        utcTime.day = 0;
		        utcTime.hour = 0;
		        utcTime.minute = 0;
		        utcTime.second = 0.0;
		        utcTime.valid = false;
		        return;
	        }

	        /* 计算年数 */
	        days -= 360;	// 1980 Jan. 6 to Dec. 31
	        year ++;		// next year

	        while (days > 366)
	        {
		        if (isLeapYear(year)) days -= 366;
		        else days -= 365;
		        year ++;
	        }

	        if (days == 366 && !isLeapYear(year))
	        {
		        days = 1;
		        year ++;
	        }

	        /* 计算月日时分秒 */ 
	        if (isLeapYear(year))
		        for (i = 3; i < 13; i ++) firstDayOfMonth[i] ++;	/* 如果是闰年，这从二月份每个月的起始日加一 */ 

	        /* 找出月份 */
	        for (i = 1; i < 13; i ++)
	        {
		        if (days < firstDayOfMonth[i]) break;
	        }
	        month = i - 1;

	        /* 日时分秒 */
	        day = days - firstDayOfMonth[month] + 1;
	        hour = (UInt32)(seconds / SECONDS_IN_HOUR);
	        seconds -= hour * SECONDS_IN_HOUR;
	        minute = (UInt32)seconds / 60;
	        seconds -= minute * 60.0;

	        /* 给UTC时间赋值 */
	        utcTime.year = year;
	        utcTime.month = month;
	        utcTime.day = day;
	        utcTime.hour = hour;
	        utcTime.minute = minute;
	        utcTime.second = seconds;
	        utcTime.valid = rcvrTime.weekValid;
	        utcTime.mse = rcvrTime.mse;
        }

        //截取字符串
        public void getStrFromStr(List<string> listData, byte[] bData, int len)
        {
            int startPos = 0;

            if (bData.Length < 1) return;
            if (len < 1) return;

            for (int i = 0; i < len; i++)
            {
                if (bData[i] != ',' && i != (len - 1) && bData[i] != '*')
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

                    if (bData[i] == '*') break;
                }
            }
        }
    }

    /// <summary>
    /// 设置系统时间 1
    /// </summary>
    public struct SYSTEMTIME
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMilliseconds;

        /// <summary>
        /// 从System.DateTime转换。
        /// </summary>
        /// <param name="time">System.DateTime类型的时间。</param>
        public void FromDateTime(DateTime time)
        {
            wYear = (ushort)time.Year;
            wMonth = (ushort)time.Month;
            wDayOfWeek = (ushort)time.DayOfWeek;
            wDay = (ushort)time.Day;
            wHour = (ushort)time.Hour;
            wMinute = (ushort)time.Minute;
            wSecond = (ushort)time.Second;
            wMilliseconds = (ushort)time.Millisecond;
        }
        /// <summary>
        /// 转换为System.DateTime类型。
        /// </summary>
        /// <returns></returns>
        public DateTime ToDateTime()
        {
            return new DateTime(wYear, wMonth, wDay, wHour, wMinute, wSecond, wMilliseconds);
        }
        /// <summary>
        /// 静态方法。转换为System.DateTime类型。
        /// </summary>
        /// <param name="time">SYSTEMTIME类型的时间。</param>
        /// <returns></returns>
        public static DateTime ToDateTime(SYSTEMTIME time)
        {
            return time.ToDateTime();
        }
    }
    /// <summary>
    /// 设置系统时间 2
    /// </summary>
    public class Win32API
    {
        [DllImport("Kernel32.dll")]
        public static extern bool SetLocalTime(ref SYSTEMTIME Time);
        [DllImport("Kernel32.dll")]
        public static extern void GetLocalTime(ref SYSTEMTIME Time);
    }

    class C_VerifyGroup
    {
        private uint[] tableCrc16 = new uint[256]{
	        0x0000, 0x1021, 0x2042, 0x3063, 0x4084, 0x50A5, 0x60C6, 0x70E7, 0x8108, 0x9129, 0xA14A, 0xB16B, 0xC18C, 0xD1AD, 0xE1CE, 0xF1EF,
	        0x1231, 0x0210, 0x3273, 0x2252, 0x52B5, 0x4294, 0x72F7, 0x62D6, 0x9339, 0x8318, 0xB37B, 0xA35A, 0xD3BD, 0xC39C, 0xF3FF, 0xE3DE,
	        0x2462, 0x3443, 0x0420, 0x1401, 0x64E6, 0x74C7, 0x44A4, 0x5485, 0xA56A, 0xB54B, 0x8528, 0x9509, 0xE5EE, 0xF5CF, 0xC5AC, 0xD58D,
	        0x3653, 0x2672, 0x1611, 0x0630, 0x76D7, 0x66F6, 0x5695, 0x46B4, 0xB75B, 0xA77A, 0x9719, 0x8738, 0xF7DF, 0xE7FE, 0xD79D, 0xC7BC,
	        0x48C4, 0x58E5, 0x6886, 0x78A7, 0x0840, 0x1861, 0x2802, 0x3823, 0xC9CC, 0xD9ED, 0xE98E, 0xF9AF, 0x8948, 0x9969, 0xA90A, 0xB92B,
	        0x5AF5, 0x4AD4, 0x7AB7, 0x6A96, 0x1A71, 0x0A50, 0x3A33, 0x2A12, 0xDBFD, 0xCBDC, 0xFBBF, 0xEB9E, 0x9B79, 0x8B58, 0xBB3B, 0xAB1A,
	        0x6CA6, 0x7C87, 0x4CE4, 0x5CC5, 0x2C22, 0x3C03, 0x0C60, 0x1C41, 0xEDAE, 0xFD8F, 0xCDEC, 0xDDCD, 0xAD2A, 0xBD0B, 0x8D68, 0x9D49,
	        0x7E97, 0x6EB6, 0x5ED5, 0x4EF4, 0x3E13, 0x2E32, 0x1E51, 0x0E70, 0xFF9F, 0xEFBE, 0xDFDD, 0xCFFC, 0xBF1B, 0xAF3A, 0x9F59, 0x8F78,
	        0x9188, 0x81A9, 0xB1CA, 0xA1EB, 0xD10C, 0xC12D, 0xF14E, 0xE16F, 0x1080, 0x00A1, 0x30C2, 0x20E3, 0x5004, 0x4025, 0x7046, 0x6067,
	        0x83B9, 0x9398, 0xA3FB, 0xB3DA, 0xC33D, 0xD31C, 0xE37F, 0xF35E, 0x02B1, 0x1290, 0x22F3, 0x32D2, 0x4235, 0x5214, 0x6277, 0x7256,
	        0xB5EA, 0xA5CB, 0x95A8, 0x8589, 0xF56E, 0xE54F, 0xD52C, 0xC50D, 0x34E2, 0x24C3, 0x14A0, 0x0481, 0x7466, 0x6447, 0x5424, 0x4405,
	        0xA7DB, 0xB7FA, 0x8799, 0x97B8, 0xE75F, 0xF77E, 0xC71D, 0xD73C, 0x26D3, 0x36F2, 0x0691, 0x16B0, 0x6657, 0x7676, 0x4615, 0x5634,
	        0xD94C, 0xC96D, 0xF90E, 0xE92F, 0x99C8, 0x89E9, 0xB98A, 0xA9AB, 0x5844, 0x4865, 0x7806, 0x6827, 0x18C0, 0x08E1, 0x3882, 0x28A3,
	        0xCB7D, 0xDB5C, 0xEB3F, 0xFB1E, 0x8BF9, 0x9BD8, 0xABBB, 0xBB9A, 0x4A75, 0x5A54, 0x6A37, 0x7A16, 0x0AF1, 0x1AD0, 0x2AB3, 0x3A92,
	        0xFD2E, 0xED0F, 0xDD6C, 0xCD4D, 0xBDAA, 0xAD8B, 0x9DE8, 0x8DC9, 0x7C26, 0x6C07, 0x5C64, 0x4C45, 0x3CA2, 0x2C83, 0x1CE0, 0x0CC1,
	        0xEF1F, 0xFF3E, 0xCF5D, 0xDF7C, 0xAF9B, 0xBFBA, 0x8FD9, 0x9FF8, 0x6E17, 0x7E36, 0x4E55, 0x5E74, 0x2E93, 0x3EB2, 0x0ED1, 0x1EF0
        };

        private void arrayMoveBit(uint[] pBuff, int startPod, int len)
        {
            for (int i = 0; i < (len - startPod) / 32; i++)
            {
                pBuff[i] = pBuff[startPod / 32] << (startPod % 32);
                if (pBuff.Length > (startPod / 32 + 1))
                    pBuff[i] |= pBuff[startPod / 32 + 1] >> (32 - startPod % 32);
            }
        
        }

        /*计算CRC16的校验*/
        public uint getCrc16Check(uint[] pBuff, int startPod, int len)
        {

            int lenOfChar = 0, bitOfChar = 0, bitNum = 0, i = 0;
            uint charTemp = 0, crcResult = 0;

            if (len == 0) return 0;

            arrayMoveBit(pBuff, startPod, len);

            lenOfChar = (len - startPod) >> 3;	/*一共包含多少个整字节*/
            bitOfChar = (len - startPod) & 7;	/*不足一个字节的剩余bit*/

            /*不足一个字节时，直接返回结果*/
            if (lenOfChar == 0)
            {
                crcResult = tableCrc16[(pBuff[0] >> (32 - bitOfChar)) & 0xFF];
                return crcResult;
            }
            if (bitOfChar > 0) lenOfChar++;

            for (i = 0; i < lenOfChar; i++)
            {
                /*字节内的有效bit数*/
                if (i == (lenOfChar - 1)) bitNum = bitOfChar > 0 ? bitOfChar : 8;
                else bitNum = 8;
                /*从高位开始取一个字节*/
                charTemp = (pBuff[i >> 2] >> ((3 - (i & 3)) << 3)) & 0xFF;
                charTemp >>= (8 - bitNum);
                /*查表结果与当前字节异或*/
                crcResult = (crcResult << bitNum) ^ tableCrc16[((crcResult >> (16 - bitNum) & 0xFF) ^ charTemp) & 0xFF];
                /*将高位全部清空，不足一个字节右移取值时不会取到高位的数值（校验表会取错），都是整字节的情况不会出错*/
                crcResult &= 0xFFFF;
            }

            return crcResult & 0xFFFF;
        }
    }
    
}
