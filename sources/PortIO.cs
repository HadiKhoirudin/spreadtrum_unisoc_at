using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace  Unisoc_AT_HadiKIT
{
    class PortIO
    {
        public static SerialPort serialPort;
        public static string PortCOMDiag = "";
        public static byte[] resp = new byte[0];

        public static string AT_Start = "7E 00 00 00 00 17 00 68 00";
        public static string AT_Command = "";
        public static string AT_End = "0D 0A 7E";

        public static void PortOpen(string PortCOMDiag)
        {
            Console.WriteLine("Create New Serial Port To COM" + PortCOMDiag);
            serialPort = new SerialPort("COM" + PortCOMDiag);
            serialPort.BaudRate = 115200;
            serialPort.Parity = Parity.None;
            serialPort.Handshake = Handshake.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.RtsEnable = true;
            serialPort.DtrEnable = true;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
            serialPort.Open();
        }

        public static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            resp = PortRead();
            Console.WriteLine("Response : " + BitConverter.ToString(resp));
        }

        public static void PortClose()
        {
            if (PortCOMDiag != "")
            {
                foreach (String s in SerialPort.GetPortNames())
                {
                    if (PortCOMDiag.Contains(s))
                    {
                        if (serialPort.IsOpen)
                        {
                            serialPort.Close();
                        }
                    }
                }
                PortCOMDiag = "";
            }
        }
        public static byte[] StringToByteArray(string hex)
        {
            hex = hex.Replace(" ", "");
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        public static byte[] PortRead()
        {
            if (!serialPort.IsOpen) return new byte[0];
            int numBytes = serialPort.BytesToRead;
            byte[] buffer = new byte[numBytes];
            serialPort.Read(buffer, 0, numBytes);
            return buffer;
        }
        public static void PortWrite(byte[] request)
        {
            serialPort.Write(request, 0, request.Length);
        }
        public static void PortWriteAT()
        {
            byte[] b1 = StringToByteArray(AT_Start);
            byte[] b2 = Encoding.UTF8.GetBytes(AT_Command);
            byte[] b3 = StringToByteArray(AT_End);
            var s = new MemoryStream();
            s.Write(b1, 0, b1.Length);
            s.Write(b2, 0, b2.Length);
            s.Write(b3, 0, b3.Length);
            var b4 = s.ToArray();
            serialPort.Write(b4, 0, b4.Length);
        }
        public static void USBPortDevice(string VID, string PID)
        {
            List<string> names = ComPortNames(VID, PID);
            if (names.Count > 0)
            {
                foreach (String s in SerialPort.GetPortNames())
                {
                    if (names.Contains(s))
                    {
                        Console.WriteLine("SPD Diag Port : " + s);
                        PortIO.PortCOMDiag = s.Replace("COM", "");
                    }
                }
            }

        }
        public static List<string> ComPortNames(String VID, String PID)
        {
            String pattern = String.Format("^VID_{0}.PID_{1}", VID, PID);
            Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
            List<string> comports = new List<string>();
            RegistryKey rk1 = Registry.LocalMachine;
            RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");
            foreach (String s3 in rk2.GetSubKeyNames())
            {
                RegistryKey rk3 = rk2.OpenSubKey(s3);
                foreach (String s in rk3.GetSubKeyNames())
                {
                    if (_rx.Match(s).Success)
                    {
                        RegistryKey rk4 = rk3.OpenSubKey(s);
                        foreach (String s2 in rk4.GetSubKeyNames())
                        {
                            RegistryKey rk5 = rk4.OpenSubKey(s2);
                            RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                            comports.Add((string)rk6.GetValue("PortName"));
                        }
                    }
                }
            }
            return comports;
        }
    }
}
