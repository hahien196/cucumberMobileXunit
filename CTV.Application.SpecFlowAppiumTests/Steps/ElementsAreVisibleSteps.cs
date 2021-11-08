using OpenQA.Selenium.Appium;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;
using CTV.Application.SpecFlowAppiumTests.Helpers;
using System;
using System.Reflection;
using System.Linq;
using CTV.Application.SpecFlowAppiumTests.Pages;

namespace CTV.Application.SpecFlowAppiumTests.Steps
{
    [Binding]
    public class ActivationElementsAreVisibleSteps
    {
        private readonly AppiumDriver<AppiumWebElement> _driver;
        PageObjectManager pom;
        private string _view;

        public ActivationElementsAreVisibleSteps(FeatureContext featureContext)
        {
            _driver = ((AppiumDriver<AppiumWebElement>)featureContext["DRIVER"]);
        }

        [Given(@"the app is running")]
        public void GivenTheAppIsRunning()
        {
            _driver.LaunchApp();
            Thread.Sleep(5000);
        }

        [When(@"the user is on the (.*) screen")]
        public void WhenTheUserIsOnTheScreen(string p0)
        { 
            for (int i = 0; !_driver.PageSource.Contains("Activation"); i++)
            {
                Thread.Sleep(500);
                if (i == 10)
                {
                    break;
                }
            }

            bool correctView = _driver.PageSource.Contains("Activation");
            Assert.True(correctView);
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
