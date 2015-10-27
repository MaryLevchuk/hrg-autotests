using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using Settings;
using Helpers;

namespace Helpers.CommonItems
{
    public class Menu : PageObject
    {
        public IWebElement Panel;
        public IWebElement Logo;
        public List<IWebElement> PrimaryItems;
        public List<IWebElement> SecondaryItems;
        public IWebElement LanguageSelector;

        public Menu()
        {
            
            this.Panel = FindItem("Panel");
            this.Logo = FindItem("Logo");
            this.PrimaryItems = FindItems("PrimaryItems");
            this.SecondaryItems = FindItems("SecondaryItems");
            this.LanguageSelector = FindItem("LanguageSelector");
        }
        
        public string GetMenuField(string field)
        {
            return this.GetType().GetField(field).ToString();
        }
        
    }
}
