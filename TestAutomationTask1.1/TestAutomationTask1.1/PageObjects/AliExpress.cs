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
        protected override IWebElement DesiredCategory => driver.FindElement(By.XPath("//*[contains(text(), 'Компьютеры и офис')]"));
        protected override IWebElement DesiredSubcategory => driver.FindElement(By.XPath("//a[contains(text(), 'Ноутбуки')] "));
        protected override IWebElement MinValueField => driver.FindElement(By.XPath("//*[@placeholder='мин']"));
        protected override IWebElement SubmitFilterButton => driver.FindElement(By.XPath("//*[@class='ui-button narrow-go']"));
        protected IWebElement MyProfile => driver.FindElement(By.XPath("//*[@class='ng-item nav-pinfo-item nav-user-account']"));
        protected IWebElement SignInButton => driver.FindElement(By.XPath("//*[@class='sign-btn']")); 
        protected IWebElement LoginField => driver.FindElement(By.XPath("//*[@id='fm-login-id']"));
        protected IWebElement PasswordField => driver.FindElement(By.XPath("//*[@id='fm-login-password']"));
        protected IWebElement closeAdButton => driver.FindElement(By.XPath("//*[@class='close-layer']"));
        protected IWebElement IFrame => driver.FindElement(By.XPath("//iframe[@id='alibaba-login-box']"));
        protected IWebElement SubmitLoginButton => driver.FindElement(By.XPath("//*[@type='submit']"));
        protected override IWebElement SearchField => driver.FindElement(By.XPath("//input[@class='search-key']"));
        protected override IWebElement SubmitSearchButton => driver.FindElement(By.XPath("//input[@class='search-key']"));
        protected override string XpathOfFoundedElements => "//*[@class='price-current']";
        protected override IList<IWebElement> FoundedElements => driver.FindElements(By.XPath("//*[@class='search-button']"));
        protected string Login => "kv4jobszxc@gmail.com";
        protected string Password => "password";
        protected string ToSearch => "Ноутбук";
        protected override int priceForFilter => 25000;

        

        public void OpenMainPage()
        {
            OpenPage();
        }
        public void SearchDesiredComponent()
        {
            closeAd();
            closeAd();
            SearchCategory(ToSearch);
            closeAd();
        }
        public void CheckFilterWorksCorrectly()
        {
            closeAd();
            Helper.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@placeholder='мин']")));
            ApplyFilter();
            CheckFilterWork();
        }
        public void closeAd()
        {
            if (IsAdExist())
            {
                Helper.wait.Until(ExpectedConditions.ElementToBeClickable(closeAdButton));
                closeAdButton.Click();
            }
        }
        public bool IsAdExist()
        {    
            try
            {
                //Helper.wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@class='newuser-container']")));
                driver.FindElement(By.XPath("//*[@class='newuser-container']"));
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
        public void SingInClick()
        {
            SignInButton.Click();
            if (SignInButton.Displayed)
            {
                SingInClick();
            }
        }
        public void SignIn()
        {
            Helper.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='user-account-port']")));
            new Actions(driver).MoveToElement(MyProfile);
            closeAd();
            MyProfile.Click();
            new Actions(driver).MoveToElement(SignInButton);
            Helper.wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@class='sign-btn']")));
            SingInClick();
            Helper.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//iframe[@id='alibaba-login-box']")));
            driver.SwitchTo().Frame(IFrame);
            Helper.wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='fm-login-id']")));
            LoginField.Click();
            LoginField.Clear();
            LoginField.SendKeys(Login);
            PasswordField.Click();
            PasswordField.Clear();
            PasswordField.SendKeys(Password);
            SubmitLoginButton.Click();
            driver.SwitchTo().DefaultContent();
        }
    }
}