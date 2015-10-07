using System;
using System.Threading;
using OpenQA.Selenium;
using NUnit.Framework;
using Hurtigruten.Accepptance.Tests.Helper;

namespace Hurtigruten.Accepptance.Tests
{
    [TestFixture]
    public class AssertionTests : TestSettings
    {

        [TestCase(new int[] { 0, 0, 0, 0, 0, 0 }, Result = "Seasons0")]
        [TestCase(new int[] { 1, 0, 0, 0, 0, 0 }, Result = "Seasons1")]
        [TestCase(new int[] { 0, 0, 1, 0, 0, 0 }, Result = "Seasons1")]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 1 }, Result = "Seasons1")]
        [TestCase(new int[] { 1, 0, 1, 0, 0, 1 }, Result = "Seasons3")]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, Result = "Seasons6")]
        public string SeasonsFilterMarkOptions(int[] states)
        {
            OpenPage(this.inspirationPage);
            Filter filter = new Filter(TestSettings.driver, "seasons");
         
            filter.CheckOptions(states);
            
            Thread.Sleep(600);
            
            return filter.FindTitle().GetAttribute("innerText");
        }

        [Test]
        public void Equal()
        {
            Assert.AreEqual(5, 5);
        }
    }
    
}
