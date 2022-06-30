using SpecFlowAppiumTests.Pages;
using OpenQA.Selenium.Appium;
using TechTalk.SpecFlow;
using Xunit;
using SpecFlowAppiumTests.Helpers;

namespace SpecFlowAppiumTests.Steps
{
    [Binding]
    public class PatientActionsSteps
    {

        private readonly AppiumDriver _driver;

        public PatientActionsSteps(FeatureContext featureContext)
        {
            _driver = ((AppiumDriver)featureContext["DRIVER"]);
        }

    }
}
