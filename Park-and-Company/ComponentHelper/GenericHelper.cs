﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Park_and_Company.Settings;

namespace Park_and_Company.ComponentHelper
{
    public class GenericHelper
    {
        private const string MaskXpath = "//div[@id='loadingIndicatorContainer' and contains(@style,'display: none;')]";

        private static Func<IWebDriver, bool> MaskPresence()
        {
            return ((x) =>
            {
                if (x.FindElements((By.XPath(MaskXpath))).Any())
                    return true;
                return false;
            });
        }

        private static Func<IWebDriver, bool> CheckForElement(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Any())
                    return true;
                return false;
            });
        }

        public static WebDriverWait GetWebDriverWait(int timeOutInSeconds)
        {
            var wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException),typeof(ElementNotVisibleException));
		    return wait;
		
	    }
        public static bool IsElementPresent(By locator)
        {
            try
            {
                var wait = GetWebDriverWait(60);
                return wait.Until((CheckForElement(locator)));
            }
            catch (TimeoutException e)
            {
                return false;
            }

        }

        public static bool IsElementPresentQuick(By locator)
        {
            try
            {
                return ObjectRepository.Driver.FindElements(locator).Count() == 1;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static IWebElement GetElement(By locator)
        {
            if (IsElementPresent(locator))
                return ObjectRepository.Driver.FindElement(locator);
            throw new NoSuchElementException("Element Not Found : " + locator.ToString());
        }

        public static IWebElement GetVisiblityOfElement(By locator)
        {
            var wait = GetWebDriverWait(60);
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WindowMaximize()
        {
            ObjectRepository.Driver.Manage().Window.Maximize();
        }

        public static void SetPageLoadTimeOut(int timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(timeout));
        }

        public static void SetElementLoadTimeOut(int timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(timeout));
        }

        public static IWebElement WaitForElement(By locator)
        {
            var wait = GetWebDriverWait(60);
            return wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public static IWebElement WaitForElementClickAble(By locator)
        {
            var wait = GetWebDriverWait(60);
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static IWebElement WaitForElementClickAble(IWebElement element)
        {
            var wait = GetWebDriverWait(60);
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static IWebElement WaitForElement(IWebElement element)
        {
            var wait = GetWebDriverWait(60);
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitForLoadingMask()
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
            var wait = GetWebDriverWait(60);
            wait.Until(MaskPresence());
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut()));
        }

        public static void WaitForAlert()
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
            var wait = GetWebDriverWait(60);
            wait.Until(ExpectedConditions.AlertIsPresent());
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut()));
        }

        public static string GetText(By locator)
        {
            return IsElementPresent(locator) ? ObjectRepository.Driver.FindElement(locator).Text : null;
        }

        public static bool IsAlertPresent()
        {
            try
            {
                ObjectRepository.Driver.SwitchTo().Alert();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void AcceptAlert()
        {
            if (IsAlertPresent())
            {
                ObjectRepository.Driver.SwitchTo().Alert().Accept();
            }
        }

        public static bool IsTextPresent(string text)
        {
            var textNode = ObjectRepository.Driver.FindElements(By.XPath("//*[text()='" + text + "']"));

            return textNode.Count != 0 && textNode.All((x) => x.Text.Equals(text));
        }

        public static void TakeSceenShot(string name = null)
        {
            if (name == null)
            {
                name = "Screenshot" + DateTime.UtcNow.ToString("yy-MMM-dd-mm") + ".jpeg";
            }
            else
            {
                name = name + ".jpeg";
            }
            var src = ObjectRepository.Driver.TakeScreenshot();
            src.SaveAsFile(name,ImageFormat.Jpeg);
        }
    }
}
