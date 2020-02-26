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
    class AliExpress : Ecomerces
    {
        public AliExpress(IWebDriver driver) : base(driver) { }

        protected override IWebElement DesiredCategory => driver.FindElement(By.XPath("//*[contains(text(), 'Компьютеры и оргтехника')]"));

        protected override IWebElement DesiredSubcategory => driver.FindElement(By.XPath("//a[contains(text(), 'Ноутбуки')] "));

        protected override IWebElement MinValueField => driver.FindElement(By.XPath("//*[@class='next-input next-small min-price']"));

        protected override IWebElement SubmitFilterButton => driver.FindElement(By.XPath("//*[@class='ui-button narrow-go']"));

        protected override string XpathOfFoundedElements => "//*[@class='price-current']";

        protected override IList<IWebElement> FoundedElements => driver.FindElements(By.XPath("//*[@class='price-current']"));

        protected override int priceForFilter => 25000;


    }
}