using System.Threading;
using Park_and_Company.CustomException;
using Park_and_Company.Settings;

namespace Park_and_Company.ComponentHelper
{
    public class BrowserHelper
    {
        public static void GoBack()
        {
            ObjectRepository.Driver.Navigate().Back();
        }

        public static void SwitchToWindow(int windowIndex)
        {
            Thread.Sleep(500);
            var windowList = ObjectRepository.Driver.WindowHandles;
            if (windowList == null || windowList.Count < windowIndex)
            {
                throw new InvalidBrowserWindowIndex($"Invalid index of Browser window : {windowIndex}");
            }
            ObjectRepository.Driver.SwitchTo().Window(windowList[windowIndex]);
        }

        public static void SwitchToParentWithClose()
        {
            var windowList = ObjectRepository.Driver.WindowHandles;
            for (var i = windowList.Count - 1; i > 0; i--)
            {
                ObjectRepository.Driver.SwitchTo().Window(windowList[i]);
                ObjectRepository.Driver.Close();
            }
            ObjectRepository.Driver.SwitchTo().Window(windowList[0]);
        }

    }


}
