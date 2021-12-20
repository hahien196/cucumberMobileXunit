using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Navigation;

namespace SpecFlowAppiumTests.Helpers
{
    public class NavigationManager
    {
        private AppiumDriver _pomdriver;
        private ConsentNav _consent;
        private WelcomeNav _welcome;

        public NavigationManager(AppiumDriver driver)
        {
            _pomdriver = driver;
        }

        public INavigationManager NavigationSwitch(string screen)
        {
            switch (screen)
            {
                case "Consent":
                    {
                        return _consent ??= new ConsentNav(_pomdriver);
                    }
                case "Welcome":
                    {
                        return _welcome ??= new WelcomeNav(_pomdriver);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
