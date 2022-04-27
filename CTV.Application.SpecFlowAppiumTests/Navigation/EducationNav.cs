using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Pages;
using SpecFlowAppiumTests.Helpers;

namespace SpecFlowAppiumTests.Navigation
{
    public class EducationNav : INavigationManager
    {
        private AppiumDriver _navigationDriver;
        public EducationNav(AppiumDriver driver)
        {
            _navigationDriver = driver;
        }

        public void NavigateTo()
        {
            HomeNav homeNav = new HomeNav(_navigationDriver);
            homeNav.NavigateTo();
            Home home = new Home(_navigationDriver);
            home.NavigateToEducation();
        }

    }
}
