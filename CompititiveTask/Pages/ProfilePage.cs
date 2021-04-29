using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using CompititiveTask.Utility;
using AventStack.ExtentReports.Model;

namespace CompititiveTask.Pages
{
    class ProfilePage
    {
        private IWebDriver driver;
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
        public IWebElement CollegeName => driver.FindElement(By.Name("instituteName"));
        public SelectElement Country => new SelectElement(driver.FindElement(By.Name("country")));
        public IWebElement Degree => driver.FindElement(By.Name("degree"));
        public SelectElement title => new SelectElement(driver.FindElement(By.Name("title")));
        public SelectElement YearOfGraduation => new SelectElement(driver.FindElement(By.Name("yearOfGraduation")));
        public IWebElement NavigateCertification => driver.FindElement(By.XPath("//*[@class='item'][text()='Certifications']"));
        public IWebElement AddCertifications => driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//thead/tr/th[4]/div"));
        public IWebElement Certificate => driver.FindElement(By.Name("certificationName"));  
        public IWebElement CertificationFrom => driver.FindElement(By.Name("certificationFrom"));
        public SelectElement CertificationYear => new SelectElement(driver.FindElement(By.Name("certificationYear")));
        public IWebElement CertifcationSaved => driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//tbody/tr[1]/td[1]"));

        public void AddDesCriptionDetails(IWebDriver driver)
        {
            this.driver = driver;
            Actions Hover = new Actions(driver);
            Hover.Click(AddDescription).Perform();
            AddText.Clear();
            AddText.SendKeys("Testing descritiopnnnn");
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
            Name.SendKeys("English");
            Level.SelectByValue("Conversational");
            Add.Click();
        }

        public void ValidateAddLanguageDetails(IWebDriver driver)
        {
            this.driver = driver;
            WaitClass.ElementPresent(driver, "CssSelector", "tbody tr td:nth-child(1)");
            String Language = NameSaved.Text;
            TestContext.Out.WriteLine(Language);
            TestContext.Out.WriteLine(Notification.Text);
            WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            Assert.That(Notification.Text == Language + " " + "has been added to your languages");
        }
        public void EditLanguageDetails(IWebDriver driver)
        {
            this.driver = driver;
            EditLanguage.Click();
            Name.Clear();
            Name.SendKeys("Test");
            Level.SelectByValue("Conversational");
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
            this.driver = driver;
            NavigateSkill.Click();
            AddSkill.Click();
            Name.SendKeys("Java");
            Level.SelectByValue("Intermediate");
            Add.Click();
        }

        public void ValidateAddSkillDetails(IWebDriver driver)
        {
            this.driver = driver;
            WaitClass.ElementPresent(driver, "XPath", "//div[@class='ui bottom attached tab segment tooltip-target active']//tbody[1]/tr[1]/td[1]");
            String Skills = SkillSaved.Text;
            WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            TestContext.WriteLine(Skills);
            Assert.That(Notification.Text == Skills + " " + "has been added to your skills");
        }
        public void EditSkillDetails(IWebDriver driver)
        {
            this.driver = driver;
            NavigateSkill.Click();
            EditSkill.Click();
            Name.Clear();
            Name.SendKeys("java");
            Level.SelectByValue("Intermediate");
            UpdateSkill.Click();
        }

        public void ValidateEditSkillDetails(IWebDriver driver)
        {
            this.driver = driver;
            WaitClass.ElementPresent(driver, "XPath", "//div[@class='ui bottom attached tab segment tooltip-target active']//tbody[1]/tr[1]/td[1]");
            String Skills = SkillSaved.Text;
            TestContext.WriteLine(Skills);
            WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            Assert.That(Notification.Text == Skills + " " + "has been updated to your skills");
        }
        public void DeleteSkillDetails(IWebDriver driver)
        {
            this.driver = driver;
            WaitClass.ElementPresent(driver, "XPath", "//div[@class='ui bottom attached tab segment tooltip-target active']//tbody[1]/tr[1]/td[1]");
            String Skills = SkillSaved.Text;
            DeleteSkill.Click();
            WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            Assert.That(Notification.Text == Skills + " " + "has been deleted from your languages");
        }



        public void EducationDetails(IWebDriver driver)
        {
            this.driver = driver;
            NavigateEducation.Click();
            AddEducation.Click();
            CollegeName.SendKeys("Mumbai University");
            Country.SelectByValue("India");
            title.SelectByValue("B.Tech");
            Degree.SendKeys("Electronics");
            YearOfGraduation.SelectByValue("2013");
            Add.Click();
        }
        public void ValidateEducationDetails(IWebDriver driver)
        {
            this.driver = driver;
            WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            Assert.That(Notification.Text == "Education has been added");
        }


        public void CertificationDetails(IWebDriver driver)
        {
            this.driver = driver;
          //  WaitClass.ElementPresent(driver, "XPath", "//*[@class='item'][text()='Certifications']");
            NavigateCertification.Click();
            AddCertifications.Click();
            Certificate.SendKeys("Javga");
            CertificationFrom.SendKeys("Intermediate");
            CertificationYear.SelectByValue("2013");
            Add.Click();
        }
        public void ValidateCertificationDetails(IWebDriver driver)
        {
            this.driver = driver;
            WaitClass.ElementPresent(driver, "XPath", "//div[@class='ui bottom attached tab segment tooltip-target active']//tbody");
            String Certifcate = CertifcationSaved.Text;
            TestContext.WriteLine(Certifcate);
            WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
            Assert.That(Notification.Text == Certifcate + " " + "has been added to your certification");
        }
    }
}
