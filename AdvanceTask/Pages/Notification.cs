using AdvanceTask.Utility;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace AdvanceTask.Pages
{
    class Notification
    {
        private IWebDriver driver;

        public string filepath = "Data\\TestData.xlsx";
        public Notification(IWebDriver driver)
        {
            this.driver = driver;
            
        }
        public IWebElement Dashboard => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[1]"));
        public IWebElement LoadMore => driver.FindElement(By.XPath("//*[@id='notification-section']//center/a[text()='Load More...']"));
        public IWebElement ShowLess => driver.FindElement(By.XPath("//*[@id='notification-section']//center/a[text()='...Show Less']"));
       public IList<IWebElement> ServiceRequestRows => driver.FindElements(By.TagName("hr"));
        public void NotificationPage()
        {
            Tests._test.Log(Status.Info, "Navigate to Dashboard");
            Dashboard.Click();
            WaitClass.ElementPresent(driver, "Xpath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/a/h1");
            Thread.Sleep(1000);
        }

        public void ValidateLoadMore()
        {
            try
            {
            //Click on Loadmore untill Load more is visible
                    while (LoadMore.Displayed)
                    {
                    LoadMore.Click();
                    Thread.Sleep(500);
                    WaitClass.ElementPresent(driver, "Xpath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/a/h1");
                    Tests._test.Log(Status.Info, "Load More is clicked");
                }
            }
            catch(NoSuchElementException e)
            {
                Tests._test.Log(Status.Pass, "All the data is shown");
            }

            catch (Exception e)
            {
                Tests._test.Log(Status.Fail, "System Error");
            }
           
        }

        public void ValidateShowLess()
        {
            try
            {
                //Click on Loadmore untill Show Less is visible
                while (ShowLess.Displayed)
                {
                    ShowLess.Click();
                    Thread.Sleep(500);
                    WaitClass.ElementPresent(driver, "Xpath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/a/h1");
                    Tests._test.Log(Status.Info, "Show Less is Clicked");
                }
            }
            catch (NoSuchElementException e)
            {
                Tests._test.Log(Status.Pass, "All the data is shown");
            }

            catch (Exception e)
            {
                Tests._test.Log(Status.Fail, "System Error");
            }
        }
    }


}
