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
using Helpers;
using Helpers.Inspiration;


namespace HRGAutoTests.InspirationSteps
{
    public class InspirationStep1 : TestSettings
    {
        public Step1 step1;
       
        public InspirationStep1() : base("chrome", "preprod")
        {
            OpenPageByName("homePage");
            step1 = new Step1();
         }

        [Test]
        public void BackgroudImage_IsPresent()
        {
            Assert.IsNotEmpty(step1.BackgroundImageDiv.GetCssValue("background-image"));
        }

        [Test]
        public void Header_IsPresent()
        {
            //Assert.IsNotEmpty(step1.Header.GetAttribute("innerText"));
            Assert.IsTrue(step1.Header.Displayed);
        }

        [Test]
        public void Intro_IsPresent()
        {
            //Assert.IsNotEmpty(step1.Intro.GetAttribute("innerText"));
            Assert.IsTrue(step1.Intro.Displayed);
        }

        [Test]
        public void FindAnAdventureBtn_IsPresent()
        {
            Assert.IsTrue(step1.FindAnAdventureBtn.Displayed);
        }

        [Test]
        public void FindAnAdventureBtn_IsClickabe()
        {
            Assert.IsNotEmpty(step1.FindAnAdventureBtn.GetAttribute("href"));
        }

        [Test]
        public void BestSuggestions_ArePresent()
        {
            //Assert.IsNotEmpty(step1.BestSuggestionsDiv.GetAttribute("innerText"));
            Assert.IsTrue(step1.BestSuggestionsDiv.Displayed);
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
            return step1.FindItemByName(itemName).Displayed;
        }

        [TestCase("PrimaryItems", Result = true)]
        [TestCase("SecondaryItems", Result = true)]
        [TestCase("SocialIcons", Result = true)]
        [TestCase("SocialIconsText", Result = true)]
        [TestCase("LogoListItems", Result = true)]
        public bool PresentItems(string itemsName)
        {
            bool result = true;
            List<IWebElement> items = step1.FindElementsByCss(itemsName);
            foreach (IWebElement item in items)
            {
                result = result && item.Displayed;
            }
            return result;
        }

        public bool Items_Displayed(string itemsName)
        {
            bool result = true;
            var items = step1.FindItemsByCommonName(itemsName);
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
