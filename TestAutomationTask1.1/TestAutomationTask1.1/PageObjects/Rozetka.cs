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
        protected override string currentUrl { get => "https://rozetka.com.ua/"; }

        protected override IWebElement DesiredCategory => driver.FindElement(By.XPath("//a[@class='menu-categories__link'][contains(text(),'Ноутбуки и компьютеры')]"));
        protected override IWebElement DesiredSubcategory => driver.FindElement(By.XPath("//*[@alt='Ноутбуки']"));
        protected override IWebElement MinValueField => driver.FindElement(By.XPath("//input[@formcontrolname='min']"));
        protected override IWebElement SubmitFilterButton => driver.FindElement(By.XPath("//*[@type='submit']"));
        protected override IList<IWebElement> FoundedElements => driver.FindElements(By.XPath("//*[@class='goods-tile__price-value']"));
        protected override string XpathOfFoundedElements => "//*[@class='goods-tile__price-value']";
        protected override int priceForFilter => 25000;

        private IWebElement FooterOfThePage => driver.FindElement(By.XPath("//*[@class='app-rz-footer app-footer']"));
        

        public void SearchAndApplyFilter()
        {
            ChooseCategory();
            Helper.wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@class='app-rz-footer app-footer']")));
            FooterOfThePage.Click();
            ChooseSubcategory();
           
        }
        public void CheckFilterWorksCorrectly()
        {
            ApplyFilter();
            CheckFilterWork();
        }
    }
}
