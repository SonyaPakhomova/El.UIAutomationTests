using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace El.Test.UiTests.Modules
{
    /// <summary>
    /// Factory for creating WebDriver for various browsers.
    /// </summary>
    public static class WebDriverFactory
    {
        /// <summary>
        /// Initilizes IWebDriver base on the given WebBrowser name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IWebDriver CreateWebDriver(string browserName)
        {
            switch (browserName)
            {
                case "FireFox":
                    return new FirefoxDriver();
                    
                case "IE":
                    InternetExplorerOptions ieOption = new InternetExplorerOptions();
                    ieOption.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    ieOption.EnsureCleanSession = true;
                    ieOption.RequireWindowFocus = true;
                    //return new InternetExplorerDriver(@"./", ieOption);
                    return new InternetExplorerDriver();

                /* case "safari":
                     return new RemoteWebDriver(new Uri("http://mac-ip-address:the-opened-port"), DesiredCapabilities.Safari());*/
                case "Crome":
                default:
                    //ChromeOptions chromeOption = new ChromeOptions();
                    //string location = @"./";
                    //chromeOption.AddArguments("--disable-extensions");
                    //return new ChromeDriver(location, chromeOption);
                    return new ChromeDriver();

            }
          
        }
    }
}