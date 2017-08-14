using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM3.TestData;

namespace TM3.Page_Object
{
    class Home
    {
        public Home(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        //MMD Scales Title   
        [FindsBy(How = How.XPath, Using = "//*[@id='mmdScalesId']/div/div[2]/div/div[1]/h2")]
        public IWebElement mmdScalesTitle { get; set; }

        //MMD Scales Table    
        [FindsBy(How = How.Id, Using = "mmdScalesWidgetId")]
        public IWebElement mmdScaletable { get; set; }

        //MMD Scales Time   
        [FindsBy(How = How.Id, Using = "mmdScalesTimeId")]
        public IWebElement mmdScalesTime { get; set; }

        //MMD MORE Button   
        [FindsBy(How = How.XPath, Using = "//div[@id='scaleMore']/a")]
        public IWebElement mmdScalesMORE_btn { get; set; }

        //Thomson Municipal News Title   
        [FindsBy(How = How.XPath, Using = "//*[@id='newsId']/div/div[2]/div/div[1]/h2")]
        public IWebElement newsTitle { get; set; }

        //Thomson Municipal News Time   
        [FindsBy(How = How.Id, Using = "newsTimeId")]
        public IWebElement newsTime { get; set; }

        //Thomson Municipal News Table  
        [FindsBy(How = How.Id, Using = "thomsonMunicipalNewsWidgetId:tbody_element")]
        public IWebElement newsTable { get; set; }

        //Thomson Municipal News MORE Button   
        [FindsBy(How = How.XPath, Using = "//div[@id='newsMore']/a")]
        public IWebElement newsMORE_btn { get; set; }

        //MIG1 Title   
        [FindsBy(How = How.XPath, Using = "//*[@id='mig1Id']/div/div[2]/div/div[1]/h2")]
        public IWebElement mig1Title { get; set; }

        //MIG1 Time   
        [FindsBy(How = How.Id, Using = "mig1TimeId")]
        public IWebElement mig1Time { get; set; }

        //MIG1 Table  
        [FindsBy(How = How.Id, Using = "mig1WidgetId")]
        public IWebElement mig1Table { get; set; }

        //MIG1 MORE Button   
        [FindsBy(How = How.XPath, Using = "//div[@id='mig1More']/a")]
        public IWebElement mig1MORE_btn { get; set; }

        //Top 5 Competitive Issues Title   
        [FindsBy(How = How.XPath, Using = "//*[@id='compIssuesId']/div/div[2]/div/div[1]/h2")]
        public IWebElement compIssuesTitle { get; set; }

        //Top 5 Competitive Issues Time   
        [FindsBy(How = How.Id, Using = "competitiveTimeId")]
        public IWebElement compIssuesTime { get; set; }

        //Top 5 Competitive Issues Table  
        [FindsBy(How = How.Id, Using = "top5CompetitiveIssuesWidgetId:tbody_element")]
        public IWebElement compIssusesTable { get; set; }

        //Top 5 Competitive Issues MORE Button   
        [FindsBy(How = How.XPath, Using = "//*[@id='t5cmpMore']/a")]
        public IWebElement compIssuseMORE_btn { get; set; }

        //Top 5 Negotiated Issues Title   
        [FindsBy(How = How.XPath, Using = "//*[@id='negIssuesId']/div/div[2]/div/div[1]/h2")]
        public IWebElement negIssuesTitle { get; set; }

        //Top 5 Negotiated Issues Time   
        [FindsBy(How = How.Id, Using = "negotiatedTimeId")]
        public IWebElement negtIssuesTime { get; set; }

        //Top 5 Negotiated Issues Table  
        [FindsBy(How = How.Id, Using = "top5NegotiatedIssuesWidgetId")]
        public IWebElement negIssusesTable { get; set; }

        //Top 5 Negotiated Issues MORE Button   
        [FindsBy(How = How.XPath, Using = "//*[@id='t5negMore']/a")]
        public IWebElement negIssuseMORE_btn { get; set; }

        //5 Most Active Trades at Volume Title   
        [FindsBy(How = How.XPath, Using = "//*[@id='5actrdId']/div/div[2]/div/div[1]/h2")]
        public IWebElement actrdTitle { get; set; }

        //5 Most Active Trades at Volume Time   
        [FindsBy(How = How.Id, Using = "activeTradesTimeId")]
        public IWebElement actrdTime { get; set; }

        //5 Most Active Trades at Volume Table  
        [FindsBy(How = How.Id, Using = "top5ActiveTradesWidgetId:tbody_element")]
        public IWebElement actrdTable { get; set; }

        //5 Most Active Trades at Volume MORE Button   
        [FindsBy(How = How.XPath, Using = "//*[@id='mstactMore']/a")]
        public IWebElement actrdMSRBSearch_btn { get; set; }

        ExtentTest test = ExtentReport.ReportStart("Home", "Home Page Functionality");

        public void validating_MMDScales(IWebDriver driver)
        {
            try
            {
                Assert.True(mmdScalesTitle.Displayed);
                IWebElement table_ele = driver.FindElement(By.Id("mmdScalesWidgetId"));



                IList<IWebElement> table_header = table_ele.FindElements(By.XPath("//*[@id='mmdScalesWidgetId']/thead/tr/th"));
                string table_header_text = "";
                foreach (IWebElement e in table_header)
                {
                    table_header_text = table_header_text + e.Text + "        ";
                }



                IList<IWebElement> table_row = driver.FindElements(By.XPath("//*[@id='mmdScalesWidgetId:tbody_element']/tr"));

                string xpath_part1 = "//*[@id='mmdScalesWidgetId:tbody_element']/tr[";
                string xpath_part2 = "]/td";

                string table_row_data = "";
                for (int i = 0; i <= table_row.Count; i++)
                {
                    string full_xpath = xpath_part1 + i + xpath_part2;
                    IList<IWebElement> table_data = driver.FindElements(By.XPath(full_xpath));

                    foreach (IWebElement e in table_data)
                    {
                        table_row_data = table_row_data + e.Text + "         ";
                    }

                }

                ExtentReport.ReportLog(test, "Pass", mmdScalesTitle.Text + "       " + mmdScalesTime.Text + "      " + table_header_text + "         "
                    + table_row_data, driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", " No Data Populated ", driver);
            }
        }


        public void validating_ThomsonMunicipalNews(IWebDriver driver)
        {
            try
            {
                Assert.True(newsTime.Displayed);

                IList<IWebElement> table_row = driver.FindElements(By.XPath("//*[@id='thomsonMunicipalNewsWidgetId:tbody_element']/tr"));

                string xpath_part1 = "//*[@id='thomsonMunicipalNewsWidgetId:tbody_element']/tr[";
                string xpath_part2 = "]";

                string table_row_data = "";
                for (int i = 0; i <= table_row.Count; i++)
                {

                    string full_xpath = xpath_part1 + i + xpath_part2;
                    IList<IWebElement> table_data = driver.FindElements(By.XPath(full_xpath));
                    foreach (IWebElement e in table_data)
                    {
                        table_row_data = table_row_data + e.Text + "      ";
                    }

                }

                ExtentReport.ReportLog(test, "Pass", newsTitle.Text + "   " + newsTime.Text + "   " + table_row_data, driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", " No Data Populated ", driver);
            }

        }
        public void validating_MIG1(IWebDriver driver)
        {
            try
            {
                Assert.True(mig1Title.Displayed);
                // Identifying Table
                IWebElement table_ele = driver.FindElement(By.Id("mig1WidgetId"));



                IList<IWebElement> table_header = table_ele.FindElements(By.XPath("//*[@id='mig1WidgetId']/thead/tr/th"));
                string table_header_text = "";
                foreach (IWebElement e in table_header)
                {
                    table_header_text = table_header_text + e.Text + "        ";
                }



                IList<IWebElement> table_row = driver.FindElements(By.XPath("//*[@id='mig1WidgetId:tbody_element']/tr"));

                string xpath_part1 = "//*[@id='mig1WidgetId:tbody_element']/tr[";
                string xpath_part2 = "]/td";

                string table_row_data = "";
                for (int i = 0; i <= table_row.Count; i++)
                {
                    string full_xpath = xpath_part1 + i + xpath_part2;
                    IList<IWebElement> table_data = driver.FindElements(By.XPath(full_xpath));

                    foreach (IWebElement e in table_data)
                    {
                        table_row_data = table_row_data + e.Text + "         ";
                    }

                }

                ExtentReport.ReportLog(test, "Pass", mig1Title.Text + "       " + mig1Time.Text + "      " + table_header_text + "         "
                    + table_row_data, driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", " No Data Populated ", driver);
            }


        }

        public void validating_Top5CompetitiveIssuses(IWebDriver driver)
        {
            try
            {
                Assert.True(compIssuesTitle.Displayed);
                // Identifying Table
                IWebElement table_ele = driver.FindElement(By.Id("top5CompetitiveIssuesWidgetId"));


                // Table Header
                IList<IWebElement> table_header = table_ele.FindElements(By.XPath("//*[@id='top5CompetitiveIssuesWidgetId']/thead/tr/th"));
                string table_header_text = "";
                foreach (IWebElement e in table_header)
                {
                    table_header_text = table_header_text + e.Text + "        ";
                }


                // Table Row
                IList<IWebElement> table_row = driver.FindElements(By.XPath("//*[@id='top5CompetitiveIssuesWidgetId:tbody_element']/tr"));

                string xpath_part1 = "//*[@id='top5CompetitiveIssuesWidgetId:tbody_element']/tr[";
                string xpath_part2 = "]/td";

                string table_row_data = "";
                for (int i = 0; i <= table_row.Count; i++)
                {
                    string full_xpath = xpath_part1 + i + xpath_part2;
                    //Table Data
                    IList<IWebElement> table_data = driver.FindElements(By.XPath(full_xpath));

                    foreach (IWebElement e in table_data)
                    {
                        table_row_data = table_row_data + e.Text + "         ";
                    }

                }

                ExtentReport.ReportLog(test, "Pass", compIssuesTitle.Text + "       " + compIssuesTime.Text + "      " + table_header_text + "         "
                    + table_row_data, driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", " No Data Populated ", driver);
            }
            ExtentReport.ReportStop(test);
        }

        public void validating_Top5NegotiatedIssuses(IWebDriver driver)
        {
            try
            {
                Assert.True(negIssuesTitle.Displayed);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", negIssusesTable);
                // Identifying Table
                IWebElement table_ele = driver.FindElement(By.Id("top5NegotiatedIssuesWidgetId"));


                // Table Header
                IList<IWebElement> table_header = table_ele.FindElements(By.XPath("//*[@id='top5NegotiatedIssuesWidgetId']/thead/tr/th"));
                string table_header_text = "";
                foreach (IWebElement e in table_header)
                {
                    table_header_text = table_header_text + e.Text + "        ";
                }


                // Table Row
                IList<IWebElement> table_row = driver.FindElements(By.XPath("//*[@id='top5NegotiatedIssuesWidgetId:tbody_element']/tr"));

                string xpath_part1 = "//*[@id='top5NegotiatedIssuesWidgetId:tbody_element']/tr[";
                string xpath_part2 = "]/td";

                string table_row_data = "";
                for (int i = 1; i <= table_row.Count; i++)
                {
                    string full_xpath = xpath_part1 + i + xpath_part2;
                    //Table Data
                    IList<IWebElement> table_data = driver.FindElements(By.XPath(full_xpath));

                    foreach (IWebElement e in table_data)
                    {
                        table_row_data = table_row_data + e.Text + "         ";
                    }

                }

                ExtentReport.ReportLog(test, "Pass", negIssuesTitle.Text + "       " + negtIssuesTime.Text + "      " + table_header_text + "         "
                    + table_row_data, driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", " No Data Populated ", driver);
            }

        }

        public void validating_5MostTrade(IWebDriver driver)
        {
            try
            {
                Assert.True(actrdTitle.Displayed);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", actrdTable);
                // Identifying Table
                IWebElement table_ele = driver.FindElement(By.Id("top5ActiveTradesWidgetId"));


                // Table Header
                IList<IWebElement> table_header = table_ele.FindElements(By.XPath("//*[@id='top5ActiveTradesWidgetId']/thead/tr/th"));
                string table_header_text = "";
                foreach (IWebElement e in table_header)
                {
                    table_header_text = table_header_text + e.Text + "        ";
                }


                // Table Row
                IList<IWebElement> table_row = driver.FindElements(By.XPath("//*[@id='top5ActiveTradesWidgetId:tbody_element']/tr"));

                string xpath_part1 = "//*[@id='top5ActiveTradesWidgetId:tbody_element']/tr[";
                string xpath_part2 = "]/td";

                string table_row_data = "";
                for (int i = 1; i <= table_row.Count; i++)
                {
                    string full_xpath = xpath_part1 + i + xpath_part2;
                    //Table Data
                    IList<IWebElement> table_data = driver.FindElements(By.XPath(full_xpath));

                    foreach (IWebElement e in table_data)
                    {
                        table_row_data = table_row_data + e.Text + "         ";
                    }

                }

                ExtentReport.ReportLog(test, "Pass", actrdTitle.Text + "       " + actrdTime.Text + "      " + table_header_text + "         "
                    + table_row_data, driver);
            }
            catch
            {
                ExtentReport.ReportLog(test, "Fail", " No Data Populated ", driver);
            }
            ExtentReport.ReportStop(test);
        }

    }
}
