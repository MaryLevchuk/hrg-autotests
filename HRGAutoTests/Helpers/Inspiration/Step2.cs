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
    /// <summary>
    /// 
    /// </summary>
    public class Step2
    {
        private IWebDriver driver;
        public IWebElement InspirationHeader;
        public IWebElement InspirationIntro;
        public List<IWebElement> FilterIconsList;
        public List<IWebElement> FilterTitlesList;
        public List<IWebElement> FilterOptionsList;
        public List<IWebElement> ArticlesList;
        
        /// <summary>
        /// Must be called ... only
        /// </summary>
        public Step2()
        {
            driver = TestSettings.driver;
            InspirationHeader = driver.FindElement(By.CssSelector(Locators.InspirationHeader));
            InspirationIntro = driver.FindElement(By.CssSelector(Locators.InspirationIntro));
            FilterIconsList = driver.FindElements(By.CssSelector((Locators.FilterIconsList))).ToList();
            FilterTitlesList = driver.FindElements(By.CssSelector((Locators.FilterTitlesList))).ToList();
            FilterOptionsList = driver.FindElements(By.CssSelector((Locators.FilterOptionsList))).ToList();
            ArticlesList = driver.FindElements(By.CssSelector((Locators.ArticlesList))).ToList();
            
        }

        public IWebElement SelectFieldForItem(string itemName)
        {
            IWebElement field = null;
            switch (itemName)
            {
                case "Header":
                    field = InspirationHeader;
                    break;

                case "Intro":
                    field = InspirationIntro;
                    break;
            }
            return field;
        }

        public List<IWebElement> SelectFieldForListOfItems(string listName)
        {
            List<IWebElement> field = null;
            switch (listName)
            {
                case "FilterIcons":
                    field = FilterIconsList;
                    break;

                case "FilterTitles":
                    field = FilterTitlesList;
                    break;

                case "FilterOptions":
                    field = FilterOptionsList;
                    break;

                case "Articles":
                    field = ArticlesList;
                    break;
            }
            return field;
        }

        public bool IsPresentByName(string itemName)
        {
            IWebElement item = SelectFieldForItem(itemName);
            return item.Displayed;
        }
        
        public bool ItemsListIsPresent(string itemsListName)
        {
            List<IWebElement> list = SelectFieldForListOfItems(itemsListName);
            return list.Count > 0;
        }

        public int AmountOfItems(string itemsListName)
        {
            List<IWebElement> items = SelectFieldForListOfItems(itemsListName);
            return items.Count;
        }

        public int AmountOfOptionsOfFilter(string filterName)
        {
            List<IWebElement> optionsList = GetOptionsForFilter(filterName);
            return optionsList.Count;
        }

        public List<IWebElement> GetOptionsForFilter(string filterName)
        {
            List<IWebElement> filterOptions = new List<IWebElement>();
            string filterAttribute = filterName.ToLower();
            foreach (IWebElement option in FilterOptionsList)
            {
                if (option.GetAttribute("htmlFor").Contains(filterAttribute))
                {
                    filterOptions.Add(option);
                }
            }
            return filterOptions;
        }

        public bool IsPresentByCss(string css)
        {
           IWebElement item = driver.FindElement(By.CssSelector(css));
           return item.Displayed;
        }

        public bool IsPresentItem(IWebElement item)
        {
            return item.Displayed;
        }


    }
}
