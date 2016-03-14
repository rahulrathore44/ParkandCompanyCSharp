using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Park_and_Company.ExtensionClass.LoggerExtClass;
using Park_and_Company.Settings;

namespace Park_and_Company.ComponentHelper
{
    public class GenericHelper
    {
        private static readonly int WaitTime = ObjectRepository.Config.GetExplicitElementLoadTimeout();
        private static readonly ILog Logger = LoggerHelper.GetLogger(typeof (GenericHelper));

        private static Func<IWebDriver, bool> MaskPresence()
        {
            return ((x) =>
            {
                if (x.FindElements((By.XPath(LocatorRepository.LoadingMaskXpath))).Any())
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
            var wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(timeOutInSeconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250),
            };

            wait.IgnoreExceptionTypes(typeof(NoSuchElementException),typeof(ElementNotVisibleException));
            Logger.Info(" Wait Object Created ");
		    return wait;
		
	    }
        public static bool IsElementPresent(By locator)
        {
            try
            {
                var wait = GetWebDriverWait(WaitTime);
                Logger.Info(" Waiting for Element " + locator);
                return wait.Until((CheckForElement(locator)));
            }
            catch (TimeoutException e)
            {
                Logger.Error(" [Ignore] " + e.StackTrace);
                return false;
            }

        }

        public static bool IsElementPresentQuick(By locator)
        {
            try
            {
                Logger.Info(" Checking for Element Quick " + locator);
                return ObjectRepository.Driver.FindElements(locator).Count() == 1;
            }
            catch (Exception e)
            {
                Logger.Error(" [Ignore] " + e.StackTrace);
                return false;
            }
        }

        public static IWebElement GetElement(By locator)
        {
            try
            {
                if (IsElementPresent(locator))
                    return ObjectRepository.Driver.FindElement(locator);
                throw new NoSuchElementException("Element Not Found : " + locator);
            }
            catch (Exception exception)
            {
                Logger.LogException(exception);
                throw;
            }
           
        }

        public static IWebElement GetVisiblityOfElement(By locator)
        {
            try
            {
                var wait = GetWebDriverWait(WaitTime);
                Logger.Info(" Waiting for Visibility of Element " + locator);
                return wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception exception)
            {
                Logger.LogException(exception);
                throw;
            }
           
        }

        public static void WindowMaximize()
        {
            ObjectRepository.Driver.Manage().Window.Maximize();
            Logger.Info(" Browser Window Maximize ");
        }

        public static void SetPageLoadTimeOut(int timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(timeout));
            Logger.Info(" Set the PageLoadTimeOut to " + timeout);
        }

        public static void SetElementLoadTimeOut(int timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(timeout));
            Logger.Info(" Set the ElementLoadTimeOut to " + timeout);
        }

        public static IWebElement WaitForElement(By locator)
        {
            try
            {
                var wait = GetWebDriverWait(WaitTime);
                Logger.Info(" Waiting for Element Exist " + locator);
                return wait.Until(ExpectedConditions.ElementExists(locator));
            }
            catch (Exception exception)
            {
                Logger.LogException(exception);
                throw;
            }
           
        }

        public static IWebElement WaitForElementClickAble(By locator)
        {
            try
            {
                var wait = GetWebDriverWait(WaitTime);
                Logger.Info(" Waiting for Element to be Clickable " + locator);
                return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (Exception exception)
            {
                Logger.LogException(exception);
                throw;
            }
            
        }

        public static IWebElement WaitForElementClickAble(IWebElement element)
        {
            try
            {
                var wait = GetWebDriverWait(WaitTime);
                Logger.Info(" Waiting for Element to be Clickable " + element);
                return wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception exception)
            {
                Logger.LogException(exception);
                throw;
            }

           
        }

        public static IWebElement WaitForElement(IWebElement element)
        {
            try
            {
                var wait = GetWebDriverWait(WaitTime);
                Logger.Info(" Waiting for Element to be Clickable " + element);
                return wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception exception)
            {
                Logger.LogException(exception);
                throw;
            }
            
        }

        public static void WaitForLoadingMask()
        {
            try
            {
                ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
                Logger.Info(" Setting the  Implicitly Wait to 1 Second ");
                var wait = GetWebDriverWait(WaitTime);
                Logger.Info(" Waiting for Loading Mask ");
                wait.Until(MaskPresence());
                ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(ObjectRepository.Config.GetImplicitElementLoadTimeout()));
                Logger.Info(" Setting the  Implicitly Wait to Configured Value ");
            }
            catch (Exception exception)
            {
                Logger.LogException(exception);
                throw;
            }
            
        }

        public static void WaitForAlert()
        {
            try
            {
                ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
                Logger.Info(" Setting the  Implicitly Wait to 1 Second ");
                var wait = GetWebDriverWait(WaitTime);
                Logger.Info(" Waiting for Alert to Present ");
                wait.Until(ExpectedConditions.AlertIsPresent());
                ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(ObjectRepository.Config.GetImplicitElementLoadTimeout()));
                Logger.Info(" Setting the  Implicitly Wait to Configured Value ");
            }
            catch (Exception exception)
            {
                Logger.LogException(exception);
                throw;
            }
            
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
                Logger.Info(" Checking for the Alert ");
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(" [Ignore] " + e.StackTrace);
                return false;
            }
        }

        public static void AcceptAlert()
        {
            if (!IsAlertPresent())
                return;

            ObjectRepository.Driver.SwitchTo().Alert().Accept();
            Logger.Info(" Switching to Alert ");
        }

        public static bool IsTextPresent(string text)
        {
            var textNode = ObjectRepository.Driver.FindElements(By.XPath("//*[text()='" + text + "']"));
            Logger.Info(" Checking for text present " + text);
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
            Logger.Info(" Screen Shot Taken " + name);
        }
    }
}
