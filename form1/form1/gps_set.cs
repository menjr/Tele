using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form1
{
    public partial class gps_set : Form
    {
        //在窗体上添加一个comboBox控件。然后使用comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());  或者
        private MainForm fm1;

        private void GetPortsName()
        {
            string[] portList = System.IO.Ports.SerialPort.GetPortNames();
            for (int i = 0; i < portList.Length; ++i)
            {
                string name = portList[i];
                GpsComName.Items.Add(name);
                //if(fm1.ClockComName==name)
                //{
                 //   GpsComName.SelectedText = name;
                //}
            }
        }
        public gps_set()
        {
            InitializeComponent();
            GetPortsName();
        }
        /// <summary>
        /// 初始化窗体，带参数设置（串口设置）
        /// </summary>
        /// <param name="mainfm"></param>
        public gps_set(MainForm mainfm)
        {
            fm1 = mainfm;
            InitializeComponent();
            GetPortsName();
            if(fm1.IsClockOpened)
            {
                button2.Text = "关闭串口";
            }else
            {
                button2.Text = "打开串口";
            }
            if(fm1.ClockOpenedName!="")
            {
                GpsComName.SelectedItem = fm1.ClockOpenedName;
            }
            if(fm1.GpsProtocoled!="")
            {
                GpsProtocol.Text = fm1.GpsProtocoled;
            }else
            {
                GpsProtocol.Text = "协议A";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 打开关闭串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (fm1.IsClockOpened)
            {
                bool opened = fm1.CloseGpsCom();
                if (!opened)
                {
                    MessageBox.Show("串口" + GpsComName.Text + "关闭失败！");
                }else
                {
                    MessageBox.Show("串口" + GpsComName.Text + "关闭成功！");
                }

            }
            else
            {
                if(GpsProtocol.Text!="")
                {
                    fm1.GpsProtocoled = GpsProtocol.Text;

                }else
                {
                    fm1.GpsProtocoled = "协议A";
                }
                fm1.GpsClockComInit(GpsComName.Text, 2048, 2048, 1, 1, 115200, 8, System.IO.Ports.Parity.None, System.IO.Ports.StopBits.One);
                bool opened = fm1.OpenGpsClockCom();
                if (opened)
                {
                    fm1.ClockOpenedName = GpsComName.Text;
                    MessageBox.Show("串口" + GpsComName.Text + "已打开");
                }
                else
                {
                    MessageBox.Show("无法打开串口" + GpsComName.Text);
                }
            }
            if (fm1.IsClockOpened)
            {
                button2.Text = "关闭串口";
            }
            else
            {
                button2.Text = "打开串口";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
