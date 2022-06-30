using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using SpecFlowAppiumTests.Pages;

namespace SpecFlowAppiumTests.Navigation
{
    public class AccountNav : INavigationManager
    {
        private AppiumDriver _navigationDriver;
        public AccountNav(AppiumDriver driver)
        {
            _navigationDriver = driver;
        }

        public void NavigateTo()
        {
            PatientHomeNav homeNav = new(_navigationDriver);
            homeNav.NavigateTo();
            PatientHome home = new(_navigationDriver);
            home.NavigateToAccount();
        }
    }
}
