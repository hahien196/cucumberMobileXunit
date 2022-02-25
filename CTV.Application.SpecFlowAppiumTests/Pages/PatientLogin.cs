using OpenQA.Selenium.Appium;
using System;
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

        AppiumElement companyLogo => _driver.FindElement(MobileBy.AccessibilityId("companyLogoImage"));
        AppiumElement patientLoginTitle => _driver.FindElement(MobileBy.AccessibilityId("patientLoginTitle"));

        By usernameInputSelector = MobileBy.AccessibilityId("patientLoginUsernameInput");
        AppiumElement usernameInput => _driver.FindElement(usernameInputSelector);
        AppiumElement pinInput => _driver.FindElement(MobileBy.AccessibilityId("patientLoginPinInput"));

        By loginButtonSelector = MobileBy.AccessibilityId("patientLoginLoginButton");
        AppiumElement loginButton => _driver.FindElement(loginButtonSelector);
        AppiumElement forgottenPinButton => _driver.FindElement(MobileBy.AccessibilityId("patientLoginForgottenPinButton"));
        AppiumElement activateAccountButton => _driver.FindElement(MobileBy.AccessibilityId("patientLoginActivateAccountButton"));
        AppiumElement needHelpButton => _driver.FindElement(MobileBy.AccessibilityId("patientLoginNeedHelpButton"));
        AppiumElement carerLoginButton => _driver.FindElement(MobileBy.AccessibilityId("patientLoginCarerLoginButton"));

        public bool ValidateElements(string elementName)
        {
            ElementUtils.WaitForElementVisible(_driver, usernameInputSelector);
            AppiumElement[] appiumWebElements = { companyLogo, patientLoginTitle, usernameInput, pinInput, loginButton, forgottenPinButton, activateAccountButton, needHelpButton, carerLoginButton };

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

        public void inputData(string userName, string password)
        {
             usernameInput.SendKeys(userName);
             pinInput.SendKeys(password);            
        }

        public void clickLogin()
        {
            loginButton.Click();
        }

        public void navigateToCarerLogin()
        {
            carerLoginButton.Click();
        }

        public void navigateToPatientAccountActivation()
        {
            activateAccountButton.Click();
        }

        public void navigateToPinReset()
        {
            forgottenPinButton.Click();
        }

        public void navigateToNeedHelp()
        {
            needHelpButton.Click();
        }
    }
}
