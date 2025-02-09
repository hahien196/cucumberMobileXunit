﻿using OpenQA.Selenium.Appium;
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
            ElementUtils.ScrollDown(_driver, 0.2, Globals.GetWindowHeight(), 0.5);
            ElementUtils.ScrollDown(_driver, 0.2, Globals.GetWindowHeight(), 0.5);
            ElementUtils.DoClick(_driver, acceptInputSelector);
        }

        public void RejectConsent()
        {
            ElementUtils.DoClick(_driver, rejectInputSelector);
        }
        public bool IsConsentDisplayed()
        {
            return ElementUtils.IsElementDisplayed(_driver, consentTitleName);
        }
    }
}
