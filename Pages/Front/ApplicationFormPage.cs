using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Front
{
    class ApplicationFormPage:Page
    {
        public ApplicationFormPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver,this);
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
        [FindsBy(How = How.XPath, Using = "//div[3]/button")]
        private IWebElement submitApplicationButton;
        [FindsBy(How = How.CssSelector, Using = "fake-entity-button > button")]
        private IWebElement fakeButton;

        public ApplicationFormPage setFirstName(string firstName)
        {
            this.firstName.SendKeys(firstName);
            return this;
        }
        public ApplicationFormPage setMiddleName(string middleName)
        {
            this.middleName.SendKeys(middleName);
            return this;
        }
        public ApplicationFormPage setLastName(string lastName)
        {
            this.lastName.SendKeys(lastName);
            return this;
        }
        public ApplicationFormPage setGender(string gender)
        {
            new SelectElement(this.gender).SelectByText(gender);
            return this;
        }
        public ApplicationFormPage setDateOfBirth(string dob)
        {
            this.dateOfBirth.SendKeys(dob);
            return this;
        }
        public ApplicationFormPage setEducation(string education)
        {
            new SelectElement(this.education).SelectByText(education);
            return this;
        }
        public ApplicationFormPage setMaritalStatus(string maritalStatus)
        {
            new SelectElement(this.maritalStatus).SelectByText(maritalStatus);
            return this;
        }
        public ApplicationFormPage setNumberOfDependents(string numberOfDependens)
        {
            this.numberOfDependents.SendKeys(numberOfDependens);
            return this;
        }
        public ApplicationFormPage setEmail(string email)
        {
            this.email.SendKeys(email);
            return this;
        }
        public ApplicationFormPage setCitizenship(string citizenship)
        {
            new SelectElement(this.citizenship).SelectByText(citizenship);
            return this;
        }
        public ApplicationFormPage setSSN(string ssn)
        {
            this.ssn.Click();
            this.ssn.SendKeys(ssn);
            return this;
        }
        public ApplicationFormPage setMonthlyIncome(string monthlyIncome)
        {
            this.monthlyIncome.SendKeys(monthlyIncome);
            return this;
        }
        public ApplicationFormPage setMonthlyExpenses(string monthlyExpenses)
        {
            this.monthlyExpenses.SendKeys(monthlyExpenses);
            return this;
        }
        public ApplicationFormPage setDriverLicense(string driverLicense)
        {
            this.driverLisense.SendKeys(driverLicense);
            return this;
        }
        public ApplicationFormPage setStateOfIssue(string stateOfIssue)
        {
            new SelectElement(this.stateOfIssue).SelectByText(stateOfIssue);
            return this;
        }
        public ApplicationFormPage setCarOwner(string carOwner)
        {
            new SelectElement(this.carOwner).SelectByText(carOwner);
            return this;
        }
        public ApplicationFormPage setMainPhone(string mainPhone)
        {
            this.mainPhone.SendKeys(mainPhone);
            return this;
        }
        public ApplicationFormPage setAlternativePhone(string alternativePhone)
        {
            this.alternativePhone.SendKeys(alternativePhone);
            return this;
        }
        public ApplicationFormPage setIncomeType(string incomeType)
        {
            new SelectElement(this.incomeType).SelectByText(incomeType);
            return this;
        }
        public ApplicationFormPage setHowOftenAreYouPaid(string howOftenAreYouPaid)
        {
            new SelectElement(this.howOftenAreYouPaid).SelectByText(howOftenAreYouPaid);
            return this;
        }
        public ApplicationFormPage setEmployer(string employer)
        {
            this.employer.SendKeys(employer);
            return this;
        }
        public ApplicationFormPage setSizeOfTheCompany(string sizeOfTheCompany)
        {
            this.sizeOfTheCompany.SendKeys(sizeOfTheCompany);
            return this;
        }
        public ApplicationFormPage setJobTitle(string jobTitle)
        {
            new SelectElement(this.jobTitle).SelectByText(jobTitle);
            return this;
        }
        public ApplicationFormPage setHireDate(string hireDate)
        {
            this.hireDate.SendKeys(hireDate);
            return this;
        }
        public ApplicationFormPage setEmployeeVerificationPhone(string employeeVerificationPhone)
        {
            this.employeeVerificationPhone.SendKeys(employeeVerificationPhone);
            return this;
        }
        public ApplicationFormPage setWorkPhone(string workPhone)
        {
            this.workPhone.SendKeys(workPhone);
            return this;
        }
        public ApplicationFormPage setResidesAtAddressYear(string residesAtAddressYear)
        {
            new SelectElement(this.residentAddressYears).SelectByText(residesAtAddressYear);
            return this;
        }
        public ApplicationFormPage setResidesAtaddressMonth(string residesAtAddressMonth)
        {
            new SelectElement(this.residentAddressMonth).SelectByText(residesAtAddressMonth);
            return this;
        }
        public ApplicationFormPage setStreet(string street)
        {
            this.street.SendKeys(street);
            return this;
        }
       public ApplicationFormPage setApartment(string apartment)
        {
            this.apartment.SendKeys(apartment);
            return this;
        }
        public ApplicationFormPage setCity(string city)
        {
            this.city.SendKeys(city);
            return this;
        }
        public ApplicationFormPage setState(string state)
        {
            new SelectElement(this.state).SelectByText(state);
            return this;
        }
        public ApplicationFormPage setZipCode(string zipCode)
        {
            this.zipCode.SendKeys(zipCode);
            return this;
        }
        public ApplicationFormPage setResidentialStatus(string residentialStatus)
        {
            new SelectElement(this.residentialStatus).SelectByText(residentialStatus);
            return this;
        }
        public ApplicationFormPage setTypeOfAccount(string typeOfAccount)
        {
            new SelectElement(this.typeOfAccount).SelectByText(typeOfAccount);
            return this;
        }
        public ApplicationFormPage setRoutingNumber(string routingNumber)
        {
            this.routingNumber.SendKeys(routingNumber);
            return this;
        }
        public ApplicationFormPage setAccountNumber(string accountNumber)
        {
            this.accountNumber.SendKeys(accountNumber);
            return this;
        }
        public ApplicationFormPage setTimeWithBankAccount(string timeWithBankAccount)
        {
            new SelectElement(this.timeWithBankAccount).SelectByText(timeWithBankAccount);
            return this;
        }
        public ApplicationFormPage setBankName(string bankName)
        {
            this.bankName.SendKeys(bankName);
            return this;
        }

        public void SubmitApplicationButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(submitApplicationButton));
            submitApplicationButton.Click();
        }

        public ApplicationFormPage clickFakeButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(fakeButton));
            fakeButton.Click();
            return this;
        }
    }
}
