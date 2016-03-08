using System.Threading;
using OpenQA.Selenium;
using Park_and_Company.Settings;

namespace Park_and_Company.ComponentHelper
{
    public class JavaScriptExecutorHelper
    {
        private static IJavaScriptExecutor _exeScript;

        public static object ExecuteScript(string script)
        {
            _exeScript = ((IJavaScriptExecutor)ObjectRepository.Driver);
            return _exeScript.ExecuteScript(script);
        }


        public static void ScrollElementAndClick(IWebElement element)
        {
            Thread.Sleep(500);
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ");");
            element.Click();
        }

        public static void ScrollToElement(IWebElement element)
        {
            Thread.Sleep(500);
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ");");
        }

        public static void ScrollElementAndClick(By locator)
        {
            var element = ObjectRepository.Driver.FindElement(locator);
            GenericHelper.WaitForElement(element);
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ");");
            element.Click();
        }
    }
}
