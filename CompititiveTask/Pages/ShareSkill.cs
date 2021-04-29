using CompititiveTask.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CompititiveTask.Pages
{
    class ShareSkill
    {
        IWebDriver driver;
        //Inintialise Page Factory
        public ShareSkill(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Declare all the WebElements
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/div[2]/a")]
        private IWebElement ShareSkillButton { get; set; }

        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement  Category { get; set; }

        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategory { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input")]
        private IWebElement Tag { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")]
        private IWebElement ServiceTypeHourly { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")]
        private IWebElement ServiceTypeOneoff { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")]
        private IWebElement LocationTypeOnSite { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")]
        private IWebElement LocationTypeOnline { get; set; }

        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDate { get; set; }

        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[1]/div/input")]
        private IWebElement Sunday { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input")]
        private IWebElement Monday { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[4]/div[1]/div/input")]
        private IWebElement Tuesday { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[5]/div[1]/div/input")]
        private IWebElement Wednesday { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[6]/div[1]/div/input")]
        private IWebElement Thursday { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[7]/div[1]/div/input")]
        private IWebElement Friday { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[8]/div[1]/div/input")]
        private IWebElement Saturday { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[2]/input")]
        private IWebElement Starttime { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[3]/input")]
        private IWebElement Endtime { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")]
        private IWebElement SkillTradeCredit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")]
        private IWebElement SkillTradeExchange { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")]
        private IWebElement Skill_Exchange { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/input")]
        private IWebElement Credit { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")]
        private IWebElement Active { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input")]
        private IWebElement Hidden { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]")]
        private IWebElement Save { get; set; }

        [FindsBy(How =How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/span/a")]
        private IWebElement DeleteTag { get; set; }

        //Fill Skill Share Page
        public void ShareSkillPage()
        {
            
            ShareSkillButton.Click();
            WaitClass.ElementPresent(driver, "Name", "categoryId");
            ExcelLibHelper.PopulateInDataCollection(@"C:\Users\Dell\Documents\VB Feb 2021\CompititiveTask\CompititiveTask\Data\TestData.xlsx", "ShareSkill");
            Title.SendKeys(ExcelLibHelper.ReadData(2, "Title"));
            Description.SendKeys(ExcelLibHelper.ReadData(2, "Description"));
           
        }

        //Select Category
        public void SelectCategory()
        {
            WaitClass.ElementPresent(driver, "Name", "categoryId");
            SelectElement select = new SelectElement(Category);
            ExcelLibHelper.PopulateInDataCollection(@"C:\Users\Dell\Documents\VB Feb 2021\CompititiveTask\CompititiveTask\Data\TestData.xlsx", "ShareSkill");
            var Categorydata = ExcelLibHelper.ReadData(2, "Category");
            select.SelectByText(Categorydata); 
        }

        //Select Sub Category
        public void SelectSubCategory()
        {
            WaitClass.ElementPresent(driver, "Name", "subcategoryId");
            SelectElement select = new SelectElement(SubCategory);
            ExcelLibHelper.PopulateInDataCollection(@"C:\Users\Dell\Documents\VB Feb 2021\CompititiveTask\CompititiveTask\Data\TestData.xlsx", "ShareSkill");
            var SubCategorydata = ExcelLibHelper.ReadData(2, "SubCategory");
            select.SelectByText(SubCategorydata);
        }

        // Add Tags on Share skill
        public void EnterTag()
        {
            ExcelLibHelper.PopulateInDataCollection(@"C:\Users\Dell\Documents\VB Feb 2021\CompititiveTask\CompititiveTask\Data\TestData.xlsx", "ShareSkill");
            var TagData = ExcelLibHelper.ReadData(2, "Tag");
            Tag.SendKeys(TagData);
            Tag.SendKeys(Keys.Enter);
            var TagData1 = ExcelLibHelper.ReadData(2, "Tag1");
            Tag.SendKeys(TagData1);
            Tag.SendKeys(Keys.Enter);
        }

        public void ShareSkillPageRemaining()
        {
            ServiceTypeHourly.Click();
            LocationTypeOnline.Click();
            ExcelLibHelper.PopulateInDataCollection(@"C:\Users\Dell\Documents\VB Feb 2021\CompititiveTask\CompititiveTask\Data\TestData.xlsx", "ShareSkill");
            var Startdatedata = ExcelLibHelper.ReadData(2, "StartDate");
            StartDate.SendKeys(Startdatedata);
            var Enddatedata = ExcelLibHelper.ReadData(2, "EndDate");
            EndDate.SendKeys(Enddatedata);
            Sunday.Click();
            Monday.Click();
            var Starttimedata = ExcelLibHelper.ReadData(2, "StartTime");
            Starttime.SendKeys(Startdatedata);
            var Endtimedata = ExcelLibHelper.ReadData(2, "EndTime");
            Endtime.SendKeys(Enddatedata);

        }

        public void SkillExchange()
        {
            SkillTradeExchange.Click();
            var skill = ExcelLibHelper.ReadData(2, "Skill");
            Skill_Exchange.SendKeys(skill);
            Skill_Exchange.SendKeys(Keys.Enter);
            var skill1 = ExcelLibHelper.ReadData(2, "Skill1");
            Skill_Exchange.SendKeys(skill1);
            Skill_Exchange.SendKeys(Keys.Enter);
        }

        public void EditCreditExchange()
        {
            SkillTradeCredit.Click();
            var Creditamount = ExcelLibHelper.ReadData(3, "Credit");
            Credit.SendKeys(Creditamount);
        }

        public void ActiveShareSkill()
        { 
            Active.Click();
        }

        public void HiddenshareSkill()
        {
            Hidden.Click();
        }

         public void SaveShareSkill()
        {
            Save.Click();
            
        }
           
        public void EditTitle()
        {
            Title.Clear();
            ExcelLibHelper.PopulateInDataCollection(@"C:\Users\Dell\Documents\VB Feb 2021\CompititiveTask\CompititiveTask\Data\TestData.xlsx", "ShareSkill");
            Title.SendKeys(ExcelLibHelper.ReadData(3, "Title"));
            Description.Clear();
            Description.SendKeys(ExcelLibHelper.ReadData(3, "Description"));
        }

        public void EditTag()
        {
            ExcelLibHelper.PopulateInDataCollection(@"C:\Users\Dell\Documents\VB Feb 2021\CompititiveTask\CompititiveTask\Data\TestData.xlsx", "ShareSkill");
            var TagData = ExcelLibHelper.ReadData(3, "Tag");
            DeleteTag.Click();
            Tag.SendKeys(TagData);
            Tag.SendKeys(Keys.Enter);
            var TagData1 = ExcelLibHelper.ReadData(3, "Tag1");
            Tag.SendKeys(TagData1);
            Tag.SendKeys(Keys.Enter);
        }

        public void LocationTypeOnsite()
        {
            LocationTypeOnSite.Click();

        }
        public void LocationTypeOnLine()
        {
            LocationTypeOnline.Click();

        }
        public void ServicetypeHourly()
        {
            ServiceTypeHourly.Click();

        }

        public void ServiceTypeOne_off()
        {
            ServiceTypeOneoff.Click();
        }
    }
}

