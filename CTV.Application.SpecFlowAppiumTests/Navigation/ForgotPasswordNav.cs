using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using SpecFlowAppiumTests.Pages;

namespace SpecFlowAppiumTests.Navigation
{
    public class ForgotPasswordNav : INavigationManager
    {
        private AppiumDriver _navigationDriver;
        public ForgotPasswordNav(AppiumDriver driver)
        {
            _navigationDriver = driver;
        }

        public void NavigateTo()
        {
            PatientLogin patientLogin = new PatientLogin(_navigationDriver);
            patientLogin.NavigateToCarerLogin();
            CarerLogin carerLogin = new CarerLogin(_navigationDriver);
            carerLogin.NavigateToPasswordReset();
        }
    }
}
