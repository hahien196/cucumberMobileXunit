﻿using OpenQA.Selenium.Appium;
using SpecFlowAppiumTests.Helpers;
using SpecFlowAppiumTests.Pages;

namespace SpecFlowAppiumTests.Navigation
{
    public class AccountNav : INavigationManager
    {
        private AppiumDriver _navigationDriver;
        public AccountNav(AppiumDriver driver)
        {
            _navigationDriver = driver;
        }

        public void NavigateTo()
        {
            HomeNav homeNav = new(_navigationDriver);
            homeNav.NavigateTo();
            Home home = new Home(_navigationDriver);
            home.NavigateToAccount();
        }
    }
}
