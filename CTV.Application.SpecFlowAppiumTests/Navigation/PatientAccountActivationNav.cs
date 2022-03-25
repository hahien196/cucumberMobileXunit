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
            patientLogin.NavigateToPatientAccountActivation();
            //PatientAccountActivation act = new PatientAccountActivation(_navigationDriver);
            //act.InputData(Globals.DEFAULT_PATIENT_ACTIVE_CODE, Globals.DEFAULT_PATIENT_DOB, Globals.DEFAULT_PATIENT_POSTCODE);
        }
    }
}
