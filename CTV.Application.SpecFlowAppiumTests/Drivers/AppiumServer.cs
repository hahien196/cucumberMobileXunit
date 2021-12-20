using System.Diagnostics;


namespace SpecFlowAppiumTests.Drivers
{
    public class AppiumServer
    {

        public ProcessStartInfo WindowsAppiumServer()
        {
            ProcessStartInfo startInfo = new("cmd.exe")
            {
                Arguments = "/K appium",
                UseShellExecute = true
            };

            return startInfo;
        }

    }
}
