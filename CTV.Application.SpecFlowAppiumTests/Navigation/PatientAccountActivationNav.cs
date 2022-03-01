using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using SpecFlowAppiumTests.Pages;

namespace SpecFlowAppiumTests.Navigation
{
    public class PatientAccountActivationNav : INavigationManager
    {
        private AppiumDriver _navigationDriver;
        public PatientAccountActivationNav(AppiumDriver driver)
        {
            _navigationDriver = driver;
        }

        public void NavigateTo()
        {
            PatientLogin patientLogin = new PatientLogin(_navigationDriver);
            patientLogin.navigateToPatientAccountActivation();
        }
    }
}
