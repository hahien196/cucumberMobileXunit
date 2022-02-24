using OpenQA.Selenium.Appium;
using System;
using SpecFlowAppiumTests.Helpers;
using System.Threading;
using OpenQA.Selenium;

namespace SpecFlowAppiumTests.Pages
{
    public class Welcome : IPageManager
    {
        private static AppiumDriver _driver;
        AppiumElement VPRQuestionSetMenu;
        By VPRQuestionSetLocator;
        public Welcome(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        AppiumElement acceptInput => _driver.FindElement(MobileBy.AccessibilityId("acceptInput"));
        AppiumElement companyLogo => _driver.FindElement(MobileBy.AccessibilityId("companyLogoImage"));
        static By welcomeTitleLocator = MobileBy.AccessibilityId("questionSetSelectionTitle");
        AppiumElement welcomeTitle => _driver.FindElement(welcomeTitleLocator);
        static By welcomePatientLocator = MobileBy.AccessibilityId("patientName");
        AppiumElement welcomePatient => _driver.FindElement(welcomePatientLocator);
        By and_VPRQuestionSetLocator = MobileBy.XPath("//android.view.View[@text='VPR Pre-Exercise Diary']");
        By ios_VPRQuestionSetLocator = MobileBy.XPath("//XCUIElementTypeStaticText[@name='VPR Pre-Exercise Diary']");

        public bool ValidateElements(string elementName)
        {
            ElementUtils.WaitForElementVisible(_driver, welcomePatientLocator);
            Thread.Sleep(1000);
            AppiumElement[] appiumWebElements = { companyLogo, welcomeTitle, welcomePatient};

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

        public void SelectVPRQuestionSet()
        {
            if (Globals.IsAndroid())
            {
                VPRQuestionSetLocator = and_VPRQuestionSetLocator;
            }
            else if (Globals.IsIOS())
            {
                VPRQuestionSetLocator = ios_VPRQuestionSetLocator;
            }

            try
            {
                VPRQuestionSetMenu = _driver.FindElement(VPRQuestionSetLocator);
            }
            catch (Exception e)
            {
                ElementUtils.ScrollToBottom(_driver);
                Thread.Sleep(1000);
                acceptInput.Click();
                ElementUtils.WaitForElementClickable(_driver, VPRQuestionSetLocator);
                VPRQuestionSetMenu = _driver.FindElement(VPRQuestionSetLocator);
            }
            VPRQuestionSetMenu.Click();
        }
    }
}
