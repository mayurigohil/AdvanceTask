using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AdvanceTask.Pages
{
    class HomePage
    {
        private IWebDriver driver;

        public IWebElement MouseHover => driver.FindElement(By.XPath("//*[@class='item ui dropdown link'][contains(text(),'Hi')]"));
        public IWebElement GoToProfile => driver.FindElement(By.XPath(" //a[normalize-space()='Go to Profile']"));
        
       
        public void NavigateProfile(IWebDriver driver)
        {
            this.driver = driver;
            Actions Hover = new Actions(driver);
            Hover.MoveToElement(MouseHover).Perform();
            GoToProfile.Click();


        }
    }
}
