using OpenQA.Selenium.Appium;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;
using SpecFlowAppiumTests.Helpers;
using SpecFlowAppiumTests.Pages;
using OpenQA.Selenium;
using FluentAssertions;
using FluentAssertions.Execution;

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
            Thread.Sleep(1000);
        }

        [When(@"the user has navigated to the ""(.*)"" screen")]
        public void GivenTheUserHasNavigatedToTheScreen(string p0)
        {
            nav = new(_driver);
            INavigationManager navigate = nav.NavigationSwitch(p0);
            navigate.NavigateTo();
            _view = p0;
        }

        [When(@"the user is on the ""(.*)"" screen")]
        public void WhenTheUserIsOnTheScreen(string p0)
        {
            if (Globals.IsAndroid())
            {
                By titleEle = MobileBy.XPath($"//*[contains(text(),'{p0.Trim()}')]");
                ElementUtils.WaitForElementVisible(_driver, titleEle);
            }
            else if (Globals.IsIOS())
            {
                By titleEle = MobileBy.XPath($"//*[contains(@label,'{p0.Trim()}')]");
                ElementUtils.WaitForElementVisible(_driver, titleEle);
            }
            _view = p0;
        }

        [Then(@"the user is on the ""(.*)"" screen")]
        public void ThenTheUserIsOnTheScreen(string p0)
        {
            if (Globals.IsAndroid())
            {
                By titleEle = MobileBy.XPath($"//*[contains(text(),'{p0.Trim()}')]");
                ElementUtils.WaitForElementVisible(_driver, titleEle);
            }
            else if (Globals.IsIOS())
            {
                By titleEle = MobileBy.XPath($"//*[contains(@label,'{p0.Trim()}')]");
                ElementUtils.WaitForElementVisible(_driver, titleEle);
            }
            _view = p0;
        }

        [When(@"the user submits the following data")]
        public void GivenTheUserHasSubmittedData(Table table)
        {
            pom = new(_driver);
            IPageManager screen = pom.ViewSwitcher(_view);
            screen.SubmitData(table);
        }        

        [Then(@"they are able to see the expected element (.*)")]
        public void ThenTheyAreAbleToSeeTheExpectedElement(string p0)
        {
            pom = new(_driver);
            Assert.Contains(Globals.SUCCESS_TEXT, ElementUtils.IsElementDisplayed(_driver, p0));
        }

        [Then(@"the following error message should be present")]
        public void ThenFollowingErrorMessageShouldBePresent(Table table)
        { 
            var dictionary = Utilities.TableToDictionary(table);
            using (new AssertionScope())
            {
                foreach (var row in dictionary)
                {
                    string responseMsg = ElementUtils.IsErrorMessageCorrect(_driver, row.Key, row.Value);
                    responseMsg.Should().Contain(Globals.SUCCESS_TEXT);
                }
            }
        }

        [Then(@"they are able to see the expected elements")]
        public void ThenTheyAreAbleToSeeTheExpectedElements(Table table)
        {

            var dictionary = Utilities.TableToDictionary(table);
            using (new AssertionScope())
            {
                foreach (var row in dictionary)
                {
                    string responseMsg = ElementUtils.IsElementDisplayed(_driver, row.Value);
                    responseMsg.Should().Contain(Globals.SUCCESS_TEXT);
                }
            }
        }
    }
}
