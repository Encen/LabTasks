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
    public static class RandomUsefulMethods
    {

        static IWebDriver driver;


        public static string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        public static void GoToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void TakeScreenshotOfEntirePage(string filePath)
        {
            string nameOfFile = $"{filePath}\\screenOfEntirePage.png";
            var screen = driver.TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker()));
            Image fullScreenImage = (Bitmap)((new ImageConverter()).ConvertFrom(screen));
            fullScreenImage.Save(nameOfFile);
        }

     

        public static void TakeScreenshotOfElement(string folderWithScreenshotes,IList<IWebElement> LocatorOfImages,string xpathOfImages)
        {
            for (int i = 0; i < LocatorOfImages.Count; i++)
            {
                ScreenshotMaker screenMaker = new ScreenshotMaker();
                OnlyElementDecorator onlyEleDecorator = new OnlyElementDecorator(screenMaker);
                By by = By.XPath($"xpathOfImages{i + 1}");
                onlyEleDecorator.SetElement(by);
                var ScreenInByteArr = driver.TakeScreenshot(onlyEleDecorator);
                Image ElementScreenImage = (Bitmap)((new ImageConverter()).ConvertFrom(ScreenInByteArr));
                ElementScreenImage.Save($"{folderWithScreenshotes}\\screen{i+1}.png");
            }
        }

      
    }
}

