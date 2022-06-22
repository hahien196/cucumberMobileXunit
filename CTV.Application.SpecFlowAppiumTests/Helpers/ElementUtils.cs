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
        public static void TouchScroll(AppiumDriver _driver, double startHeightRatio, double endHeightRatio, double widthRatio)
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

        public static void ScrollToElement(AppiumDriver _driver, By by, double topHeightRatio, double bottomHeightRatio, double widthRatio)
        {
            int retry = 0;
            while (_driver.FindElements(by).Count == 0 && retry < 4)
            {
                ScrollDown(_driver, topHeightRatio, bottomHeightRatio, widthRatio);
                retry++;
            }
            retry = 0;
            while (_driver.FindElements(by).Count == 0 && retry < 4)
            {
                ScrollUp(_driver, topHeightRatio, bottomHeightRatio, widthRatio);
                retry++;
            }
        }

        public static void ScrollDown(AppiumDriver _driver, double topHeightRatio, double bottomHeightRatio, double widthRatio)
        {
            if (Globals.IsAndroid())
            {
                TouchScroll(_driver, bottomHeightRatio, topHeightRatio, widthRatio);
            }
            else if (Globals.IsIOS())
            {
                IOSScroll(_driver, "down");
            }
        }

        public static void ScrollUp(AppiumDriver _driver, double topHeightRatio, double bottomHeightRatio, double widthRatio)
        {
            if (Globals.IsAndroid())
            {
                TouchScroll(_driver, topHeightRatio, bottomHeightRatio, widthRatio);
            }
            else if (Globals.IsIOS())
            {
                IOSScroll(_driver, "up");
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
                Console.WriteLine("=== ERROR: Element does not exist within timeout: " + by.ToString());
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
                Console.WriteLine("=== ERROR: Element is not visible within timeout: " + by.ToString());
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
                Console.WriteLine("=== ERROR: Element is not clickable within timeout: " + by.ToString());
            }
            return ele;
        }

        public static void DoClick(AppiumDriver _driver, By by)
        {
            WaitForElementClickable(_driver, by);
            _driver.FindElement(by).Click();
        }

        public static void ClickElementByText(AppiumDriver _driver, string text)
        {
            By by = MobileBy.XPath("//*[contains(@" + Globals.TextLocator() + "," + text + ")]/..");
            ElementUtils.ScrollToElement(_driver, by, 0.2, Globals.GetWindowHeight(), 0.5);
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

        public static bool IsElementDisplayed(AppiumDriver _driver, string accessibilityID)
        {
            By locator = MobileBy.XPath($"//*[@{Globals.GetLocator()}='{accessibilityID}']");
            ScrollToElement(_driver, locator, 0.2, Globals.GetWindowHeight(), 0.5);
            WaitForElementVisible(_driver, locator);
            var count = _driver.FindElements(locator).Count;
            return count > 0;
        }

        public static bool IsElementDisplayed(AppiumDriver _driver, By by)
        {
            WaitForElementVisible(_driver, by);
            var count = _driver.FindElements(by).Count;
            return count > 0;
        }

        public static bool IsErrorMessageCorrect(AppiumDriver _driver, string accessibilityID, string text)
        {
            By eleLocator = null;
            if (Globals.IsAndroid())
            {
                eleLocator = By.XPath($"//android.view.View[@{Globals.AndroidLocator()}='{accessibilityID}']/../following-sibling::android.view.View[1]");
            }
            else if (Globals.IsIOS())
            {
                eleLocator = By.XPath($"//*[@{Globals.IOSLocator()}='{accessibilityID}']/following-sibling::XCUIElementTypeStaticText[1]");
            }
            WaitForElementExists(_driver, eleLocator);
            var ele = _driver.FindElement(eleLocator);
            string errText = ele.GetAttribute(Globals.TextLocator());
            bool isSuccess = (text == errText);
            if (!isSuccess)
            {
                Console.WriteLine("=== FAILED: Actual text: '" + errText + "' does not match the expected text: '" + text + "'.");
            }
            return isSuccess;
        }

    }
}
