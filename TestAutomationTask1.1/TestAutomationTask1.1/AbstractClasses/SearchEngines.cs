using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;
using OpenQA.Selenium.Support.PageObjects;
using System.IO;

namespace automaionTask1
{
   abstract class SearchEngines : BasePage
    {
        public SearchEngines(IWebDriver driver) : base(driver) { }

        protected abstract string xpathOfSearchedElement { get; }
        protected  abstract string stringToSearch { get; }
        protected abstract IWebElement SearchField { get; }
        protected abstract IWebElement NextPageButton { get; }
        public bool FindElementIfExists()
        {
            try
            {
                driver.FindElement(By.XPath(xpathOfSearchedElement));
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public void SearchText()
        {
            RandomUsefulMethods.GoToPage(currentUrl);
            SearchField.SendKeys(stringToSearch);
            SearchField.SendKeys(Keys.Return);
        }
        public void SearchElement(string xpath)
        {
            while (true)
            {
                if (FindElementIfExists())
                {
                    IWebElement NumberOfPage = driver.FindElement(By.XPath(xpath));
                    string currentPage = NumberOfPage.Text;
                    TestContext.Out.WriteLine(currentPage);
                    break;
                }
                else
                {
                    NextPageButton.Click();
                }
            }
        }

       
    }
}
