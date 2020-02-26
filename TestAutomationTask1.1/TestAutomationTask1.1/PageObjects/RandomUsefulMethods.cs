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
       
        public static string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        public static void GoToPage(string url)
        {
           
            Helper.driver.Navigate().GoToUrl(url);
        }

        public static void TakeScreenshotOfEntirePage(string filePath)
        {
            string nameOfFile = $"{filePath}\\screenOfEntirePage.png";
            
            var screen = Helper.driver.TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker()));
            if (IfByteReplaced())
            {
                ByteReplace(screen);
            }
            Image fullScreenImage = (Bitmap)((new ImageConverter()).ConvertFrom(screen));
            fullScreenImage.Save(nameOfFile);
        }

     

        public static void TakeScreenshotOfElement(string folderWithScreenshotes,IList<IWebElement> LocatorOfImages,string xpathOfImages)
        {
            ScreenshotMaker screenMaker = new ScreenshotMaker();
            OnlyElementDecorator onlyEleDecorator = new OnlyElementDecorator(screenMaker);
            for (int i = 0; i < LocatorOfImages.Count; i++)
            {
                
                By by = By.XPath($"({xpathOfImages})[{i + 1}]");
                onlyEleDecorator.SetElement(by);
                
                byte[] ScreenInByteArr = Helper.driver.TakeScreenshot(onlyEleDecorator);
                Image ElementScreenImage = (Bitmap)((new ImageConverter()).ConvertFrom(ScreenInByteArr));
                ElementScreenImage.Save($"{folderWithScreenshotes}\\screen{i+1}.png");
            }
        }

        public static byte[] ByteReplace(byte[] kek)
        {
            string str = System.Text.Encoding.Default.GetString(kek);
            string ReplacedString = str.Replace("$", "document");
            kek = System.Text.Encoding.UTF8.GetBytes(ReplacedString);
            return kek;
        }

        public static bool IfByteReplaced()
        {
            try
            {
                var screen = Helper.driver.TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker()));

            }
            catch (OpenQA.Selenium.WebDriverException)
            {
                return true;
            }
            return false;
        }

      
    }
}

