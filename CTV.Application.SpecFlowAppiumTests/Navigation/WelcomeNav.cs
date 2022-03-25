using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Pages;
using SpecFlowAppiumTests.Helpers;

namespace SpecFlowAppiumTests.Navigation
{
    public class WelcomeNav : INavigationManager
    {
        private AppiumDriver _navigationDriver;
        public WelcomeNav(AppiumDriver driver)
        {
            _navigationDriver = driver;
        }

        public void NavigateTo()
        {
            PatientLogin patientLogin = new PatientLogin(_navigationDriver);
            patientLogin.DoLogin(Globals.DEFAULT_PATIENT_USERNAME, Globals.DEFAULT_PATIENT_PIN);
            Consent cons = new Consent(_navigationDriver);
            cons.ApproveConsent();
        }

    }
}
