using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Settings;



namespace Helpers.Inspiration
{
    public class Filter
    {
        public string FilterName;
        public IWebElement IconItem;
        public IWebElement TitleItem;
        public List<IWebElement> OptionItems;
        
        protected IWebDriver driver;

        public Filter(string name)
        {
           this.driver = TestSettings.driver;
           this.FilterName = name;

           this.IconItem = FindIcon();

           this.IconItem.Click();
           Thread.Sleep(500);

           this.TitleItem = FindTitle();
           this.OptionItems = FindOptions();

            Thread.Sleep(500);
        }

        public IWebElement FindIcon()
        {
            return driver.FindElement(By.CssSelector((Locators.FilterIcon + "." + FilterName)));
        }
        
        public IWebElement FindTitle()
        {
            return driver.FindElement(By.CssSelector(".nav-tabs.active " + Locators.FilterTitle));
        }

        public List<IWebElement> FindOptions()
        {
            return driver.FindElements(By.CssSelector((Locators.FilterOptions + "[for|='" + FilterName + "']"))).ToList();
        }

        public void MarkOption(int order_number)
        {
            OptionItems[order_number].Click(); Thread.Sleep(500);
        }
        
        public void MarkOptions(int[] states)
        {
            for (var i = 0; i < OptionItems.Count; i++ )
            {
                if (states[i] == 1)
                { MarkOption(i); }
            }
        }

        public string GetIconBackgroudColor()
        {
            string color = IconItem.GetCssValue("box-shadow");
            string[] numbers = color.Split('(')[1].Split(')')[0].Split(',');

            int r = Int32.Parse(numbers[0].Trim());
            int g = Int32.Parse(numbers[1].Trim());
            int b = Int32.Parse(numbers[2].Trim());

            String hex = ("#" + r.ToString("X") + g.ToString("X") + b.ToString("X")).ToLower();
            return hex;
        }

        public virtual void TurnOn()
        {
            this.MarkOption(1);
            Thread.Sleep(500);
        }

        public static void TurnOn(params string[] fNames)
        {
            foreach (string name in fNames)
            {
                new Filter(name).TurnOn(); 
            }
        }

        public void ClearAllFilters()
        {
            driver.FindElement(By.CssSelector(".grid-filter-clear-all")).Click();
        }

        
    }
}

