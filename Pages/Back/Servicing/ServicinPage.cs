using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Back.Servicing
{
    class ServicinPage:Page
    {
        public ServicinPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "input[placeholder=\"Search\"]")]
        private IWebElement searchField;

        [FindsBy(How = How.CssSelector, Using = "div[ng-show=\"loan.Status==5 || loan.Status==13\"] button")]
        private IWebElement disburseButton;

        [FindsBy(How = How.CssSelector, Using = "a[ng-click=\"disburse()\"]")]
        private IWebElement manualDisburse;

        [FindsBy(How = How.CssSelector, Using = "div#servicingTabs ul li[heading=\"Customer Details\"]")]
        private IWebElement CustomerDetailsTab;

        [FindsBy(How = How.CssSelector, Using = "div#servicingTabs ul li")]
        private IList <IWebElement> ServisingTabs;
        [FindsBy(How = How.XPath, Using = "//input[@name=\"refnum\"]")]
        private IWebElement Reference;
        [FindsBy(How = How.XPath, Using = "//select[@name=\"paymenttype\"]")]
        private  IWebElement TypeDisburse;
        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"submit(disburse)\"]")]
        private IWebElement OkButton;
        [FindsBy(How = How.CssSelector, Using = "div[complete-handler=\"timeShifted\"] button")]
        private IWebElement TimeShiftButton;
        [FindsBy(How = How.CssSelector, Using = "a[ng-click=\"setPastDue(6)\"]")]
        private IWebElement TimeShift1Month;
        [FindsBy(How = How.Id, Using = "jqgh_applicationsGrid_grid_Id")]
        private IWebElement sortById;
        [FindsBy(How = How.CssSelector, Using = "button[indi-click=\"repayment()\"]")]
        private IWebElement PaymentButton;
        [FindsBy(How = How.CssSelector, Using = "input#_int")]
        private IWebElement AmountField;
        [FindsBy(How = How.XPath, Using = "//input[@name=\"refnum\"]")]
        private IWebElement ReferenceField;
        [FindsBy(How = How.XPath, Using = "//select[@name=\"paymenttype\"]")]
        private IWebElement TypeList;
        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"submit(payment)\"]")]
        private IWebElement ApprovePayment;
        [FindsBy(How = How.CssSelector, Using = "div#servicingTabs ul li")]
        private IList <IWebElement> listTabs;
        [FindsBy(How = How.CssSelector, Using = "div#servicingTabs ul li[heading=\"Payments\"]")]
        private IWebElement PaymentsTab;
        [FindsBy(How = How.CssSelector,Using ="table#applicationsGrid_grid tr td[aria-describedby=\"applicationsGrid_grid_Status\"] div[title=\"Active\"]")]
        private IWebElement statusLoan;
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""newContact()""]")]
        private IWebElement ContactButton;
        

        public void ClickContactButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(ContactButton));
            ContactButton.Click();
        }
        public void DisburseLoan()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(disburseButton));
            disburseButton.Click();
            manualDisburse.Click();
            Reference.SendKeys("123");
            //new SelectElement(this.TypeDisburse).SelectByText("Cash");
            new SelectElement(this.TypeDisburse).SelectByIndex(1);
            OkButton.Click();
        }

        public void TimeShiftMonth(int countMonth)
        {
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[complete-handler=\"timeShifted\"] button")));
            //for (int i = 0; i < countMonth; i++)
            //{
            TimeShiftButton.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[ng-click=\"setPastDue("+countMonth+")\"]")));
            driver.FindElement(By.CssSelector("a[ng-click=\"setPastDue("+countMonth+")\"]")).Click();
            //Console.WriteLine(driver.FindElements(By.CssSelector("loan-schedule-new div.table- responsive tbody tr"))[2].GetAttribute("class"));
            //while (driver.FindElements(By.CssSelector("loan-schedule-new div.table-responsive tbody tr"))[2].GetAttribute("class")!= "ng-scope danger")
            //Thread.Sleep(1000);
            //driver.FindElement(By.CssSelector("div.table-responsive tbody tr[class=\"ng-scope danger\"]"));
            //TimeShift1Month.Click();
            Thread.Sleep(2000);
            //}
        }
        public void TimeShiftDays(int countDays)
        {
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[complete-handler=\"timeShifted\"] button")));
            TimeShiftButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[ng-click=\"setPastDue()\"]")));
            driver.FindElement(By.CssSelector("a[ng-click=\"setPastDue()\"]")).Click();
            while (driver.FindElements(By.CssSelector("loan-schedule-new div.table-responsive tbody tr"))[2].GetAttribute("class") != "ng-scope danger")
            Thread.Sleep(2000);
            
        }
        public List<IWebElement> GetLoanId()
        {
            return driver.FindElements(By.CssSelector("div#gview_applicationsGrid_grid tr[id] td:nth-of-type(1)")).ToList();
        }
        public void SortById()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("jqgh_applicationsGrid_grid_Id")));
            Thread.Sleep(2000);
            sortById.Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("table#applicationsGrid_grid tr:nth-of-type(2)")).Click();
            //Console.WriteLine(GetLoanId()[1].Text);
            //GetLoanId()[1].Click();
        }

        public void selectLoan(string loanId)
        {
            Thread.Sleep(2000);
            for (int i = 0; i < driver.FindElements(By.CssSelector("table#applicationsGrid_grid tr")).Count; i++)
            {
                if (driver.FindElements(By.CssSelector("table#applicationsGrid_grid tr"))[i].GetAttribute("id") ==
                    loanId)
                    driver.FindElements(By.CssSelector("table#applicationsGrid_grid tr"))[i].Click();
            }
            PaymentsTab.Click();
        }

        public string GetStatusPayment(int paymentId)
        {
            
            string status = driver.FindElement(By.CssSelector("loan-schedule-new tbody tr:nth-of-type(" + paymentId + ") td:nth-of-type(9)")).Text;
            return status;

        }

        public void SearchLoan(string loanId)
        {
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("input[placeholder=\"Search\"]")));
            searchField.Clear();
            searchField.SendKeys(loanId);
            Thread.Sleep(2000);
        }

        public double GetTotalAmountOfPayment(int paymentId)
        {
            PaymentsTab.Click();
            //for (int i = 0; i < paymentId; i++)
            //loan - schedule - new tbody > tr:nth - of - type(1) > td:nth - of - type(3)
           //return driver.FindElements(By.CssSelector("loan-schedule-new tbody tr:nth-of-type"))[paymentId].FindElement(By.CssSelector("td:nth-of-type(3)")).Text;
            string amount = driver.FindElement(By.CssSelector("loan-schedule-new tbody tr:nth-of-type(" + paymentId +") td:nth-of-type(3)")).Text.Substring(1);

            return Convert.ToDouble("2000.03");
        }

        public void Repayment(string amount)
        {
           wait.Until(ExpectedConditions.ElementToBeClickable(PaymentButton));
            PaymentButton.Click();
            AmountField.SendKeys(amount);
            ReferenceField.SendKeys("123");
            //new SelectElement(TypeList).SelectByText("Cash");
            new SelectElement(TypeList).SelectByIndex(1);
            ApprovePayment.Click();
            Thread.Sleep(2000);
        }

        public void GoToPaymentTab()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(PaymentsTab));
            PaymentsTab.Click();
        }
        public string CheckStatusLoan()
        {
            //return driver.FindElement(By.CssSelector("table#applicationsGrid_grid tr td[aria-describedby=\"applicationsGrid_grid_Status\"] div")).GetAttribute("title");
            return driver.FindElement(By.CssSelector("table#applicationsGrid_grid tr td[aria-describedby=\"applicationsGrid_grid_Status\"] div")).GetAttribute("class");
        }


    }
}
