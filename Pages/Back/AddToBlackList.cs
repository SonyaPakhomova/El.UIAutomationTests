using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace El.Test.UiTests.Pages.Back
{
    class AddToBlackList:Page
    {
        public AddToBlackList(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

    }
}
