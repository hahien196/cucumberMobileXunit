using OpenQA.Selenium.Appium;
using System;
using CTV.Application.SpecFlowAppiumTests.Helpers;

namespace CTV.Application.SpecFlowAppiumTests.Pages
{
    public class Activation : IPageManager
    {
        private static AppiumDriver _driver;
        AppiumElement spiritLogo;
        //private static string xpathToLogo = @;

        public Activation(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        AppiumElement companyLogo => _driver.FindElement(MobileBy.AccessibilityId("companyLogoImage"));
        AppiumElement pageTitle => _driver.FindElement(MobileBy.AccessibilityId("activationTitle"));
        AppiumElement pageDescription => _driver.FindElement(MobileBy.AccessibilityId("activationDesc"));
        AppiumElement codeInput => _driver.FindElement(MobileBy.AccessibilityId("activationCodeInput"));
        AppiumElement tandc => _driver.FindElement(MobileBy.AccessibilityId("termsAgreedInput"));
        AppiumElement continueInput => _driver.FindElement(MobileBy.AccessibilityId("activationContinueInput"));


        public bool ValidateElements(string elementName)
        {
            AppiumElement[] appiumWebElements = { companyLogo, pageTitle, pageDescription, codeInput, tandc, continueInput };

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
