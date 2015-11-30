using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Settings;
using Helpers.ItemModels;
using Helpers.Inspiration;
using Models;

namespace HRGAutoTests.InspirationSteps
{
    public class InspirationStep1 : TestSettings
    {
        public Step1 step1;
        public Menu menu;
        public Footer footer;
        public PageObject pageObject;

        public InspirationStep1() : base("chrome", "preprod")
        {
            OpenPageByName("homePage");
            step1 = new Step1();
            pageObject = new PageObject();
            menu = new Menu();
            footer = new Footer();
        }

        [Test]
        public void BackgroudImage_IsPresent()
        {
            Assert.IsNotEmpty(step1.BackgroundImageDiv.GetCssValue("background-image"));
        }

        [Test]
        public void Header_IsPresent()
        {
            Assert.IsNotEmpty(step1.Header.GetAttribute("innerText"));
        }

        [Test]
        public void Intro_IsPresent()
        {
            Assert.IsNotEmpty(step1.Intro.GetAttribute("innerText"));
        }

        [Test]
        public void FindAnAdventureBtn_IsPresent()
        {
            Assert.IsNotEmpty(step1.FindAnAdventureBtn.GetAttribute("href"));
        }

        [Test]
        public void BestSuggestions_ArePresent()
        {
            Assert.IsNotEmpty(step1.BestSuggestionsDiv.GetAttribute("innerText"));
        }

        [TestCase("MenuPanel", Result = true)]
        [TestCase("MenuLogo", Result = true)]
        [TestCase("MenuLanguageSelector", Result = true)]
        public bool Item_Displayed(string itemName)
        {
            var result = pageObject.FindItemByFieldName(itemName);
            return result.Displayed;
        }

        public bool Items_Displayed(string itemsName)
        {
            bool result = true;
            var items = pageObject.FindItemsByCommonName(itemsName);
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

        //[TestCase("Panel", Result = true)]
        //[TestCase("Logo", Result = true)]
        //[TestCase("LanguageSelector", Result = true)]
        //public bool VisibleMenuItem(string itemName)
        //{
        //    //this.menu = new Menu();
        //    return PresentItem(menu, itemName);
        //}

        //[TestCase("PrimaryItems", Result = true)]
        //[TestCase("SecondaryItems", Result = true)]
        //public bool VisibleMenuItems(string itemsName)
        //{
        //    //this.menu = new Menu();
        //    return PresentItems(menu, itemsName);
        //}

        //[TestCase("FooterPanel", Result = true)]
        //[TestCase("FooterInfoList", Result = true)]
        //[TestCase("Copyright", Result = true)]
        //[TestCase("ArrowUp", Result = true)]
        //public bool VisibleFooterItem(string itemName)
        //{
        //    //this.footer = new Footer();
        //    return PresentItem(footer, itemName);
        //}

        //[TestCase("SocialIcons", Result = true)]
        //[TestCase("SocialIconsText", Result = true)]
        //[TestCase("LogoListItems", Result = true)]
        //public bool VisibleFooterItems(string itemsName)
        //{
        //    //this.footer = new Footer();
        //    return PresentItems(footer, itemsName);
        //}


    }
}
