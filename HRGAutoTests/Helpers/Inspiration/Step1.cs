using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Settings;
using Helpers;

namespace Helpers.Inspiration
{
    public class Step1
    {
        private IWebDriver driver;
        public IWebElement BackgroundImageDiv;
        public IWebElement Header;
        public IWebElement Intro;
        public IWebElement FindAnAdventureBtn;
        public IWebElement BestSuggestionsDiv;

        public Step1()
        {
            driver = TestSettings.driver;
            BackgroundImageDiv = driver.FindElement(By.CssSelector(Locators.BackgroudImageDiv));
            Header = driver.FindElement(By.CssSelector(Locators.Header));
            Intro = driver.FindElement(By.CssSelector(Locators.Intro));
            FindAnAdventureBtn = driver.FindElement(By.CssSelector(Locators.FindAnAdventureBtn));
            BestSuggestionsDiv = driver.FindElement(By.CssSelector(Locators.PromotedTravels));
        }
        
        
    }
}
