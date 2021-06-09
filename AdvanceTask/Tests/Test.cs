using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AdvanceTask.Pages;
using AdvanceTask.Utility;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

namespace AdvanceTask
{
     class Tests : CommonDriver
    {
        public static ExtentTest _test;
        public static ExtentReports _extent;
        public static string BasePath = Resource.Resource1.BasePath;

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
         _extent.Flush();
         }

        [SetUp]
        public void SetUpBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(BasePath);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CloseBrowser()
        {
           
            driver.Quit();
        }

        [TestCase(2)]
        [TestCase(3)]
        [Category("Registration")]
        public void Register(int rownum)
        {
            Register Obj1 = new Register(driver, rownum);
            Obj1.RegisterAccount(driver);
        }

        [TestCase(2)]
        [Category("Login")]
        public void Login(int rownum)
        {
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            //TestContext.WriteLine(Obj1.Name);
            Obj1.LoginValidation();
        }

            [TestCase(2), Order(1)]
        [Category("Description")]
        public void AddDescription(int rownum)
        {
            _test = _extent.CreateTest("Add Description");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            ProfilePage obj5 = new ProfilePage(driver, rownum);
            obj5.AddDesCriptionDetails(driver);
            obj5.ValidateAddDesCriptionDetails(driver);
            
        }

        [TestCase(2), Order(1)]
        [Category("Language")]
        public void AddLanguages(int rownum)
        {
            _test = _extent.CreateTest("Add Language details");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            ProfilePage obj6 = new ProfilePage(driver, rownum);
            obj6.AddLanguageDetails(driver);
            obj6.ValidateAddLanguageDetails(driver);
            
        }

        [TestCase(2), Order(2)]
        [Category("Language")]
        public void EditLanguages(int rownum)
        {
            _test = _extent.CreateTest("Edit Language");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            ProfilePage obj9 = new ProfilePage(driver, rownum);
            obj9.EditLanguageDetails(driver);
            obj9.ValidateEditLanguageDetails(driver);
            
        }

        [TestCase(2), Order(3)]
        [Category("Language")]
        public void DeleteLanguages(int rownum)
        {
            _test = _extent.CreateTest("Delete Language");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            ProfilePage obj10 = new ProfilePage(driver, rownum);
            obj10.DeleteLanguageDetails(driver);
           
        }
        [TestCase(2), Order(1)]
        [Category("Skills")]
        public void AddSkills(int rownum)
        {
            _test = _extent.CreateTest("Add Skills");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            ProfilePage obj7 = new ProfilePage(driver, rownum);
            obj7.AddSkillDetails(driver);
            obj7.ValidateAddSkillDetails(driver);
           
        }

        [TestCase(2), Order(2)]
        [Category("Skills")]
        public void EditSkills(int rownum)
        {
            _test = _extent.CreateTest("Edit Description");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            ProfilePage obj11 = new ProfilePage(driver, rownum);
            obj11.EditSkillDetails(driver);
            obj11.ValidateEditSkillDetails(driver);
           
        }
        [TestCase(2), Order(3)]
        [Category("Skills")]
        public void DeleteSkills(int rownum)
        {
            _test = _extent.CreateTest("Delete Skills");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            ProfilePage obj11 = new ProfilePage(driver, rownum);
            obj11.DeleteSkillDetails(driver);
           
        }
        [TestCase(2), Order(1)]
        [Category("Education")]
        public void AddEducation(int rownum)
        {
            _test = _extent.CreateTest("Add Education");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            ProfilePage obj8 = new ProfilePage(driver, rownum);
            obj8.EducationDetails(driver);
            obj8.ValidateEducationDetails(driver);
          
        }
        [TestCase(2), Order(2)]
        [Category("Education")]
        public void EditEducation(int rownum)
        {
            _test = _extent.CreateTest("Edit Education");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            ProfilePage obj8 = new ProfilePage(driver, rownum);
            obj8.EditEducation(driver);
            obj8.ValidateEditEducation(driver);
       
        }
        [TestCase(2), Order(3)]
        [Category("Education")]
        public void DeleteEducation(int rownum)
        {
            _test = _extent.CreateTest("Delete Education");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            ProfilePage obj8 = new ProfilePage(driver, rownum);
            obj8.DeleteEducation(driver);
            obj8.ValidateDeleteEducation(driver);
            obj8.FinalValidation(driver);

        }
        [TestCase(2), Order(1)]
        [Category("Certificate")]
        public void AddCerticate(int rownum)
        {
            _test = _extent.CreateTest("Add Certiifcate");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            ProfilePage obj7 = new ProfilePage(driver, rownum);
            obj7.CertificationDetails(driver);
            obj7.ValidateCertificationDetails(driver);
           
        }

        [TestCase(2), Order(2)]
        [Category("Certificate")]
        public void EditCerticate(int rownum)
        {
            _test = _extent.CreateTest("Edit Certificate");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            ProfilePage obj7 = new ProfilePage(driver, rownum);
            obj7.EditCertificateDetails(driver);
            obj7.ValidateEditCertificate(driver);
              
        }

        [TestCase(2), Order(3)]
        [Category("Certificate")]
        public void DeleteCerticate(int rownum)
        {
            _test = _extent.CreateTest("Delete Certificate");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            ProfilePage obj7 = new ProfilePage(driver, rownum);
            obj7.DeleteCerticateDetails(driver);
            obj7.ValidateDeleteCertificate(driver);
            
        }

        [TestCase(2)]
        [TestCase(5)]
        [Category("SkillShare Add")]
        public void AddSkillShareSkillExchangeActive(int rownum)
        {
            _test = _extent.CreateTest("Add Shareskill with Service Enabled");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            ShareSkill Obj2 = new ShareSkill(driver,rownum);
            _test.Log(Status.Info, "ShareSkill Page is Opened");
            Obj2.ShareSkillPage();
            Obj2.SelectCategory();
            Obj2.SelectSubCategory();
            Obj2.EnterTag();
            Obj2.LocationTypeOnsite();
            Obj2.ServiceTypeOne_off();
            Obj2.ShareSkillPageRemaining();
            Obj2.SkillExchange();
            Obj2.ActiveShareSkill();
            Obj2.SaveShareSkill();
            _test.Log(Status.Info, "ShareSkill is Saved");
            Thread.Sleep(3000);
            Managelisting Obj3 = new Managelisting(driver,rownum);
            Obj3.ManageListingsActive();
            _test.Log(Status.Pass, "Assert Pass as condition is True and Manage listing is Active");
        }

        [TestCase(3)]
        [TestCase(6)]
        [Category("SkillShare Add")]
        public void AddSkillShareCreditHidden(int rownum)
        {
            _test = _extent.CreateTest("Share Skill with Service Disabled");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            ShareSkill Obj2 = new ShareSkill(driver,rownum);
            _test.Log(Status.Info, "ShareSkill Page is Opened");
            Obj2.ShareSkillPage();
            Obj2.SelectCategory();
            Obj2.SelectSubCategory();
            Obj2.EnterTag();
            Obj2.LocationTypeOnLine();
            Obj2.ServicetypeHourly();
            Obj2.ShareSkillPageRemaining();
            Obj2.SkillExchange();
            Obj2.HiddenshareSkill();
            Obj2.SaveShareSkill();
            _test.Log(Status.Info, "ShareSkill is Saved");
            Thread.Sleep(3000);
            Managelisting Obj3 = new Managelisting(driver,rownum);
            Obj3.ManageListingHidden();
            _test.Log(Status.Pass, "Assert Pass as condition is True and Manage listing is Hidden");
        }

        [TestCase(4)]
        [Category("SkillShare Edit")]
        public void EditSkillShareCreditHidden(int rownum)
        {
            _test = _extent.CreateTest("Edit Share Skill with Skill Trade as Skill Exchange and change it to Credit");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            Managelisting Obj3 = new Managelisting(driver,rownum);
            Obj3.NavigateManageListing();
            Obj3.EditManageListing();
            ShareSkill Obj2 = new ShareSkill(driver,rownum);
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

        [TestCase(2)]
        [Category("SkillShare Delete")]
        public void DeleteSkillShareCreditHidden(int rownum)
        {
            _test = _extent.CreateTest("Edit Share Skill with Skill Trade as Skill Exchange and change it to Credit");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            Managelisting Obj3 = new Managelisting(driver, rownum);
            Obj3.NavigateManageListing();
            Obj3.DeleteManageListing();
        }
            [TestCase(2)]
        [Category("Notification")]
        public void LoadMore(int rownum)

        {
            _test = _extent.CreateTest("Validate Load More Functionality");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            Notification obj1 = new Notification(driver);
            obj1.NotificationPage();
            obj1.ValidateLoadMore();
            Assert.Pass("All the data on Notification Page is loaded");
        }

        [TestCase(2)]
        [Category("Notification")]

        public void ShowLess(int rownum)
        {
            _test = _extent.CreateTest("Validate Show Less Functionality");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver,rownum);
            Obj1.LoginPage(driver);
            _test.Log(Status.Info, "User Loggedin Successfully");
            Notification obj2 = new Notification(driver);
            obj2.NotificationPage();
            obj2.ValidateLoadMore();
            obj2.ValidateShowLess();
        }

        [TestCase(2)]
        [Category("Search")]
        public void Searchskill(int rownum)
        {
            _test = _extent.CreateTest("Validate Search Skill using Category");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            _test.Log(Status.Info, "User Loggedin Successfully");
            SearchSkill Search = new SearchSkill(driver, 2);
            Search.SearchSkillCategory();
        }

        [TestCase(2)]
        [Category("Search")]
        public void SearchskillSubCategory(int rownum)
        {
            _test = _extent.CreateTest("Validate Search Skill using Subategory");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            _test.Log(Status.Info, "User Loggedin Successfully");
            SearchSkill Search = new SearchSkill(driver, 2);
            Search.SearchSkillCategory();
        }

        [TestCase(2)]
        [Category("Chat")]
        public void ChatHistory(int rownum)
        {
            _test = _extent.CreateTest("Validate Search Skill using Category");
            _test.Log(Status.Info, "Browser Initialisation");
            Login Obj1 = new Login(driver, rownum);
            Obj1.LoginPage(driver);
            _test.Log(Status.Info, "User Loggedin Successfully");
            Chat Obj2 = new Chat(driver);
            Obj2.ChatHistory();
            _test.Log(Status.Pass, "Chat History is displayed");
        }
        }
}