using CTV.Application.SpecFlowAppiumTests.Drivers;
using OpenQA.Selenium.Appium;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;

namespace CTV.Application.SpecFlowAppiumTests.Hooks
{
    class TestHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public TestHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void Initialise()
        {
            AppiumDriver appiumDriver = new();
            AppiumServer appiumServer = new();
            if (OperatingSystem.IsMacOS())
            {
                _scenarioContext["DRIVER"] = appiumDriver.InitIOSDriver();
            }
            else if (OperatingSystem.IsWindows())
            {

                _scenarioContext["SERVER"] = Process.Start(appiumServer.WindowsAppiumServer());
                Thread.Sleep(5000);
                _scenarioContext["DRIVER"] = appiumDriver.InitAndroidDriver();
            }

        }

        [After]
        public void ShutDown(ScenarioContext context)
        {
            var driver = context["DRIVER"] as AppiumDriver<AppiumWebElement>;
            driver.Quit();
            var server = context["SERVER"] as Process;
            server.CloseMainWindow();
            server.Close();
        }

    }
}

