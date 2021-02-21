using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;

namespace GnssView
{
    public class DrawingCurve
    {
        /// <summary>
        /// 画曲线图
        /// </summary>
        /// <param name="dsParameter"></param>
        /// <returns></returns>
        //public override Bitmap DrawImage(DataSet dsParameter)
        //{
        //    Curve2D cuv2D = new Curve2D();
        //    cuv2D.Fit();
        //    return cuv2D.CreateImage();
        //}

        public Bitmap DrawImage(Size board, List<float> keys, List<float> values)
        {
            Curve2D cuv2D = new Curve2D();
            cuv2D.Width = board.Width;
            cuv2D.Height = board.Height;
            if (keys.Count > 1)
            {
                cuv2D.Keys = keys;
                cuv2D.Values = values;
            }
            cuv2D.Fit();
            return cuv2D.CreateImage();
        }
    }
    public class Curve2D
    {
        private Graphics objGraphics; //Graphics 类提供将对象绘制到显示设备的方法
        private Bitmap objBitmap; //位图对象
        private float fltWidth = 480; //图像宽度
        private float fltHeight = 248; //图像高度
        private float fltXSlice = 80; //X轴刻度宽度
        private float fltYSlice = 50; //Y轴刻度宽度
        private float fltXSliceLen = 10; //X轴刻度线长度
        private float fltYSliceLen = 10; //Y轴刻度线长度
        private float fltXSliceValue = 20; //X轴刻度的数值宽度
        private float fltYSliceValue = 20; //Y轴刻度的数值宽度
        private float fltXSliceBegin = 0; //X轴刻度开始值
        private float fltYSliceBegin = 0; //Y轴刻度开始值
        private float fltTension = 0.0f;
        private string strTitle = "3D位置精度"; //标题
        private string strXAxisText = "点数"; //X轴说明文字
        private string strYAxisText = "精度"; //Y轴说明文字
        private List<float> fltsKeys = new List<float>();// { 10f, 20f, 30f, 40f, 50f, 60f, 70f, 80f, 90f, 100f }; //键
        private List<float> fltsValues = new List<float>();// { 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f }; //值
        private Color clrBgColor = Color.Snow; //背景色
        private Color clrTextColor = Color.Black; //文字颜色
        private Color clrBorderColor = Color.Black; //整体边框颜色
        private Color clrAxisColor = Color.Black; //轴线颜色
        private Color clrAxisTextColor = Color.Black; //轴说明文字颜色
        private Color clrSliceTextColor = Color.Black; //刻度文字颜色
        private Color clrSliceColor = Color.Black; //刻度颜色
        private Color[] clrsCurveColors = new Color[] { Color.Red, Color.Blue }; //曲线颜色
        private float fltXSpace = 100f; //图像左右距离边缘距离
        private float fltYSpace = 50f; //图像上下距离边缘距离
        private int intFontSize = 8; //字体大小号数
        private float fltXRotateAngle = 0f; //X轴文字旋转角度
        private float fltYRotateAngle = 0f; //Y轴文字旋转角度
        private int intCurveSize = 2; //曲线线条大小
        private int intFontSpace = 0; //intFontSpace 是字体大小和距离调整出来的一个比较适合的数字
        #region 公共属性
        /// <summary>
        /// 图像的宽度
        /// </summary>
        public float Width
        {
            set
            {
                if (value < 100)
                {
                    fltWidth = 100;
                }
                else
                {
                    fltWidth = value;
                }
            }
            get
            {
                if (fltWidth <= 100)
                {
                    return 100;
                }
                else
                {
                    return fltWidth;
                }
            }
        }
        /// <summary>
        /// 图像的高度
        /// </summary>
        public float Height
        {
            set
            {
                if (value < 100)
                {
                    fltHeight = 100;
                }
                else
                {
                    fltHeight = value;
                }
            }
            get
            {
                if (fltHeight <= 100)
                {
                    return 100;
                }
                else
                {
                    return fltHeight;
                }
            }
        }
        /// <summary>
        /// X轴刻度宽度
        /// </summary>
        public float XSlice
        {
            set { fltXSlice = value; }
            get { return fltXSlice; }
        }
        /// <summary>
        /// Y轴刻度宽度
        /// </summary>
        public float YSlice
        {
            set { fltYSlice = value; }
            get { return fltYSlice; }
        }
        /// <summary>
        /// X轴刻度线长度
        /// </summary>
        public float XSliceLen
        {
            set { fltXSliceLen = value; }
            get { return fltXSliceLen; }
        }
        /// <summary>
        /// Y轴刻度线长度
        /// </summary>
        public float YSliceLen
        {
            set { fltYSliceLen = value; }
            get { return fltYSliceLen; }
        }
        /// <summary>
        /// X轴刻度的数值宽度
        /// </summary>
        public float XSliceValue
        {
            set { fltXSliceValue = value; }
            get { return fltXSliceValue; }
        }
        /// <summary>
        /// Y轴刻度的数值宽度
        /// </summary>
        public float YSliceValue
        {
            set { fltYSliceValue = value; }
            get { return fltYSliceValue; }
        }
        /// <summary>
        /// X轴刻度开始值
        /// </summary>
        public float XSliceBegin
        {
            set { fltXSliceBegin = value; }
            get { return fltXSliceBegin; }
        }
        /// <summary>
        /// Y轴刻度开始值
        /// </summary>
        public float YSliceBegin
        {
            set { fltYSliceBegin = value; }
            get { return fltYSliceBegin; }
        }
        /// <summary>
        /// 张力系数
        /// </summary>
        public float Tension
        {
            set
            {
                if (value < 0.0f && value > 1.0f)
                {
                    fltTension = 0.5f;
                }
                else
                {
                    fltTension = value;
                }
            }
            get
            {
                return fltTension;
            }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { strTitle = value; }
            get { return strTitle; }
        }
        /// <summary>
        /// 键，X轴数据
        /// </summary>
        public List<float> Keys
        {
            set { fltsKeys = value; }
            get { return fltsKeys; }
        }
        /// <summary>
        /// 值，Y轴数据
        /// </summary>
        public List<float> Values
        {
            set { fltsValues = value; }
            get { return fltsValues; }
        }
        /// <summary>
        /// 背景色
        /// </summary>
        public Color BgColor
        {
            set { clrBgColor = value; }
            get { return clrBgColor; }
        }
        /// <summary>
        /// 文字颜色
        /// </summary>
        public Color TextColor
        {
            set { clrTextColor = value; }
            get { return clrTextColor; }
        }
        /// <summary>
        /// 整体边框颜色
        /// </summary>
        public Color BorderColor
        {
            set { clrBorderColor = value; }
            get { return clrBorderColor; }
        }
        /// <summary>
        /// 轴线颜色
        /// </summary>
        public Color AxisColor
        {
            set { clrAxisColor = value; }
            get { return clrAxisColor; }
        }
        /// <summary>
        /// X轴说明文字
        /// </summary>
        public string XAxisText
        {
            set { strXAxisText = value; }
            get { return strXAxisText; }
        }
        /// <summary>
        /// Y轴说明文字
        /// </summary>
        public string YAxisText
        {
            set { strYAxisText = value; }
            get { return strYAxisText; }
        }
        /// <summary>
        /// 轴说明文字颜色
        /// </summary>
        public Color AxisTextColor
        {
            set { clrAxisTextColor = value; }
            get { return clrAxisTextColor; }
        }
        /// <summary>
        /// 刻度文字颜色
        /// </summary>
        public Color SliceTextColor
        {
            set { clrSliceTextColor = value; }
            get { return clrSliceTextColor; }
        }
        /// <summary>
        /// 刻度颜色
        /// </summary>
        public Color SliceColor
        {
            set { clrSliceColor = value; }
            get { return clrSliceColor; }
        }
        /// <summary>
        /// 曲线颜色
        /// </summary>
        public Color[] CurveColors
        {
            set { clrsCurveColors = value; }
            get { return clrsCurveColors; }
        }
        /// <summary>
        /// X轴文字旋转角度
        /// </summary>
        public float XRotateAngle
        {
            get { return fltXRotateAngle; }
            set { fltXRotateAngle = value; }
        }
        /// <summary>
        /// Y轴文字旋转角度
        /// </summary>
        public float YRotateAngle
        {
            get { return fltYRotateAngle; }
            set { fltYRotateAngle = value; }
        }
        /// <summary>
        /// 图像左右距离边缘距离
        /// </summary>
        public float XSpace
        {
            get { return fltXSpace; }
            set { fltXSpace = value; }
        }
        /// <summary>
        /// 图像上下距离边缘距离
        /// </summary>
        public float YSpace
        {
            get { return fltYSpace; }
            set { fltYSpace = value; }
        }
        /// <summary>
        /// 字体大小号数
        /// </summary>
        public int FontSize
        {
            get { return intFontSize; }
            set { intFontSize = value; }
        }
        /// <summary>
        /// 曲线线条大小
        /// </summary>
        public int CurveSize
        {
            get { return intCurveSize; }
            set { intCurveSize = value; }
        }
        #endregion
        /// <summary>
        /// 自动根据参数调整图像大小
        /// </summary>
        public void Fit()
        {
            int intXSliceCount = 0;
            int intYSliceCount = 0;

            //计算字体距离
            intFontSpace = FontSize -1;
            //计算图像边距
            //float fltSpace = Math.Min(Width / 10, Height / 10);
            //XSpace = fltSpace;
            //YSpace = fltSpace;

            if (XSpace <= 0 || YSpace <= 0) return;

            intXSliceCount = (int)Math.Floor((Width - 2 * XSpace) / XSlice);
            intYSliceCount = (int)Math.Floor((Height - 2 * YSpace) / YSlice);
            if (intXSliceCount <= 0 || intYSliceCount <= 0) return;

            if (Keys.Count >= 1)
            {
                //计算X轴刻度宽度和Y轴刻度开始值
                float fltMaxKey = XSliceBegin = Keys[0];
                for (int i = 0; i < Keys.Count; i++)
                {
                    if (Keys[i] < XSliceBegin)
                    {
                        XSliceBegin = Keys[i];
                    }

                    if (Keys[i] > fltMaxKey)
                    {
                        fltMaxKey = Keys[i];
                    }
                }
                if (fltMaxKey == XSliceBegin) fltMaxKey += 1;
                XSliceValue = (int)(Math.Ceiling((fltMaxKey - XSliceBegin) / intXSliceCount));

                //计算Y轴刻度宽度和Y轴刻度开始值
                float fltMaxValue = YSliceBegin = Values[0];

                for (int i = 0; i < Values.Count; i++)
                {
                    if (Values[i] < YSliceBegin)
                    {
                        YSliceBegin = Values[i];
                    }

                    if (Values[i] > fltMaxValue)
                    {
                        fltMaxValue = Values[i];
                    }
                }

                if (fltMaxValue == YSliceBegin) fltMaxValue += 1;
                YSliceValue = (fltMaxValue - YSliceBegin ) / intYSliceCount;

            }
        }
        /// <summary>
        /// 生成图像并返回bmp图像对象
        /// </summary>
        /// <returns></returns>
        public Bitmap CreateImage()
        {
            InitializeGraph();
            int intKeysCount = Keys.Count;
            int intValuesCount = Values.Count;
            if (intKeysCount <= 0 || intValuesCount <= 0 || intValuesCount != intKeysCount) return objBitmap;

            DrawContent(ref objGraphics, clrsCurveColors[1]);

            return objBitmap;
        }
        /// <summary>
        /// 初始化和填充图像区域，画出边框，初始标题
        /// </summary>
        private void InitializeGraph()
        {
            //根据给定的高度和宽度创建一个位图图像
            objBitmap = new Bitmap((int)Width, (int)Height);
            //从指定的 objBitmap 对象创建 objGraphics 对象 (即在objBitmap对象中画图)
            objGraphics = Graphics.FromImage(objBitmap);
            //根据给定颜色(LightGray)填充图像的矩形区域 (背景)
            //objGraphics.DrawRectangle(new Pen(BorderColor, 1), 0, 0, Width - 1, Height - 1); //画边框
            objGraphics.FillRectangle(new SolidBrush(BgColor), 1, 1, Width - 2, Height - 2); //填充边框
            //画X轴,注意图像的原始X轴和Y轴计算是以左上角为原点，向右和向下计算的
            float fltX1 = XSpace;
            float fltY1 = Height - YSpace;
            float fltX2 = Width - XSpace;
            float fltY2 = fltY1;
            objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), fltX1, fltY1, fltX2, fltY2);
            //画Y轴
            fltX1 = XSpace;
            fltY1 = Height - YSpace;
            fltX2 = XSpace;
            fltY2 = YSpace;
            objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), fltX1, fltY1, fltX2, fltY2);
            //初始化轴线说明文字
            SetAxisText(ref objGraphics);
            //初始化X轴上的刻度和文字
            SetXAxis(ref objGraphics);
            //初始化Y轴上的刻度和文字
            SetYAxis(ref objGraphics);
            //初始化标题
            CreateTitle(ref objGraphics);
        }
        /// <summary>
        /// 初始化轴线说明文字
        /// </summary>
        /// <param name="objGraphics"></param>
        private void SetAxisText(ref Graphics objGraphics)
        {
            float fltX = Width - XSpace + intFontSpace;
            float fltY = Height - YSpace - intFontSpace;
            objGraphics.DrawString(XAxisText, new Font("宋体", FontSize), new SolidBrush(AxisTextColor), fltX, fltY);
            fltX = XSpace;
            fltY = YSpace - 2 * intFontSpace;
            objGraphics.DrawString(YAxisText, new Font("宋体", FontSize), new SolidBrush(AxisTextColor), fltX, fltY);
        }
        /// <summary>
        /// 初始化X轴上的刻度和文字
        /// </summary>
        /// <param name="objGraphics"></param>
        private void SetXAxis(ref Graphics objGraphics)
        {
            float fltX1 = XSpace;
            float fltY1 = Height - YSpace;
            float fltX2 = Width - XSpace;
            float fltY2 = YSpace;
            int iCount = 0;
            float Scale = 0;
            int iSliceCount = 1;
            float iWidth = ((Width - 2 * XSpace) / XSlice) * 50; //将要画刻度的长度分段，并乘以50，以10为单位画刻度线。
            string strSliceText = string.Empty;
            strSliceText = Math.Round(XSliceBegin, 4).ToString("f4");
            objGraphics.TranslateTransform(fltX1, fltY1 + XSliceLen * 2f); //平移图像(原点)
            objGraphics.RotateTransform(XRotateAngle, MatrixOrder.Prepend); //旋转图像
            objGraphics.DrawString(strSliceText, new Font("宋体", FontSize), new SolidBrush(SliceTextColor), 0, 0);
            objGraphics.ResetTransform(); //重置图像
            for (int i = 0; i <= iWidth; i += 10)
            {
                Scale = i * XSlice / 50; //即(i / 10) * (YSlice / 5)，将每个刻度分五部分画，但因为i以10为单位，得除以10
                if (iCount == 5)
                {
                    objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor)), fltX1 + Scale, fltY1 + XSliceLen * 1.5f, fltX1 + Scale, fltY1 - XSliceLen * 1.5f);
                    //画网格虚线
                    Pen penDashed = new Pen(new SolidBrush(AxisColor));
                    penDashed.DashStyle = DashStyle.Dash;
                    objGraphics.DrawLine(penDashed, fltX1 + Scale, fltY1 - XSliceLen * 1.5f, fltX1 + Scale, fltY2);
                    //这里显示Y轴刻度
                    strSliceText = Math.Round(XSliceValue * iSliceCount + XSliceBegin, 4).ToString("f4");
                    objGraphics.TranslateTransform(fltX1 + Scale, fltY1 + XSliceLen * 2f); //平移图像(原点)
                    objGraphics.RotateTransform(XRotateAngle, MatrixOrder.Prepend); //旋转图像
                    objGraphics.DrawString(strSliceText, new Font("宋体", FontSize), new SolidBrush(SliceTextColor), 0, 0);
                    objGraphics.ResetTransform(); //重置图像
                    iCount = 0;
                    iSliceCount++;
                }
                else
                {
                    objGraphics.DrawLine(new Pen(new SolidBrush(SliceColor)), fltX1 + Scale, fltY1 + XSliceLen, fltX1 + Scale, fltY1 - XSliceLen);
                }
                iCount++;
            }
        }
        /// <summary>
        /// 初始化Y轴上的刻度和文字
        /// </summary>
        /// <param name="objGraphics"></param>
        private void SetYAxis(ref Graphics objGraphics)
        {
            float fltX1 = XSpace;
            float fltY1 = Height - YSpace;
            float fltX2 = Width - XSpace;
            float fltY2 = YSpace;
            int iCount = 0;
            float Scale = 0;
            int iSliceCount = 1;
            float iHeight = ((Height - 2 * YSpace) / YSlice) * 50; //将要画刻度的长度分段，并乘以50，以10为单位画刻度线。
            string strSliceText = string.Empty;
            strSliceText = Math.Round(YSliceBegin, 4).ToString("f4");
            objGraphics.TranslateTransform(XSpace - intFontSpace * strSliceText.Length - YSliceLen, fltY1); //平移图像(原点)
            objGraphics.RotateTransform(YRotateAngle, MatrixOrder.Prepend); //旋转图像
            objGraphics.DrawString(strSliceText, new Font("宋体", FontSize), new SolidBrush(SliceTextColor), 0, 0);
            objGraphics.ResetTransform(); //重置图像
            for (int i = 0; i <= iHeight; i += 10)
            {
                Scale = i * YSlice / 50; //即(i / 10) * (YSlice / 5)，将每个刻度分五部分画，但因为i以10为单位，得除以10
                if (iCount == 5)
                {
                    objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor)), fltX1 - YSliceLen * 1.5f, fltY1 - Scale, fltX1 + YSliceLen * 1.5f, fltY1 - Scale);
                    //画网格虚线
                    Pen penDashed = new Pen(new SolidBrush(AxisColor));
                    penDashed.DashStyle = DashStyle.Dash;
                    objGraphics.DrawLine(penDashed, fltX1 + YSliceLen * 1.5f, fltY1 - Scale, fltX2, fltY1 - Scale);
                    //这里显示Y轴刻度
                    strSliceText = Math.Round(YSliceValue * iSliceCount + YSliceBegin, 4).ToString("f4");
                    objGraphics.TranslateTransform(XSpace - intFontSpace * strSliceText.Length - YSliceLen, fltY1 - Scale); //平移图像(原点)
                    objGraphics.RotateTransform(YRotateAngle, MatrixOrder.Prepend); //旋转图像
                    objGraphics.DrawString(strSliceText, new Font("宋体", FontSize), new SolidBrush(SliceTextColor), 0, 0);
                    objGraphics.ResetTransform(); //重置图像
                    iCount = 0;
                    iSliceCount++;
                }
                else
                {
                    objGraphics.DrawLine(new Pen(new SolidBrush(SliceColor)), fltX1 - YSliceLen, fltY1 - Scale, fltX1 + YSliceLen, fltY1 - Scale);
                }
                iCount++;
            }
        }
        /// <summary>
        /// 画曲线
        /// </summary>
        /// <param name="objGraphics"></param>
        private void DrawContent(ref Graphics objGraphics, Color clrCurrentColor)
        {
            Pen CurvePen = new Pen(clrCurrentColor, CurveSize);
            PointF[] CurvePointF = new PointF[Keys.Count];
            float keys = 0;
            float values = 0;
            for (int i = 0; i < Keys.Count; i++)
            {
                keys = XSpace + XSlice * ((Keys[i] - XSliceBegin) / XSliceValue);
                values = (Height - YSpace) - YSlice * ((Values[i] - YSliceBegin) / YSliceValue);
                CurvePointF[i] = new PointF(keys, values);
            }

            objGraphics.DrawCurve(CurvePen, CurvePointF, Tension);
        }
        /// <summary>
        /// 初始化标题
        /// </summary>
        /// <param name="objGraphics"></param>
        private void CreateTitle(ref Graphics objGraphics)
        {
            objGraphics.DrawString(Title, new Font("宋体", FontSize), new SolidBrush(TextColor), new Point((int)(Width - XSpace) - intFontSpace * Title.Length, (int)(YSpace - 2 * intFontSpace)));
        }
    }
}