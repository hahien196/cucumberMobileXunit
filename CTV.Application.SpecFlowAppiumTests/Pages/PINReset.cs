using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowAppiumTests.Pages
{
    public class PINReset : IPageManager
    {
        private static AppiumDriver _driver;

        public PINReset(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        By usernameInputSelector = MobileBy.AccessibilityId("pinResetUsernameInput");
        By resetButtonSelector = MobileBy.AccessibilityId("pinResetResetButton");
        By pinResetSuccessText = MobileBy.AccessibilityId("pinResetSuccessText");

        public void InputData(string userName)
        {
            ElementUtils.ActionSendKeys(_driver, usernameInputSelector, userName);
            if (Globals.IsAndroid())
            {
                _driver.HideKeyboard();
            }
        }

        public void ClickResetButton()
        {
            ElementUtils.DoClick(_driver, resetButtonSelector);
            ElementUtils.WaitForElementVisible(_driver, pinResetSuccessText);
        }

        public void SubmitData(Table table)
        {
            var dictionary = Utilities.TableToDictionary(table);
            InputData(dictionary["Username"]);
            ElementUtils.DoClick(_driver, resetButtonSelector);
        }
    }
}
