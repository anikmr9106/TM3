using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
    class Munistatements
    {
        // Search Tab

        public Munistatements(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //issuerName Field
        [FindsBy(How = How.Id, Using = "issuerName")]
        public IWebElement issuerName { get; set; }

        //state Dropdown
        [FindsBy(How = How.Id, Using = "state")]
        public IWebElement state_dropdown { get; set; }

        //cusip Field
        [FindsBy(How = How.Id, Using = "cusip")]
        public IWebElement cusip { get; set; }

        //datedDateFrom Field
        [FindsBy(How = How.Id, Using = "datedDateFrom")]
        public IWebElement datedDateFrom { get; set; }

        //datedDateTo Field
        [FindsBy(How = How.Id, Using = "datedDateTo")]
        public IWebElement datedDateTo { get; set; }

        //fromSize Field
        [FindsBy(How = How.Id, Using = "fromSize")]
        public IWebElement fromSize { get; set; }

        //toSize Field
        [FindsBy(How = How.Id, Using = "toSize")]
        public IWebElement toSize { get; set; }

        //revenue Field
        [FindsBy(How = How.Id, Using = "revenue")]
        public IWebElement revenue_dropdown { get; set; }

        //proceeds Field
        [FindsBy(How = How.Id, Using = "proceeds")]
        public IWebElement proceeds_dropdown { get; set; }

        //leadmangr Field
        [FindsBy(How = How.Id, Using = "leadmangr")]
        public IWebElement leadmangr_dropdown { get; set; }

        //corporation Field
        [FindsBy(How = How.Id, Using = "corporation")]
        public IWebElement corporation { get; set; }

        //project Field
        [FindsBy(How = How.Id, Using = "project")]
        public IWebElement project { get; set; }

        //Run Button
        [FindsBy(How = How.Id, Using = "muniStmtsForm:runQuery")]
        public IWebElement run_btn { get; set; }

        //Clear Button
        [FindsBy(How = How.Id, Using = "clearFilters")]
        public IWebElement clear_btn { get; set; }

        ExtentTest test = ExtentReport.ReportStart("Munistatement", "Munistatement Functionality Under Muni/Data Analysis");

        public void validsearch_munistatement(IWebDriver driver)
        {
            issuerName.SendKeys("RANCHO CUCAMONGA CALIF PUB FIN");
            // Thread.Sleep(TimeSpan.FromSeconds(10));
            run_btn.Click();
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
                wait.Until(ExpectedConditions.ElementExists(By.Id("muniStmtsForm:srchResView:results:0:_idJsp9:0:docLink")));
                IWebElement result = driver.FindElement(By.XPath("//*[@id='docMsg']"));
                ExtentReport.ReportLog(test, "Pass", result.Text + " " + "for the Issuer" + " " +
                    driver.FindElement(By.Id("muniStmtsForm:srchResView:results:0:issuer")).Text, driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "Data didnot Found", driver);
            }
            Thread.Sleep(TimeSpan.FromSeconds(3));
            driver.FindElement(By.XPath("//*[@id='tabNav']/ul/li[1]/a")).Click();
        }

        public void Invalidsearch_munistatement(IWebDriver driver)
        {
            issuerName.Clear();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            run_btn.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            ExtentReport.ReportLog(test, "Fail", "Search parameters are not provided.", driver);
        }

        public void Today_Document(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//*[@id='tabNav']/ul/li[2]/a/span")).Click();
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(3));
                wait.Until(ExpectedConditions.ElementExists(By.Id("muniStmtsForm:srchResView:results:0:_idJsp9:0:docLink")));
                // Result Element 
                IWebElement result = driver.FindElement(By.XPath("//*[@id='docMsg']"));
                ExtentReport.ReportLog(test, "Pass", result.Text + " For Today's Document ", driver);
            }

            catch
            {
                ExtentReport.ReportLog(test, "Fail", "Data didnot Retrived Waited more then 3 Min", driver);
            }


        }

        public void Yesterday_Document(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//*[@id='tabNav']/ul/li[3]/a")).Click();
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(3));
                wait.Until(ExpectedConditions.ElementExists(By.Id("muniStmtsForm:srchResView:results:0:_idJsp9:0:docLink")));
                // Result Element 
                IWebElement result = driver.FindElement(By.XPath("//*[@id='docMsg']"));
                ExtentReport.ReportLog(test, "Pass", result.Text + " For Today's Document ", driver);
            }

            catch
            {
                ExtentReport.ReportLog(test, "Fail", "Data didnot Retrived Waited more then 3 Min", driver);
            }
        }

        public void Last_10_Download(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//*[@id='tabNav']/ul/li[4]/a/span")).Click();
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
                wait.Until(ExpectedConditions.ElementExists(By.Id("muniStmtsForm:srchResView:results:0:_idJsp9:0:docLink")));
                // Document Link
                IWebElement document_link = driver.FindElement(By.Id("muniStmtsForm:srchResView:results:1:_idJsp9:0:docLink"));
                document_link.Click();
                WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
                wait1.Until(ExpectedConditions.ElementExists(By.Id("mailBtn")));
                Thread.Sleep(TimeSpan.FromSeconds(5));
                driver.FindElement(By.XPath("//*[@id='PDFmessage']/a")).Click();
                Thread.Sleep(TimeSpan.FromMinutes(2));

                driver.SwitchTo().Frame(driver.FindElement(By.Id("pdfDocFrame")));

                Actions action = new Actions(driver);

                action.MoveToElement(driver.FindElement(By.Id("plugin"))).Build().Perform();

            }

            catch
            {
                ExtentReport.ReportLog(test, "Fail", "Data didnot Retrived", driver);
            }
        }


        public void Company_Usage_Report(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//*[@id='tabNav']/ul/li[5]/a/span")).Click();
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
                wait.Until(ExpectedConditions.ElementExists(By.Id("companyName")));
                IWebElement company = driver.FindElement(By.Id("companyName"));
                IWebElement totalcount = driver.FindElement(By.Id("cmpTotDocCnt"));
                ExtentReport.ReportLog(test, "Pass", company.Text + " and " + totalcount.Text, driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", "Data didnot Retrived Waited more then 3 Min", driver);
            }
            ExtentReport.ReportStop(test);
        }


    }


}
