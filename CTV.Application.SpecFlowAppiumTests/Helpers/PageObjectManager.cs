using CTV.Application.SpecFlowAppiumTests.Pages;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTV.Application.SpecFlowAppiumTests.Helpers
{
    public class PageObjectManager
    {
        private AppiumDriver<AppiumWebElement> pomdriver;
        private Activation activationPage;
        private Activation2 act2;

        public PageObjectManager(AppiumDriver<AppiumWebElement> _driver)
        {
            pomdriver = _driver;
        }

        public IPageManager ViewSwitcher(string screen)
        {
            switch(screen)
            {
                case "Activation":
                    {
                        return activationPage ??= new Activation(pomdriver);
                    }
                case "Activation2":
                    {
                        return act2 ??= new Activation2(pomdriver);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
