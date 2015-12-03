//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using OpenQA.Selenium;
//using NUnit.Framework;
//using Settings;
//using Helpers;

//namespace Helpers.ItemModels
//{
//    public class Menu : HomePageStep
//    {
//        public IWebElement Panel;
//        public IWebElement Logo;
//        public List<IWebElement> PrimaryItems;
//        public List<IWebElement> SecondaryItems;
//        public IWebElement LanguageSelector;

//        public Menu()
//        {
//            this.Panel = FindItemByFieldName("MenuPanel");
//            this.Logo = FindItemByFieldName("MenuLogo");
//            this.PrimaryItems = FindItemsByCommonName("MenuPrimaryItems");
//            this.SecondaryItems = FindItemsByCommonName("MenuSecondaryItems");
//            this.LanguageSelector = FindItemByFieldName("MenuLanguageSelector");
//        }
        
//        public string GetMenuField(string field)
//        {
//            return this.GetType().GetField(field).ToString();
//        }
        
//    }
//}
