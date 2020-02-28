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

namespace automaionTask1
{
    class Bing : SearchEngines
    {
        public Bing(IWebDriver driver) : base(driver) { }

        protected override string currentUrl => "https://www.bing.com/";
        protected override string xpathOfNextPageButton => "//*[@title='Next page']";
        protected override IWebElement NextPageButton => driver.FindElement(By.XPath("//*[@title='Next page']"));
        protected override string stringToSearch => "национальный парк";
        protected override string xpathOfSearchedElement => "//*[contains(text(),'Лахемаа')]";
        protected override IWebElement SearchField => driver.FindElement(By.XPath("//input[@id='sb_form_q']"));
        protected override string xpathOfPageNumber => "//*[@class='sb_pagS sb_pagS_bp b_widePag sb_bp']";

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
