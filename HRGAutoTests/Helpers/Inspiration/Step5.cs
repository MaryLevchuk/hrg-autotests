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
using Helpers;

namespace Helpers.Inspiration
{
    public class Step5 : Step3and4
    {
        public List<IWebElement> ArticlesUrlsList;
        public List<IWebElement> FilteredArticles;

        public ItemActions action;
        public IWebDriver driver;
        public Step5() : base()
        {
            driver = TestSettings.driver;
            action = new ItemActions();
         }

        public List<IWebElement> GetArticlesUrls()
        {
            ArticlesUrlsList = driver.FindElements(By.CssSelector((Locators.ArticlesUrlsList))).ToList();
            return ArticlesUrlsList;
        }

        public List<IWebElement> GetFilteredArticles()
        {
            List<IWebElement> FilteredArticles = driver.FindElements(By.CssSelector((Locators.FilteredArticles))).ToList();
            return FilteredArticles;
        }
        public int GenerateRandomNumber(int upperLimit)
        {
            return new Random().Next(0, upperLimit);
        }

        public void SelectArticleFrom(List<IWebElement> listOfArticles, int articleNumber)
        {
                IWebElement article = listOfArticles[articleNumber];
                action.ScrollThePageToTheIWebElement(article);
                action.WaitUntilFoundItemLoaded(article);
                article.Click();
        }

        public string GetURLByArticleNumber(int articleNumber)
        {
            string url = ArticlesUrlsList[articleNumber].GetAttribute("href");
            return url; 
        }

        public void PressViewRelatedTravelSuggestionsLink()
        {
            driver.FindElement(By.CssSelector(Locators.ViewRelatedTravelSuggestionsLink)).Click();
        }

        public List<IWebElement> GetRelatedArticlesList()
        {
            return driver.FindElements(By.CssSelector(Locators.RelatedArticlesList)).ToList();
        }

        //public string GetResponseCodeByUrl(string url)
        //{
        //    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
        //    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
        //    return response.StatusCode.ToString();

        //}
    }
}
