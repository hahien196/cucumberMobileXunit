using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowAppiumTests.Pages
{
    public class Home
    {
        private static AppiumDriver _driver;
        public Home(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        By and_VPRQuestionSetLocator = MobileBy.XPath("//android.view.View[@text='VPR Pre-Exercise Diary']");
        By ios_VPRQuestionSetLocator = MobileBy.XPath("//XCUIElementTypeStaticText[@name='VPR Pre-Exercise Diary']");
        By accountNavigationItem = MobileBy.AccessibilityId("accountNavigationItem");
        By homeNavigationItem = MobileBy.AccessibilityId("homeNavigationItem");
        By educationNavigationItem = MobileBy.AccessibilityId("educationNavigationItem");
        By contactNavigationItem = MobileBy.AccessibilityId("contactNavigationItem");

        public void SelectVPRQuestionSet()
        {
            By VPRQuestionSetLocator = null;
            if (Globals.IsAndroid())
            {
                VPRQuestionSetLocator = and_VPRQuestionSetLocator;
            }
            else if (Globals.IsIOS())
            {
                VPRQuestionSetLocator = ios_VPRQuestionSetLocator;
            }
            ElementUtils.DoClick(_driver, VPRQuestionSetLocator);
        }
        public void NavigateToAccount()
        {
            ElementUtils.DoClick(_driver, accountNavigationItem);
        }

        public void NavigateToEducation()
        {
            ElementUtils.DoClick(_driver, educationNavigationItem);
        }

        public void NavigateToContact()
        {
            ElementUtils.DoClick(_driver, contactNavigationItem);
        }

    }


}
