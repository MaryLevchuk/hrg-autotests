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

namespace Helpers.ItemModels
{
    public class PageObject
    {
        protected IWebDriver driver;

        public PageObject()
        {
            this.driver = TestSettings.driver;
        }

        public IWebElement FindItemByFieldName(string itemName)
        {
            var locator = typeof(Locators).GetField(itemName).GetValue(typeof(Locators));

            return driver.FindElement(By.CssSelector(locator.ToString()));
        }

        public List<IWebElement> FindItemsByCommonName(string itemsScopeName)
        {
            var locator = typeof(Locators).GetField(itemsScopeName).GetValue(typeof(Locators));
            return driver.FindElements(By.CssSelector(locator.ToString())).ToList();
        }

        public object GetClassField(string field)
        {
            return this.GetType().GetField(field).GetValue(this);
        }
        
    }
}
