using CTV.Application.SpecFlowAppiumTests.Drivers;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;

namespace CTV.Application.SpecFlowAppiumTests.Hooks
{
    [Binding]
    class TestHooks
    {
        private static FeatureContext _featureContext;
        private static Process server;
        private static AppiumDriver<AppiumWebElement> appiumClient;

        public TestHooks(FeatureContext featureContext)
        {
            _featureContext = featureContext;
        }

        [BeforeFeature]
        public static void Initialise()
        {
            AppiumDriver appiumDriver = new AppiumDriver();
            AppiumServer appiumServer = new AppiumServer();
            if (OperatingSystem.IsMacOS())
            {
                appiumClient = appiumDriver.InitIOSDriver();
            }
            else if (OperatingSystem.IsWindows())
            {
                Thread.Sleep(2000);
                server = Process.Start(appiumServer.WindowsAppiumServer());
                Thread.Sleep(5000);
                appiumClient = appiumDriver.InitAndroidDriver();

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
                _featureContext.Add("DRIVER", appiumClient);
            }
            
        }

        [AfterFeature]
        public static void ShutDown(FeatureContext context)
        {
            var driver = ((AppiumDriver<AppiumWebElement>)context["DRIVER"]);
            driver.Quit();
            var server = ((Process)context["SERVER"]);
            server.CloseMainWindow();
            server.Close();
        }

    }
}

