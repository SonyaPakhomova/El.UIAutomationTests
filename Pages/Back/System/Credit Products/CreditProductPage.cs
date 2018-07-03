using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Back.System.Credit_Products
{
    class CreditProductPage:Page
    {
        public CreditProductPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""addNewEntry()""]")]
        private IWebElement addCreditProductButton;
        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"deleteItems()\"]")]
        private IWebElement deleteCreditProductButton;
        [FindsBy(How = How.CssSelector, Using = "div.form-group input[placeholder=\"Search\"]")]
        private IWebElement searchField;
        [FindsBy(How = How.CssSelector, Using = "html > body > div > div > div > div:nth-of-type(3) > button")]
        private IWebElement approveDeleteCP;
        [FindsBy(How = How.CssSelector, Using = "table > tbody > tr > td > input[ng-model=\"cp.selected\"]")]
        private IWebElement checkCreditProduct;
        [FindsBy(How = How.CssSelector, Using = "div.modal-footer button[ng-click=\"$dismiss()\"]")]
        private IWebElement btnCloseIfCPExist;
        [FindsBy(How = How.CssSelector, Using = "div.modal-footer button[ng-click=\"$dismiss()\"]")]
        private IWebElement btnCancel;
        public void createCreaditProductClick()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(addCreditProductButton));
            addCreditProductButton.Click();
        }
        public void deleteCreaditProductClick()
        {
            deleteCreditProductButton.Click();
        }
        public CreditProductPage setSearchField(string creditProduct)
        {
            searchField.Clear();
            searchField.SendKeys(creditProduct);
            return this;
        }

        public void approveDeleteCpClick()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("html > body > div > div > div > div:nth-of-type(3) > button")));
            approveDeleteCP.Click();
        }
        public CreditProductPage checkCreditProductClick()
        {
            checkCreditProduct.Click();
            return this;
        }
      public List<IWebElement> GetCreditProductsIds()
      {
          //wait.Until(ExpectedConditions.UrlContains("/system/creditproduct"));
          Thread.Sleep(3000);
          return driver.FindElements(By.CssSelector("elmenu > div:nth-of-type(2) tr")).ToList();
        }
        public bool IsCreditProductExistByMessage()
        {
            if (isElementPresent(By.XPath("//form[@name=\"dlgForm\"]/div[1]/strong[1]")))
            {
                btnCloseIfCPExist.Click();
                btnCancel.Click();
                Console.WriteLine("Credit product exist!!!");
                return true;
            }
            else return false;
        }
        public bool IsCreditProductExistInGrid()
        {
            Thread.Sleep(2000);
            if (driver.FindElements(By.CssSelector("table.table tbody tr")).ToList().Count > 0)
                return true;
            else
                return false;
        }
    }
}
