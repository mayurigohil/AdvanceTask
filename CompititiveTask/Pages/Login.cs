using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CompititiveTask.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace CompititiveTask.Pages
{
    class Login
    {
        private IWebDriver driver;
        
       
        public string filepath = "Data\\TestData.xlsx";

        public IWebElement SignIn => driver.FindElement(By.XPath("//a[normalize-space()='Sign In']"));
        public IWebElement EmailAddress => driver.FindElement(By.Name("email"));
        public IWebElement Password => driver.FindElement(By.Name("password"));
        public IWebElement LoginBtn => driver.FindElement(By.XPath("//button[normalize-space()='Login']"));
        public IWebElement ProfileName => driver.FindElement(By.XPath("//*[@class='item ui dropdown link'][text()='Hi ']"));

        
        public void LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            
            WaitClass.ElementPresent(driver, "XPath", "//a[normalize-space()='Sign In']");
            SignIn.Click();
            driver.SwitchTo().ActiveElement();
            ExcelLibHelper.PopulateInDataCollection((Path.Combine(AppDomain.CurrentDomain.BaseDirectory + filepath)), "Credentials");
            EmailAddress.SendKeys(ExcelLibHelper.ReadData(2, "username"));
            Password.SendKeys(ExcelLibHelper.ReadData(2,"password"));
            LoginBtn.Click();
            //Thread.Sleep(3000);
            WaitClass.ElementPresent(driver, "CssSelector", "i[class='outline write icon']");
        }
    }
}
