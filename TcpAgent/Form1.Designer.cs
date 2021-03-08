namespace TcpAgent
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.agentPortText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.agentAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.portText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.maxListenText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.startBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.debugText = new System.Windows.Forms.TextBox();
            this.authorLabel = new System.Windows.Forms.Label();
            this.userListBox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.agentPortText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.agentAddress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.portText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置端口";
            // 
            // agentPortText
            // 
            this.agentPortText.Location = new System.Drawing.Point(431, 23);
            this.agentPortText.Name = "agentPortText";
            this.agentPortText.Size = new System.Drawing.Size(68, 21);
            this.agentPortText.TabIndex = 5;
            this.agentPortText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.agentPort_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(394, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "端口：";
            // 
            // agentAddress
            // 
            this.agentAddress.Location = new System.Drawing.Point(243, 23);
            this.agentAddress.Name = "agentAddress";
            this.agentAddress.Size = new System.Drawing.Size(145, 21);
            this.agentAddress.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "代理地址：";
            // 
            // portText
            // 
            this.portText.Location = new System.Drawing.Point(77, 23);
            this.portText.Name = "portText";
            this.portText.Size = new System.Drawing.Size(68, 21);
            this.portText.TabIndex = 1;
            this.portText.TextChanged += new System.EventHandler(this.portText_TextChanged);
            this.portText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.port_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "暴露端口：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.maxListenText);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(170, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 73);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工作参数设置";
            // 
            // maxListenText
            // 
            this.maxListenText.Location = new System.Drawing.Point(98, 27);
            this.maxListenText.Name = "maxListenText";
            this.maxListenText.Size = new System.Drawing.Size(100, 21);
            this.maxListenText.TabIndex = 1;
            this.maxListenText.Text = "50";
            this.maxListenText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.maxListenText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "最大连接数：";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 312);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(145, 27);
            this.progressBar1.TabIndex = 3;
            // 
            // startBtn
            // 
            this.startBtn.Enabled = false;
            this.startBtn.Location = new System.Drawing.Point(167, 312);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(76, 27);
            this.startBtn.TabIndex = 4;
            this.startBtn.Text = "启动";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Enabled = false;
            this.stopBtn.Location = new System.Drawing.Point(255, 312);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(76, 27);
            this.stopBtn.TabIndex = 5;
            this.stopBtn.Text = "停止";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // debugText
            // 
            this.debugText.BackColor = System.Drawing.SystemColors.InfoText;
            this.debugText.ForeColor = System.Drawing.Color.White;
            this.debugText.Location = new System.Drawing.Point(170, 160);
            this.debugText.Multiline = true;
            this.debugText.Name = "debugText";
            this.debugText.Size = new System.Drawing.Size(361, 143);
            this.debugText.TabIndex = 6;
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.authorLabel.Location = new System.Drawing.Point(442, 316);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(81, 12);
            this.authorLabel.TabIndex = 7;
            this.authorLabel.Text = "Author：cao";
            // 
            // userListBox
            // 
            this.userListBox.FormattingEnabled = true;
            this.userListBox.ItemHeight = 12;
            this.userListBox.Location = new System.Drawing.Point(13, 81);
            this.userListBox.Name = "userListBox";
            this.userListBox.Size = new System.Drawing.Size(145, 220);
            this.userListBox.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 351);
            this.Controls.Add(this.userListBox);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.debugText);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "TCP协议代理转发工具";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox agentPortText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox agentAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox maxListenText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.TextBox debugText;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.ListBox userListBox;
    }
}

