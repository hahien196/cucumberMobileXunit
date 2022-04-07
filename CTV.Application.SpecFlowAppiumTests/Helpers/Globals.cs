using System;
using System.Collections.Generic;

namespace SpecFlowAppiumTests.Helpers
{
    public static class Globals
    {
        public const int EXPLICIT_WAIT_TIMEOUT = 5;

        // patien information
        public const string DEFAULT_PATIENT_USERNAME = "user";
        public const string DEFAULT_PATIENT_PIN = "12345678";
        public const string DEFAULT_PATIENT_ACTIVE_CODE = "123456";
        public const string DEFAULT_PATIENT_DOB = "02 October 1990";
        public const string DEFAULT_PATIENT_POSTCODE = "CV37 8LE";

        // carer information
        public const string DEFAULT_CARER_EMAIL = "user";
        public const string DEFAULT_CARER_PASSWORD = "12345678";

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

        public static string TextLocator()
        {
            if (IsAndroid())
            {
                return "text";
            }
            else if (IsIOS())
            {
                return "value";
            }
            return null;
        }

        public static double GetWindowHeight()
        {
            double height = 0.0;
            if (Globals.IsAndroid())
            {
                height = 0.8;
            }
            else if (Globals.IsIOS())
            {
                height = 0.7;
            }
            return height;
        }


        public static string GetLocator()
        {
            string ios = IOSLocator();
            string android = AndroidLocator();

            return ios ?? android;
        }

        public enum Month
        {
            NotSet = 0,
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }

    }
}
