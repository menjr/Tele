using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.Net.Sockets;
using System.Net;

namespace form1
{
    
    public partial class MainForm : Form
    {

        /// <summary>
        /// SOCKET 定义变量
        /// </summary>
        public static Socket socket_serve;

        public static bool socketrunning = false;
        public static short socket_port;
        public static Thread socket_thread;
        public static char []recv_buffer = new char [100];
        public static char []send_buffer = new char [1000];
        public static short send_size = 0;

        /// <summary>
        /// tele和cap的串口号等初始化常量
        /// </summary>
        public short m_tele_comport = 3;
        public short m_cap_comport = 1;
        public float axis_pos_ha; //ha位置坐标
        public float axis_pos_dec; //dec位置坐标
        public float axis_posremain_ha;
        public float axis_posremain_dec;

        public float axis_error_ha;//限位检查ha坐标
        public float axis_error_dec;//限位检查dec坐标
        public float m_telez_ha = 229630.00F;
        public float m_telez_dec = 797450.00F;
        public bool m_tele_connected;//是否连接望远镜
        public bool m_cap_connected;//是否连接圆顶
        public bool homestatus_ha;// HA home Status状态
        public bool homestatus_dec;// DEC home Status状态


        public int tele_status = -2;

        /// <summary>
        /// GPS时钟全局变量
        /// </summary>
        public string ClockOpenedName;//已经选择的串口
        public bool IsClockOpened;//串口是否打开
        public string GpsProtocoled;//选择的串口解析协议类型

        /// <summary>
        /// 子窗体变量定义
        /// </summary>
        private tele_set tele_form;
        private gps_set gps_form =new gps_set();
        private exp_set exp_form =new exp_set();
        private tele_param param_form =new tele_param();
        private set_cap cap_form = new set_cap();
        /// <summary>
        /// 更新位置线程
        /// </summary>
        public Thread updatepos;

        /// <summary>
        /// 找零线程
        /// </summary>
        public Thread clibzero_thread;

        private object TeleLock = new Object();//望远镜操作互斥锁（位置坐标）

        

        public MainForm()
        {
            InitializeComponent();
            //updatepos = new Thread(new ThreadStart(thread_func_updatepos));           
            FormClosing += new FormClosingEventHandler(My_FormClosing);
        }

        /// <summary>
        /// 关闭窗体检查线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void My_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updatepos!=null)
            {
                if(updatepos.IsAlive)
                {
                    updatepos.Abort();
                }
            }
            if (m_cap.IsAccessible)
            {
                m_cap.DoAbort();
            }
            if (m_telescope.IsAccessible)
            {
                m_telescope.DoAbort();
            }

        }

        /// <summary>
        /// GPS串口初始化
        /// </summary>
        /// <param name="PortName">串口名</param>
        /// <param name="InBuff">收缓存</param>
        /// <param name="OutBuff">发缓存</param>
        /// <param name="InputMode"></param>
        /// <param name="RTreshold"></param>
        /// <param name="BRT">波特率</param>
        /// <param name="DataBits">数据长度</param>
        /// <param name="Parity">奇偶校验</param>
        /// <param name="StopBits">停止位</param>
        public void GpsClockComInit(string PortName, int InBuff,int OutBuff,int InputMode,int RTreshold,int BRT, int DataBits, Parity ParitySet,StopBits StopBitsSet)
        {
            GpsCom.PortName = PortName;
            GpsCom.ReadBufferSize = InBuff;
            GpsCom.WriteBufferSize = OutBuff;
            GpsCom.ReceivedBytesThreshold = RTreshold;
            GpsCom.BaudRate = BRT;
            GpsCom.DataBits = DataBits;
            GpsCom.Parity = ParitySet;
            GpsCom.StopBits = StopBitsSet;
            if(GpsProtocoled=="协议B")
            {
                GpsCom.DataReceived += new SerialDataReceivedEventHandler(GpsClock_DataReceivedB);
            }else
            {
                GpsCom.DataReceived += new SerialDataReceivedEventHandler(GpsClock_DataReceivedA);
            }
            
        }

        /// <summary>
        /// 打开GPS时钟串口
        /// </summary>
        /// <returns></returns>
        public bool OpenGpsClockCom()
        {
            try
            {
                GpsCom.Open();
            }
            catch { }
            IsClockOpened = GpsCom.IsOpen;

            if (GpsCom.IsOpen)
            {
                return true;
            }else
            {
                return false;
            }
            
        }
        /// <summary>
        /// 关闭GPS时钟串口
        /// </summary>
        /// <returns></returns>
        public bool CloseGpsCom()
        {
            GpsCom.Close();
            IsClockOpened = GpsCom.IsOpen;
            if(GpsCom.IsOpen)
            {
                return false;
            }else
            {
                return true;
            }
        }

        /// <summary>
        /// GPS时钟接收处理程序A
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GpsClock_DataReceivedA(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                StringBuilder currentline = new StringBuilder();
                //循环接收数据
                while (GpsCom.BytesToRead > 0)
                {
                    char ch = (char)GpsCom.ReadByte();
                    currentline.Append(ch);
                }
               //在这里对接收到的数据进行处理
               //
                currentline = new StringBuilder();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());

            }
        }

        /// <summary>
        /// GPS时钟接收处理程序B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GpsClock_DataReceivedB(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                StringBuilder currentline = new StringBuilder();
                //循环接收数据
                while (GpsCom.BytesToRead > 0)
                {
                    char ch = (char)GpsCom.ReadByte();
                    currentline.Append(ch);
                }
                //在这里对接收到的数据进行处理
                //
                currentline = new StringBuilder();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());

            }
        }

        /// <summary>
        /// 角度转换为度分秒
        /// </summary>
        /// <param name="as1"></param>
        /// <param name="d"></param>
        /// <param name="m"></param>
        /// <param name="s"></param>
        /// <param name="axis"></param>
        public void as2dms(float as1, out int d, out int m, out float s, int axis)
        {
            
            float ad = as1 * 0.1F / 3600.0F;

            bool neg = false;
            if (ad < 0)
            {
                ad = System.Math.Abs(ad);
                neg = true;
            }
            float mm;
            d = (int)System.Math.Floor(ad);
            mm = (ad - d) * 60.0F;
            m = (int)System.Math.Floor(mm);
            s = (mm - m) * 60.0F;
            if (neg) d *= -1;
            
        }

        /// <summary>
        /// 获取望远镜指向
        /// </summary>
        public void getPos()
        {
            lock (TeleLock)
            {
                try
                {
                    axis_pos_ha = m_telescope.get_Pos(Constants.TELESCOPE_AXIS_HA) * Constants.TELESCOPE_COUNTSCALE_HA * (-1.0F) + m_telez_ha;
                    axis_pos_dec = m_telescope.get_Pos(Constants.TELESCOPE_AXIS_DEC) * Constants.TELESCOPE_COUNTSCALE_DEC + m_telez_dec;
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// 检查是否到达限位
        /// </summary>
        public void checklimit()
        {
            lock (TeleLock)
            {

                try
                {
                    axis_error_ha = m_telescope.get_AxisError(Constants.TELESCOPE_AXIS_HA);
                    axis_error_dec = m_telescope.get_AxisError(Constants.TELESCOPE_AXIS_DEC);
                }
                catch
                {

                }
            }

        }

        public void thread_func_calibzero()
        {

        }
        /// <summary>
        /// 更新位置信息显示线程
        /// </summary>
        public void thread_func_updatepos()
        {
            String show_text;
            int d, m;
            float s;
            while (true)
            {
                if (m_tele_connected == true)
                {
                    getPos();
                    checklimit();
                    as2dms(axis_pos_ha, out d, out m, out s, Constants.TELESCOPE_AXIS_HA);
                    if (d < 0)
                    {
                        show_text = String.Format("-{0:D2}:{1:D2}:{2:F}", System.Math.Abs(d), m, s);
                    }
                    else
                    {
                        show_text = String.Format("{0:D2}:{1:D2}:{2:F}", d, m, s);
                    }
                    MP_HA.Text = show_text;

                    as2dms(axis_pos_dec, out d, out m, out s, Constants.TELESCOPE_AXIS_DEC);
                    if (d < 0)
                    {
                        show_text = String.Format("-{0:D2}:{1:D2}:{2:F}", System.Math.Abs(d), m, s);
                    }
                    else
                    {
                        show_text = String.Format("{0:D2}:{1:D2}:{2:F}", d, m, s);
                    }
                    MP_DEC.Text = show_text;

                    if (2 == axis_error_ha || 4 == axis_error_ha || 2 == axis_error_dec || 4 == axis_error_dec)
                    {
                        tele_status = TeleReportedConstants.SOCK_REPORT_LIMITED;//limit.Text = "达限位";
                    }
                    else
                    {
                        //limit.Text = "非限位";
                    }

                    Thread.Sleep(500);
                }
                else
                {
                    if (updatepos.IsAlive)
                    {
                        updatepos.Abort();
                    }
                }

            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("选择图片", "信息提示", MessageBoxButtons.OK);
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        /// <summary>
        /// 打开曝光参数设置对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 曝光参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (exp_form != null && exp_form.Created)
            {
                exp_form.Focus();
                return;
            }

            exp_form = new exp_set();
            exp_form.Show();
        }

        /// <summary>
        /// 望远镜连接，微调设置对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 连接设置ToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            if (tele_form!= null && tele_form.Created)
            {
                tele_form.Focus();          
                return;
            }

            tele_form = new tele_set(this);
            tele_form.Show();
        }

        /// <summary>
        /// GPS锁存对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gPS锁存设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gps_form != null && gps_form.Created)
            {
                gps_form.Focus();
                return;
            }

            gps_form = new gps_set(this);
            gps_form.Show();
        }

        /// <summary>
        /// 修正参数读取对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修正参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (param_form != null && param_form.Created)
            {
                param_form.Focus();
                return;
            }

            param_form = new tele_param();
            param_form.Show();
        }

        /// <summary>
        /// 设置速度参数（送速度）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetSpeed_Click(object sender, EventArgs e)
        {
            if (tele_status == TeleReportedConstants.SOCK_REPORT_DISCONNECT) return;
            long vha = 0;
            long vdec = -150000;
            vha = (long)(vha / Constants.TELESCOPE_COUNTSCALE_HA * -1);
            vdec = (long)(vdec / Constants.TELESCOPE_COUNTSCALE_DEC);
            //调用送位置的两个函数

            tele_status = TeleReportedConstants.SOCK_REPORT_RUNNING;
        }
        /// <summary>
        /// 停止望远镜操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stop_Click(object sender, EventArgs e)
        {
            if (tele_status ==TeleReportedConstants.SOCK_REPORT_DISCONNECT) return;

            if (clibzero_thread != null)
            {
                if (clibzero_thread.IsAlive)
                {
                    clibzero_thread.Abort();
                    clibzero_thread = null;
                }
            }

            tele_status = TeleReportedConstants.SOCK_REPORT_WAITING;
        }

        /// <summary>
        /// 打开镜盖操作
        /// </summary>
        public bool OpenCap()
        {
            if(m_cap_connected)
            {
                m_cap.set_Out(0, 0x55);
                return true;
            }else
            {
                MessageBox.Show("cap not connected");
                return false;
            }
            
        }
        /// <summary>
        /// 关闭镜盖操作
        /// </summary>
        public bool CloseCap()
        {
            if (m_cap_connected)
            {
                m_cap.set_Out(0, 0xAA);
                return true;
            }else
            {
                MessageBox.Show("cap not connected");
                return false;
            }
        }

        /// <summary>
        /// 停止镜盖运动操作
        /// </summary>
        public bool StopCap()
        {
            if (m_cap_connected)
            {
                m_cap.set_Out(0, 0x00);
                return true;
            }else
            {
                MessageBox.Show("cap not connected");
                return false;
            }
        }

        /// <summary>
        /// 镜盖操作对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 镜盖操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cap_form != null && cap_form.Created)
            {
                cap_form.Focus();
                return;
            }

            cap_form = new set_cap(this);
            cap_form.Show();

        }
        /// <summary>
        /// 送位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoTo_Click(object sender, EventArgs e)
        {
            if (tele_status ==TeleReportedConstants.SOCK_REPORT_DISCONNECT) return;
            float pha = 0;
            float pdec = 25.5F;
            pha = pha * 3600 / Constants.TELESCOPE_COUNTSCALE_HA * 10;
            pdec = pdec * 3600 / Constants.TELESCOPE_COUNTSCALE_DEC * 10;

            pha = m_telez_ha / Constants.TELESCOPE_COUNTSCALE_HA - pha;
            pdec = pdec - m_telez_dec / Constants.TELESCOPE_COUNTSCALE_DEC;

            tele_status = TeleReportedConstants.SOCK_REPORT_RUNNING;
            new Thread(thread_func_checkpsing);
            
        }
        /// <summary>
        /// POS 保持中？
        /// </summary>
        private void Telegetposremaining()
        {
            lock (TeleLock)
            {
                axis_posremain_ha = m_telescope.get_PosRemaining(Constants.TELESCOPE_AXIS_HA);
                axis_posremain_dec = m_telescope.get_PosRemaining(Constants.TELESCOPE_AXIS_DEC);

            }
        }
        /// <summary>
        /// 检查POS是否在运动中？
        /// </summary>
        private void thread_func_checkpsing()
        {
            Thread.Sleep(500);
            do
            {
                Telegetposremaining();
                Thread.Sleep(50);
            }
            while (0 != (int)axis_posremain_ha || 0 != (int)axis_posremain_dec);

            tele_status = TeleReportedConstants.SOCK_REPORT_WAITING;
        }
    }
    
    /// <summary>
    /// 望远镜状态常量参数
    /// </summary>
    public class TeleReportedConstants
    {
        public const int SOCK_REPORT_WAITING = 0;
        public const int SOCK_REPORT_RUNNING = 1;
        public const int SOCK_REPORT_LIMITED = 2;
        public const int SOCK_REPORT_CLIBING = 3;
        public const int SOCK_REPORT_ILLEGAL = -1;
        public const int SOCK_REPORT_DISCONNECT = -2;
        public const int SOCK_REPORTSIZE = 24;
    }
}
