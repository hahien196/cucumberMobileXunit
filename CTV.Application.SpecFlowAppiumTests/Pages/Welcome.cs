﻿using OpenQA.Selenium.Appium;
using System;
using SpecFlowAppiumTests.Helpers;
using System.Threading;

namespace SpecFlowAppiumTests.Pages
{
    public class Welcome : IPageManager
    {
        private static AppiumDriver _driver;

        public Welcome(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        AppiumElement companyLogo => _driver.FindElement(MobileBy.AccessibilityId("companyLogoImage"));
        AppiumElement welcomeTitle => _driver.FindElement(MobileBy.AccessibilityId("questionSetSelectionTitle"));
        AppiumElement welcomePatient => _driver.FindElement(MobileBy.AccessibilityId("patientName"));


        public bool ValidateElements(string elementName)
        {
            AppiumElement[] appiumWebElements = { companyLogo, welcomeTitle, welcomePatient, };

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
                AppiumElement VPRQuestionSet = _driver.FindElement(MobileBy.XPath("//android.view.View[@text='VPR Pre-Exercise Diary']"));
                Thread.Sleep(3000);
                VPRQuestionSet.Click();
            }
            else if (Globals.IsIOS())
            {
                AppiumElement VPRQuestionSet = _driver.FindElement(MobileBy.XPath("//XCUIElementTypeStaticText[@name='VPR Pre-Exercise Diary']"));
                Thread.Sleep(3000);
                VPRQuestionSet.Click();
            }
        }
    }
}
