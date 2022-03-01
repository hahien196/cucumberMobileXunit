using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowAppiumTests.Helpers
{
    class Utilities
    {
        public static Dictionary<string, string> TableToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        public static void takeScreenShot(AppiumDriver _driver, string testID)
        {
            Screenshot screenshot = _driver.GetScreenshot();
            string folder = "screenshot";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string subPath = folder + "\\" + DateTime.Now.ToString("MMMMdd");
            Directory.CreateDirectory(subPath);
            // subPath: //SpiritDigital.CliniTouchVie.Application.Testing/CTV.Application.SpecFlowAppiumTests/TestResults/screenshot/
            screenshot.SaveAsFile(subPath + "\\" + testID, ScreenshotImageFormat.Png);
        }
    }
}
