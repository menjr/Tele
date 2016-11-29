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

namespace form1
{
    public partial class tele_set : Form
    {
        
        private MainForm fm1;

        
        public tele_set()
        {
            InitializeComponent();
        }
        public tele_set(MainForm mainfm)
        {
            InitializeComponent();
            fm1 = mainfm;

        }
        /// <summary>
        /// 连接望远镜
        /// </summary>
        public void TeleConnect()
        {
            try
            {
                fm1.m_telescope.SetNextMoveBX2Link(2, fm1.m_tele_comport, 57600, true);
                fm1.m_telescope.set_Config(Constants.TELESCOPE_AXIS_HA, Constants.TELESCOPE_AXISTYPE);
                fm1.m_telescope.set_Config(Constants.TELESCOPE_AXIS_DEC, Constants.TELESCOPE_AXISTYPE);
                fm1.m_telescope.set_Accel(Constants.TELESCOPE_AXIS_HA, Constants.TELESCOPE_ACCELDECEL);
                fm1.m_telescope.set_Decel(Constants.TELESCOPE_AXIS_HA, Constants.TELESCOPE_ACCELDECEL);
                fm1.m_telescope.set_Accel(Constants.TELESCOPE_AXIS_DEC, Constants.TELESCOPE_ACCELDECEL);
                fm1.m_telescope.set_Decel(Constants.TELESCOPE_AXIS_DEC, Constants.TELESCOPE_ACCELDECEL);

                fm1.m_telescope.DoCancel(Constants.TELESCOPE_AXIS_HA);
                fm1.m_telescope.DoCancel(Constants.TELESCOPE_AXIS_DEC);

                fm1.m_telescope.set_DriveEnable(Constants.TELESCOPE_AXIS_HA, true);
                fm1.m_telescope.set_DriveEnable(Constants.TELESCOPE_AXIS_DEC, true);

                fm1.m_telescope.set_LimitMode(Constants.TELESCOPE_AXIS_HA, 2);
                fm1.m_telescope.set_LimitMode(Constants.TELESCOPE_AXIS_DEC, 2);

                fm1.tele_status = TeleReportedConstants.SOCK_REPORT_WAITING;
                fm1.m_tele_connected = true;
            }
            catch
            {
                fm1.m_tele_connected = false;
                MessageBox.Show("telescope not connected");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(fm1.tele_status != TeleReportedConstants.SOCK_REPORT_DISCONNECT)
            {
                TeleConnect();
            }
            if(fm1.m_tele_connected)
            {
                fm1.updatepos = new Thread(new ThreadStart(fm1.thread_func_updatepos));
                fm1.updatepos.Start();
                TeleStatus.Text = "望远镜已连接...";

            }else
            {
                TeleStatus.Text = "未连接望远镜！！！";

            }
        }
        /// <summary>
        /// 望远镜找零
        /// </summary>
        /// <param name="axis"></param>
        public void TeleSethome(short axis)
        {
            if(fm1.m_cap_connected)
            {
                fm1.m_telescope.set_Home(axis, 4);
            }            
        }
        /// <summary>
        /// 望远镜是否在零点判断
        /// </summary>
        /// <param name="axis"></param>
        public void TeleGethomeStatus(short axis)
        {
            if(fm1.m_cap_connected)
            {
                lock(fm1.m_telescope)
                if (Constants.TELESCOPE_AXIS_HA == axis)
                    fm1.homestatus_ha = fm1.m_telescope.get_HomeStatus(axis);
                if (Constants.TELESCOPE_AXIS_DEC == axis)
                    fm1.homestatus_dec = fm1.m_telescope.get_HomeStatus(axis);
            }

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            if(fm1.m_tele_connected)
            {
                TeleSethome(Constants.TELESCOPE_AXIS_HA);
                TeleSethome(Constants.TELESCOPE_AXIS_DEC);
                TeleStatus.Text = "望远镜找零...\r\n" + TeleStatus.Text;

            }
            else
            {
                MessageBox.Show("telescope not connected");
                TeleStatus.Text = "找零失败！！！\r\n" + TeleStatus.Text;
            }
            if (fm1.tele_status == TeleReportedConstants.SOCK_REPORT_DISCONNECT) return;
            fm1.clibzero_thread = new Thread(fm1.thread_func_calibzero);
        }
       


    }

    /// <summary>
    /// 望远镜初始化参数
    /// </summary>
    public class Constants
    {
        public const short TELESCOPE_AXIS_HA = 0;
        public const short TELESCOPE_AXIS_DEC = 1;
        public const short TELESCOPE_AXISTYPE = 1;//伺服电机
        public const float TELESCOPE_ACCELDECEL = 66667.0F;
        public const float TELESCOPE_COUNTSCALE_HA = 1.0F;
        public const float TELESCOPE_COUNTSCALE_DEC = 1.62F;

        public const float TELE_PL_HA = 170.0F;
        public const float TELE_NL_HA = -170.0F;
        public const float TELE_PL_DEC = 96.0F;
        public const float TELE_NL_DEC = -35.0F;

    }
}
