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
        private AppiumDriver pomdriver;
        private Activation activationPage;

        public PageObjectManager(AppiumDriver _driver)
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
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
