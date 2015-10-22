using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Settings;
using Helpers;

namespace Helpers.CommonItems
{
    public class PageObject
    {
        protected IWebDriver driver;

        public PageObject()
        {
            this.driver = TestSettings.driver;
        }

        public IWebElement FindItem(string itemName)
        {
            var locator = typeof(CommonLocators).GetField(itemName).GetValue(typeof(CommonLocators));
            return driver.FindElement(By.CssSelector(locator.ToString()));
        }

        public List<IWebElement> FindItems(string itemsScopeName)
        {
            var locator = typeof(CommonLocators).GetField(itemsScopeName).GetValue(typeof(CommonLocators));
            return driver.FindElements(By.CssSelector(locator.ToString())).ToList();
        }

        public object GetClassField(string field)
        {
            return this.GetType().GetField(field).GetValue(this);
        }
        
    }
}
