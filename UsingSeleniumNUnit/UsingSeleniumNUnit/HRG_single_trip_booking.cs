using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class HRGSingleTripBooking
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            baseURL = "http://testing.hurtigruten.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheHRGSingleTripBookingTest()
        {
            driver.Navigate().GoToUrl(baseURL);
            WaitUntilVisible("img.large", 60);

            SelectFindATripMenu();
            
            SetPort("from", "FRO");
            
            SetPort("to", "FRO");
            Thread.Sleep(5000);

            
        }

        public void WaitUntilVisible(String elementSelector, Int16 timeInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(elementSelector)));
        }
                       
        public void SelectFindATripMenu() 
        {
            driver.FindElement(By.CssSelector(".booking span.button-text")).Click();
        }

        public void SetPort(String direction, String userSpecifiedPort)
        {
            String selector = "div#" + direction + "Port_chosen";
            driver.FindElement(By.CssSelector(selector)).Click();
            
            String portsSelector = selector + " .chosen-results li";
System.Console.WriteLine(portsSelector);           
            var ports = driver.FindElements(By.CssSelector(portsSelector));

System.Console.WriteLine(direction);           

            foreach (var lPort in ports) 
            {
                System.Console.WriteLine(lPort.GetAttribute("textContent"));            
            }

System.Console.WriteLine("-------------------");

            foreach (var localPort in ports)
            {                
                if (localPort.GetAttribute("textContent").Contains(userSpecifiedPort)) 
                {

System.Console.WriteLine(localPort.GetAttribute("textContent"));
System.Console.WriteLine(localPort.Displayed);

                    localPort.Click();
                    break;
                }
            }
            driver.FindElement(By.CssSelector("h1.header-primary")).Click();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
