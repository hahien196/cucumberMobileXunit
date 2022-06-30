using SpecFlowAppiumTests.Pages;
using OpenQA.Selenium.Appium;
using TechTalk.SpecFlow;
using Xunit;
using SpecFlowAppiumTests.Helpers;
using SpecFlowAppiumTests.Navigation;
using OpenQA.Selenium;

namespace SpecFlowAppiumTests.Steps
{
    [Binding]
    public class CarerActionsSteps
    {

        private readonly AppiumDriver _driver;
        private NavigationManager nav;

        public CarerActionsSteps(FeatureContext featureContext)
        {
            _driver = ((AppiumDriver)featureContext["DRIVER"]);
        }

        [Given(@"the Carer is logged in")]
        public void GivenTheCarerIsLoggedIn()
        {
            CarerHomeNav homeNav = new CarerHomeNav(_driver);
            homeNav.NavigateTo();
        }

        [Given(@"the Carer has selected ""(.*)"" from the ""(.*)"" screen")]
        public void GivenTheCarerHasSelected(string acessibilityID, string p0)
        {

            By element = MobileBy.AccessibilityId(acessibilityID);
            ElementUtils.DoClick(_driver, element);
        }

        [Then(@"the final results page should show (.*), (.*), (.*)")]
        public void ThenTheFinalResultsPageShouldShow(string p0, string p1, string p2)
        {
            VPRQuestionSet vprq2 = new(_driver);
            Assert.True(vprq2.AnswersMatchExpected(p0, p1, p2));
        }
    }
}
