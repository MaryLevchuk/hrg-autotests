using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;




namespace Settings
{
    public abstract class TestSettings
    {
        public static IWebDriver driver;

        public const string FIREFOX = "firefox";
        public const string IEXPLORER = "iexplore";
        public const string CHROME = "chrome";

        public string environment;   
        public string page;

        public IWebDriver SetBrowser(string browser)
        {
            IWebDriver driver;
            switch (browser)
            {
                case FIREFOX:
                    driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
                    break;
                case IEXPLORER:
                    driver = new OpenQA.Selenium.IE.InternetExplorerDriver();
                    break;
                case CHROME:
                    driver = new OpenQA.Selenium.Chrome.ChromeDriver();
                    break;
                default:
                    throw new Exception();
            }
            return driver;
        }

        public void OpenBrowser(string browser)
        {
            driver = SetBrowser(browser);
            driver.Manage().Window.Maximize();
        }

        public TestSettings(string driver, string env, string pageName)
        {
            OpenBrowser(driver);
            this.environment = ConfigurationManager.AppSettings[env];
            this.page = this.environment + ConfigurationManager.AppSettings[pageName];
        }
        public void OpenPage(string url)
        {
            driver.Navigate().GoToUrl(url);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            
        }



        [TestFixtureSetUp]
        public void InitPage()
        {
            OpenPage(this.page);
        }

        [TestFixtureTearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(1000);
            driver.Quit();
        }

    }
}
