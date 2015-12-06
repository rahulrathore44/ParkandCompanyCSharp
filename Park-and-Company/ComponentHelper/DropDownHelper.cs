using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Park_and_Company.ComponentHelper
{
    public class DropDownHelper
    {
        private static SelectElement select;
        private static readonly By DownArrow = By.XPath("//span[text()='select']");

        public static void SelectByVisibleText(By locator, string text)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            select.SelectByText(text);
        }

        public static void SelectByVisibleText(IWebElement element, string text)
        {
            select = new SelectElement(element);
            select.SelectByText(text);
        }

        public static void SelectItemPerList(string number)
        {
            var arrow = GenericHelper.GetElement(DownArrow);
            JavaScriptExecutorHelper.ScrollElementAndClick(arrow);
            Thread.Sleep(500);
            var list = GenericHelper.GetVisiblityOfElement(By.XPath("//li[text()='" + number + "']"));
            list.Click();
            GenericHelper.WaitForLoadingMask();
            Thread.Sleep(1000);
        }

        public static void SelectFromKendoDropDown(By selectArrow,string value)
        {
            var arrow = GenericHelper.GetElement(selectArrow);
            JavaScriptExecutorHelper.ScrollElementAndClick(arrow);
            Thread.Sleep(500);
            var list = GenericHelper.GetVisiblityOfElement(By.XPath("//li[text()='" + value + "']"));
            list.Click();
            GenericHelper.WaitForLoadingMask();
            Thread.Sleep(1000);
        }

    }
}
