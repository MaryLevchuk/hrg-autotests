using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Settings;
using Helpers;

namespace Helpers
{
    public class HomePageStep
    {
        private IWebDriver driver;
        public IWebElement BackgroundImageDiv;
        public IWebElement Header;
        public IWebElement Intro;
        public IWebElement FindAnAdventureBtn;
        public IWebElement BestSuggestionsDiv;

        public IWebElement FooterPanel;
        public List<IWebElement> SocialIcons;
        public List<IWebElement> SocialIconsText;
        public IWebElement FooterInfoList;
        public IWebElement Copyright;
        public List<IWebElement> LogoListItems;
        public IWebElement ArrowUp;

        public IWebElement MenuPanel;
        public IWebElement Logo;
        public List<IWebElement> PrimaryItems;
        public List<IWebElement> SecondaryItems;
        public IWebElement LanguageSelector;

        public HomePageStep()
        {
            driver = TestSettings.driver;
            BackgroundImageDiv = driver.FindElement(By.CssSelector(Locators.BackgroudImageDiv));
            Header = driver.FindElement(By.CssSelector(Locators.Header));
            Intro = driver.FindElement(By.CssSelector(Locators.Intro));
            FindAnAdventureBtn = driver.FindElement(By.CssSelector(Locators.FindAnAdventureBtn));
            BestSuggestionsDiv = driver.FindElement(By.CssSelector(Locators.PromotedTravels));

            //FooterPanel = FindItemByFieldName("FooterPanel");
            //SocialIcons = FindItemsByCommonName("FooterSocialIcons");
            //SocialIconsText = FindItemsByCommonName("FooterSocialIconsText");
            //FooterInfoList = FindItemByFieldName("FooterInfoList");
            //Copyright = FindItemByFieldName("FooterCopyright");
            //LogoListItems = FindItemsByCommonName("FooterLogoListItems");
            //ArrowUp = FindItemByFieldName("FooterArrowUp");

            //MenuPanel = FindItemByName("MenuPanel");
            //Logo = FindItemByName("Logo");
            //PrimaryItems = FindItemsByCommonName("PrimaryItems");
            //SecondaryItems = FindItemsByCommonName("SecondaryItems");
            //LanguageSelector = FindItemByName("LanguageSelector");
        }

        //public IWebElement FindItemByName(string itemName)
        //{
        //    var locator = typeof(Locators).GetField(itemName).GetValue(typeof(Locators));
        //    return driver.FindElement(By.CssSelector(locator.ToString()));
        //}

        //public List<IWebElement> FindItemsByCommonName(string itemsScopeName)
        //{
        //    var locator = typeof(Locators).GetField(itemsScopeName).GetValue(typeof(Locators));
        //    return driver.FindElements(By.CssSelector(locator.ToString())).ToList();
        //}

        //public IWebElement FindElementByCss(string css)
        //{

        //    return driver.FindElement(By.CssSelector(css));
        //}

        //public List<IWebElement> FindElementsByCss(string css)
        //{
        //    return driver.FindElements(By.CssSelector(css)).ToList();
        //}

        //public object GetClassField(string field)
        //{
        //    return GetType().GetField(field).GetValue(this);
        //}

    }
}
