using OpenQA.Selenium.Appium;
using System;
using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

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
        By iOS_dateOfBirthInputLocator = MobileBy.AccessibilityId("Date Picker");
        By and_DOB_yearSelector = MobileBy.XPath("//*[@resource-id='android:id/date_picker_header_year']");
        By iOS_showYearSelector = MobileBy.AccessibilityId("Show year picker");
        By iOS_hideYearSelector = MobileBy.AccessibilityId("Hide year picker");
        By activateButtonSelector = MobileBy.AccessibilityId("activationContinueButton");
        By noActivationCodeButtonLocator = MobileBy.AccessibilityId("noActivationCodeButton");
        By and_calendarOKButtonLocator = MobileBy.Id("android:id/button1");
        By and_calendarCancelButtonLocator = MobileBy.Id("android:id/button2");
        String and_yearXpath = "//android.widget.ListView/android.widget.TextView[contains(@text,'year')]";
        String iOS_yearXpath = "//XCUIElementTypePickerWheel[@value='year']";
        String iOS_monthXpath = "//XCUIElementTypePickerWheel[@value='month']";
        By nextMonthButton = MobileBy.AccessibilityId("Next month");
        By prevMonthButton = MobileBy.AccessibilityId("Previous month");


        /// <summary>Input data in Activation screen</summary>
        /// <param name="dob">The date of birth is in format "dd MMMM yyyy"</param>
        /// <param name="code">The activation code</param>
        /// <param name="postCode">The postcode</param>
        public void InputData(string code, string dob, string postCode)
        {
            if (Globals.IsIOS())
            {
                dateOfBirthInputLocator = iOS_dateOfBirthInputLocator;
            }
            ElementUtils.DoClick(_driver, codeInputLocator);
            ElementUtils.ActionSendKeys(_driver, codeInputLocator, code); 
            if (Globals.IsAndroid())
            {
                _driver.HideKeyboard();
            }
            if (!String.IsNullOrEmpty(dob))
            {
                ElementUtils.DoClick(_driver, dateOfBirthInputLocator);
                SelectDate(dob);
            }
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
            string yearXpath = "";
            By calendarOKButtonLocator = null;
            By DOB_yearSelector = null;

            if (Globals.IsIOS())
            {
                if (dob.Substring(0,1) == "0")
                {
                    dob = dob.Substring(1);
                }
            }
            var splittedDate = Utilities.SplitDate(dob, " ");
            string day = splittedDate.Item1;
            string month = splittedDate.Item2;
            string year = splittedDate.Item3;

            if (Globals.IsAndroid())
            {
                yearXpath = and_yearXpath;
                calendarOKButtonLocator = and_calendarOKButtonLocator;
                DOB_yearSelector = and_DOB_yearSelector;
                ElementUtils.DoClick(_driver, DOB_yearSelector);

                // select year
                By yearSelector = MobileBy.XPath(yearXpath.Replace("year", year));
                ElementUtils.ScrollToElement(_driver, yearSelector, 0.4, 0.7, 0.5);
                ElementUtils.DoClick(_driver, yearSelector);
                int currentMonth = (int)DateTime.Now.Month;
                int inputtedMonth = (int)Enum.Parse(typeof(Globals.Month), month);

                // move to the selected month
                if (inputtedMonth > currentMonth)
                {
                    for (int i = 0; i < inputtedMonth - currentMonth; i++)
                    {
                        ElementUtils.DoClick(_driver, nextMonthButton);
                    }
                }
                else
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
            else if (Globals.IsIOS())
            {
                yearXpath = iOS_yearXpath;
                ElementUtils.DoClick(_driver, iOS_showYearSelector);
                By yearSelector = MobileBy.XPath(yearXpath.Replace("year", year));
                // scroll to year
                while (_driver.FindElements(By.XPath(iOS_yearXpath.Replace("year", year))).Count == 0) 
                {
                    ElementUtils.ScrollToElement(_driver, yearSelector, 0.55, 0.6, 0.7);
                }

                // scroll to month
                By monthSelector = By.XPath(iOS_monthXpath.Replace("month", month));
                ElementUtils.ScrollToElement(_driver, monthSelector, 0.55, 0.6, 0.3);
                ElementUtils.DoClick(_driver, iOS_hideYearSelector);

                By date = MobileBy.AccessibilityId(day);
                ElementUtils.DoClick(_driver, date);
                ElementUtils.DoClick(_driver, date);
                ElementUtils.DoClick(_driver, iOS_dateOfBirthInputLocator);
            }            
        }

        public void ClickActivateButton()
        {
            ElementUtils.DoClick(_driver, activateButtonSelector);
        }

        public void SubmitData(Table table)
        {
            var dictionary = Utilities.TableToDictionary(table);
            InputData(dictionary["Activation Code"], dictionary["Date of Birth"], dictionary["Postcode"]);
            ClickActivateButton();
        }

    }
}
