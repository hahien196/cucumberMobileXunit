using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium;

namespace SpecFlowAppiumTests.Pages
{
    public class Consent
    {
        private static AppiumDriver _driver;

        public Consent(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        string consentTitleName = "consentTitle";
        By acceptInputSelector = MobileBy.AccessibilityId("acceptInput");
        By rejectInputSelector = MobileBy.AccessibilityId("rejectInput");


        public void ApproveConsent()
        {
            if (Globals.IsAndroid())
            {
                ElementUtils.Scroll(_driver, Globals.GetWindowHeight(), 0.3, 0.4);
                ElementUtils.Scroll(_driver, Globals.GetWindowHeight(), 0.3, 0.4);
            }
            else if (Globals.IsIOS())
            {
                ElementUtils.IOSScroll(_driver, "down");
            }
            ElementUtils.DoClick(_driver, acceptInputSelector);
        }

        public void RejectConsent()
        {
            ElementUtils.DoClick(_driver, rejectInputSelector);
        }

        public bool IsConsentDisplayed()
        {
            return ElementUtils.IsElementDisplayed(_driver, consentTitleName) ? true : false;
        }
    }
}
