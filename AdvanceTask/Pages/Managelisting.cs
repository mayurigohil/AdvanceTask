using AventStack.ExtentReports;
using AdvanceTask.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework.Interfaces;

namespace AdvanceTask.Pages
{
    class Managelisting
    {

        private IWebDriver driver;
        public  int rownum = 0;
        public  string filepath = "Data\\TestData.xlsx";
      

        //Initialising driver through constructor
        public Managelisting(IWebDriver driver, int rownum)
        {
            this.driver = driver;
            this.rownum = rownum;
            ExcelLibHelper.PopulateInDataCollection((Path.Combine(AppDomain.CurrentDomain.BaseDirectory + filepath)), "ShareSkill");
        
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
        public IWebElement DeleteManageListingButton => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));
        public IWebElement DescriptionText => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div/div/div/div[2]"));
        public IWebElement YesButtton => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
        public IWebElement NoButtton => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[1]"));
        public IWebElement Notification => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
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
          
        public void DeleteManageListing()
        {
            try
            {
                //get the list of Total count
                IList<IWebElement> ListingRows = driver.FindElements(By.TagName("tr"));
                Tests._test.Log(Status.Info, Convert.ToString(ListingRows.Count));
                //Get the value of Title
                var ActualTitle = Title.Text;
                //Click on Delete
                DeleteManageListingButton.Click();
                WaitClass.ElementPresent(driver, "XPath", "/html/body/div[2]/div/div[3]/button[1]");
                YesButtton.Click();
                WaitClass.ElementPresent(driver, "XPath", "//div[@class='ns-box-inner']");
                var message = Notification.Text;
                TestContext.WriteLine(message);

                //If Data is deleted
                if (message == ActualTitle + " has been deleted")
                {
                    IList<IWebElement> UpdatedListingRows = driver.FindElements(By.TagName("tr"));
                    Tests._test.Log(Status.Info, Convert.ToString(ListingRows.Count));
                    Assert.Less(UpdatedListingRows.Count, ListingRows.Count);
                    Tests._test.Log(Status.Pass, "Data is Deleted Successfully");
                }

                //If Pending Request on Data
                else if (message == "Unable to delete listing. Pending or Accepted skill trade requests exist.")
                {
                    Assert.Fail("Profile has Pending requests and can not be deleted");
                    Tests._test.Log(Status.Fail, "Profile has Pending requests and can not be deleted");
                }
            }

            catch (Exception e)
            {
                Assert.Fail("There are no services listed in the page", e.Message);
                Tests._test.Log(Status.Fail, "There are no services listed in the page");
            }
            
        }
        public  void ManageListingsActive()
        {   
            //Calling Excel library to get the data
                var ExpectedCategory = ExcelLibHelper.ReadData(rownum, "Category");
                var ExpectedTitle = ExcelLibHelper.ReadData(rownum, "Title");
                var ExpectedDescription = ExcelLibHelper.ReadData(rownum, "Description");
                var ExpectedService = ExcelLibHelper.ReadData(rownum, "ServiceType");
                var ExpectedSubCategory = ExcelLibHelper.ReadData(rownum, "SubCategory");
                var ExpectedStartDate = ExcelLibHelper.ReadData(rownum, "StartDate");
                var ExpectedEndDate = ExcelLibHelper.ReadData(rownum, "EndDate");
                var ExpectedLocationType = ExcelLibHelper.ReadData(rownum, "LocationType");
                var ExpectedSkillTrade = ExcelLibHelper.ReadData(rownum, "Skill");

            //Wait for the Table to get displayed
                WaitClass.ElementPresent(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input");
          
            //Creating variables for all the data on Manage listing page
                var ActualCategory = Category.Text;
                var ActualTitle = Title.Text;
                var ActualServiceType = ServiceType.Text;
                View.Click();
                WaitClass.ElementPresent(driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[2]");
                var ActualSubCategory = SubCategory.Text;
                var ActualDescription = DescriptionText.Text;
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
            try
            {
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
            catch
            {
                var NotificationText = Notification.Text;
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                var errorMessage = TestContext.CurrentContext.Result.Message;

                if (status == TestStatus.Failed)
                {
                    Tests._test.Log(Status.Fail, "Error Message :" + NotificationText);
                    Tests._test.Log(Status.Fail, "Snapshot below: " + CommonDriver.SaveScreenshot(driver, "Delete Skill Failed"));
                }
            }
               
        }

        public void ManageListingHidden()
        {
            var ExpectedCategory = ExcelLibHelper.ReadData(rownum, "Category");
            var ExpectedTitle = ExcelLibHelper.ReadData(rownum, "Title");
            var ExpectedDescription = ExcelLibHelper.ReadData(rownum, "Description");
            var ExpectedService = ExcelLibHelper.ReadData(rownum, "ServiceType");
            var ExpectedSubCategory = ExcelLibHelper.ReadData(rownum, "SubCategory");
            var ExpectedStartDate = ExcelLibHelper.ReadData(rownum, "StartDate");
            var ExpectedEndDate = ExcelLibHelper.ReadData(rownum, "EndDate");
            var ExpectedLocationType = ExcelLibHelper.ReadData(rownum, "LocationType");
            var ExpectedSkillTrade = ExcelLibHelper.ReadData(rownum, "Skill");

            //Wait for the Table to get displayed
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input");

            //Creating variables for all the data on Manage listing page
            var ActualCategory = Category.Text;
            var ActualTitle = Title.Text;
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

            // Back to the Manage listing Page
            driver.Navigate().Back();

            //Wait for Manage listings table to get displayed
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input");

            //Create logs for Validating step
            Tests._test.Log(Status.Info, "Validating Data on Manage listing");

            //Multile Assertion to validate all the data
            try
            {
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
                });
            }
            
            catch
            {
                var NotificationText = Notification.Text;
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                var errorMessage = TestContext.CurrentContext.Result.Message;

                if (status == TestStatus.Failed)
                {
                    Tests._test.Log(Status.Fail, "Error Message :" + NotificationText);
                    Tests._test.Log(Status.Fail, "Snapshot below: " + CommonDriver.SaveScreenshot(driver, "Delete Skill Failed"));
                }
            }

        }

        public void ValidateEditManageListing()
        {
            var ExpectedCategory = ExcelLibHelper.ReadData(rownum, "Category");
            var ExpectedTitle = ExcelLibHelper.ReadData(rownum, "Title");
            var ExpectedDescription = ExcelLibHelper.ReadData(rownum, "Description");
            var ExpectedService = ExcelLibHelper.ReadData(rownum, "ServiceType");
            var ExpectedSubCategory = ExcelLibHelper.ReadData(rownum, "SubCategory");
            var ExpectedStartDate = ExcelLibHelper.ReadData(rownum, "StartDate");
            var ExpectedEndDate = ExcelLibHelper.ReadData(rownum, "EndDate");
            var ExpectedLocationType = ExcelLibHelper.ReadData(rownum, "LocationType");
            
            var ExpectedCredit= ExcelLibHelper.ReadData(3, "Credit");

            //Wait for the Table to get displayed
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input");

            //Creating variables for all the data on Manage listing page
            var ActualCategory = Category.Text;
            var ActualTitle = Title.Text;
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
            try
            {
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
                    Assert.That(CreditAmount == "Charge is :$" + ExpectedCredit + " per hour");
                });
            }
            catch
            {
                var NotificationText = Notification.Text;
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                var errorMessage = TestContext.CurrentContext.Result.Message;

                if (status == TestStatus.Failed)
                {
                    Tests._test.Log(Status.Fail, "Error Message :" + NotificationText);
                    Tests._test.Log(Status.Fail, "Snapshot below: " + CommonDriver.SaveScreenshot(driver, "Delete Skill Failed"));
                }
            }

            
            
        }

    }
}

