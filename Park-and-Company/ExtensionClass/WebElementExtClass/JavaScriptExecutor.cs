using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Park_and_Company.ComponentHelper;

namespace Park_and_Company.ExtensionClass.WebElementExtClass
{
    public static class JavaScriptExecutor
    {
        public static void ScrollToElement(this IWebElement element)
        {
            Thread.Sleep(500);
            JavaScriptExecutorHelper.ExecuteScript("window.scrollTo(0," + element.Location.Y + ");");
        }

        public static void ScrollElementAndClick(this IWebElement element)
        {
            Thread.Sleep(500);
            JavaScriptExecutorHelper.ExecuteScript("window.scrollTo(0," + element.Location.Y + ");");
            element.Click();
        }
    }
}
