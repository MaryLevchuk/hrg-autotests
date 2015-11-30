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
using Helpers;

namespace Helpers.Inspiration
{
    public class Step3 : Step2
    {
        public Step3() : base()
        {  }

        public IWebElement FindFilterTitleByFilterName(string filterName)
        {
            IWebElement result = null;
            foreach (IWebElement title in FilterTitlesList)
            {
                string titleString = title.GetAttribute("innerText");
                //Console.WriteLine(titleString);
                if (titleString.Contains(filterName))
                {
                    result = title;
                    break;
                }
            }
            return result;     
        }

        public IWebElement FindFilterIconByFilterName(string filterName)
        {
            IWebElement result = null;
            foreach (IWebElement icon in FilterIconsList)
            {
                string attributeClassName = icon.GetAttribute("className");
                
                if (attributeClassName.Contains(filterName.ToLower()))
                {
                    result = icon;
                    break;
                }
            }
            return result;
        }
        
        public IWebElement FindOptionByName(string filterName, string optionName)
        {
            IWebElement result = null;
            List<IWebElement> optionsList = GetOptionsForFilter(filterName);
            foreach (IWebElement option in optionsList)
            {
                if (option.GetAttribute("innerText").Contains(optionName))
                {
                    result = option;
                }
            }
            return result;
        }
        
        public void MarkOptionByName(string filterName, string optionName)
        {
            FindOptionByName(filterName, optionName).Click();
        }

        public string GetFilterColor(string filterName)
        {
            string color = FindFilterTitleByFilterName(filterName).GetAttribute("box-shadow");
            //Console.WriteLine(color);
            return color;
        }

        public string GetFilterTitleIndex_Of(string filterName)
        {
            string filterTitle = FindFilterTitleByFilterName(filterName).GetAttribute("innerText");
            string index = SplitStringByMultiCharacterDelimiter(filterTitle, filterName)[1];
            return index;
        }

        public string[] SplitStringByMultiCharacterDelimiter(string source, string delimiter)
        {
            string[] stringSeparators = new string[] { delimiter };
            string[] result = source.Split(stringSeparators, StringSplitOptions.None);
            return result;
        }
    }
}
