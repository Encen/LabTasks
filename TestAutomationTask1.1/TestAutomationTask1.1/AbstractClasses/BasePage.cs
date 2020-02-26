using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace automaionTask1
{
    public abstract class BasePage
    {
        protected static IWebDriver driver;
        protected WebDriverWait wait;
        
        protected string CurrentDate
        {
            get =>
            DateTime.Now.ToString("dd.MM.yyy").Replace('/', '\\');
        }
        public virtual string folderWithScreenshots { get => $"C:\\Users\\{Environment.UserName}\\Desktop\\FolderWithScreens\\{CurrentDate}\\{this.GetType().Name}"; }
        protected virtual string currentUrl { get; set; }
        public BasePage(IWebDriver _driver)
        {
            driver = _driver;
            PageFactory.InitElements(driver, this);
        }

        public void SetTheDirectoryWithSaves()
        {
            if (!Directory.Exists(folderWithScreenshots))
            {
                Directory.CreateDirectory(folderWithScreenshots);
            }
        }



    }
}
