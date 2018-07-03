using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Back.Archive
{
    class ArchivePage:Page
    {
        public ArchivePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "input[placeholder=\"Search\"]")]
        private IWebElement searchField;
        [FindsBy(How = How.CssSelector,Using = "table#applicationsGrid_grid tr td[aria-describedby=\"applicationsGrid_grid_Status\"] div")]
        private IWebElement statusLoan;

        public void searchLoan(string loanId)
        {
           Thread.Sleep(2000);
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("input[placeholder=\"Search\"]")));
                searchField.Clear();
                searchField.SendKeys(loanId);
                Thread.Sleep(2000);
           
        }

        public string GetStatusLoan()
        {
            return driver
                .FindElements(By.CssSelector(
                    "table#applicationsGrid_grid tr"))[1].FindElement(By.CssSelector("td[aria-describedby=\"applicationsGrid_grid_Status\"] div"))
                .GetAttribute("class");
        }

    }
}
