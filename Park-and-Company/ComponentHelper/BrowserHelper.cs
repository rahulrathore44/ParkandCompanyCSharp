using System;
using System.Threading;
using log4net;
using Park_and_Company.CustomException;
using Park_and_Company.ExtensionClass.LoggerExtClass;
using Park_and_Company.Settings;

namespace Park_and_Company.ComponentHelper
{
    public class BrowserHelper
    {
        private static readonly ILog Logger = LoggerHelper.GetLogger(typeof (BrowserHelper));
        public static void GoBack()
        {
            try
            {
                ObjectRepository.Driver.Navigate().Back();
                Logger.Info(" Browser Back Button Clicked ");
            }
            catch (Exception exception)
            {
                Logger.LogException(exception);
                throw;
            }
           
        }

        public static void SwitchToWindow(int windowIndex)
        {
            try
            {
                Thread.Sleep(500);
                var windowList = ObjectRepository.Driver.WindowHandles;
                if (windowList == null || windowList.Count < windowIndex)
                {
                    throw new InvalidBrowserWindowIndex($"Invalid index of Browser window : {windowIndex}");
                }
                ObjectRepository.Driver.SwitchTo().Window(windowList[windowIndex]);
                Logger.Info(" Switch to Window " + windowIndex);
            }
            catch (Exception exception)
            {
                Logger.LogException(exception);
                throw;
            }
            
        }

        public static void SwitchToParentWithClose()
        {
            try
            {
                var windowList = ObjectRepository.Driver.WindowHandles;
                for (var i = windowList.Count - 1; i > 0; i--)
                {
                    ObjectRepository.Driver.SwitchTo().Window(windowList[i]);
                    Logger.Info(" Switch to Window " + windowList[i]);
                    ObjectRepository.Driver.Close();
                    Logger.Info(" Browser Window Closed " + windowList[i]);
                }
                ObjectRepository.Driver.SwitchTo().Window(windowList[0]);
                Logger.Info(" Switch to Parent Window ");
            }
            catch (Exception exception)
            {
                Logger.LogException(exception);
                throw;
            }
           
        }

    }


}
