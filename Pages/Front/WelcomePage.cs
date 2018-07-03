using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using El.Test.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AppConfigSettingsReader = El.Test.UiTests.Modules.AppConfigSettingsReader;

namespace El.Test.UiTests.Pages.Front
{
    internal class WelcomePage:Page
    {
        public WelcomePage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Name, Using = "currencyValue")]
        private IWebElement loanAmount;
        [FindsBy(How = How.Name, Using = "Term")]
        private IWebElement loanTerm;
        [FindsBy(How = How.CssSelector, Using = "select[ng-model=\"loanParams.product\"]")]
        private IWebElement loanType;
        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"takeLoan()\"]")]
        private IWebElement applyNow;
        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"enterPromoDlg()\"]")]
        private IWebElement enterPromoCode;

        public static string UrlFront => AppConfigSettingsReader.Read("Url", "");
        public WelcomePage Open()
        {
            driver.Navigate().GoToUrl(UrlFront+ "Lending#/");
            return this;
        }
        public WelcomePage setLoanTerm(string term)
        {
            loanTerm.Clear();
            loanTerm.SendKeys(term);
            return this;
        }
        public WelcomePage setLoanAmount(string amount)
        {
            loanAmount.Clear();
            loanAmount.SendKeys(amount);
            return this;
        }
        public WelcomePage setLoanType(string aLoanType)
        {
            new SelectElement(loanType).SelectByText(aLoanType);
            Thread.Sleep(2000);
            return this;
        }
        public void ApplyClick()
        {
           //if(driver.FindElement(applyNow).Enabled)
         isElementClicble(applyNow);
         applyNow.Click();
            //return PageFactory.InitElements(driver, CreateAccountPage);
        }
    }
    

}
