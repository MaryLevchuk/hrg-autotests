using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Settings;
using Helpers;

namespace Helpers
{
    public  class ItemActions
    {
        public IWebDriver driver;

        public ItemActions()
        {
            this.driver = TestSettings.driver;
        }

        public void MakeHovered(IWebElement item)
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(item).Build().Perform();  
        }

        public void ScrollThePageDownToTheEnd()
        {            
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        public void ScrollThePageToTheIWebElement(IWebElement item)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", item);
        }

        public void ScrollThePageToTheElementByCss(string css)
        {
            IWebElement item = driver.FindElement(By.CssSelector(css));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", item);
        }

        public List<int> ParseToIntAndTrim(string[] color_parts)
        {
            List<int> numbers = new List<int>();
            foreach (string part in color_parts.Take(3))
            {
                Console.WriteLine(part);
                int number = Int32.Parse(part.Trim());
                numbers.Add(number);
            }
            return numbers;
        }

        public string BuildHexString(int[] numbers)
        {
            string hex = "#";
            foreach (int number in numbers)
            {
                hex = hex + (number.ToString("x").Length == 1 ? String.Format("0{0}", number.ToString("x")) : number.ToString("x"));
            }
            return hex;
        }

        public string GetHexIconBackgroudColorByCssValue(string cssValue, IWebElement item)
        {
            string color = item.GetCssValue(cssValue);
            string[] numbers = color.Split('(')[1].Split(')')[0].Split(',');
            int[] int_numbers = ParseToIntAndTrim(numbers).ToArray();
            return BuildHexString(int_numbers);
        }

        public void WaitUntilElementLoadedByCss(string css)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(css)));
        }

        public void WaitUntilFoundItemLoaded(IWebElement item)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
            {
                return item;
            });

        }
        public void SelectInspirationMenu()
        {
            driver.FindElement(By.CssSelector((Locators.GetInspiredMenuItem))).Click();
        }

        public string GetResponseCodeByUrl(string url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            return response.StatusCode.ToString();

        }

        
    }
}
