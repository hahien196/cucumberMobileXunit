using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium.Appium;
using System;
using System.Threading;
using OpenQA.Selenium;

namespace SpecFlowAppiumTests.Pages
{
    public class VPRQuestionSet
    {

        private static AppiumDriver _driver;
        AppiumElement yesButton;
        AppiumElement noButton;
        AppiumElement betterThanYesterday;
        AppiumElement sameAsYesterday;
        AppiumElement worseThanYesterday;
        AppiumElement nextButton;
        AppiumElement saveButton;

        // android locator
        By and_q1YesLocator = MobileBy.AccessibilityId("have-you-taken-your-inhalers-today-as-prescribed-yes");
        By and_q1NoLocator = MobileBy.AccessibilityId("have-you-taken-your-inhalers-today-as-prescribed-no");
        By and_q1NextBtnLocator = MobileBy.XPath("//android.view.View/android.widget.Button");
        By and_q2Op1Locator = MobileBy.AccessibilityId("how-are-you-today-better-than-yesterday");

        By and_q2Op2Locator = MobileBy.AccessibilityId("how-are-you-today-same-as-yesterday");
        By and_q2Op3Locator = MobileBy.AccessibilityId("how-are-you-today-worse-than-yesterday");
        By and_q2NextBtnLocator = MobileBy.XPath("//android.view.View/android.widget.Button");

        By and_q3YesLocator = MobileBy.AccessibilityId("do-you-feel-able-to-do-your-exercises-session-today-yes");
        By and_q3NoLocator = MobileBy.AccessibilityId("do-you-feel-able-to-do-your-exercises-session-today-no");
        By and_q3NextBtnLocator = MobileBy.XPath("//android.view.View/android.widget.Button");
        By and_saveBtnLocator = MobileBy.XPath("//android.view.View/android.widget.Button");

        // ios locator
        By ios_q1YesLocator = MobileBy.AccessibilityId("Yes");
        By ios_q1NoLocator = MobileBy.AccessibilityId("No");
        By ios_q1NextBtnLocator = MobileBy.AccessibilityId("Next");
        By ios_q2Op1Locator = MobileBy.AccessibilityId("Better than yesterday");
        By ios_q2Op2Locator = MobileBy.AccessibilityId("Same as yesterday");
        By ios_q2Op3Locator = MobileBy.AccessibilityId("Worse than yesterday");
        By ios_q2NextBtnLocator = MobileBy.AccessibilityId("Next");
        By ios_q3YesLocator = MobileBy.AccessibilityId("Yes");
        By ios_q3NoLocator = MobileBy.AccessibilityId("No");
        By ios_q3NextBtnLocator = MobileBy.AccessibilityId("Next");
        By ios_saveBtnLocator = MobileBy.AccessibilityId("Save");

        public VPRQuestionSet(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        private void QuestionOne(string q1)
        {
            if (Globals.IsAndroid())
            {
                ElementUtils.WaitForElementClickable(_driver, and_q1YesLocator);
                yesButton = _driver.FindElement(and_q1YesLocator);
                noButton = _driver.FindElement(and_q1NoLocator);
                nextButton = _driver.FindElement(and_q1NextBtnLocator);
            }
            else if (Globals.IsIOS())
            {
                ElementUtils.WaitForElementClickable(_driver, ios_q1YesLocator);
                yesButton = _driver.FindElement(ios_q1YesLocator);
                noButton = _driver.FindElement(ios_q1NoLocator);
                nextButton = _driver.FindElement(ios_q1NextBtnLocator);
            }

            if (q1.ToLower() == "yes")
            {
                yesButton.Click();
            }
            else if (q1.ToLower() == "no")
            {
                noButton.Click();
            }

            nextButton.Click();
        }

        private void QuestionOTwo(string q2)
        {
            if (Globals.IsAndroid())
            {
                ElementUtils.WaitForElementClickable(_driver, and_q2Op1Locator);
                betterThanYesterday = _driver.FindElement(and_q2Op1Locator);
                sameAsYesterday = _driver.FindElement(and_q2Op2Locator);
                worseThanYesterday = _driver.FindElement(and_q2Op3Locator);
                nextButton = _driver.FindElement(and_q2NextBtnLocator);
            }
            else if (Globals.IsIOS())
            {
                ElementUtils.WaitForElementClickable(_driver, ios_q2Op1Locator);
                betterThanYesterday = _driver.FindElement(ios_q2Op1Locator);
                sameAsYesterday = _driver.FindElement(ios_q2Op2Locator);
                worseThanYesterday = _driver.FindElement(ios_q2Op3Locator);
                nextButton = _driver.FindElement(ios_q2NextBtnLocator);
            }

            switch (q2)
            {
                case "Better than yesterday":
                    {
                        betterThanYesterday.Click();
                        break;
                    }

                case "Same as yesterday":
                    {
                        sameAsYesterday.Click();
                        break;
                    }
                case "Worse than yesterday":
                    {
                        worseThanYesterday.Click();
                        break;
                    }
            }

            nextButton.Click();
        }

        private void QuestionThree(string q3)
        {
            if (Globals.IsAndroid())
            {
                ElementUtils.WaitForElementClickable(_driver, and_q3YesLocator);
                yesButton = _driver.FindElement(and_q3YesLocator);
                noButton = _driver.FindElement(and_q3NoLocator);
                nextButton = _driver.FindElement(and_q3NextBtnLocator);
            }
            else if (Globals.IsIOS())
            {
                ElementUtils.WaitForElementClickable(_driver, ios_q3YesLocator);
                yesButton = _driver.FindElement(ios_q3YesLocator);
                noButton = _driver.FindElement(ios_q3NoLocator);
                nextButton = _driver.FindElement(ios_q3NextBtnLocator);
            }

            if (q3.ToLower() == "yes")
            {
                yesButton.Click();
            }
            else if (q3.ToLower() == "no")
            {
                noButton.Click();
            }

            nextButton.Click();
        
        }

        public bool CompletedQuestions(string q1, string q2, string q3)
        {
            try
            {
                QuestionOne(q1);
                QuestionOTwo(q2);
                QuestionThree(q3);
                return true;
            }

            catch (Exception) { return false; }
        }

        public bool AnswersMatchExpected(string q1, string q2, string q3)
        {
            if (Globals.IsAndroid())
            {
                ElementUtils.WaitForElementClickable(_driver, and_saveBtnLocator);
                saveButton = _driver.FindElement(and_saveBtnLocator);
            }
            else if (Globals.IsIOS())
            {
                ElementUtils.WaitForElementClickable(_driver, ios_saveBtnLocator);
                saveButton = _driver.FindElement(ios_saveBtnLocator);
            }

            string pageSource = _driver.PageSource;
            Thread.Sleep(1000);
            if (pageSource.Contains(q1) && pageSource.Contains(q2) && pageSource.Contains(q3))
            {
                saveButton.Click();
                return true; 
            }
            else { return false; }
        }
    }
}
