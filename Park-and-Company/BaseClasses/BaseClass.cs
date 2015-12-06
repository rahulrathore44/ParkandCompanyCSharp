using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Park_and_Company.ComponentHelper;

namespace Park_and_Company.BaseClasses
{
    public class BaseClass
    {
        private readonly string logoutXpath =
            "//div[@id='bergerModal']/following-sibling::div[position()=1]/descendant::span[position()=2]";
        public void Logout()
        {
            if (GenericHelper.IsElementPresentQuick(By.XPath(logoutXpath)))
            {
                var logout = GenericHelper.GetElement(By.XPath(logoutXpath));
                logout = GenericHelper.WaitForElementClickAble(logout);
                JavaScriptExecutorHelper.ScrollElementAndClick(logout);
                logout = GenericHelper.WaitForElement(By.XPath("//a[contains(text(),'Log Off')]"));
                JavaScriptExecutorHelper.ScrollElementAndClick(logout);
                GenericHelper.WaitForElement(By.XPath("//div[@class='loginWrapper']"));
            }

        }
    }
}
