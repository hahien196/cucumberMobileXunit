using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using SpecFlowAppiumTests.Pages;

namespace SpecFlowAppiumTests.Navigation
{
    public class CarerLoginNav : INavigationManager
    {
        private AppiumDriver _navigationDriver;
        public CarerLoginNav(AppiumDriver driver)
        {
            _navigationDriver = driver;
        }

        public void NavigateTo()
        {
            PatientLogin patientLogin = new PatientLogin(_navigationDriver);
            patientLogin.NavigateToCarerLogin();
            //CarerLogin carerLogin = new CarerLogin(_navigationDriver);
            //carerLogin.InputData(Globals.DEFAULT_CARER_EMAIL, Globals.DEFAULT_CARER_PASSWORD);
        }
    }
}
