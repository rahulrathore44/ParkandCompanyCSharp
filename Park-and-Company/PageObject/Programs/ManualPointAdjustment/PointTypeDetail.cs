using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;

namespace Park_and_Company.PageObject.Programs.ManualPointAdjustment
{
    public class PointTypeDetail : PageBase
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath,Using = "//button[text()='Save']/following-sibling::button[text()='Close']")]
        private IWebElement close;

        public PointTypeDetail(IWebDriver driver) : base(driver)
        {
            _driver = driver;   
        }

        public void ClickClose()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(close);
        }

        public void WaitForModalDialog()
        {
            GenericHelper.WaitForElement(close);
        }
    }
}
