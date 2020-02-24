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
    class Rozetka : Ecomerces
    {
        public Rozetka(IWebDriver driver) : base(driver) { }


        [FindsBy(How = How.XPath, Using = "//a[@class='menu-categories__link'][contains(text(),'Ноутбуки и компьютеры')]")]
        private IWebElement LaptopsAndComputers;

        [FindsBy(How = How.XPath, Using = "//*[@class='app-rz-footer app-footer']")]
        private IWebElement FooterOfThePage;

        [FindsBy(How = How.XPath, Using = "//*[@alt='Ноутбуки']")]
        private IWebElement Laptops;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='min']")]
        private IWebElement MinValueField;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='min']")]
        private IWebElement SubmitFilterButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='goods-tile__price-value']")]
        private IList <IWebElement> ListOfPrices;

    }
}
