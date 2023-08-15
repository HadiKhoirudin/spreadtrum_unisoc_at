using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text.RegularExpressions;

namespace  Unisoc_AT_HadiKIT
{
    class PortIO
    {
        public static SerialPort serialPort;
        public static string PortCOMDiag = "";
        public static void PortOpen(string PortCOMDiag)
        {
            Console.WriteLine("Create New Serial Port To COM" + PortCOMDiag);
            serialPort = new SerialPort("COM" + PortCOMDiag);
            serialPort.RtsEnable = true;
            serialPort.DtrEnable = true;
            serialPort.WriteBufferSize = serialPort.BaudRate;
            serialPort.Open();
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
        public static byte[] PortRead()
        {
            int numBytes = serialPort.BytesToRead;
            byte[] buffer = new byte[numBytes];
            serialPort.Read(buffer, 0, numBytes);
            return buffer;
        }
        public static void PortWrite(byte[] request)
        {
            serialPort.Write(request, 0, request.Length);
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
