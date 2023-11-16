namespace Serial_Communication
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox_port = new System.Windows.Forms.ComboBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.textBox_send = new System.Windows.Forms.TextBox();
            this.richTextBox_received = new System.Windows.Forms.RichTextBox();
            this.label_send = new System.Windows.Forms.Label();
            this.label_receive = new System.Windows.Forms.Label();
            this.label_port = new System.Windows.Forms.Label();
            this.button_send = new System.Windows.Forms.Button();
            this.label_status = new System.Windows.Forms.Label();
            this.comboBox_band = new System.Windows.Forms.ComboBox();
            this.label_band = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Serial = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox_parity = new System.Windows.Forms.ComboBox();
            this.label_parity = new System.Windows.Forms.Label();
            this.comboBox_datasize = new System.Windows.Forms.ComboBox();
            this.label_datasize = new System.Windows.Forms.Label();
            this.tabPage_Battery = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_BATtest = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage_Serial.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage_Battery.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_port
            // 
            this.comboBox_port.FormattingEnabled = true;
            this.comboBox_port.Location = new System.Drawing.Point(368, 18);
            this.comboBox_port.Name = "comboBox_port";
            this.comboBox_port.Size = new System.Drawing.Size(98, 20);
            this.comboBox_port.TabIndex = 0;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(366, 218);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(97, 20);
            this.button_connect.TabIndex = 1;
            this.button_connect.Text = "포트열기";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.Button_connect_Click);
            // 
            // button_disconnect
            // 
            this.button_disconnect.Location = new System.Drawing.Point(366, 242);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(97, 22);
            this.button_disconnect.TabIndex = 1;
            this.button_disconnect.Text = "포트닫기";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.Button_disconnect_Click);
            // 
            // textBox_send
            // 
            this.textBox_send.Location = new System.Drawing.Point(3, 243);
            this.textBox_send.Name = "textBox_send";
            this.textBox_send.Size = new System.Drawing.Size(262, 21);
            this.textBox_send.TabIndex = 2;
            // 
            // richTextBox_received
            // 
            this.richTextBox_received.Location = new System.Drawing.Point(3, 18);
            this.richTextBox_received.Name = "richTextBox_received";
            this.richTextBox_received.Size = new System.Drawing.Size(358, 201);
            this.richTextBox_received.TabIndex = 3;
            this.richTextBox_received.Text = "";
            // 
            // label_send
            // 
            this.label_send.AutoSize = true;
            this.label_send.Location = new System.Drawing.Point(3, 226);
            this.label_send.Name = "label_send";
            this.label_send.Size = new System.Drawing.Size(29, 12);
            this.label_send.TabIndex = 4;
            this.label_send.Text = "송신";
            // 
            // label_receive
            // 
            this.label_receive.AutoSize = true;
            this.label_receive.Location = new System.Drawing.Point(0, 3);
            this.label_receive.Name = "label_receive";
            this.label_receive.Size = new System.Drawing.Size(29, 12);
            this.label_receive.TabIndex = 4;
            this.label_receive.Text = "수신";
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(366, 3);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(90, 12);
            this.label_port.TabIndex = 5;
            this.label_port.Text = "COM 포트 설정";
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(270, 242);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(91, 23);
            this.button_send.TabIndex = 6;
            this.button_send.Text = "보내기";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.Button_send_Click);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(3, 266);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(53, 12);
            this.label_status.TabIndex = 7;
            this.label_status.Text = "연결상태";
            // 
            // comboBox_band
            // 
            this.comboBox_band.FormattingEnabled = true;
            this.comboBox_band.Items.AddRange(new object[] {
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200"});
            this.comboBox_band.Location = new System.Drawing.Point(368, 54);
            this.comboBox_band.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_band.Name = "comboBox_band";
            this.comboBox_band.Size = new System.Drawing.Size(98, 20);
            this.comboBox_band.TabIndex = 8;
            // 
            // label_band
            // 
            this.label_band.AutoSize = true;
            this.label_band.Location = new System.Drawing.Point(366, 40);
            this.label_band.Name = "label_band";
            this.label_band.Size = new System.Drawing.Size(59, 12);
            this.label_band.TabIndex = 9;
            this.label_band.Text = "Band rate";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Serial);
            this.tabControl1.Controls.Add(this.tabPage_Battery);
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(686, 386);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage_Serial
            // 
            this.tabPage_Serial.Controls.Add(this.panel1);
            this.tabPage_Serial.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Serial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_Serial.Name = "tabPage_Serial";
            this.tabPage_Serial.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_Serial.Size = new System.Drawing.Size(678, 360);
            this.tabPage_Serial.TabIndex = 0;
            this.tabPage_Serial.Text = "Serial";
            this.tabPage_Serial.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.comboBox_parity);
            this.panel1.Controls.Add(this.label_parity);
            this.panel1.Controls.Add(this.comboBox_datasize);
            this.panel1.Controls.Add(this.label_datasize);
            this.panel1.Controls.Add(this.richTextBox_received);
            this.panel1.Controls.Add(this.button_disconnect);
            this.panel1.Controls.Add(this.label_status);
            this.panel1.Controls.Add(this.button_connect);
            this.panel1.Controls.Add(this.label_band);
            this.panel1.Controls.Add(this.textBox_send);
            this.panel1.Controls.Add(this.comboBox_band);
            this.panel1.Controls.Add(this.label_send);
            this.panel1.Controls.Add(this.label_receive);
            this.panel1.Controls.Add(this.label_port);
            this.panel1.Controls.Add(this.button_send);
            this.panel1.Controls.Add(this.comboBox_port);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 354);
            this.panel1.TabIndex = 0;
            // 
            // comboBox_parity
            // 
            this.comboBox_parity.FormattingEnabled = true;
            this.comboBox_parity.Location = new System.Drawing.Point(368, 128);
            this.comboBox_parity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_parity.Name = "comboBox_parity";
            this.comboBox_parity.Size = new System.Drawing.Size(98, 20);
            this.comboBox_parity.TabIndex = 13;
            // 
            // label_parity
            // 
            this.label_parity.AutoSize = true;
            this.label_parity.Location = new System.Drawing.Point(366, 114);
            this.label_parity.Name = "label_parity";
            this.label_parity.Size = new System.Drawing.Size(37, 12);
            this.label_parity.TabIndex = 12;
            this.label_parity.Text = "Parity";
            // 
            // comboBox_datasize
            // 
            this.comboBox_datasize.FormattingEnabled = true;
            this.comboBox_datasize.Location = new System.Drawing.Point(368, 93);
            this.comboBox_datasize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_datasize.Name = "comboBox_datasize";
            this.comboBox_datasize.Size = new System.Drawing.Size(98, 20);
            this.comboBox_datasize.TabIndex = 11;
            // 
            // label_datasize
            // 
            this.label_datasize.AutoSize = true;
            this.label_datasize.Location = new System.Drawing.Point(366, 75);
            this.label_datasize.Name = "label_datasize";
            this.label_datasize.Size = new System.Drawing.Size(58, 12);
            this.label_datasize.TabIndex = 10;
            this.label_datasize.Text = "Data size";
            // 
            // tabPage_Battery
            // 
            this.tabPage_Battery.Controls.Add(this.panel2);
            this.tabPage_Battery.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Battery.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_Battery.Name = "tabPage_Battery";
            this.tabPage_Battery.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_Battery.Size = new System.Drawing.Size(678, 360);
            this.tabPage_Battery.TabIndex = 1;
            this.tabPage_Battery.Text = "Battery";
            this.tabPage_Battery.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.button_BATtest);
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(668, 354);
            this.panel2.TabIndex = 0;
            // 
            // button_BATtest
            // 
            this.button_BATtest.Location = new System.Drawing.Point(592, 330);
            this.button_BATtest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_BATtest.Name = "button_BATtest";
            this.button_BATtest.Size = new System.Drawing.Size(74, 23);
            this.button_BATtest.TabIndex = 0;
            this.button_BATtest.Text = "Test";
            this.button_BATtest.UseVisualStyleBackColor = true;
            this.button_BATtest.Click += new System.EventHandler(this.button_BATtest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 401);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Serial.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage_Battery.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_port;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.TextBox textBox_send;
        private System.Windows.Forms.RichTextBox richTextBox_received;
        private System.Windows.Forms.Label label_send;
        private System.Windows.Forms.Label label_receive;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.ComboBox comboBox_band;
        private System.Windows.Forms.Label label_band;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Serial;
        private System.Windows.Forms.TabPage tabPage_Battery;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox_parity;
        private System.Windows.Forms.Label label_parity;
        private System.Windows.Forms.ComboBox comboBox_datasize;
        private System.Windows.Forms.Label label_datasize;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_BATtest;
    }
}

