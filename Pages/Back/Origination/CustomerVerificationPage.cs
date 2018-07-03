using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Back.Origination
{
    class CustomerVerificationPage:Page
    {
        public CustomerVerificationPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "customer.name")]
        private IWebElement serchByName;
        [FindsBy(How = How.Id, Using = "customer.phone")]
        private IWebElement serchByPhone;
        [FindsBy(How = How.Id, Using = "customer.ssn")]
        private IWebElement serchBySSN;
        [FindsBy(How = How.CssSelector, Using = "td:nth-of-type(8) > button")]
        private IWebElement buttonSelect;
        [FindsBy(How = How.CssSelector, Using = "button:nth-of-type(3)")]
        private IWebElement useSelectCustuomerButton;
        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"newCustomer()\"]")]
        private IWebElement newCustomerButton;

        public CustomerVerificationPage setSerchByName(string name)
        {
            serchByName.SendKeys(name);
            return this;
        }
        public CustomerVerificationPage setSerchByPhone(string phone)
        {
            serchByPhone.SendKeys(phone);
            return this;
        }
        public CustomerVerificationPage setSerchBySSN(string ssn)
        {
            serchBySSN.SendKeys(ssn);
            return this;
        }
        public CustomerVerificationPage selectButtonClick()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(buttonSelect));
            buttonSelect.Click();
            return this;
        }
        public void useSelectCustomerButtonClick()
        {
            useSelectCustuomerButton.Click();
        }
        public void newCustomerButtonClick()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[ng-click=\"newCustomer()\"]")));
            newCustomerButton.Click();
        }
    }
}
