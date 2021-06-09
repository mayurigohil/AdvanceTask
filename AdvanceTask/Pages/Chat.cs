using AdvanceTask.Utility;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvanceTask.Pages
{
    class Chat
    {
        private IWebDriver driver;

        public string filepath = "Data\\TestData.xlsx";
        public Chat(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement ChatNavigation => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[1]"));
        public IWebElement ChatList => driver.FindElement(By.XPath("//*[@id='chatList']/div[2]/div[2]"));
        public IWebElement ChatBox => driver.FindElement(By.XPath("//*[@id='chatBox']/div[1]"));

        public void ChatHistory()
        {
        try
            {

                ChatNavigation.Click();
                WaitClass.ElementPresent(driver, "XPath", "//*[@id='chatList']/div[2]/div[2]");
                Tests._test.Log(Status.Info, "Chat History is Opened");
                ChatList.Click();
                WaitClass.ElementPresent(driver, "XPath", "//*[@id='chatBox']/div[1]");
                bool displayed = ChatBox.Displayed;
                Assert.IsTrue(displayed);
                Tests._test.Log(Status.Pass, "Chat box is Opened");
            }
            catch
            {
                Assert.Fail("Chat History not visible");
            }

        }
    }
}
