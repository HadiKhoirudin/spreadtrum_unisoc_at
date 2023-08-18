using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace  Unisoc_AT_HadiKIT
{
    public partial class Main : Form
    {
        public static Main DelegateFunction;
        public static string ATCommand = "";
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

            //HexToImei(ImeiToHex("867400020316612"));
            //HexToImei(ImeiToHex("867400020316620"));
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ATWorker.IsBusy)
            {
                ATWorker.CancelAsync();
                USBFastConnect.stop = true;
            }
        }
        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            RichTextBox.Invoke(new Action(() =>
            {
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
        private void cb_fastconnect_CheckedChanged(object sender, EventArgs e)
        {
            Main.DelegateFunction.btn_factory.Invoke(new Action(() => { Main.DelegateFunction.btn_factory.Enabled = false; }));
            Main.DelegateFunction.btn_backlight.Invoke(new Action(() => { Main.DelegateFunction.btn_backlight.Enabled = false; }));
            Main.DelegateFunction.btn_reboot.Invoke(new Action(() => { Main.DelegateFunction.btn_reboot.Enabled = false; }));
            if (cb_fastconnect.Checked)
            {
                RichTextBox_Clear();
                RichLogs("Please Turn Off Devices and Plug-In USB...", Color.Black, false, true);
                Main.DelegateFunction.cmb_port.Invoke(new Action(() => { Main.DelegateFunction.cmb_port.Text = "Searching SPD Diag Port..."; }));
                ATWorker.RunWorkerAsync();
            }
            else if (!cb_fastconnect.Checked)
            {
                RichTextBox_Clear();
                Main.DelegateFunction.cmb_port.Invoke(new Action(() => { Main.DelegateFunction.cmb_port.Text = "Please Activate Fast Connect To Start... "; }));
                USBFastConnect.stop = true;
            }
        }
        public string ImeiToHex(string imei)
        {
            if (string.IsNullOrEmpty(imei)) return "";
            imei = imei.Trim();
            if (imei.Length != 15) return "";
            string res = imei.Substring(0, 1) + "A ";
            for (int i = 1; i < imei.Length; i += 2)
                res += imei.Substring(i + 1, 1) + imei.Substring(i, 1) + " ";

            Console.WriteLine("Imei To Hex : " + res);
            return res;
        }
        public static string HexToImei(string hex)
        {
            if (string.IsNullOrEmpty(hex)) return "";
            hex = hex.Replace(" ", "").Replace("-", "");
            if (hex.Length != 16) return "";
            string res = hex.Substring(0, 1) + "A ";
            for (int i = 0; i < hex.Length; i += 2)
                res += hex.Substring(i + 1, 1) + hex.Substring(i, 1) + " ";

            res = res.Substring(4).Replace(" ", "");
            Console.WriteLine("Hex To Imei : " + res);
            return res;
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
                    Main.DelegateFunction.RichLogs("Reboot            : ", Color.Black, true, false);
                    Console.WriteLine("Reboot");
                    PortIO.PortWrite(Properties.Resources.reboot);
                    Main.DelegateFunction.RichLogs("OK", Color.Lime, true, true);
                    Program.Delay(4);
                    cb_fastconnect.Checked = false;
                }
            }
        }
        private void btn_factory_Click(object sender, EventArgs e)
        {
            if (PortIO.serialPort.IsOpen)
            {
                if (USBFastConnect.count == 1)
                {
                    Main.DelegateFunction.RichLogs("Factory Reset     : ", Color.Black, true, false);
                    PortIO.PortWrite(Properties.Resources.factory);
                    Main.DelegateFunction.RichLogs("OK", Color.Lime, true, true);
                    Program.Delay(4);
                    cb_fastconnect.Checked = false;
                }
            }
        }
        private void btn_poweroff_Click(object sender, EventArgs e)
        {
            if (PortIO.serialPort.IsOpen)
            {
                if (USBFastConnect.count == 1)
                {
                    Main.DelegateFunction.RichLogs("Power Off         : ", Color.Black, true, false);
                    PortIO.PortWrite(Properties.Resources.factory);
                    Main.DelegateFunction.RichLogs("OK", Color.Lime, true, true);
                    Program.Delay(4);
                    cb_fastconnect.Checked = false;
                }
            }
        }
        private void btn_readimei_Click(object sender, EventArgs e)
        {
            if (PortIO.serialPort.IsOpen)
            {
                if (USBFastConnect.count == 1)
                {
                    Main.DelegateFunction.RichLogs("Read IMEI         : ", Color.Black, true, false);
                    PortIO.PortWrite(Properties.Resources.readimei);
                    Program.Delay(1);
                    string resp = Encoding.Default.GetString(PortIO.resp);
                    if (resp.Contains("Š"))
                    {
                        Main.DelegateFunction.RichLogs("OK", Color.Lime, true, true);
                        int offset = resp.IndexOf("Š");
                        Console.WriteLine("IMEI String : " + resp);
                        Console.WriteLine("IMEI Offset : " + offset);

                        string IMEI1 = HexToImei(BitConverter.ToString(PortIO.resp.Skip(offset).Take(8).ToArray()));
                        string IMEI2 = HexToImei(BitConverter.ToString(PortIO.resp.Skip(offset + 8).Take(8).ToArray()));

                        txt_IMEI1.Text = IMEI1;
                        txt_IMEI2.Text = IMEI2;
                    }
                    else
                    {
                        Main.DelegateFunction.RichLogs("Failed", Color.Crimson, true, true);
                        txt_IMEI1.Text = "NULL";
                        txt_IMEI2.Text = "NULL";
                    }
                }
            }
        }
        private void btn_ATSend_Click(object sender, EventArgs e)
        {
            if (PortIO.serialPort.IsOpen)
            {
                if (rtb_ATCommand.Text != "")
                {
                    PortIO.AT_Command = rtb_ATCommand.Text;
                    PortIO.PortWriteAT();
                }
            }
        }


    }
}
