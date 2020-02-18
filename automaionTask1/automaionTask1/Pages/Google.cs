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

        protected override string folderWithScreenshots
        { get => $""; }
        protected string stringToSearch { get; set; }

        protected override string currentUrl { get => "https://www.google.com/"; }

        [FindsBy(How = How.XPath, Using = "//*[@id='searchform']//input[@type='text']")]
        private IWebElement SearchField;

        [FindsBy(How = How.XPath, Using = "//*[@id='pnnext']")]
        protected new IWebElement NextPageButton;

        [FindsBy(How=How.XPath,Using = "//*[contains(text(),'MTB БАНК')]")]
        private IWebElement DesiredElement;

        
    }
}
