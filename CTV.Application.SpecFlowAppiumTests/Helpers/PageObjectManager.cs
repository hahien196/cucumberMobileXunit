using CTV.Application.SpecFlowAppiumTests.Pages;
using OpenQA.Selenium.Appium;

namespace CTV.Application.SpecFlowAppiumTests.Helpers
{
    public class PageObjectManager
    {
        private AppiumDriver _pomdriver;
        private Activation _activationPage;
        private Consent _consent;
        private Welcome _welcome;

        public PageObjectManager(AppiumDriver _driver)
        {
            _pomdriver = _driver;
        }

        public IPageManager ViewSwitcher(string screen)
        {
            switch (screen)
            {
                case "Activation":
                    {
                        return _activationPage ??= new Activation(_pomdriver);
                    }
                case "Consent":
                    {
                        return _consent ??= new Consent(_pomdriver);
                    }
                case "Welcome":
                    {
                        return _welcome ??= new Welcome(_pomdriver);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
