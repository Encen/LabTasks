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
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;
using System.IO;

namespace automaionTask1
{
    [TestFixture]
    class GoogleTest: Helper
    {
        [Test]
        public void GoogleTest1()
        {
            Google google = new Google(driver);
            google.FindElement();
            google.TakeScreen();
        }
    }
}
