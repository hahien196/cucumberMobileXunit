using SpecFlowAppiumTests.Pages;
using OpenQA.Selenium.Appium;

namespace SpecFlowAppiumTests.Helpers
{
    public class PageObjectManager
    {
        private AppiumDriver _pomdriver;
        private PatientAccountActivation _patientActivationPage;
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
                case "Patient Account Activation":
                    {
                        return _patientActivationPage ??= new PatientAccountActivation(_pomdriver);
                    }
                case "Patient Login":
                    {
                        return _patientLogin ??= new PatientLogin(_pomdriver);
                    }
                case "Carer Login":
                    {
                        return _carerLogin ??= new CarerLogin(_pomdriver);
                    }
                case "PIN Reset":
                    {
                        return _PINReset ??= new PINReset(_pomdriver);
                    }
                case "Forgot Password":
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
