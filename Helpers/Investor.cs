using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using El.Test.UiTests.Modules;
using El.Test.UiTests.Pages.Back.System.Users.Investors;
using OpenQA.Selenium;

namespace El.Test.UiTests.Helpers
{
    class Investor
    {
        private Application app;
        public Investor(Application app)
        {
            this.app = app;
        }

        public void CreateInvestor(string testName)
       {
          var InvestorData = ExcelDataAccess.GetInvestorData(testName, "Investor");
            app.InvestorPage.SetSearchInvestor(InvestorData.Email);
           if (app.InvestorPage.IsInvestorExist() == false)
            {
                app.InvestorPage.CreateInvestorClick();
                app.InvestorPage.SetInvestorEmail(InvestorData.Email)
                    .SetInvestorPassword(InvestorData.Password)
                    .SetInvestorConfirmPassword(InvestorData.ConfirmPassword)
                    .SetInvestorFullName(InvestorData.FullName)
                    .SetInvestorPhone(InvestorData.Phone)
                    .SetInvestorBalance(InvestorData.Balance)
                    .ClickOk();
            }
        }
       /* public void DeleteInvestor(string testName)
        {
            var InvestorData = ExcelDataAccess.GetInvestorData(testName, "Investor");
            app.searchUserFill(InvestorData.Email)
                .selectUserCheck()
                .deteteUSerButtonClick();
            app.systemPage.successDeleteUser();
            app.systemPage.searchUserFill("");
        }*/
    }
}
