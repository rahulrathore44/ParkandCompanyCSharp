using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.ComponentHelper;
using Park_and_Company.Settings;

namespace Park_and_Company.BaseClasses
{
    public class BaseClass
    {
        
        public void Logout()
        {
            if (!GenericHelper.IsElementPresentQuick(By.XPath(LocatorRepository.LogoutXpath)))
                return;

            var logout = GenericHelper.GetElement(By.XPath(LocatorRepository.LogoutXpath));
            logout = GenericHelper.WaitForElementClickAble(logout);
            JavaScriptExecutorHelper.ScrollElementAndClick(logout);
            logout = GenericHelper.WaitForElement(By.XPath(LocatorRepository.LogOffXpath));
            JavaScriptExecutorHelper.ScrollElementAndClick(logout);
            GenericHelper.AcceptAlert();
            GenericHelper.WaitForElement(By.XPath(LocatorRepository.LoginPageLogoXpath));
        }

        public virtual Type GetClassType()
        {
            return GetType();
        }

        protected By GetElementLocator(How locator, string locatorValue)
        {
            switch (locator)
            {
                case How.XPath:
                    return By.XPath(locatorValue);
                case How.ClassName:
                    return By.ClassName(locatorValue);
                case How.CssSelector:
                    return By.CssSelector(locatorValue);
                case How.LinkText:
                    return By.LinkText(locatorValue);
                case How.Name:
                    return By.Name(locatorValue);
                case How.PartialLinkText:
                    return By.PartialLinkText(locatorValue);
                default:
                    return By.Id(locatorValue);
            }
        }
    }
}
