using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium;

namespace SpecFlowAppiumTests.Pages
{
    public class Welcome
    {
        private static AppiumDriver _driver;
        public Welcome(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        By and_VPRQuestionSetLocator = MobileBy.XPath("//android.view.View[@text='VPR Pre-Exercise Diary']");
        By ios_VPRQuestionSetLocator = MobileBy.XPath("//XCUIElementTypeStaticText[@name='VPR Pre-Exercise Diary']");
        By accountNavigationItem = MobileBy.AccessibilityId("accountNavigationItem");

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
    }


}
