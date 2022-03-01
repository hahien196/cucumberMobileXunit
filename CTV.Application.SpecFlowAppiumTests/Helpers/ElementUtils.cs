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
        public static void ScrollToBottom(AppiumDriver _driver)
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

        public static AppiumElement WaitForElementVisible(AppiumDriver _driver, By by)
        {
            AppiumElement ele = null;
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Globals.EXPLICIT_WAIT_TIMEOUT));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                ele = _driver.FindElement(by);
            }
            catch (Exception) { }
            return ele;
        }

        public static AppiumElement WaitForElementClickable(AppiumDriver _driver, By by)
        {
            AppiumElement ele = null;
            ele = WaitForElementVisible(_driver, by);
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Globals.EXPLICIT_WAIT_TIMEOUT));
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
            }
            catch (Exception) { }
            return ele;
        }

        public static void actionSendKeys(AppiumDriver _driver, AppiumElement ele, string input)
        {
            ele.Click();
            Actions action = new Actions(_driver);
            action.SendKeys(input).Perform();
        }
    }
}
