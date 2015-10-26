using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;

namespace Park_and_Company.PageObject.UserGroups
{
    public class CreateNewGroup : PageBase
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Id,Using = "GroupName")]
        private IWebElement GroupName;

        [FindsBy(How = How.Id, Using = "GroupDescription")]
        private IWebElement GroupDescription;

        [FindsBy(How = How.XPath,Using = "//input[@name='SmartGroup' and @value='yes']")]
        private IWebElement Yes;

        [FindsBy(How = How.XPath, Using = "//input[@name='SmartGroup' and @value='no']")]
        private IWebElement No;

        [FindsBy(How = How.XPath, Using = "//button[text()='OK']")]
        private IWebElement Ok;

        [FindsBy(How = How.XPath, Using = "//button[text()='Cancel']")]
        private IWebElement Cancel;

        public CreateNewGroup(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        public void CreateGroup(string grpName, bool isSmartGroup)
        {
            GroupName.SendKeys(grpName);
            if(isSmartGroup)
                Yes.Click();
            else
                No.Click();
            Thread.Sleep(500);
        }

        public void CreateGrpOfGroup(string grpName, string grpDescription)
        {
            GroupName.SendKeys(grpName);
            GroupDescription.SendKeys(grpDescription);
            Thread.Sleep(500);
        }

        public void ClickOk()
        {
            Ok.Click();
        }

        public void ClickCancel()
        {
            Cancel.Click();
        }
    }
}
