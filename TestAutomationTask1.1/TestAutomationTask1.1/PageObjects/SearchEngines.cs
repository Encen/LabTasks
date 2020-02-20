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
    class SearchEngines : Page
    {
        public SearchEngines(IWebDriver driver) : base(driver) { }

        protected IWebElement NextPageButton;

        protected string xpathOfSearchedElement;

        protected string CurrentDate
        {
            get =>
DateTime.Now.ToString("dd.mm.yyy").Replace('/', '\\');
        }
        protected virtual string folderWithScreenshots { get => $"C:\\Users\\{Environment.UserName}\\Desktop\\FolderWithScreens\\{CurrentDate}\\{this.GetType().Name}"; }
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

        public void SearchElement()
        {
            while (true)
            {
                if (FindElementIfExists())
                {
                    IWebElement SearchResult = driver.FindElement(By.XPath("//*[@class='cur']"));
                    string currentPage = SearchResult.Text;
                    TestContext.Out.WriteLine(currentPage);
                    break;
                }
                else
                {
                    NextPageButton.Click();
                }
            }
        }

        public void SetTheDirectoryWithSaves()
        {
            if (!Directory.Exists(folderWithScreenshots))
            {
                Directory.CreateDirectory(folderWithScreenshots);
            }
        }
    }
}
