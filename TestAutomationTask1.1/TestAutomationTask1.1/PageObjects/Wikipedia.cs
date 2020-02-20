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
    class Wikipedia : Page
    {
        public Wikipedia(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//*[contains(@id,'mp-upper') or @id='mp-bottom']//img")]
        private IWebElement listOfPictures;


    }
}
