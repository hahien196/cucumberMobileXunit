using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowAppiumTests.Pages
{
    public class CarerHome
    {
        private static AppiumDriver _driver;
        public CarerHome(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        By and_VPRQuestionSetLocator = MobileBy.XPath("//android.view.View[@text='VPR Pre-Exercise Diary']");
        By ios_VPRQuestionSetLocator = MobileBy.XPath("//XCUIElementTypeStaticText[@name='VPR Pre-Exercise Diary']");
        By accountNavigationItem = MobileBy.AccessibilityId("accountNavigationItem");
        By homeNavigationItem = MobileBy.AccessibilityId("homeNavigationItem");
        By educationNavigationItem = MobileBy.AccessibilityId("educationNavigationItem");
        By contactNavigationItem = MobileBy.AccessibilityId("contactNavigationItem");
        
        

        public void NavigateToContact()
        {
            ElementUtils.DoClick(_driver, contactNavigationItem);
        }

    }


}
