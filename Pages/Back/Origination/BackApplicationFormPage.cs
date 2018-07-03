using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Back.Origination
{
    class BackApplicationFormPage : Page
    {
        public BackApplicationFormPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "cd.FirstName")]
        private IWebElement firstName;
        [FindsBy(How = How.Id, Using = "cd.MiddleName")]
        private IWebElement middleName;
        [FindsBy(How = How.Id, Using = "cd.LastName")]
        private IWebElement lastName;
        [FindsBy(How = How.Id, Using = "cd.Gender")]
        private IWebElement gender;
        [FindsBy(How = How.Id, Using = "cd.BirthDate_int")]
        private IWebElement dateOfBirth;
        [FindsBy(How = How.Id, Using = "cd.Education")]
        private IWebElement education;
        [FindsBy(How = How.Id, Using = "cd.MaritalStatus")]
        private IWebElement maritalStatus;
        [FindsBy(How = How.Id, Using = "cd.NumberOfDependents")]
        private IWebElement numberOfDependents;
        [FindsBy(How = How.Id, Using = "cd.Email")]
        private IWebElement email;
        [FindsBy(How = How.Id, Using = "cd.Citizenship")]
        private IWebElement citizenship;
        [FindsBy(How = How.Id, Using = "cd.SocialSecurityNumber")]
        private IWebElement ssn;
        [FindsBy(How = How.Id, Using = "cd.GrossMonthlyIncome_int")]
        private IWebElement monthlyIncome;
        [FindsBy(How = How.Id, Using = "cd.GrossMonthlyExpenses_int")]
        private IWebElement monthlyExpenses;
        [FindsBy(How = How.Id, Using = "cd.DriverLicenseID")]
        private IWebElement driverLisense;
        [FindsBy(How = How.Id, Using = "cd.StateOfIssue")]
        private IWebElement stateOfIssue;
        [FindsBy(How = How.Id, Using = "cd.CarOwner")]
        private IWebElement carOwner;
        [FindsBy(How = How.Id, Using = "cd.Phone_int")]
        private IWebElement mainPhone;
        [FindsBy(How = How.Id, Using = "cd.AlternativePhone_int")]
        private IWebElement alternativePhone;
        [FindsBy(How = How.Id, Using = "cd.IncomeType")]
        private IWebElement incomeType;
        [FindsBy(How = How.Id, Using = "cd.HowOftenPaidEmployed")]
        private IWebElement howOftenAreYouPaid;
        [FindsBy(How = How.Id, Using = "cd.Employer")]
        private IWebElement employer;
        [FindsBy(How = How.Id, Using = "cd.SizeCompany")]
        private IWebElement sizeOfTheCompany;
        [FindsBy(How = How.Id, Using = "cd.JobTitle")]
        private IWebElement jobTitle;
        [FindsBy(How = How.Id, Using = "cd.HireDate_int")]
        private IWebElement hireDate;
        [FindsBy(How = How.Id, Using = "cd.EmployeeVerificationPhone_int")]
        private IWebElement employeeVerificationPhone;
        [FindsBy(How = How.Id, Using = "cd.WorkPhone_int")]
        private IWebElement workPhone;
        [FindsBy(How = How.Id, Using = "cd.ResidedAtAddress_years")]
        private IWebElement residentAddressYears;
        [FindsBy(How = How.Id, Using = "cd.ResidedAtAddress_months")]
        private IWebElement residentAddressMonth;
        [FindsBy(How = How.Id, Using = "model.Street")]
        private IWebElement street;
        [FindsBy(How = How.Id, Using = "model.Apartment")]
        private IWebElement apartment;
        [FindsBy(How = How.Id, Using = "model.City")]
        private IWebElement city;
        [FindsBy(How = How.Id, Using = "model.State")]
        private IWebElement state;
        [FindsBy(How = How.Id, Using = "model.ZipCode")]
        private IWebElement zipCode;
        [FindsBy(How = How.Id, Using = "model.ResidentialStatus")]
        private IWebElement residentialStatus;
        [FindsBy(How = How.Id, Using = "model.TypeOfAccount")]
        private IWebElement typeOfAccount;
        [FindsBy(How = How.Id, Using = "model.RoutingNumber")]
        private IWebElement routingNumber;
        [FindsBy(How = How.Id, Using = "model.AccountNumber_int")]
        private IWebElement accountNumber;
        [FindsBy(How = How.Id, Using = "model.TimeWithBankAccount")]
        private IWebElement timeWithBankAccount;
        [FindsBy(How = How.Id, Using = "model.BankName")]
        private IWebElement bankName;
        [FindsBy(How = How.CssSelector, Using = "div.panel-footer > input[ng-click=\"save()\"]")]
        private IWebElement submitApplicationButton;
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/section[1]/elmenu[1]/div[2]/div[1]/ng-view[1]/ng-form[1]/div[1]/div[2]/form[1]/div[1]/fake-customer-details-button[1]/fake-entity-button[1]/button[1]")]
        private IWebElement fakeButton;

        public BackApplicationFormPage setFirstName(string firstName)
        {
            this.firstName.SendKeys(firstName);
            return this;
        }
        public BackApplicationFormPage setMiddleName(string middleName)
        {
            this.middleName.SendKeys(middleName);
            return this;
        }
        public BackApplicationFormPage setLastName(string lastName)
        {
            this.lastName.SendKeys(lastName);
            return this;
        }
        public BackApplicationFormPage setGender(string gender)
        {
            new SelectElement(this.gender).SelectByText(gender);
            return this;
        }
        public BackApplicationFormPage setDateOfBirth(string dob)
        {
            this.dateOfBirth.SendKeys(dob);
            return this;
        }
        public BackApplicationFormPage setEducation(string education)
        {
            new SelectElement(this.education).SelectByText(education);
            return this;
        }
        public BackApplicationFormPage setMaritalStatus(string maritalStatus)
        {
            new SelectElement(this.maritalStatus).SelectByText(maritalStatus);
            return this;
        }
        public BackApplicationFormPage setNumberOfDependents(string numberOfDependens)
        {
            this.numberOfDependents.SendKeys(numberOfDependens);
            return this;
        }
        public BackApplicationFormPage setEmail(string email)
        {
            this.email.SendKeys(email);
            return this;
        }
        public BackApplicationFormPage setCitizenship(string citizenship)
        {
            new SelectElement(this.citizenship).SelectByText(citizenship);
            return this;
        }
        public BackApplicationFormPage setSSN(string ssn)
        {
            this.ssn.Click();
            this.ssn.SendKeys(ssn);
            return this;
        }
        public BackApplicationFormPage setMonthlyIncome(string monthlyIncome)
        {
            this.monthlyIncome.SendKeys(monthlyIncome);
            return this;
        }
        public BackApplicationFormPage setMonthlyExpenses(string monthlyExpenses)
        {
            this.monthlyExpenses.SendKeys(monthlyExpenses);
            return this;
        }
        public BackApplicationFormPage setDriverLicense(string driverLicense)
        {
            this.driverLisense.SendKeys(driverLicense);
            return this;
        }
        public BackApplicationFormPage setStateOfIssue(string stateOfIssue)
        {
            new SelectElement(this.stateOfIssue).SelectByText(stateOfIssue);
            return this;
        }
        public BackApplicationFormPage setCarOwner(string carOwner)
        {
            new SelectElement(this.carOwner).SelectByText(carOwner);
            return this;
        }
        public BackApplicationFormPage setMainPhone(string mainPhone)
        {
            this.mainPhone.SendKeys(mainPhone);
            return this;
        }
        public BackApplicationFormPage setAlternativePhone(string alternativePhone)
        {
            this.alternativePhone.SendKeys(alternativePhone);
            return this;
        }
        public BackApplicationFormPage setIncomeType(string incomeType)
        {
            new SelectElement(this.incomeType).SelectByText(incomeType);
            return this;
        }
        public BackApplicationFormPage setHowOftenAreYouPaid(string howOftenAreYouPaid)
        {
            new SelectElement(this.howOftenAreYouPaid).SelectByText(howOftenAreYouPaid);
            return this;
        }
        public BackApplicationFormPage setEmployer(string employer)
        {
            this.employer.SendKeys(employer);
            return this;
        }
        public BackApplicationFormPage setSizeOfTheCompany(string sizeOfTheCompany)
        {
            this.sizeOfTheCompany.SendKeys(sizeOfTheCompany);
            return this;
        }
        public BackApplicationFormPage setJobTitle(string jobTitle)
        {
            new SelectElement(this.jobTitle).SelectByText(jobTitle);
            return this;
        }
        public BackApplicationFormPage setHireDate(string hireDate)
        {
            this.hireDate.SendKeys(hireDate);
            return this;
        }
        public BackApplicationFormPage setEmployeeVerificationPhone(string employeeVerificationPhone)
        {
            this.employeeVerificationPhone.SendKeys(employeeVerificationPhone);
            return this;
        }
        public BackApplicationFormPage setWorkPhone(string workPhone)
        {
            this.workPhone.SendKeys(workPhone);
            return this;
        }
        public BackApplicationFormPage setResidesAtAddressYear(string residesAtAddressYear)
        {
            new SelectElement(this.residentAddressYears).SelectByText(residesAtAddressYear);
            return this;
        }
        public BackApplicationFormPage setResidesAtaddressMonth(string residesAtAddressMonth)
        {
            new SelectElement(this.residentAddressMonth).SelectByText(residesAtAddressMonth);
            return this;
        }
        public BackApplicationFormPage setStreet(string street)
        {
            this.street.SendKeys(street);
            return this;
        }
        public BackApplicationFormPage setApartment(string apartment)
        {
            this.apartment.SendKeys(apartment);
            return this;
        }
        public BackApplicationFormPage setCity(string city)
        {
            this.city.SendKeys(city);
            return this;
        }
        public BackApplicationFormPage setState(string state)
        {
            new SelectElement(this.state).SelectByText(state);
            return this;
        }
        public BackApplicationFormPage setZipCode(string zipCode)
        {
            this.zipCode.SendKeys(zipCode);
            return this;
        }
        public BackApplicationFormPage setResidentialStatus(string residentialStatus)
        {
            new SelectElement(this.residentialStatus).SelectByText(residentialStatus);
            return this;
        }
        public BackApplicationFormPage setTypeOfAccount(string typeOfAccount)
        {
            new SelectElement(this.typeOfAccount).SelectByText(typeOfAccount);
            return this;
        }
        public BackApplicationFormPage setRoutingNumber(string routingNumber)
        {
            this.routingNumber.SendKeys(routingNumber);
            return this;
        }
        public BackApplicationFormPage setAccountNumber(string accountNumber)
        {
            this.accountNumber.SendKeys(accountNumber);
            return this;
        }
        public BackApplicationFormPage setTimeWithBankAccount(string timeWithBankAccount)
        {
            new SelectElement(this.timeWithBankAccount).SelectByText(timeWithBankAccount);
            return this;
        }
        public BackApplicationFormPage setBankName(string bankName)
        {
            this.bankName.SendKeys(bankName);
            return this;
        }

        public void SubmitApplicationButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(submitApplicationButton));
            submitApplicationButton.Click();
        }

        public BackApplicationFormPage clickFakeButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(fakeButton));
            fakeButton.Click();
            // wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html[1]/body[1]/section[1]/elmenu[1]/div[2]/div[1]/ng-view[1]/ng-form[1]/div[1]/div[3]/input[1]")));
            return this;
        }
    }
}
