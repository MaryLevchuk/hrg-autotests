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
    public class InspirationStep6 : TestSettings
    {
        public ItemActions action;
        public Step5 step5;
        public InspirationStep6() : base("chrome", "preprod")
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

            step5.SelectArticleFrom(step5.FilteredArticles, step5.GenerateRandomNumber(step5.FilteredArticles.Count));
            action.WaitUntilElementLoadedByCss(Locators.ArticleBackgroundImg);

            List<IWebElement> relatedArticlesList = step5.GetRelatedArticlesList();
            step5.SelectArticleFrom(relatedArticlesList, step5.GenerateRandomNumber(relatedArticlesList.Count));
            action.WaitUntilElementLoadedByCss(Locators.ArticleBackgroundImg);
        }

        [Test]
        public void _RelatedArticlesArePresent()
        {
            List<IWebElement> relatedArticles = step5.GetRelatedArticlesList();
            Assert.Greater(relatedArticles.Count, 2);
        }

        [Test]
        public void RelatedArticle_OpenedIn_FindATrip_Menu()
        {
            string activeMenuItemText = driver.FindElement(By.CssSelector(Locators.ActiveMenuItem)).Text;
            Assert.AreEqual(activeMenuItemText.ToLower(), "Find a trip".ToLower());
        }
    }
}
