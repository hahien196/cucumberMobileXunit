using OpenQA.Selenium.Appium;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;
using SpecFlowAppiumTests.Helpers;
using SpecFlowAppiumTests.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;

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
            } else if (Globals.IsIOS())
            {
                By titleEle = MobileBy.XPath($"//*[contains(@label,'{p0.Trim()}')]");
                ElementUtils.WaitForElementVisible(_driver, titleEle);
            }
            _view = p0;
        }

        [Then(@"they are able to see the expected element (.*)")]
        public void ThenTheyAreAbleToSeeTheExpectedElement(string p0)
        {
            pom = new(_driver);
            Assert.True(ElementUtils.IsElementDisplayed(_driver, p0));            
        }

        [Then(@"they are able to see the expected elements")]
        public void ThenTheyAreAbleToSeeTheExpectedElements(Table table)
        {
            pom = new(_driver);
            var dictionary = Utilities.TableToDictionary(table);
            int numDisplayed = 0;
            List<string> notDisplayedEles = new List<string>();
            foreach (var row in dictionary)
            {
                if (ElementUtils.IsElementDisplayed(_driver, row.Value))
                {
                    numDisplayed++;
                }
                else
                {
                    notDisplayedEles.Add(row.Value);
                }
            }

            Assert.True(numDisplayed == dictionary.Count);

        }
    }
}
