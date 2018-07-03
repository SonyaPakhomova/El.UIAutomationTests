using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Back.Underwriting
{
    class UnderwritingPage:Page
    {
        public UnderwritingPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "input[ng-=\"Search\"]")]
        private IWebElement searchField;
        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"approve()\"]")]
        private IWebElement approveButton;
        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"$close(comment)\"]")]
        private IWebElement confirmApproveButton;
        [FindsBy(How = How.CssSelector, Using = "drop-down[key=\"search.filters.filterStatus\"] div button")]
        private IWebElement filterStatus;
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""addToBlackList()""]")]
        protected IWebElement Blacklist { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""submit()""]")]
        protected IWebElement OkButton { get; set; }
        [FindsBy(How = How.XPath, Using = @"//input[@name=""comment""]")]
        protected IWebElement Comments { get; set; }
        [FindsBy(How = How.XPath, Using = @"button[ng-click=""$close(comment)""]")]
        protected IWebElement AddToRejectLoan { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""$dismiss()""]")]
        protected IWebElement CancelAddToRejectLoan { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"div.modal-footer button[ng-click=""$dismiss()""]")]
        protected IWebElement Reject { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""rework()""]")]
        protected IWebElement SendForReprocessing { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"el-field[caption=""Name""]")]
        protected IWebElement Name { get; set; }
        [FindsBy(How = How.Id, Using = @"cd.FirstName")]
        protected IWebElement FirstName { get; set; }


       /* public UnderwritingPage SearchLoan(string loanid)
        {
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("input[placeholder=\"Search\"]")));
            searchField.SendKeys(loanid);
            return this;
        }*/

        public void approveButtonClick()
        {
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementToBeClickable(approveButton));
            approveButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(confirmApproveButton));
            confirmApproveButton.Click();
        }

        public void confirmApproveButtonClick()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(confirmApproveButton));
            confirmApproveButton.Click();
   
        }

        /*public List<IWebElement> GetLoanId()
        {
            return driver.FindElements(By.CssSelector("div#gview_applicationsGrid_grid tr[id] td:nth-of-type(1)")).ToList();
        }*/

        public UnderwritingPage searchFilterStatus(string status)
        {
            new SelectElement(this.filterStatus).SelectByText(status);
            return this;
        }

        public void ClickAddToBlackList()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Blacklist));
            Blacklist.Click();
        }

        public UnderwritingPage addCommentToBlackList(string comments)
        {
            Comments.SendKeys(comments);
            return this;
        }
        public UnderwritingPage ClickAddToRejectLoan()
        {
            wait.Until(ExpectedConditions.StalenessOf(driver.FindElement(By.CssSelector("div.modal-dialog"))));
            AddToRejectLoan.Click();
            return this;
        }
        public UnderwritingPage ClickCancelToAddRejectLoan()
        {
           // wait.Until(ExpectedConditions.StalenessOf(driver.FindElement(By.CssSelector("div.modal-dialog"))));
            CancelAddToRejectLoan.Click();
            return this;
        }

        public void clickSubmitAddLoanToBlackList()
        {
            //wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.modal-dialog")));
            wait.Until(d => d.FindElement(By.CssSelector("div.modal-dialog")));
            OkButton.Click();
        }

    }
}
