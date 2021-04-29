
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Linq;



namespace CompititiveTask.Utility
{
    class SetUp:CommonDriver
    {
        protected ExtentTest _test;
        protected ExtentReports _extent;
        public IWebDriver driver;
      
      //  [OneTimeSetUp]
        protected void Setup(IWebDriver driver)
        {
            this.driver = driver;
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + "Reports\\ExtentReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Host Name", "LocalHost");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("UserName", "TestUser");
        }

       // [SetUp]
        public void SetUpBrowser(IWebDriver driver)
        {
            
            this.driver = driver;
            driver.Navigate().GoToUrl("http://localhost:5000/Home");
            driver.Manage().Window.Maximize();
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }

      //  [TearDown]
        public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
        {
            
            var folderLocation = AppDomain.CurrentDomain.BaseDirectory;

            TestContext.WriteLine(folderLocation);

            if (!System.IO.Directory.Exists(folderLocation))
            {
                System.IO.Directory.CreateDirectory(folderLocation);
            }

            var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = new StringBuilder(folderLocation);

            fileName.Append(ScreenShotFileName);
            fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
            //fileName.Append(DateTime.Now.ToString("dd-mm-yyyym_ss"));
            fileName.Append(".jpeg");
            screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
            return fileName.ToString();
        }


    }
}
