using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using SpecFlowAppiumTests.Pages;

namespace SpecFlowAppiumTests.Navigation
{
    public class ContactNav : INavigationManager
    {
        private AppiumDriver _navigationDriver;
        public ContactNav(AppiumDriver driver)
        {
            _navigationDriver = driver;
        }

        public void NavigateTo()
        {
            PatientHomeNav homeNav = new(_navigationDriver);
            homeNav.NavigateTo();
            PatientHome home = new PatientHome(_navigationDriver);
            home.NavigateToContact();
        }
    }
}
