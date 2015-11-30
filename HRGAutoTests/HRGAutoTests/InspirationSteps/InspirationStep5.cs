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
    public class InspirationStep5 : InspirationStep3and4
    {
        public List<IWebElement> InspirationArticles;
        public InspirationStep5()
            : base()
        {
           OpenPageByName("inspirationPage");
           InspirationArticles = FindArticles();
           SelectOneRandomArticle(InspirationArticles);
        }

        public List<IWebElement> FindArticles()
        {
            return driver.FindElements(By.CssSelector((Locators.ArticlesList))).ToList();
        }

        public void SelectOneRandomArticle(List<IWebElement> listOfArticles)
        {
            int n = listOfArticles.Count;
            int m = new Random().Next(0, n);
            listOfArticles[m].Click();
            //listOfArticles[new Random().Next(0, listOfArticles.Count)].Click();
            Thread.Sleep(1000);
            Console.WriteLine("n = {0}", n.ToString());
            Console.WriteLine("m = {0}", m.ToString());
        }
    }
}
