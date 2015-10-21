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
        public string Color_IsChanged_WhenActive(string name)
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


        [TestCase(new int[] { 1, 0, 0, 0, 0, 0 }, Result = "Destinations1")]
        [TestCase(new int[] { 0, 1, 0, 0, 1, 0 }, Result = "Destinations2")]
        [TestCase(new int[] { 0, 0, 1, 1, 0, 1 }, Result = "Destinations3")]
        [TestCase(new int[] { 1, 0, 1, 1, 0, 1 }, Result = "Destinations4")]
        [TestCase(new int[] { 1, 1, 0, 1, 1, 1 }, Result = "Destinations5")]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, Result = "Destinations6")]
        public string DestinationsFilterMarkOptions(int[] states)
        {
            Filter filter = new Filter("destinations");
            filter.MarkOptions(states);
            Thread.Sleep(500);

            string title = filter.FindTitle().GetAttribute("innerText");
            Thread.Sleep(500);
            filter.ClearAllFilters();

            return title;
        }


        [TestCase(new int[] { 1, 0, 0, 0 }, Result = "Seasons1")]
        [TestCase(new int[] { 0, 1, 0, 1 }, Result = "Seasons2")]
        [TestCase(new int[] { 1, 0, 1, 1 }, Result = "Seasons3")]
        [TestCase(new int[] { 1, 1, 1, 1 }, Result = "Seasons4")]
        public string SeasonsFilterMarkOptions(int[] states)
        {
            Filter filter = new Filter("seasons");
            filter.MarkOptions(states);
            Thread.Sleep(500);

            string title = filter.FindTitle().GetAttribute("innerText");
            Thread.Sleep(500);
            filter.ClearAllFilters();

            return title;
        }

        [TestCase(new int[] { 1, 0, 0, 0, 0, 0, 0 }, Result = "Attractions1")]
        [TestCase(new int[] { 0, 1, 0, 0, 0, 1, 0 }, Result = "Attractions2")]
        [TestCase(new int[] { 1, 0, 0, 1, 0, 0, 1 }, Result = "Attractions3")]
        [TestCase(new int[] { 0, 1, 1, 0, 1, 1, 0 }, Result = "Attractions4")]
        [TestCase(new int[] { 1, 0, 1, 1, 1, 0, 1 }, Result = "Attractions5")]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 0 }, Result = "Attractions6")]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1 }, Result = "Attractions7")]


        public string AttractionsFilterMarkOptions(int[] states)
        {
            Filter filter = new Filter("attractions");
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
