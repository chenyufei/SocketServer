namespace SocketServer
{
    partial class FrmServer
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
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Stop_Listen = new System.Windows.Forms.Button();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.richTextBox_Log = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Msg = new System.Windows.Forms.RichTextBox();
            this.comboBox_Socket = new System.Windows.Forms.ComboBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.button_Select = new System.Windows.Forms.Button();
            this.button_SendFile = new System.Windows.Forms.Button();
            this.textBox_FilePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(351, 12);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(75, 23);
            this.button_Start.TabIndex = 0;
            this.button_Start.Text = "开始监听";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_Stop_Listen
            // 
            this.button_Stop_Listen.Location = new System.Drawing.Point(471, 11);
            this.button_Stop_Listen.Name = "button_Stop_Listen";
            this.button_Stop_Listen.Size = new System.Drawing.Size(75, 23);
            this.button_Stop_Listen.TabIndex = 1;
            this.button_Stop_Listen.Text = "停止监听";
            this.button_Stop_Listen.UseVisualStyleBackColor = true;
            this.button_Stop_Listen.Click += new System.EventHandler(this.button_Stop_Listen_Click);
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(28, 11);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(122, 21);
            this.textBox_IP.TabIndex = 2;
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(211, 10);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(78, 21);
            this.textBox_Port.TabIndex = 3;
            // 
            // richTextBox_Log
            // 
            this.richTextBox_Log.Location = new System.Drawing.Point(28, 66);
            this.richTextBox_Log.Name = "richTextBox_Log";
            this.richTextBox_Log.Size = new System.Drawing.Size(760, 96);
            this.richTextBox_Log.TabIndex = 4;
            this.richTextBox_Log.Text = "";
            // 
            // richTextBox_Msg
            // 
            this.richTextBox_Msg.Location = new System.Drawing.Point(28, 186);
            this.richTextBox_Msg.Name = "richTextBox_Msg";
            this.richTextBox_Msg.Size = new System.Drawing.Size(760, 96);
            this.richTextBox_Msg.TabIndex = 5;
            this.richTextBox_Msg.Text = "";
            // 
            // comboBox_Socket
            // 
            this.comboBox_Socket.FormattingEnabled = true;
            this.comboBox_Socket.Location = new System.Drawing.Point(582, 10);
            this.comboBox_Socket.Name = "comboBox_Socket";
            this.comboBox_Socket.Size = new System.Drawing.Size(181, 20);
            this.comboBox_Socket.TabIndex = 6;
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(529, 415);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(75, 23);
            this.button_Send.TabIndex = 7;
            this.button_Send.Text = "发送信息";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // button_Select
            // 
            this.button_Select.Location = new System.Drawing.Point(529, 359);
            this.button_Select.Name = "button_Select";
            this.button_Select.Size = new System.Drawing.Size(75, 23);
            this.button_Select.TabIndex = 8;
            this.button_Select.Text = "选择";
            this.button_Select.UseVisualStyleBackColor = true;
            this.button_Select.Click += new System.EventHandler(this.button_Select_Click);
            // 
            // button_SendFile
            // 
            this.button_SendFile.Location = new System.Drawing.Point(652, 359);
            this.button_SendFile.Name = "button_SendFile";
            this.button_SendFile.Size = new System.Drawing.Size(75, 23);
            this.button_SendFile.TabIndex = 9;
            this.button_SendFile.Text = "发送文件";
            this.button_SendFile.UseVisualStyleBackColor = true;
            this.button_SendFile.Click += new System.EventHandler(this.button_SendFile_Click);
            // 
            // textBox_FilePath
            // 
            this.textBox_FilePath.Location = new System.Drawing.Point(28, 359);
            this.textBox_FilePath.Name = "textBox_FilePath";
            this.textBox_FilePath.Size = new System.Drawing.Size(480, 21);
            this.textBox_FilePath.TabIndex = 10;
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox_FilePath);
            this.Controls.Add(this.button_SendFile);
            this.Controls.Add(this.button_Select);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.comboBox_Socket);
            this.Controls.Add(this.richTextBox_Msg);
            this.Controls.Add(this.richTextBox_Log);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.button_Stop_Listen);
            this.Controls.Add(this.button_Start);
            this.Name = "FrmServer";
            this.Text = "服务端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Stop_Listen;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.RichTextBox richTextBox_Log;
        private System.Windows.Forms.RichTextBox richTextBox_Msg;
        private System.Windows.Forms.ComboBox comboBox_Socket;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Button button_Select;
        private System.Windows.Forms.Button button_SendFile;
        private System.Windows.Forms.TextBox textBox_FilePath;
    }
}

