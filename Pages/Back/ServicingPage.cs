using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace El.Test.UiTests.Pages.Back
{
    class ServicingPage:Page
    {
        public ServicingPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver,this);
        }
        [FindsBy(How = How.CssSelector, Using = "input[placeholder=\"Search\"]")]
        private IWebElement searchField;
        [FindsBy(How = How.CssSelector, Using = "div.loan-buttons button span.caret")]
        private IWebElement disburseButton;
        [FindsBy(How = How.CssSelector, Using = "div.loan-buttons > div > ul li a[ng-click=\"disburse()\"]")]
        private IWebElement disburseManualyButton;
    }
}
