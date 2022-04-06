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
            WelcomeNav homeNav = new(_navigationDriver);
            homeNav.NavigateTo();
            Welcome home = new Welcome(_navigationDriver);
            home.NavigateToAccount();
        }
    }
}
