using OpenQA.Selenium.Appium;
using System;
using CTV.Application.SpecFlowAppiumTests.Helpers;
using System.Threading;
using System.Drawing;
using OpenQA.Selenium.Appium.MultiTouch;

namespace CTV.Application.SpecFlowAppiumTests.Pages
{
    public class Welcome : IPageManager
    {
        private static AppiumDriver _driver;

        public Welcome(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        AppiumElement companyLogo => _driver.FindElement(MobileBy.AccessibilityId("companyLogoImage"));
        AppiumElement welcomeTitle => _driver.FindElement(MobileBy.AccessibilityId("welcomeTitle"));
        AppiumElement welcomePatient => _driver.FindElement(MobileBy.AccessibilityId("patientName"));


        public bool ValidateElements(string elementName)
        {
            AppiumElement[] appiumWebElements = { companyLogo, welcomeTitle, welcomePatient, };

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
    }
}
