using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Back.Origination
{
    class SetLoanParam:Page

    {
        public SetLoanParam(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver,this);
        }

        [FindsBy(How = How.CssSelector, Using = "div.loan-selector select[ng-model=\"app.product\"]")]
        private IWebElement creditProduct;
        [FindsBy(How = How.Id, Using = "_int")]
        private IWebElement loanAmount;
        [FindsBy(How = How.XPath, Using = "//input[@name=\"Term\"]")]
        private IWebElement term;
        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"proceed()\"]")]
        private IWebElement buttonProced;
        [FindsBy(How = How.CssSelector, Using = @"select[ng-model=""app.Saving""]")]
        private IWebElement SavingRate;

        public SetLoanParam setCreditProduct(string creditProduct)
        {
            new SelectElement(this.creditProduct).SelectByText(creditProduct);
            return this;
        }
        public SetLoanParam setLoanAmount(string loanAmount)
        {
            this.loanAmount.Click();
            this.loanAmount.Clear();
            //this.loanAmount.SendKeys(Keys.Control+Keys.Home);
            this.loanAmount.SendKeys(loanAmount);
            return this;
        }
        public SetLoanParam setTerm(string term)
        {
            this.term.Clear();
            this.term.SendKeys(term);
            return this;
        }
        public void buttonProcedClick()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[ng-click=\"proceed()\"]")));
         buttonProced.Click();
        }
        public SetLoanParam setSavingRate(string savingRate)
        {
            new SelectElement(SavingRate).SelectByText(savingRate);
            return this;
        }


    }
}
