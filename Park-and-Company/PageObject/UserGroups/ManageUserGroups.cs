using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;

namespace Park_and_Company.PageObject.UserGroups
{
    public class ManageUserGroups : PageBase
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//button[text()='Create']")] private IWebElement Create;

        public ManageUserGroups(IWebDriver drive) : base(drive)
        {
            this._driver = drive;
        }

        public void CreateGroup(string grpName,bool isSmartGroup)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(Create);
            GenericHelper.WaitForLoadingMask();
            GenericHelper.WaitForElement(By.Id("GroupName"));
            var grp = new CreateNewGroup(_driver);
            grp.CreateGroup(grpName,isSmartGroup);
            grp.ClickOk();
            Thread.Sleep(500);
            GenericHelper.WaitForLoadingMask();
        }
    }
}
