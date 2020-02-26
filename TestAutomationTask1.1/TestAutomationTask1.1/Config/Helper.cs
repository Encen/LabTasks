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
using OpenQA.Selenium.Firefox;

namespace automaionTask1
{
    public class Helper
    {
        public static IWebDriver driver { get; set; }
        public static WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = DriverConfig.GetDriver(DriverTypes.Chrome);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
