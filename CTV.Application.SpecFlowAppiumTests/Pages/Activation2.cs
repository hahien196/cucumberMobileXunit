using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTV.Application.SpecFlowAppiumTests.Pages
{
    public class Activation2 : IPageManager
    {
        private static AppiumDriver<AppiumWebElement> _driver;
        private static string xpathToTitle = @"/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.View/android.view.View/android.view.View/android.view.View[2]/android.view.View[1]";

        public Activation2(AppiumDriver<AppiumWebElement> appiumDriver)
        {
            _driver = appiumDriver;
            
        }
                 
        AppiumWebElement activationTitle => _driver.FindElementByXPath(xpathToTitle);

        public bool ValidateElements(string elementName)
        {
            AppiumWebElement[] appiumWebElements = { activationTitle };

             foreach (AppiumWebElement element in appiumWebElements)
             {
                 if (element != null)
                 {
                     try
                     {
                        return true ? element.Displayed : false;
                     }
                     catch (Exception)
                     {
                         return false;
                     }
                 }
             }

            return false;
        }
    }
}
