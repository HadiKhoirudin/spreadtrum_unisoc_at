using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace  Unisoc_AT_HadiKIT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
        public static void Delay(double dblSecs)
        {
            DateTime.Now.AddSeconds(0.0000115740740740741d);
            var dateTime = DateTime.Now.AddSeconds(0.0000115740740740741d);
            var dateTime1 = dateTime.AddSeconds(dblSecs);
            while (DateTime.Compare(DateTime.Now, dateTime1) <= 0)
                Application.DoEvents();
        }
    }
}
