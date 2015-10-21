using System;
using System.Text;
using System.Collections.Generic;

using OpenQA.Selenium;
using NUnit.Framework;
using Settings;
using Helpers.CommonItems.Menu;
using Helpers;


namespace Pages
{
    [TestFixture]
    public class Page : TestSettings
    {
        
        public Page(string browser, string env, string pageName) :base(browser, env, pageName)
        {  }

        
        [Test]
        public void Menu_IsPresent()
        {
            Assert.IsNotNull(new Menu().Panel);
        }

        [Test]
        public void Logo_IsPresent()
        {
            Assert.IsNotNull(new Menu().Logo);
        }

        [Test]
        public void PrimaryMenuItems_ArePresent()
        {
            Assert.GreaterOrEqual(new Menu().PrimaryItems.Count, 5);
        }

        [Test]
        public void SecondaryMenuItems_ArePresent()
        {
            Assert.GreaterOrEqual(new Menu().SecondaryItems.Count, 6);
        }

        [Test]
        public void LanguageSelector_IsPresent()
        {
            Assert.IsNotNull(new Menu().LanguageSelector);
        }
        
        
    }
}
