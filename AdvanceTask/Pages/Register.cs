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
    class Register
    {
        private IWebDriver driver;
        public int rownum = 0;
        public string filepath = "Data\\TestData.xlsx";


        //Initialising driver through constructor
        public Register(IWebDriver driver, int rownum)
        {
            this.driver = driver;
            this.rownum = rownum;
            ExcelLibHelper.PopulateInDataCollection((Path.Combine(AppDomain.CurrentDomain.BaseDirectory + filepath)), "Register");

        }
        public IWebElement Password => driver.FindElement(By.Name("password"));
        public IWebElement ConfirmPassword => driver.FindElement(By.Name("confirmPassword"));
        public IWebElement Terms => driver.FindElement(By.Name("terms"));
        public IWebElement Email => driver.FindElement(By.Name("email"));
        public IWebElement LastName => driver.FindElement(By.Name("lastName"));
        public IWebElement FirstName => driver.FindElement(By.Name("firstName"));
        public IWebElement Join => driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/button"));
        public IWebElement Submit => driver.FindElement(By.Id("submit-btn"));
        public IWebElement Notification => driver.FindElement(By.ClassName("ns-box-inner"));
        public IWebElement EmailVerification => driver.FindElement(By.XPath("/html/body/div[3]/div/div/form/div[3]/div"));

        public void RegisterAccount(IWebDriver driver)

            {
            var Data = ExcelLibHelper.ReadData(rownum, "Status");
            Join.Click();
            WaitClass.ElementPresent(driver, "Name", "lastName");
            FirstName.SendKeys(ExcelLibHelper.ReadData(rownum, "Firstname"));
            LastName.SendKeys(ExcelLibHelper.ReadData(rownum, "Lastname"));
            Email.SendKeys(ExcelLibHelper.ReadData(rownum, "Email"));
            Password.SendKeys(ExcelLibHelper.ReadData(rownum, "Password"));
            ConfirmPassword.SendKeys(ExcelLibHelper.ReadData(rownum, "ConfirmPassword"));
            Terms.Click();
            Submit.Click();
           
            try
            {
                if (Data=="Valid")
                {
                    WaitClass.ElementPresent(driver, "ClassName", "ns-box-inner");
                    if (Notification.Text == "Registration Successfull")
                        Tests._test.Log(Status.Pass, "Data is Deleted Successfully");
                }
                else
                {
                    String EmailValidationMsg = EmailVerification.Text;
                    if (EmailValidationMsg == "This email has already been used to register an account.")
                        Tests._test.Log(Status.Fail, "The account has already been created with this emailID, Please log in using exisitng account details");
                }

            }
            catch (Exception e)
            {
                Assert.Fail("Registration failed due to 1 or more errors. Make sure that there isn't an existing account", e.Message);
            }
           


        }

    }
    }
