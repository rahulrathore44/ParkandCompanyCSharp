using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;

namespace Park_and_Company.PageObject.Configuration.ManageRoles
{
    public class RolesDetails : PageBase
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath,Using = "//button[text()='Save']")]
        private IWebElement SaveBtn;

        public RolesDetails(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void ClickSaveWithScreenShot(string name)
        {
            TakeScreenShot(name);
            JavaScriptExecutorHelper.ScrollElementAndClick(SaveBtn);
            GenericHelper.WaitForLoadingMask();
        }
    }
}
