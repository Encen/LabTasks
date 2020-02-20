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
using SeleniumExtras.PageObjects;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace automaionTask1
{
    public class Page
    {
        protected static IWebDriver driver;
        protected WebDriverWait wait;

        protected virtual string currentUrl { get; set; }
        public Page(IWebDriver _driver)
        {
            driver = _driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void TakeScreenshotOfEntirePage(string filePath)
        {
            var screen = driver.TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker()));
            Image fullScreenImage = (Bitmap)((new ImageConverter()).ConvertFrom(screen));
            fullScreenImage.Save(filePath);
        }

        public void TakeScreenshotOfElement(string filePath)
        {

        }
    }
}
