using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace El.Test.UiTests.Pages.Front
{
    class InvestorRegistrationPage:Page
    {
        public InvestorRegistrationPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "data.UserName")]
        private IWebElement emailInvestor;
        [FindsBy(How = How.Id, Using = "data.Password")]
        private IWebElement passwordInvestor;
        [FindsBy(How = How.Id, Using = "u.PasswordConfirmation")]
        private IWebElement confirmPasswordInvestor;
        [FindsBy(How = How.Id, Using = "data.FullName")]
        private IWebElement fullNameInvestor;
        [FindsBy(How = How.Id, Using = "_int")]
        private IWebElement mobilePhoneInvestor;

        public InvestorRegistrationPage setEmailInvestor(string email)
        {
            emailInvestor.SendKeys(email);
            return this;
        }
        public InvestorRegistrationPage setPasswordInvestor(string password)
        {
            passwordInvestor.SendKeys(password);
            return this;
        }

        public InvestorRegistrationPage setConfirmPasswordInvestor(string confirmPassword)
        {
            confirmPasswordInvestor.SendKeys(confirmPassword);
            return this;
        }

        public InvestorRegistrationPage setFullNameInvestor(string fullName)
        {
            fullNameInvestor.SendKeys(fullName);
            return this;
        }

        public InvestorRegistrationPage setMobilePhoneInvestor(string mobilePhone)
        {
            mobilePhoneInvestor.SendKeys(mobilePhone);
            return this;
        }

    }
}
