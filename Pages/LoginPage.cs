using System;
using El.Test.UiTests.Modules;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace El.Test.UiTests.Pages
{
    internal class LoginPage:Page
    {
        //private ChromeDriver driver;
        public static string Url => AppConfigSettingsReader.Read("Url", "");
        public LoginPage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        public LoginPage open()
        {
            driver.Navigate().GoToUrl(Url+ "Account/Login");
            return this;
        }
        
        //[FindsBy(How = How.LinkText, Using = "Login")]
        //private IWebElement login;
        [FindsBy(How = How.Id, Using = "UserName")]
        private IWebElement username;
        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement password;
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement submit;

        public LoginPage setLogin(String alogin)
        {
            username.SendKeys(alogin);
            return this;
        }
        public LoginPage setPassword(String apassword)
        {
            password.SendKeys(apassword);
            return this;
        }
        public void clickSubmit()
        {
            submit.Click();
        }
    }
}
