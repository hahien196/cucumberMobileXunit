using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Navigation;

namespace SpecFlowAppiumTests.Helpers
{
    public class NavigationManager
    {
        private AppiumDriver _pomdriver;
        private ConsentNav _consent;
        private PatientHomeNav _patientHome;
        private CarerHomeNav _carerHome;
        private CarerLoginNav _carerLoginNav;
        private PatientAccountActivationNav _patientActivationNav;
        private PINResetNav _PINResetNav;
        private ForgotPasswordNav _forgotPasswordNav;
        private AccountNav _accountNav;
        private SelectPatientNav _selectPatientNav;
        private EducationNav _educationNav;

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
                case "Patient Home":
                    {
                        return _patientHome ??= new PatientHomeNav(_pomdriver);
                    }
                case "Carer Home":
                    {
                        return _carerHome ??= new CarerHomeNav(_pomdriver);
                    }
                case "Carer Login":
                    {
                        return _carerLoginNav ??= new CarerLoginNav(_pomdriver);
                    }
                case "Patient Account Activation":
                    {
                        return _patientActivationNav ??= new PatientAccountActivationNav(_pomdriver);
                    }
                case "PIN Reset":
                    {
                        return _PINResetNav ??= new PINResetNav(_pomdriver);
                    }
                case "Forgot Password":
                    {
                        return _forgotPasswordNav ??= new ForgotPasswordNav(_pomdriver);
                    }
                case "Account":
                    {
                        return _accountNav ??= new AccountNav(_pomdriver);
                    }
                case "Select Patient":
                    {
                        return _selectPatientNav ??= new SelectPatientNav(_pomdriver);
                    }
                case "Education":
                    {
                        return _educationNav ??= new EducationNav(_pomdriver);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
