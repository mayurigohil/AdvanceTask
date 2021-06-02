using AdvanceTask.Utility;
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
            Dashboard.Click();
            WaitClass.ElementPresent(driver, "Xpath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/a/h1");
            Thread.Sleep(1000);
        }

        public void ValidateLoadMore()
        {
            try
            {
                    while (LoadMore.Displayed)
                    {
                        LoadMore.Click();
                    Thread.Sleep(500);
                    WaitClass.ElementPresent(driver, "Xpath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/a/h1");
                    }
            }
            catch(NoSuchElementException e)
            {
                TestContext.WriteLine("All the data is shown", e.Message);
            }

            catch (Exception e)
            {
                TestContext.WriteLine("System Error", e.Message);
            }
           
        }

        public void ValidateShowLess()
        {
            try
            {
                while (ShowLess.Displayed)
                {
                    ShowLess.Click();
                    Thread.Sleep(500);
                    WaitClass.ElementPresent(driver, "Xpath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/a/h1");
                }
            }
            catch (NoSuchElementException e)
            {
                TestContext.WriteLine("All the data is shown and validated", e.Message);
            }
            catch (Exception e)
            {
                TestContext.WriteLine("System Error", e.Message);
            }
        }
    }


}
