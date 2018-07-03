using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages
{
    internal class Page
    {
        //protected IWebDriver driver;
        protected IWebDriver driver;

        protected WebDriverWait wait;
        public Page(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }
        public bool isElementPresent(By element)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(element));
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool isElementClicble(IWebElement element)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Something filled wrong");
                return false;
            }
          }
    }
}