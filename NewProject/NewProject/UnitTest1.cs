using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using NUnit.Framework;

namespace NewProject
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;

        [TestInitialize]
        public void OpenBrowser()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.lipsum.com/");
            driver.Manage().Window.Maximize();
        }
        
        [TestMethod]
        public void TestMethod1()
        {
            var paragraph_amount = driver.FindElement(By.Id("amount"));
            paragraph_amount.Clear();
            paragraph_amount.SendKeys("10");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1000));
            
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }

}

