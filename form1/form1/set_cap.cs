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
    public partial class set_cap : Form
    {
        private MainForm fm1;


        public set_cap()
        {
            InitializeComponent();
        }
        public set_cap(MainForm mainfm)
        {
            InitializeComponent();
            fm1 = mainfm;

        }

        public void CapConnect()
        {

            try
            {
                fm1.m_cap.SetNextMoveBX2Link(3, fm1.m_cap_comport, 57600, true);
                fm1.m_cap.set_Config(0, 1);
                fm1.m_cap.set_Config(1, 1);
                fm1.m_cap.set_Accel(0, 66667.0F);
                fm1.m_cap.set_Decel(0, 66667.0F);
                fm1.m_cap.set_Accel(1, 66667.0F);
                fm1.m_cap.set_Decel(1, 66667.0F);

                fm1.m_cap.DoCancel(0);
                fm1.m_cap.DoCancel(1);

                fm1.m_cap.set_DriveEnable(0, true);
                fm1.m_cap.set_DriveEnable(1, true);

                fm1.m_telescope.set_LimitMode(0, 2);
                fm1.m_telescope.set_LimitMode(1, 2);
                fm1.m_cap_connected = true;
            }
            catch
            {
                MessageBox.Show("cap not connected");
                fm1.m_cap_connected = false;
            }
        }


        private void ConnetCap_Click(object sender, EventArgs e)
        {
            if (!fm1.m_cap_connected)
            {
                CapConnect();
                
            }
            if (fm1.m_cap_connected)
            {
                CapStatus.Text = "望远镜镜盖已连接...";

            }
            else
            {
                CapStatus.Text = "未连接望远镜镜盖！！！";

            }

        }

        private void set_cap_Load(object sender, EventArgs e)
        {

        }

        private void OpenCap_Click(object sender, EventArgs e)
        {
            bool status = fm1.OpenCap();
            if(status)
            {
                CapStatus.Text = "镜盖已打开...\r\n" + CapStatus.Text;
            }else
            {
                CapStatus.Text = "镜盖打开失败!!!\r\n" + CapStatus.Text;
            }
        }

        private void CloseCap_Click(object sender, EventArgs e)
        {
            bool status = fm1.CloseCap();
            if (status)
            {
                CapStatus.Text = "镜盖已关闭...\r\n" + CapStatus.Text;
            }
            else
            {
                CapStatus.Text = "镜盖关闭失败!!!\r\n" + CapStatus.Text;
            }
        }

        private void StopCap_Click(object sender, EventArgs e)
        {
            bool status = fm1.StopCap();
            if (status)
            {
                CapStatus.Text = "镜盖已停止...\r\n" + CapStatus.Text;
            }
            else
            {
                CapStatus.Text = "镜盖停止失败!!!\r\n" + CapStatus.Text ;
            }
        }
    }
}
