using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM3.Page_Object;
using TM3.TestData;

namespace TM3.Workflow
{
    public class VRDN_Create_Portfolio
    {
        static ExtentTest test = ExtentReport.ReportStart("Create Portfolio", "Create Portfolio");

        public static void create_portfolio(IWebDriver driver)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(45));
                driver.FindElement(By.XPath("//*[@id='topNav7']/a[1]")).Click();
                driver.FindElement(By.XPath("//*[@id='subList7']/li[4]/a")).Click();
                VRDN_PortfolioManagement vr = new VRDN_PortfolioManagement(driver);
                vr.create_new_portfolio.Click();
                vr.portfolio_name.SendKeys("Test1_Anil");
                vr.manual_cusip_entry.SendKeys("123404AA3");
                vr.add_btn.Click();
                vr.manual_cusip_entry.SendKeys("123404AB1");
                vr.add_btn.Click();
                vr.manual_cusip_entry.SendKeys("123404AE5");
                vr.add_btn.Click();
                vr.manual_cusip_entry.SendKeys("782667BA6");
                vr.add_btn.Click();
                vr.manual_cusip_entry.SendKeys("782667AZ2");
                vr.add_btn.Click();
                vr.save_btn.Click();


                vr.create_new_portfolio.Click();
                vr.portfolio_name.SendKeys("Test2_Anil");
                vr.manual_cusip_entry.SendKeys("782637AA0");
                vr.add_btn.Click();
                vr.manual_cusip_entry.SendKeys("782637AB8");
                vr.add_btn.Click();
                vr.manual_cusip_entry.SendKeys("782637AC6");
                vr.add_btn.Click();
                vr.manual_cusip_entry.SendKeys("782667BA6");
                vr.add_btn.Click();
                vr.manual_cusip_entry.SendKeys("782667AZ2");
                vr.add_btn.Click();
                vr.save_btn.Click();

            }

            catch
            {
                ExtentReport.ReportLog(test, "Fail", "Portfolio is not created", driver);
            }

            ExtentReport.ReportLog(test, "Pass", "Portfolio is created", driver);

            ExtentReport.ReportStop(test);
        }


    }
}
