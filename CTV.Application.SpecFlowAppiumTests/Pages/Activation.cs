using OpenQA.Selenium.Appium;
using System;
using CTV.Application.SpecFlowAppiumTests.Helpers;
using System.Threading;

namespace CTV.Application.SpecFlowAppiumTests.Pages
{
    public class Activation : IPageManager
    {
        private static AppiumDriver _driver;

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

        public void SendCodeThenContinue()
        {
            AppiumElement parent;
            if(Globals.IsAndroid())
            { 
                parent = _driver.FindElement(MobileBy.XPath("//android.view.View[@content-desc='activationCodeInput']/.."));
                parent.SendKeys("123456");
            }
            else if (Globals.IsIOS())
            {
                codeInput.SendKeys("123456");
            }
            
            Thread.Sleep(500);
            tandc.Click();
            Thread.Sleep(2000);
            continueInput.Click();
        }
    }
}
