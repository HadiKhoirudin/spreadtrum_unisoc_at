
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
            this.cmb_port = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.RichTextBox = new System.Windows.Forms.RichTextBox();
            this.btn_factory = new System.Windows.Forms.Button();
            this.btn_backlight = new System.Windows.Forms.Button();
            this.btn_reboot = new System.Windows.Forms.Button();
            this.ATWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // cmb_port
            // 
            this.cmb_port.FormattingEnabled = true;
            this.cmb_port.Location = new System.Drawing.Point(13, 13);
            this.cmb_port.Name = "cmb_port";
            this.cmb_port.Size = new System.Drawing.Size(243, 21);
            this.cmb_port.TabIndex = 1;
            this.cmb_port.Text = "Searching SPD Diag Port...";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(262, 15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Fast Connect";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // RichTextBox
            // 
            this.RichTextBox.Location = new System.Drawing.Point(13, 40);
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.Size = new System.Drawing.Size(338, 108);
            this.RichTextBox.TabIndex = 0;
            this.RichTextBox.Text = "";
            this.RichTextBox.TextChanged += new System.EventHandler(this.RichTextBox_TextChanged);
            // 
            // btn_factory
            // 
            this.btn_factory.Location = new System.Drawing.Point(12, 156);
            this.btn_factory.Name = "btn_factory";
            this.btn_factory.Size = new System.Drawing.Size(108, 24);
            this.btn_factory.TabIndex = 3;
            this.btn_factory.Text = "Factory Reset";
            this.btn_factory.UseVisualStyleBackColor = true;
            this.btn_factory.Click += new System.EventHandler(this.btn_factory_Click);
            // 
            // btn_backlight
            // 
            this.btn_backlight.Location = new System.Drawing.Point(127, 156);
            this.btn_backlight.Name = "btn_backlight";
            this.btn_backlight.Size = new System.Drawing.Size(108, 24);
            this.btn_backlight.TabIndex = 4;
            this.btn_backlight.Text = "Turn On Backlight";
            this.btn_backlight.UseVisualStyleBackColor = true;
            this.btn_backlight.Click += new System.EventHandler(this.btn_backlight_Click);
            // 
            // btn_reboot
            // 
            this.btn_reboot.Location = new System.Drawing.Point(243, 156);
            this.btn_reboot.Name = "btn_reboot";
            this.btn_reboot.Size = new System.Drawing.Size(108, 24);
            this.btn_reboot.TabIndex = 5;
            this.btn_reboot.Text = "Reboot";
            this.btn_reboot.UseVisualStyleBackColor = true;
            this.btn_reboot.Click += new System.EventHandler(this.btn_reboot_Click);
            // 
            // ATWorker
            // 
            this.ATWorker.WorkerReportsProgress = true;
            this.ATWorker.WorkerSupportsCancellation = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 188);
            this.Controls.Add(this.btn_reboot);
            this.Controls.Add(this.btn_backlight);
            this.Controls.Add(this.btn_factory);
            this.Controls.Add(this.RichTextBox);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cmb_port);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unisoc AT - HadiK IT - C# Version";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBox1;
        public System.ComponentModel.BackgroundWorker ATWorker;
        public System.Windows.Forms.RichTextBox RichTextBox;
        public System.Windows.Forms.ComboBox cmb_port;
        public System.Windows.Forms.Button btn_factory;
        public System.Windows.Forms.Button btn_backlight;
        public System.Windows.Forms.Button btn_reboot;
    }
}

