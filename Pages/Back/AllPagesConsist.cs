using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Back

{
    internal class AllPagesConsist:Page   
    {
        public AllPagesConsist(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.LinkText, Using = "Log off")]
        private IWebElement linkLogOut;
        [FindsBy(How = How.LinkText, Using = "Login")]
        private IWebElement linkLogIn;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"#/system/users\"]")]
        private IWebElement linkSystem;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"#/origination\"]")]
        private IWebElement linkOrigination;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"#/underwriting\"]")]
        private IWebElement linkUnderwriting;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"#/collateral\"]")]
        private IWebElement linkCollateral;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"#/servicing\"]")]
        private IWebElement linkServicing;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"#/collection\"]")]
        private IWebElement linkCollection;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"#/report\"]")]
        private IWebElement linkReports;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"#/archive\"]")]
        private IWebElement likArchive;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"#/customers\"]")]
        private IWebElement linkCustomers;
        [FindsBy(How = How.LinkText, Using = "div#originationTabs ul li")]
        private IList <IWebElement> listTabs;
        [FindsBy(How = How.CssSelector, Using = "li[heading=\"Interaction History\"] a")]
        private IWebElement InteractionHistoryTab;
        [FindsBy(How = How.CssSelector, Using = "table[ng-if=\"loan.Contacts\"] tr")]
        private IList<IWebElement> ContactsGrid;



        //public static string Url => AppConfigSettingsReader.Read("Url", "");

        public void clickLogout()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Log off")));
            linkLogOut.Click();
        }
        public void clickLogin()
        {
            linkLogIn.Click();
        }
        public void goToSystemTab()
        {
            //wait.Until(ExpectedConditions.ElementToBeClickable(linkSystem));
            linkSystem.Click();
        }

        public void goToUnderwritingPage()
        {
           // wait.Until(ExpectedConditions.ElementToBeClickable(linkUnderwriting));
            linkUnderwriting.Click();
        }
        public void goToServicingPage()
        {
            //wait.Until();
            linkServicing.Click();
        }
        public void goToArchivePage()
        {
            //wait.Until();
            likArchive.Click();
        }
        public void goToCollectionPage()
        {
            //wait.Until();
            linkCollection.Click();
        }
        public void goToOriginationPage()
        {
            //wait.Until();
            linkOrigination.Click();
        }

        public void goToCollateralPage()
        {
            linkCollateral.Click();
        }

        public IList<IWebElement> GetListTabs(string page)
        {
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div#"+page+"Tabs ul li")));
            return driver.FindElements(By.CssSelector("div#"+page+"Tabs ul li")).ToList();

        }

        public void GoToItaractionHistoryTab()
        {
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementToBeClickable(InteractionHistoryTab));
            InteractionHistoryTab.Click();
        }

        public IList<IWebElement> GetContactsList()
        {
            Thread.Sleep(1000);
            return driver.FindElements(By.CssSelector("table[ng-if=\"loan.Contacts\"] tr")).ToList();
        }

    }
}
