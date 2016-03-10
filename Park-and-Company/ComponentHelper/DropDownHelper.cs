using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Park_and_Company.Settings;

namespace Park_and_Company.ComponentHelper
{
    public class DropDownHelper
    {
        private static SelectElement select;
        private static readonly By DownArrow = By.XPath(LocatorRepository.SelectButtonXpath);

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

        public static void SelectFromDropDownWithLabel(string label,string value)
        {
            var arrow = GenericHelper.GetElement(By.XPath("//label[text()='" + label + "']/following-sibling::div//span[text()='select']"));
            JavaScriptExecutorHelper.ScrollElementAndClick(arrow);
            Thread.Sleep(500);
            var list = GenericHelper.GetVisiblityOfElement(By.XPath("//li[text()='" + value + "']"));
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
