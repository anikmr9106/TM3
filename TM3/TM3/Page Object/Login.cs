using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM3.Page_Object
{
    class Login
    {

        public Login(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        // UserName Field  
        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement userName { get; set; }


        //Password Field
        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement Password { get; set; }

        //Login Button
        [FindsBy(How = How.Id, Using = "loginButton")]
        public IWebElement loginButton { get; set; }


        //Cancel Button
        [FindsBy(How = How.Id, Using = "cancelButton")]
        public IWebElement cancelButton { get; set; }


        //Forget Link  
        [FindsBy(How = How.XPath, Using = @"//table/tbody/tr[2]/td[2]/a")]
        public IWebElement forgetLink { get; set; }

        //Remember CheckBox
        [FindsBy(How = How.Id, Using = "remember")]
        public IWebElement remember { get; set; }

        //clientservice@tm3.com Link 
        [FindsBy(How = How.PartialLinkText, Using = "clientservice@tm3.com")]
        public IWebElement clientService { get; set; }

        //TM3 Link 
        [FindsBy(How = How.PartialLinkText, Using = "TM3")]
        public IWebElement tm3link { get; set; }

        //Register Link
        [FindsBy(How = How.CssSelector, Using = "a[title='Click To Register']")]
        public IWebElement registerLink { get; set; }


        public void logining(string username, string password)
        {
            userName.Clear();
            this.userName.SendKeys(username);
            this.Password.SendKeys(password);
            loginButton.Click();

        }
    }
}
