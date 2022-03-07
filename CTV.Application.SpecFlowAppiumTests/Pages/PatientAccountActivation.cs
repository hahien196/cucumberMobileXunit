using OpenQA.Selenium.Appium;
using System;
using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium;

namespace SpecFlowAppiumTests.Pages
{
    public class PatientAccountActivation : IPageManager
    {
        private static AppiumDriver _driver;

        public PatientAccountActivation(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }


        By codeInputLocator = MobileBy.AccessibilityId("activationCodeInput");
        By postcodeInputLocator = MobileBy.AccessibilityId("activationPostcodeInput");
        By dateOfBirthInputLocator = MobileBy.AccessibilityId("activationDateOfBirthInput");
        By DOB_yearSelector = MobileBy.XPath("//*[@resource-id='android:id/date_picker_header_year']");
        By calendarOKButtonLocator = MobileBy.Id("android:id/button1");
        By calendarCancelButtonLocator = MobileBy.Id("android:id/button2");
        By activateButtonSelector = MobileBy.AccessibilityId("activationContinueButton");
        By noActivationCodeButtonLocator = MobileBy.AccessibilityId("noActivationCodeButton");
        String yearXpath = "//android.widget.ListView/android.widget.TextView[contains(@text,'year')]";
        By nextMonthButton = MobileBy.AccessibilityId("Next month");
        By prevMonthButton = MobileBy.AccessibilityId("Previous month");


        /// <summary>Input data in Activation screen</summary>
        /// <param name="dob">The date of birth is in format "dd MMMM yyyy"</param>
        /// <param name="code">The activation code</param>
        /// <param name="postCode">The postcode</param>
        public void InputData(string code, string dob, string postCode)
        {
            ElementUtils.ActionSendKeys(_driver, codeInputLocator, code);
            ElementUtils.DoClick(_driver, dateOfBirthInputLocator);
            SelectDate(dob);
            ElementUtils.ActionSendKeys(_driver, postcodeInputLocator, postCode);
            if (Globals.IsAndroid())
            {
                _driver.HideKeyboard();
            }
        }

        /// <summary>Select a date in date picker. The date is in format "dd MMMM yyyy"</summary>
        /// <param name="dob">The date of birth in format "dd MMMM yyyy"</param>
        public void SelectDate (string dob)
        {
            ElementUtils.DoClick(_driver, DOB_yearSelector);

            var splittedDate = Utilities.SplitDate(dob, " ");
            var month = splittedDate.Item2;
            var year = splittedDate.Item3;

            // select year
            By yearSelector = MobileBy.XPath(yearXpath.Replace("year", year));
            ElementUtils.ScrollUpToElement(_driver, yearSelector);
            ElementUtils.DoClick(_driver, yearSelector);
            int currentMonth = (int)DateTime.Now.Month;
            int inputtedMonth = (int)Enum.Parse(typeof(Globals.Month), month);

            // move to the selected month
            if (inputtedMonth > currentMonth)
            {
                for (int i = 0; i < inputtedMonth-currentMonth; i++)
                {
                    ElementUtils.DoClick(_driver, nextMonthButton);
                }
            } else
            {
                for (int i = 0; i < currentMonth - inputtedMonth; i++)
                {
                    ElementUtils.DoClick(_driver, prevMonthButton);
                }
            }

            // select date
            By date = MobileBy.AccessibilityId(dob);
            ElementUtils.DoClick(_driver, date);

            ElementUtils.DoClick(_driver, calendarOKButtonLocator);

        }
        public void ClickActivateButton()
        {
            ElementUtils.DoClick(_driver, activateButtonSelector);
        }

    }
}
