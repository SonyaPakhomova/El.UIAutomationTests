using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using El.Test.UiTests.Modules;
using El.Test.UiTests.Pages;
using El.Test.UiTests.Pages.Back;
using El.Test.UiTests.Pages.Back.Archive;
using El.Test.UiTests.Pages.Back.Collateral;
using El.Test.UiTests.Pages.Back.Collection;
using El.Test.UiTests.Pages.Back.Origination;
using El.Test.UiTests.Pages.Back.Servicing;
using El.Test.UiTests.Pages.Back.System;
using El.Test.UiTests.Pages.Back.System.BlackList;
using El.Test.UiTests.Pages.Back.System.Credit_Products;
using El.Test.UiTests.Pages.Back.System.Users.Internal_Users;
using El.Test.UiTests.Pages.Back.System.Users.Investors;
using El.Test.UiTests.Pages.Back.Underwriting;
using El.Test.UiTests.Pages.Front;
using El.Test.UiTests.Pages.Front.Investor;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace El.Test.UiTests.Helpers
{
    public class Application
    {
        internal ApplicationFormPage ApplicationFormPage;
        internal BackApplicationFormPage BackApplicationFormPage;
        internal AllPagesConsist AllPagesConsist;
        internal CreateAccountPage CreateAccountPage;
        internal CreditProductsCreatePage CreditProductCreatePage;
        internal CreditProductPage CreditProductPage;
        internal CustomerVerificationPage CustomerVerificationPage;
        internal IWebDriver driver;
        internal LoginPage LoginPage;
        internal OriginationPage OriginationPage;
        internal SetLoanParam SetLoanParam;
        internal SystemPage SystemPage;
        internal UnderwritingPage UnderwritingPage;
        internal UsersPage UsersPage;
        internal WebDriverWait wait;
        internal WelcomePage WelcomePage;
        internal ServicinPage ServisingPage;
        internal CollectionPage CollectionPage;
        internal ArchivePage ArchivePage;
        internal ContactsPage ContactPage;
        internal BlackListPage BlackListPage;
        internal PersonalArea PersonalArea;
        internal Login logina;
        internal Users Users;
        internal Investor Investors;
        internal CreditProduct CreditProducts;
        internal Loan Loans;
        internal CollateralPage CollateralPage;
        internal InvestorPage InvestorPage;
        internal InvestorPersonalArea InvestorPersonalArea;
        public Application()
        {
            //--------Local testing--------
            //driver = WebDriverFactory.CreateWebDriver(Browser);
            //--------Remote testing-------
            var capabilities = new DesiredCapabilities(Browser, "latest", new Platform(PlatformType.Any));
            capabilities.SetCapability("enableVNC", true);
            capabilities.SetCapability("screenResolution", "1280x1024x24");
            //capabilities.SetCapability("screenResolution", "800x600x24");
            capabilities.SetCapability("enableVideo",true);
            driver = new RemoteWebDriver(new Uri("http://192.168.0.73:4444/wd/hub"), capabilities);
            //driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities);
            //WebDriverFactory.InitBrowser("Chrome");
            //-----------
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            //----Initialize pages-----
            LoginPage = new LoginPage(driver);
            AllPagesConsist = new AllPagesConsist(driver);
            UsersPage = new UsersPage(driver);
            SystemPage = new SystemPage(driver);
            WelcomePage = new WelcomePage(driver);
            CreateAccountPage = new CreateAccountPage(driver);
            ApplicationFormPage = new ApplicationFormPage(driver);
            CreditProductCreatePage = new CreditProductsCreatePage(driver);
            CreditProductPage = new CreditProductPage(driver);
            OriginationPage = new OriginationPage(driver);
            SetLoanParam = new SetLoanParam(driver);
            CustomerVerificationPage = new CustomerVerificationPage(driver);
            BackApplicationFormPage = new BackApplicationFormPage(driver);
            UnderwritingPage = new UnderwritingPage(driver);
            ServisingPage = new ServicinPage(driver);
            CollectionPage = new CollectionPage(driver);
            ArchivePage = new ArchivePage(driver);
            ContactPage = new ContactsPage(driver);
            BlackListPage = new BlackListPage(driver);
            PersonalArea = new PersonalArea(driver);
            CollateralPage = new CollateralPage(driver);
            InvestorPage = new InvestorPage(driver);
            InvestorPersonalArea = new InvestorPersonalArea(driver);
    
            //---Initializa Helpers-------------
            Users = new Users(this);
            CreditProducts = new CreditProduct(this);
            Loans = new Loan(this);
            Investors = new Investor(this);
            
        }

        private static string Browser => AppConfigSettingsReader.Read("Browser", "");
       //-------Страница логина-----------------------
      public void Login(string testName)
        {
            //logina.LoginAs(testName);
            var userData = ExcelDataAccess.GetLoginData(testName, "Login");
            LoginPage.open()
                .setLogin(userData.Username)
                .setPassword(userData.Password)
                .clickSubmit();
            if (LoginPage.isElementPresent(By.CssSelector("div.validation-summary-errors"))) Console.WriteLine("Invalid username or password");
        }

        public void Logout()
        {
            AllPagesConsist.clickLogout();
        }
        public void Quit()
        {
            driver.Quit();
        }
        //----Создание нового юзера------------
        public void CreateUser(string testName)
        {
           Users.CreateUser(testName);
        }
        //-----Создание нового инвестора-------
        public void CreateNewInvestor(string testName)
        {
            SystemPage.clickUsersTab();
            UsersPage.clickInvestorTab();
            //investorPage.CreateInvestorClick();
            Investors.CreateInvestor(testName);
            SearchInGrid("");
        }

        public void InvestorBid(string amount, string loanId)
        { 
            //Console.WriteLine(investorPersonalArea.ListInvestLoan()[0].Text);
            //List<IWebElement> listBid = driver.FindElements(By.CssSelector("tr:nth-of-type(2) td.actions")).ToList();
            //Console.WriteLine(investorPersonalArea.ListInvestLoan().Count);
            for (int i = 0; i < InvestorPersonalArea.ListInvestLoan().Count; i++)
            {   //Console.WriteLine(investorPersonalArea.ListInvestLoan()[i].Text);
                //Thread.Sleep(2000);
                //Console.WriteLine(listBid[i].FindElement(By.CssSelector("a.btn_bid")).Text);
                int j = i + 1;
                if (InvestorPersonalArea.ListInvestLoan()[i].Text==loanId)
                driver.FindElement(By.CssSelector("tr:nth-of-type("+j+") td.actions a.btn-bid")).Click();
            }
            InvestorPersonalArea.SetAmount(amount)
                .ClickOk();
        }
        //-----Проверка наличия вкладок на рабочих местах
        public void СheckTabs(string page)
        {
            string tabStr = "";
            var userData = ExcelDataAccess.GetTabData(page, "Tab");
            for (int i = 0; i < AllPagesConsist.GetListTabs(page).Count; i++)
            {
                tabStr = tabStr + AllPagesConsist.GetListTabs(page)[i].GetAttribute("heading").Replace(" ", "") + " ";
                //string tabName = AllPagesConsist.GetListTabs("")[i].GetAttribute("heading");
            }
            Console.WriteLine(tabStr);
            Console.WriteLine(userData.Tabs);
            Assert.IsTrue(tabStr==userData.Tabs);
           // userData.CustomerDetails;
            /*systemPage.searchUserFill(userData.UserLogin)
            AllPagesConsist.GetListTabs();*/
        }
        //----Добавление контакта на Origination Page  ---------------
        public void FillContact(string page)
        {
            AllPagesConsist.GoToItaractionHistoryTab();
            IList<IWebElement> oldList = AllPagesConsist.GetContactsList();
            switch (page)
            {
                case "Origination":
                {
                    OriginationPage.AddContact();
                    ContactPage.setResult("Success");
                    break;
                }
                case "Collateral":
                {
                        CollateralPage.ClickContactButton();
                        ContactPage.setResult("Success");
                        break;
                }
                case "Servicing":
                {
                    ServisingPage.ClickContactButton();
                    ContactPage.setResult("Success");
                    break;
                }
                case "Collection":
                {
                    CollectionPage.ClickContactButton();
                    ContactPage.setResult("Failed to reach");
                }

                break;
            }
            ContactPage.setMethod("Email")
                       .setPurpose("testPurpose")
                       .setComments("test Comments")
                       .clickOkButton();
            IList<IWebElement> newList = AllPagesConsist.GetContactsList();
            Assert.IsTrue(oldList!=newList);
        }
        //----Создание лоана с бека ------------------------
        public string CreateLoanFromBack(string CreditProduct)
        {
            AllPagesConsist.goToOriginationPage();
            //List<IWebElement> oldIds = GetLoansList();
            //Console.WriteLine(oldIds.Count);
            OriginationPage.newApplicationButtonClick();
            SetLoanParam.setCreditProduct(CreditProduct)
                .setLoanAmount("1000")
                .setTerm("6")
                .buttonProcedClick();
            CustomerVerificationPage.newCustomerButtonClick();
            //backApplicationFormPage.clickFakeButton().SubmitApplicationButton();
            Loans.FillApplicationForm("Fake");
            Thread.Sleep(2000);
            //SearchLoan(GetLoanId());
            //List<IWebElement> newIds = GetLoansList();
            //Console.WriteLine(newIds.Count);
            //Assert.IsTrue(newIds.Count == oldIds.Count + 1, "Create loan - FAIL");
           
            return //driver.FindElements(By.CssSelector("div#gview_applicationsGrid_grid tr[id]"))[0].Text.Substring(3);
            GetLoanId();
        }
        //------Создание лоана с фронта----------------
        public string CreateLoanFromFront(string CreditProduct)
        {
           WelcomePage.setLoanType(CreditProduct)
                       .setLoanAmount("1000")
                       .setLoanTerm("6")
                       .ApplyClick();
            CreateAccountPage.setUserEmail(DateTime.Now.ToString("yyMMddHmmss") + "@user.ua")
                .setPassword("123456")
                .setConfermPassword("123456")
                .createAccountClick();
            ApplicationFormPage.clickFakeButton()
                               .SubmitApplicationButton();
            return PersonalArea.GetLoanIdFront();
        }
        //--------Создание кредитного продукта-------------
        public void CreateCreditProduct(string testName)
        {
           if (CreditProducts.SearchCreditProduct(testName) == false)
            {
               CreditProducts.CreateCreditProduct(testName);
               
            } 
        }
        //-----Удаление кредитного продукта----------
        public void DeleteCreditProduct(string testName)
        {
            CreditProducts.DeleteCreditProduct(testName);
        }
        
        //--------BkackList--------------
        public void AddToBlackList(string page, string loanId)
        {
            AllPagesConsist.goToSystemTab();
            SystemPage.clickBlackListTab();
            List<IWebElement> oldList = GetGridBlackList();
            switch (page)
            {
                case "Underwriting":
                {
                    AllPagesConsist.goToUnderwritingPage();
                    SearchLoan(loanId);
                    UnderwritingPage.ClickAddToBlackList();
                    UnderwritingPage.clickSubmitAddLoanToBlackList();
                    UnderwritingPage.ClickCancelToAddRejectLoan();
                    break;
                }
                case "Servicing":
                {
                    AllPagesConsist.goToServicingPage();
                    SearchLoan(loanId);
                    UnderwritingPage.ClickAddToBlackList();
                    UnderwritingPage.clickSubmitAddLoanToBlackList();
                    break;
                }
                case "Collection":
                {
                    AllPagesConsist.goToCollectionPage();
                    SearchLoan(loanId);
                    UnderwritingPage.ClickAddToBlackList();
                    UnderwritingPage.clickSubmitAddLoanToBlackList();
                    break;
                }

            }
            AllPagesConsist.goToSystemTab();
            SystemPage.clickBlackListTab();
            List<IWebElement> newList = GetGridBlackList();
            Assert.IsTrue(oldList.Count!=newList.Count,"Adding to BlackList FAILED!!!");
            BlackListPage.CheckAllBlackListClick().SetDeleteSelected().SubmitDeleteBlackListPageClick();

        }
        public void AddCollateral()
        {
            CollateralPage.AddCollateralClick();
            CollateralPage.AddDeposit();
            CollateralPage.DepositAmount("10000");
            CollateralPage.DepositCurrency("USD");
            CollateralPage.DepositAccountNumber("123456789123456789");
            CollateralPage.SetComments("AddDeposite");
            CollateralPage.ClickOk();
        }
        public void ValuateCollateral()
        {
            CollateralPage.ClickValuateButton();
            CollateralPage.SetEstimatedValue("10000");
            CollateralPage.SetValuateComments("AddDeposite");
            CollateralPage.ClickOKAfterValuate();
        }

        //-------------------------------------
        public List<IWebElement> GetLoansId()
        {
            int i = 0;
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("th#applicationsGrid_grid_Id")));
            //wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div#gview_applicationsGrid_grid tr[id] td:nth-of-type(1)")));
            //Обновляем грид с лоанами, пока не появится наш лоан 
            while (driver.FindElements(By.CssSelector("div#gview_applicationsGrid_grid tr[id] td:nth-of-type(1)"))
                       .ToList().Count == 0)
            {
                
                driver.FindElement(By.CssSelector("th#applicationsGrid_grid_Id")).Click();
                i++;
                if (i > 3) break;
            }
            return driver.FindElements(By.CssSelector("div#gview_applicationsGrid_grid tr[id] td:nth-of-type(1)")).ToList();
        }
        public List<IWebElement> GetLoansList()
        {
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div#gview_applicationsGrid_grid tr[id]")));
            return driver.FindElements(By.CssSelector("div#gview_applicationsGrid_grid tr[id]")).ToList();
        }
        public void SearchLoan(string loanId)
        {
            try
            {
                Thread.Sleep(3000);
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[ng-model=\"search.search\"]")));
                //List<IWebElement> oldIds = GetLoansId();
                driver.FindElement(By.CssSelector("input[ng-model=\"search.search\"]")).SendKeys(loanId);
                Console.WriteLine(GetLoansId()[0].Text.Substring(3));
                int i = 0;
                try
                {
                    while (loanId != GetLoansId()[0].Text.Substring(3))
                    {
                        i++;
                        Thread.Sleep(1000);
                        if (i > 3)
                        {
                            Console.WriteLine("Loan can not find!!!");
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Лоан завис в 3 статусе");
                    Quit();
                    //Logout();
                }
            }
            catch (StaleElementReferenceException e)
            {
                Console.WriteLine("Строка поиска не найдена");            
                Quit();
            }
            
        }
            //List<IWebElement> newIds = GetLoansId();
            //Console.WriteLine(newIds.Count);
            // while(newIds.Count<1) driver.FindElement(By.CssSelector("th#applicationsGrid_grid_Id")).Click();
            //while (oldIds == newIds)
            //    Thread.Sleep(1000);
        
        public void selectLoan(string loanId)
        {
            Thread.Sleep(2000);
            for (int i = 0; i < driver.FindElements(By.CssSelector("table#applicationsGrid_grid tr")).Count; i++)
            {
                if (driver.FindElements(By.CssSelector("table#applicationsGrid_grid tr"))[i].GetAttribute("id") ==
                    loanId)
                    driver.FindElements(By.CssSelector("table#applicationsGrid_grid tr"))[i].Click();
            }
            //PaymentsTab.Click();
        }
        public string GetLoanId()
        {
            Thread.Sleep(1000);
            //wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div#gview_applicationsGrid_grid"));
            return GetLoansId()[0].Text.Substring(3);
        }
        internal void SelectLoan(string LoanId)
        {
            driver.FindElement(By.XPath("id(\"" + LoanId + "\")")).Click();
        }

        public bool SearchInGrid(string element)
        {
            bool result = true;
            List<IWebElement> list = driver.FindElements(By.CssSelector("div.panel-body table tbody tr")).ToList();
            foreach (IWebElement t in list)
            {
                if (t.FindElement(By.CssSelector("td:nth-of-type(2)")).Text == element)
                {
                    result = true;
                    break;
                }
                else
                    result = false;
            }
            return result;
        }
        public void waitActiveLoan()
        {
            while (ServisingPage.CheckStatusLoan() != "loanStatus status-Active")
            {
                Thread.Sleep(1000);
            }
        }

        public string GetFullName(string loanId)
        {
            //SelectLoan(loanId);
            return driver.FindElement(By.CssSelector("table#applicationsGrid_grid tr[id=\""+loanId+"\"] td span.fullname")).Text;
        }

        //---Получение Черного списка в System - BlackList
        public List<IWebElement> GetGridBlackList()
        {
            Thread.Sleep(2000);
            return driver.FindElements(By.CssSelector("table#blackListGrid_grid tr")).ToList();
        }
    }
   
}