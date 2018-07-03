using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using El.Test.UiTests.Tests;
using NUnit.Framework;

namespace El.Test.UiTests.Modules
{
    [SetUpFixture]
    class SetUpClass:BaseTest
    {
        //[OneTimeSetUp]
        public void Create_User_And_CreditProduct()
        {
            app.Login("AdminLogin");
            app.CreateCreditProduct("Initial");
            app.CreateCreditProduct("Regular_Anuity_Monthly_Collateral");
            app.CreateCreditProduct("Regular_Anuity_Monthly_P2P");
            app.CreateCreditProduct("Regular_Anuity_Monthly_P2P_FundAnyTime");
        }
    }
}
