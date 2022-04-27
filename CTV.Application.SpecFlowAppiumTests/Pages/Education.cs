using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowAppiumTests.Pages
{
    public class Education
    {
        private static AppiumDriver _driver;
        public Education(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        By accountNavigationItem = MobileBy.AccessibilityId("accountNavigationItem");
        By homeNavigationItem = MobileBy.AccessibilityId("homeNavigationItem");
        By educationNavigationItem = MobileBy.AccessibilityId("educationNavigationItem");
        By contactNavigationItem = MobileBy.AccessibilityId("contactNavigationItem");

    }


}
