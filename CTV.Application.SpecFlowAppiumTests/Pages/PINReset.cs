using OpenQA.Selenium.Appium;
using System;
using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium;
using System.Threading;

namespace SpecFlowAppiumTests.Pages
{
    public class PINReset : IPageManager
    {
        private static AppiumDriver _driver;

        public PINReset(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        AppiumElement companyLogo => _driver.FindElement(MobileBy.AccessibilityId("companyLogoImage"));
        AppiumElement pinResetTitle => _driver.FindElement(MobileBy.AccessibilityId("pinResetTitle"));
        AppiumElement pinResetDescription => _driver.FindElement(MobileBy.AccessibilityId("pinResetDescription"));

        By usernameInputSelector = MobileBy.AccessibilityId("pinResetUsernameInput");
        AppiumElement usernameInput => _driver.FindElement(usernameInputSelector);

        By resetButtonSelector = MobileBy.AccessibilityId("pinResetResetButton");
        AppiumElement resetButton => _driver.FindElement(resetButtonSelector);

        public bool ValidateElements(string elementName)
        {
            ElementUtils.WaitForElementVisible(_driver, usernameInputSelector);
            Thread.Sleep(1000);
            AppiumElement[] appiumWebElements = { companyLogo, pinResetTitle, pinResetDescription, usernameInput, resetButton };

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

        public void inputData(string userName)
        {
            ElementUtils.WaitForElementVisible(_driver, usernameInputSelector);
            ElementUtils.actionSendKeys(_driver, usernameInput, userName);
            _driver.HideKeyboard();
        }

        public void clickResetButton()
        {
            ElementUtils.WaitForElementClickable(_driver, resetButtonSelector);
            resetButton.Click();
        }
    }
}
