using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace HighchartsTest.Confing
{
    class DriverConfig
    {
        public static IWebDriver GetDriver(DriverTypes driverName)
            => driverName switch
            {
                DriverTypes.Chrome => (IWebDriver)new ChromeDriver(),
                DriverTypes.Firefox => new FirefoxDriver(),
                _ => new ChromeDriver()
            };
    }
}
