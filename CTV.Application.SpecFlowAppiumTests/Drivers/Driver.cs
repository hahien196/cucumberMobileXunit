using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using System;


namespace SpecFlowAppiumTests.Drivers
{
    public class Driver
    {

        public AndroidDriver InitAndroidDriver(string deviceType)
        {
            string browser = deviceType.ToUpper();

            switch (browser)
            {
                case "ANDROID_MOBILE": return AndroidMobileDriver();
                case "ANDROID_TABLET": return AndroidTabletDriver();
                case string unknown: throw new NotSupportedException($"{unknown} is not a supported device");
                default: throw new NotSupportedException("unsupported device: <null>");
            }

        }

        public IOSDriver InitIOSDriver(string deviceType)
        {
            string browser = deviceType.ToUpper();

            switch (browser)
            {
                case "IOS_MOBILE": return IosMobileDriver();
                case "IOS_TABLET": return IosTabletDriver();
                case string unknown: throw new NotSupportedException($"{unknown} is not a supported device");
                default: throw new NotSupportedException("unsupported device: <null>");
            }
        }

        public AndroidDriver AndroidMobileDriver()
        {
            const string apk = @"C:\TestAPK\CTV\app-debug.apk";
            var driverOptions = new AppiumOptions
            {
                PlatformName = "Android",
                AutomationName = AutomationName.AndroidUIAutomator2,
                App = apk
        };
            driverOptions.AddAdditionalAppiumOption("appium:avd", "AndroidTest001"); driverOptions.AutomationName = AutomationName.AndroidUIAutomator2;
            driverOptions.App = apk;
            driverOptions.AddAdditionalAppiumOption(MobileCapabilityType.NewCommandTimeout, 120000);
            driverOptions.AddAdditionalAppiumOption("appium:launchTimeout", "120000");

            return new AndroidDriver(new Uri("http://localhost:4723/"), driverOptions);
        }


        public AndroidDriver AndroidTabletDriver()
        {
            const string apk = @"C:\TestAPK\CTV\app-debug.apk";
            var driverOptions = new AppiumOptions
            {
                PlatformName = "Android",
                AutomationName = AutomationName.AndroidUIAutomator2,
                App = apk
            };

            driverOptions.AddAdditionalAppiumOption("appium:avd", "AndroidTestTablet001");
            driverOptions.AddAdditionalAppiumOption(MobileCapabilityType.NewCommandTimeout, 120000);
            driverOptions.AddAdditionalAppiumOption("appium:launchTimeout", "120000");

            return new AndroidDriver(new Uri("http://localhost:4723/"), driverOptions);
        }

        public IOSDriver IosMobileDriver()
        {
            //local mac 
            //var ipa = @"/Users/dev/Documents/CliniTouchVie.app";
            //remote mac mini
            const string ipa = @"/Users/spiritdigital/Documents/CliniTouchVie.app";
            var driverOptions = new AppiumOptions
            {
                PlatformName = "iOS",
                DeviceName = "iPhone 13 Pro",
                AutomationName = "XCUITest",
                //remote mac mini only supports up to version 15.0 for now
                PlatformVersion = "15.0",
                //driverOptions.PlatformVersion = "15.2";
                App = ipa
            };
            driverOptions.AddAdditionalAppiumOption(MobileCapabilityType.NewCommandTimeout, 120000);
            driverOptions.AddAdditionalAppiumOption("appium:wdaLaunchTimeout", "120000");
            driverOptions.AddAdditionalAppiumOption("appium:useNewWDA", "false");
            driverOptions.AddAdditionalAppiumOption("appium:language", "en");

            //remote mac mini
            return new IOSDriver(new Uri("http://185.200.102.183:4723/"), driverOptions);
            //local mac mini
            //return new IOSDriver(new Uri("http://192.168.1.54:4723/"), driverOptions);
        }

        public IOSDriver IosTabletDriver()
        {
            //local mac 
            //var ipa = @"/Users/dev/Documents/CliniTouchVie.app";
            //remote mac mini
            const string ipa = @"/Users/spiritdigital/Documents/CliniTouchVie.app";
            var driverOptions = new AppiumOptions
            {
                PlatformName = "iOS",
                DeviceName = "iPad 9th Gen",
                AutomationName = "XCUITest",
                //remote mac mini only supports up to version 15.0 for now
                PlatformVersion = "15.0",
                //driverOptions.PlatformVersion = "15.2";
                App = ipa
            };
            driverOptions.AddAdditionalAppiumOption(MobileCapabilityType.NewCommandTimeout, 120000);
            driverOptions.AddAdditionalAppiumOption("appium:wdaLaunchTimeout", 120000);
            driverOptions.AddAdditionalAppiumOption("appium:useNewWDA", false);
            driverOptions.AddAdditionalAppiumOption("appium:language", "en");
            driverOptions.AddAdditionalAppiumOption("appium:orientation", "LANDSCAPE");

            //remote mac mini
            return new IOSDriver(new Uri("http://185.200.102.183:4723/"), driverOptions);
            //local mac mini
            //return new IOSDriver(new Uri("http://192.168.1.54:4723/"), driverOptions);
        }
    }
}