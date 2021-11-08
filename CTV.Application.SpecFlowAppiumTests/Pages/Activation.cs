using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTV.Application.SpecFlowAppiumTests.Pages
{
    public class Activation : IPageManager
    {
        private static AppiumDriver<AppiumWebElement> _driver;
        private static string xpathToLogo = @"/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.View/android.view.View/android.view.View/android.view.View[1]/android.widget.ImageView";

        public Activation(AppiumDriver<AppiumWebElement> appiumDriver)
        {
            _driver = appiumDriver;
            
        }
                 
        AppiumWebElement spiritLogo => _driver.FindElementByXPath(xpathToLogo);

        public bool ValidateElements(string elementName)
        {
            AppiumWebElement[] appiumWebElements = { spiritLogo };

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
