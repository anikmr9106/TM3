using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM3.TestData
{
    class ExtentReport
    {
        public static ExtentReports extend = new ExtentReports(MyPath.reportpath);
        public static ExtentTest ReportStart(string Name, string Descrption)
        {
            ExtentTest test = extend.StartTest(Name, Descrption);
            return test;

        }

        public static void ReportLog(ExtentTest test, string status, string Description, IWebDriver driver = null)
        {
            switch (status)
            {
                case "Pass":
                    string filenamepass = Path.GetRandomFileName();
                    screenshots.takescreenshot(filenamepass, driver);
                    test.Log(LogStatus.Pass, Description, test.AddScreenCapture(MyPath.screenshotpath + filenamepass + ".jpeg"));
                    break;
                case "Fail":
                    string filename = Path.GetRandomFileName();
                    screenshots.takescreenshot(filename, driver);
                    test.Log(LogStatus.Fail, Description, test.AddScreenCapture(MyPath.screenshotpath + filename + ".jpeg"));
                    break;
                case "Error":
                    string filenameError = Path.GetRandomFileName();
                    screenshots.takescreenshot(filenameError, driver);
                    test.Log(LogStatus.Error, Description, test.AddScreenCapture(MyPath.screenshotpath + filenameError + ".jpeg"));
                    break;
                case "Info":
                    string filenameInfo = Path.GetRandomFileName();
                    screenshots.takescreenshot(filenameInfo, driver);
                    test.Log(LogStatus.Info, Description, test.AddScreenCapture(MyPath.screenshotpath + filenameInfo + ".jpeg"));
                    break;

            }
        }
        public static void ReportStop(ExtentTest test)
        {
            extend.EndTest(test);
            extend.Flush();
        }
    }
}
