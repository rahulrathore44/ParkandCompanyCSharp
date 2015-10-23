using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Park_and_Company.Settings;

namespace Park_and_Company.ComponentHelper
{
    public class JavaScriptExecutorHelper
    {
        private static IJavaScriptExecutor exeScript;

        public static void ExecuteScript(string script)
        {
            exeScript = ((IJavaScriptExecutor)ObjectRepository.Driver);
            exeScript.ExecuteScript(script);
        }


        public static void ScrollElementAndClick(IWebElement element)
        {
            Thread.Sleep(500);
            JavaScriptExecutorHelper.ExecuteScript("window.scrollTo(0," + element.Location.Y + ");");
            element.Click();
        }

        public static void ScrollToElement(IWebElement element)
        {
            Thread.Sleep(500);
            JavaScriptExecutorHelper.ExecuteScript("window.scrollTo(0," + element.Location.Y + ");");
        }

        public static void ScrollElementAndClick(By locator)
        {
            IWebElement element = ObjectRepository.Driver.FindElement(locator);
            GenericHelper.WaitForElement(element);
            JavaScriptExecutorHelper.ExecuteScript("window.scrollTo(0," + element.Location.Y + ");");
            element.Click();
        }
    }
}
