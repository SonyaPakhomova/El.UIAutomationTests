using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Back.System
{
    internal class SystemPage : Page
    {
        public SystemPage(IWebDriver driver):base(driver)
            {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using =".btn.btn-primary.ng-scope")]
        private IWebElement btnAddUser;
        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"remove()\"]")]
        private IWebElement btnDeleteUser;
        //[FindsBy(css="input[placeholder=\"Search\"]")
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search']")]
        private IWebElement fildSearchUser;
        [FindsBy(How = How.CssSelector, Using = "#usersGrid_grid")]
        private IWebElement listOfUser;
        [FindsBy(How = How.Id, Using = "cb_usersGrid_grid")]
        private IWebElement selectUser;
        [FindsBy(How = How.CssSelector, Using = "html > body > div > div > div > div:nth-of-type(3) > button")]
        private IWebElement btnSuccessDeleteCustomer;
        /*[FindsBy(How = How.CssSelector, Using = "#usersGrid_grid tr td[aria-describedby= \"usersGrid_grid_Username\"]")]
        public List<IWebElement> searchOfUser;*/
        [FindsBy(How = How.CssSelector, Using = "div.action-btn > a")]
        private IWebElement btnEditUser;
        [FindsBy(How = How.CssSelector,Using = "a[href=\"#/system/creditproduct\"]")]
        private IWebElement creditProductTab;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"#/system/blacklist\"]")]
        private IWebElement BlackListTab;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"#/system/decisionRules\"]")]
        private IWebElement DecisionRulesTab;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"#/system/users\"]")]
        private IWebElement UsersTab;
        [FindsBy(How = How.CssSelector, Using = "table#usersGrid_grid tr")]
        public IList<IWebElement> customerRows;

        public List<IWebElement> GetUsersIds()
        {
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div#gview_usersGrid_grid tr")));
            return driver.FindElements(By.CssSelector("div#gview_usersGrid_grid tr")).ToList();
        }
        public void clickCreditProductTab()
        {
            creditProductTab.Click();
        }
        public void clickBlackListTab()
        {
            BlackListTab.Click();
        }
        public void clickDecisionRulesTab()
        {
            DecisionRulesTab.Click();
        }
        public void clickUsersTab()
        {
            UsersTab.Click();
        }
        public void addUserButtonClick()
        {
            btnAddUser.Click();
        }
        public void deteteUSerButtonClick()
        {
            btnDeleteUser.Click();
        }

        public void successDeleteUser()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("html > body > div > div > div > div:nth-of-type(3) > button")));
            btnSuccessDeleteCustomer.Click();
        }

        public SystemPage searchUserFill(string username)
        {
            fildSearchUser.Clear();
            fildSearchUser.SendKeys(username);
            Thread.Sleep(1000);
            return this;
        }

        public SystemPage selectUserCheck()
        {
            selectUser.Click();
            return this;
        }

    }
}
