using System.Threading;
using NUnit.Framework;

namespace El.Test.UiTests.Tests
{
    [TestFixture]
    [Ignore("Тесты перенесены в смоук, пока не разрабатываются")]
    class RegressionTest : BaseTest
    {

        [Test]
        [Description("Создание кредитного продукта с коллатеролом")]
        public void TestCreateCreditProductWithCollateral()
        {
            app.Login("AdminLogin");
            app.CreateCreditProduct("Regular_Anuity_Monthly_Collateral");
            
            
        }
        [Test]
        [Description("Создание лоана с коллатеролом")]
        public void TestCreateLoanWithCollateral()
        {
            TestCreateCreditProductWithCollateral();
            app.CreateLoanFromBack("Regular_Anuity_Monthly_Collateral");
        }

        [Test]
        [Ignore("")]
        public void TestAddCollateral()
        {
            TestCreateLoanWithCollateral();
            app.OriginationPage.sendForApprovalButtonClick();
            app.AllPagesConsist.goToUnderwritingPage();
            app.UnderwritingPage.approveButtonClick();
        }

        [Test]
        public void TestAddContact()
        {
            app.Login("AdminLogin");
            string loanid = app.CreateLoanFromBack("Regular_Anuity_Monthly_Collateral");
            Thread.Sleep(3000);
            //app.originationPage.AddContact();
            app.FillContact("Origination");
        }

        [Test]
        public void TestAddBlacklist()
        {
            app.Login("AdminLogin");
            string loanid=app.CreateLoanFromBack("Regular_Anuity_Monthly_Collateral");
            //Console.WriteLine(loanid);
            app.OriginationPage.sendForApprovalButtonClick();
            //Thread.Sleep(2000);
            app.OriginationPage.clickConfirmSendForApprove();
            //Thread.Sleep(2000);
            //app.AddToBlackList(loanid);
           
        }

        /*[Test]
        public void TestLogin([Values("CorrectLogin", "IncorrectLogin", "AdminLogin")] string key)
        {
            app.login(key);
        }*/
        [Test]
        public void TestCorrectLogin()
        {
            app.Login("CorrectLogin");
        }
        [Test]
        public void TestIncorrectLogin()
        {
            app.Login("IncorrectLogin");
        }
        [Test]
        public void TestAdminLogin()
        {
            app.Login("AdminLogin");
        }
    }
}
