using OpenQA.Selenium.Appium;
using System;
using SpecFlowAppiumTests.Helpers;
using System.Threading;
using OpenQA.Selenium;

namespace SpecFlowAppiumTests.Pages
{
    public class Activation : IPageManager
    {
        private static AppiumDriver _driver;

        public Activation(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        By codeInputParentLocator = MobileBy.XPath("//android.view.View[@content-desc='activationCodeInput']/..");
        By companyLogoSelector = MobileBy.AccessibilityId("companyLogoImage");
        AppiumElement companyLogo => _driver.FindElement(companyLogoSelector);
        AppiumElement pageTitle => _driver.FindElement(MobileBy.AccessibilityId("activationTitle"));
        AppiumElement pageDescription => _driver.FindElement(MobileBy.AccessibilityId("activationDesc"));
        AppiumElement codeInput => _driver.FindElement(MobileBy.AccessibilityId("activationCodeInput"));
        By tandcSelector = MobileBy.AccessibilityId("termsAgreedInput");
        AppiumElement tandc => _driver.FindElement(tandcSelector);
        By continueInputSelector = MobileBy.AccessibilityId("activationContinueInput");
        AppiumElement continueInput => _driver.FindElement(continueInputSelector);


        public bool ValidateElements(string elementName)
        {
            ElementUtils.WaitForElementVisible(_driver, companyLogoSelector);
            Thread.Sleep(1000);
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
                parent = _driver.FindElement(codeInputParentLocator);
                parent.SendKeys(Globals.activateCode);
            }
            else if (Globals.IsIOS())
            {
                codeInput.SendKeys(Globals.activateCode);
            }

            ElementUtils.WaitForElementClickable(_driver, tandcSelector);
            tandc.Click();
            ElementUtils.WaitForElementClickable(_driver, continueInputSelector);
            continueInput.Click();
        }
    }
}
