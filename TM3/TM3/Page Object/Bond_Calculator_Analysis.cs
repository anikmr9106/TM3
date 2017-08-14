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
    class Bond_Calculator_Analysis
    {
        public Bond_Calculator_Analysis(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Single Issuse Bond Analysis

        //AnalysisType Dropdown
        [FindsBy(How = How.Id, Using = "analysisType")]
        public IWebElement analysisType_dropdown { get; set; }

        //Cusip9 Field
        [FindsBy(How = How.Id, Using = "cusip9")]
        public IWebElement cusip9 { get; set; }

        //parValue Field
        [FindsBy(How = How.Id, Using = "parValue")]
        public IWebElement parValue { get; set; }

        //CalculateFrom_dropdown
        [FindsBy(How = How.Id, Using = "calculateFrom")]
        public IWebElement calculateFrom_dropdown { get; set; }

        //CalculateFromAmt Field
        [FindsBy(How = How.Id, Using = "calculateFromAmt")]
        public IWebElement calculateFromAmt { get; set; }

        //settlementDate Field
        [FindsBy(How = How.Id, Using = "settlementDate")]
        public IWebElement settlementDate { get; set; }

        //Concession Field
        [FindsBy(How = How.Id, Using = "concession")]
        public IWebElement concession { get; set; }

        //IncomeTax Field
        [FindsBy(How = How.Id, Using = "incomeTax")]
        public IWebElement incomeTax { get; set; }

        //capitalGainsTax Field
        [FindsBy(How = How.Id, Using = "capitalGainsTax")]
        public IWebElement capitalGainsTax { get; set; }

        //viewData Button
        [FindsBy(How = How.Id, Using = "viewData")]
        public IWebElement viewData_btn { get; set; }

        //clearFilters Button
        [FindsBy(How = How.Id, Using = "clearFilters")]
        public IWebElement clearFilters_btn { get; set; }


        //Two Issue Bond Analysis

        //CusipBuy Field
        [FindsBy(How = How.Id, Using = "cusipBuy")]
        public IWebElement cusipBuy { get; set; }

        //CusipSell Field
        [FindsBy(How = How.Id, Using = "cusipSell")]
        public IWebElement cusipSell { get; set; }

        //ParValueBuy Field
        [FindsBy(How = How.Id, Using = "parValueBuy")]
        public IWebElement parValueBuy { get; set; }

        //ParValueSell Field
        [FindsBy(How = How.Id, Using = "parValueSell")]
        public IWebElement parValueSell { get; set; }

        //PriceBuy Field
        [FindsBy(How = How.Id, Using = "priceBuy")]
        public IWebElement priceBuy { get; set; }

        //PriceSell Field
        [FindsBy(How = How.Id, Using = "priceSell")]
        public IWebElement priceSell { get; set; }

        //YieldBuy Field
        [FindsBy(How = How.Id, Using = "yieldBuy")]
        public IWebElement yieldBuy { get; set; }

        //YieldSell Field
        [FindsBy(How = How.Id, Using = "yieldSell")]
        public IWebElement yieldSell { get; set; }

        //ConcessionBuy Field
        [FindsBy(How = How.Id, Using = "concessionBuy")]
        public IWebElement concessionBuy { get; set; }

        //ConcessionSell Field
        [FindsBy(How = How.Id, Using = "concessionSell")]
        public IWebElement concessionSell { get; set; }

        ExtentTest test = ExtentReport.ReportStart("Bond Calculator Analysis", "Bond Calculator Analysis Functionality Under Muni/Data Analysis");

        public void SearchwithValid_data(IWebDriver driver)
        {
            SelectElement analysis_dropdown = new SelectElement(analysisType_dropdown);
            analysis_dropdown.SelectByValue("singleBondPage");
            cusip9.SendKeys("54466LFG7");
            viewData_btn.Click();
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementExists(By.Id("closePopupError")));
                IWebElement closepopup = driver.FindElement(By.Id("closePopupError"));
                closepopup.Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
                driver.FindElement(By.Id("bondSingleForm:_idJsp10")).Click();
                WebDriverWait waitforpopup = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                waitforpopup.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='overlayContent']/table/tbody/tr/td[2]")));
                IWebElement issuer = driver.FindElement(By.XPath("//*[@id='overlayContent']/table/tbody/tr/td[2]"));
                Thread.Sleep(TimeSpan.FromSeconds(5));
                ExtentReport.ReportLog(test, "Pass", "Data is retrived for the CUSIP 54466LFG7 and the issuer " + issuer.Text, driver);
                driver.FindElement(By.Id("closeOverlay")).Click();

            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "Data is not retrived for the CUSIP 54466LFG7", driver);
            }

            driver.FindElement(By.XPath("//*[@id='subList6']/li[3]/a")).Click();
        }

        public void SearchwithInvalid_data(IWebDriver driver)
        {
            SelectElement analysis_dropdown = new SelectElement(analysisType_dropdown);
            analysis_dropdown.SelectByValue("singleBondPage");
            cusip9.SendKeys("54466L");
            viewData_btn.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementExists(By.Id("closePopupError")));
                IWebElement closepopup = driver.FindElement(By.Id("closePopupError"));
                closepopup.Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
                driver.FindElement(By.Id("bondSingleForm:_idJsp10")).Click();
                WebDriverWait waitforpopup = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                waitforpopup.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='overlayContent']/table/tbody/tr/td[2]")));
                IWebElement issuer = driver.FindElement(By.XPath("//*[@id='overlayContent']/table/tbody/tr/td[2]"));
                Thread.Sleep(TimeSpan.FromSeconds(5));
                ExtentReport.ReportLog(test, "Pass", "Data is retrived for the CUSIP 54466LFG7 and the issuer " + issuer.Text, driver);
                driver.FindElement(By.Id("closeOverlay")).Click();

            }
            catch
            {
                driver.SwitchTo().Alert().Accept();
                ExtentReport.ReportLog(test, "Fail", "Invalid CUSIP Entered", driver);
            }

            driver.FindElement(By.XPath("//*[@id='subList6']/li[3]/a")).Click();

        }

        public void TwoBond_Searchwithvalid_data(IWebDriver driver)
        {
            SelectElement analysis_dropdown = new SelectElement(analysisType_dropdown);
            analysis_dropdown.SelectByValue("doubleBondPage");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(ExpectedConditions.ElementExists(By.Id("cusipBuy")));
            cusipBuy.SendKeys("54466LFG7");
            cusipSell.SendKeys("54466LFG7");
            viewData_btn.Click();
            try
            {
                WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                wait1.Until(ExpectedConditions.ElementExists(By.Id("closePopupError")));
                driver.FindElement(By.Id("closePopupError")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='staticToolbar']/h1")).Displayed);
                driver.FindElement(By.Id("bondDoubleForm:_idJsp9")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
                IWebElement issuer1 = driver.FindElement(By.XPath("//*[@id='overlayContent']/table/tbody/tr/td[2]"));
                string issuer1_text = issuer1.Text;
                IWebElement cusip1 = driver.FindElement(By.XPath("//*[@id='overlayContent']/table/tbody/tr/td[1]"));
                string cusip1_text = cusip1.Text;
                driver.FindElement(By.Id("closeOverlay")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
                driver.FindElement(By.Id("bondDoubleForm:_idJsp13")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
                IWebElement issuer2 = driver.FindElement(By.XPath("//*[@id='overlayContent']/table/tbody/tr/td[2]"));
                string issuer2_text = issuer2.Text;
                IWebElement cusip2 = driver.FindElement(By.XPath("//*[@id='overlayContent']/table/tbody/tr/td[1]"));
                string cusip2_text = cusip2.Text;
                driver.FindElement(By.Id("closeOverlay")).Click();
                ExtentReport.ReportLog(test, "Pass", "Data is retrived for the CUSIPs " + cusip1_text + " (Sell)"
                    + " " + cusip2_text + " (Buy)" + " and the issuer " + issuer1_text + " & " + issuer2_text, driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "Invalid CUSIP Entered", driver);

            }
            ExtentReport.ReportStop(test);
        }
    }
}
