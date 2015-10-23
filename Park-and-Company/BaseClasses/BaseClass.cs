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
        public void Logout()
        {
            if (GenericHelper.IsElementPresentQuick(By.XPath(("//span[@class='headerMenuPipe']/preceding-sibling::span[contains(text(),'Welcome')]"))))
            {
                var logout = GenericHelper.GetElement(By.XPath("//span[@class='headerMenuPipe']/preceding-sibling::span[contains(text(),'Welcome')]"));
                logout = GenericHelper.WaitForElementClickAble(logout);
                logout.Click();
                logout = GenericHelper.WaitForElement(By.XPath("//a[contains(text(),'Log Off')]"));
                logout.Click();
                GenericHelper.WaitForElement(By.XPath("//div[@class='loginWrapper']"));
            }

        }
    }
}
