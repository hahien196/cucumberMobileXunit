using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Pages;
using SpecFlowAppiumTests.Helpers;
using System.Threading;

namespace SpecFlowAppiumTests.Navigation
{
    public class WelcomeNav : INavigationManager
    {
        private AppiumDriver _navigationDriver;
        public WelcomeNav(AppiumDriver driver)
        {
            _navigationDriver = driver;
        }

        public void NavigateWithConsent()
        {
            Activation act = new Activation(_navigationDriver);
            act.SendCodeThenContinue();
            Thread.Sleep(3000);
            Consent cons = new Consent(_navigationDriver);
            cons.ApproveConsent();
        }

        public void Navigate()
        {
            Activation act = new Activation(_navigationDriver);
            act.SendCodeThenContinue();
            Thread.Sleep(3000);
        }

    }
}
