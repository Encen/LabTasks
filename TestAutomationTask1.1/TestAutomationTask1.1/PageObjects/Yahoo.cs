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
    class Yahoo : SearchEngines
    {
        public Yahoo(IWebDriver driver):base(driver){ }

        protected override string currentUrl { get => "https://www.yahoo.com/"; }
        protected override IWebElement SearchField => driver.FindElement(By.XPath("//input[@id='header-search-input']"));
        protected override string xpathOfSearchedElement => "//a[contains(text(),'РАНАРА')]";
        protected override string xpathOfNextPageButton => "//*[@class='next']";
        protected override IWebElement NextPageButton => driver.FindElement(By.XPath("//*[@class='next']"));
        protected override string stringToSearch => "ветеринарная клиника";
        protected override string xpathOfPageNumber => "//*[@class='compPagination']//strong";

        public void FindElement()
        {
            SearchText();
            SearchElement(xpathOfPageNumber);
        }

        public void TakeScreen()
        {
            SetTheDirectoryWithSaves();
            RandomUsefulMethods.TakeScreenshotOfEntirePage(folderWithScreenshots);
        }
    }
}

