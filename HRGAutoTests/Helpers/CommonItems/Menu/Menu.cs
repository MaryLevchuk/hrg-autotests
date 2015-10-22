using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using Settings;

namespace Helpers.CommonItems
{
    public class Menu : PageObject
    {
        //private IWebDriver driver;
        public IWebElement Panel;
        public IWebElement Logo;
        public List<IWebElement> PrimaryItems;
        public List<IWebElement> SecondaryItems;
        public IWebElement LanguageSelector;

        public Menu()
        {
          //  this.driver = TestSettings.driver;
            this.Panel = FindItem("Panel");
            this.Logo = FindItem("Logo");
            this.PrimaryItems = FindItems("PrimaryItems");
            this.SecondaryItems = FindItems("SecondaryItems");
            this.LanguageSelector = FindItem("LanguageSelector");
        }
        
        //public string GetMenuField(string field)
        //{
        //    string result;
        //    switch (field)
        //    {
        //        case "Panel":
        //            result = this.Panel.ToString();
        //            break;

        //        case "Logo":
        //            result = this.Logo.ToString();
        //            break;

        //        case "PrimaryItems":
        //            result = this.PrimaryItems.Count.ToString();
        //            break;

        //        case "SecondaryItems":
        //            result = this.SecondaryItems.Count.ToString();
        //            break;

        //        case "LanguageSelector":
        //            result = this.LanguageSelector.ToString();
        //            break;

        //        default:
        //            result = null;
        //            break;
        //    }
        //    return result;

        //}

        public string GetMenuField(string field)
        {
            return this.GetType().GetField(field).ToString();
        }
        
    }
}
