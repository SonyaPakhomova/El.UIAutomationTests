using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Back.System.Users.Investors
{
    class InvestorPage:Page
    {
        public InvestorPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"createInvestor()\"]")]
        private IWebElement btnCreateInvestor;
        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"deleteSelected()\"]")]
        private IWebElement btnDeleteInvestor;
        [FindsBy(How = How.CssSelector, Using = "div#investor-list input[placeholder=\"Search\"]")]
        private IWebElement SearchInvestor;
        [FindsBy(How = How.CssSelector, Using = "div#jqgh_investors-grid_grid_cb")]
        private IWebElement SelectAllInvestor;
        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"$close(comment)\"]")]
        private IWebElement btnConfirmDeleteInvestor;

        //---------------------
        [FindsBy(How = How.XPath, Using = "id(\"data.UserName\")")]
        private IWebElement InvestorEmail;
        [FindsBy(How = How.XPath, Using = "id(\"data.Password\")")]
        private IWebElement InvestorPassword;
        [FindsBy(How = How.XPath, Using = "id(\"u.PasswordConfirmation\")")]
        private IWebElement InvestorConfirmPassword;
        [FindsBy(How = How.CssSelector, Using = "input[name=\"phoneInput\"]")]
        private IWebElement InvestorPhone;
        [FindsBy(How = How.XPath, Using = "id(\"data.FullName\")")]
        private IWebElement InvestorFullName;
        [FindsBy(How = How.CssSelector, Using = "input[name=\"currencyValue\"]")]
        private IWebElement InvestorBalance;
        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"ok()\"]")]
        private IWebElement OkButton;

        public void CreateInvestorClick()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(btnCreateInvestor));
            btnCreateInvestor.Click();
        }
        public void DeleteInvestoreClick()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(btnDeleteInvestor));
            btnDeleteInvestor.Click();
            btnConfirmDeleteInvestor.Click();
        }
        public void SetSearchInvestor(string investor)
        {
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div#investor-list input[placeholder=\"Search\"]")));
            SearchInvestor.SendKeys(investor);
        }
        public void SelectAllInvestors()
        {
            SelectAllInvestor.Click();
        }

        //------------------------------------------
        public InvestorPage SetInvestorEmail(string investorEmail)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("id(\"data.UserName\")")));
            InvestorEmail.SendKeys(investorEmail);
            return this;
        }
        public InvestorPage SetInvestorPassword(string investorPassword)
        {
            InvestorPassword.SendKeys(investorPassword);
            return this;
        }
        public InvestorPage SetInvestorConfirmPassword(string investorConfirmPassword)
        {
            InvestorConfirmPassword.SendKeys(investorConfirmPassword);
            return this;
        }
        public InvestorPage SetInvestorFullName(string investorFullName)
        {
            InvestorFullName.SendKeys(investorFullName);
            return this;
        }
        public InvestorPage SetInvestorPhone(string investorPhone)
        {
            InvestorPhone.SendKeys(investorPhone);
            return this;
        }
        public InvestorPage SetInvestorBalance(string investorBalance)
        {
            InvestorBalance.SendKeys(investorBalance);
            return this;
        }
        public void ClickOk()
        {
            OkButton.Click();
        }
        //-------------------------------------
        public bool IsInvestorExist()
        {
            Thread.Sleep(2000);
            //Console.WriteLine(driver.FindElements(By.CssSelector("table#investors-grid_grid tr[id] td:nth-of-type(3)"))[0].Text);
            //if (driver.FindElements(By.CssSelector("table#investors-grid_grid tr[id] td:nth-of-type(3)"))[0].Text == investor)
            if (driver.FindElements(By.CssSelector("table#investors-grid_grid tr[id]")).ToList().Count > 0)
                return true;
            else
                return false;
        }
    }
}
