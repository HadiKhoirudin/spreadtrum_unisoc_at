
namespace  Unisoc_AT_HadiKIT
{
    partial class Main
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
            this.ATWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_poweroff = new System.Windows.Forms.Button();
            this.btn_reboot = new System.Windows.Forms.Button();
            this.btn_backlight = new System.Windows.Forms.Button();
            this.btn_factory = new System.Windows.Forms.Button();
            this.RichTextBox = new System.Windows.Forms.RichTextBox();
            this.cb_fastconnect = new System.Windows.Forms.CheckBox();
            this.cmb_port = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_charging = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_WiFiAddr = new System.Windows.Forms.TextBox();
            this.txt_BTAddr = new System.Windows.Forms.TextBox();
            this.txt_IMEI2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_InitPhaseCheck = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_readaddr = new System.Windows.Forms.Button();
            this.txt_SN2 = new System.Windows.Forms.TextBox();
            this.txt_SN1 = new System.Windows.Forms.TextBox();
            this.txt_IMEI1 = new System.Windows.Forms.TextBox();
            this.btn_readimei = new System.Windows.Forms.Button();
            this.btn_writeaddr = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_readsn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_writesn = new System.Windows.Forms.Button();
            this.btn_writeimei = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtb_ATCommand = new System.Windows.Forms.RichTextBox();
            this.btn_ATSend = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ATWorker
            // 
            this.ATWorker.WorkerReportsProgress = true;
            this.ATWorker.WorkerSupportsCancellation = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_poweroff);
            this.groupBox1.Controls.Add(this.btn_reboot);
            this.groupBox1.Controls.Add(this.btn_backlight);
            this.groupBox1.Controls.Add(this.btn_factory);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 382);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // btn_poweroff
            // 
            this.btn_poweroff.Location = new System.Drawing.Point(6, 81);
            this.btn_poweroff.Name = "btn_poweroff";
            this.btn_poweroff.Size = new System.Drawing.Size(108, 24);
            this.btn_poweroff.TabIndex = 11;
            this.btn_poweroff.Text = "Power Off";
            this.btn_poweroff.UseVisualStyleBackColor = true;
            this.btn_poweroff.Click += new System.EventHandler(this.btn_poweroff_Click);
            // 
            // btn_reboot
            // 
            this.btn_reboot.Location = new System.Drawing.Point(6, 111);
            this.btn_reboot.Name = "btn_reboot";
            this.btn_reboot.Size = new System.Drawing.Size(108, 24);
            this.btn_reboot.TabIndex = 11;
            this.btn_reboot.Text = "Reboot";
            this.btn_reboot.UseVisualStyleBackColor = true;
            this.btn_reboot.Click += new System.EventHandler(this.btn_reboot_Click);
            // 
            // btn_backlight
            // 
            this.btn_backlight.Location = new System.Drawing.Point(4, 21);
            this.btn_backlight.Name = "btn_backlight";
            this.btn_backlight.Size = new System.Drawing.Size(108, 24);
            this.btn_backlight.TabIndex = 10;
            this.btn_backlight.Text = "Turn On Backlight";
            this.btn_backlight.UseVisualStyleBackColor = true;
            this.btn_backlight.Click += new System.EventHandler(this.btn_backlight_Click);
            // 
            // btn_factory
            // 
            this.btn_factory.Location = new System.Drawing.Point(4, 51);
            this.btn_factory.Name = "btn_factory";
            this.btn_factory.Size = new System.Drawing.Size(108, 24);
            this.btn_factory.TabIndex = 9;
            this.btn_factory.Text = "Factory Reset";
            this.btn_factory.UseVisualStyleBackColor = true;
            this.btn_factory.Click += new System.EventHandler(this.btn_factory_Click);
            // 
            // RichTextBox
            // 
            this.RichTextBox.BackColor = System.Drawing.Color.White;
            this.RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBox.Location = new System.Drawing.Point(3, 16);
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.Size = new System.Drawing.Size(317, 363);
            this.RichTextBox.TabIndex = 6;
            this.RichTextBox.Text = "";
            // 
            // cb_fastconnect
            // 
            this.cb_fastconnect.AutoSize = true;
            this.cb_fastconnect.Checked = true;
            this.cb_fastconnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_fastconnect.Location = new System.Drawing.Point(596, 14);
            this.cb_fastconnect.Name = "cb_fastconnect";
            this.cb_fastconnect.Size = new System.Drawing.Size(89, 17);
            this.cb_fastconnect.TabIndex = 8;
            this.cb_fastconnect.Text = "Fast Connect";
            this.cb_fastconnect.UseVisualStyleBackColor = true;
            this.cb_fastconnect.CheckedChanged += new System.EventHandler(this.cb_fastconnect_CheckedChanged);
            // 
            // cmb_port
            // 
            this.cmb_port.FormattingEnabled = true;
            this.cmb_port.Location = new System.Drawing.Point(12, 12);
            this.cmb_port.Name = "cmb_port";
            this.cmb_port.Size = new System.Drawing.Size(457, 21);
            this.cmb_port.TabIndex = 7;
            this.cmb_port.Text = "Searching SPD Diag Port...";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RichTextBox);
            this.groupBox2.Location = new System.Drawing.Point(475, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 382);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logs";
            // 
            // cb_charging
            // 
            this.cb_charging.AutoSize = true;
            this.cb_charging.Checked = true;
            this.cb_charging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_charging.Location = new System.Drawing.Point(691, 14);
            this.cb_charging.Name = "cb_charging";
            this.cb_charging.Size = new System.Drawing.Size(104, 17);
            this.cb_charging.TabIndex = 8;
            this.cb_charging.Text = "Charging Battery";
            this.cb_charging.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_WiFiAddr);
            this.groupBox3.Controls.Add(this.txt_BTAddr);
            this.groupBox3.Controls.Add(this.txt_IMEI2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cb_InitPhaseCheck);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btn_readaddr);
            this.groupBox3.Controls.Add(this.txt_SN2);
            this.groupBox3.Controls.Add(this.txt_SN1);
            this.groupBox3.Controls.Add(this.txt_IMEI1);
            this.groupBox3.Controls.Add(this.btn_readimei);
            this.groupBox3.Controls.Add(this.btn_writeaddr);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btn_readsn);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btn_writesn);
            this.groupBox3.Controls.Add(this.btn_writeimei);
            this.groupBox3.Location = new System.Drawing.Point(136, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(333, 321);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // txt_WiFiAddr
            // 
            this.txt_WiFiAddr.Location = new System.Drawing.Point(68, 144);
            this.txt_WiFiAddr.Name = "txt_WiFiAddr";
            this.txt_WiFiAddr.Size = new System.Drawing.Size(257, 20);
            this.txt_WiFiAddr.TabIndex = 11;
            // 
            // txt_BTAddr
            // 
            this.txt_BTAddr.Location = new System.Drawing.Point(68, 114);
            this.txt_BTAddr.Name = "txt_BTAddr";
            this.txt_BTAddr.Size = new System.Drawing.Size(257, 20);
            this.txt_BTAddr.TabIndex = 11;
            // 
            // txt_IMEI2
            // 
            this.txt_IMEI2.Location = new System.Drawing.Point(68, 54);
            this.txt_IMEI2.Name = "txt_IMEI2";
            this.txt_IMEI2.Size = new System.Drawing.Size(257, 20);
            this.txt_IMEI2.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Wi-Fi Addr";
            // 
            // cb_InitPhaseCheck
            // 
            this.cb_InitPhaseCheck.AutoSize = true;
            this.cb_InitPhaseCheck.Location = new System.Drawing.Point(9, 203);
            this.cb_InitPhaseCheck.Name = "cb_InitPhaseCheck";
            this.cb_InitPhaseCheck.Size = new System.Drawing.Size(107, 17);
            this.cb_InitPhaseCheck.TabIndex = 8;
            this.cb_InitPhaseCheck.Text = "Init Phase Check";
            this.cb_InitPhaseCheck.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "BT Addr";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "IMEI 2";
            // 
            // btn_readaddr
            // 
            this.btn_readaddr.Location = new System.Drawing.Point(68, 170);
            this.btn_readaddr.Name = "btn_readaddr";
            this.btn_readaddr.Size = new System.Drawing.Size(57, 24);
            this.btn_readaddr.TabIndex = 9;
            this.btn_readaddr.Text = "Read";
            this.btn_readaddr.UseVisualStyleBackColor = true;
            // 
            // txt_SN2
            // 
            this.txt_SN2.Location = new System.Drawing.Point(68, 261);
            this.txt_SN2.Name = "txt_SN2";
            this.txt_SN2.Size = new System.Drawing.Size(258, 20);
            this.txt_SN2.TabIndex = 11;
            // 
            // txt_SN1
            // 
            this.txt_SN1.Location = new System.Drawing.Point(68, 231);
            this.txt_SN1.Name = "txt_SN1";
            this.txt_SN1.Size = new System.Drawing.Size(259, 20);
            this.txt_SN1.TabIndex = 11;
            // 
            // txt_IMEI1
            // 
            this.txt_IMEI1.Location = new System.Drawing.Point(68, 24);
            this.txt_IMEI1.Name = "txt_IMEI1";
            this.txt_IMEI1.Size = new System.Drawing.Size(257, 20);
            this.txt_IMEI1.TabIndex = 11;
            // 
            // btn_readimei
            // 
            this.btn_readimei.Location = new System.Drawing.Point(68, 81);
            this.btn_readimei.Name = "btn_readimei";
            this.btn_readimei.Size = new System.Drawing.Size(57, 24);
            this.btn_readimei.TabIndex = 9;
            this.btn_readimei.Text = "Read";
            this.btn_readimei.UseVisualStyleBackColor = true;
            this.btn_readimei.Click += new System.EventHandler(this.btn_readimei_Click);
            // 
            // btn_writeaddr
            // 
            this.btn_writeaddr.Location = new System.Drawing.Point(268, 170);
            this.btn_writeaddr.Name = "btn_writeaddr";
            this.btn_writeaddr.Size = new System.Drawing.Size(57, 24);
            this.btn_writeaddr.TabIndex = 9;
            this.btn_writeaddr.Text = "Write";
            this.btn_writeaddr.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "SN 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "SN 1";
            // 
            // btn_readsn
            // 
            this.btn_readsn.Location = new System.Drawing.Point(68, 287);
            this.btn_readsn.Name = "btn_readsn";
            this.btn_readsn.Size = new System.Drawing.Size(57, 24);
            this.btn_readsn.TabIndex = 9;
            this.btn_readsn.Text = "Read";
            this.btn_readsn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "IMEI 1";
            // 
            // btn_writesn
            // 
            this.btn_writesn.Location = new System.Drawing.Point(268, 287);
            this.btn_writesn.Name = "btn_writesn";
            this.btn_writesn.Size = new System.Drawing.Size(57, 24);
            this.btn_writesn.TabIndex = 9;
            this.btn_writesn.Text = "Write";
            this.btn_writesn.UseVisualStyleBackColor = true;
            // 
            // btn_writeimei
            // 
            this.btn_writeimei.Location = new System.Drawing.Point(268, 81);
            this.btn_writeimei.Name = "btn_writeimei";
            this.btn_writeimei.Size = new System.Drawing.Size(57, 24);
            this.btn_writeimei.TabIndex = 9;
            this.btn_writeimei.Text = "Write";
            this.btn_writeimei.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtb_ATCommand);
            this.groupBox4.Controls.Add(this.btn_ATSend);
            this.groupBox4.Location = new System.Drawing.Point(136, 361);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(332, 55);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "AT Command";
            // 
            // rtb_ATCommand
            // 
            this.rtb_ATCommand.Location = new System.Drawing.Point(6, 19);
            this.rtb_ATCommand.Name = "rtb_ATCommand";
            this.rtb_ATCommand.Size = new System.Drawing.Size(255, 30);
            this.rtb_ATCommand.TabIndex = 10;
            this.rtb_ATCommand.Text = "";
            // 
            // btn_ATSend
            // 
            this.btn_ATSend.Location = new System.Drawing.Point(269, 21);
            this.btn_ATSend.Name = "btn_ATSend";
            this.btn_ATSend.Size = new System.Drawing.Size(57, 24);
            this.btn_ATSend.TabIndex = 11;
            this.btn_ATSend.Text = "Send";
            this.btn_ATSend.UseVisualStyleBackColor = true;
            this.btn_ATSend.Click += new System.EventHandler(this.btn_ATSend_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 426);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmb_port);
            this.Controls.Add(this.cb_charging);
            this.Controls.Add(this.cb_fastconnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unisoc AT - HadiK IT - C# Version";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.ComponentModel.BackgroundWorker ATWorker;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btn_poweroff;
        public System.Windows.Forms.Button btn_reboot;
        public System.Windows.Forms.Button btn_backlight;
        public System.Windows.Forms.Button btn_factory;
        public System.Windows.Forms.RichTextBox RichTextBox;
        public System.Windows.Forms.ComboBox cmb_port;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_WiFiAddr;
        private System.Windows.Forms.TextBox txt_BTAddr;
        private System.Windows.Forms.TextBox txt_IMEI2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_InitPhaseCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btn_readaddr;
        private System.Windows.Forms.TextBox txt_SN2;
        private System.Windows.Forms.TextBox txt_SN1;
        private System.Windows.Forms.TextBox txt_IMEI1;
        public System.Windows.Forms.Button btn_readimei;
        public System.Windows.Forms.Button btn_writeaddr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btn_writesn;
        public System.Windows.Forms.Button btn_writeimei;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.CheckBox cb_charging;
        public System.Windows.Forms.CheckBox cb_fastconnect;
        private System.Windows.Forms.RichTextBox rtb_ATCommand;
        public System.Windows.Forms.Button btn_ATSend;
        public System.Windows.Forms.Button btn_readsn;
    }
}

