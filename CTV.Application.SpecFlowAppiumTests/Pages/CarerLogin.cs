using OpenQA.Selenium.Appium;
using System;
using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium;
using System.Threading;

namespace SpecFlowAppiumTests.Pages
{
    public class CarerLogin : IPageManager
    {
        private static AppiumDriver _driver;

        public CarerLogin(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        By emailInputSelector = MobileBy.AccessibilityId("carerLoginEmailInput");
        By passwordInputSelector = MobileBy.AccessibilityId("carerLoginPasswordInput");
        By loginButtonSelector = MobileBy.AccessibilityId("carerLoginLoginButton");
        By forgottenPasswordButtonSelector = MobileBy.AccessibilityId("carerLoginForgottenPasswordButton");


        public void InputData(string userName, string password)
        {
            ElementUtils.ActionSendKeys(_driver, emailInputSelector, userName);
            ElementUtils.ActionSendKeys(_driver, passwordInputSelector, password);
            if (Globals.IsAndroid())
            {
                _driver.HideKeyboard();
            }
        }

        public void ClickLogin()
        {
            ElementUtils.DoClick(_driver, loginButtonSelector);
        }

        public void DoLogin(string userName, string password)
        {
            InputData(userName, password);
            ClickLogin();
        }

        public void NavigateToPasswordReset()
        {
            ElementUtils.DoClick(_driver, forgottenPasswordButtonSelector);
        }
    }
}
