using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM3.TestData;

namespace TM3.Page_Object
{
    class CUSIP9_Search
    {
        public CUSIP9_Search(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //cusip6 Field
        [FindsBy(How = How.Id, Using = "cusip6")]
        public IWebElement cusip6 { get; set; }

        //state dropdown
        [FindsBy(How = How.Id, Using = "state")]
        public IWebElement state_dropdown { get; set; }

        //issuerName Field
        [FindsBy(How = How.Id, Using = "issuerName")]
        public IWebElement issuerName { get; set; }

        //bondInsr dropdown
        [FindsBy(How = How.Id, Using = "bondInsr")]
        public IWebElement bondInsr_dropdown { get; set; }

        //proceedUse dropdown
        [FindsBy(How = How.Id, Using = "proceedUse")]
        public IWebElement proceedUse_dropdown { get; set; }

        //securityType dropdown
        [FindsBy(How = How.Id, Using = "securityType")]
        public IWebElement securityType_dropdown { get; set; }

        //taxStatus dropdown
        [FindsBy(How = How.Id, Using = "taxStatus")]
        public IWebElement taxStatus_dropdown { get; set; }

        //supplementType dropdown
        [FindsBy(How = How.Id, Using = "supplementType")]
        public IWebElement supplementType_dropdown { get; set; }

        //redemptionType dropdown
        [FindsBy(How = How.Id, Using = "redemptionType")]
        public IWebElement redemptionType_dropdown { get; set; }

        //bankQualified dropdown
        [FindsBy(How = How.Id, Using = "bankQualified")]
        public IWebElement bankQualified_dropdown { get; set; }

        //excludeInactive Checkbox
        [FindsBy(How = How.Id, Using = "excludeInactive")]
        public IWebElement excludeInactive { get; set; }

        //maturityDateFrom Data Picker 
        [FindsBy(How = How.Id, Using = "maturityDateFrom")]
        public IWebElement maturityDateFrom { get; set; }

        //maturityDateTo Data Picker 
        [FindsBy(How = How.Id, Using = "maturityDateTo")]
        public IWebElement maturityDateTo { get; set; }

        //couponRate1 Field 
        [FindsBy(How = How.Id, Using = "couponRate1")]
        public IWebElement couponRate1 { get; set; }

        //couponRate2 Field 
        [FindsBy(How = How.Id, Using = "couponRate2")]
        public IWebElement couponRate2 { get; set; }

        //callableDateFrom Data Picker 
        [FindsBy(How = How.Id, Using = "callableDateFrom")]
        public IWebElement callableDateFrom { get; set; }

        //callableDateTo Data Picker 
        [FindsBy(How = How.Id, Using = "callableDateTo")]
        public IWebElement callableDateTo { get; set; }

        //redemptionDateFrom Data Picker 
        [FindsBy(How = How.Id, Using = "redemptionDateFrom")]
        public IWebElement redemptionDateFrom { get; set; }

        //redemptionDateTo Data Picker 
        [FindsBy(How = How.Id, Using = "redemptionDateTo")]
        public IWebElement redemptionDateTo { get; set; }

        //originalPrice1 Field 
        [FindsBy(How = How.Id, Using = "originalPrice1")]
        public IWebElement originalPrice1 { get; set; }

        //originalPrice2 Field
        [FindsBy(How = How.Id, Using = "originalPrice2")]
        public IWebElement originalPrice2 { get; set; }

        //originalYield1 Field
        [FindsBy(How = How.Id, Using = "originalYield1")]
        public IWebElement originalYield1 { get; set; }

        //originalYield2 Field
        [FindsBy(How = How.Id, Using = "originalYield2")]
        public IWebElement originalYield2 { get; set; }

        //datedDateFrom Date Picker
        [FindsBy(How = How.Id, Using = "datedDateFrom")]
        public IWebElement datedDateFrom { get; set; }

        //datedDateTo Date Picker
        [FindsBy(How = How.Id, Using = "datedDateTo")]
        public IWebElement datedDateTo { get; set; }

        //runQuery Date Picker
        [FindsBy(How = How.Id, Using = "runQuery")]
        public IWebElement runQuery { get; set; }

        //clearFilters Date Picker
        [FindsBy(How = How.Id, Using = "clearFilters")]
        public IWebElement clearFilters { get; set; }

        //editQuery Field
        [FindsBy(How = How.Id, Using = "editQuery")]
        public IWebElement editQuery { get; set; }

        ExtentTest test = ExtentReport.ReportStart("CUSIP9 Search", "CUSIP9 Search Functionality Under Muni/Data Analysis");

        public void validsearch(IWebDriver driver)
        {
            clearFilters.Click();
            driver.SwitchTo().Alert().Accept();
            cusip6.SendKeys("6222");
            runQuery.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.Id("editQuery")));
            if (editQuery.Displayed)
            {
                try
                {
                    IWebElement query_result = driver.FindElement(By.XPath("//*[@id='_idJsp0']/div[2]/h2/span"));
                    ExtentReport.ReportLog(test, "Pass", query_result.Text, driver);
                    editQuery.Click();
                }
                catch
                {
                    ExtentReport.ReportLog(test, "Fail", "Data didnot Found", driver);
                }

            }
        }

        public void Invalidsearch(IWebDriver driver)
        {
            clearFilters.Click();
            driver.SwitchTo().Alert().Accept();
            cusip6.SendKeys("6222F");
            runQuery.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.Id("editQuery")));
            if (editQuery.Displayed)
            {
                try
                {
                    IWebElement query_result = driver.FindElement(By.XPath("//*[@id='_idJsp0']/div[2]/h2/span"));
                    ExtentReport.ReportLog(test, "Info", query_result.Text, driver);
                    editQuery.Click();
                }
                catch
                {
                    ExtentReport.ReportLog(test, "Fail", "Data didnot Found", driver);
                }
                ExtentReport.ReportStop(test);
            }

        }

    }
}
