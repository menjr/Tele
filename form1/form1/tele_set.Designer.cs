namespace form1
{
    partial class tele_set
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
            this.button1 = new System.Windows.Forms.Button();
            this.TeleStatus = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MovUnit = new System.Windows.Forms.ComboBox();
            this.MovDeg = new System.Windows.Forms.NumericUpDown();
            this.MovSW = new System.Windows.Forms.Button();
            this.MovS = new System.Windows.Forms.Button();
            this.MovSE = new System.Windows.Forms.Button();
            this.MovW = new System.Windows.Forms.Button();
            this.MovE = new System.Windows.Forms.Button();
            this.MovNW = new System.Windows.Forms.Button();
            this.MovNE = new System.Windows.Forms.Button();
            this.MovN = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MovDeg)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(262, 39);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "连接望远镜";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TeleStatus
            // 
            this.TeleStatus.Location = new System.Drawing.Point(28, 30);
            this.TeleStatus.Margin = new System.Windows.Forms.Padding(2);
            this.TeleStatus.Multiline = true;
            this.TeleStatus.Name = "TeleStatus";
            this.TeleStatus.Size = new System.Drawing.Size(209, 55);
            this.TeleStatus.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MovUnit);
            this.groupBox2.Controls.Add(this.MovDeg);
            this.groupBox2.Controls.Add(this.MovSW);
            this.groupBox2.Controls.Add(this.MovS);
            this.groupBox2.Controls.Add(this.MovSE);
            this.groupBox2.Controls.Add(this.MovW);
            this.groupBox2.Controls.Add(this.MovE);
            this.groupBox2.Controls.Add(this.MovNW);
            this.groupBox2.Controls.Add(this.MovNE);
            this.groupBox2.Controls.Add(this.MovN);
            this.groupBox2.Location = new System.Drawing.Point(82, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 178);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "指向调整";
            // 
            // MovUnit
            // 
            this.MovUnit.FormattingEnabled = true;
            this.MovUnit.Items.AddRange(new object[] {
            "Sec.",
            "Min.",
            "Deg."});
            this.MovUnit.Location = new System.Drawing.Point(80, 143);
            this.MovUnit.Name = "MovUnit";
            this.MovUnit.Size = new System.Drawing.Size(47, 20);
            this.MovUnit.TabIndex = 8;
            // 
            // MovDeg
            // 
            this.MovDeg.Location = new System.Drawing.Point(29, 143);
            this.MovDeg.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.MovDeg.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MovDeg.Name = "MovDeg";
            this.MovDeg.Size = new System.Drawing.Size(39, 21);
            this.MovDeg.TabIndex = 4;
            this.MovDeg.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MovSW
            // 
            this.MovSW.Location = new System.Drawing.Point(101, 104);
            this.MovSW.Name = "MovSW";
            this.MovSW.Size = new System.Drawing.Size(33, 33);
            this.MovSW.TabIndex = 7;
            this.MovSW.Text = "SW";
            this.MovSW.UseVisualStyleBackColor = true;
            // 
            // MovS
            // 
            this.MovS.Location = new System.Drawing.Point(61, 104);
            this.MovS.Name = "MovS";
            this.MovS.Size = new System.Drawing.Size(33, 33);
            this.MovS.TabIndex = 6;
            this.MovS.Text = "S";
            this.MovS.UseVisualStyleBackColor = true;
            // 
            // MovSE
            // 
            this.MovSE.Location = new System.Drawing.Point(21, 104);
            this.MovSE.Name = "MovSE";
            this.MovSE.Size = new System.Drawing.Size(33, 33);
            this.MovSE.TabIndex = 5;
            this.MovSE.Text = "SE";
            this.MovSE.UseVisualStyleBackColor = true;
            // 
            // MovW
            // 
            this.MovW.Location = new System.Drawing.Point(101, 65);
            this.MovW.Name = "MovW";
            this.MovW.Size = new System.Drawing.Size(33, 33);
            this.MovW.TabIndex = 4;
            this.MovW.Text = "W";
            this.MovW.UseVisualStyleBackColor = true;
            // 
            // MovE
            // 
            this.MovE.Location = new System.Drawing.Point(21, 65);
            this.MovE.Name = "MovE";
            this.MovE.Size = new System.Drawing.Size(33, 33);
            this.MovE.TabIndex = 3;
            this.MovE.Text = "E";
            this.MovE.UseVisualStyleBackColor = true;
            // 
            // MovNW
            // 
            this.MovNW.Location = new System.Drawing.Point(101, 25);
            this.MovNW.Name = "MovNW";
            this.MovNW.Size = new System.Drawing.Size(33, 33);
            this.MovNW.TabIndex = 2;
            this.MovNW.Text = "NW";
            this.MovNW.UseVisualStyleBackColor = true;
            // 
            // MovNE
            // 
            this.MovNE.Location = new System.Drawing.Point(21, 25);
            this.MovNE.Name = "MovNE";
            this.MovNE.Size = new System.Drawing.Size(33, 33);
            this.MovNE.TabIndex = 1;
            this.MovNE.Text = "NE";
            this.MovNE.UseVisualStyleBackColor = true;
            // 
            // MovN
            // 
            this.MovN.Location = new System.Drawing.Point(61, 25);
            this.MovN.Name = "MovN";
            this.MovN.Size = new System.Drawing.Size(33, 33);
            this.MovN.TabIndex = 0;
            this.MovN.Text = "N";
            this.MovN.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(262, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "找零";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tele_set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 347);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.TeleStatus);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "tele_set";
            this.Text = "望远镜微调";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MovDeg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TeleStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox MovUnit;
        private System.Windows.Forms.NumericUpDown MovDeg;
        private System.Windows.Forms.Button MovSW;
        private System.Windows.Forms.Button MovS;
        private System.Windows.Forms.Button MovSE;
        private System.Windows.Forms.Button MovW;
        private System.Windows.Forms.Button MovE;
        private System.Windows.Forms.Button MovNW;
        private System.Windows.Forms.Button MovNE;
        private System.Windows.Forms.Button MovN;
        private System.Windows.Forms.Button button2;
    }
}