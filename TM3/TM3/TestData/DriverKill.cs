using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM3.TestData
{
    public class DriverKill
    {
        public static void KillDriver()
        {
            Process[] proc1 = Process.GetProcessesByName("chrome");
            foreach (Process chrome in proc1)
            {
                chrome.Kill();
            }

            Process[] proc = Process.GetProcessesByName("chromedriver");
            foreach (Process chromedriver in proc)
            {
                chromedriver.Kill();
            }
        }
    }
}
