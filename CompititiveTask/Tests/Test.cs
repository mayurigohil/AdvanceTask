using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CompititiveTask.Pages;
using CompititiveTask.Utility;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

namespace CompititiveTask
{
     class Tests : CommonDriver
    {
        public static ExtentTest _test;
        public static ExtentReports _extent;
        public IWebDriver _driver;
        [OneTimeSetUp]
        protected void Setup()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = (projectPath + "Reports\\ExtentReport.html");
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Host Name", "LocalHost");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("UserName", "Mayuri Gohil");
        }
        [OneTimeTearDown]
        protected void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == TestStatus.Failed)
            {
                _test.Log(Status.Fail, stackTrace + errorMessage);
                _test.Log(Status.Fail, "Snapshot below: " + CommonDriver.SaveScreenshot(driver, "Share Skill Failed"));
            }
           
            _extent.Flush();
           
        }
        [SetUp]
        public void SetUpBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
           
        }

        [TearDown]

        public void CloseBrowser()
        {
            driver.Quit();

        }

        [Test]
        [Category("SkillShare")]
        public void AddSkillShareSkillExchangeActive()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login();
            Obj1.LoginPage(driver);
            ShareSkill Obj2 = new ShareSkill(driver);
            _test.Log(Status.Info, "ShareSkill Page is Opened");
            Obj2.ShareSkillPage();
            Obj2.SelectCategory();
            Obj2.SelectSubCategory();
            Obj2.EnterTag();
            Obj2.ShareSkillPageRemaining();
            Obj2.SkillExchange();
            Obj2.ActiveShareSkill();
            Obj2.SaveShareSkill();
            _test.Log(Status.Info, "ShareSkill is Saved");
            Thread.Sleep(3000);
            Managelisting Obj3 = new Managelisting(driver);
            Obj3.ManageListingsActive();
            _test.Log(Status.Pass, "Assert Pass as condition is True and Manage listing is Active");

        }

        [Test]
        [Category("SkillShare")]
        public void AddSkillShareCreditHidden()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login();
            Obj1.LoginPage(driver);
            ShareSkill Obj2 = new ShareSkill(driver);
            _test.Log(Status.Info, "ShareSkill Page is Opened");
            Obj2.ShareSkillPage();
            Obj2.SelectCategory();
            Obj2.SelectSubCategory();
            Obj2.EnterTag();
            Obj2.ShareSkillPageRemaining();
            Obj2.SkillExchange();
            Obj2.HiddenshareSkill();
            Obj2.SaveShareSkill();
            _test.Log(Status.Info, "ShareSkill is Saved");
            Thread.Sleep(3000);
            Managelisting Obj3 = new Managelisting(driver);
            Obj3.ManageListingHidden();
            _test.Log(Status.Pass, "Assert Pass as condition is True and Manage listing is Hidden");
        }

        [Test]
        [Category("SkillShare")]
        public void EditSkillShareCreditHidden()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login();
            Obj1.LoginPage(driver);
            Managelisting Obj3 = new Managelisting(driver);
            Obj3.NavigateManageListing();
            Obj3.EditManageListing();
            ShareSkill Obj2 = new ShareSkill(driver);
            _test.Log(Status.Info, "ShareSkill Page is Opened");
            Obj2.EditTitle();
            Obj2.SelectCategory();
            Obj2.SelectSubCategory();
            Obj2.EditTag();
            Obj2.LocationTypeOnLine();
            Obj2.ServicetypeHourly();
            Obj2.ShareSkillPageRemaining();
            Obj2.EditCreditExchange();
            Obj2.ActiveShareSkill();
            Obj2.SaveShareSkill();
            _test.Log(Status.Info, "ShareSkill is Saved");
            Thread.Sleep(3000);
            Obj3.ValidateEditManageListing();
            _test.Log(Status.Pass, "Assert Pass as condition is True and Manage listing is Hidden");
        }

    }
}