using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace El.Test.UiTests.Pages.Back.System.Users.Internal_Users
{
    internal class UsersPage : Page
    {
        public UsersPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "user.UserName")]
        private IWebElement login;
        [FindsBy(How = How.Id, Using = "user.Password")]
        private IWebElement password;
        [FindsBy(How = How.Id, Using = "user.FirstName")]
        private IWebElement firstName;
        [FindsBy(How = How.Id, Using = "user.LastName")]
        private IWebElement lastName;
        [FindsBy(How = How.Id, Using = "user.Email")]
        private IWebElement email;
        [FindsBy(How = How.Id, Using = "user.PhoneNumber_int")]
        private IWebElement phone;
        [FindsBy(How = How.XPath, Using = "//form[@name=\"editUser\"]/div[2]/roles-editor[1]/div[1]/div[2]/div[1]/div[1]/div[1]/label[1]/input[1]")]
        private IWebElement roleAdmin;
        [FindsBy(How = How.XPath, Using = "//form[@name=\"editUser\"]/div[2]/roles-editor[1]/div[1]/div[2]/div[1]/div[2]/div[1]/label[1]/input[1]")]
        private IWebElement roleCollateralManager;
        [FindsBy(How = How.XPath, Using = "//form[@name=\"editUser\"]/div[2]/roles-editor[1]/div[1]/div[2]/div[1]/div[3]/div[1]/label[1]/input[1]")]
        private IWebElement roleCollector;
        [FindsBy(How = How.XPath, Using = "//form[@name=\"editUser\"]/div[2]/roles-editor[1]/div[1]/div[2]/div[1]/div[4]/div[1]/label[1]/input[1]")]
        private IWebElement roleLoanManager;
        [FindsBy(How = How.XPath, Using = "//form[@name=\"editUser\"]/div[2]/roles-editor[1]/div[1]/div[2]/div[1]/div[5]/div[1]/label[1]")]
        private IWebElement roleOriginator;
        [FindsBy(How = How.XPath, Using = "//form[@name=\"editUser\"]/div[2]/roles-editor[1]/div[1]/div[2]/div[1]/div[6]/div[1]/label[1]/input[1]")]
        private IWebElement roleSupervisor;
        [FindsBy(How = How.XPath, Using = "//form[@name=\"editUser\"]/div[2]/roles-editor[1]/div[1]/div[2]/div[1]/div[7]/div[1]/label[1]")]
        private IWebElement roleUnderwriter;
        [FindsBy(How = How.XPath, Using = "//form[@name=\"editUser\"]/div[3]/div[2]/div[1]/div[1]/branch-office-select[1]/div[1]/div[1]/div[1]/span[1]")]
        private IWebElement branch;
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div[1]/div[1]/div[3]/button[1]")]
        private IWebElement btnOk;
        [FindsBy(How = How.CssSelector, Using = ".modal-footer button[ng-click=\"cancel()\"]")]
        private IWebElement btnCancel;
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div[1]/div[1]/div[1]/h2[1]")]
        private IWebElement LabelAddUser;
        [FindsBy(How = How.CssSelector, Using = "button.btn.btn-default")]
        private IWebElement btnCloseIfUserExist;
        [FindsBy(How = How.CssSelector, Using = "html > body > div > div > div > div:nth-of-type(2) > form > div > strong")]
        private IWebElement lableIfUserExist;
        [FindsBy(How = How.CssSelector, Using = "div.modal-header h2")]
        private IWebElement lableEditUser;
        [FindsBy(How = How.CssSelector, Using = "li[heading=\"Internal Users\"] a")]
        private IWebElement InternalUsersTab;
        [FindsBy(How = How.CssSelector, Using = "li[heading=\"Investors\"] a")]
        private IWebElement InvestorsTab;

        [FindsBy(How = How.CssSelector,
        Using = "div[id = \"application-user-list\"] button[ng-click=\"remove()\"]")]
        public IWebElement deleteUser;

        [FindsBy(How = How.CssSelector, Using = "div[id = \"application-user-list\"] input[placeholder=\"Search\"]")]
        private IWebElement findUser;

        [FindsBy(How =How.XPath, Using = "id(\"cb_usersGrid_grid\")")]
        public IWebElement chooseUser;

        [FindsBy(How = How.CssSelector, Using = "button[ng-click=\"$close(comment)\"]")]
        public IWebElement approveDeleteUser;
        //@Step("Вводим логин юзера")
        public UsersPage setUserlogin(String flogin)
        {
            login.Clear();
            login.SendKeys(flogin);
            return this;
        }//@Step("Вводим пароль юзера")
        public UsersPage setUserPassword(String fPassword)
        {
            password.Clear();
            password.SendKeys(fPassword);
            return this;
        }
//@Step("Вводим имя юзера")
public UsersPage setUserFirstName(String fFirstName)
        {
            firstName.Clear();
            firstName.SendKeys(fFirstName);
            return this;
        }
//@Step("Вводим фамилию юзера")
public UsersPage setUserLastName(String fLastName)
        {
            lastName.Clear();
            lastName.SendKeys(fLastName);
            return this;
        }
//@Step("Вводим емаил юзера")
public UsersPage setUserEmail(String fEmail)
        {
            email.Clear();
            email.SendKeys(fEmail);
            return this;
        }
//@Step("Вводим телефон юзера")
public UsersPage setUserPhone(String fPhone)
        {
            phone.Clear();
            phone.SendKeys(fPhone);
            return this;
        }
//@Step("Устанавливаем роль админ")
public UsersPage setUserRoleAdmin()
        {
            roleAdmin.Click();
            return this;
        }
//@Step("Устанавливаем роль колатерал")
public UsersPage setUserRoleCollateralManager()
        {
            roleCollateralManager.Click();
            return this;
        }
//@Step("Устанавливаем роль колектор")
public UsersPage setUserRoleCollector()
        {
            roleCollector.Click();
            return this;
        }
//@Step("Устанавливаем роль лоан менеджер")
public UsersPage setUserRoleLoanManager()
        {
            roleLoanManager.Click();
            return this;
        }
//@Step("Устанавливаем роль ориджинатор")
public UsersPage setUserRoleOriginator()
        {
            roleOriginator.Click();
            return this;
        }
//@Step("Устанавливаем роль супервизор")
public UsersPage setUserRoleSupervisor()
        {
            roleSupervisor.Click();
            return this;
        }
//@Step("Устанавливаем роль андерайтер")
public UsersPage setUserRoleUnderwriter()
        {
            roleUnderwriter.Click();
            return this;
        }
//@Step("Устанавливаем отделение")
public UsersPage setUserBranch(String fBranch)
        {
            branch.Clear();
            branch.SendKeys(fBranch); ;
            return this;
        }
//@Step("Подтверждаем сохранение")
public UsersPage clickBtnOk()
        {
            btnOk.Click();
            return this;
        }
//@Step("Отклоняем сохранение")
public UsersPage setBtnCancel()
        {
            btnCancel.Click(); ;
            return this;
        }
        public UsersPage setfLabelAddUser(IWebElement fLabelAddUser)
        {

            return this;
        }
//@Step("Если юзер существует, клацаем конфирмейшн")
       public UsersPage setBtnCloseIfUserExist(IWebElement btnCloseIfUserExist)
        {
            this.btnCloseIfUserExist = btnCloseIfUserExist;
            return this;
        }
        public UsersPage setLableIfUserExist(IWebElement lableIfUserExist)
        {
            this.lableIfUserExist = lableIfUserExist;
            return this;
        }

        /*public bool IsElementPresent(IWebDriver driver, By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch(NoSuchElementException e)
            {
                return false;
            }

        }*/

        /*public bool isUserExist()
        {
            if (isElementPresent(By.XPath("//form[@name=\"dlgForm\"]/div[1]/strong[1]")))
            {
                btnCloseIfUserExist.Click();
                btnCancel.Click();
                Console.WriteLine("User exist!!!");
                return true;
            }
            else return false;
        }*/

        public UsersPage setSerchUser(string userName)
        {
            findUser.SendKeys(userName);
            return this;
        }

        public void clickDeleteButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div[id = \"application-user-list\"] button[ng-click=\"remove()\"]")));
            deleteUser.Click();
        }
        public UsersPage clickChooseUser()
        {
            chooseUser.Click();
            return this;
        }

        public void clickApproveDeleteUser()
        {
            approveDeleteUser.Click();
        }

        public UsersPage clickInvestorTab()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("li[heading=\"Investors\"] a")));
            InvestorsTab.Click();
            return this;
        }

        public bool IsUserExist()
        {
           Thread.Sleep(2000);
           if (driver.FindElements(By.CssSelector("table#usersGrid_grid tr[id]")).ToList().Count > 0)
                return true;
            else
                return false;
        }
    }
}
