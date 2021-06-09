using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;


namespace AdvanceTask.Utility
{
    class WaitClass
    {
        public static void ElementPresent(IWebDriver driver, String Locator, String LocatorValue)
        {
            try
            {
                if (Locator == "Id")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(LocatorValue)));
                }

                if (Locator == "ClassName")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName(LocatorValue)));
                }

                if (Locator == "XPath")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(LocatorValue)));
                }
                if (Locator == "CssSelector")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(LocatorValue)));
                }
                if (Locator == "Name")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name(LocatorValue)));
                }
            }

            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Time out Exception");
            }
            catch (StaleElementReferenceException)
            {
                Assert.Fail("Stale element");
            }
            catch (Exception Ex)
            {
                Assert.Fail("test case failed", Ex);
            }

        }
    }
}
