using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using Settings;
using Helpers;


namespace Helpers.CommonItems
{
    public class Footer : PageObject
    {
        public IWebElement FooterPanel;
        public List<IWebElement> SocialIcons;
        public List<IWebElement> SocialIconsText;
        public IWebElement FooterInfoList;
        public IWebElement Copyright;
        public List<IWebElement> LogoListItems;
        public IWebElement ArrowUp;

        public Footer()
        {
            this.FooterPanel = FindItem("FooterPanel");
            this.SocialIcons = FindItems("SocialIcons");
            this.SocialIconsText = FindItems("SocialIconsText");
            this.FooterInfoList = FindItem("FooterInfoList");
            this.Copyright = FindItem("Copyright");
            this.LogoListItems = FindItems("LogoListItems");
            this.ArrowUp = FindItem("ArrowUp");
        }
    }
}
