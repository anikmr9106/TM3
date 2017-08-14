using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TM3.TestData;

namespace TM3.Page_Object
{
    class Negotiated_Sale_Result
    {
        ExtentTest test = ExtentReport.ReportStart("Negotiated Sale Results", "Negotiated Sale Results Functionality Under Primary Market");

        public void checkingdata(IWebDriver driver)
        {

            List<IWebElement> list_Neg_link = new List<IWebElement>();
            string firstpart = "_idJsp2:_idJsp3:";
            string secondpart = ":_idJsp6";
            int count = 0;
            int i = 0;
            do
            {
                string fullxpath = firstpart + count + secondpart;
                try
                {
                    IWebElement e = driver.FindElement(By.Id(fullxpath));
                    if (e.Displayed)
                    {
                        list_Neg_link.Add(e);
                        count++;
                        i = 0;
                    }

                }
                catch
                {
                    i = 1;
                }
            } while (i == 0);

            IList<IWebElement> date_list = driver.FindElements(By.XPath("//*[@id='_idJsp2:_idJsp3']/li/span"));




            Console.WriteLine(date_list[0].Text);
            Console.WriteLine(date_list[date_list.Count - 1].Text);

            ExtentReport.ReportLog(test, "Info", "Number of News Links Under Negotiated Sale Results" + "  " + count + "  " + "Starting from date" +
                " " + date_list[0].Text + " " + "to" + " " + date_list[date_list.Count - 1].Text, driver);

            Random random = new Random();
            int num = random.Next(5, 8);

            try
            {
                for (int j = 0; j < num; j++)
                {
                    list_Neg_link[j].Click();
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    ExtentReport.ReportLog(test, "Pass", "Clicked on the News Links Under Negotiated Sale Results", driver);
                    IWebElement elemen = driver.FindElement(By.Id("closeOverlay"));
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("arguments[0].click();", elemen);
                }
            }

            catch
            {
                driver.Navigate().Refresh();
                Thread.Sleep(TimeSpan.FromSeconds(6));
                List<IWebElement> list_Neg_link1 = new List<IWebElement>();
                string firstpart1 = "_idJsp2:_idJsp3:";
                string secondpart1 = ":_idJsp6";
                int count1 = 0;
                int i1 = 0;
                do
                {
                    string fullxpath = firstpart1 + count1 + secondpart1;
                    try
                    {
                        IWebElement e = driver.FindElement(By.Id(fullxpath));
                        if (e.Displayed)
                        {
                            list_Neg_link1.Add(e);
                            count1++;
                            i1 = 0;
                        }

                    }
                    catch
                    {
                        i1 = 1;
                    }
                } while (i1 == 0);

                for (int j = 0; j < num; j++)
                {
                    list_Neg_link1[j].Click();
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    ExtentReport.ReportLog(test, "Pass", "Clicked on the News Links Under Negotiated Sale Results", driver);
                    IWebElement elemen = driver.FindElement(By.Id("closeOverlay"));
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("arguments[0].click();", elemen);
                }

            }

            ExtentReport.ReportStop(test);
        }
    }
}
