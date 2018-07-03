using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Back.Origination
{
    class OriginationPage:Page
    {
        public OriginationPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver,this);
        }

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/section[1]/elmenu[1]/div[2]/div[1]/ng-view[1]/split-view[1]/div[1]/split-toolbar[1]/nav[1]/form[1]/div[2]/a[1]")]
        private IWebElement newApplicationButton;
        [FindsBy(How = How.CssSelector, Using = "div.nextstep-buttons button[ng-click=\"sendForApproval()\"]")]
        private IWebElement sendForApprovalButton;
        [FindsBy(How = How.CssSelector, Using = "div#gview_applicationsGrid_grid")]
        IList <IWebElement> loanRows;
        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"$close(comment)\"]")]
        private IWebElement confirmSendForApprove;
        [FindsBy(How = How.CssSelector, Using = "div#originationTabs li[heading=\"Customer Details\"] a")]
        private IWebElement CustomerDetailsTab;
        [FindsBy(How = How.CssSelector, Using = "div#originationTabs li[heading=\"Interaction History\"] a")]
        private IWebElement InteractionHistoryTab;
        [FindsBy(How = How.CssSelector, Using = "div#originationTabs li[heading=\"Documents\"] a")]
        private IWebElement DocumentsTab;
        [FindsBy(How = How.CssSelector, Using = "div#originationTabs li[heading=\"Change History\"] a")]
        private IWebElement ChangeHistoryTab;
        [FindsBy(How = How.CssSelector, Using = "input[ng-model=\"search.search\"]")]
        private IWebElement searchField;
        [FindsBy(How = How.CssSelector, Using = "table#applicationsGrid_grid tr td[aria-describedby=\"applicationsGrid_grid_Status\"] div")]
        private IWebElement statusLoan;
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""edit()""]")]
        protected IWebElement Edit { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""newContact()""]")]
        protected IWebElement Contact { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""changeOffer()""]")]
        protected IWebElement ChangeTerms { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"contacts > table > tbody > tr")]
        protected IWebElement ContactGrid { get; set; }
        //internal HashSet<string> GetCustomerIds()
        public void clickConfirmSendForApprove()
        {
            // wait.Until(ExpectedConditions.ElementExists(By.CssSelector("button[ng-click=\"$close(comment)\"]")));
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[ng-click=\"$close(comment)\"]")));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("div.modal-dialog")));
            /*wait.Until(ExpectedConditions.ElementToBeClickable(
                By.CssSelector("html > body > div > div > div > div:nth - of - type(3) > button")));*/
            confirmSendForApprove.Click();
            //driver.FindElement(By.CssSelector("html > body > div > div > div > div:nth-of-type(3) > button")).Click();
        }

        internal List<IWebElement> GetLoansIds()
        {
            return driver.FindElements(By.CssSelector("div#gview_applicationsGrid_grid tr[id]")).ToList();
        }

        public List<IWebElement> GetLoanId()
        {
            return driver.FindElements(By.CssSelector("div#gview_applicationsGrid_grid tr[id] td:nth-of-type(1)")).ToList();
        }

        public void newApplicationButtonClick()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html[1]/body[1]/section[1]/elmenu[1]/div[2]/div[1]/ng-view[1]/split-view[1]/div[1]/split-toolbar[1]/nav[1]/form[1]/div[2]/a[1]")));
            newApplicationButton.Click();
            wait.Until(d => d.FindElement(By.Id("_int")));
        }
        public OriginationPage serchLoan(string loanId)
        {
            searchField.SendKeys(loanId);
            return this;
        }
        public void sendForApprovalButtonClick()
        {
            //wait.Until(d => d.FindElement(By.CssSelector("div.nextstep-buttons button[ng-click=\"sendForApproval()\"]")));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("div.nextstep-buttons button[ng-click=\"sendForApproval()\"]")));
            sendForApprovalButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(confirmSendForApprove));
            confirmSendForApprove.Click();
            Console.WriteLine("Заявка отправлена на обработку");
            //wait.Until(ExpectedConditions.StalenessOf(driver.FindElement(By.CssSelector(""))));

        }

        public OriginationPage clickCustomerDetailsTab()
        {
            CustomerDetailsTab.Click();
            return this;
        }
        public OriginationPage clickInteractionHistoryTab()
        {
            InteractionHistoryTab.Click();
            return this;
        }
        public OriginationPage clickDocumentsTab()
        {
            DocumentsTab.Click();
            return this;
        }
        public OriginationPage clickChangeHistoryTab()
        {
            ChangeHistoryTab.Click();
            return this;
        }
        public void searchLoan(string loanId)
        {
            //Thread.Sleep(2000);
            //wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("input[placeholder=\"Search\"]")));
            searchField.Clear();
            searchField.SendKeys(loanId);
            //Thread.Sleep(2000);

        }

        public string GetStatusLoan()
        {
            return driver
                .FindElements(By.CssSelector(
                    "table#applicationsGrid_grid tr"))[1].FindElement(By.CssSelector("td[aria-describedby=\"applicationsGrid_grid_Status\"] div"))
                .GetAttribute("title");
        }

        public List<IWebElement> GetContactsList()
        {
            return driver.FindElements(By.CssSelector("dsfsdf")).ToList();
        }

        public void AddContact()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Contact));
            Contact.Click();
        }
    }
}
