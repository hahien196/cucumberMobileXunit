using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowAppiumTests.Pages
{
    public class RejectConsent
    {
        private AppiumDriver _driver;

        public RejectConsent(AppiumDriver driver)
        {
            _driver = driver;
        }

        AppiumElement rejectTitle => _driver.FindElement(MobileBy.AccessibilityId("consentRejectionTitle"));

        public bool RejectPage()
        {
           return true ? rejectTitle.Displayed : false;
        }
    }
}
