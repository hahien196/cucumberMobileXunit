using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Pages;
using SpecFlowAppiumTests.Helpers;

namespace SpecFlowAppiumTests.Navigation
{
    public class CarerHomeNav : INavigationManager
    {
        private AppiumDriver _navigationDriver;
        public CarerHomeNav(AppiumDriver driver)
        {
            _navigationDriver = driver;
        }

        public void NavigateTo()
        {
            PatientLogin patientLogin = new PatientLogin(_navigationDriver);
            patientLogin.NavigateToCarerLogin();
            CarerLogin carerLogin = new CarerLogin(_navigationDriver);
            carerLogin.InputData(Globals.DEFAULT_PATIENT_USERNAME, Globals.DEFAULT_PATIENT_PIN);
            carerLogin.ClickLogin();
        }
    }
}
