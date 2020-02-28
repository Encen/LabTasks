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
    class AliExpress : Ecomerces
    {
        public AliExpress(IWebDriver driver) : base(driver) { }

        protected override string currentUrl => "https://aliexpress.ru/";
        protected IWebElement NewUserNotificaiton => driver.FindElement(By.XPath("//*[@class='newuser-container']"));
        protected override IWebElement DesiredCategory => driver.FindElement(By.XPath("//*[contains(text(), 'Компьютеры и оргтехника')]"));
        protected override IWebElement DesiredSubcategory => driver.FindElement(By.XPath("//a[contains(text(), 'Ноутбуки')] "));
        protected override IWebElement MinValueField => driver.FindElement(By.XPath("//*[@class='next-input next-small min-price']"));
        protected override IWebElement SubmitFilterButton => driver.FindElement(By.XPath("//*[@class='ui-button narrow-go']"));
        protected IWebElement MyProfile => driver.FindElement(By.XPath("//*[@class='ng-item nav-pinfo-item nav-user-account']"));
        protected IWebElement SignInButton => driver.FindElement(By.XPath(".//*[@class='sign-btn']")); 
        protected IWebElement LoginField => driver.FindElement(By.XPath(".//*[@id='fm-login-id']"));
        protected IWebElement PasswordField => driver.FindElement(By.XPath("//*[@id='fm-login-password']"));
        protected IWebElement closeAdButton => driver.FindElement(By.XPath("//*[@class='close-layer']"));
        protected override string XpathOfFoundedElements => "//*[@class='price-current']";
        protected override IList<IWebElement> FoundedElements => driver.FindElements(By.XPath("//*[@class='price-current']"));
        protected string Login => "kv4jobszxc@gmail.com";
        protected string Password => "password";
        protected override int priceForFilter => 25000;


        public void OpenMainPage()
        {
            OpenPage();
        }
        public void SearchAndApplyFilter()
        {
            ChooseCategory();
            ChooseSubcategory();
        }
        public void CheckFilterWorksCorrectly()
        {
            ApplyFilter();
            CheckFilterWork();
        }

        public void closeAd()
        {
            if (IsAdExist())
            {
                closeAdButton.Click();
            }
        }
        public bool IsAdExist()
        {    
            try
            {
                Helper.wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@class='newuser-container']")));
                driver.FindElement(By.XPath("//*[@class='newuser-container']"));
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public void SignIn()
        {
            
            Helper.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='user-account-port']")));
            new Actions(driver).MoveToElement(MyProfile);
            MyProfile.Click();
            new Actions(driver).MoveToElement(SignInButton);
            Helper.wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@class='sign-btn']")));
            SignInButton.Click();
            Helper.wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@class='ui-window ui-window-normal ui-window-transition pc-dialog tel-dialog']")));
            Helper.wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='fm-login-id']")));
            LoginField.Click();
            LoginField.Clear();
            LoginField.SendKeys(Login);
            PasswordField.Click();
            PasswordField.Clear();
            PasswordField.SendKeys(Password);
        }
    }
}