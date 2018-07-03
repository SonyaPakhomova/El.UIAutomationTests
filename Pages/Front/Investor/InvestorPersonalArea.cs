using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Front.Investor
{
    class InvestorPersonalArea:Page
    {
        public InvestorPersonalArea(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver,this);
        }
        [FindsBy(How = How.CssSelector, Using = "td.actions a.btn-bid")]
        private IWebElement BidButton;
        [FindsBy(How = How.XPath, Using = "id(\"data.Amount_int\")")]
        private IWebElement Amount;
        [FindsBy(How = How.CssSelector, Using = "td.actions a.btn-bid")]
        private IWebElement InterestRate;
        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"submit(settings)\"]")]
        private IWebElement OkButton;
        [FindsBy(How = How.CssSelector, Using = "div.modal-footer button[ng-click=\"$close()\"]")]
        private IWebElement OkButtonSubmit;

        public InvestorPersonalArea BidButtonClick()
        {
            BidButton.Click();
            return this;
        }
        public InvestorPersonalArea SetAmount(string amount)
        {
            Amount.SendKeys(amount);
            return this;
        }
        public InvestorPersonalArea ClickOk()
        {
            OkButton.Click();
            OkButtonSubmit.Click();
            return this;
        }

        public List<IWebElement> ListInvestLoan()
        {
            //wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.opportunities table tr td:nth-of-type(1)")));
            return driver.FindElements(By.CssSelector("div.opportunities table tr td:nth-of-type(1)")).ToList();
            //List<IWebElement> listBid = driver.FindElements(By.CssSelector("div.opportunities table tr td:nth-of-type(9)")).ToList();
            //Console.WriteLine(listLoanId[0].GetAttribute("text"));
            /*for (int i = 0; i < listLoanId.Count; i++)
            {   Console.WriteLine(listLoanId[i].GetAttribute("text"));
                //Thread.Sleep(2000);
                //Console.WriteLine(listBid[i].FindElement(By.CssSelector("a.btn_bid")).Text);
                //if (listLoanId[i].GetAttribute("text")==loanId)
                //listBid[i].FindElement(By.CssSelector("a.btn_bid")).Click();
            }*/
            //return this;
        }
    }
}
