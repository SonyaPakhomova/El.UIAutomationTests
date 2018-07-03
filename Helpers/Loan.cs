using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Helpers
{
    class Loan
    {
        private Application app;

        public Loan(Application app)
        {
            this.app = app;
        }
        public void createLoanFromFront()
        {
            /*applicationFormPage.setFirstName("Alex")
                               .setMiddleName("Test")
                               .setLastName("Test")
                               .setGender("Male")
                               .setDateOfBirth("01.01.1985")
                               .setEducation("Graduate")
                               .setMaritalStatus("Married")
                               .setNumberOfDependents("1")
                               //.setEmail("first@user.ua")
                               .setCitizenship("US Citizen")
                               .setSSN("123-45-6789")
                               .setMonthlyIncome("10000")
                               .setMonthlyExpenses("1000")
                               .setDriverLicense("Test")
                               .setMainPhone("1234567890")
                               .setIncomeType("Employed")
                               .setHowOftenAreYouPaid("Weekly")
                               .setEmployer("test")
                               .setSizeOfTheCompany("25")
                               .setJobTitle("Upper Manager")
                               .setHireDate("01.01.2000")
                               .setEmployeeVerificationPhone("1234567890")
                               .setWorkPhone("1234567890")
                               .setResidesAtAddressYear("4")
                               .setResidesAtaddressMonth("2")
                               .setStreet("test")
                               .setApartment("2")
                               .setCity("test")
                               .setState("Alabama")
                               .setZipCode("12345")
                               .setResidentialStatus("Own")
                               .setTypeOfAccount("Cheking")
                               .setRoutingNumber("1234567890")
                               .setAccountNumber("123456789123456789")
                               .setTimeWithBankAccount("Month")
                               .setBankName("test")
                               .SubmitApplicationButton();*/
            app.ApplicationFormPage.clickFakeButton()
                .SubmitApplicationButton();
            app.wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(
                "html > body > section > ng-view > div > div > div > div > div:nth-of-type(3) > div > div > div > div > h2")));
        }
        public void FillApplicationForm(string key)
        {
            if (key == "Fake")
            {
                int i = 0;
                app.BackApplicationFormPage.clickFakeButton();
                Console.WriteLine(app.driver.FindElement(By.CssSelector("ng-form[name=\"customerDetails\"]")).GetAttribute("class"));
                while(app.driver.FindElement(By.CssSelector("ng-form[name=\"customerDetails\"]")).GetAttribute("class")
                    .Contains("ng-invalid"))
                {
                    i++;
                    Console.WriteLine("True");
                    app.BackApplicationFormPage.clickFakeButton();
                    if (i > 3) break;
                }
                /*try
                {
                    ExpectedConditions.ElementToBeClickable(app.driver.FindElement(By.CssSelector("input[ng-click=\"save()\"]")));
                }
                catch(Exception e)
                {
                    app.BackApplicationFormPage.clickFakeButton();
                }*/
            }
            else if (key == "Real")
            {
                app.BackApplicationFormPage.setFirstName("Alex")
                    .setMiddleName("Test")
                    .setLastName("Test")
                    .setGender("Male")
                    .setDateOfBirth("01.01.1985")
                    .setEducation("Graduate")
                    .setMaritalStatus("Married")
                    .setNumberOfDependents("1")
                    .setEmail(System.DateTime.Now.ToString("yyMMddHmmss") + "@user.ua")
                    .setCitizenship("US Citizen")
                    .setSSN("123-45-6789")
                    .setMonthlyIncome("10000")
                    .setMonthlyExpenses("1000")
                    .setDriverLicense("Test")
                    .setMainPhone("1234567890")
                    .setIncomeType("Employed")
                    .setHowOftenAreYouPaid("Weekly")
                    .setEmployer("test")
                    .setSizeOfTheCompany("25")
                    .setJobTitle("Upper Manager")
                    .setHireDate("01.01.2000")
                    .setEmployeeVerificationPhone("1234567890")
                    .setWorkPhone("1234567890")
                    .setResidesAtAddressYear("4")
                    .setResidesAtaddressMonth("2")
                    .setStreet("test")
                    .setApartment("2")
                    .setCity("test")
                    .setState("Alabama")
                    .setZipCode("12345")
                    .setResidentialStatus("Own")
                    .setTypeOfAccount("Cheking")
                    .setRoutingNumber("1234567890")
                    .setAccountNumber("123456789123456789")
                    .setTimeWithBankAccount("Month")
                    .setBankName("test")
                    .SubmitApplicationButton();
            }
            //Thread.Sleep(5000);
            app.BackApplicationFormPage.SubmitApplicationButton();
        }
        public void chooseLoanParamsFromFront()
        {
            app.WelcomePage.Open()
                .setLoanType("Initial")
                .setLoanAmount("1000")
                .setLoanTerm("6")
                .ApplyClick();
        }
    }
}
