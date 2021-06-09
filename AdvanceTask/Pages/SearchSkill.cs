using AdvanceTask.Utility;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdvanceTask.Pages
{
    class SearchSkill
    {

        private IWebDriver driver;
        public int rownum = 0;
        public string filepath = "Data\\TestData.xlsx";

        //Initialising driver through constructor
        public SearchSkill(IWebDriver driver, int rownum)
        {
            this.driver = driver;
            this.rownum = rownum;
            ExcelLibHelper.PopulateInDataCollection((Path.Combine(AppDomain.CurrentDomain.BaseDirectory + filepath)), "SearchSkill");
        }

        public IWebElement SearchCategory => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[1]/input"));
        public IWebElement AllCategoryCount => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[1]/span"));
        public IWebElement GraphicsnDesign => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[2]/span"));
        public IWebElement DigitalMarkeying => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[3]/span"));
        public IWebElement WritingnTranslation => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[4]/span"));
        public IWebElement VideonAnimation => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[5]/span"));
        public IWebElement MusicnAutio => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[6]/span"));
        public IWebElement ProgrammingnTech => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[7]/span"));
        public IWebElement Business => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[8]/span"));
        public IWebElement FunnLifestyle => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[9]/span"));
        public IWebElement LogoDesign => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[3]/span"));
        public void SearchSkillCategory()
        {

            SearchCategory.SendKeys(ExcelLibHelper.ReadData(2, "SearchCategory"));
            SearchCategory.SendKeys(Keys.Enter);
            Tests._test.Log(Status.Info, "Search Category is Entered");
            string CategorySelected = ExcelLibHelper.ReadData(2, "SearchCategory");
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]");

            try {

                switch (CategorySelected)
                {
                    case "All Category":
                        var Category = AllCategoryCount.Text;
                        int CategoryCount = Convert.ToInt32(Category);
                        Assert.GreaterOrEqual(CategoryCount, 1);
                        break;
                    case "Graphics & Design":
                        var Graphics = GraphicsnDesign.Text;
                        int GraphicsCount = Convert.ToInt32(Graphics);
                        Assert.GreaterOrEqual(GraphicsCount, 1);
                        break;
                    case "Digital Marketing":
                        var Digital = DigitalMarkeying.Text;
                        int DigialCount = Convert.ToInt32(Digital);
                        Assert.GreaterOrEqual(DigialCount, 1);
                        break;
                    case "Writing & Translation":
                        var Writing = WritingnTranslation.Text;
                        int WritingCount = Convert.ToInt32(Writing);
                        Assert.GreaterOrEqual(WritingCount, 1);
                        break;
                    case "Video & Animation":
                        var Video = VideonAnimation.Text;
                        int VideoCount = Convert.ToInt32(Video);
                        Assert.GreaterOrEqual(VideoCount, 1);
                        break;
                    case "Music & Audio":
                        var Music = MusicnAutio.Text;
                        int MusicCount = Convert.ToInt32(Music);
                        Assert.GreaterOrEqual(MusicCount, 1);
                        break;
                    case "Programming & Tech":
                        var Programming = ProgrammingnTech.Text;
                        int ProgrammingCount = Convert.ToInt32(Programming);
                        Assert.GreaterOrEqual(Programming, 1);
                        break;
                    case "Business":
                        var BusinessString = Business.Text;
                        int BusinessCount = Convert.ToInt32(Business);
                        Assert.GreaterOrEqual(BusinessCount, 1);
                        break;
                    case "Fun & Lifestyle":
                        var Fun = FunnLifestyle.Text;
                        int FunCount = (int)Convert.ToInt64(Fun);
                        TestContext.WriteLine(FunCount);
                        Assert.GreaterOrEqual(FunCount, 1);
                        break;
                }
            }
            catch
            {
                Assert.Fail("No results found, please select a new category!");
                Tests._test.Log(Status.Fail, "No results found, please select a new category!");
            }
        }

        public void SearchSkillSub()
        {
            SearchCategory.SendKeys(ExcelLibHelper.ReadData(2, "SearchSubCategory"));
            SearchCategory.SendKeys(Keys.Enter);
            string SubCategorySelected = ExcelLibHelper.ReadData(2, "SearchSubCategory");
            Tests._test.Log(Status.Info, "Search SubCategory is Entered");
            WaitClass.ElementPresent(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]");

            try
            {

                switch (SubCategorySelected)
                {
                    case "All Category":
                        var Category = AllCategoryCount.Text;
                        int CategoryCount = Convert.ToInt32(Category);
                        Assert.GreaterOrEqual(CategoryCount, 1);
                        break;
                    case "Logo Design":
                        var Graphics = GraphicsnDesign.Text;
                        int GraphicsCount = Convert.ToInt32(Graphics);
                        Assert.GreaterOrEqual(GraphicsCount, 1);
                        break;
                }
            }
            
                catch
            {
                Assert.Fail("No results found, please select a new category!");
                Tests._test.Log(Status.Fail, "No results found, please select a new category!");
            }
        }
    }  
}
