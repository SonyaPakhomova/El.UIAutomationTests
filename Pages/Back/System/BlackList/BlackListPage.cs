using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Back.System.BlackList
{
    class BlackListPage:Page
    {
        public BlackListPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""deleteItems()""]")]
        protected IWebElement DeleteSelected;
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""addNewEntry(blackListType)""]")]
        protected IWebElement AddNewRecord { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""importList()""]")]
        protected IWebElement ImportData { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"input[placeholder=""Search""]")]
        protected IWebElement Search { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"table#blackListGrid_grid")]
        protected IWebElement BlackListGrid { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"div#mg_current select")]
        protected IWebElement ChooseCategory { get; set; }
        [FindsBy(How = How.XPath, Using = @"//input[@name=""current.value.FirstName""]")]
        protected IWebElement FirstName{get;set;}
        [FindsBy(How = How.XPath, Using = @"//input[@name=""current.value.MiddleName""]")]
        protected IWebElement MiddleName { get; set; }
        [FindsBy(How = How.XPath, Using = @"//input[@name=""current.value.LastName""]")]
        protected IWebElement LastName { get; set; }
        [FindsBy(How = How.XPath, Using = @"id(""mg_current.value.Suffix"")/span[1]/select[1]")]
        protected IWebElement Suffix { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"input[name=""dateField""]")]
        protected IWebElement DateofBirth { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"button[indi-click=""submit(current)""]")]
        protected IWebElement OKButton { get; set; }
        [FindsBy(How = How.Id, Using = @"current.value.ssn")]
        protected IWebElement SSN { get; set; }
        [FindsBy(How = How.Id, Using = @"_int")]
        protected IWebElement Phone { get; set; }
        [FindsBy(How = How.Id, Using = @"current.value.address")]
        protected IWebElement Email { get; set; }
        [FindsBy(How = How.Id, Using = @"current.value.id")]
        protected IWebElement DriverLicense { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"th#blackListGrid_grid_cb")]
        protected IWebElement CheckAllBlackList { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""$close(comment)""]")]
        protected IWebElement SubmitSeleteAllBlackList{ get; set; }
        public BlackListPage SetFirstName(string firstName)
        {
            FirstName.SendKeys(firstName);
            return this;
        }

        public BlackListPage CheckAllBlackListClick()
        {
            CheckAllBlackList.Click();
            return this;
        }

        public BlackListPage SubmitDeleteBlackListPageClick()
        {
            SubmitSeleteAllBlackList.Click();
            return this;
        }

        public BlackListPage SetSearchField(string search)
        {
            Search.SendKeys(search);
            return this;
        }
        public BlackListPage SetMiddleName(string middleName)
        {
            MiddleName.SendKeys(middleName);
            return this;
        }
        public BlackListPage SetDriverLicense(string driverLicense)
        {
            DriverLicense.SendKeys(driverLicense);
            return this;
        }
        public BlackListPage SetLastName(string lastName)
        {
            LastName.SendKeys(lastName);
            return this;
        }
        public BlackListPage SetDateofBirth(string dateofBirth)
        {
            DateofBirth.SendKeys(dateofBirth);
            return this;
        }
        public BlackListPage SetSSN(string ssn)
        {
            SSN.SendKeys(ssn);
            return this;
        }
        public BlackListPage SetPhone(string phone)
        {
            Phone.SendKeys(phone);
            return this;
        }
        public BlackListPage SetEmail(string email)
        {
            Email.SendKeys(email);
            return this;
        }
        public BlackListPage SetSuffix(string suffix)
        {
            Suffix.SendKeys(suffix);
            return this;
        }
        public BlackListPage SetDeleteSelected()
        {
            DeleteSelected.Click();
            return this;
        }
        public void ClickOkButton()
        {
            OKButton.Click();
        }
        public BlackListPage ClickAddNewRecord()
        {
            AddNewRecord.Click();
            return this;
        }
        public BlackListPage ClickImportData()
        {
            ImportData.Click();
            return this;
        }

        public BlackListPage setChooseCategory(string category)
        {
            new SelectElement(ChooseCategory).SelectByText(category);
            return this;
        }
    }
}
