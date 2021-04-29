using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CompititiveTask.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace CompititiveTask.Pages
{
    class Login
    {
        private IWebDriver driver;
        
        protected ExtentReports _extent;
        
        public IWebElement SignIn => driver.FindElement(By.XPath("//a[normalize-space()='Sign In']"));
        public IWebElement EmailAddress => driver.FindElement(By.Name("email"));
        public IWebElement Password => driver.FindElement(By.Name("password"));
        public IWebElement LoginBtn => driver.FindElement(By.XPath("//button[normalize-space()='Login']"));
        public IWebElement ProfileName => driver.FindElement(By.XPath("//*[@class='item ui dropdown link'][text()='Hi ']"));

        //public void OneTimeSetUp()
        //{
          
        //    var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        //    var actualPath = path.Substring(0, path.LastIndexOf("bin"));
        //    var projectPath = new Uri(actualPath).LocalPath;
        //    Directory.CreateDirectory(projectPath.ToString() + "Reports");
        //    var reportPath = (projectPath + "Reports\\ExtentReport.html");
        //    var reporter = new ExtentHtmlReporter(reportPath);
        //    _extent = new ExtentReports();
        //    _extent.AttachReporter(reporter);
        //    _extent.AddSystemInfo("Host Name", "LocalHost");
        //    _extent.AddSystemInfo("Environment", "QA");
        //    _extent.AddSystemInfo("UserName", "TestUser");
        //}
        //public void Initalise(IWebDriver driver)
        //{
        //    this.driver = driver;
        //    driver.Navigate().GoToUrl("http://localhost:5000/Home");
        //    driver.Manage().Window.Maximize();
            
            
        //}
        public void LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            
            WaitClass.ElementPresent(driver, "XPath", "//a[normalize-space()='Sign In']");
            SignIn.Click();
            driver.SwitchTo().ActiveElement();
            ExcelLibHelper.PopulateInDataCollection(@"C:\Users\Dell\Documents\VB Feb 2021\CompititiveTask\CompititiveTask\Data\TestData.xlsx", "Credentials");
            EmailAddress.SendKeys(ExcelLibHelper.ReadData(2, "username"));
            Password.SendKeys(ExcelLibHelper.ReadData(2,"password"));
            LoginBtn.Click();
            //Thread.Sleep(3000);
            WaitClass.ElementPresent(driver, "CssSelector", "i[class='outline write icon']");
        }
    }
}
