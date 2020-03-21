using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HighchartsTest.Confing
{
    internal class Helper
    {
        internal static IWebDriver driver { get; set; }
        internal static WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = DriverConfig.GetDriver(DriverTypes.Chrome);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

      
    }
}
