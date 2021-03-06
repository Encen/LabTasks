﻿using System;
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
    public class DriverConfig
    {
        public static IWebDriver GetDriver(DriverTypes driverName)
            => driverName switch
            {
                DriverTypes.Chrome => (IWebDriver)new ChromeDriver(),
                DriverTypes.Firefox => (IWebDriver)new FirefoxDriver(),
                _ => new ChromeDriver()
            };
    }
}
