using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.IO;
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

        public static void TakeScreenShot(AppiumDriver _driver, string testID)
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

        public static Tuple<string, string, string> SplitDate(string date, string splitString)
        {
            var splittedDate = date.Split(splitString);
            var day = splittedDate[0];
            var month = splittedDate[1];
            var year = splittedDate[2];
            return new Tuple<string, string, string>(day, month, year);
        }
    }
}
