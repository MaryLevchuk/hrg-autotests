using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Settings;
using Helpers.ItemModels;
using Helpers;


namespace Models
{
    [TestFixture]
    public abstract class Page : TestSettings
    {
        public Menu menu;
        public Footer footer;
        public ItemActions action;
        
        public Page(string browser, string env, string pageName) :base(browser, env)
        {
            action = new ItemActions();
            OpenPageByName(pageName);
        }
        
        public bool PresentItem(PageObject area, string itemName)
        {
            var result = (IWebElement)area.GetClassField(itemName);
            return result.Displayed;
        }

        public bool PresentItems(PageObject area, string itemsName)
        {
            bool result = true;
            var items = (List<IWebElement>)area.GetClassField(itemsName);
                if (items[0].GetAttribute("innerText").Contains("Your booking"))
                {
                    items.RemoveAt(0);
                }
            foreach (IWebElement item in items)
            {
                result = result && item.Displayed;
            }
            return result;
        }


        [TestCase("Panel", Result = true)]
        [TestCase("Logo", Result = true)]
        [TestCase("LanguageSelector", Result = true)]
        public bool VisibleMenuItem(string itemName)
        {
            this.menu = new Menu();
            return PresentItem(menu, itemName);
        }

        [TestCase("PrimaryItems", Result = true)]
        [TestCase("SecondaryItems", Result = true)]
        public bool VisibleMenuItems(string itemsName)
        {
            this.menu = new Menu();
            return PresentItems(menu, itemsName);
        }

        [TestCase("FooterPanel", Result = true)]
        [TestCase("FooterInfoList", Result = true)]
        [TestCase("Copyright", Result = true)]
        [TestCase("ArrowUp", Result = true)]
        public bool VisibleFooterItem(string itemName)
        {
            this.footer = new Footer();
            return PresentItem(footer, itemName);
        }

        [TestCase("SocialIcons", Result = true)]
        [TestCase("SocialIconsText", Result = true)]
        [TestCase("LogoListItems", Result = true)]
        public bool VisibleFooterItems(string itemsName)
        {
            this.footer = new Footer();
            return PresentItems(footer, itemsName);
        }

    }
}
