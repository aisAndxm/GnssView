using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GnssView
{
    public class uartVar
    {
        public int rd;
        public int wr;
        public byte[] buf;
        public const int MSG_MAX_LEN = 1024000;//(1000 * 1024);
        public int rdOut;
        public int rdSave;

        public void Clear()
        {
            rd = 0;
            wr = 0;
            rdOut = 0;
            rdSave = 0;
        }
    }

    public class ggaMsg
    {
        public double utcTime;
        public double lat;
        public string latMark;
        public double lon;
        public string lonMark;
        public string flag;
        public int svNum;
        public double hdop;
        public double alt;

        public double acc3D;
        public int ggaCount;
        public bool valid;

        public void init0Var()
        {
            utcTime = 0;
            lat = 0;
            latMark = "N";
            lon = 0;
            lonMark = "E";
            flag = "0";
            svNum = 0;
            hdop = 0;
            alt = 0;
            valid = false;
        }
    }

    public class gsaMsg
    {
        public int svNum;
        public int type;
        public int[] svidId = new int[12];
        public double pdop;
        public double hdop;
        public double vdop;
    }

    public class gsvMsg
    {
        public int svid;
        public int type;
        public int el;//仰角
        public int az;//方位角
        public int cn0;//载噪比
        public int isInuse;//是否参与定位
        public int isInCh;//是否存在
    }

    public class navInfo
    {
        public float ggaCurrentLat = 0.0f;
        public float ggaCurrentLon = 0.0f;
        public float ggaCurrentUtc = 0.0f;
        public float ggaCurrent3D = 0.0f;
        public float ggaTotalCnt = 0.0f;
    }

    public class posInfo
    {
        public double lat;
        public double lon;
        public double alt;
    }

    /*UTC时间定义*/
    public class struct_utcTime_t
    {
        public UInt32 year;
        public UInt32 month;
        public UInt32 day;
        public UInt32 hour;
        public UInt32 minute;
        public double second;
        public double mse;		/* 与接收机时间的均方差一致，单位为us */
        public bool valid;		/* 日期的有效标志 */
    }

    /*接收机时间定义*/
    public class struct_rcvrTime_t
    {
        public double seconds;
        public double mse;		    /* 周秒的误差均方差，单位为us */
        public UInt32 weekNum;        /* 接收机的周 */
        public bool weekValid;
    }

    /*接收机meas信息定义*/
    public class struct_mearMsg_t
    {
        public char svid;
        public string type;
        public char state;
        public char cn0;
        public char pld;

        public string cType;
        public char cState;
        public char cCn0;
        public char cPld;
    }

    public class struct_baseband_t
    {
        public int cn0Corr;
        public int pldCorr;
        public int cn0Data;
        public int pldData;
    }

    public class struct_qtpResultFlag_t
    {
        public int acqStatus;
        public double firstTime;
        public int svidCmp;
        public int trkStatus;
        public int pld;
        public int cn0Corr;
        public int pldCorr;
        public int cn0Data;
        public int pldData;
        public double psrAcc;
        public double carrAcc;
    }

    public enum ShiftSymOne
    {
        bit0 = 0x0001,
        bit1 = 0x0002,
        bit2 = 0x0004,
        bit3 = 0x0008,
        bit4 = 0x0010,
        bit5 = 0x0020,
        bit6 = 0x0040,
        bit7 = 0x0080,
    };

    public enum ShiftSymZero
    {
        bit0 = 0xfe,
        bit1 = 0xfd,
        bit2 = 0xfb,
        bit3 = 0xf7,
        bit4 = 0xef,
        bit5 = 0xdf,
        bit6 = 0xbf,
        bit7 = 0x7f,
    };

    /*地心地固直角坐标系定义*/
    public struct struct_ecef_coord
    {
        public double x;
        public double y;
        public double z;
    };

    /*地心地固大地坐标系定义*/
    public struct struct_lla_coord
    {
        public double lat;
        public double lon;
        public double alt;
    };

    /*地心地固站心坐标系定义*/
    public struct struct_enu_coord
    {
        public double e;
        public double n;
        public double u;
    };

}
