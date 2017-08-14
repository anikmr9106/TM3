using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM3.Page_Object;
using TM3.TestData;
using TM3.Workflow;

namespace TM3
{
    [TestFixture]
    public class TestClass
    {
        public IWebDriver driver = null;

        public static ExtentReports extend = new ExtentReports(MyPath.reportpath);

        [Test]
        public void A_Installisation()
        {

            //Killing Driver 
            DriverKill.KillDriver();

            // Lunching Brower
            driver = new ChromeDriver();

            //Navigating to URL
            driver.Url = "https://www.tm3.com/homepage/homepage.jsf?ur=y";

            driver.Manage().Window.Maximize();
        }


        [Test]
        public void B_LoginTestCase()
        {
            //Creating Log Report 
            ExtentTest test = ExtentReport.ReportStart("Login Page", "Login Page Functionality");

            //Clicking on Login Link
            driver.FindElement(By.Id("tm3login")).Click();

            // Populating Data From Excel to Table And Collections
            ////////////  Excellib.popuateInCollection(MyPath.loginDataFile);
            ////////////  DataTable table = Excellib.ExceltoDataTable(MyPath.loginDataFile);
            DataTable table = new DataTable();
            table.Columns.Add("UserName");
            table.Columns.Add("Password");

            table.Rows.Add("", "");
            table.Rows.Add("T1966M8", "ARNIL");
            table.Rows.Add("T1966M853", "kjnns");
            table.Rows.Add("", "MARNIL");
            table.Rows.Add("T1966M853", "MARNIL");

            //Getting the Row Count of Table
            int count = Excellib.getrowcount(table);

            Excellib.popuateInCollection1(table);

            //Creating Instances of Login POM
            Login login = new Login(driver);


            //Iterating through data in table
            for (int i = 1; i <= count; i++)
            {
                login.logining(Excellib.ReadData(i, "UserName"), Excellib.ReadData(i, "Password"));
                try
                {
                    // Finding UserName
                    IWebElement dashboard = driver.FindElement(By.CssSelector("#tm3login>span"));
                    Assert.AreNotEqual("LOGIN", "Anil Kumar");
                    ExtentReport.ReportLog(test, "Pass", "Login in with the username " + dashboard.Text, driver);
                    Console.WriteLine("We Are In Home Page");

                }

                catch (NoSuchElementException e)
                {
                    ExtentReport.ReportLog(test, "Fail", " Invalid Login crediational " + "UserName : " + " " + Excellib.ReadData(i, "UserName") + "  " +
                    "Password : " + " " + Excellib.ReadData(i, "Password"), driver);
                }
            }
            ExtentReport.ReportStop(test);

        }


        [Test]
        public void C_Home()
        {
            Home home = new Home(driver);
            home.validating_MMDScales(driver);
            home.validating_ThomsonMunicipalNews(driver);
            home.validating_MIG1(driver);
            home.validating_Top5CompetitiveIssuses(driver);
            home.validating_Top5NegotiatedIssuses(driver);
            home.validating_5MostTrade(driver);
        }


        [Test]
        public void C_Primary_SelectingCB_NB()
        {
            driver.FindElement(By.XPath("//*[@id='topNav4']")).Click();
            driver.FindElement(By.XPath("//*[@id='subList4']/li[1]")).Click();
            Primary_Worksheets pr = new Primary_Worksheets(driver);
            pr.SelectCompetitive_NegotiatedBonds_Notes(driver);
            pr.SelectCompetitive_Negotiated_History(driver);
        }

        [Test]
        public void D_Primary_AdvanceSearch()
        {
            driver.FindElement(By.XPath("//*[@id='topNav4']")).Click();
            driver.FindElement(By.XPath("//*[@id='subList4']/li[2]")).Click();
            Advanced_Worksheet aw = new Advanced_Worksheet(driver);
            aw.AdvancedSearchwithValiddate(driver);
            aw.AdvancedSearchForWeekend(driver);
            aw.AdvancedSearchForfuturedate(driver);
            aw.AdvancedSearchForInvaliddate(driver);
        }

        [Test]
        public void E_CompetitiveSaleResult()
        {
            driver.FindElement(By.XPath("//*[@id='topNav4']")).Click();
            driver.FindElement(By.XPath("//*[@id='subList4']/li[3]")).Click();
            Competitive_Sale_Result cs = new Competitive_Sale_Result();
            cs.checkingdata(driver);

        }

        [Test]
        public void F_NegotiatedSaleResult()
        {
            driver.FindElement(By.XPath("//*[@id='topNav4']")).Click();
            driver.FindElement(By.XPath("//*[@id='subList4']/li[4]")).Click();
            Negotiated_Sale_Result Ns = new Negotiated_Sale_Result();
            Ns.checkingdata(driver);
        }

        [Test]
        public void G_MMD_Trade_Tracker()
        {
            driver.FindElement(By.XPath("//*[@id='topNav5']")).Click();
            driver.FindElement(By.XPath("//*[@id='subList5']/li[1]")).Click();
            MMD_Trade_Tracker mmd = new MMD_Trade_Tracker(driver);
            mmd.validsearchcriteriabydate(driver);
            mmd.Futuresearchcriteriabydate(driver);
            mmd.Invalidsearchcriteriabydate(driver);
            mmd.Weekendsearchcriteriabydate(driver);
        }


        [Test]
        public void H_MMD_Cusip9Search()
        {
            driver.FindElement(By.XPath("//*[@id='topNav6']/a[1]")).Click();
            driver.FindElement(By.XPath("//*[@id='subList6']/li[1]/a")).Click();
            CUSIP9_Search cs = new CUSIP9_Search(driver);
            cs.validsearch(driver);
            cs.Invalidsearch(driver);
        }

        [Test]
        public void I_MMD_DealSearch()
        {
            driver.FindElement(By.XPath("//*[@id='topNav6']/a[1]")).Click();
            driver.FindElement(By.XPath("//*[@id='subList6']/li[2]/a")).Click();
            Deal_Search ds = new Deal_Search(driver);
            ds.validsearch(driver);
            ds.Invalidsearch(driver);
        }

        [Test]
        public void J_Bond_Calculator()
        {
            driver.FindElement(By.XPath("//*[@id='topNav6']/a[1]")).Click();
            driver.FindElement(By.XPath("//*[@id='subList6']/li[3]/a")).Click();
            Bond_Calculator_Analysis bc = new Bond_Calculator_Analysis(driver);
            bc.SearchwithValid_data(driver);
            bc.SearchwithInvalid_data(driver);
            bc.TwoBond_Searchwithvalid_data(driver);
        }

        [Test]
        public void K_Munistatement()
        {
            driver.FindElement(By.XPath("//*[@id='topNav6']/a[1]")).Click();
            driver.FindElement(By.XPath("//*[@id='subList6']/li[4]/a")).Click();
            Munistatements munistatement = new Munistatements(driver);
            munistatement.validsearch_munistatement(driver);
            munistatement.Invalidsearch_munistatement(driver);
            munistatement.Today_Document(driver);
            munistatement.Yesterday_Document(driver);
            //munistatement.Last_10_Download(driver);
            munistatement.Company_Usage_Report(driver);
        }

        [Test]
        public void VRD()
        {
            VRDN_Create_Portfolio.create_portfolio(driver);
        }

    }
}

