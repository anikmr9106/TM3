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
    class Deal_Search
    {
        public Deal_Search(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //cusip6 Field
        [FindsBy(How = How.Id, Using = "cusip")]
        public IWebElement cusip6 { get; set; }

        //state Dropdown
        [FindsBy(How = How.Id, Using = "state")]
        public IWebElement state_dropdown { get; set; }

        //issuerName Field
        [FindsBy(How = How.Id, Using = "issuerName")]
        public IWebElement issuerName { get; set; }

        //bondInsr Dropdown
        [FindsBy(How = How.Id, Using = "bondInsr")]
        public IWebElement bondInsr_dropdown { get; set; }

        //proceedUse Dropdown
        [FindsBy(How = How.Id, Using = "proceedUse")]
        public IWebElement proceedUse_dropdown { get; set; }

        //securityType Dropdown
        [FindsBy(How = How.Id, Using = "securityType")]
        public IWebElement securityType_dropdown { get; set; }

        //taxStatus Dropdown
        [FindsBy(How = How.Id, Using = "taxStatus")]
        public IWebElement taxStatus_dropdown { get; set; }

        //supplementType Dropdown
        [FindsBy(How = How.Id, Using = "supplementType")]
        public IWebElement supplementType_dropdown { get; set; }

        //offeringType Dropdown
        [FindsBy(How = How.Id, Using = "offeringType")]
        public IWebElement offeringType_dropdown { get; set; }


        //leadManager Dropdown
        [FindsBy(How = How.Id, Using = "leadManager")]
        public IWebElement leadManager_dropdown { get; set; }

        //bankQualified Dropdown
        [FindsBy(How = How.Id, Using = "bankQualified")]
        public IWebElement bankQualified_dropdown { get; set; }

        //dealSizeMin Field
        [FindsBy(How = How.Id, Using = "dealSizeMin")]
        public IWebElement dealSizeMin { get; set; }

        //dealSizeMax Field
        [FindsBy(How = How.Id, Using = "dealSizeMax")]
        public IWebElement dealSizeMax { get; set; }

        //saleDateFrom Field
        [FindsBy(How = How.Id, Using = "saleDateFrom")]
        public IWebElement saleDateFrom { get; set; }

        //saleDateTo Field
        [FindsBy(How = How.Id, Using = "saleDateTo")]
        public IWebElement saleDateTo { get; set; }

        //datedDateFrom Field
        [FindsBy(How = How.Id, Using = "datedDateFrom")]
        public IWebElement datedDateFrom { get; set; }

        //datedDateTo Field
        [FindsBy(How = How.Id, Using = "datedDateTo")]
        public IWebElement datedDateTo { get; set; }

        //runQuery button
        [FindsBy(How = How.Id, Using = "runQuery")]
        public IWebElement runQuery { get; set; }

        //clearFilters button
        [FindsBy(How = How.Id, Using = "clearFilters")]
        public IWebElement clearFilters { get; set; }

        //editQuery button
        [FindsBy(How = How.Id, Using = "editQuery")]
        public IWebElement editQuery { get; set; }


        ExtentTest test = ExtentReport.ReportStart("Deal Search", "Deal Search Functionality Under Muni/Data Analysis");

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
