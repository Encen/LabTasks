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

        public override string folderWithScreenshots { get; }
        protected override string stringToSearch { get=>"Банк";}

        protected override string xpathOfSearchedElement => "//*[contains(text(),'MTB БАНК')]";

        protected override string currentUrl { get => "https://www.google.com/"; }
        string xpathOfPageNumber => "//*[@class='cur']";

        protected override IWebElement SearchField => driver.FindElement(By.XPath("//*[@id='searchform']//input[@type='text']"));

        [FindsBy(How = How.XPath, Using = "//*[@id='pnnext']")]
        protected new IWebElement NextPageButton;

        [FindsBy(How = How.XPath, Using = "xpathOfSearchedElement")]
        private IWebElement DesiredElement;

        public void FindElement()
        {
            SearchText();
            SearchElement(xpathOfSearchedElement);
        }

        public void TakeScreen()
        {
            RandomUsefulMethods.TakeScreenshotOfEntirePage(folderWithScreenshots);
        }
    }
}
