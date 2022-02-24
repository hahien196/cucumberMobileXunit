using OpenQA.Selenium.Appium;
using System;
using SpecFlowAppiumTests.Helpers;
using System.Threading;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium;

namespace SpecFlowAppiumTests.Pages
{
    public class Consent : IPageManager
    {
        private static AppiumDriver _driver;

        public Consent(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        By companyLogoSelector = MobileBy.AccessibilityId("companyLogoImage");
        AppiumElement companyLogo => _driver.FindElement(companyLogoSelector);
        AppiumElement consentTitle => _driver.FindElement(MobileBy.AccessibilityId("consentTitle"));
        By acceptInputSelector = MobileBy.AccessibilityId("acceptInput");
        AppiumElement acceptInput => _driver.FindElement(acceptInputSelector);
        By rejectInputSelector = MobileBy.AccessibilityId("rejectInput");
        AppiumElement rejectInput => _driver.FindElement(rejectInputSelector);



        public bool ValidateElements(string elementName)
        {
            ElementUtils.WaitForElementVisible(_driver, companyLogoSelector);
            Thread.Sleep(1000);
            AppiumElement[] appiumWebElements = { companyLogo, consentTitle, acceptInput, rejectInput };

            string locator = Globals.GetLocator();

             foreach (AppiumElement element in appiumWebElements)
             {

                 if (element.GetAttribute(locator) == elementName)
                 {
                     try
                     {
                        return true ? element.Displayed : false;
                     }
                     catch (Exception)
                     {
                         return false;
                     }
                 }
             }

            return false;
        }

        public void ApproveConsent()
        {
            ElementUtils.ScrollToBottom(_driver);
            ElementUtils.ScrollToBottom(_driver);
            ElementUtils.WaitForElementClickable(_driver, acceptInputSelector);
            acceptInput.Click();
        }

        public void RejectConsent()
        {
            //ElementUtils.ScrollToBottom(_driver);
            //Thread.Sleep(1000);
            ElementUtils.WaitForElementClickable(_driver, rejectInputSelector);
            rejectInput.Click();
        }

        
    }
}
