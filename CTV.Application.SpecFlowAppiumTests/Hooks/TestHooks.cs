using SpecFlowAppiumTests.Drivers;
using OpenQA.Selenium.Appium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using SpecFlowAppiumTests.Helpers;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlowAppiumTests.Hooks
{
    [Binding]
    class TestHooks
    {
        private static FeatureContext _featureContext; 
        private static ScenarioContext _scenarioContext;

        private static AppiumDriver _appiumClient;
        private static ISpecFlowOutputHelper _specFlowOutputHelper;

        public TestHooks(FeatureContext featureContext, ScenarioContext scenarioContext, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _featureContext = featureContext; 
            _scenarioContext = scenarioContext;
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [BeforeFeature]
        public static void Initialise()
        {
            // local use only
            Environment.SetEnvironmentVariable("PLATFORM", "Android");

            AppiumServer appiumServer = new AppiumServer();
            Driver appiumDriver = new Driver();
            if ((Environment.GetEnvironmentVariable("PLATFORM", EnvironmentVariableTarget.Process)) == "iOS")
            {
                string device = Environment.GetEnvironmentVariable("Device_Type");
                Thread.Sleep(1000);
                _appiumClient = appiumDriver.InitIOSDriver(device);
            }
            else if ((Environment.GetEnvironmentVariable("PLATFORM", EnvironmentVariableTarget.Process)) == "Android")
            {
                string device = Environment.GetEnvironmentVariable("Device_Type");
                Thread.Sleep(1000);
                _appiumClient = appiumDriver.InitAndroidDriver(device);
            }
        }

        [BeforeScenario]
        public void SaveContext()
        {
            if (!_featureContext.ContainsKey("DRIVER"))
            {
                _featureContext.Add("DRIVER", _appiumClient);
            }          
        }

        [AfterStep]
        public static void TakeScreenshotAfterStep()
        {
            if (_scenarioContext.TestError != null)
            {
                var imagePath = Utilities.TakeScreenShot(_appiumClient, _scenarioContext.ScenarioInfo.Title);
                _specFlowOutputHelper.AddAttachment(imagePath);
            }
        }
            [AfterScenario]
        public static void CleanScenario(FeatureContext context)
        {
            var driver = ((AppiumDriver)context["DRIVER"]);
            driver.ResetApp();
        }

        [AfterFeature]
        public static void ShutDown(FeatureContext context)
        {
            var driver = ((AppiumDriver)context["DRIVER"]);
            driver.Quit();
        }

    }
}

