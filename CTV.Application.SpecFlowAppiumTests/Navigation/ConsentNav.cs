using OpenQA.Selenium.Appium;
using CTV.Application.SpecFlowAppiumTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTV.Application.SpecFlowAppiumTests.Pages;

namespace CTV.Application.SpecFlowAppiumTests.Navigation
{
    public class ConsentNav : INavigationManager
    {
        private AppiumDriver _navigationDriver;
        public ConsentNav(AppiumDriver driver)
        {
            _navigationDriver = driver;
        }

        public void NavigateTo()
        {
            Activation act = new Activation(_navigationDriver);
            act.SendCodeThenContinue();
        }
    }
}
