using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Back
{
    class ContactsPage:Page
    {
        public ContactsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "id(\"_int\")")]
        private IWebElement Date;
        [FindsBy(How = How.XPath, Using = "//select[@name=\"method\"]")]
        private IWebElement Method;
        [FindsBy(How = How.XPath, Using = "//input[@name=\"purpose\"]")]
        private IWebElement Purpose;
        [FindsBy(How = How.XPath, Using = "//select[@name=\"result\"]")]
        private IWebElement Result;
        [FindsBy(How = How.XPath, Using = "//textarea[@name=\"comment\"]")]
        private IWebElement Comment;
        [FindsBy(How = How.CssSelector, Using = "button[ng-click= \"submit(c, newContact)\"]")]
        private IWebElement OkButton;

        public ContactsPage setDate(string date)
        {
            Date.SendKeys(date);
            return this;
        }
        public ContactsPage setMethod(string method)
        {
            new SelectElement(Method).SelectByText(method);
            return this;
        }
        public ContactsPage setResult(string result)
        {
            new SelectElement(Result).SelectByText(result);
            return this;
        }
        public ContactsPage setPurpose(string purpose)
        {
            Purpose.SendKeys(purpose);
            return this;
        }
        public ContactsPage setComments(string comment)
        {
            Comment.SendKeys(comment);
            return this;
        }

        public void clickOkButton()
        {
            OkButton.Click();
        }
    }
}
