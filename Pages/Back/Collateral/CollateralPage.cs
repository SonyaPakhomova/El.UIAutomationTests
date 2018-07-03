using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Back.Collateral
{
    class CollateralPage:Page
    {
        public CollateralPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""reject()""]")]
        protected IWebElement reject { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""contact()""]")]
        protected IWebElement contact { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"add-collateral[add-Collateral=""addCollateral(selectedVal)""] button")]
        protected IWebElement addCollateral{get;set; }
        [FindsBy(How = How.CssSelector, Using = @"add-collateral[add-collateral=""addCollateral(selectedVal)""] ul li:nth-of-type(1)")]
        //--------Vehicle-----------------
        protected IWebElement Veichle { get; set; }
        [FindsBy(How = How.Id, Using = @"c.VehicleType_int")]
        protected IWebElement VehicleType { get; set; }
        [FindsBy(How = How.Id, Using = @"c.Make")]
        protected IWebElement Make { get; set; }
        [FindsBy(How = How.Id, Using = @"c.Vin")]
        protected IWebElement Vin { get; set; }
        [FindsBy(How = How.Id, Using = @"c.Style")]
        protected IWebElement Style { get; set; }
        [FindsBy(How = How.Id, Using = @"c.Model")]
        protected IWebElement Model { get; set; }
        [FindsBy(How = How.Id, Using = @"c.Year")]
        protected IWebElement Year { get; set; }
        [FindsBy(How = How.Id, Using = @"c.Mileage")]
        protected IWebElement Mileage { get; set; }
        //-------------------------------
        [FindsBy(How = How.Id, Using = @"c.Comment")]
        protected IWebElement Comment { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""$close(ir)""]")]
        protected IWebElement Ok { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""$close()""]")]
        protected IWebElement OkAfterValuate { get; set; }
        [FindsBy(How = How.XPath, Using = @"//form[@name=""collateralItemEdit""]/collateral-element[1]/div[1]/collateral-item-vehicle[1]/div[2]/div[1]/div[1]/div[2]/doc-upload[1]/div[1]/div[1]/label[1]/span[1]")]
        protected IWebElement ChooseFiel { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""valuate(c)""]")]
        protected IWebElement Valuate { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""edit(c)""]")]
        protected IWebElement Edit { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""release(c)""]")]
        protected IWebElement Delete { get; set; }
        [FindsBy(How = How.XPath, Using = @"id(""mg_"")/span[1]/button[1]")]
        protected IWebElement RequestMarketValue { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"input[name=""EstimatedValue""]")]
        protected IWebElement EstimatedValue { get; set; }
        [FindsBy(How = How.XPath, Using = @"//input[@name=""EstimatedValue""]")]
        protected IWebElement EstimateValue { get; set; }
        [FindsBy(How = How.XPath, Using = @"/html/body/section[1]/elmenu[1]/div[2]/div[1]/ng-view[1]/split-view[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[2]/button[3]")]
        protected IWebElement Approve { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"add-collateral[add-collateral=""addCollateral(selectedVal)""] ul li:nth-of-type(2)")]
        protected IWebElement Deposit { get; set; }
        [FindsBy(How = How.Id, Using = @"c.Amount")]
        protected IWebElement Amount { get; set; }
        [FindsBy(How = How.XPath, Using = @"//select[@name=""currency""]")]
        protected IWebElement Currency { get; set; }
        [FindsBy(How = How.Id, Using = @"c.AccountNumber_int")]
        protected IWebElement AccountNumber { get; set; }
        [FindsBy(How = How.Id, Using = @"c.EstateType_int")]
        protected IWebElement PropertyType { get; set; }
        [FindsBy(How = How.Id, Using = @"c.Condition_int")]
        protected IWebElement Condition { get; set; }
        [FindsBy(How = How.Id, Using = @"c.BuiltYear")]
        protected IWebElement YearBuilt { get; set; }
        [FindsBy(How = How.Id, Using = @"c.Rooms")]
        protected IWebElement Rooms { get; set; }
        [FindsBy(How = How.Id, Using = @"c.Address")]
        protected IWebElement Address { get; set; }
        [FindsBy(How = How.Id, Using = @"c.Size")]
        protected IWebElement PropertySize { get; set; }
        [FindsBy(How = How.Id, Using = @"c.ProofOwnershipId")]
        protected IWebElement ProofOfOwnership { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"add-collateral[add-collateral=""addCollateral(selectedVal)""] ul li:nth-of-type(3)")]
        protected IWebElement RealEstate { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""contact()""]")]
        protected IWebElement ContactButton { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"button[ng-click=""$close(comment)""]")]
        protected IWebElement SubmitApproveButton { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"div#mg_moneyComment > span > textarea")]
        protected IWebElement ValuateComments { get; set; }

        public void ClickContactButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(ContactButton));
            ContactButton.Click();
        }
        public void AddCollateralClick()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(addCollateral));
            addCollateral.Click();
        }
        //-----Deposit----------------
        public void AddDeposit()
        {
            Deposit.Click();
        }
        public void DepositAmount(string depositAmount)
        {
            Amount.SendKeys(depositAmount);
        }
        public void DepositCurrency(string depositCurrency)
        {
            new SelectElement(this.Currency).SelectByText(depositCurrency);
        }
        public void DepositAccountNumber(string accountNumber)
        {
            AccountNumber.SendKeys(accountNumber);
        }
        public void ClickOk()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Ok));
            Ok.Click();
        }
        //------Valuate------------------
        public void ClickValuateButton()
        {
            Valuate.Click();
        }
        public void SetEstimatedValue(string estimateValue)
        {
            EstimatedValue.Clear();
            EstimatedValue.SendKeys(estimateValue);
        }
        public void ClickApprove()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Approve));
            Approve.Click();
            SubmitApproveButton.Click();
        }
        public void SetComments(string comments)
        {
            Comment.SendKeys(comments);
        }
        public void SetValuateComments(string comments)
        {
            ValuateComments.SendKeys(comments);
        }
        public void ClickOKAfterValuate()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(OkAfterValuate));
            OkAfterValuate.Click();
        }


    }
}
