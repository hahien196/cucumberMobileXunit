using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowAppiumTests.Pages
{
    public class CarerHome
    {
        private static AppiumDriver _driver;
        public CarerHome(AppiumDriver appiumDriver)
        {
            _driver = appiumDriver;
        }

    }


}
