using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*定义类时C开头其他首字母大写
 定义枚举时e_形式，第一个小写，其他大写
 定义变量时，首字符小写，最好变量名加上类型名，int i_, struct struct_*/
namespace GnssView
{
    class CSonFormtInfo
    {
        public const int SON_WIN_ROW_NUM = 2;
        public const int SON_WIN_COL_NUM = 2;
    }

    /// <summary>
    /// MSS命令，C命令的子项目
    /// </summary>
    public enum e_mssItem
    {
        errRate     = 0,
        rdss        = 1,
        cold        = 2,
        warm        = 3,
        hot         = 4,
        range       = 5,
        timing      = 6,
        reAcq       = 7,
        raim        = 8,
        midDynamic  = 9,
        authTest     = 10,
    }

    /// <summary>
    /// 命令字头头
    /// </summary>
    public enum e_strHeadId
    {
        Ht1902      = 1,
        Msg         = 2,
        Gga         = 3,
        Gsa         = 4,
        Gsv         = 5,
        V21         = 6,
        Bbm         = 7,
        Acq         = 8,
        Intr        = 9,
        Pquit       = 10,
        Bsi         = 11,
        Ect         = 12,
        Rmc         = 13,
        update      = 14,
        pps         = 15,
        Ht103       = 16,
    }

    /* GNSS类型 */
    public enum  e_gnssType
    {
        L1CA        = 0,
        B1C,
        B3Q,
        B3I,
        B1A,
        B3A,
        B1I,
        B2A,
        G1,
        G2,
        E1OS,
    }

    /* V21命令 */
    public enum e_v21Cmd
    {
        RIS         = 0,
        MSS,
        RMO,
        PRD,
        ECS,
        CPM,
        SPM,
        STM,
    }


    class CResultLimitDef
    {
        public const int ACQ_COUNT_MAX              = 1;
        public const int THIS_EPOCH_CN0_DIFF        = 3;
        public const int THIS_EPOCH_PLD_DIFF        = 90;
        public const int THIS_EPOCH_CN0CORR_DIFF    = 3;
        public const int THIS_EPOCH_PLDCORR_DIFF    = 3;
        public const int THIS_EPOCH_CN0DATA_DIFF    = 3;
        public const int THIS_EPOCH_PLDDATA_DIFF    = 3;
    }

    class CCodeRateDef
    {
        public const int GPS_L1CA_CODE_FREQ         = 1023000;
        public const int GPS_L1C_CODE_FREQ          = 1023000;
        public const int GPS_L2CM_CODE_FREQ         = 511500;
        public const int GPS_L2CL_CODE_FREQ         = 511500;
        public const int GPS_L5_CODE_FREQ           = 10230000;

        public const int GLO_G1CA_CODE_FREQ         = 511000;
        public const int GLO_G2CA_CODE_FREQ         = 511000;

        public const int GAL_E1_CODE_FREQ           = 1023000;
        public const int GAL_E5A_CODE_FREQ          = 10230000;
        public const int GAL_E5B_CODE_FREQ          = 10230000;

        public const int BDS_B1I_CODE_FREQ          = 2046000;
        public const int BDS_B1C_CODE_FREQ          = 1023000;
        public const int BDS_B1A_CODE_FREQ          = 2046000;

        public const int BDS_B2A_CODE_FREQ          = 10230000;
        public const int BDS_B2B_CODE_FREQ          = 10230000;
        public const int BDS_B3I_CODE_FREQ          = 10230000;
        public const int BDS_B3Q_CODE_FREQ          = 10230000;
        public const int BDS_B3A_CODE_FREQ          = 10230000;
        public const int BDS_B3AE_CODE_FREQ         = 10230000;
    }

    class CEpochCountDef
    {
        public const double BD_GEO = 2;
        public const double BD_IGSO_MEO = 20;
    }

    class CCarryCountDef
    {
        public const double B3I = 4294967296.0;
        public const double B3Q = 65536.0;
    }
}
