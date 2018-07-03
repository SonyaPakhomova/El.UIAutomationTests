using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using El.Test.UiTests.Helpers;
using NUnit.Framework;

namespace El.Test.UiTests.Tests.SmokeTests
{
    [TestFixture]
    class SmokeWorkFlow:BaseTest
    {
        //[OneTimeSetUp]
        public void Create_User_And_CreditProduct()
        {
            Start();
            app.Login("AdminLogin");
            app.AllPagesConsist.goToSystemTab();
            app.SystemPage.clickCreditProductTab();
            app.CreateCreditProduct("Initial");
            app.CreateCreditProduct("Regular_Anuity_Monthly_Collateral");
            app.CreateCreditProduct("Regular_Anuity_Monthly_P2P_FundBeforeDisbursement");
            app.CreateCreditProduct("Regular_Anuity_Monthly_P2P_FundAnyTime");
            app.Logout();
            Quit();
        }
        //[OneTimeTearDown]
        public void Delete_User_And_CreditProduct()
        {
            Start();
            app.Login("AdminLogin");
            app.AllPagesConsist.goToSystemTab();
            app.SystemPage.clickCreditProductTab();
            app.DeleteCreditProduct("Initial");
            app.DeleteCreditProduct("Regular_Anuity_Monthly_Collateral");
            app.DeleteCreditProduct("Regular_Anuity_Monthly_P2P_FundBeforeDisbursement");
            app.DeleteCreditProduct("Regular_Anuity_Monthly_P2P_FundAnyTime");
            app.Logout();
            Quit();
        }
        [Test]
        [Description("CreateLoanFromFront_GoToTheBack_Approve_Repayment_CheckThatLoanInArchiveWithStatusRepayment")]
        //[Ignore("На фронте необходимо отключать капчу в конфиге")]
        public void Check_All_Workflow_From_Front()
        {
            app.Login("AdminLogin");
            app.AllPagesConsist.goToSystemTab();
            app.SystemPage.clickCreditProductTab();
            app.CreateCreditProduct("Automation_Initial");
            //app.CreateCreditProduct("Initial");
            app.Logout();
            app.WelcomePage.Open();
            string loanId = app.CreateLoanFromFront("Automation_Initial");
            app.Logout();
            app.Login("AdminLogin");
            //----Underwriting page---------------
            app.AllPagesConsist.goToUnderwritingPage();
            app.SearchLoan(loanId);
            app.UnderwritingPage.approveButtonClick();
            //app.underwritingPage.confirmApproveButtonClick();
            //-----
            app.AllPagesConsist.goToServicingPage();
            //---Servising Page-------
            app.SearchLoan(loanId);
            //app.servisingPage.selectLoan(loanId);
            if (app.ServisingPage.CheckStatusLoan() == "loanStatus status-Approved")
            {
                app.ServisingPage.DisburseLoan();
                app.waitActiveLoan();
            }
            app.ServisingPage.GoToPaymentTab();
            app.ServisingPage.TimeShiftMonth(6);
            app.ServisingPage.TimeShiftMonth(1);
            app.ServisingPage.Repayment("10000");

            //---Archive Page--------
            app.AllPagesConsist.goToArchivePage();
            app.SearchLoan(loanId);
            Assert.IsTrue(app.ArchivePage.GetStatusLoan() == "loanStatus status-Closed_Repaid");
            app.Logout();
        }

        [Test(Description = "CreateFromBack_Approve_Repayment_ToArchive")]
        //[Ignore("Полный проход заявки реализован в тесте Check_Add_Contact_For_all_Workplace")]
        //[Parallelizable(ParallelScope.Self)]
        public void Check_All_Workflow_From_Back()
        {
            app.Login("AdminLogin");
            app.AllPagesConsist.goToSystemTab();
            app.SystemPage.clickCreditProductTab();
            app.CreateCreditProduct("Automation_Initial");
            //app.CreateCreditProduct("Initial");
            //app.CreateCreditProduct("Initial");
            string loanId = app.CreateLoanFromBack("Automation_Initial");
            app.SearchLoan(loanId);
            app.OriginationPage.sendForApprovalButtonClick();
            //app.originationPage.clickConfirmSendForApprove();
            //---Underwriting Page--------
            app.AllPagesConsist.goToUnderwritingPage();
            app.SearchLoan(loanId);
            app.UnderwritingPage.approveButtonClick();
            //app.underwritingPage.confirmApproveButtonClick();
            //-----
            app.AllPagesConsist.goToServicingPage();
            //---Servising Page-------
            app.SearchLoan(loanId);
            //app.servisingPage.selectLoan(loanId);
            //if (app.servisingPage.CheckStatusLoan() == "Approved")
            if (app.ServisingPage.CheckStatusLoan() == "loanStatus status-Approved")
            {
                app.ServisingPage.DisburseLoan();
                app.waitActiveLoan();
            }
            app.ServisingPage.GoToPaymentTab();
            app.ServisingPage.TimeShiftMonth(6);
            app.ServisingPage.TimeShiftMonth(1);
            app.ServisingPage.Repayment("10000");

            //---Archive Page--------
            app.AllPagesConsist.goToArchivePage();
            app.SearchLoan(loanId);
            Assert.IsTrue(app.ArchivePage.GetStatusLoan() == "loanStatus status-Closed_Repaid");
            app.Logout();
        }

        [Test(Description = "Создание лоана с существующим пользователем с ручным заполнением полей - до архива")]
        //[Ignore("Закомичен для ускорения сборки")]
        public void Check_All_Workflow_From_Back_With_Exicting_User()
        {
            app.Login("AdminLogin");
            app.AllPagesConsist.goToSystemTab();
            app.SystemPage.clickCreditProductTab();
            app.CreateCreditProduct("Automation_Initial");
           //------Создание лоана с бека
            string loanId = app.CreateLoanFromBack("Automation_Initial");
            //Console.WriteLine(loanId);
            //--Запоминаем имя клиента по созданному лоану---
            string FullName = app.GetFullName(loanId);
            app.SearchLoan(loanId);
            app.OriginationPage.sendForApprovalButtonClick();
            //app.originationPage.clickConfirmSendForApprove();
            //Console.WriteLine(FullName);
            //--Создаем лоан по раннее созданному клиенту
            app.AllPagesConsist.goToOriginationPage();
            //List<IWebElement> oldIds = app.GetLoansList();
            //Console.WriteLine(oldIds.Count);
            app.OriginationPage.newApplicationButtonClick();
            app.SetLoanParam.setCreditProduct("Automation_Initial")
                .setLoanAmount("1000")
                .setTerm("6")
                .buttonProcedClick();
            app.CustomerVerificationPage.setSerchByName(FullName);
            app.CustomerVerificationPage.selectButtonClick();
            app.CustomerVerificationPage.useSelectCustomerButtonClick();
            //backApplicationFormPage.clickFakeButton().SubmitApplicationButton();
            //app.SearchLoan(app.GetLoanId());
            //List<IWebElement> newIds = app.GetLoansList();
            //Console.WriteLine(newIds.Count);
            string loanSecond = app.GetLoanId();
            app.SearchLoan(loanSecond);
            //Assert.IsTrue(newIds.Count == oldIds.Count + 1, "Create loan - FAIL");
            app.OriginationPage.sendForApprovalButtonClick();
            //app.originationPage.clickConfirmSendForApprove();
            //---Underwriting Page--------
            app.AllPagesConsist.goToUnderwritingPage();
            app.SearchLoan(loanSecond);
            app.UnderwritingPage.approveButtonClick();
            //app.underwritingPage.confirmApproveButtonClick();
            //-----
            app.AllPagesConsist.goToServicingPage();
            //---Servising Page-------
            app.SearchLoan(loanSecond);
            //app.servisingPage.selectLoan(loanSecond);
            if (app.ServisingPage.CheckStatusLoan() == "loanStatus status-Approved")
            {
                app.ServisingPage.DisburseLoan();
                app.waitActiveLoan();
            }
            app.ServisingPage.GoToPaymentTab();
            app.ServisingPage.TimeShiftMonth(6);
            app.ServisingPage.TimeShiftMonth(1);
            app.ServisingPage.Repayment("10000");

            //---Archive Page--------
            app.AllPagesConsist.goToArchivePage();
            app.SearchLoan(loanSecond);
            Assert.IsTrue(app.ArchivePage.GetStatusLoan() == "loanStatus status-Closed_Repaid");
            app.Logout();

        }
        [Test(Description = "Создание лоана и добавление контактов на всех рабочих местах")]
        //[AllureTest("Создание лоана и добавление контактов на всех рабочих местах")]
        //[Ignore("Отключено для отладки")]
        public void Check_Add_Contact_For_All_Workplace()
        {
            app.Login("AdminLogin");
            app.AllPagesConsist.goToSystemTab();
            app.SystemPage.clickCreditProductTab();
            app.CreateCreditProduct("Automation_Regular_Anuity_Monthly_Collateral");
            //app.CreateCreditProduct("Regular_Anuity_Monthly_Collateral");
            string loanId = app.CreateLoanFromBack("Automation_Regular_Anuity_Monthly_Collateral");
            //app.AllPagesConsist.goToOriginationPage();
            app.SearchLoan(loanId);

            //--Добавление контакта
            app.FillContact("Origination");
            app.OriginationPage.sendForApprovalButtonClick();
            
            //app.originationPage.clickConfirmSendForApprove();
            //---Underwriting Page--------
            app.AllPagesConsist.goToUnderwritingPage();
            app.SearchLoan(loanId);
            app.UnderwritingPage.approveButtonClick();
            //app.underwritingPage.confirmApproveButtonClick();
            //----Collateral Page---------------
            app.AllPagesConsist.goToCollateralPage();
            app.SearchLoan(loanId);
            //app.SelectLoan(loanId);
            app.AddCollateral();
            app.ValuateCollateral();
            app.FillContact("Collateral");
            app.CollateralPage.ClickApprove();
            //-----
            app.AllPagesConsist.goToServicingPage();
            //---Servising Page-------
            app.SearchLoan(loanId);
            //app.servisingPage.selectLoan(loanId);
            if (app.ServisingPage.CheckStatusLoan() == "loanStatus status-Approved")
            {
                app.ServisingPage.DisburseLoan();
                app.waitActiveLoan();
            }
            app.FillContact("Servicing");
            app.ServisingPage.GoToPaymentTab();
            app.ServisingPage.TimeShiftMonth(6);
            //--Collection Page
            app.AllPagesConsist.goToCollectionPage();
            app.SearchLoan(loanId);
            app.FillContact("Collection");
            //-----------------
            //app.AllPagesConsist.goToServicingPage();
            //app.SearchLoan(loanId);
            //app.ServisingPage.GoToPaymentTab();
            app.CollectionPage.TimeShift(1);
            app.CollectionPage.Repayment("10000");

            //---Archive Page--------
            app.AllPagesConsist.goToArchivePage();
            app.SearchLoan(loanId);
            Assert.IsTrue(app.ArchivePage.GetStatusLoan() == "loanStatus status-Closed_Repaid");
            app.Logout();
        }
        [Test(Description = "Проверка добавления параметров лоана в черный список на рабочих местах Underwriting, Servicing, Collection")]
        [Ignore("Добавить проверку и поиск в большом списке в блеклисте")]
        public void Check_Add_To_BlackList_On_All_Workplace()
        {
            app.Login("AdminLogin");
            app.AllPagesConsist.goToSystemTab();
            app.SystemPage.clickCreditProductTab();
            app.CreateCreditProduct("Automation_Initial");
            string loanId = app.CreateLoanFromBack("Automation_Initial");
            app.SearchLoan(loanId);
            app.OriginationPage.sendForApprovalButtonClick();
            //app.originationPage.clickConfirmSendForApprove();
            //-----Underwriting Page------
            app.AllPagesConsist.goToUnderwritingPage();
            app.SearchLoan(loanId);
            app.AddToBlackList("Underwriting", loanId);
            app.AllPagesConsist.goToUnderwritingPage();
            app.SearchLoan(loanId);
            app.UnderwritingPage.approveButtonClick();
            //app.underwritingPage.confirmApproveButtonClick();
            //---ServicingPage-------
            app.AllPagesConsist.goToServicingPage();
            app.SearchLoan(loanId);
            //app.servisingPage.selectLoan(loanId);
            if (app.ServisingPage.CheckStatusLoan() == "loanStatus status-Approved")
            {
                app.ServisingPage.DisburseLoan();
                app.waitActiveLoan();
            }
            app.AddToBlackList("Servicing", loanId);
            app.AllPagesConsist.goToServicingPage();
            app.SearchLoan(loanId);
            app.ServisingPage.GoToPaymentTab();
            app.ServisingPage.TimeShiftMonth(6);
            //--Collection Page
            app.AllPagesConsist.goToCollectionPage();
            app.SearchLoan(loanId);
            app.AddToBlackList("Collection", loanId);
            //-----------------
            app.AllPagesConsist.goToServicingPage();
            app.SearchLoan(loanId);
            app.ServisingPage.GoToPaymentTab();
            app.ServisingPage.TimeShiftMonth(1);
            app.ServisingPage.Repayment("10000");

            //---Archive Page--------
            app.AllPagesConsist.goToArchivePage();
            app.SearchLoan(loanId);
            Assert.IsTrue(app.ArchivePage.GetStatusLoan() == "loanStatus status-Closed_Repaid");
            app.Logout();
        }

        [Test(Description = "Создание кредитного продукта с P2P - выдача - инвестирование и в архив")]
        //[Ignore("Проблема с добавлением нового инвестора на 9288")]
        public void Check_Workflow_With_P2P_FundBeforeDisbursmant()
        {
            app.Login("AdminLogin");
            app.AllPagesConsist.goToSystemTab();
            app.SystemPage.clickCreditProductTab();
            app.CreateCreditProduct("Automation_Regular_Anuity_Monthly_P2P_FundBeforeDisbursement");
            app.AllPagesConsist.goToOriginationPage();
            string loanId = app.CreateLoanFromBack("Automation_Regular_Anuity_Monthly_P2P_FundBeforeDisbursement");
            app.SearchLoan(loanId);
            Console.WriteLine("Лоан " + loanId + " создан!!!");
            app.OriginationPage.sendForApprovalButtonClick();
            //---Underwriting Page--------
            app.AllPagesConsist.goToUnderwritingPage();
            app.SearchLoan(loanId);
            app.UnderwritingPage.approveButtonClick();
            //app.underwritingPage.confirmApproveButtonClick();
            app.Logout();
            //----Investor Front ------
            app.Login("InvestorLogin1");
            app.InvestorBid("1000", loanId);
            app.Logout();
            app.Login("AdminLogin");
            //-----
            app.AllPagesConsist.goToServicingPage();
            //---Servising Page-------
            app.SearchLoan(loanId);
            //app.servisingPage.selectLoan(loanId);
            if (app.ServisingPage.CheckStatusLoan() == "loanStatus status-Approved")
            {
                app.ServisingPage.DisburseLoan();
                app.waitActiveLoan();
            }
            app.ServisingPage.GoToPaymentTab();
            app.ServisingPage.TimeShiftMonth(6);
            app.ServisingPage.TimeShiftMonth(1);
            app.ServisingPage.Repayment("10000");

            //---Archive Page--------
            app.AllPagesConsist.goToArchivePage();
            app.SearchLoan(loanId);
            Assert.IsTrue(app.ArchivePage.GetStatusLoan() == "loanStatus status-Closed_Repaid");
            app.Logout();
        }
        [Test(Description = "Создание кредитного продукта с P2P - выдача - инвестирование и в архив")]
        //[Ignore("Проблема с добавлением нового инвестора на 9288")]
        public void Check_Workflow_With_P2P_FundAnytime()
        {
            app.Login("AdminLogin");
            app.AllPagesConsist.goToSystemTab();
            app.SystemPage.clickCreditProductTab();
            app.CreateCreditProduct("Automation_Regular_Anuity_Monthly_P2P_FundAnyTime");
            app.CreateNewInvestor("Investor1");
            app.AllPagesConsist.goToOriginationPage();
            string loanId = app.CreateLoanFromBack("Automation_Regular_Anuity_Monthly_P2P_FundAnyTime");
            app.SearchLoan(loanId);
            Console.WriteLine("Лоан " + loanId + "создан!!!");
            app.OriginationPage.sendForApprovalButtonClick();
            //---Underwriting Page--------
            app.AllPagesConsist.goToUnderwritingPage();
            app.SearchLoan(loanId);
            app.UnderwritingPage.approveButtonClick();
            //app.underwritingPage.confirmApproveButtonClick();
            app.Logout();
            //string loanId = "11119";
            //----Investor Front ------
            app.Login("InvestorLogin1");
            app.InvestorBid("1000", loanId);
            app.Logout();
            app.Login("AdminLogin");
            //-----
            app.AllPagesConsist.goToServicingPage();
            //---Servising Page-------
            app.SearchLoan(loanId);
            //app.servisingPage.selectLoan(loanId);
            if (app.ServisingPage.CheckStatusLoan() == "loanStatus status-Approved")
            {
                app.ServisingPage.DisburseLoan();
                app.waitActiveLoan();
            }
            app.ServisingPage.GoToPaymentTab();
            app.ServisingPage.TimeShiftMonth(6);
            app.ServisingPage.TimeShiftMonth(1);
            app.ServisingPage.Repayment("10000");

            //---Archive Page--------
            app.AllPagesConsist.goToArchivePage();
            app.SearchLoan(loanId);
            Assert.IsTrue(app.ArchivePage.GetStatusLoan() == "loanStatus status-Closed_Repaid");
            app.Logout();
        }
    }
}
