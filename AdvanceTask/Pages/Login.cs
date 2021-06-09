using AdvanceTask.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;

namespace AdvanceTask.Pages
{
    class Login
    {
        private IWebDriver driver;
        public int rownum = 0;
        public string filepath = "Data\\TestData.xlsx";
        

        //Initialising driver through constructor
        public Login(IWebDriver driver, int rownum)
        {
            this.driver = driver;
            this.rownum = rownum;
            ExcelLibHelper.PopulateInDataCollection((Path.Combine(AppDomain.CurrentDomain.BaseDirectory + filepath)), "Credentials");

        }
        public IWebElement SignIn => driver.FindElement(By.XPath("//a[normalize-space()='Sign In']"));
        public IWebElement EmailAddress => driver.FindElement(By.Name("email"));
        public IWebElement Password => driver.FindElement(By.Name("password"));
        public IWebElement LoginBtn => driver.FindElement(By.XPath("//button[normalize-space()='Login']"));
       
        public IWebElement PName => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));
        public IWebElement ProfileName => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/text()[2]"));
        public string Name = ExcelLibHelper.ReadData(2, "name");

        public void LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            var Name = ExcelLibHelper.ReadData(rownum, "name");
        WaitClass.ElementPresent(driver, "XPath", "//a[normalize-space()='Sign In']");
            SignIn.Click();
            driver.SwitchTo().ActiveElement();
            EmailAddress.SendKeys(ExcelLibHelper.ReadData(rownum, "username"));
            Password.SendKeys(ExcelLibHelper.ReadData(rownum,"password"));
            LoginBtn.Click();
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i");
        }

        public void LoginValidation()
            {
                TestContext.WriteLine(Name);
                Assert.That(PName.Text == "Hi " + Name);
            }
            

           

        
    }
}
