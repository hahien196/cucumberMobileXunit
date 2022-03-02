using OpenQA.Selenium.Appium;
using System;
using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium;
using System.Threading;

namespace SpecFlowAppiumTests.Pages
{
    public class ForgotPassword : IPageManager
    {
        private static AppiumDriver _driver;

        public ForgotPassword(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        AppiumElement companyLogo => _driver.FindElement(MobileBy.AccessibilityId("companyLogoImage"));
        AppiumElement passwordResetTitle => _driver.FindElement(MobileBy.AccessibilityId("passwordResetTitle"));
        AppiumElement passwordResetDescription => _driver.FindElement(MobileBy.AccessibilityId("passwordResetDescription"));

        By emailInputSelector = MobileBy.AccessibilityId("passwordResetEmailInput");
        AppiumElement emailInput => _driver.FindElement(emailInputSelector);

        By resetButtonSelector = MobileBy.AccessibilityId("passwordResetResetButton");
        AppiumElement resetButton => _driver.FindElement(resetButtonSelector);

        public bool ValidateElements(string elementName)
        {
            ElementUtils.WaitForElementVisible(_driver, emailInputSelector);
            Thread.Sleep(1000);
            AppiumElement[] appiumWebElements = { companyLogo, passwordResetTitle, passwordResetDescription, emailInput, resetButton };

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

        public void inputData(string email)
        {
            ElementUtils.WaitForElementVisible(_driver, emailInputSelector);
            ElementUtils.actionSendKeys(_driver, emailInput, email);
            _driver.HideKeyboard();
        }

        public void clickResetButton()
        {
            ElementUtils.WaitForElementClickable(_driver, resetButtonSelector);
            resetButton.Click();
        }
    }
}
