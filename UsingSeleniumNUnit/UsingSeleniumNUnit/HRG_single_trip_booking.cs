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
              Thread.Sleep(1000);
           
            SetPort("to", "FRO");
              Thread.Sleep(1000);
            
            SetPassengers("ADULT", 1);

            Thread.Sleep(5000);

            
        }

        public void WaitUntilVisible(String elementSelector, Int16 timeInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(elementSelector)));
        }

        public void WaitUntilClickable(String elementSelector, Int16 timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(elementSelector)));
        }
        public void WaitUntilInvisible(String elementSelector, Int16 timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(elementSelector)));
        }
                                       
        public void SelectFindATripMenu() 
        {
            driver.FindElement(By.CssSelector(".booking span.button-text")).Click();
        }

        public void SetPort(String direction, String userSpecifiedPort)
        {
            String selector = "div#" + direction + "Port_chosen";
            driver.FindElement(By.CssSelector(selector)).Click();
            Thread.Sleep(100);

            String portsSelector = selector + " .chosen-results li";
   
            var ports = driver.FindElements(By.CssSelector(portsSelector));

            foreach (var localPort in ports)
            {                
                if (localPort.GetAttribute("textContent").Contains(userSpecifiedPort)) 
                {
                    localPort.Click();
                    break;
                }
            }
            WaitUntilInvisible(portsSelector, 10);
        }

        public void SetPassengers(String type, Int16 amount)
        {
            driver.FindElement(By.CssSelector("span.form-input[data-trigger=booking-cabin-controller]")).Click();
            WaitUntilVisible("li.cabin-action-edit a", 10);
           // Thread.Sleep(1000);

            driver.FindElement(By.CssSelector("li.cabin-action-edit a")).Click();
           
            WaitUntilVisible("div.booking-passenger-selection", 10);
            var rowSelector = PassengersRowSelector("ADULT");
            var defaultNumber = Convert.ToInt16(driver.FindElement(By.CssSelector((rowSelector + " span.booking-passenger-selection-item-count").ToString())).GetAttribute("textContent"));
             
            IWebElement buttonAdd = driver.FindElement(By.CssSelector((rowSelector + " button.button.button-circle.booking-passenger-selection-item-add").ToString()));
            IWebElement buttonRemove = driver.FindElement(By.CssSelector((rowSelector + " button.button.button-circle.booking-passenger-selection-item-remove").ToString()));
   
            if (defaultNumber > amount) 
            {
                var difference = defaultNumber - amount;
                while (difference != 0)
                {
                    buttonRemove.Click();
                    Thread.Sleep(100);
                    difference = difference - 1;
                }
            }
            else if (defaultNumber < amount)
            {
                var difference = amount - defaultNumber;
                while (difference != 0)
                {
                    buttonAdd.Click();
                    Thread.Sleep(100);
                    difference = difference - 1;
                }
            }
            
            WaitUntilClickable(".button.button-primary.booking-passenger-selection-done", 10);
            driver.FindElement(By.CssSelector(".button.button-primary.booking-passenger-selection-done")).Click();

            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".button.button-primary.cabin-controller-done")).Click();
            
        }

        public String PassengersRowSelector(String type)
        {
            String selector = ".booking-passenger-selection-list.list li[data-passengertype=" + type + "]";
            return selector;
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
