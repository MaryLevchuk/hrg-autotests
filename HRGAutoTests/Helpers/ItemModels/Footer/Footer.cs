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
//    public class Footer : HomePageStep
//    {
//        public IWebElement FooterPanel;
//        public List<IWebElement> SocialIcons;
//        public List<IWebElement> SocialIconsText;
//        public IWebElement FooterInfoList;
//        public IWebElement Copyright;
//        public List<IWebElement> LogoListItems;
//        public IWebElement ArrowUp;

//        public Footer()
//        {
//            this.FooterPanel = FindItemByFieldName("FooterPanel");
//            this.SocialIcons = FindItemsByCommonName("FooterSocialIcons");
//            this.SocialIconsText = FindItemsByCommonName("FooterSocialIconsText");
//            this.FooterInfoList = FindItemByFieldName("FooterInfoList");
//            this.Copyright = FindItemByFieldName("FooterCopyright");
//            this.LogoListItems = FindItemsByCommonName("FooterLogoListItems");
//            this.ArrowUp = FindItemByFieldName("FooterArrowUp");
//        }
//    }
//}
