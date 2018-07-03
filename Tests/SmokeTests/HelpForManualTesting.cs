using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace El.Test.UiTests.Tests.SmokeTests
{
    [TestFixture]
    class HelpForManualTesting:BaseTest
    {
        [Test]
        public void CreateCreditProduct()
        {
            app.Login("AdminLogin");
            app.AllPagesConsist.goToSystemTab();
            app.SystemPage.clickCreditProductTab();
            app.CreateCreditProduct("Automation_Regular_Anuity_Monthly");
            app.Logout();
        }
    }
}
