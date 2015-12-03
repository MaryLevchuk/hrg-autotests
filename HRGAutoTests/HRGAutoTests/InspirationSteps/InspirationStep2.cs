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
using Helpers.Inspiration;
//using Helpers.ItemModels;
using Helpers;
//using Models;

namespace HRGAutoTests.InspirationSteps
{
    public class InspirationStep2 : TestSettings
    {
        public IWebElement InspirationHeader;
        public Step2 step2;
        public ItemActions action;
        public InspirationStep2() : base("chrome", "preprod")
        {
            action = new ItemActions();

            OpenPageByName("homePage");
            action.WaitUntilElementLoadedByCss(Locators.Header);
            
            action.SelectInspirationMenu();
            action.WaitUntilElementLoadedByCss(Locators.LastVisibleArticle);
            
            step2 = new Step2();
            InspirationHeader = driver.FindElement(By.CssSelector(Locators.InspirationHeader));
        }

        [TestCase("Header", Result = true)]
        [TestCase("Intro", Result = true)]
        public bool PresentItem(string itemName)
        {
            return step2.IsPresentByName(itemName);
        }

        [TestCase("FilterIcons", Result = true)]
        [TestCase("FilterTitles", Result = true)]
        [TestCase("FilterOptions", Result = true)]
        [TestCase("Articles", Result = true)]
        public bool PresentListOfItems(string listName)
        {
            return step2.ItemsListIsPresent(listName);
        }

        [Test]
        public void GetInspiredMenu_IsActive()
        {
            string activeMenuItemText = driver.FindElement(By.CssSelector(Locators.ActiveMenuItem)).Text;
            Assert.AreEqual(activeMenuItemText.ToLower(), "Get inspired".ToLower());
        }


    }
}
