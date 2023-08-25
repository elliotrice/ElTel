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
    public class AddEmployee
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
        public void TheAddEmployeeTest()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com");
            driver.FindElement(By.Name("username")).Click();
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys("Admin");
            driver.FindElement(By.Name("password")).Click();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("admin123");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index");
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/pim/viewEmployeeList");
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div[2]/div/button/i")).Click();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/pim/addEmployee");
            driver.FindElement(By.Name("firstName")).Click();
            driver.FindElement(By.Name("firstName")).Clear();
            driver.FindElement(By.Name("firstName")).SendKeys("John");
            driver.FindElement(By.Name("lastName")).Click();
            driver.FindElement(By.Name("lastName")).Clear();
            driver.FindElement(By.Name("lastName")).SendKeys("Rice");
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div/div[2]/div[2]/div/label/span")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div/div[2]/div[3]/div/div/div/div[2]/input")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div/div[2]/div[3]/div/div/div/div[2]/input")).Clear();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div/div[2]/div[3]/div/div/div/div[2]/input")).SendKeys("johnrice");
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div/div[2]/div[3]/div/div[2]/div/div[2]/div/div[2]/div/label")).Click();
            driver.FindElement(By.XPath("//input[@type='password']")).Click();
            driver.FindElement(By.XPath("//input[@type='password']")).Clear();
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("knobhead123");
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div/div[2]/div[4]/div/div[2]/div/div[2]/input")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div/div[2]/div[4]/div/div[2]/div/div[2]/input")).Clear();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/form/div/div[2]/div[4]/div/div[2]/div/div[2]/input")).SendKeys("knobhead123");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/pim/viewPersonalDetails/empNumber/87");
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/pim/viewPersonalDetails/empNumber/87");
            driver.FindElement(By.LinkText("Employee List")).Click();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/pim/viewEmployeeList");
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/div[2]/form/div/div/div/div/div[2]/div/div/input")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/div[2]/form/div/div/div/div/div[2]/div/div/input")).Clear();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div/div[2]/form/div/div/div/div/div[2]/div/div/input")).SendKeys("rice");
            driver.FindElement(By.CssSelector(".oxd-form")).Submit();
            driver.FindElement(By.CssSelector("button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div/div[2]/div[2]/div/div[2]/div[3]/div/div[2]/div/div/div[3]/div")).Click();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/pim/viewPersonalDetails/empNumber/75");
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
