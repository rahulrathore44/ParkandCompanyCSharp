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
    public class ManageRoles : PageBase
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath,Using = "//button[text()='CREATE']")]
        private IWebElement CreateBtn;

        public ManageRoles(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public RolesDetails ClickOnRoleName(string gridXpath, int row, int column)
        {
            var elemnet = GridHelper.GetGridElement(gridXpath, row, column);
            JavaScriptExecutorHelper.ScrollElementAndClick(elemnet);
            GenericHelper.WaitForLoadingMask();
            return new RolesDetails(_driver);

        }
    }
}
