using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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
    class Primary_Worksheets
    {

        public Primary_Worksheets(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        // Drop Dowm1  
        [FindsBy(How = How.Id, Using = "qualifier")]
        public IWebElement DropDowm1 { get; set; }

        // Drop Dowm2 
        [FindsBy(How = How.Id, Using = "product")]
        public IWebElement DropDowm2 { get; set; }

        // Go Button 
        [FindsBy(How = How.Id, Using = "pmWorksheetsForm:submitFilterBar")]
        public IWebElement btnGo { get; set; }

        // Sale Date Link 
        [FindsBy(How = How.Id, Using = "pmWorksheetsForm:_idJsp2")]
        public IWebElement SaleDateLink { get; set; }

        // Sate Link
        [FindsBy(How = How.Id, Using = "pmWorksheetsForm:_idJsp4")]
        public IWebElement StateLink { get; set; }

        // BankQual Link
        [FindsBy(How = How.Id, Using = "pmWorksheetsForm:_idJsp6")]
        public IWebElement BankQual { get; set; }

        // Amount Link  
        [FindsBy(How = How.Id, Using = "pmWorksheetsForm:_idJsp8")]
        public IWebElement Amount { get; set; }

        // Print Button   
        [FindsBy(How = How.Id, Using = "btnPrint")]
        public IWebElement btnPrint { get; set; }

        // Bookmark Button  
        [FindsBy(How = How.Id, Using = "btnBookmark")]
        public IWebElement btnBookmark { get; set; }

        //Sub Tab in Primary Market 
        [FindsBy(How = How.Id, Using = "subList4")]
        public IList<IWebElement> SubLink { get; set; }

        //PopUp Worksheet Tab
        [FindsBy(How = How.Id, Using = "Worksheet")]
        public IWebElement Popupworksheettab { get; set; }

        //PopUp BidParameters Tab
        [FindsBy(How = How.Id, Using = "BidParameters")]
        public IWebElement PopupBidParameterstab { get; set; }

        //PopUp Scale Tab
        [FindsBy(How = How.Id, Using = "Scale")]
        public IWebElement PopupScaletab { get; set; }

        //PopUp IssueInfo Tab
        [FindsBy(How = How.Id, Using = "IssueInfo")]
        public IWebElement PopupIssueInfotab { get; set; }

        //PopUp Docs Tab  
        [FindsBy(How = How.Id, Using = "Docs")]
        public IWebElement PopupDocstab { get; set; }

        //PopUp btnexcelLink Last5Sales
        [FindsBy(How = How.Id, Using = "IssueInfo")]
        public IWebElement popupbtnexcelLink { get; set; }

        //PopUp Last5Sales Tab
        [FindsBy(How = How.Id, Using = "Last5Sales")]
        public IWebElement popupLast5Sales { get; set; }

        //PopUp btnPrint 
        [FindsBy(How = How.Id, Using = "btnPrint")]
        public IWebElement popupbtnPrint { get; set; }

        //PopUp btnBookmark
        [FindsBy(How = How.Id, Using = "btnBookmark")]
        public IWebElement popupbtnBookmark { get; set; }

        ExtentTest test = ExtentReport.ReportStart(" Worksheets", "Worksheets Functionality Under Primary Tab");

        public void VerifyingWorksheets(IWebDriver driver)
        {
            try
            {
                //Primary Market Tab
                driver.FindElement(By.Id("topNav4")).Click();

                //Find the WORKSHEET Text From Primary Tab And Verifying 
                IWebElement worksheet = driver.FindElement(By.CssSelector("#pageTitle"));
                Assert.AreEqual("WORKSHEETS", worksheet.Text);
                ExtentReport.ReportLog(test, "Pass", "Navigated to WORKSHEETS Page in Primary Market", driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "Did Not Found WORKSHEET Title in Primary Market ", driver);
            }

        }

        public void SelectCompetitive_NegotiatedBonds_Notes(IWebDriver driver)
        {
            SelectElement dropdown1 = new SelectElement(DropDowm1);
            SelectElement dropdown2 = new SelectElement(DropDowm2);
            dropdown1.SelectByValue("CN");
            dropdown2.SelectByValue("BN");
            btnGo.Click();
            try
            {
                IWebElement CB = driver.FindElement(By.XPath("//*[@id='scrollContent']/p[1]/a[@name='CB']"));
                Assert.That(CB.Displayed);
                string CBtext = CB.Text;
                Assert.IsNotEmpty(CBtext);
                string start_date = driver.FindElement(By.Id("pmWorksheetsForm:compBondsList:0:sDate")).Text;
                ExtentReport.ReportLog(test, "Pass", CBtext + " Datas are populated From date" + "  " + start_date, driver);

            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "No data found for Competitive Bond", driver);
            }

            try
            {
                IWebElement CN = driver.FindElement(By.XPath("//*[@id='scrollContent']/p[2]/a[@name='CN']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", CN);
                Assert.That(CN.Displayed);
                string CBtext = CN.Text;
                Assert.IsNotEmpty(CBtext);
                string start_date = driver.FindElement(By.Id("pmWorksheetsForm:compNotesList:0:sDate")).Text;
                ExtentReport.ReportLog(test, "Pass", CBtext + " Datas are populated From date" + "  " + start_date, driver);

            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "No data found for Competitive Notes", driver);
            }
            try
            {
                IWebElement NB = driver.FindElement(By.XPath("//*[@id='scrollContent']/p[3]/a[@name='NB']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", NB);
                Assert.That(NB.Displayed);
                string CBtext = NB.Text;
                Assert.IsNotEmpty(CBtext);
                string start_date = driver.FindElement(By.Id("pmWorksheetsForm:negBondsList:0:wDate")).Text;
                ExtentReport.ReportLog(test, "Pass", CBtext + " Datas are populated From date" + "  " + start_date, driver);

            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "No data found for Negotiated Bonds", driver);
            }

            try
            {
                IWebElement NN = driver.FindElement(By.XPath("//*[@id='scrollContent']/p[4]/a"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", NN);
                Assert.That(NN.Displayed);
                string CBtext = NN.Text;
                Assert.IsNotEmpty(CBtext);
                string start_date = driver.FindElement(By.Id("pmWorksheetsForm:negNotesList:0:wDate")).Text;
                ExtentReport.ReportLog(test, "Pass", CBtext + " Datas are populated From date" + "  " + start_date, driver);

            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "No data found for Negotiated Notes", driver);
            }


            try
            {
                SaleDateLink.Click();
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[1]/a[@name='CB']")).Displayed);
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[2]/a[@name='CN']")).Displayed);
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[3]/a[@name='NB']")).Displayed);
                // Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[4]/a[@name='NH']")).Displayed);
                ExtentReport.ReportLog(test, "Pass", "Clicked on Sale Date Link. Now the data are grouped by Sale Date", driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "didnt clicked on Sale Date Link", driver);
            }

            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                StateLink.Click();
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[1]/a[@name='CB']")).Displayed);
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[2]/a[@name='CN']")).Displayed);
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[3]/a[@name='NB']")).Displayed);
                ExtentReport.ReportLog(test, "Pass", "Clicked on State Link. Now the data are grouped by State", driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "didnt clicked on State Link", driver);
            }

            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                BankQual.Click();
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[1]/a[@name='CB']")).Displayed);
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[2]/a[@name='CN']")).Displayed);
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[3]/a[@name='NB']")).Displayed);
                ExtentReport.ReportLog(test, "Pass", "Clicked on BankQual Link. Now the data are grouped by BankQual", driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "didnt clicked on BankQual Link", driver);
            }

            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Amount.Click();
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[1]/a[@name='CB']")).Displayed);
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[2]/a[@name='CN']")).Displayed);
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[3]/a[@name='NB']")).Displayed);
                ExtentReport.ReportLog(test, "Pass", "Clicked on Amount Link now the data are grouped by Amount", driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "didnt clicked on Amount Link", driver);
            }


        }

        public void SelectCompetitive_Negotiated_History(IWebDriver driver)
        {
            SelectElement dropdown1 = new SelectElement(DropDowm1);
            SelectElement dropdown2 = new SelectElement(DropDowm2);
            dropdown1.SelectByValue("CN");
            dropdown2.SelectByValue("HT");
            btnGo.Click();
            SaleDateLink.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));

            try
            {
                IWebElement CH = driver.FindElement(By.XPath("//*[@id='scrollContent']/p[1]/a"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", CH);
                Assert.That(CH.Displayed);
                string CBtext = CH.Text;
                Assert.IsNotEmpty(CBtext);
                string start_date = driver.FindElement(By.Id("pmWorksheetsForm:compHistList:0:sDate")).Text;
                ExtentReport.ReportLog(test, "Pass", CBtext + " Datas are populated From date" + "  " + start_date, driver);

            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "No data found for Competitive History", driver);
            }

            try
            {
                IWebElement NH = driver.FindElement(By.XPath("//*[@id='scrollContent']/p[2]/a"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", NH);
                Assert.That(NH.Displayed);
                string CBtext = NH.Text;
                Assert.IsNotEmpty(CBtext);
                string start_date = driver.FindElement(By.Id("pmWorksheetsForm:negHistList:0:sDate")).Text;
                ExtentReport.ReportLog(test, "Pass", CBtext + " Datas are populated From date" + "  " + start_date, driver);

            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "No data found for Negotiated History", driver);
            }

            try
            {
                SaleDateLink.Click();
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[1]/a")).Displayed);
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[2]/a")).Displayed);
                ExtentReport.ReportLog(test, "Pass", "Clicked on Sale Date Link. Now the data are grouped by Sale Date", driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "didnt clicked on Sale Date Link", driver);
            }

            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                StateLink.Click();
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[1]/a")).Displayed);
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[2]/a")).Displayed);
                ExtentReport.ReportLog(test, "Pass", "Clicked on State Link. Now the data are grouped by State", driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "didnt clicked on State Link", driver);
            }

            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                BankQual.Click();
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[1]/a")).Displayed);
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[2]/a")).Displayed);
                ExtentReport.ReportLog(test, "Pass", "Clicked on BankQual Link. Now the data are grouped by BankQual", driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "didnt clicked on BankQual Link", driver);
            }

            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Amount.Click();
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[1]/a")).Displayed);
                Assert.That(driver.FindElement(By.XPath("//*[@id='scrollContent']/p[2]/a")).Displayed);
                ExtentReport.ReportLog(test, "Pass", "Clicked on Amount Link now the data are grouped by Amount", driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "didnt clicked on Amount Link", driver);
            }

            ExtentReport.ReportStop(test);

        }

        public void SelectingDropDown1(IWebDriver driver)
        {
            SelectElement dropdown1 = new SelectElement(DropDowm1);
            SelectElement dropdown2 = new SelectElement(DropDowm2);
            try
            {
                for (int i = 0; i < dropdown1.Options.Count; i++)
                {
                    dropdown1.SelectByIndex(i);
                    string dropdown1text = dropdown1.SelectedOption.Text;
                    //Console.WriteLine(ss);

                    for (int j = 0; j < dropdown2.Options.Count; j++)
                    {

                        //Selecting Option From Dropdown2
                        dropdown2.SelectByIndex(j);
                        string dropdown2text = dropdown2.SelectedOption.Text;

                        //Clicking Go
                        btnGo.Click();
                        try
                        {
                            //Asseration with 
                            IList<IWebElement> list = driver.FindElements(By.XPath("//div[@id='scrollContent']/p/a"));
                            String str = null;
                            foreach (IWebElement ele in list)
                            {
                                if (ele.Text.ToString() != "" && ele.Displayed)
                                {
                                    str = str + " " + ele.Text.ToString();
                                }

                            }
                            ExtentReport.ReportLog(test, "Pass", "For the selected option" + " " + dropdown1text + " And " + dropdown2text + " " + "Following data are populated" + " " + str, driver);
                        }
                        catch
                        {
                            ExtentReport.ReportLog(test, "Fail", "Data didnt populate for selected options", driver);
                        }

                        //Adding to Report
                        ExtentReport.ReportLog(test, "Pass", "Selected " + dropdown1.SelectedOption.Text + " From dropdown1" + "  &  " + dropdown2.SelectedOption.Text + " From dropdown2 & Clicked on GO", driver);
                        try
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(5));
                            //Clicking Sale Date Links Under Groupby
                            SaleDateLink.Click();

                            Thread.Sleep(TimeSpan.FromSeconds(5));
                            //Clicking State Links Under Groupby
                            StateLink.Click();

                            Thread.Sleep(TimeSpan.FromSeconds(5));
                            //Clicking Bank Qual Links Under Groupby
                            BankQual.Click();

                            Thread.Sleep(TimeSpan.FromSeconds(5));
                            //Clicking Amount Links Under Groupby
                            Amount.Click();
                            Thread.Sleep(TimeSpan.FromSeconds(5));
                        }
                        catch
                        {
                            ExtentReport.ReportLog(test, "Fail", "Element Didnt Found", driver);
                        }
                    }
                }
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", " It didn't Selected  " + dropdown1.SelectedOption.Text + "  &  " + dropdown2.SelectedOption.Text, driver);
            }

            ExtentReport.ReportStop(test);
        }

    }
}
