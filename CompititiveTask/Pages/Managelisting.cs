using AventStack.ExtentReports;
using CompititiveTask.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CompititiveTask.Pages
{
    class Managelisting
    {
        private IWebDriver driver;

        public  string filepath = "Data\\TestData.xlsx";

        //Initialising driver through constructor
        public Managelisting(IWebDriver driver)
        {
            this.driver = driver;
        }
        //defining all the Web Element
        public IWebElement Category => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[2]"));
        public IWebElement Title => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
        public IWebElement Description => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]"));
        public IWebElement ServiceType => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[5]"));
        public IList<IWebElement> Active => driver.FindElements(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input"));

        public IWebElement View => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[1]"));

        public IWebElement SubCategory => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[2]"));
        public IWebElement StartDate => driver.FindElement(By.XPath(" //*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[1]/div/div[2]"));
        public IWebElement EndDate => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[2]/div/div[2]"));
        public IWebElement LocationType => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]"));
        public IWebElement SkillTrade => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[4]/div[2]/div/div/div[2]/span"));
        public IWebElement Credit => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[2]/label/em"));
        public IWebElement SearchText => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[1]/div[1]/input"));
        public IWebElement ManageListingNavigation => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[3]"));
        public IWebElement ManageListingfromSearch => driver.FindElement(By.XPath("//*[@id='service-search-section']/section[1]/div/a[3]"));
        public IWebElement EditManageListingButton => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i"));
        public IWebElement DescriptionText => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div/div/div/div[2]"));
        public void NavigateManageListing()
        {
            ManageListingNavigation.Click();
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i");
        }

        public void EditManageListing()
        {
            EditManageListingButton.Click();
            WaitClass.ElementPresent(driver, "Name", "title");
        }
        
          
        public  void ManageListingsActive()
        {   
            //Calling Excel library to get the data
                ExcelLibHelper.PopulateInDataCollection((Path.Combine(AppDomain.CurrentDomain.BaseDirectory + filepath)), "ShareSkill");
                var ExpectedCategory = ExcelLibHelper.ReadData(2, "Category");
                var ExpectedTitle = ExcelLibHelper.ReadData(2, "Title");
                var ExpectedDescription = ExcelLibHelper.ReadData(2, "Description");
                var ExpectedService = ExcelLibHelper.ReadData(2, "ServiceType");
                var ExpectedSubCategory = ExcelLibHelper.ReadData(2, "SubCategory");
                var ExpectedStartDate = ExcelLibHelper.ReadData(2, "StartDate");
                var ExpectedEndDate = ExcelLibHelper.ReadData(2, "EndDate");
                var ExpectedLocationType = ExcelLibHelper.ReadData(2, "LocationType");
                var ExpectedSkillTrade = ExcelLibHelper.ReadData(2, "Skill");

            //Wait for the Table to get displayed
                WaitClass.ElementPresent(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input");
          
            //Creating variables for all the data on Manage listing page
                var ActualCategory = Category.Text;
                var ActualTitle = Title.Text;
                var ActualDescription = Description.Text;
                var ActualServiceType = ServiceType.Text;
                View.Click();
                WaitClass.ElementPresent(driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[2]");
                var ActualSubCategory = SubCategory.Text;
                var SDate = StartDate.Text;
                String ActualStartDate = String.Join("", SDate.Split('-').Reverse());
                var EDate = EndDate.Text;
                String ActualEndDate = String.Join("", EDate.Split('-').Reverse());
                var ActualLocationType = LocationType.Text;
                var ActualSkillTrade = SkillTrade.Text;
            // Back to the Manage listing Page
                driver.Navigate().Back();

            //Wait for Manage listings table to get displayed
                WaitClass.ElementPresent(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input");
           
            //Create logs for Validating step
                Tests._test.Log(Status.Info, "Validating Data on Manage listing");

            //Multile Assertion to validate all the data
                Assert.Multiple(() =>
            {
                Assert.That(ActualCategory == ExpectedCategory);
                Assert.That(ActualTitle == ExpectedTitle);
                Assert.That(ActualDescription == ExpectedDescription);
                Assert.That(ActualServiceType == ExpectedService);
                Assert.True(Active.ElementAt(0).Selected);
                Assert.That(ActualSubCategory == ExpectedSubCategory);
                Assert.That(ActualStartDate == ExpectedStartDate);
                Assert.That(ActualEndDate == ExpectedEndDate);
                Assert.That(ActualLocationType == ExpectedLocationType);
                Assert.That(ActualSkillTrade == ExpectedSkillTrade);
            });
        }

        public void ManageListingHidden()
        {
            ExcelLibHelper.PopulateInDataCollection(@"C:\Users\Dell\Documents\VB Feb 2021\CompititiveTask\CompititiveTask\Data\TestData.xlsx", "ShareSkill");
            var ExpectedCategory = ExcelLibHelper.ReadData(2, "Category");
            var ExpectedTitle = ExcelLibHelper.ReadData(2, "Title");
            var ExpectedDescription = ExcelLibHelper.ReadData(2, "Description");
            var ExpectedService = ExcelLibHelper.ReadData(2, "ServiceType");
            var ExpectedSubCategory = ExcelLibHelper.ReadData(2, "SubCategory");
            var ExpectedStartDate = ExcelLibHelper.ReadData(2, "StartDate");
            var ExpectedEndDate = ExcelLibHelper.ReadData(2, "EndDate");
            var ExpectedLocationType = ExcelLibHelper.ReadData(2, "LocationType");
            var ExpectedSkillTrade = ExcelLibHelper.ReadData(2, "Skill");

            //Wait for the Table to get displayed
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input");

            //Creating variables for all the data on Manage listing page
            var ActualCategory = Category.Text;
            var ActualTitle = Title.Text;
            var ActualDescription = Description.Text;
            var ActualServiceType = ServiceType.Text;
            View.Click();
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[2]");
            var ActualSubCategory = SubCategory.Text;
            var SDate = StartDate.Text;
            String ActualStartDate = String.Join("", SDate.Split('-').Reverse());
            var EDate = EndDate.Text;
            String ActualEndDate = String.Join("", EDate.Split('-').Reverse());
            var ActualLocationType = LocationType.Text;
            var ActualSkillTrade = SkillTrade.Text;

            //SearchText.SendKeys(ExcelLibHelper.ReadData(2, "Title"));
            //SearchText.SendKeys(Keys.Enter);

            // Back to the Manage listing Page
            driver.Navigate().Back();

            //Wait for Manage listings table to get displayed
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input");

            //Create logs for Validating step
            Tests._test.Log(Status.Info, "Validating Data on Manage listing");

            //Multile Assertion to validate all the data
            Assert.Multiple(() =>
            {
                Assert.That(ActualCategory == ExpectedCategory);
                Assert.That(ActualTitle == ExpectedTitle);
                Assert.That(ActualDescription == ExpectedDescription);
                Assert.That(ActualServiceType == ExpectedService);
                Assert.False(Active.ElementAt(0).Selected);
                Assert.That(ActualSubCategory == ExpectedSubCategory);
                Assert.That(ActualStartDate == ExpectedStartDate);
                Assert.That(ActualEndDate == ExpectedEndDate);
                Assert.That(ActualLocationType == ExpectedLocationType);
                Assert.That(ActualSkillTrade == ExpectedSkillTrade);

            });
        }

        public void ValidateEditManageListing()
        {
            ExcelLibHelper.PopulateInDataCollection(@"C:\Users\Dell\Documents\VB Feb 2021\CompititiveTask\CompititiveTask\Data\TestData.xlsx", "ShareSkill");
            var ExpectedCategory = ExcelLibHelper.ReadData(3, "Category");
            var ExpectedTitle = ExcelLibHelper.ReadData(3, "Title");
            var ExpectedDescription = ExcelLibHelper.ReadData(3, "Description");
            var ExpectedService = ExcelLibHelper.ReadData(3, "ServiceType");
            var ExpectedSubCategory = ExcelLibHelper.ReadData(3, "SubCategory");
            var ExpectedStartDate = ExcelLibHelper.ReadData(3, "StartDate");
            var ExpectedEndDate = ExcelLibHelper.ReadData(3, "EndDate");
            var ExpectedLocationType = ExcelLibHelper.ReadData(3, "LocationType");
            
            var ExpectedCredit= ExcelLibHelper.ReadData(3, "Credit");

            //Wait for the Table to get displayed
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input");

            //Creating variables for all the data on Manage listing page
            var ActualCategory = Category.Text;
            var ActualTitle = Title.Text;
            //var ActualDescription = Description.Text;
            var ActualServiceType = ServiceType.Text;
            View.Click();
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[2]");
            var ActualDescription = DescriptionText.Text;
            var ActualSubCategory = SubCategory.Text;
            var SDate = StartDate.Text;
            String ActualStartDate = String.Join("", SDate.Split('-').Reverse());
            var EDate = EndDate.Text;
            String ActualEndDate = String.Join("", EDate.Split('-').Reverse());
            var ActualLocationType = LocationType.Text;
            var ActualSkillTrade = SkillTrade.Text;
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='service-detail-section']/div[1]/div[1]/input");
            SearchText.SendKeys(ExcelLibHelper.ReadData(3, "Description"));
            SearchText.SendKeys(Keys.Enter);
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[2]/label/em");
            var CreditAmount =Credit.Text;

            // Back to the Manage listing Page
            ManageListingfromSearch.Click();

            //Wait for Manage listings table to get displayed
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input");

            //Create logs for Validating step
            Tests._test.Log(Status.Info, "Validating Data on Manage listing");

            //Multile Assertion to validate all the data
            Assert.Multiple(() =>
            {
                Assert.That(ActualCategory == ExpectedCategory);
                Assert.That(ActualTitle == ExpectedTitle);
                Assert.That(ActualDescription == ExpectedDescription);
                Assert.That(ActualServiceType == ExpectedService);
                Assert.True(Active.ElementAt(0).Selected);
                Assert.That(ActualSubCategory == ExpectedSubCategory);
                Assert.That(ActualStartDate == ExpectedStartDate);
                Assert.That(ActualEndDate == ExpectedEndDate);
                Assert.That(ActualLocationType == ExpectedLocationType);
               // Assert.That(ActualSkillTrade == ExpectedSkillTrade);
                Assert.That(CreditAmount == "Charge is :$" + ExpectedCredit + " per hour");

            });
        }

    }
}

