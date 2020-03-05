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
using System.IO;
using System.Drawing.Imaging;

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
        public static string RemoveWhitespaceAndDash(string input)
        {
            return new string (input.ToCharArray()
                .Where(c => (!Char.IsPunctuation(c) && !Char.IsWhiteSpace(c)))
                .ToArray()).Substring(0,5);
        }
        public static void GoToPage(string url)
        {
            Helper.driver.Navigate().GoToUrl(url);
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
        public static Bitmap GetEntireScreenshot()
        {
            Bitmap stitchedImage = null;
            try
            {
                long totalwidth1 = (long)((IJavaScriptExecutor)Helper.driver).ExecuteScript("return document.body.offsetWidth");//documentElement.scrollWidth");
                long totalHeight1 = (long)((IJavaScriptExecutor)Helper.driver).ExecuteScript("return  document.body.parentNode.scrollHeight");
                int totalWidth = (int)totalwidth1;
                int totalHeight = (int)totalHeight1;
                // Get the Size of the Viewport
                long viewportWidth1 = (long)((IJavaScriptExecutor)Helper.driver).ExecuteScript("return document.body.clientWidth");//documentElement.scrollWidth");
                long viewportHeight1 = (long)((IJavaScriptExecutor)Helper.driver).ExecuteScript("return window.innerHeight");//documentElement.scrollWidth");
                int viewportWidth = (int)viewportWidth1;
                int viewportHeight = (int)viewportHeight1;
                // Split the Screen in multiple Rectangles
                List<Rectangle> rectangles = new List<Rectangle>();
                // Loop until the Total Height is reached
                for (int i = 0; i < totalHeight; i += viewportHeight)
                {
                    int newHeight = viewportHeight;
                    // Fix if the Height of the Element is too big
                    if (i + viewportHeight > totalHeight)
                    {
                        newHeight = totalHeight - i;
                    }
                    // Loop until the Total Width is reached
                    for (int ii = 0; ii < totalWidth; ii += viewportWidth)
                    {
                        int newWidth = viewportWidth;
                        // Fix if the Width of the Element is too big
                        if (ii + viewportWidth > totalWidth)
                        {
                            newWidth = totalWidth - ii;
                        }
                        // Create and add the Rectangle
                        Rectangle currRect = new Rectangle(ii, i, newWidth, newHeight);
                        rectangles.Add(currRect);
                    }
                }
                // Build the Image
                stitchedImage = new Bitmap(totalWidth, totalHeight);
                // Get all Screenshots and stitch them together
                Rectangle previous = Rectangle.Empty;
                foreach (var rectangle in rectangles)
                {
                    // Calculate the Scrolling (if needed)
                    if (previous != Rectangle.Empty)
                    {
                        int xDiff = rectangle.Right - previous.Right;
                        int yDiff = rectangle.Bottom - previous.Bottom;
                        // Scroll
                        //selenium.RunScript(String.Format("window.scrollBy({0}, {1})", xDiff, yDiff));
                        ((IJavaScriptExecutor)Helper.driver).ExecuteScript(String.Format("window.scrollBy({0}, {1})", xDiff, yDiff));
                        System.Threading.Thread.Sleep(200);
                    }
                    // Take Screenshot
                    var screenshot = ((ITakesScreenshot)Helper.driver).GetScreenshot();
                    // Build an Image out of the Screenshot
                    Image screenshotImage;
                    using (MemoryStream memStream = new MemoryStream(screenshot.AsByteArray))
                    {
                        screenshotImage = Image.FromStream(memStream);
                    }
                    // Calculate the Source Rectangle
                    Rectangle sourceRectangle = new Rectangle(viewportWidth - rectangle.Width, viewportHeight - rectangle.Height, rectangle.Width, rectangle.Height);
                    // Copy the Image
                    using (Graphics g = Graphics.FromImage(stitchedImage))
                    {
                        g.DrawImage(screenshotImage, rectangle, sourceRectangle, GraphicsUnit.Pixel);
                    }
                    // Set the Previous Rectangle
                    previous = rectangle;
                }
            }
            catch (Exception ex)
            {
                // handle
            }
            return stitchedImage;
        }
        public static void TakeScreenshotOfEntirePage(string filePath)
        {
            string nameOfFile = $"{filePath}\\screenOfEntirePage.jpeg";
            RandomUsefulMethods.GetEntireScreenshot().Save(nameOfFile,ImageFormat.Jpeg);
        }

    }
}

