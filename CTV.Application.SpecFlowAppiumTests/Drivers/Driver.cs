using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using System;


namespace SpecFlowAppiumTests.Drivers
{
    public class Driver
    {

        public AndroidDriver InitAndroidDriver()
        {

            var apk = @"C:\TestAPK\CTV\app-debug.apk";
            var driverOptions = new AppiumOptions();
            driverOptions.PlatformName = "Android";
            driverOptions.AddAdditionalAppiumOption("appium:avd", "AndroidTest001");
            driverOptions.AutomationName = AutomationName.AndroidUIAutomator2;
            driverOptions.App = apk;
            driverOptions.AddAdditionalAppiumOption(MobileCapabilityType.NewCommandTimeout, 120000);
            driverOptions.AddAdditionalAppiumOption("appium:launchTimeout", "120000");

            return new AndroidDriver(new Uri("http://localhost:4723/"), driverOptions);
        }

        public IOSDriver InitIOSDriver()
        {
            //local mac 
            //var ipa = @"/Users/dev/Documents/CliniTouchVie.app";
            //remote mac mini
            var ipa = @"/Users/spiritdigital/Documents/CliniTouchVie.app";
            var driverOptions = new AppiumOptions();
            driverOptions.PlatformName = "iOS";
            driverOptions.DeviceName =  "iPhone 13 Pro";
            driverOptions.AutomationName = "XCUITest";
            //remote mac mini only supports up to version 15.0 for now
            driverOptions.PlatformVersion = "15.0";
            //driverOptions.PlatformVersion = "15.2";
            driverOptions.App =  ipa;
            driverOptions.AddAdditionalAppiumOption(MobileCapabilityType.NewCommandTimeout, 120000);
            driverOptions.AddAdditionalAppiumOption("appium:wdaLaunchTimeout", "120000");
            driverOptions.AddAdditionalAppiumOption("appium:useNewWDA", "false");
            driverOptions.AddAdditionalAppiumOption("appium:language", "en");

            //remote mac mini
            //return new IOSDriver(new Uri("http://185.200.102.183:4723/"), driverOptions);
            //local mac mini
            return new IOSDriver(new Uri("http://192.168.1.54:4723/"), driverOptions);
        }
    }
}