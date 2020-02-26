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
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;
using System.IO;


namespace automaionTask1
{
    class Google : SearchEngines
    {
        public Google(IWebDriver driver) : base(driver) { }

        public override string  folderWithScreenshots { get => base.folderWithScreenshots; } 
        protected override string stringToSearch { get=>"Банк";}
        protected override string xpathOfSearchedElement { get => "//*[contains(text(),'MTB БАНК')]"; }
        protected override string currentUrl { get => "https://www.google.com/"; }
        protected override string xpathOfPageNumber => "//*[@class='cur']";
        protected override IWebElement SearchField => driver.FindElement(By.XPath("//*[@id='searchform']//input[@type='text']"));
        protected override IWebElement NextPageButton { get => driver.FindElement(By.XPath("//*[@id='pnnext']")); }
        protected override string xpathOfNextPageButton => "//*[@id='pnnext']";

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
