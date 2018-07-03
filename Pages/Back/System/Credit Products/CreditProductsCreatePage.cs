using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Back.System.Credit_Products
{
    internal class CreditProductsCreatePage:Page
    {
        public CreditProductsCreatePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver,this);
        }

        [FindsBy(How = How.Id, Using = "cp.Name")]
        private IWebElement creditProductName;
        [FindsBy(How = How.Name, Using = "cp.LoanType")]
        private IWebElement loanType;
        [FindsBy(How = How.Id, Using = "cp.CalculationMethodObj")]
        private IWebElement typeOfCalculation;
        [FindsBy(How = How.Id, Using = "cp.PeriodicityObj")]
        private IWebElement periodicity;
        [FindsBy(How = How.Id, Using = "cp.MinAmount_int")]
        private IWebElement minAmount;
        [FindsBy(How = How.Id, Using = "cp.MaxAmount_int")]
        private IWebElement maxAmount;
        [FindsBy(How = How.XPath, Using = "id(\"cp.MinTerm\")/div[1]/div[1]/input[1]")]
        private IWebElement minTerm;
        [FindsBy(How = How.XPath, Using = "id(\"cp.MaxTerm\")/div[1]/div[1]/input[1]")]
        private IWebElement maxTerm;
        [FindsBy(How = How.CssSelector, Using = "percents-edit[ng-model=\"cp.InterestRate\"] input")]
        private IWebElement interestRate;
        [FindsBy(How = How.Id, Using = "cp.ToleranceWriteOff_int")]
        private IWebElement toleranceWriteOff;
        [FindsBy(How = How.Name, Using = "cp.OverdueInterestType")]
        private IWebElement overDueInterestType;
        [FindsBy(How = How.CssSelector, Using = "percents-edit[ng-model=\"cp.OverdueInterestRate\"] input")]
        private IWebElement overdueInterestRate;
        [FindsBy(How = How.Id, Using = "cp.LateGraceDays")]
        private IWebElement lateGraceDays;
        [FindsBy(How = How.CssSelector, Using = "button[indi-click=\"submit()\"]")]
        private IWebElement okButton;
        //---P2P loan---------------
        [FindsBy(How = How.CssSelector, Using = "input[ng-model=\"cp.P2PSettings.Enabled\"]")]
        private IWebElement P2PEnebled;
        [FindsBy(How = How.CssSelector, Using = "div[ng-if=\"cp.P2PSettings.Enabled\"] input[name=\"percentsValue\"]")]
        private IWebElement IIR;
        [FindsBy(How = How.CssSelector, Using = "select[name=\"cp.P2PSettings.Workflow\"]")]
        private IWebElement WorkflowInvestor;
        //---Rollover loan----------
        [FindsBy(How = How.CssSelector, Using = "input[ng-model=\"cp.Rollover.Enabled\"]")]
        private IWebElement RolloverCheck;
        [FindsBy(How = How.CssSelector, Using = "time-span[ng-model=\"cp.Rollover.MinTermStr\"] input[type=\"number\"]")]
        private IWebElement minTermRollover;
        [FindsBy(How = How.CssSelector, Using = "time-span[ng-model=\"cp.Rollover.MaxTermStr\"] input[type=\"number\"]")]
        private IWebElement maxTermRollover;
        [FindsBy(How = How.CssSelector, Using = "input[ng-model=\"cp.Rollover.MaxRolloversForLoan\"]")]
        private IWebElement maxAllowedRollover;
        [FindsBy(How = How.CssSelector, Using = "percents-edit[ng-model=\"cp.MaxLTV\"] input")]
        private IWebElement maxLTV;
        [FindsBy(How = How.CssSelector, Using = "percents-edit[ng-model=\"cp.P2PSettings.InvestmentInterestRate\"] input")]
        private IWebElement InvestInterestRate;
        [FindsBy(How = How.XPath, Using = "//select[@name=\"cp.P2PSettings.Workflow\"]")]
        private IWebElement Workflow;
        [FindsBy(How = How.CssSelector, Using = "input[ng-model=\"cp.UseCollateral\"]")]
        private IWebElement CollateralCheck;
        public CreditProductsCreatePage setName(string name)
        {
            creditProductName.SendKeys(name);
            return this;
        }
        public CreditProductsCreatePage setLoanType(string loanType)
        {
            new SelectElement(this.loanType).SelectByText(loanType);
            return this;
        }
        public CreditProductsCreatePage setTypeofCalculation(string typeOfCalculation)
        {
            new SelectElement(this.typeOfCalculation).SelectByText(typeOfCalculation);
            return this;
        }
        public CreditProductsCreatePage setPeriodicity(string periodicity)
        {
            new SelectElement(this.periodicity).SelectByText(periodicity);
            return this;
        }
        public CreditProductsCreatePage setMinAmount(string minAmount)
        {
            this.minAmount.SendKeys(minAmount);
            return this;
        }
        public CreditProductsCreatePage setMaxAmount(string maxAmount)
        {
           this.maxAmount.SendKeys(maxAmount);
            return this;
        }
        public CreditProductsCreatePage setMinTerm(string minTerm)
        {
            this.minTerm.SendKeys(minTerm);
            return this;
        }
        public CreditProductsCreatePage setMaxTerm(string maxTerm)
        {
            this.maxTerm.SendKeys(maxTerm);
            return this;
        }
        public CreditProductsCreatePage setInterestRate(string interstRate)
        {
            this.interestRate.SendKeys(interstRate);
            return this;
        }
        public CreditProductsCreatePage setToleranceWriteOff(string toleranceWriteOff)
        {
            this.toleranceWriteOff.SendKeys(toleranceWriteOff);
            return this;
        }
        public CreditProductsCreatePage setOverDueInterestType(string overDueInterestType)
        {
            new SelectElement(this.overDueInterestType).SelectByText(overDueInterestType);
            return this;
        }
        public CreditProductsCreatePage setOverDueInterestRate(string overDueInterestRate)
        {
            this.overdueInterestRate.SendKeys(overDueInterestRate);
            return this;
        }
        public CreditProductsCreatePage setLateGraceDays(string lateGraceDays)
        {
            this.lateGraceDays.SendKeys(lateGraceDays);
            return this;
        }

        public CreditProductsCreatePage setEnableRollover()
        {
           RolloverCheck.Click();
            return this;
        }
       public CreditProductsCreatePage setMinTermRollover(string minTerm)
        {
            minTermRollover.SendKeys(minTerm);
            return this;
        }
        public CreditProductsCreatePage setMaxTermRollover(string maxTerm)
        {
            maxTermRollover.SendKeys(maxTerm);
            return this;
        }
        public CreditProductsCreatePage setMaxAllowedRollover(string maxRollover)
        {
            maxAllowedRollover.SendKeys(maxRollover);
            return this;
        }
        public CreditProductsCreatePage setEnableCollateral()
        {
           CollateralCheck.Click();
            return this;
        }
        public CreditProductsCreatePage setMaxLTV(string MaxLTV)
        {
            maxLTV.SendKeys(MaxLTV);
            return this;
        }
        public void clickOkButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[indi-click=\"submit()\"]")));
            okButton.Click();
        }
        public CreditProductsCreatePage setP2PEnabled()
        {
            P2PEnebled.Click();
            return this;
        }
        public CreditProductsCreatePage setInvestmantInterestRate(string Interest)
        {
            IIR.SendKeys(Interest);
            return this;
        }
        public CreditProductsCreatePage setInvestmantWorkflow(string Workflow)
        {
            new SelectElement(this.WorkflowInvestor).SelectByText(Workflow);
            return this;
        }
    }
   
}
