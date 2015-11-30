using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Helpers;

namespace Helpers.ItemModels
{
    public class FilterSearch : Filter
    {
        public IWebElement SearchBox;
        public IWebElement SearchBtn;

        public FilterSearch()
            : base("filter-search")
        {
            SearchBox = FindSearchBox();
            SearchBtn = FindSearchBtn();
        }

        public IWebElement FindSearchBox()
        {
            return driver.FindElement(By.CssSelector(Locators.SearchInput));
        }

        public IWebElement FindSearchBtn()
        {
            return driver.FindElement(By.CssSelector(Locators.SearchBtn));
        }

        public void TypeText(string text)
        {
            SearchBox.Clear();
            SearchBox.SendKeys(text);
        }
    }
}

