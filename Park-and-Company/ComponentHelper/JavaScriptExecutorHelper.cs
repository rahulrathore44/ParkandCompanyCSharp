using System;
using System.Threading;
using log4net;
using OpenQA.Selenium;
using Park_and_Company.ExtensionClass.LoggerExtClass;
using Park_and_Company.Settings;

namespace Park_and_Company.ComponentHelper
{
    public class JavaScriptExecutorHelper
    {
        private static IJavaScriptExecutor _exeScript;
        private static readonly ILog Logger = LoggerHelper.GetLogger(typeof(JavaScriptExecutorHelper));

        public static object ExecuteScript(string script)
        {
            _exeScript = ((IJavaScriptExecutor)ObjectRepository.Driver);
            Logger.Info(" Executing Script " + script);
            return _exeScript.ExecuteScript(script);
        }


        public static void ScrollElementAndClick(IWebElement element)
        {
            try
            {
                Thread.Sleep(500);
                ExecuteScript("window.scrollTo(0," + element.Location.Y + ");");
                element.Click();
                Logger.Info(" Scroll Element And Click " + element);
            }
            catch (Exception exception)
            {
                Logger.LogException(exception);
                throw;
            }
           
        }

        public static void ScrollToElement(IWebElement element)
        {
            try
            {
                Thread.Sleep(500);
                ExecuteScript("window.scrollTo(0," + element.Location.Y + ");");
                Logger.Info(" Scroll To Element " + element);
            }
            catch (Exception exception)
            {
                Logger.LogException(exception);
                throw;
            }
           
        }

        public static void ScrollElementAndClick(By locator)
        {
            var element = ObjectRepository.Driver.FindElement(locator);
            GenericHelper.WaitForElement(element);
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ");");
            element.Click();
            Logger.Info(" Scroll Element And Click " + locator);
        }
    }
}
