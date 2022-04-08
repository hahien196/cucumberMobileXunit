using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace SpecFlowAppiumTests.Helpers
{
    public static class ElementUtils
    {
        public static void Scroll(AppiumDriver _driver, double startHeightRatio, double endHeightRatio, double widthRatio)
        {
            double windowStartHeight = _driver.Manage().Window.Size.Height * startHeightRatio;
            double windowEndHeight = _driver.Manage().Window.Size.Height * endHeightRatio;
            double windowWidth = _driver.Manage().Window.Size.Width * widthRatio;

            TouchAction drag = (TouchAction)new TouchAction(_driver)
                .Press(windowWidth, windowStartHeight)
                .MoveTo(windowWidth, windowEndHeight)
                .Release();

            drag.Perform();
        }

        public static void IOSScroll(AppiumDriver _driver, string direction)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor) _driver;
            Dictionary<string, string> scrollObject = new Dictionary<string, string>();
            // direction can be "down", "up"
            scrollObject.Add("direction", direction);
            js.ExecuteScript("mobile: scroll", scrollObject);
        }

        public static void ScrollToElement(AppiumDriver _driver, By by, double startHeightRatio, double endHeightRatio, double widthRatio)
        {
            while(_driver.FindElements(by).Count == 0)
            {
                Scroll(_driver, startHeightRatio, endHeightRatio, widthRatio);
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
                Console.WriteLine("=== ERROR: Element does not exist: " + by.ToString());
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
                Console.WriteLine("=== ERROR: Element is not visible: " + by.ToString());
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
                Console.WriteLine("=== ERROR: Element is not clickable: " + by.ToString());
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
            if (!String.IsNullOrEmpty(input))
            {
                Actions action = new Actions(_driver);
                action.SendKeys(input).Perform();
            }
        }

        public static bool IsElementDisplayed(AppiumDriver _driver, string elementName)
        {
            By locator = MobileBy.XPath($"//*[@{Globals.GetLocator()}='{elementName}']");
            WaitForElementVisible(_driver, locator);
            var count = _driver.FindElements(locator).Count;
            return count > 0;
        }

        public static bool IsErrorMessageCorrect(AppiumDriver _driver, string elementName, string text)
        {
            AppiumElement ele = null;
            if (Globals.IsAndroid())
            {
                ele = _driver.FindElement(By.XPath($"//android.view.View[@{Globals.AndroidLocator()}='{elementName}']/../following-sibling::android.view.View[1]"));
            }
            else if (Globals.IsIOS())
            {
                ele = _driver.FindElement(By.XPath($"//*[@{Globals.IOSLocator()}='{elementName}']/following-sibling::XCUIElementTypeStaticText[1]"));
            }
            string errText = ele.GetAttribute(Globals.TextLocator());
            bool isSuccess = text == errText;
            if (!isSuccess)
            {
                Console.WriteLine("=== FAILED: Actual text: " + errText + " does not match the expected text:  " + text);
            }
            return isSuccess;
        }

    }
}
