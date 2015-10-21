using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using Settings;

namespace Helpers.CommonItems.Menu
{
    public class Menu
    {
        private IWebDriver driver;
        public IWebElement Panel;
        public IWebElement Logo;
        public List<IWebElement> PrimaryItems;
        public List<IWebElement> SecondaryItems;
        public IWebElement LanguageSelector;

        public Menu()
        {
            this.driver = TestSettings.driver;
            this.Panel = FindItem("Panel");
            this.Logo = FindItem("Logo");
            this.PrimaryItems = FindItems("PrimaryItems");
            this.SecondaryItems = FindItems("SecondaryItems");
            this.LanguageSelector = FindItem("LanguageSelector");
        }
        
        public IWebElement FindItem(string itemName) 
        {
            var locator = typeof(CommonLocators).GetField(itemName).GetValue(typeof(CommonLocators));
            return driver.FindElement(By.CssSelector(locator.ToString())); 
        }

        public List<IWebElement> FindItems(string itemsName) 
        {
            var locator = typeof(CommonLocators).GetField(itemsName).GetValue(typeof(CommonLocators));
            return driver.FindElements(By.CssSelector(locator.ToString())).ToList(); 
        }

        public string GetField(string field)
        {
            var locator = typeof(Menu).GetField(field).ToString();
            return locator;
        }
        
    }
}
