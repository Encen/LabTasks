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
    [TestFixture]
    public class UnitTest1:Helper
    {
       


        
       


        [Test]
        public void FacebookLoginCheck()
        {
            string login = "asd";
            string password = "asd";
            url = "https://uk-ua.facebook.com/";
            driver.Navigate().GoToUrl(url);
            IWebElement LoginInput = driver.FindElement(By.XPath("//*[@type='email']"));
            LoginInput.SendKeys(login);
            IWebElement PasswordInput = driver.FindElement(By.XPath("//*[@id='pass']"));
            PasswordInput.SendKeys(password);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@class='login_form_login_button uiButton uiButtonConfirm']")));
            IWebElement SubmitButton = driver.FindElement(By.XPath("//*[@class='login_form_login_button uiButton uiButtonConfirm']"));
            SubmitButton.Click();
            string expectedURL = driver.Url;
            Assert.AreNotEqual(url, expectedURL,$"We expect that page redirects to {expectedURL}");
        }

        [Test]
        public void WikiExercise1()
        {
            url = "https://en.wikipedia.org/wiki/Main_Page";
            driver.Navigate().GoToUrl(url);
            string TitleName = driver.Title;
            int LengthOfTitle = TitleName.Length;
            Console.WriteLine(TitleName);
            Console.WriteLine(LengthOfTitle);
            string currentURL = driver.Url;
            Assert.AreEqual(url,currentURL, $"We verify that current page adress is{url}");
            string currentPageSource = driver.PageSource;
            int LengthOfPageSource = currentPageSource.Length;
            TestContext.Out.WriteLine(LengthOfPageSource);
        }
        [Test]
        public void WikiExercise2()
        {
            url = "https://en.wikipedia.org/wiki/Main_Page";
            driver.Navigate().GoToUrl(url);
            IWebElement Help = driver.FindElement(By.LinkText("Help"));
            Help.Click();
            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().GoToUrl(url);
            driver.Navigate().Refresh();
        }
        [Test]
        public void Exercise3()
        {
            driver.Manage().Window.Size = new System.Drawing.Size(500, 600);
            driver.Manage().Window.Position = new System.Drawing.Point(200, 150);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void GoogleTask()
        {
            url = "https://www.google.com/";
            string xpath = "//*[contains(text(),'MTB БАНК')]";
            string folderWithScreenshotes = "C:\\Users\\Vladyslav_Kyrianov\\source\\repos\\screens\\screen.png";
            driver.Navigate().GoToUrl(url);
            IWebElement SearchField = driver.FindElement(By.XPath("//*[@id='searchform']//input[@type='text']"));
            SearchField.SendKeys("Банк");
            SearchField.SendKeys(Keys.Return);
            IWebElement NextPageButton = driver.FindElement(By.XPath("//*[@id='pnnext']"));
            while (true)
            {
                if (FindElementIfExists(xpath))
                {
                    IWebElement SearchResult = driver.FindElement(By.XPath("//*[@class='cur']"));
                    string currentPage = SearchResult.Text;
                    TestContext.Out.WriteLine(currentPage);
                    break;
                }
                else
                {
                    NextPageButton.Click();
                }
            }
            var screen = driver.TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker()));
            Image fullScreenImage = (Bitmap)((new ImageConverter()).ConvertFrom(screen));
            fullScreenImage.Save(folderWithScreenshotes);
        }


        public static bool FindElementIfExists(string elementName)
        {
            try 
            {
                driver.FindElement(By.XPath(elementName));
            }
            catch(NoSuchElementException) 
            {
                return false;
            }
            return true;
        }

        [Test]
        public void Wikipedia()
        {
            url = "https://en.wikipedia.org/wiki/Main_Page";
            driver.Navigate().GoToUrl(url);
            ScreenshotMaker screenMaker = new ScreenshotMaker();
            OnlyElementDecorator onlyEleDecorator = new OnlyElementDecorator(screenMaker);
            IList<IWebElement> listOfPictures = driver.FindElements(By.XPath("//img"));
            
            for(int i = 0; i<listOfPictures.Count;i++)
            {
                string folderWithScreenshotes = $"C:\\Users\\Vladyslav_Kyrianov\\source\\repos\\screens\\screen{i}.png";
                string xpath = $"(//img)[{i + 1}]";
                By by = By.XPath(xpath);
                onlyEleDecorator.SetElement(by);
                var ScreenInByteArr = driver.TakeScreenshot(onlyEleDecorator);
                Image ElementScreenImage = (Bitmap)((new ImageConverter()).ConvertFrom(ScreenInByteArr));
                ElementScreenImage.Save(folderWithScreenshotes);
            }
        }

        [Test]
        public void Rozetka()
        {
           
            string minValue = "25000";
            url = "https://rozetka.com.ua/";
            driver.Navigate().GoToUrl(url);
            IWebElement LaptopsAndComputers = driver.FindElement(By.XPath(("//a[@class='menu-categories__link'][contains(text(),'Ноутбуки и компьютеры')]")));
            LaptopsAndComputers.Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@class='app-rz-footer app-footer']")));
            IWebElement footer = driver.FindElement(By.XPath("//*[@class='app-rz-footer app-footer']"));
            footer.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@alt='Ноутбуки']")));
            IWebElement Laptops = driver.FindElement(By.XPath("//*[@alt='Ноутбуки']"));
            Laptops.Click();
            IWebElement MinValueField = driver.FindElement(By.XPath("//input[@formcontrolname='min']"));
            MinValueField.Clear();
            MinValueField.SendKeys(minValue);
            IWebElement SubmitButton = driver.FindElement(By.XPath("//*[contains(text(),'Ok')][@type='submit']"));
            SubmitButton.Click();
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy((By.XPath("//*[@class='goods-tile__price-value']"))));
            IList<IWebElement> LaptopPrices = driver.FindElements(By.XPath("//*[@class='goods-tile__price-value']"));
            List<string> prices = new List<string>();
            
            List<int> INTprices = new List<int>();
            foreach (var i in LaptopPrices)
            {
                prices.Add(RemoveWhitespace(i.Text));
            }
            for (int i = 0; i < prices.Count; i++)
            {
                Console.WriteLine(prices[i]);
            }
            INTprices = prices.Select(int.Parse).ToList();
            for (int i = 0; i < INTprices.Count; i++)
            {
                if (INTprices[i] < 25000)
                {
                    throw new Exception("filter doesn't work correctly");
                }
            }
            
        }
        public static string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
