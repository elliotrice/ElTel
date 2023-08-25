using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class AssignLeave
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;
        
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
        }
        
        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        
        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }
        
        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [TestMethod]
        public void TheAssignLeaveTest()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys("Admin");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("admin123");
            driver.FindElement(By.CssSelector(".oxd-form")).Submit();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index");
            driver.FindElement(By.XPath("//div[@id='app']/div/div/aside/nav/div[2]/ul/li[3]/a/span")).Click();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/leave/viewLeaveList");
            driver.FindElement(By.LinkText("Assign Leave")).Click();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/leave/assignLeave");
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div/div/div/div/div[2]/div/div/input")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div/div/div/div/div[2]/div/div/input")).Clear();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div/div/div/div/div[2]/div/div/input")).SendKeys("John Smith");
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div[2]/div/div/div/div[2]/div/div/div[2]/i")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div[3]/div/div/div/div[2]/div/div/i")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div[3]/div/div/div/div[2]/div/div[2]/div/div/button[2]/i")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div[3]/div/div/div/div[2]/div/div[2]/div/div[3]/div[28]/div")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div[3]/div/div[2]/div/div[2]/div/div/i")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div[3]/div/div[2]/div/div[2]/div/div[2]/div/div/button[2]")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div[3]/div/div[2]/div/div[2]/div/div[2]/div/div[3]/div[3]/div")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div[4]/div/div/div/div[2]/div/div/div[2]/i")).Click();
            driver.FindElement(By.CssSelector("i.oxd-icon.bi-caret-up-fill.oxd-select-text--arrow")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div[4]/div/div[2]/div/div[2]/div/div/div[2]/i")).Click();
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.CssSelector("button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-button-margin")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div/div/header/div/div[2]/ul/li/span")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
