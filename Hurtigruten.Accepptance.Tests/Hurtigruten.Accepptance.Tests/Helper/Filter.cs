using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;


namespace Hurtigruten.Accepptance.Tests.Helper
{
    public class Filter
    {
        public string FilterName;
        public string IconCss = ".inspiration-filter-nav-tab-icon";
        public string TitleCss = ".title";
        public string OptionsCss = ".form-label.form-label-checkbox";
        public List<IWebElement> OptionItems;
        private IWebDriver driver;

        public Filter(IWebDriver driver, string name)
        {
           this.driver = driver;
           FilterName = name;
           FindIcon().Click();
           Thread.Sleep(1000);
           OptionItems = driver.FindElements(By.CssSelector((OptionsCss + "[for|='" + FilterName + "']"))).ToList();
           Thread.Sleep(5000);
        }
        
        public IWebElement FindIcon()
        {
            return driver.FindElement(By.CssSelector((IconCss + "." + FilterName)));
        }
        
        public IWebElement FindTitle()
        {
            return driver.FindElement(By.CssSelector(".nav-tabs.active.has-selected-filters " + TitleCss));
        }

        public void CheckOptions(int[] states)
        {            
            for (var i = 0; i <= OptionItems.Count; i++ )
            {
                if (states[i] == 1)
                { OptionItems[i].Click(); }
            }
        }

    }
}
