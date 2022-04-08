using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using SpecFlowAppiumTests.Pages;

namespace SpecFlowAppiumTests.Navigation
{
    public class SelectPatientNav : INavigationManager
    {
        private AppiumDriver _navigationDriver;
        public SelectPatientNav(AppiumDriver driver)
        {
            _navigationDriver = driver;
        }

        public void NavigateTo()
        {
            CarerLoginNav carerLoginNav = new CarerLoginNav(_navigationDriver);
            carerLoginNav.NavigateTo();
            CarerLogin carerLogin = new CarerLogin(_navigationDriver);
            carerLogin.InputData(Globals.DEFAULT_CARER_EMAIL, Globals.DEFAULT_CARER_PASSWORD);
            carerLogin.ClickLogin();
        }
    }
}
