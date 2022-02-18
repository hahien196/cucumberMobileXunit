using OpenQA.Selenium.Appium;


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
