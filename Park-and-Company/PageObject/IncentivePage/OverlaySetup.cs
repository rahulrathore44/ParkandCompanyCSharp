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
    public class OverlaySetup : PageBase
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[text()='Overlay Setup']")]
        private IWebElement OverlaySetups;

        [FindsBy(How = How.XPath, Using = "//div[@id='accordion']/descendant::div[@id='rendered'][position()=7]/button")]
        private IWebElement OverlaySetupsNext;

        public OverlaySetup(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void ClickOverlaySetupAndNext()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(OverlaySetups);
            GenericHelper.WaitForLoadingMask();
            TakeScreenShot($"OverlaySetups-{DateTime.UtcNow.ToString("hh-mm-ss")}");
            JavaScriptExecutorHelper.ScrollElementAndClick(OverlaySetupsNext);
            GenericHelper.WaitForLoadingMask();
            JavaScriptExecutorHelper.ScrollElementAndClick(OverlaySetups);
            GenericHelper.WaitForLoadingMask();
        }
    }
}
