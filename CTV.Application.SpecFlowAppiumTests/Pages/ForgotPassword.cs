using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowAppiumTests.Pages
{
    public class ForgotPassword : IPageManager
    {
        private static AppiumDriver _driver;

        public ForgotPassword(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        By emailInputSelector = MobileBy.AccessibilityId("passwordResetEmailInput");
        By resetButtonSelector = MobileBy.AccessibilityId("passwordResetResetButton");
        By passwordResetSuccessText = MobileBy.AccessibilityId("passwordResetSuccessText");



        public void InputData(string email)
        {
            ElementUtils.ActionSendKeys(_driver, emailInputSelector, email);
            if (Globals.IsAndroid())
            {
                _driver.HideKeyboard();
            }
        }

        public void ClickResetButton()
        {
            ElementUtils.DoClick(_driver, resetButtonSelector);
            ElementUtils.WaitForElementVisible(_driver, passwordResetSuccessText);
        }
        public void SubmitData(Table table)
        {
            var dictionary = Utilities.TableToDictionary(table);
            InputData(dictionary["Email"]);
            ClickResetButton();
        }
    }
}
