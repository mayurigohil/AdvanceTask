using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.IO;

namespace CompititiveTask.Utility
{
    class CommonDriver
    {
        public static IWebDriver driver { get; set; }

        public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
        {

            var folderLocation = AppDomain.CurrentDomain.BaseDirectory;

            Directory.CreateDirectory(folderLocation + "Screenshorts");
            TestContext.WriteLine(folderLocation);
           
            var finalpth = folderLocation.Substring(0, folderLocation.LastIndexOf("bin")) + "Screenshorts\\" ;
            var localpath = new Uri(finalpth).LocalPath;
            if (!System.IO.Directory.Exists(localpath))
            {
                System.IO.Directory.CreateDirectory(localpath);
            }

            var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = new StringBuilder(localpath);

            fileName.Append(ScreenShotFileName);
            fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
            //fileName.Append(DateTime.Now.ToString("dd-mm-yyyym_ss"));
            fileName.Append(".Png");
            screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Png);
            return fileName.ToString();
        }


    }
}
