using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
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
    public class InspirationStep5 : TestSettings
    {
        public ItemActions action;
        public Step5 step5;

        public InspirationStep5()
            : base("chrome", "preprod")
        {
            action = new ItemActions();

            OpenPageByName("homePage");
            action.WaitUntilElementLoadedByCss(Locators.Header);

            action.SelectInspirationMenu();
            action.WaitUntilElementLoadedByCss(Locators.LastVisibleArticle);

            step5 = new Step5();

            step5.MarkOptionByName("Destinations", "Norway");
            Thread.Sleep(500);

            step5.FindFilterTitleByFilterName("Attractions").Click();
            Thread.Sleep(500);

            step5.MarkOptionByName("Attractions", "Fjords");
            Thread.Sleep(500);

            action.ScrollThePageDownToTheEnd();
            Thread.Sleep(1000);
            
            action.ScrollThePageToTheElementByCss(".grid-item.wow.zoomIn.wow-animated.animated.animated");
            Thread.Sleep(1000);

            step5.FilteredArticles = step5.GetFilteredArticles();
            step5.ArticlesUrlsList = step5.GetArticlesUrls();
        }

        [Test]
        public void SelectedArticleReturnsOK()
        {
            int articlesAmount = step5.FilteredArticles.Count;
            int articleNumber = step5.GenerateRandomNumber(articlesAmount);
            string url = step5.GetURLByArticleNumber(articleNumber);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            Console.WriteLine(response.StatusCode.ToString());
            Assert.AreEqual(response.StatusCode.ToString(), "OK");
        }


    }
}
