﻿using OpenQA.Selenium.Appium;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;
using SpecFlowAppiumTests.Helpers;
using SpecFlowAppiumTests.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;
using System;

namespace SpecFlowAppiumTests.Steps
{
    [Binding]
    public class ElementCommonSteps
    {
        private readonly AppiumDriver _driver;
        PageObjectManager pom;
        NavigationManager nav;
        private string _view;

        public ElementCommonSteps(FeatureContext featureContext)
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
            _view = p0;
            By titleEle = MobileBy.XPath($"//*[contains(@{Globals.TextLocator()},'{p0.Trim()}')]");
            ElementUtils.WaitForElementVisible(_driver, titleEle);
        }

        [When(@"the user clicks on the ""(.*)""")]
        public void WhenTheUserClicksOnTheElement(string input)
        {
            try
            {
                By element = MobileBy.AccessibilityId(input);
                ElementUtils.DoClick(_driver, element);
            }
            catch (Exception)
            {
                Console.WriteLine("====> Try to access element by Text instead of Accessibility ID");
                By element = MobileBy.XPath($"//*[contains(@{Globals.TextLocator()}, '{input}')]");
                ElementUtils.DoClick(_driver, element);
            }
        }

        [When(@"the user scrolls to the ""(.*)""")]
        public void WhenTheUserScrollsToElement(string accessibilityID)
        {
            By locator = MobileBy.XPath($"//*[@{Globals.GetLocator()}='{accessibilityID}']");
            ElementUtils.ScrollToElement(_driver, locator, 0.3, Globals.GetWindowHeight(), 0.5);
        }

        [Then(@"the user is on the ""(.*)"" screen")]
        public void ThenTheUserIsOnTheScreen(string p0)
        {
            _view = p0;
            By titleEle = MobileBy.XPath($"//*[contains(@{Globals.TextLocator()},'{p0.Trim()}')]");
            Assert.True(ElementUtils.IsElementDisplayed(_driver, titleEle));
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
            Assert.True(ElementUtils.IsElementDisplayed(_driver, p0));
        }

        [Then(@"they are able to see the expected elements")]
        public void ThenTheyAreAbleToSeeTheExpectedElements(Table table)
        {
            pom = new(_driver);
            var dictionary = Utilities.TableToDictionary(table);
            int passCount = 0;
            List<string> notDisplayedEles = new List<string>();
            foreach (var row in dictionary)
            {
                if (ElementUtils.IsElementDisplayed(_driver, row.Value))
                {
                    passCount++;
                } else
                {
                    notDisplayedEles.Add(row.Value);
                }
            }
            Assert.Equal(dictionary.Count, passCount);
        }

        [Then(@"the following error message should be present")]
        public void ThenFollowingErrorMessageShouldBePresent(Table table)
        {
            var dictionary = Utilities.TableToDictionary(table);
            int passCount = 0;
            List<string> notDisplayedEles = new List<string>();
            foreach (var row in dictionary)
            {
                if (ElementUtils.IsErrorMessageCorrect(_driver, row.Key, row.Value))
                {
                    passCount++;
                } else
                {
                    notDisplayedEles.Add(row.Key);
                }
            }
            Assert.Equal(dictionary.Count, passCount);
        }
    }
}
