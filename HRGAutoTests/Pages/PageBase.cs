using System;
using System.Text;
using System.Collections.Generic;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Settings;
using Helpers.CommonItems;
using Helpers;


namespace Pages
{
    [TestFixture]
    public class Page : TestSettings
    {
        
        public Page(string browser, string env, string pageName) :base(browser, env, pageName)
        {  }

        [TestCase("Panel", Result = true)]
        [TestCase("Logo", Result = true)]
        [TestCase("PrimaryItems", Result = true)]
        [TestCase("SecondaryItems", Result = true)]
        [TestCase("LanguageSelector", Result = true)]
        public bool VisibleMenuItems(string itemName)
        {
            var result = (IWebElement)new Menu().GetClassField(itemName);
            //var result = (IWebElement)new Menu().GetClassField(itemName);
            return result.Displayed;
        }

        //[TestCase("Panel", Result = false)]
        //public bool PresentFooterItems(string itemName)
        //{ 
        
        //}
        
    }
}
