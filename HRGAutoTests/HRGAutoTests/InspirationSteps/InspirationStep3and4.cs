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
    public class InspirationStep3and4 : TestSettings
    {

        public Step3 step3;
        public ItemActions action;
        public InspirationStep3and4() : base("chrome", "preprod")
        {
            action = new ItemActions();

            OpenPageByName("homePage");
            action.WaitUntilLoaded(Locators.Header);

            action.SelectInspirationMenu();
            action.WaitUntilLoaded(Locators.LastVisibleArticle);

            step3 = new Step3();
            
            step3.MarkOptionByName("Destinations", "Norway");
            Thread.Sleep(500);

            step3.FindFilterTitleByFilterName("Attractions").Click();
            Thread.Sleep(500);

            step3.MarkOptionByName("Attractions", "Fjords");
            Thread.Sleep(500);
        }

        [TestCase("Destinations", Result = "#7bc4be")]
        [TestCase("Attractions", Result = "#7091b8")]
        public string FilterChangesItsColorWhenActive(string filterName)
        {
            IWebElement filterIcon = step3.FindFilterIconByFilterName(filterName);
                string hexColor = action.GetHexIconBackgroudColorByCssValue("box-shadow", filterIcon);
            return hexColor;
        }

        [TestCase("Destinations", Result = "1")]
        [TestCase("Attractions", Result = "1")]
        public string FilterChangesItsIndexWhenOptionsAreMarked(string filterName)
        {
            string index = step3.GetFilterTitleIndex_Of(filterName);
            return index;
        }

        
    }
}
