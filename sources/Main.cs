using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace  Unisoc_AT_HadiKIT
{
    public partial class Main : Form
    {
        public static Main DelegateFunction;
        public Stopwatch Watch = new Stopwatch();
        public Main()
        {
            InitializeComponent();
            Load += Main_Load;
            FormClosing += Main_FormClosing;
            ATWorker.DoWork += ATWorker_DoWork;
            ATWorker.RunWorkerCompleted += ATWorker_RunWorkerCompleted;
            ATWorker.RunWorkerAsync();
        }
        private void ATWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Watch.Start();

            while (!USBFastConnect.started)
            {
                USBFastConnect.FastConnect();
                break;
            }

            while (!USBFastConnect.stop)
            {
                Console.ReadLine();
            }

            if (USBFastConnect.stop)
            {
                USBFastConnect.FastConnectClose();
                e.Cancel = true;
                return;
            }
        }
        private void ATWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            PortIO.PortClose();
            PortIO.PortCOMDiag = "";
            USBFastConnect.found = false;
            USBFastConnect.count = 0;
            USBFastConnect.started = false;
            USBFastConnect.stop = false;
            Console.WriteLine("FastConnect Elapsed Time : " + Watch.ElapsedMilliseconds);
            Watch.Restart();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            DelegateFunction = this;
            btn_factory.Enabled = false;
            btn_backlight.Enabled = false;
            btn_reboot.Enabled = false;
            RichLogs("Please Turn Off Devices and Plug-In USB...", Color.Black, false, true);
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ATWorker.IsBusy)
            {
                ATWorker.CancelAsync();
                USBFastConnect.FastConnectClose();
            }
        }
        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            RichTextBox.Invoke(new Action(() =>
            {
                if (RichTextBox.Text.Contains("Sending Payload   : Sending Payload   : "))
                {
                    RichTextBox_Clear();
                    checkBox1.Checked = false;
                    MessageBox.Show("Sending Payload Failed! Please try again...");
                    Main.DelegateFunction.cmb_port.Invoke(new Action(() => { Main.DelegateFunction.cmb_port.Text = ""; }));
                }
                if (RichTextBox.Text.Contains("Sending Payload   : OKOK"))
                {
                    RichTextBox_Clear();
                    checkBox1.Checked = false;
                    MessageBox.Show("Sending Payload Failed! Please try again...");
                    Main.DelegateFunction.cmb_port.Invoke(new Action(() => { Main.DelegateFunction.cmb_port.Text = ""; }));
                }
                RichTextBox.SelectionStart = RichTextBox.Text.Length;
                RichTextBox.ScrollToCaret();
            }));
        }
        public void RichTextBox_Clear()
        {
            RichTextBox.Invoke(new Action(() => { RichTextBox.Clear(); }));
        }
        public void RichLogs(string msg, Color colour, bool isBold, bool NextLine = false)
        {
            RichTextBox.Invoke(new Action(() =>
            {
                RichTextBox.SelectionStart = RichTextBox.Text.Length;
                var selectionColor = RichTextBox.SelectionColor;
                RichTextBox.SelectionColor = colour;
                if (isBold)
                {
                    RichTextBox.SelectionFont = new Font(RichTextBox.Font, FontStyle.Bold);
                }
                else
                {
                    RichTextBox.SelectionFont = new Font(RichTextBox.Font, FontStyle.Regular);
                }
                RichTextBox.AppendText(msg);
                RichTextBox.SelectionColor = selectionColor;
                if (NextLine)
                {
                    if (RichTextBox.TextLength > 0)
                    {
                        RichTextBox.AppendText(Environment.NewLine);
                    }
                }
            }));
        }
        private void btn_backlight_Click(object sender, EventArgs e)
        {
            if (PortIO.serialPort.IsOpen)
            {
                if (USBFastConnect.count == 1)
                {
                    Main.DelegateFunction.RichLogs("Turn On Backlight : ", Color.Black, true, false);
                    Console.WriteLine("Sending backlight");
                    PortIO.PortWrite(Properties.Resources.backlight);
                    Main.DelegateFunction.RichLogs("OK", Color.Lime, true, true);
                }
            }
        }
        private void btn_reboot_Click(object sender, EventArgs e)
        {
            if (PortIO.serialPort.IsOpen)
            {
                if (USBFastConnect.count == 1)
                {
                    Main.DelegateFunction.RichLogs("Reboot                : ", Color.Black, true, false);
                    Console.WriteLine("Reboot");
                    PortIO.PortWrite(Properties.Resources.reboot);
                    Main.DelegateFunction.RichLogs("OK", Color.Lime, true, true);
                    checkBox1.Checked = false;
                }
            }
        }
        private void btn_factory_Click(object sender, EventArgs e)
        {
            if (PortIO.serialPort.IsOpen)
            {
                if (USBFastConnect.count == 1)
                {
                    Main.DelegateFunction.RichLogs("Factory Reset       : ", Color.Black, true, false);
                    PortIO.PortWrite(Properties.Resources.factory);
                    Main.DelegateFunction.RichLogs("OK", Color.Lime, true, true);
                    checkBox1.Checked = false;
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Main.DelegateFunction.btn_factory.Invoke(new Action(() => { Main.DelegateFunction.btn_factory.Enabled = false; }));
            Main.DelegateFunction.btn_backlight.Invoke(new Action(() => { Main.DelegateFunction.btn_backlight.Enabled = false; }));
            Main.DelegateFunction.btn_reboot.Invoke(new Action(() => { Main.DelegateFunction.btn_reboot.Enabled = false; }));
            if (checkBox1.Checked)
            {
                RichTextBox_Clear();
                RichLogs("Please Turn Off Devices and Plug-In USB...", Color.Black, false, true);
                Main.DelegateFunction.cmb_port.Invoke(new Action(() => { Main.DelegateFunction.cmb_port.Text = "Searching SPD Diag Port..."; }));
                ATWorker.RunWorkerAsync();
            }
            else if (!checkBox1.Checked)
            {
                RichTextBox_Clear();
                Main.DelegateFunction.cmb_port.Invoke(new Action(() => { Main.DelegateFunction.cmb_port.Text = "Please Activate Fast Connect To Start... "; }));
                USBFastConnect.stop = true;
            }
        }
    }
}
