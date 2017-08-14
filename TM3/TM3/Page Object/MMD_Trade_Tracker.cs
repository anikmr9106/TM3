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
    class MMD_Trade_Tracker
    {
        public MMD_Trade_Tracker(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        // searchDateFrom Field  
        [FindsBy(How = How.Id, Using = "searchDateFrom")]
        public IWebElement searchDateFrom { get; set; }

        // searchDateTo Field  
        [FindsBy(How = How.Id, Using = "searchDateTo")]
        public IWebElement searchDateTo { get; set; }

        // cusip Field  
        [FindsBy(How = How.Id, Using = "cusip")]
        public IWebElement cusip { get; set; }

        // issuerName Field  
        [FindsBy(How = How.Id, Using = "issuerName")]
        public IWebElement issuerName { get; set; }

        // state Field  
        [FindsBy(How = How.Id, Using = "state")]
        public IWebElement state_dropdown { get; set; }

        // maturityDateFrom Field  
        [FindsBy(How = How.Id, Using = "maturityDateFrom")]
        public IWebElement maturityDateFrom { get; set; }

        // maturityDateTo Field  
        [FindsBy(How = How.Id, Using = "maturityDateTo")]
        public IWebElement maturityDateTo { get; set; }

        // callableDateFrom Field  
        [FindsBy(How = How.Id, Using = "callableDateFrom")]
        public IWebElement callableDateFrom { get; set; }

        // callableDateTo Field  
        [FindsBy(How = How.Id, Using = "callableDateTo")]
        public IWebElement callableDateTo { get; set; }

        // couponRateFrom Field  
        [FindsBy(How = How.Id, Using = "couponRateFrom")]
        public IWebElement couponRateFrom { get; set; }

        // couponRateTo Field  
        [FindsBy(How = How.Id, Using = "couponRateTo")]
        public IWebElement couponRateTo { get; set; }

        // tradeType Field  
        [FindsBy(How = How.Id, Using = "tradeType")]
        public IWebElement tradeType_dropdown { get; set; }

        // tradeSizeInputFrom Field  
        [FindsBy(How = How.Id, Using = "tradeSizeInputFrom")]
        public IWebElement tradeSizeInputFrom { get; set; }

        // tradeSizeInputTo Field  
        [FindsBy(How = How.Id, Using = "tradeSizeInputTo")]
        public IWebElement tradeSizeInputTo { get; set; }

        // savedSearches Field  
        [FindsBy(How = How.Id, Using = "savedSearches")]
        public IWebElement savedSearches { get; set; }

        // timeFrom Field  
        [FindsBy(How = How.Id, Using = "timeFrom")]
        public IWebElement timeFrom_dropdown { get; set; }

        // timeTo Field  
        [FindsBy(How = How.Id, Using = "timeTo")]
        public IWebElement timeTo_dropdown { get; set; }

        // moodyRatingFrom Field  
        [FindsBy(How = How.Id, Using = "moodyRatingFrom")]
        public IWebElement moodyRatingFrom_dropdown { get; set; }

        // moodyRatingTo Field  
        [FindsBy(How = How.Id, Using = "moodyRatingTo")]
        public IWebElement moodyRatingTo_dropdown { get; set; }

        // spRatingFrom Field  
        [FindsBy(How = How.Id, Using = "spRatingFrom")]
        public IWebElement spRatingFrom_dropdown { get; set; }

        // spRatingTo Field  
        [FindsBy(How = How.Id, Using = "spRatingTo")]
        public IWebElement spRatingTo_dropdown { get; set; }

        // priceFrom Field  
        [FindsBy(How = How.Id, Using = "priceFrom")]
        public IWebElement priceFrom { get; set; }

        // priceTo Field  
        [FindsBy(How = How.Id, Using = "priceTo")]
        public IWebElement priceTo { get; set; }

        // yieldFrom Field  
        [FindsBy(How = How.Id, Using = "yieldFrom")]
        public IWebElement yieldFrom { get; set; }

        // yieldTo Field  
        [FindsBy(How = How.Id, Using = "yieldTo")]
        public IWebElement yieldTo { get; set; }

        // bondInsur Field  
        [FindsBy(How = How.Id, Using = "bondInsur")]
        public IWebElement bondInsur_dropdown { get; set; }

        // spreadFrom Field  
        [FindsBy(How = How.Id, Using = "spreadFrom")]
        public IWebElement spreadFrom { get; set; }

        // spreadTo Field  
        [FindsBy(How = How.Id, Using = "spreadTo")]
        public IWebElement spreadTo { get; set; }

        // sector Field  
        [FindsBy(How = How.Id, Using = "sector")]
        public IWebElement sector { get; set; }

        // clearFilters Field  
        [FindsBy(How = How.Id, Using = "clearFilters")]
        public IWebElement clearFilter_btn { get; set; }

        // runQuery Field  
        [FindsBy(How = How.Id, Using = "runQuery")]
        public IWebElement runQuery_btn { get; set; }

        // saveQuery_btn Field  
        [FindsBy(How = How.Id, Using = "searchForm:saveQuery")]
        public IWebElement saveQuery_btn { get; set; }

        // Next_btn Field  
        [FindsBy(How = How.Id, Using = "searchResultsForm:botNextId")]
        public IWebElement Next_btn { get; set; }

        ExtentTest test = ExtentReport.ReportStart("MMD Trade Tracker", "MMD Trade Tracker Functionality Under Secondary Market");

        public void validsearchcriteriabydate(IWebDriver driver)
        {
            searchDateFrom.Clear();
            searchDateTo.Clear();
            searchDateFrom.SendKeys("05/08/2017");
            searchDateTo.SendKeys("05/09/2017");
            SelectElement statedropdown = new SelectElement(state_dropdown);
            statedropdown.SelectByIndex(0);
            runQuery_btn.Click();
            Thread.Sleep(TimeSpan.FromSeconds(10));
            try
            {
                Assert.IsTrue(Next_btn.Displayed);
                Next_btn.Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Assert.IsTrue(Next_btn.Displayed);
                Next_btn.Click();
                ExtentReport.ReportLog(test, "Pass", " Datas are populated From date: 05/08/2017 to 05/09/2017 ", driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", " Datas are populated From date: 05/08/2017 to 05/09/2017 ", driver);
            }

            driver.FindElement(By.Id("srSearch")).Click();
        }

        public void Futuresearchcriteriabydate(IWebDriver driver)
        {
            searchDateFrom.Clear();
            searchDateTo.Clear();
            searchDateFrom.SendKeys("05/08/2018");
            searchDateTo.SendKeys("05/09/2018");
            SelectElement statedropdown = new SelectElement(state_dropdown);
            statedropdown.SelectByIndex(0);
            runQuery_btn.Click();
            Thread.Sleep(TimeSpan.FromSeconds(10));
            try
            {
                Assert.IsTrue(Next_btn.Displayed);
                Next_btn.Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Assert.IsTrue(Next_btn.Displayed);
                Next_btn.Click();
                ExtentReport.ReportLog(test, "Pass", " Datas are populated From date: 05/08/2017 to 05/09/2017 ", driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", " Datas are not populated From date:05/08/2018 to 05/09/2018  ", driver);
            }

            driver.FindElement(By.Id("srSearch")).Click();

        }

        public void Invalidsearchcriteriabydate(IWebDriver driver)
        {
            searchDateFrom.Clear();
            searchDateTo.Clear();
            searchDateFrom.SendKeys("05/09/2018");
            searchDateTo.SendKeys("05/08/2018");
            SelectElement statedropdown = new SelectElement(state_dropdown);
            statedropdown.SelectByIndex(0);
            runQuery_btn.Click();
            Thread.Sleep(TimeSpan.FromSeconds(10));
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            ExtentReport.ReportLog(test, "Fail", "The From Date should be earlier or equal to the To Date", driver);

        }

        public void Weekendsearchcriteriabydate(IWebDriver driver)
        {
            searchDateFrom.Clear();
            searchDateTo.Clear();
            searchDateFrom.SendKeys("05/13/2017");
            searchDateTo.SendKeys("05/14/2017");
            SelectElement statedropdown = new SelectElement(state_dropdown);
            statedropdown.SelectByIndex(0);
            runQuery_btn.Click();
            Thread.Sleep(TimeSpan.FromSeconds(10));
            try
            {
                Assert.IsTrue(Next_btn.Displayed);
                Next_btn.Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Assert.IsTrue(Next_btn.Displayed);
                Next_btn.Click();
                ExtentReport.ReportLog(test, "Pass", " Datas are populated From date: 05/13/2017 to 05/14/2017 ", driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", " Datas are not populated From date:05/13/2017 to 05/14/2017 as it falls on weekend  ", driver);
            }

            driver.FindElement(By.Id("srSearch")).Click();
            ExtentReport.ReportStop(test);
        }
    }
}
