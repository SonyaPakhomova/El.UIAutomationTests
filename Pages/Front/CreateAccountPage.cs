using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Front
{
    class CreateAccountPage:Page
    {
        public CreateAccountPage(IWebDriver driver):base(driver)
        {
            
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "u.username")]
        public IWebElement userEmail;
        [FindsBy(How = How.Id, Using = "u.password")]
        public IWebElement userPassword;
        [FindsBy(How = How.Id, Using = "u.confirm")]
        public IWebElement userConfirmPassword;
        [FindsBy(How = How.XPath, Using = "//button")]
        public IWebElement createAccountButton;

        [FindsBy(How = How.XPath, Using = "//form[@name=\"dlgForm\"]/div[1]/strong[1]")]
        private IWebElement messageIfUserExist;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div[1]/div[3]/button[1]")]
        private IWebElement buttonIfUserExist;

        public CreateAccountPage setUserEmail(string email)
        {
            wait.Until(ExpectedConditions.UrlContains("stepRegister"));
            wait.Until(ExpectedConditions.ElementExists(By.Id("u.username")));
            userEmail.SendKeys(email);
            return this;
        }
        public CreateAccountPage setPassword(string password)
        {
            userPassword.SendKeys(password);
            return this;
        }
        public CreateAccountPage setConfermPassword(string confirmPassword)
        {
            userConfirmPassword.SendKeys(confirmPassword);
            return this;
        }
        public void createAccountClick()
        {
            createAccountButton.Click();
        }

        public bool checkIfUserExist()
        {
            if(isElementPresent(By.XPath("//form[@name=\"dlgForm\"]/div[1]/strong[1]")))
            {
                buttonIfUserExist.Click();
                return true;
            }
            return false;
        }
    }
}
