namespace form1
{
    partial class gps_set
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GpsComName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.GpsProtocol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Cam1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Cam2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Com3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Cam4 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GpsComName
            // 
            this.GpsComName.FormattingEnabled = true;
            this.GpsComName.Location = new System.Drawing.Point(89, 19);
            this.GpsComName.Margin = new System.Windows.Forms.Padding(2);
            this.GpsComName.Name = "GpsComName";
            this.GpsComName.Size = new System.Drawing.Size(76, 20);
            this.GpsComName.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 21);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "时钟源";
            // 
            // GpsProtocol
            // 
            this.GpsProtocol.FormattingEnabled = true;
            this.GpsProtocol.Items.AddRange(new object[] {
            "协议A",
            "协议B"});
            this.GpsProtocol.Location = new System.Drawing.Point(243, 20);
            this.GpsProtocol.Margin = new System.Windows.Forms.Padding(2);
            this.GpsProtocol.Name = "GpsProtocol";
            this.GpsProtocol.Size = new System.Drawing.Size(76, 20);
            this.GpsProtocol.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "锁存协议";
            // 
            // Cam1
            // 
            this.Cam1.FormattingEnabled = true;
            this.Cam1.Items.AddRange(new object[] {
            "开启",
            "关闭"});
            this.Cam1.Location = new System.Drawing.Point(89, 15);
            this.Cam1.Margin = new System.Windows.Forms.Padding(2);
            this.Cam1.Name = "Cam1";
            this.Cam1.Size = new System.Drawing.Size(76, 20);
            this.Cam1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "相机1锁存";
            // 
            // Cam2
            // 
            this.Cam2.FormattingEnabled = true;
            this.Cam2.Items.AddRange(new object[] {
            "开启",
            "关闭"});
            this.Cam2.Location = new System.Drawing.Point(89, 45);
            this.Cam2.Margin = new System.Windows.Forms.Padding(2);
            this.Cam2.Name = "Cam2";
            this.Cam2.Size = new System.Drawing.Size(76, 20);
            this.Cam2.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "相机2锁存";
            // 
            // Com3
            // 
            this.Com3.FormattingEnabled = true;
            this.Com3.Items.AddRange(new object[] {
            "开启",
            "关闭"});
            this.Com3.Location = new System.Drawing.Point(243, 16);
            this.Com3.Margin = new System.Windows.Forms.Padding(2);
            this.Com3.Name = "Com3";
            this.Com3.Size = new System.Drawing.Size(76, 20);
            this.Com3.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "相机3锁存";
            // 
            // Cam4
            // 
            this.Cam4.FormattingEnabled = true;
            this.Cam4.Items.AddRange(new object[] {
            "开启",
            "关闭"});
            this.Cam4.Location = new System.Drawing.Point(243, 47);
            this.Cam4.Margin = new System.Windows.Forms.Padding(2);
            this.Cam4.Name = "Cam4";
            this.Cam4.Size = new System.Drawing.Size(76, 20);
            this.Cam4.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 49);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "相机4锁存";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(266, 96);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 32);
            this.button2.TabIndex = 21;
            this.button2.Text = "打开串口";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 256);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 32);
            this.button1.TabIndex = 20;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Cam4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Com3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Cam2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Cam1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(23, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 77);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "锁存使能";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GpsProtocol);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.GpsComName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(25, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 49);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "时钟源选择";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(207, 256);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(73, 32);
            this.button3.TabIndex = 24;
            this.button3.Text = "确定";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // gps_set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 326);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "gps_set";
            this.Text = "GPS锁存设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox GpsComName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox GpsProtocol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cam1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Cam2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Com3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Cam4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
    }
}