using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Back.Collection
{
    class CollectionPage:Page
    {
        public CollectionPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""newContact()""]")]
        protected IWebElement ContactButton { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""newPayment()""]")]
        protected IWebElement PaymentButton { get; set; }
        [FindsBy(How = How.CssSelector, Using = "input#_int")]
        private IWebElement AmountField;
        [FindsBy(How = How.XPath, Using = "//input[@name=\"refnum\"]")]
        private IWebElement ReferenceField;
        [FindsBy(How = How.XPath, Using = "//select[@name=\"paymenttype\"]")]
        private IWebElement TypeList;
        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"submit(payment)\"]")]
        private IWebElement ApprovePayment;
        [FindsBy(How = How.CssSelector, Using = "div[complete-handler=\"timeShifted\"] button")]
        private IWebElement TimeShiftButton;

        public void ClickContactButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(ContactButton));
            ContactButton.Click();
        }
        public void ClickPaymentButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(PaymentButton));
            PaymentButton.Click();
        }
        public void Repayment(string amount)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(PaymentButton));
            PaymentButton.Click();
            AmountField.SendKeys(amount);
            ReferenceField.SendKeys("123");
            //new SelectElement(TypeList).SelectByText("Cash");
            new SelectElement(TypeList).SelectByIndex(1);
            ApprovePayment.Click();
            Thread.Sleep(2000);
        }
        public void TimeShift(int countMonth)
        {
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[complete-handler=\"timeShifted\"] button")));
            //for (int i = 0; i < countMonth; i++)
            //{
            TimeShiftButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[ng-click=\"setPastDue(" + countMonth + ")\"]")));
            driver.FindElement(By.CssSelector("a[ng-click=\"setPastDue(" + countMonth + ")\"]")).Click();
            //Console.WriteLine(driver.FindElements(By.CssSelector("loan-schedule-new div.table- responsive tbody tr"))[2].GetAttribute("class"));
            while (driver.FindElements(By.CssSelector("loan-schedule-new div.table-responsive tbody tr"))[2].GetAttribute("class") != "ng-scope danger")
                //Thread.Sleep(1000);
                //driver.FindElement(By.CssSelector("div.table-responsive tbody tr[class=\"ng-scope danger\"]"));
                //TimeShift1Month.Click();
                Thread.Sleep(2000);
            //}
        }
    }
}
