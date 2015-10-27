using System;
using System.Threading;
using OpenQA.Selenium;
using NUnit.Framework;
using Helpers.Inspiration;
using Settings;
using Pages;

namespace HRGAutotests
{
    [TestFixture]
    public class InspirationPage : Page
    {

        public InspirationPage()
            : base("chrome", "preprod", "inspirationPage")
        { }

        [TestCase("destinations", Result = "#7bc4be")]
        [TestCase("seasons", Result = "#cd6849")]
        [TestCase("attractions", Result = "#7091b8")]
        [TestCase("filter-search", Result = "#383735")]
        public string FilterColor_IsChanged_WhenActive(string name)
        {
            Filter.TurnOn("destinations", "seasons", "attractions");
            new FilterSearch().TypeText("q");

            Filter f = new Filter(name);
            string color = f.GetIconBackgroudColor();
            f.ClearAllFilters();
            return color;
        }

        [Test]
        public void SearchBoxAllowsTypeText()
        {
            FilterSearch fSearch = new FilterSearch();

            fSearch.TypeText("Bergen");
            Thread.Sleep(500);

            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            string actualText = (string)js.ExecuteScript("return document.getElementById('inspiration-search').value");

            fSearch.SearchBox.Clear();

            Assert.AreEqual(actualText, "Bergen");
        }

        [Explicit]
        [TestCase("destinations", 1, 0, 0, 0, 0, 0 , Result = "Destinations1")]
        [TestCase("destinations", 0, 1, 0, 0, 1, 0 , Result = "Destinations2")]
        [TestCase("destinations", 0, 0, 1, 1, 0, 1 , Result = "Destinations3")]
        [TestCase("destinations", 1, 0, 1, 1, 0, 1 , Result = "Destinations4")]
        [TestCase("destinations", 1, 1, 0, 1, 1, 1 , Result = "Destinations5")]
        [TestCase("destinations", 1, 1, 1, 1, 1, 1 , Result = "Destinations6")]
        [TestCase("seasons", 1, 0, 0, 0 , Result = "Seasons1")]
        [TestCase("seasons", 0, 1, 0, 1 , Result = "Seasons2")]
        [TestCase("seasons", 1, 0, 1, 1 , Result = "Seasons3")]
        [TestCase("seasons", 1, 1, 1, 1 , Result = "Seasons4")]
        [TestCase("attractions", 1, 0, 0, 0, 0, 0, 0 , Result = "Attractions1")]
        [TestCase("attractions", 0, 1, 0, 0, 0, 1, 0 , Result = "Attractions2")]
        [TestCase("attractions", 1, 0, 0, 1, 0, 0, 1 , Result = "Attractions3")]
        [TestCase("attractions", 0, 1, 1, 0, 1, 1, 0 , Result = "Attractions4")]
        [TestCase("attractions", 1, 0, 1, 1, 1, 0, 1 , Result = "Attractions5")]
        [TestCase("attractions", 1, 1, 1, 1, 1, 1, 0 , Result = "Attractions6")]
        [TestCase("attractions", 1, 1, 1, 1, 1, 1, 1 , Result = "Attractions7")]
        public string Options_AreAllowed_ToBeMarked(string filterName, params int[] states)
        {
            Filter filter = new Filter(filterName);
            filter.MarkOptions(states);
            Thread.Sleep(500);

            string title = filter.FindTitle().GetAttribute("innerText");
            Thread.Sleep(500);
            filter.ClearAllFilters();

            return title;
        }

        [Test]
        public void AssistanceBtnIsPresent()
        {
            Assert.IsNotNull(driver.FindElement(By.CssSelector(".assistance-toggler.assistance-toggler-button.assistance-toggler-icon")));
        }
    }

}
