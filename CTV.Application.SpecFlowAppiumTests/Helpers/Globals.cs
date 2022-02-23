using System;

namespace SpecFlowAppiumTests.Helpers
{
    public static class Globals
    {
        public static bool IsAndroid()
        {
            if ((Environment.GetEnvironmentVariable("PLATFORM", EnvironmentVariableTarget.Process)) == "Android")
            {
                return true;
            }

            return false;
        }

        public static bool IsIOS()
        {
            if ((Environment.GetEnvironmentVariable("PLATFORM", EnvironmentVariableTarget.Process)) == "iOS")
            {
                return true;
            }

            return false;
        }

        public static string AndroidLocator()
        {
            if (IsAndroid())
            {
                return "content-desc";
            }
            return null;
        }

        public static string IOSLocator()
        {
            if (IsIOS())
            {
                return "name";
            }
            return null;
        }

        public static double IOSWindowHeight()
        {
            return 0.9;
        }

        public static double AndroidWindowHeight()
        {
            return 0.8;
        }

        public static string GetLocator()
        {
            string ios = IOSLocator();
            string android = AndroidLocator();

            return ios ?? android;
        }
    }
}
