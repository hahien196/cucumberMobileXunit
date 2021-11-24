using OpenQA.Selenium.Appium;
using System;
using CTV.Application.SpecFlowAppiumTests.Helpers;
using System.Threading;

namespace CTV.Application.SpecFlowAppiumTests.Pages
{
    public class Consent : IPageManager
    {
        private static AppiumDriver _driver;

        public Consent(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        AppiumElement companyLogo => _driver.FindElement(MobileBy.AccessibilityId("companyLogoImage"));


        public bool ValidateElements(string elementName)
        {
            AppiumElement[] appiumWebElements = { companyLogo, };

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
