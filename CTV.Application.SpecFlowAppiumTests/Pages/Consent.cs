using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium;
using System.Threading;

namespace SpecFlowAppiumTests.Pages
{
    public class Consent : IPageManager
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
            ElementUtils.ScrollDown(_driver);
            Thread.Sleep(1000);
            ElementUtils.ScrollDown(_driver);
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
