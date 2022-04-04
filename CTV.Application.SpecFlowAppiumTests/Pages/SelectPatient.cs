using OpenQA.Selenium.Appium;
using System;
using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium;

namespace SpecFlowAppiumTests.Pages
{
    public class SelectPatient
    {
        private static AppiumDriver _driver;

        public SelectPatient(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }
        
    }
}
