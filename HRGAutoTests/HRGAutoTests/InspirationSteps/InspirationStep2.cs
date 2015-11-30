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
using Helpers.ItemModels;
using Helpers;
using Models;

namespace HRGAutoTests.InspirationSteps
{
    public class InspirationStep2 : TestSettings
    {
        public Step2 step2;
        public ItemActions action;
        public InspirationStep2() : base("chrome", "preprod")
        {
            action = new ItemActions();

            OpenPageByName("homePage");
            action.WaitUntilLoaded(Locators.Header);
            
            action.SelectInspirationMenu();
            action.WaitUntilLoaded(Locators.LastVisibleArticle);
            
            step2 = new Step2();
        }

        [TestCase("Header", Result = true)]
        [TestCase("Intro", Result = true)]
        public bool PresentItem(string itemName)
        {
            return step2.PresenceOfItem(itemName);
        }

        [TestCase("FilterIcons", Result = true)]
        [TestCase("FilterTitles", Result = true)]
        [TestCase("FilterOptions", Result = true)]
        [TestCase("Articles", Result = true)]
        public bool PresentListOfItems(string listName)
        {
            return step2.PresenceOfItemsList(listName);
        }

        [TestCase("FilterIcons", Result = 4)]
        [TestCase("FilterTitles", Result = 4)]
        [TestCase("FilterOptions", Result = 17)]
        public int AmountOf(string itemsName)
        {
            return step2.AmountOfItems(itemsName);
        }

        [TestCase("destinations", Result = 6)]
        [TestCase("seasons", Result = 4)]
        [TestCase("attractions", Result = 7)]
        public int AmountOfOptionsForFilter(string filterName)
        {
            return step2.AmountOfOptionsOfFilter(filterName);
        }
    }
}
