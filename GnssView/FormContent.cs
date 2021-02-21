using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GnssView
{
    public partial class FormContent : Form
    {
        public FormContent()
        {
            InitializeComponent();
        }

        public void history()
        {
            textBoxContent.Text = "~~~~更新历史~~~~\r\n" + 
          "GnssView V2.3.0.1 20201107\r\n~~1、修改窗体覆盖bug\r\n" +
          "GnssView V2.3.0.2 20201109\r\n~~1、添加接收BIN的ID校验\r\n~~2、修改无握手模式清状态标志bug\r\n" +
          "GnssView V2.3.0.3 20201110\r\n~~1、添加提示信息\r\n" +
          "GnssView V2.3.0.4 20201110\r\n~~1、打开双缓冲\r\n~~2、添加接收帧号检测选择功能\r\n~~3、修改保存文件\r\n" +
          "GnssView V2.3.0.5 20201110\r\n~~1、添加12命令判断\r\n" +
          "GnssView V2.3.0.6 20201110\r\n~~1、更新界面改成中文\r\n~~2、增加静默传输间隔\r\n"+
          "GnssView V2.3.0.7 20201111\r\n~~1、自动连接上次连接串口\r\n~~2、说明文档取消选中状态\r\n" +
          "GnssView V2.3.0.8 20201112\r\n~~1、修改VIEW界面使用更新为Chart\r\n" +
          "GnssView V2.3.0.9 20201116\r\n~~1、修改不等待烧写flash的bug\r\n" +
          "GnssView V2.3.1.1 20201215\r\n~~1、添加加载功能\r\n" +
          "GnssView V2.3.1.2 20201216\r\n~~1、修改加载功能\r\n" +
          "GnssView V2.3.1.3 20201231\r\n~~1、修改载噪比图形间隔\r\n" + 
          "GnssView V2.3.2.0 20200112\r\n~~1、加载功能修复完毕，当前软件各项功能均能正常使用\r\n" +
          "GnssView V2.4.0.1 20200120\r\n~~1、添加加载进度条\r\n~~2、修改水平界面bug\r\n" +
          "GnssView V2.4.0.5 20200208\r\n~~1、添加103项目\r\n~~2、整体更新到VS2019+20.3\r\n~~3、其他部分进行优化微调\r\n"; 

            textBoxContent.SelectionStart = textBoxContent.SelectionLength;
        }
    }
}
