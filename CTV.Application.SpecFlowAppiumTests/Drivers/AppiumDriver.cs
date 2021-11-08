using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using System;

namespace CTV.Application.SpecFlowAppiumTests.Drivers
{
    public class AppiumDriver
    {

        public AndroidDriver<AppiumWebElement> InitAndroidDriver()
        {

            var apk = @"C:\TestAPK\CTV\app-debug.apk";
            var driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOptions.AddAdditionalCapability("appium:avd", "AndroidTest001");
            driverOptions.AddAdditionalCapability("appium:automationName", "uiautomator2");
            driverOptions.AddAdditionalCapability("appium:app", apk);
            driverOptions.AddAdditionalCapability("appium:newCommandTimeout", 120);

            return new AndroidDriver<AppiumWebElement>(new Uri("http://localhost:4723/"), driverOptions);
        }

        public IOSDriver<AppiumWebElement> InitIOSDriver()
        {
            var ipa = @"ioslocation";
            var driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "iOS");
            driverOptions.AddAdditionalCapability("appium:deviceName", "iPhone 11");
            driverOptions.AddAdditionalCapability("appium:automationName", "XCUITest");
            driverOptions.AddAdditionalCapability("appium:app", ipa);

            return new IOSDriver<AppiumWebElement>(new Uri("http://localhost:4723/"), driverOptions);
        }
    }
}