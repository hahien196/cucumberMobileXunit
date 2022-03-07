using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SpecFlowAppiumTests.Helpers
{
    public static class ElementUtils
    {
        public static void ScrollDown(AppiumDriver _driver)
        {
            double windowHeight;

            if (Globals.IsIOS())
            {
                windowHeight = Globals.IOSWindowHeight();
            }
            else
            {
                windowHeight = Globals.AndroidWindowHeight();
            }

            double windowStartHeight = _driver.Manage().Window.Size.Height * windowHeight;
            double windowEndHeight = _driver.Manage().Window.Size.Height * 0.2;
            double windowWidth = _driver.Manage().Window.Size.Width / 2;

            TouchAction dragtobottom = (TouchAction)new TouchAction(_driver).
                Press(windowWidth, windowStartHeight)
                .Wait(500)
                .MoveTo(windowWidth, windowEndHeight)
                .Release();

            dragtobottom.Perform();
        }

        public static void ScrollUp(AppiumDriver _driver)
        {
            double windowStartHeight = _driver.Manage().Window.Size.Height * 0.4;
            double windowEndHeight = _driver.Manage().Window.Size.Height * 0.7;
            double windowWidth = _driver.Manage().Window.Size.Width / 2;

            TouchAction drag = (TouchAction)new TouchAction(_driver).
                Press(windowWidth, windowStartHeight)
                .MoveTo(windowWidth, windowEndHeight)
                .Release();

            drag.Perform();
        }

        public static void ScrollDownToElement(AppiumDriver _driver, By by)
        {
            while (_driver.FindElements(by).Count == 0)
            {
                ScrollDown(_driver);
            }
        }
        public static void ScrollUpToElement(AppiumDriver _driver, By by)
        {
            while(_driver.FindElements(by).Count == 0)
            {
                ScrollUp(_driver);
            }
        }

        public static AppiumElement WaitForElementExists(AppiumDriver _driver, By by)
        {
            AppiumElement ele = null;
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Globals.EXPLICIT_WAIT_TIMEOUT));
                wait.Until(ExpectedConditions.ElementExists(by));
                ele = _driver.FindElement(by);
            }
            catch (Exception)
            {
                Console.WriteLine("===Element is not existed: " + by.ToString());
            }
            return ele;
        }

        public static AppiumElement WaitForElementVisible(AppiumDriver _driver, By by)
        {
            AppiumElement ele = null;
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Globals.EXPLICIT_WAIT_TIMEOUT));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                ele = _driver.FindElement(by);
            }
            catch (Exception)
            {
                Console.WriteLine("===Element is not visible: " + by.ToString());
            }
            return ele;
        }

        public static AppiumElement WaitForElementClickable(AppiumDriver _driver, By by)
        {
            AppiumElement ele = null;
            ele = WaitForElementExists(_driver, by);
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Globals.EXPLICIT_WAIT_TIMEOUT));
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
            }
            catch (Exception) {
                Console.WriteLine("===Element is not clickable: " + by.ToString());
            }
            return ele;
        }

        public static void DoClick(AppiumDriver _driver, By by)
        {
            WaitForElementClickable(_driver, by);
            _driver.FindElement(by).Click();
        }

        public static void ActionSendKeys(AppiumDriver _driver, By by, string input)
        {
            WaitForElementVisible(_driver, by);
            AppiumElement ele = _driver.FindElement(by);
            ele.Click();
            Actions action = new Actions(_driver);
            action.SendKeys(input).Perform();
        }

        public static bool IsElementDisplayed(AppiumDriver _driver, string elementName)
        {
            By locator = MobileBy.XPath($"//*[@{Globals.GetLocator()}='{elementName}']");
            WaitForElementVisible(_driver, locator);
            var count = _driver.FindElements(locator).Count;
            return count > 0;
        }

    }
}
