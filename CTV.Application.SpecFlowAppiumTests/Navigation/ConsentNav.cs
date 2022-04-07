using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using SpecFlowAppiumTests.Pages;

namespace SpecFlowAppiumTests.Navigation
{
    public class ConsentNav : INavigationManager
    {
        private AppiumDriver _navigationDriver;
        public ConsentNav(AppiumDriver driver)
        {
            _navigationDriver = driver;
        }

        public void NavigateTo()
        {
            PatientLogin patientLogin = new PatientLogin(_navigationDriver);
            patientLogin.DoLogin(Globals.DEFAULT_PATIENT_USERNAME, Globals.DEFAULT_PATIENT_PIN);
        }
    }
}
