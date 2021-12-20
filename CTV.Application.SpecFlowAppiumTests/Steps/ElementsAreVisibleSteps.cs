using OpenQA.Selenium.Appium;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;
using SpecFlowAppiumTests.Helpers;
using SpecFlowAppiumTests.Pages;

namespace SpecFlowAppiumTests.Steps
{
    [Binding]
    public class ElementsAreVisibleSteps
    {
        private readonly AppiumDriver _driver;
        PageObjectManager pom;
        NavigationManager nav;
        private string _view;

        public ElementsAreVisibleSteps(FeatureContext featureContext)
        {
            _driver = ((AppiumDriver)featureContext["DRIVER"]);
        }

        [Given(@"the app is running")]
        public void GivenTheAppIsRunning()
        {
            //_driver.LaunchApp();
            Thread.Sleep(5000);
        }

        [Given(@"the user has navigated to the ""(.*)"" screen")]
        public void GivenTheUserHasNavigatedToTheScreen(string p0)
        {
            nav = new(_driver);
            INavigationManager navigate = nav.NavigationSwitch(p0);
            navigate.NavigateWithConsent();
        }

        [When(@"the user is on the (.*) screen")]
        public void WhenTheUserIsOnTheScreen(string p0)
        {
            Thread.Sleep(3000);
            if(Globals.IsAndroid())
            {
                bool correctView = _driver.PageSource.Contains(p0);
                Assert.True(correctView);
            }
            _view = p0;
        }

        [Then(@"they are able to see the expected element (.*)")]
        public void ThenTheyAreAbleToSeeTheExpectedElement(string p0)
        {
            pom = new(_driver);
            IPageManager screen = pom.ViewSwitcher(_view);
            Assert.True(screen.ValidateElements(p0));
            
        }

    }
}
