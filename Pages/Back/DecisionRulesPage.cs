using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace El.Test.UiTests.Pages.Back
{
    class DecisionRulesPage:Page
    {
        public DecisionRulesPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement DriverLisense;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement SSN;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement Blacklisted;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement IdenticalPhoneNumbers;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement MainPhone;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement SuspiciousAge;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement SuspiciousPhoneNumber;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement ResidenceRegistrationAddress;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement Citizenship;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement Employment;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement NetIncome;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement LoanToIncome;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement NumberActiveLoans;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement DelinquencyCheck;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement BankruptcyCheck;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement DefaultsCheck;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement CreditBureauInquiries;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement CreditBureauScore;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement ApplicationDetailsCopyPasted;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement ReplacementAttachments;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement TooManyDoubtsLoanTerm;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement SuspectedCopyPaste;
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement SuspectedIrresponsibleBehavior;



    }
}
