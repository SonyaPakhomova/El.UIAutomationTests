using El.Test.UiTests.Modules;
using El.Test.UiTests.Pages;
using OpenQA.Selenium;

namespace El.Test.UiTests.Helpers
{
    
    public class Login
    {
        private LoginPage loginPage;
        private IWebDriver driver;
        private Application app;
        //private Application app;

        public Login(Application app)
        {
            this.app = app;
        }

        public void LoginAs(string testName)
        {
            var userData = ExcelDataAccess.GetLoginData(testName,"Login");
            loginPage.open()
                     .setLogin(userData.Username)
                     .setPassword(userData.Password)
                     .clickSubmit();
        }

        public string GetMessage()
        {
            return driver.FindElement(By.CssSelector("section#loginForm div.validation-summary-errors ul li")).Text;
        }
    }
}
