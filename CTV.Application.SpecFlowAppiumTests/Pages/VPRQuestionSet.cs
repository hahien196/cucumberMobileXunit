using CTV.Application.SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium.Appium;
using System;
using System.Threading;

namespace CTV.Application.SpecFlowAppiumTests.Pages
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

        public VPRQuestionSet(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

        private void QuestionOne(string q1)
        {
            Thread.Sleep(1000);
            if (Globals.IsAndroid())
            {
                yesButton = _driver.FindElement(MobileBy.XPath("//android.view.View[@content-desc='have-you-taken-your-inhalers-today-as-prescribed-yes']"));
                noButton = _driver.FindElement(MobileBy.XPath("//android.view.View[@content-desc='have-you-taken-your-inhalers-today-as-prescribed-no']"));
                nextButton = _driver.FindElement(MobileBy.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/androidx.compose.ui.platform.ComposeView/android.view.View/android.view.View/android.view.View/android.view.View[2]/android.view.View[3]/android.widget.Button"));
            }
            else if (Globals.IsIOS())
            {
                yesButton = _driver.FindElement(MobileBy.AccessibilityId("Yes"));
                noButton = _driver.FindElement(MobileBy.AccessibilityId("No"));
                nextButton = _driver.FindElement(MobileBy.AccessibilityId("Next"));
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
            Thread.Sleep(1000);
            if (Globals.IsAndroid())
            {
                betterThanYesterday = _driver.FindElement(MobileBy.XPath("//android.view.View[@content-desc='how-are-you-today-better-than-yesterday']"));
                sameAsYesterday = _driver.FindElement(MobileBy.XPath("//android.view.View[@content-desc='how-are-you-today-same-as-yesterday']"));
                worseThanYesterday = _driver.FindElement(MobileBy.XPath("//android.view.View[@content-desc='how-are-you-today-worse-than-yesterday']"));
                nextButton = _driver.FindElement(MobileBy.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/androidx.compose.ui.platform.ComposeView/android.view.View/android.view.View/android.view.View/android.view.View[2]/android.view.View[3]/android.widget.Button"));
            }
            else if (Globals.IsIOS())
            {
                betterThanYesterday = _driver.FindElement(MobileBy.AccessibilityId("Better than yesterday"));
                sameAsYesterday = _driver.FindElement(MobileBy.AccessibilityId("Same as yesterday"));
                worseThanYesterday = _driver.FindElement(MobileBy.AccessibilityId("Worse than yesterday"));
                nextButton = _driver.FindElement(MobileBy.AccessibilityId("Next"));
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
            Thread.Sleep(1000);
            if (Globals.IsAndroid())
            {
                yesButton = _driver.FindElement(MobileBy.XPath("//android.view.View[@content-desc='do-you-feel-able-to-do-your-exercises-session-today-yes']"));
                noButton = _driver.FindElement(MobileBy.XPath("//android.view.View[@content-desc='do-you-feel-able-to-do-your-exercises-session-today-no']"));
                nextButton = _driver.FindElement(MobileBy.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/androidx.compose.ui.platform.ComposeView/android.view.View/android.view.View/android.view.View/android.view.View[2]/android.view.View[3]/android.widget.Button"));
            }
            else if (Globals.IsIOS())
            {
                yesButton = _driver.FindElement(MobileBy.AccessibilityId("Yes"));
                noButton = _driver.FindElement(MobileBy.AccessibilityId("No"));
                nextButton = _driver.FindElement(MobileBy.AccessibilityId("Next"));
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
                Thread.Sleep(500);
                return true;
            }

            catch (Exception) { return false; }
        }

        public bool AnswersMatchExpected(string q1, string q2, string q3)
        {
            Thread.Sleep(1000);
            AppiumElement saveButton = _driver.FindElement(MobileBy.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/androidx.compose.ui.platform.ComposeView/android.view.View/android.view.View/android.view.View/android.view.View[2]/android.view.View[3]/android.widget.Button")); 

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
