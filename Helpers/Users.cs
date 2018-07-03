using El.Test.UiTests.Modules;

namespace El.Test.UiTests.Helpers
{
    class Users
    {
        private Application app;

        public Users(Application app)
        {
            this.app = app;
        }
        public void CreateUser(string testName)
        {
            var userData = ExcelDataAccess.GetUserData(testName, "User");
            app.SystemPage.addUserButtonClick();
                app.UsersPage.setUserlogin(userData.UserLogin)
                    .setUserPassword(userData.UserPassword)
                    .setUserFirstName(userData.FirstName)
                    .setUserLastName(userData.LastName)
                    .setUserEmail(userData.Email)
                    .setUserPhone(userData.Phone)
                    .setUserRoleAdmin()
                    .setUserRoleCollateralManager()
                    .setUserRoleCollector()
                    .setUserRoleLoanManager()
                    .setUserRoleOriginator()
                    .setUserRoleSupervisor()
                    .setUserRoleUnderwriter()
                    .clickBtnOk();
        }
        public void DeleteUser(string testName)
        {
            var userData = ExcelDataAccess.GetUserData(testName, "User");
            app.SystemPage.searchUserFill(userData.UserLogin)
                .selectUserCheck()
                .deteteUSerButtonClick();
            app.SystemPage.successDeleteUser();
            app.SystemPage.searchUserFill("");
        }

        public bool SearchUser(string testName)
        {
            var userData = ExcelDataAccess.GetUserData(testName, "User");
            app.UsersPage.setSerchUser(userData.UserLogin);
            if (app.UsersPage.IsUserExist() == true) { app.UsersPage.setSerchUser(""); return true;}
            else { app.UsersPage.setSerchUser(""); return false;}
        }
    }
}
