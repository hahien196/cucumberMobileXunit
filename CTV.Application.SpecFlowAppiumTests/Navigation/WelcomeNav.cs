using OpenQA.Selenium.Appium;
using CTV.Application.SpecFlowAppiumTests.Pages;
using CTV.Application.SpecFlowAppiumTests.Helpers;
using System.Threading;

namespace CTV.Application.SpecFlowAppiumTests.Navigation
{
    public class WelcomeNav : INavigationManager
    {
        private AppiumDriver _navigationDriver;
        public WelcomeNav(AppiumDriver driver)
        {
            _navigationDriver = driver;
        }

        public void NavigateTo()
        {
            Activation act = new Activation(_navigationDriver);
            act.SendCodeThenContinue();
            Thread.Sleep(3000);
            Consent cons = new Consent(_navigationDriver);
            cons.ApproveConsent();
        }
    }
}
