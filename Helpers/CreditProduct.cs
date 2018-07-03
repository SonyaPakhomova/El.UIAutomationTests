using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using El.Test.UiTests.Modules;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Helpers
{
    class CreditProduct
    {
        private Application app;
        public CreditProduct(Application app)
        {
            this.app = app;
        }
        public void CreateCreditProduct(string testName)
        {
            app.CreditProductPage.createCreaditProductClick();
            var userData = ExcelDataAccess.GetCreditProductData(testName, "CreditProduct");
            app.CreditProductCreatePage.setName(userData.Name)
                .setLoanType(userData.LoanType)
                .setTypeofCalculation(userData.TypeOfCalculation)
                .setPeriodicity(userData.Periodicity)
                .setMinAmount(userData.MinAmount)
                .setMaxAmount(userData.MaxAmount)
                .setMinTerm(userData.MinTerm)
                .setMaxTerm(userData.MaxTerm)
                .setInterestRate(userData.Interest)
                .setToleranceWriteOff(userData.TWO)
                .setOverDueInterestType(userData.OverdueInterestType)
                .setOverDueInterestRate(userData.OverdueInterestRate)
                .setLateGraceDays(userData.LateGraceDays);
            if (userData.P2Ploan == true)
            {
                app.CreditProductCreatePage.setP2PEnabled()
                    .setInvestmantInterestRate(userData.IIR)
                    .setInvestmantWorkflow(userData.Workflow);
            }
            if (userData.EnableRollover == true)
            {
                app.CreditProductCreatePage.setEnableRollover()
                    .setMinTermRollover(userData.MinTermRollover)
                    .setMaxTermRollover(userData.MaxTermRollover)
                    .setMaxAllowedRollover(userData.MaxAllowedRollover);
            }
            if (userData.UseCollateral == true)
            {
                app.CreditProductCreatePage.setEnableCollateral()
                    .setMaxLTV(userData.MaxLTV);
            }
            app.CreditProductCreatePage.clickOkButton();
            //wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button[ng-click =\"addNewEntry()\"]")));
        }
        public void DeleteCreditProduct(string testName)
        {
            var userData = ExcelDataAccess.GetCreditProductData(testName, "CreditProduct");
            app. CreditProductPage.setSearchField(userData.Name).checkCreditProductClick();
            app.wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[ng-click=\"deleteItems()\"]")));
            app.CreditProductPage.deleteCreaditProductClick();
            app.CreditProductPage.approveDeleteCpClick();
            //Thread.Sleep(2000);
            app.CreditProductPage.setSearchField("");
        }
        public bool SearchCreditProduct(string testName)
        {
            var UserData = ExcelDataAccess.GetCreditProductData(testName, "CreditProduct");
            app.CreditProductPage.setSearchField(UserData.Name);
            if (app.CreditProductPage.IsCreditProductExistInGrid() == true) { app.CreditProductPage.setSearchField(""); return true; }
            else { app.CreditProductPage.setSearchField(""); return false; }
        }
    }
}
