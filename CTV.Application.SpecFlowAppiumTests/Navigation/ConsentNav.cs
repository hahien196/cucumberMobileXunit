using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using SpecFlowAppiumTests.Pages;

namespace SpecFlowAppiumTests.Navigation
{
    public class ConsentNav : INavigationManager
    {
        private AppiumDriver _navigationDriver;
        public ConsentNav(AppiumDriver driver)
        {
            _navigationDriver = driver;
        }

        public void NavigateWithConsent()
        {
            Activation act = new Activation(_navigationDriver);
            act.SendCodeThenContinue();
        }
    }
}
