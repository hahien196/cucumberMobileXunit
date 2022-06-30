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
            PatientHomeNav homeNav = new PatientHomeNav(_navigationDriver);
            homeNav.NavigateTo();
            PatientHome home = new PatientHome(_navigationDriver);
            home.NavigateToEducation();
        }

    }
}
