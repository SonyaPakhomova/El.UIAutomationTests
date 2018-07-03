using NUnit.Framework;

namespace El.Test.UiTests.Tests
{
    [TestFixture]
    [Ignore("Используется для создания заявок на разных рабочих местах")]
    class DemoTest:BaseTest
    {
        //public void
        public string LoanOnOriginationPage()
        {
           app.AllPagesConsist.goToOriginationPage();
            string loanId = app.CreateLoanFromBack("Initial");
            return loanId;
        }
        public void LoanOnUnderwriting(string loanId)
        {
            app.AllPagesConsist.goToOriginationPage();
            app.SearchLoan(loanId);
            app.OriginationPage.sendForApprovalButtonClick();
            app.OriginationPage.clickConfirmSendForApprove();
            app.AllPagesConsist.goToUnderwritingPage();
            app.SearchLoan(loanId);
        }
        public void LoanOnServicingPage(string loanId)
        {
            app.AllPagesConsist.goToUnderwritingPage();
            app.SearchLoan(loanId);
            app.UnderwritingPage.approveButtonClick();
            app.UnderwritingPage.confirmApproveButtonClick();
            app.AllPagesConsist.goToServicingPage();
            app.SearchLoan(loanId);
            if (app.ServisingPage.CheckStatusLoan() == "loanStatus status-Approved")
            {
                app.ServisingPage.DisburseLoan();
                app.waitActiveLoan();
            }
        }
        public void LoanOnCollectionPage(string loanId)
        {
            app.AllPagesConsist.goToServicingPage();
            app.SearchLoan(loanId);
            app.ServisingPage.TimeShiftMonth(6);
            app.AllPagesConsist.goToCollectionPage();
            app.SearchLoan(loanId);
        }
        public void LoanOnArchivePage(string loanId)
        {
            app.AllPagesConsist.goToServicingPage();
            app.SearchLoan(loanId);
            app.ServisingPage.TimeShiftMonth(1);
            app.ServisingPage.Repayment("10000");
            app.AllPagesConsist.goToArchivePage();
            app.SearchLoan(loanId);
            Assert.IsTrue(app.ArchivePage.GetStatusLoan() == "loanStatus status-Closed_Repaid");
        }
        public void Create_Loan_On_Diferent_Workplace(string workplace)
        {
           switch (workplace)
                {
                    case "Origination":
                    {
                        LoanOnOriginationPage();
                        break;
                    }
                    case "Underwriting":
                    {
                        string loanId = LoanOnOriginationPage();
                        LoanOnUnderwriting(loanId);
                        break;
                    }
                    case "Servicing":
                    {
                      string loanId = LoanOnOriginationPage();
                      LoanOnUnderwriting(loanId);
                      LoanOnServicingPage(loanId);
                      break;
                    }
                    case "Collection":
                    {
                        string loanId = LoanOnOriginationPage();
                        LoanOnUnderwriting(loanId);
                        LoanOnServicingPage(loanId);
                        LoanOnCollectionPage(loanId);
                        break;
                    }
                    case "Archive":
                    {
                        string loanId = LoanOnOriginationPage();
                        LoanOnUnderwriting(loanId);
                        LoanOnServicingPage(loanId);
                        LoanOnCollectionPage(loanId);
                        LoanOnArchivePage(loanId);
                        break;
                    }
             }
        }

        [Test]
        public void CreateLoan()
        {
            app.Login("AdminLogin");
            app.CreateCreditProduct("Initial");
            for (int i = 0; i < 2; i++)
            {
                Create_Loan_On_Diferent_Workplace("Underwriting");
            }
        }

    }
}
