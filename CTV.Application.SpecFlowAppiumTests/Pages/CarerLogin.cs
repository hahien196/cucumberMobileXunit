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

        AppiumElement companyLogo => _driver.FindElement(MobileBy.AccessibilityId("companyLogoImage"));
        AppiumElement carerLoginTitle => _driver.FindElement(MobileBy.AccessibilityId("carerLoginTitle"));

        By emailInputSelector = MobileBy.AccessibilityId("carerLoginEmailInput");
        AppiumElement emailInput => _driver.FindElement(emailInputSelector);
        AppiumElement passwordInput => _driver.FindElement(MobileBy.AccessibilityId("carerLoginPasswordInput"));

        By loginButtonSelector = MobileBy.AccessibilityId("carerLoginLoginButton");
        AppiumElement loginButton => _driver.FindElement(loginButtonSelector);

        By forgottenPasswordButtonSelector = MobileBy.AccessibilityId("carerLoginLoginButton");
        AppiumElement forgottenPasswordButton => _driver.FindElement(forgottenPasswordButtonSelector);

        public bool ValidateElements(string elementName)
        {
            ElementUtils.WaitForElementVisible(_driver, emailInputSelector);
            Thread.Sleep(1000);
            AppiumElement[] appiumWebElements = { companyLogo, carerLoginTitle, emailInput, passwordInput, loginButton, forgottenPasswordButton };

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
            ElementUtils.WaitForElementVisible(_driver, emailInputSelector);
            ElementUtils.actionSendKeys(_driver, emailInput, userName);
            ElementUtils.actionSendKeys(_driver, passwordInput, password);
            _driver.HideKeyboard();
        }

        public void clickLogin()
        {
            ElementUtils.WaitForElementClickable(_driver, loginButtonSelector);
            loginButton.Click();
        }

        public void doLogin(string userName, string password)
        {
            inputData(userName, password);
            loginButton.Click();
        }

        public void navigateToPasswordReset()
        {
            ElementUtils.WaitForElementClickable(_driver, forgottenPasswordButtonSelector);
            forgottenPasswordButton.Click();
        }
    }
}
