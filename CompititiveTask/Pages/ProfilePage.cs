using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using AdvanceTask.Utility;
using AventStack.ExtentReports.Model;
using System.IO;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;

namespace AdvanceTask.Pages
{
    class ProfilePage
    {
        private IWebDriver driver;
        int rownum = 0;
        string filepath = "Data\\TestData.xlsx";
        public static ExtentTest _test;

        public ProfilePage(IWebDriver driver, int rownum )
        {
            this.driver = driver;
            this.rownum = rownum;
            ExcelLibHelper.PopulateInDataCollection((Path.Combine(AppDomain.CurrentDomain.BaseDirectory + filepath)), "Profile");
        }

        public static String Certifcate;
        public static String NotificationText;
        public IWebElement AddDescription => driver.FindElement(By.CssSelector("i[class='outline write icon']"));
        public IWebElement AddText => driver.FindElement(By.Name("value"));
        public IWebElement SaveDescription => driver.FindElement(By.XPath("//button[@type='button']"));
        public IWebElement Notification => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        public IWebElement AddLanguage => driver.FindElement(By.CssSelector("div[class='ui teal button ']"));
        public IWebElement EditLanguage => driver.FindElement(By.XPath("//td[@class='right aligned']//i[@class='outline write icon']"));
        public IWebElement DeleteLanguage => driver.FindElement(By.XPath("//i[@class='remove icon']"));
        public IWebElement Name => driver.FindElement(By.Name("name"));
        public SelectElement Level => new SelectElement(driver.FindElement(By.Name("level")));
        public IWebElement Add => driver.FindElement(By.XPath("//input[@value='Add']"));
        public IWebElement Update => driver.FindElement(By.XPath("//input[@value='Update']"));
        public IWebElement NameSaved => driver.FindElement(By.CssSelector("tbody tr td:nth-child(1)"));
        public IWebElement NavigateSkill => driver.FindElement(By.XPath("//a[normalize-space()='Skills']"));
        public IWebElement AddSkill => driver.FindElement(By.CssSelector("div[class='ui teal button']"));
        public IWebElement SkillSaved => driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//tbody[1]/tr[1]/td[1]"));
        public IWebElement EditSkill => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
        public IWebElement UpdateSkill => driver.FindElement(By.XPath("//input[@value='Update']"));
        public IWebElement DeleteSkill => driver.FindElement(By.XPath("//i[@class='remove icon']"));
        public IWebElement NavigateEducation => driver.FindElement(By.XPath("//a[normalize-space()='Education']"));
        public IWebElement AddEducation => driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//thead/tr/th[6]/div"));
        public IWebElement EditEducationDetails => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i"));
        public IWebElement UpdateEducation => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]"));
        public IWebElement DeleteEducationDetails => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i"));
        public IWebElement CollegeName => driver.FindElement(By.Name("instituteName"));
        public SelectElement Country => new SelectElement(driver.FindElement(By.Name("country")));
        public IWebElement Degree => driver.FindElement(By.Name("degree"));
        public SelectElement title => new SelectElement(driver.FindElement(By.Name("title")));
        public SelectElement YearOfGraduation => new SelectElement(driver.FindElement(By.Name("yearOfGraduation")));
        public IWebElement NavigateCertification => driver.FindElement(By.XPath("//*[@class='item'][text()='Certifications']"));
        public IWebElement AddCertifications => driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//thead/tr/th[4]/div"));
        public IWebElement EditCertificate => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[1]/i"));
        public IWebElement UpdateCertificate => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
        public IWebElement DeleteCertificate => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i"));
        public IWebElement Certificate => driver.FindElement(By.Name("certificationName"));  
        public IWebElement CertificationFrom => driver.FindElement(By.Name("certificationFrom"));
        public SelectElement CertificationYear => new SelectElement(driver.FindElement(By.Name("certificationYear")));
        public IWebElement CertifcationSaved => driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//tbody/tr[1]/td[1]"));

        public void AddDesCriptionDetails(IWebDriver driver)
        {
            
            Actions Hover = new Actions(driver);
            Hover.Click(AddDescription).Perform();
            AddText.Clear();
            AddText.SendKeys(ExcelLibHelper.ReadData(rownum, "Description"));
            SaveDescription.Click();
        }

        public void ValidateAddDesCriptionDetails(IWebDriver driver)
        {
            this.driver = driver;
            WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            Assert.That(Notification.Text == "Description has been saved successfully");
        }

        public void AddLanguageDetails(IWebDriver driver)
        {
            this.driver = driver;
            AddLanguage.Click();
            Name.SendKeys(ExcelLibHelper.ReadData(rownum, "Language"));
            Level.SelectByValue(ExcelLibHelper.ReadData(rownum, "Level"));
            Add.Click();
        }

        public void ValidateAddLanguageDetails(IWebDriver driver)
        {
            
                this.driver = driver;
                WaitClass.ElementPresent(driver, "CssSelector", "tbody tr td:nth-child(1)");
                String Language = NameSaved.Text;
                TestContext.Out.WriteLine(Language);
                NotificationText = Notification.Text;
                WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
                Assert.That(Notification.Text == Language + " " + "has been added to your languages");
        }

        public void EditLanguageDetails(IWebDriver driver)
        {
            this.driver = driver;
            EditLanguage.Click();
            Name.Clear();
            Name.SendKeys(ExcelLibHelper.ReadData(rownum,"Language"));
            Level.SelectByValue(ExcelLibHelper.ReadData(rownum, "Level"));
            Update.Click();
        }
        public void ValidateEditLanguageDetails(IWebDriver driver)
        {
            this.driver = driver;
            WaitClass.ElementPresent(driver, "CssSelector", "tbody tr td:nth-child(1)");
            String Language = NameSaved.Text;
            TestContext.WriteLine(Language);
            WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            Assert.That(Notification.Text == Language + " " + "has been updated to your languages");
        }
        public void DeleteLanguageDetails(IWebDriver driver)
        {
            this.driver = driver;
            WaitClass.ElementPresent(driver, "CssSelector", "tbody tr td:nth-child(1)");
            String Language = NameSaved.Text;
            DeleteLanguage.Click();
            WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            TestContext.WriteLine(Language);
            Assert.That(Notification.Text == Language + " " + "has been deleted from your languages");
        }
        public void AddSkillDetails(IWebDriver driver)
        {
           
            NavigateSkill.Click();
            AddSkill.Click();
            Name.SendKeys(ExcelLibHelper.ReadData(rownum,"Skills"));
            Level.SelectByValue(ExcelLibHelper.ReadData(rownum, "SkillLevel"));
            Add.Click();
        }

        public void ValidateAddSkillDetails(IWebDriver driver)
        {
            
            WaitClass.ElementPresent(driver, "XPath", "//div[@class='ui bottom attached tab segment tooltip-target active']//tbody[1]/tr[1]/td[1]");
            String Skills = SkillSaved.Text;
            WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            TestContext.WriteLine(Skills);
            Assert.That(Notification.Text == Skills + " " + "has been added to your skills");
        }
        public void EditSkillDetails(IWebDriver driver)
        {
            
            NavigateSkill.Click();
            EditSkill.Click();
            Name.Clear();
            Name.SendKeys(ExcelLibHelper.ReadData(rownum, "Skills"));
            Level.SelectByValue(ExcelLibHelper.ReadData(rownum, "SkillLevel"));
            UpdateSkill.Click();
        }

        public void ValidateEditSkillDetails(IWebDriver driver)
        {
            
            WaitClass.ElementPresent(driver, "XPath", "//div[@class='ui bottom attached tab segment tooltip-target active']//tbody[1]/tr[1]/td[1]");
            String Skills = SkillSaved.Text;
            TestContext.WriteLine(Skills);
            WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            Assert.That(Notification.Text == Skills + " " + "has been updated to your skills");
        }
        public void DeleteSkillDetails(IWebDriver driver)
        {
           
            WaitClass.ElementPresent(driver, "XPath", "//div[@class='ui bottom attached tab segment tooltip-target active']//tbody[1]/tr[1]/td[1]");
            String Skills = SkillSaved.Text;
            DeleteSkill.Click();
            WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            Assert.That(Notification.Text == Skills + " " + "has been deleted from your languages");
        }

        public void EducationDetails(IWebDriver driver)
        {
           
            NavigateEducation.Click();
            AddEducation.Click();
            CollegeName.SendKeys(ExcelLibHelper.ReadData(rownum, "CollegeName"));
            Country.SelectByValue(ExcelLibHelper.ReadData(rownum, "Country"));
            title.SelectByValue(ExcelLibHelper.ReadData(rownum, "CollegeTitle"));
            Degree.SendKeys(ExcelLibHelper.ReadData(rownum, "degree"));
            YearOfGraduation.SelectByValue(ExcelLibHelper.ReadData(rownum, "Year"));
            Add.Click();
        }
        public void ValidateEducationDetails(IWebDriver driver)
        {
            
            WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            Assert.That(Notification.Text == "Education has been added");
        }

        public void EditEducation(IWebDriver driver)
        {
            NavigateEducation.Click();
            EditEducationDetails.Click();
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]");
            CollegeName.SendKeys(ExcelLibHelper.ReadData(rownum, "CollegeName"));
            Country.SelectByValue(ExcelLibHelper.ReadData(rownum, "Country"));
            title.SelectByValue(ExcelLibHelper.ReadData(rownum, "CollegeTitle"));
            Degree.SendKeys(ExcelLibHelper.ReadData(rownum, "degree"));
            YearOfGraduation.SelectByValue(ExcelLibHelper.ReadData(rownum, "Year"));
            UpdateEducation.Click();
        }

        public void ValidateEditEducation(IWebDriver driver)
        {
            WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            Assert.That(Notification.Text == "Education as been updated");
        }

        public void DeleteEducation(IWebDriver driver)
        {
            NavigateEducation.Click();
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]");
            DeleteEducationDetails.Click();
        }

        public void ValidateDeleteEducation(IWebDriver driver)
        {
            WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            Assert.That(Notification.Text == "Education entry successfully removed");
        }

        public void CertificationDetails(IWebDriver driver)
        {
            NavigateCertification.Click();
            AddCertifications.Click();
            Certificate.SendKeys(ExcelLibHelper.ReadData(rownum, "Certificate"));
            CertificationFrom.SendKeys(ExcelLibHelper.ReadData(rownum, "From"));
            CertificationYear.SelectByValue(ExcelLibHelper.ReadData(rownum, "CertificationYear"));
            Add.Click();
        }

        public void ValidateCertificationDetails(IWebDriver driver)
        {
            WaitClass.ElementPresent(driver, "XPath", "//div[@class='ui bottom attached tab segment tooltip-target active']//tbody");
            String Certifcate = CertifcationSaved.Text;
            TestContext.WriteLine(Certifcate);
            WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            Assert.That(Notification.Text == Certifcate + " " + "has been added to your certification");
        }

        public void EditCertificateDetails(IWebDriver driver)
        {
            NavigateCertification.Click();
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]");
            EditCertificate.Click();
            Certificate.SendKeys(ExcelLibHelper.ReadData(rownum, "Certificate"));
            CertificationFrom.SendKeys(ExcelLibHelper.ReadData(rownum, "From"));
            CertificationYear.SelectByValue(ExcelLibHelper.ReadData(rownum, "CertificationYear"));
            UpdateCertificate.Click();
        }

        public void ValidateEditCertificate(IWebDriver driver)
        {
            WaitClass.ElementPresent(driver, "XPath", "//div[@class='ui bottom attached tab segment tooltip-target active']//tbody");
            String Certifcate = CertifcationSaved.Text;
            TestContext.WriteLine(Certifcate);
            WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            Assert.That(Notification.Text == Certifcate + " " + "has been updated to your certification");
        }

        public void DeleteCerticateDetails(IWebDriver driver)
        {
            NavigateCertification.Click();
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]");
            Certifcate = CertifcationSaved.Text;
            DeleteCertificate.Click();
           
        }
        public void ValidateDeleteCertificate(IWebDriver driver)
        {
            
           WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            Assert.That(Notification.Text == Certifcate + " " + "has been deleted from your certification");
        }

        public void FinalValidation(IWebDriver driver)
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == TestStatus.Failed)
            {
                _test.Log(Status.Fail, errorMessage + ProfilePage.NotificationText);
                _test.Log(Status.Fail, "Snapshot below: " + CommonDriver.SaveScreenshot(driver, "Share Skill Failed"));
            }
        }
    }
}
