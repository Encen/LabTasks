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

namespace automaionTask1
{
    class Bing : SearchEngines
    {
        public Bing(IWebDriver driver) : base(driver) { }

        protected override IWebElement NextPageButton => throw new NotImplementedException();
        protected override string xpathOfSearchedElement => throw new NotImplementedException();

        protected override string stringToSearch { get; }
        protected override IWebElement SearchField { get; }

        protected override string xpathOfPageNumber => throw new NotImplementedException();

        protected override string xpathOfNextPageButton => throw new NotImplementedException();
    }
}
