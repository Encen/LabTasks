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
    class Wikipedia : BasePage
    {
        public Wikipedia(IWebDriver driver) : base(driver) { }

        protected override string currentUrl { get => "https://en.wikipedia.org/wiki/Main_Page"; }
        public override string folderWithScreenshots { get; }
        private string xpathOfPictures => "//*[contains(@id,'mp-upper') or @id='mp-bottom']//img";

        [FindsBy(How = How.XPath, Using = "xpathOfPictures")]
        private IList<IWebElement> listOfPictures;

        public void TakeScreenOfElement()
        {             
                RandomUsefulMethods.TakeScreenshotOfElement(folderWithScreenshots,listOfPictures,xpathOfPictures);
        }

    }
}
