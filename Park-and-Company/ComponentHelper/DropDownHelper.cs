using System;
using System.Threading;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Park_and_Company.ExtensionClass.LoggerExtClass;
using Park_and_Company.Settings;

namespace Park_and_Company.ComponentHelper
{
    public class DropDownHelper
    {
        private static readonly ILog Logger = LoggerHelper.GetLogger(typeof(DropDownHelper));
        private static SelectElement _select;
        private static readonly By DownArrow = LocatorRepository.SelectButtonXpath;


        #region Private

        public static By GetDropDownWithLabelXpath(string label)
        {
            return GenericHelper.IsElementPresentQuick(
                By.XPath("//label[text()='" + label + "']/following-sibling::div//span[text()='select']")) ? By.XPath("//label[text()='" + label + "']/following-sibling::div//span[text()='select']") : By.XPath("//label[text()='" + label + "']/following-sibling::span//span[text()='select']");
        }

        #endregion

        public static void SelectByVisibleText(By locator, string text)
        {
            _select = new SelectElement(GenericHelper.GetElement(locator));
            _select.SelectByText(text);
            Logger.Info(text + " Selected from " + locator);
        }

        public static void SelectByVisibleText(IWebElement element, string text)
        {
            _select = new SelectElement(element);
            _select.SelectByText(text);
            Logger.Info(text + " Selected from " + element);
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
            try
            {
                var arrow = GenericHelper.GetElement(GetDropDownWithLabelXpath(label));
                JavaScriptExecutorHelper.ScrollElementAndClick(arrow);
                Thread.Sleep(500);
                var list = GenericHelper.GetVisiblityOfElement(By.XPath("//li[text()='" + value + "']"));
                list.Click();
                GenericHelper.WaitForLoadingMask();
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Logger.LogException(e);
                throw;
            }
            
        }

        public static void SelectFromKendoDropDown(By selectArrow,string value)
        {
            try
            {
                var arrow = GenericHelper.GetElement(selectArrow);
                JavaScriptExecutorHelper.ScrollElementAndClick(arrow);
                Thread.Sleep(500);
                var list = GenericHelper.GetVisiblityOfElement(By.XPath("//li[text()='" + value + "']"));
                list.Click();
                GenericHelper.WaitForLoadingMask();
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Logger.LogException(e);
                throw;
            }
            
        }

    }
}
