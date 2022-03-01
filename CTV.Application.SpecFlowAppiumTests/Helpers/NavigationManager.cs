using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Navigation;

namespace SpecFlowAppiumTests.Helpers
{
    public class NavigationManager
    {
        private AppiumDriver _pomdriver;
        private ConsentNav _consent;
        private WelcomeNav _welcome;
        private CarerLoginNav _carerLoginNav;
        private PatientAccountActivationNav _patientActivationNav;

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
                case "Carer Login":
                    {
                        return _carerLoginNav ??= new CarerLoginNav(_pomdriver);
                    }
                case "Patient Account Activation":
                    {
                        return _patientActivationNav ??= new PatientAccountActivationNav(_pomdriver);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
