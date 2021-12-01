using CTV.Application.SpecFlowAppiumTests.Drivers;
using OpenQA.Selenium.Appium;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace CTV.Application.SpecFlowAppiumTests.Hooks
{
    [Binding]
    class TestHooks
    {
        private static FeatureContext _featureContext;
        private static Process server;
        private static AppiumDriver _appiumClient;
        
        public TestHooks(FeatureContext featureContext)
        {
            _featureContext = featureContext;
        }

        [BeforeFeature]
        public static void Initialise()
        {
            //local use only
            //Environment.SetEnvironmentVariable("PLATFORM", "Android");
            //
            AppiumServer appiumServer = new AppiumServer();
            Driver appiumDriver = new Driver();
            if ((Environment.GetEnvironmentVariable("PLATFORM", EnvironmentVariableTarget.Process)) == "iOS")
            {
                _appiumClient = appiumDriver.InitIOSDriver();
            }
            else if ((Environment.GetEnvironmentVariable("PLATFORM", EnvironmentVariableTarget.Process)) == "Android")
            {
                server = Process.Start(appiumServer.WindowsAppiumServer());
                Thread.Sleep(2000);
                _appiumClient = appiumDriver.InitAndroidDriver();


            }
        }

        [BeforeScenario]
        public void SaveContext()
        {
            if (!_featureContext.ContainsKey("SERVER"))
            {
                _featureContext.Add("SERVER", server);
            }
            if (!_featureContext.ContainsKey("DRIVER"))
            {
                _featureContext.Add("DRIVER", _appiumClient);
            }          
        }

        [AfterScenario]
        public static void CleanScenario(FeatureContext context)
        {
            var driver = ((AppiumDriver)context["DRIVER"]);
            driver.ResetApp();
            Thread.Sleep(2000);
        }

        [AfterFeature]
        public static void ShutDown(FeatureContext context)
        {
            var driver = ((AppiumDriver)context["DRIVER"]);
            driver.Quit();
            var server = ((Process)context["SERVER"]);
            if (server != null)
            {
                server.CloseMainWindow();
                server.Close();
            }
            
        }

    }
}

