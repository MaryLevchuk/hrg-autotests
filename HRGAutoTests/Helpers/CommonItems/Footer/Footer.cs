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
        public List<IWebElement> SocialIconsInscription;
        public IWebElement InfoList;
        public IWebElement Copyright;
        public List<IWebElement> FooterLogoListItems;
        public IWebElement FooterArrowUp;

        public Footer()
        {
        
        }
    }
}
