using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;

namespace Park_and_Company.PageObject.IncentivePage
{
    public class BundleSetup : PageBase
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[text()='Bundle Setup']")]
        private IWebElement BundleSetups;

        [FindsBy(How = How.Name,Using = "UserGroups")]
        private IWebElement bundleDropDown;

        [FindsBy(How = How.XPath,Using = "//button[text()='Skip']")]
        private IWebElement skip;

        [FindsBy(How = How.XPath, Using = "//button[text()='Create a New Bundle']")]
        private IWebElement createNewBundle;

        [FindsBy(How = How.XPath, Using = "//div[@id='accordion']/descendant::div[@id='rendered'][position()=6]/button")]
        private IWebElement BundleSetupsNext;

        public BundleSetup(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void Skip()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(skip);
            BundleSetupsNext.Click();
            GenericHelper.WaitForLoadingMask();
        }

        public void ClickBundleSetupsAndNext()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(BundleSetups);
            GenericHelper.WaitForLoadingMask();
            TakeScreenShot($"BundleSetups-{DateTime.UtcNow.ToString("hh-mm-ss")}");
            JavaScriptExecutorHelper.ScrollElementAndClick(BundleSetupsNext);
            GenericHelper.WaitForLoadingMask();
            JavaScriptExecutorHelper.ScrollElementAndClick(BundleSetups);
            GenericHelper.WaitForLoadingMask();
        }
    }
}
