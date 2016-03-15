using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Configuration;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Settings;
using Helpers;


namespace HRGAutoTests
{
    public class HomePageTests : TestSettings
    {
        public HomePageStep  homepage;
        public ItemActions action;
            public HomePageTests() : base("chrome", "preprod")
            {
                OpenPageByName("homePage");
                action = new ItemActions();
                homepage = new HomePageStep();
            }

        [Test]
        public void PageOpenedWithResponseOK()
        {
            string url = environment + ConfigurationManager.AppSettings["OurShipsPage"];
            Console.WriteLine(url);
            Assert.AreEqual(action.GetResponseCodeByUrl(url), "OK");
        }

            [Test]
            public void BackgroudImage_IsPresent()
            {
                Assert.IsNotEmpty(homepage.BackgroundImageDiv.GetCssValue("background-image"));
            }

            [Test]
            public void Header_IsPresent()
            {
               Assert.IsTrue(homepage.Header.Displayed);
            }

            [Test]
            public void Intro_IsPresent()
            {
                Assert.IsTrue(homepage.Intro.Displayed);
            }

            [Test]
            public void FindAnAdventureBtn_IsPresent()
            {
                Assert.IsTrue(homepage.FindAnAdventureBtn.Displayed);
            }

            [Test]
            public void FindAnAdventureBtn_IsClickabe()
            {
                Assert.IsNotEmpty(homepage.FindAnAdventureBtn.GetAttribute("href"));
            }

            [Test]
            public void BestSuggestions_ArePresent()
            {
                Assert.IsTrue(homepage.BestSuggestionsDiv.Displayed);
            }

            [TestCase("MenuPanel", Result = true)]
            [TestCase("Logo", Result = true)]
            [TestCase("LanguageSelector", Result = true)]
            [TestCase("FooterPanel", Result = true)]
            [TestCase("InfoList", Result = true)]
            [TestCase("Copyright", Result = true)]
            [TestCase("ArrowUp", Result = true)]
            public bool PresentItem(string itemName)
            {
                return action.FindItemByName(itemName).Displayed;
            }

            [TestCase("PrimaryItems", Result = true)]
            [TestCase("SecondaryItems", Result = true)]
            [TestCase("SocialIcons", Result = true)]
            [TestCase("SocialIconsText", Result = true)]
            [TestCase("LogoListItems", Result = true)]
            public bool PresentItems(string itemsName)
            {
                bool result = true;
                List<IWebElement> items = action.FindElementsByCss(itemsName);
                foreach (IWebElement item in items)
                {
                    result = result && item.Displayed;
                }
                return result;
            }

            public bool Items_Displayed(string itemsName)
            {
                bool result = true;
                var items = action.FindItemsByCommonName(itemsName);
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

        }
}
