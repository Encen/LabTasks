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
    abstract class Ecomerces : BasePage
    {
        public Ecomerces(IWebDriver driver) : base(driver) { }

        protected abstract IWebElement DesiredCategory { get; }

        protected abstract IWebElement DesiredSubcategory { get; }

        protected abstract IWebElement MinValueField { get; }

        protected abstract IWebElement SubmitFilterButton { get; }

        protected abstract string XpathOfFoundedElements { get; }
        protected abstract IList<IWebElement> FoundedElements { get; }

        protected abstract int priceForFilter { get; }

        List<string> prices;

        List<int> pricesAsInt;

        public void ChooseCategory()
        {
            RandomUsefulMethods.GoToPage(currentUrl);
            DesiredCategory.Click();
            
        }
        public void ChooseSubcategory()
        {
            DesiredSubcategory.Click();
        }
        public void ApplyFilter()
        {
            MinValueField.Clear();
            MinValueField.Click();
            MinValueField.SendKeys(priceForFilter.ToString());
            SubmitFilterButton.Click();
        }

        public void CheckFilterWork()
        {
            Helper.wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy((By.XPath(XpathOfFoundedElements))));
            prices = new List<string>();
            pricesAsInt = new List<int>();
            foreach (var i in FoundedElements)
            {
                prices.Add(RandomUsefulMethods.RemoveWhitespace(i.Text));
            }
            for (int i = 0; i < prices.Count; i++)
            {
                Console.WriteLine(prices[i]);
            }
            pricesAsInt = prices.Select(int.Parse).ToList();
            for (int i = 0; i < pricesAsInt.Count; i++)
            {
                if (pricesAsInt[i] < priceForFilter)
                {
                    throw new Exception("filter doesn't work correctly");
                }
            }
        }
    }
}
