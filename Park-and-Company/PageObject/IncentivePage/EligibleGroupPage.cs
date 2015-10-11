using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Park_and_Company.ComponentHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;

namespace Park_and_Company.PageObject.IncentivePage
{
    public class EligibleGroupPage : PageBase
    {
        public EligibleGroupPage(IWebDriver _driver) : base(_driver)
        {
        }

            [FindsBy(How = How.XPath,Using = "//a[text()='Eligible Group(s)']")]
            private IWebElement EligibleGroup;

            [FindsBy(How = How.XPath,Using = "//select[@title='Group']")]
            private IWebElement EligibleGroupDropown;

            [FindsBy(How = How.XPath,Using = "//div[@id='accordion']/descendant::div[@id='rendered'][position()=5]/button")]
            private IWebElement EligibleGroupNext;

            public void AddEligibleGroup(string grpName)
            {
                JavaScriptExecutorHelper.ScrollElementAndClick(EligibleGroup);
                GenericHelper.WaitForLoadingMask();
                DropDownHelper.SelectByVisibleText(EligibleGroupDropown, grpName);
                EligibleGroupNext.Click();
                Thread.Sleep(500);
                EligibleGroup.Click();
                GenericHelper.WaitForLoadingMask();
            }
    }
}
