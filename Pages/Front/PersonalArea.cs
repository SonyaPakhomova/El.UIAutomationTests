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
    class PersonalArea:Page
    {
        public PersonalArea(IWebDriver driver) : base(driver)
        {
         PageFactory.InitElements(driver,this);  
        }
        [FindsBy(How = How.CssSelector, Using = "div.loan-header br")]
        private IWebElement loanId;

        public string GetLoanIdFront()
        {
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("loan-reference[customer-info=\"customerInfo\"] a b")));
            return driver.FindElement(By.CssSelector("loan-reference[customer-info=\"customerInfo\"] a b")).Text.Substring(3);
        }

    }
}
