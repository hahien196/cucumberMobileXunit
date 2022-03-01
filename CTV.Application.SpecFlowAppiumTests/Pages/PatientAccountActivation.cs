using OpenQA.Selenium.Appium;
using System;
using SpecFlowAppiumTests.Helpers;
using System.Threading;
using OpenQA.Selenium;

namespace SpecFlowAppiumTests.Pages
{
    public class PatientAccountActivation : IPageManager
    {
        private static AppiumDriver _driver;

        public PatientAccountActivation(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        By codeInputParentLocator = MobileBy.XPath("//android.view.View[@content-desc='activationCodeInput']/..");

        By companyLogoSelector = MobileBy.AccessibilityId("companyLogoImage");
        AppiumElement companyLogo => _driver.FindElement(companyLogoSelector);
        AppiumElement pageTitle => _driver.FindElement(MobileBy.AccessibilityId("activationTitle"));
        AppiumElement codeInput => _driver.FindElement(MobileBy.AccessibilityId("activationCodeInput"));
        AppiumElement activationPostcodeInput => _driver.FindElement(MobileBy.AccessibilityId("activationPostcodeInput"));
        AppiumElement activationDateOfBirthInput => _driver.FindElement(MobileBy.AccessibilityId("activationDateOfBirthInput"));
        AppiumElement calendarOKButton => _driver.FindElement(By.Id("android:id/button1"));
        AppiumElement calendarCancelButton => _driver.FindElement(By.Id("android:id/button2"));

        By ativateButtonSelector = MobileBy.AccessibilityId("activationContinueButton");
        AppiumElement ativateButton => _driver.FindElement(ativateButtonSelector);
        AppiumElement noActivationCodeButton => _driver.FindElement(MobileBy.AccessibilityId("noActivationCodeButton"));
        public bool ValidateElements(string elementName)
        {
            ElementUtils.WaitForElementVisible(_driver, companyLogoSelector);
            Thread.Sleep(1000);
            AppiumElement[] appiumWebElements = { companyLogo, pageTitle, codeInput, activationPostcodeInput, activationDateOfBirthInput, ativateButton, noActivationCodeButton };

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

        // need to update
        public void SendCodeThenContinue()
        {
            AppiumElement parent;
            if(Globals.IsAndroid())
            { 
                parent = _driver.FindElement(codeInputParentLocator);
                parent.SendKeys(Globals.ACTIVATE_CODE);
            }
            else if (Globals.IsIOS())
            {
                codeInput.SendKeys(Globals.ACTIVATE_CODE);
            }

            ElementUtils.WaitForElementClickable(_driver, ativateButtonSelector);
            ativateButton.Click();
        }
    }
}
