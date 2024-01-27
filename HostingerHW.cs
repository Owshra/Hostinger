using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

/* Commented out code doesn't work, left it there to show what I tried
   Login details changed for privacy while posting in public Git repository
*/


namespace Ausra.Kasiulionyte.Hostinger
{
    public class Tests
    {
        private IWebDriver driver;
        private string validEmail = "validEmail";
        private string validPassword = "validPassword"; // I know hardcoded passwords are not okay

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.hostinger.com/";
        }

        [Test]
        public void TestHappyPath()
        {
            TestLogin(validEmail, validPassword);
        }
        private void TestLogin(string email, string password)
        {
            CssClicker(By.Id("hgr-topmenu-login"));
            driver.FindElement(By.Id("email-input")).SendKeys(email);
            driver.FindElement(By.Id("password-input")).SendKeys(password);
            driver.FindElement(By.Id("password-input")).Submit();

            //    IWebElement accountInfo = driver.FindElement(By.LinkText("Hi, Test Enthusiast"));
            //    Assert.AreEqual("Hi, Test Enthusiast", accountInfo.Text);

            driver.Url = "https://hpanel.hostinger.com/servers/plans";
            //    driver.FindElement(By.LinkText("Select")).Click();
            //    CssClicker(By.Id("hpanel_tracking-vps-plans-select_button"));

        }
        private void CssClicker(By selector)
        {
            driver.FindElement(selector).Click();
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}