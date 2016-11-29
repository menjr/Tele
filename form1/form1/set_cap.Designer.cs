namespace form1
{
    partial class set_cap
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
            this.components = new System.ComponentModel.Container();
            this.CapStatus = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ConnetCap = new System.Windows.Forms.Button();
            this.OpenCap = new System.Windows.Forms.Button();
            this.CloseCap = new System.Windows.Forms.Button();
            this.StopCap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CapStatus
            // 
            this.CapStatus.Location = new System.Drawing.Point(30, 31);
            this.CapStatus.Multiline = true;
            this.CapStatus.Name = "CapStatus";
            this.CapStatus.Size = new System.Drawing.Size(336, 80);
            this.CapStatus.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ConnetCap
            // 
            this.ConnetCap.Location = new System.Drawing.Point(408, 55);
            this.ConnetCap.Name = "ConnetCap";
            this.ConnetCap.Size = new System.Drawing.Size(102, 38);
            this.ConnetCap.TabIndex = 2;
            this.ConnetCap.Text = "连接镜盖";
            this.ConnetCap.UseVisualStyleBackColor = true;
            this.ConnetCap.Click += new System.EventHandler(this.ConnetCap_Click);
            // 
            // OpenCap
            // 
            this.OpenCap.Location = new System.Drawing.Point(62, 159);
            this.OpenCap.Name = "OpenCap";
            this.OpenCap.Size = new System.Drawing.Size(100, 74);
            this.OpenCap.TabIndex = 3;
            this.OpenCap.Text = "打开镜盖";
            this.OpenCap.UseVisualStyleBackColor = true;
            this.OpenCap.Click += new System.EventHandler(this.OpenCap_Click);
            // 
            // CloseCap
            // 
            this.CloseCap.Location = new System.Drawing.Point(199, 159);
            this.CloseCap.Name = "CloseCap";
            this.CloseCap.Size = new System.Drawing.Size(100, 74);
            this.CloseCap.TabIndex = 4;
            this.CloseCap.Text = "关闭镜盖";
            this.CloseCap.UseVisualStyleBackColor = true;
            this.CloseCap.Click += new System.EventHandler(this.CloseCap_Click);
            // 
            // StopCap
            // 
            this.StopCap.Location = new System.Drawing.Point(336, 159);
            this.StopCap.Name = "StopCap";
            this.StopCap.Size = new System.Drawing.Size(100, 74);
            this.StopCap.TabIndex = 5;
            this.StopCap.Text = "停止";
            this.StopCap.UseVisualStyleBackColor = true;
            this.StopCap.Click += new System.EventHandler(this.StopCap_Click);
            // 
            // set_cap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 271);
            this.Controls.Add(this.StopCap);
            this.Controls.Add(this.CloseCap);
            this.Controls.Add(this.OpenCap);
            this.Controls.Add(this.ConnetCap);
            this.Controls.Add(this.CapStatus);
            this.Name = "set_cap";
            this.Text = "镜盖控制";
            this.Load += new System.EventHandler(this.set_cap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CapStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button ConnetCap;
        private System.Windows.Forms.Button OpenCap;
        private System.Windows.Forms.Button CloseCap;
        private System.Windows.Forms.Button StopCap;
    }
}