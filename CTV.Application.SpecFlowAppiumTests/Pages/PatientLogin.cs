using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium;

namespace SpecFlowAppiumTests.Pages
{
    public class PatientLogin : IPageManager
    {
        private static AppiumDriver _driver;

        public PatientLogin(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        By usernameInputSelector = MobileBy.AccessibilityId("patientLoginUsernameInput");
        By pinInputSelector = MobileBy.AccessibilityId("patientLoginPinInput");
        By loginButtonSelector = MobileBy.AccessibilityId("patientLoginLoginButton");
        By forgottenPinButtonSelector = MobileBy.AccessibilityId("patientLoginForgottenPinButton");
        By activateAccountButtonSelector = MobileBy.AccessibilityId("patientLoginActivateAccountButton");
        By needHelpButtonSelector = MobileBy.AccessibilityId("patientLoginNeedHelpButton");
        By carerLoginButtonSelector = MobileBy.AccessibilityId("patientLoginCarerLoginButton");


        public void InputData(string userName, string password)
        {
            ElementUtils.ActionSendKeys(_driver, usernameInputSelector, userName);
            ElementUtils.ActionSendKeys(_driver, pinInputSelector, password);
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

        public void NavigateToCarerLogin()
        {
            ElementUtils.DoClick(_driver, carerLoginButtonSelector);
        }

        public void NavigateToPatientAccountActivation()
        {
            ElementUtils.DoClick(_driver, activateAccountButtonSelector);
        }

        public void NavigateToPinReset()
        {
            ElementUtils.DoClick(_driver, forgottenPinButtonSelector);
        }

        public void NavigateToNeedHelp()
        {
            ElementUtils.DoClick(_driver, needHelpButtonSelector);
        }
    }
}
