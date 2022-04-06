using OpenQA.Selenium.Appium;
using System;
using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowAppiumTests.Pages
{
    public class Acccount
    {
        private static AppiumDriver _driver;

        public Acccount(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        By logoutButtonSelector = MobileBy.AccessibilityId("accountLogoutButton");
        

        public void ClickLogin()
        {
            ElementUtils.DoClick(_driver, logoutButtonSelector);
        }

    }
}
