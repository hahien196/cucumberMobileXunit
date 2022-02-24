using SpecFlowAppiumTests.Pages;
using OpenQA.Selenium.Appium;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowAppiumTests.Steps
{
    [Binding]
    public class ConsentSteps
    {

        private readonly AppiumDriver _driver;

        public ConsentSteps(FeatureContext featureContext)
        {
            _driver = ((AppiumDriver)featureContext["DRIVER"]);
        }

        [When(@"the user clicks the ""(.*)"" Button")]
        public void WhenTheUserClicksTheButton(string p0)
        {
            Consent cons = new(_driver);
            cons.RejectConsent();
        }

        [Then(@"they are taken to the ""(.*)"" screen")]
        public void ThenTheyAreTakenToTheScreen(string p0)
        {
            RejectConsent rejcons = new(_driver);
            Assert.True(rejcons.RejectPage());
        }

    }
}
