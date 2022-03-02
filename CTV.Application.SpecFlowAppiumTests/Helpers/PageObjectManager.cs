using SpecFlowAppiumTests.Pages;
using OpenQA.Selenium.Appium;

namespace SpecFlowAppiumTests.Helpers
{
    public class PageObjectManager
    {
        private AppiumDriver _pomdriver;
        private PatientAccountActivation _patientActivationPage;
        private Consent _consent;
        private Welcome _welcome;
        private PatientLogin _patientLogin;
        private CarerLogin _carerLogin;
        private PINReset _PINReset;
        private ForgotPassword _forgotPassword;

        public PageObjectManager(AppiumDriver _driver)
        {
            _pomdriver = _driver;
        }

        public IPageManager ViewSwitcher(string screen)
        {
            switch (screen)
            {
                case "PatientAccountActivation":
                    {
                        return _patientActivationPage ??= new PatientAccountActivation(_pomdriver);
                    }
                case "Consent":
                    {
                        return _consent ??= new Consent(_pomdriver);
                    }
                case "Welcome":
                    {
                        return _welcome ??= new Welcome(_pomdriver);
                    }
                case "PatientLogin":
                    {
                        return _patientLogin ??= new PatientLogin(_pomdriver);
                    }
                case "CarerLogin":
                    {
                        return _carerLogin ??= new CarerLogin(_pomdriver);
                    }
                case "PINReset":
                    {
                        return _PINReset ??= new PINReset(_pomdriver);
                    }
                case "ForgotPassword":
                    {
                        return _forgotPassword ??= new ForgotPassword(_pomdriver);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
