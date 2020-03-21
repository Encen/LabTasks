using HighchartsTest.Confing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighchartsTest.PageElement
{
    internal class BLL
    {
        private static HighchartsPage highchartsPage;
        public static void OpenMainPage()
        {
            highchartsPage = new HighchartsPage();
            highchartsPage.OpenMainPage();
            string actualURL = highchartsPage.GetURL();
            Assert.AreEqual(highchartsPage.CurrentUrl, actualURL, $"Expected URL is {highchartsPage.CurrentUrl} but actual is {actualURL}");
        }

        public static void HoverElementsAndGetData()
        {
            Helper.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@aria-label='Toggle visibility of Highsoft employees']")));
            highchartsPage.AcceptCookies();
            highchartsPage.ChooseChart(PossibleCharts.Blue);
            highchartsPage.EnableOrDisableChart();
            highchartsPage.ChooseChart(PossibleCharts.Green);
            highchartsPage.EnableOrDisableChart();
            highchartsPage.ChooseChart(PossibleCharts.Black);
            highchartsPage.ViewDataTable();
            highchartsPage.GetDataFromTable();
            highchartsPage.HoverOverWholeChart();
            Assert.Contains(highchartsPage.ExpectedDataFromTables, highchartsPage.ActualDataFromChart);
        }
    }
}
