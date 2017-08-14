using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM3.Page_Object
{
    class VRDN_PortfolioManagement
    {
        public VRDN_PortfolioManagement(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Create New portfolio button   
        [FindsBy(How = How.Id, Using = "mmdiformpm:createp")]
        public IWebElement create_new_portfolio { get; set; }

        //Show drop down   
        [FindsBy(How = How.Id, Using = "mmdiformpm:allprofile")]
        public IWebElement show_dropdown { get; set; }

        //Go button   
        [FindsBy(How = How.Id, Using = "mmdiformpm:allprofile")]
        public IWebElement go_btn { get; set; }

        //manual_cusip_entry  
        [FindsBy(How = How.Id, Using = "manualCUSIP")]
        public IWebElement manual_cusip_entry { get; set; }

        //Add button   
        [FindsBy(How = How.Id, Using = "createportfolio:_idJsp7")]
        public IWebElement add_btn { get; set; }

        //save button   
        [FindsBy(How = How.Id, Using = "save")]
        public IWebElement save_btn { get; set; }

        //cancel button   
        [FindsBy(How = How.Id, Using = "createportfolio:cancel")]
        public IWebElement cancel_btn { get; set; }

        //Name Field 
        [FindsBy(How = How.Id, Using = "portfolioName")]
        public IWebElement portfolio_name { get; set; }

        //Edit Field 
        [FindsBy(How = How.Id, Using = "mmdiformpm:reports:0:_idJsp33")]
        public IWebElement portfolio_edit { get; set; }

        //Delete Field 
        [FindsBy(How = How.Id, Using = "mmdiformpm:reports:0:_idJsp36")]
        public IWebElement portfolio_del { get; set; }

        //Export Field 
        [FindsBy(How = How.Id, Using = "mmdiformpm:reports:0:_idJsp39")]
        public IWebElement portfolio_Export { get; set; }
    }
}
