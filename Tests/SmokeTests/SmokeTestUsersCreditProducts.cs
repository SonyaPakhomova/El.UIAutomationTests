using System;
using System.Collections.Generic;
using Aspose.Cells;
using El.Test.UiTests.Helpers;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace El.Test.UiTests.Tests
{
     
     [TestFixture]
     //[AllureFixture("Description for allure container")]
    class SmokeTestUsersCreditProducts:BaseTest
    {
      
        [Test(Description ="Создание кредитного продукта System - Credit Products(проверка существующего КП) - Удаление КП")]
        //[AllureTest("Создание кредитного продукта System - Credit Products(проверка существующего КП) - Удаление КП")]
        //[Ignore("Закомичен для ускорения сборки")]
        public void Check_Create_Delete_CreditProduct()
        {
            app.Login("AdminLogin");
            app.AllPagesConsist.goToSystemTab();
            app.SystemPage.clickCreditProductTab();
            app.CreateCreditProduct("Automation_Regular_Anuity_Monthly");
            app.DeleteCreditProduct("Automation_Regular_Anuity_Monthly");
            app.Logout();
        }

        [Test(Description = "Создание пользователя System - Users(Проверка существующего пользователя) - Удаление пользователя")]
        //[Ignore("Добавить проверку поиска в многостраничном поиске")]
        public void Check_Create_Delete_User()
        {
            app.Login("AdminLogin");
            app.AllPagesConsist.goToSystemTab();
            app.SystemPage.clickUsersTab();
            if (app.Users.SearchUser("PositiveTest"))
            {
                app.Users.DeleteUser("PositiveTest");
                app.Users.CreateUser("PositiveTest");
                Assert.IsTrue(app.Users.SearchUser("PositiveTest"),"FAIL - Create user");
                app.Users.DeleteUser("PositiveTest");
                Assert.IsFalse(app.Users.SearchUser("PositiveTest"), "FAIL - Delete user");
            }
            else
            {
                app.Users.CreateUser("PositiveTest");
                Assert.IsTrue(app.Users.SearchUser("PositiveTest"), "FAIL - Create user");
                app.Users.DeleteUser("PositiveTest");
                Assert.IsFalse(app.Users.SearchUser("PositiveTest"), "FAIL - Delete user");
            }
            
        }
        [Test(Description = "Проверка наличия всех вкладок на рабочих местах")]
        //[Parallelizable(ParallelScope.Self)]
        [Ignore("В будущем доступность вкладок может начать определяться permission-ами, так что тоже придется переписывать. Я бы не развивал этот тест пока. KDE")]
        public void Check_All_Tabs()
        {
            app.Login("AdminLogin");
            app.AllPagesConsist.goToOriginationPage();
            app.СheckTabs("origination");
            app.AllPagesConsist.goToUnderwritingPage();
            app.СheckTabs("underwriting");
            app.AllPagesConsist.goToServicingPage();
            app.СheckTabs("servicing");
            app.AllPagesConsist.goToCollectionPage();
            app.СheckTabs("collection");
            app.AllPagesConsist.goToArchivePage();
            app.СheckTabs("archive");

        }

        public void ScenarioTest()
        {
            
        }
    }
}
