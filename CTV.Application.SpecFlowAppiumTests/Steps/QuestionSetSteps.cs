using SpecFlowAppiumTests.Pages;
using OpenQA.Selenium.Appium;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowAppiumTests.Steps
{
    [Binding]
    public class QuestionSetSteps
    {

        private readonly AppiumDriver _driver;

        public QuestionSetSteps(FeatureContext featureContext)
        {
            _driver = ((AppiumDriver)featureContext["DRIVER"]);
        }

        [When(@"they select the ""(.*)"" Question Set")]
        public void WhenTheySelectTheQuestionSet(string p0)
        {
            Welcome welcome = new(_driver);
            welcome.SelectVPRQuestionSet();
        }

        [When(@"respond to all the questions with (.*), (.*), (.*)")]
        public void WhenRespondToAllTheQuestionsWith(string p0, string p1, string p2)
        {
            VPRQuestionSet vprqs = new(_driver);
            Assert.True(vprqs.CompletedQuestions(p0, p1, p2));
        }

        [Then(@"the final results page should show (.*), (.*), (.*)")]
        public void ThenTheFinalResultsPageShouldShow(string p0, string p1, string p2)
        {
            VPRQuestionSet vprq2 = new(_driver);
            Assert.True(vprq2.AnswersMatchExpected(p0, p1, p2));
        }
    }
}
