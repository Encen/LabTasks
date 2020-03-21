using HighchartsTest.Confing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighchartsTest.PageElement
{
    class HighchartsPage
    {
        private IWebDriver driver;
        private IWebElement visibilityOfCurrentChart;
        private IList<IWebElement> CurrentChartPath;
        internal string CurrentUrl => "https://www.highcharts.com/demo/combo-timeline";
        private IList<IWebElement> BlueChart => driver.FindElements(By.XPath("//*[contains(@class,'point highcharts-color-0')]"));
        private IList<IWebElement> BlackChart => driver.FindElements(By.XPath("//*[contains(@class,'point highcharts-color-1')]"));
        private IList<IWebElement> GreenChart => driver.FindElements(By.XPath("//*[contains(@class,'point highcharts-color-2')]"));
        //private IWebElement FrameWithCookies => driver.FindElement(By.XPath("//iframe[@title='Blank'][2]"));
        private IWebElement AcceptUsingCookies => driver.FindElement(By.XPath("//*[@id='CybotCookiebotDialogBodyLevelButtonAccept']"));
        private IWebElement moreOptionsButton => driver.FindElement(By.XPath("//*[@aria-label='View chart menu']"));
        private IWebElement ViewDataTableButton => driver.FindElement(By.XPath("//*[contains(text(),'View data table')]"));
        private IWebElement visibilityOfBlueChart => driver.FindElement(By.XPath("//*[@aria-label='Toggle visibility of Google search for highcharts']"));
        private IWebElement visibilityOfBlackChart => driver.FindElement(By.XPath("//*[@aria-label='Toggle visibility of Revenue']"));
        private IWebElement visibilityOfGreenChart => driver.FindElement(By.XPath("//*[@aria-label='Toggle visibility of Highsoft employees']"));
        private IList<IWebElement> FirstColumnOfAnyChartTable => driver.FindElements(By.XPath("//th[@scope='row' and following-sibling::*[@class='number']]"));
        private IList<IWebElement> SecondColumnOfAnyChartTable => driver.FindElements(By.XPath("//td[@class='number']"));
        private IList<IWebElement> TextFromChart => driver.FindElements(By.XPath("//*[@x='8']//*[not(contains(@style,'fill'))]"));
        internal List<string> TextFromChartInString;
        internal List<string> ActualDataFromChart { get; set; }
        internal Dictionary<string, string> ExpectedDataFromTables { get; set; }

        public void OpenMainPage()
        {
            Helper.driver.Navigate().GoToUrl(CurrentUrl);
        }
        public string GetURL()
        {
            string actualURL = driver.Url;
            return actualURL;
        }
        public void AcceptCookies()
        {
            // driver.SwitchTo().Frame(FrameWithCookies);
            Helper.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='CybotCookiebotDialogBodyLevelButtonAccept']")));
            AcceptUsingCookies.Click();
            //Actions action = new Actions(driver);
            //action.MoveToElement(AcceptUsingCookies).Release().Perform();
            //driver.SwitchTo().DefaultContent();
        }
        public void ViewDataTable()
        {
            moreOptionsButton.Click();
            ViewDataTableButton.Click();
        }
        public Dictionary<string, string> GetDataFromTable()
        {
            List<string> keys = new List<string>();
            List<string> values = new List<string>();
            ExpectedDataFromTables = new Dictionary<string, string>();
            foreach (var i in FirstColumnOfAnyChartTable)
            {
                
                if (CurrentChartPath != GreenChart)
                {
                    keys.Add(DateTime.Parse(i.Text).ToString("MMM yyyy"));
                }
            }
            foreach (var i in SecondColumnOfAnyChartTable)
            {
                values.Add(i.Text);
            }
            for (int i = 0; i < SecondColumnOfAnyChartTable.Count; i++)
            {
                ExpectedDataFromTables.Add(keys[i], values[i]);
            }
            return ExpectedDataFromTables;
        }
        public void ChooseChart(PossibleCharts ChartToInteractWith)
        {
            if (ChartToInteractWith == PossibleCharts.Black)
            {
                visibilityOfCurrentChart = visibilityOfBlackChart;
                CurrentChartPath = BlackChart;
            }
            else if (ChartToInteractWith == PossibleCharts.Green)
            {
                visibilityOfCurrentChart = visibilityOfGreenChart;
                CurrentChartPath = GreenChart;
            }
            else if (ChartToInteractWith == PossibleCharts.Blue)
            {
                visibilityOfCurrentChart = visibilityOfBlueChart;
                CurrentChartPath = BlueChart;
            }
        }
        public void EnableOrDisableChart()
        {
            visibilityOfCurrentChart.Click();
        }
        public void HoverOverElement(IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();
        }
        public List<string> HoverOverWholeChart()
        {
           TextFromChartInString = new List<string>(60);
           string DataInOneString = null;
           ActualDataFromChart = new List<string>();
            
            foreach (var i in CurrentChartPath)
            {
                for (int j = 0; j <= TextFromChart.Count; j++) { 

                    if (TextFromChart.Count == 0) { break; }
                        
                    TextFromChartInString[j] = ($"{TextFromChart[j].Text} ");
                }

                HoverOverElement(i);
               
                DataInOneString = String.Join(String.Empty, TextFromChartInString.ToArray());
                ActualDataFromChart.Add(DataInOneString);
                DataInOneString = null;
            }
            return ActualDataFromChart;
        }

        public HighchartsPage()
        {
            driver = Helper.driver;
        }
    }
}
