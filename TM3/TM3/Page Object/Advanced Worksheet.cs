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
    class Advanced_Worksheet
    {
        public Advanced_Worksheet(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Worksheet Advance Search Tab
        [FindsBy(How = How.XPath, Using = "//ul[@id='subList4']/li[2]/a")]
        public IWebElement WorksheetadvTab { get; set; }

        //Page Title of WorkSheet Advance Search   
        [FindsBy(How = How.Id, Using = "pageTitle")]
        public IWebElement pagetitle { get; set; }

        //iDealDateFrom of WorkSheet Advance Search   
        [FindsBy(How = How.Id, Using = "iDealDateFrom")]
        public IWebElement iDealDateFrom { get; set; }

        //iDealDateTo of WorkSheet Advance Search    
        [FindsBy(How = How.Id, Using = "iDealDateTo")]
        public IWebElement iDealDateTo { get; set; }

        //type of WorkSheet Advance Search    
        [FindsBy(How = How.Id, Using = "type")]
        public IWebElement type { get; set; }

        //bankQualified of WorkSheet Advance Search      
        [FindsBy(How = How.Id, Using = "bankQual")]
        public IWebElement bankQualified { get; set; }

        //szRangeFrom of WorkSheet Advance Search      
        [FindsBy(How = How.Id, Using = "szRangeFrom")]
        public IWebElement szRangeFrom { get; set; }

        //szRangeTo of WorkSheet Advance Search        
        [FindsBy(How = How.Id, Using = "szRangeTo")]
        public IWebElement szRangeTo { get; set; }

        //issuername of WorkSheet Advance Search      
        [FindsBy(How = How.Id, Using = "issuer")]
        public IWebElement issuername { get; set; }

        //leadManager of WorkSheet Advance Search       
        [FindsBy(How = How.Id, Using = "leadMngr")]
        public IWebElement leadManager { get; set; }

        //Co Manager of WorkSheet Advance Search      
        [FindsBy(How = How.Id, Using = "coMngr")]
        public IWebElement Comanager { get; set; }

        //taxStatus of WorkSheet Advance Search       
        [FindsBy(How = How.Id, Using = "taxStatus")]
        public IWebElement taxStatus { get; set; }

        //state of WorkSheet Advance Search      
        [FindsBy(How = How.Id, Using = "state")]
        public IWebElement state { get; set; }

        //Button runQuery of WorkSheet Advance Search      
        [FindsBy(How = How.Id, Using = "runQuery")]
        public IWebElement btnrunQuery { get; set; }

        //Button clearFilters of WorkSheet Advance Search      
        [FindsBy(How = How.Id, Using = "clearFilters")]
        public IWebElement btnclearFilters { get; set; }

        ExtentTest test = ExtentReport.ReportStart("Worksheet Advance Search", "Worksheet Advance Search Functionality Under Primary Market");

        public void AdvancedSearchwithValiddate(IWebDriver driver)
        {
            iDealDateFrom.Clear();
            iDealDateFrom.SendKeys("03/07/2017");
            iDealDateTo.Clear();
            iDealDateTo.SendKeys("03/08/2017");
            SelectElement typedropdown = new SelectElement(type);
            for (int i = 0; i < typedropdown.Options.Count; i++)
            {
                if (i > 0)
                {
                    typedropdown.DeselectByIndex(i - 1);
                }

                typedropdown.SelectByIndex(i);
                btnrunQuery.Click();
                switch (i)
                {
                    case 0:
                        try
                        {
                            // Competitive Bonds Label 
                            IWebElement CB = driver.FindElement(By.XPath("//*[@id='scrollContent']/div[1]/p/a"));
                            Assert.That(CB.Displayed);
                            string CBtext = CB.Text;
                            Assert.IsNotEmpty(CBtext);
                            string start_date0 = driver.FindElement(By.Id("advSearchForm:compBondsList:0:sDate")).Text;
                            ExtentReport.ReportLog(test, "Pass", CBtext + " Datas are populated From date" + "  " + start_date0, driver);

                        }
                        catch
                        {
                            ExtentReport.ReportLog(test, "Fail", "No data found for Competitive Bond", driver);
                        }

                        try
                        {
                            // Competitive Notes
                            IWebElement CN = driver.FindElement(By.XPath("//*[@id='scrollContent']/div[4]/p/a"));
                            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", CN);
                            Assert.That(CN.Displayed);
                            string CNtext = CN.Text;
                            Assert.IsNotEmpty(CNtext);
                            string start_date1 = driver.FindElement(By.Id("advSearchForm:compNotesList:0:sDate")).Text;
                            ExtentReport.ReportLog(test, "Pass", CNtext + " Datas are populated From date" + "  " + start_date1, driver);

                        }
                        catch
                        {
                            ExtentReport.ReportLog(test, "Fail", "No data found for Competitive Notes", driver);
                        }
                        try
                        {
                            // Negotiated Bonds
                            IWebElement NB = driver.FindElement(By.XPath("//*[@id='scrollContent']/div[7]/p/a"));
                            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", NB);
                            Assert.That(NB.Displayed);
                            string NBtext = NB.Text;
                            Assert.IsNotEmpty(NBtext);
                            string start_date2 = driver.FindElement(By.Id("advSearchForm:negBondsList:0:sDate")).Text;
                            ExtentReport.ReportLog(test, "Pass", NBtext + " Datas are populated From date" + "  " + start_date2, driver);

                        }
                        catch
                        {
                            ExtentReport.ReportLog(test, "Fail", "No data found for Negotiated Bonds", driver);
                        }

                        try
                        {
                            // Negotiated Notes 
                            IWebElement NN = driver.FindElement(By.XPath("//*[@id='scrollContent']/div[10]/p/a"));
                            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", NN);
                            Assert.That(NN.Displayed);
                            string NNtext = NN.Text;
                            Assert.IsNotEmpty(NNtext);
                            string start_date3 = driver.FindElement(By.Id("advSearchForm:negNotesList:0:sDate")).Text;
                            ExtentReport.ReportLog(test, "Pass", NNtext + " Datas are populated From date" + "  " + start_date3, driver);

                        }
                        catch
                        {
                            ExtentReport.ReportLog(test, "Fail", "No data found for Negotiated Notes", driver);
                        }
                        break;
                    case 1:
                        try
                        {
                            // Competitive Bonds Label 
                            IWebElement CB1 = driver.FindElement(By.XPath("//*[@id='scrollContent']/div[1]/p/a"));
                            Assert.That(CB1.Displayed);
                            string CBtext1 = CB1.Text;
                            Assert.IsNotEmpty(CBtext1);
                            string start_date00 = driver.FindElement(By.Id("advSearchForm:compBondsList:0:sDate")).Text;
                            ExtentReport.ReportLog(test, "Pass", CBtext1 + " Datas are populated From date" + "  " + start_date00, driver);

                        }
                        catch
                        {
                            ExtentReport.ReportLog(test, "Fail", "No data found for Competitive Bond", driver);
                        }
                        break;
                    case 2:
                        try
                        {
                            // Competitive Notes
                            IWebElement CN = driver.FindElement(By.XPath("//*[@id='scrollContent']/div[1]/p/a"));
                            Assert.That(CN.Displayed);
                            string CNtext = CN.Text;
                            Assert.IsNotEmpty(CNtext);
                            string start_date1 = driver.FindElement(By.Id("advSearchForm:compNotesList:0:sDate")).Text;
                            ExtentReport.ReportLog(test, "Pass", CNtext + " Datas are populated From date" + "  " + start_date1, driver);

                        }
                        catch
                        {
                            ExtentReport.ReportLog(test, "Fail", "No data found for Competitive Notes", driver);
                        }
                        break;
                    case 3:
                        try
                        {
                            // Negotiated Bonds
                            IWebElement NB = driver.FindElement(By.XPath("//*[@id='scrollContent']/div[1]/p/a"));
                            Assert.That(NB.Displayed);
                            string NBtext = NB.Text;
                            Assert.IsNotEmpty(NBtext);
                            string start_date2 = driver.FindElement(By.Id("advSearchForm:negBondsList:0:sDate")).Text;
                            ExtentReport.ReportLog(test, "Pass", NBtext + " Datas are populated From date" + "  " + start_date2, driver);

                        }
                        catch
                        {
                            ExtentReport.ReportLog(test, "Fail", "No data found for Negotiated Bonds", driver);
                        }

                        break;
                    case 4:
                        try
                        {
                            // Negotiated Notes 
                            IWebElement NN = driver.FindElement(By.XPath("//*[@id='scrollContent']/div[1]/p/a"));
                            Assert.That(NN.Displayed);
                            string NNtext = NN.Text;
                            Assert.IsNotEmpty(NNtext);
                            string start_date3 = driver.FindElement(By.Id("advSearchForm:negNotesList:0:sDate")).Text;
                            ExtentReport.ReportLog(test, "Pass", NNtext + " Datas are populated From date" + "  " + start_date3, driver);

                        }
                        catch
                        {
                            ExtentReport.ReportLog(test, "Fail", "No data found for Negotiated Notes", driver);
                        }

                        break;

                }
                Thread.Sleep(TimeSpan.FromSeconds(5));
                driver.FindElement(By.Id("editQuery")).Click();
            }
        }


        public void AdvancedSearchForWeekend(IWebDriver driver)
        {
            // driver.FindElement(By.Id("editQuery")).Click();
            iDealDateFrom.Clear();
            iDealDateFrom.SendKeys("05/06/2017");
            iDealDateTo.Clear();
            iDealDateTo.SendKeys("05/07/2017");
            SelectElement typedropdown = new SelectElement(type);
            typedropdown.SelectByIndex(0);
            btnrunQuery.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            if (driver.FindElement(By.Id("errorMsg")).Displayed)
            {
                ExtentReport.ReportLog(test, "Fail", "Sorry, No Matches were found containing your query as the entered date falls on weekend ", driver);
            }
        }

        public void AdvancedSearchForfuturedate(IWebDriver driver)
        {
            // driver.FindElement(By.Id("editQuery")).Click();
            iDealDateFrom.Clear();
            iDealDateFrom.SendKeys("05/06/2018");
            iDealDateTo.Clear();
            iDealDateTo.SendKeys("05/07/2018");
            SelectElement typedropdown = new SelectElement(type);
            typedropdown.SelectByIndex(0);
            btnrunQuery.Click();
            if (driver.FindElement(By.Id("errorMsg")).Displayed)
            {
                ExtentReport.ReportLog(test, "Fail", "Sorry, No Matches were found containing your query as the entered date is future ", driver);
            }
        }


        public void AdvancedSearchForInvaliddate(IWebDriver driver)
        {
            // driver.FindElement(By.Id("editQuery")).Click();
            iDealDateFrom.Clear();
            iDealDateFrom.SendKeys("06/15/2018");
            iDealDateTo.Clear();
            iDealDateTo.SendKeys("06/01/2018");
            SelectElement typedropdown = new SelectElement(type);
            typedropdown.SelectByIndex(0);
            btnrunQuery.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            ExtentReport.ReportLog(test, "Fail", "The From Date should be earlier or equal to the To Date", driver);
            ExtentReport.ReportStop(test);
        }
    }

}


