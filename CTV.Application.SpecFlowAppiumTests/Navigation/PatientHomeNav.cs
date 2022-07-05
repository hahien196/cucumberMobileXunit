using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Pages;
using SpecFlowAppiumTests.Helpers;

namespace SpecFlowAppiumTests.Navigation
{
    public class PatientHomeNav : INavigationManager
    {
        private AppiumDriver _navigationDriver;
        public PatientHomeNav(AppiumDriver driver)
        {
            _navigationDriver = driver;
        }

        public void NavigateTo()
        {
            PatientLogin patientLogin = new PatientLogin(_navigationDriver);
            patientLogin.InputData(Globals.DEFAULT_PATIENT_USERNAME, Globals.DEFAULT_PATIENT_PIN);
            patientLogin.ClickLogin();
            Consent cons = new Consent(_navigationDriver);
            cons.ApproveConsent();
        }

    }
}
