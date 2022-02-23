using OpenQA.Selenium.Appium;
using System;
using SpecFlowAppiumTests.Helpers;
using System.Threading;
using OpenQA.Selenium.Appium.MultiTouch;

namespace SpecFlowAppiumTests.Pages
{
    public class Consent : IPageManager
    {
        private static AppiumDriver _driver;

        public Consent(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        AppiumElement companyLogo => _driver.FindElement(MobileBy.AccessibilityId("companyLogoImage"));
        AppiumElement consentTitle => _driver.FindElement(MobileBy.AccessibilityId("consentTitle"));
        AppiumElement acceptInput => _driver.FindElement(MobileBy.AccessibilityId("acceptInput"));
        AppiumElement rejectInput => _driver.FindElement(MobileBy.AccessibilityId("rejectInput"));



        public bool ValidateElements(string elementName)
        {
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
            ScrollToBottom();
            Thread.Sleep(1000);
            acceptInput.Click();
        }

        public void RejectConsent()
        {
            ScrollToBottom();
            Thread.Sleep(1000);
            rejectInput.Click();
        }

        public void ScrollToBottom()
        {
            double windowHeight;

            if (Globals.IsIOS())
            {
                windowHeight = Globals.IOSWindowHeight();
            }
            else
            {
                windowHeight = Globals.AndroidWindowHeight();
            }

            double windowStartHeight = _driver.Manage().Window.Size.Height * windowHeight;
            double windowEndHeight = _driver.Manage().Window.Size.Height * 0.2;
            double windowWidth = _driver.Manage().Window.Size.Width / 2;

            TouchAction dragtobottom = (TouchAction)new TouchAction(_driver).
                Press(windowWidth, windowStartHeight)
                .Wait(500)
                .MoveTo(windowWidth, windowEndHeight)
                .Release();

            dragtobottom.Perform();
        }
    }
}
