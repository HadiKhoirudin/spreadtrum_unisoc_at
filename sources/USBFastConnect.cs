using System;
using System.Drawing;
using System.IO;
using System.Management;

namespace  Unisoc_AT_HadiKIT
{
    public static class USBFastConnect
    {
        public static ManagementEventWatcher WatchConnect;
        public static ManagementEventWatcher WatchDisconnected;
        public static bool found = false;
        public static bool started = false;
        public static bool stop = false;
        public static int count = 0;
        public static void FastConnect()
        {
                Console.WriteLine("FastConnect Start...");
            // Membuat objek ManagementEventWatcher untuk memantau perubahan pada device USB
            WqlEventQuery QueryUSBConnected = new WqlEventQuery(
                "SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBControllerDevice'");
            WatchConnect = new ManagementEventWatcher(QueryUSBConnected);

            // Menambahkan event handler untuk event USB
            WatchConnect.EventArrived += USBDeviceConnected;

            // Memulai pemantauan
            WatchConnect.Start();
            started = true;
        }
        public static void FastDisconnect()
        {
            // Membuat objek ManagementEventWatcher untuk memantau perubahan pada device USB
            WqlEventQuery QueryUSBDisconnected = new WqlEventQuery(
                "SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");
            WatchDisconnected = new ManagementEventWatcher(QueryUSBDisconnected);

            // Menambahkan event handler untuk event USB
            WatchDisconnected.EventArrived += USBDeviceDisconnected;

            // Memulai pemantauan
            WatchDisconnected.Start();
        }
        public static void USBDeviceConnected(object sender, EventArrivedEventArgs e)
        {
            // Mendapatkan informasi device USB yang baru disambungkan
            ManagementBaseObject targetInstance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            string deviceId = targetInstance["Dependent"].ToString() ?? string.Empty;
        
            Console.WriteLine("USB VID & PID : " + Get_VID_PID(deviceId));
        
            if (deviceId.Contains("VID_1782&PID_4D00"))
            {
                found = true;
                PortIO.USBPortDevice("1782", "4D00");
                PortIO.PortOpen(PortIO.PortCOMDiag);

                Main.DelegateFunction.cmb_port.Invoke(new Action(() => { Main.DelegateFunction.cmb_port.Text = "USB Port SPRD U2S Diag (COM" + PortIO.PortCOMDiag + ")"; }));

                if (PortIO.serialPort.IsOpen)
                {
                    if (count == 0)
                    {
                        Main.DelegateFunction.RichLogs("Sending Payload   : ", Color.Black, true, false);
                        Console.WriteLine("Sending Payload");
                        PortIO.PortWrite(Properties.Resources.payload);
                    }
                    if (count == 1)
                    {
                        Main.DelegateFunction.RichLogs("Enter Diag Mode   : ", Color.Black, true, false);
                        Main.DelegateFunction.RichLogs("Success", Color.Lime, true, true);
                        Main.DelegateFunction.btn_factory.Invoke(new Action(() => { Main.DelegateFunction.btn_factory.Enabled = true; }));
                        Main.DelegateFunction.btn_backlight.Invoke(new Action(() => { Main.DelegateFunction.btn_backlight.Enabled = true; }));
                        Main.DelegateFunction.btn_reboot.Invoke(new Action(() => { Main.DelegateFunction.btn_reboot.Enabled = true; }));
                     }
                    FastDisconnect();
                }
                else
                {
                    Console.WriteLine("Port Closed....");
                }
            }

        }
        public static void USBDeviceDisconnected(object sender, EventArrivedEventArgs e)
        {
            if (USBDisconnectCheck("1782", "4D00"))
            {
                if (found)
                {
                    Console.WriteLine("SPD Diag Port Disconnected! ");
                    if (count == 0)
                    {
                        Main.DelegateFunction.RichLogs("OK", Color.Lime, true, true);
                        Main.DelegateFunction.cmb_port.Invoke(new Action(() => { Main.DelegateFunction.cmb_port.Text = "Searching SPD Diag Port..."; }));
                    }
                    WatchDisconnected.Stop();
                    PortIO.PortClose();
                    count++;
                    found = false;
                }
            }
        }
        public static void FastConnectClose()
        {
            // Mengakhiri pemantauan *Gunakan saat menutup form
            // Misalnya: private void Main_FormClosing(object sender, FormClosingEventArgs e)
            // {
            //     USBFastConnect.FastConnectClose();
            //     // Tindakan penutupan form lainnya...
            // }
            WatchConnect.Stop();
        }
        public static string Get_VID_PID(string input)
        {
            int startIndex = input.IndexOf('"') + 1;
            int endIndex = input.LastIndexOf('\\') - 1;

            if (startIndex > 0 && endIndex > 0)
            {
                return input.Substring(startIndex, endIndex - startIndex).Replace("USB", "").Replace("\\", "");
            }

            return "";
        }
        public static bool USBDisconnectCheck(string VID, string PID)
        {
            ManagementObjectCollection.ManagementObjectEnumerator enumerator = null;
            using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\cimv2", "SELECT * FROM Win32_USBControllerDevice"))
            {
                enumerator = managementObjectSearcher.Get().GetEnumerator();
                while (enumerator.MoveNext())
                {
                    ManagementObject current = (ManagementObject)enumerator.Current;
                    string str = current["Dependent"].ToString();
                    if (str.Contains("VID_" + VID + "&PID_" + PID))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
