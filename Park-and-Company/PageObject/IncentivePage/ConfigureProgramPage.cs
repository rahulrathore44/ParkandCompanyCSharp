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

namespace Park_and_Company.PageObject.IncentivePage
{
    public class ConfigureProgramPage : PageBase
    {
        public ConfigureProgramPage(IWebDriver _driver) : base(_driver){}

        [FindsBy(How = How.XPath,Using = "//a[text()='Configure Program']")]
        private IWebElement ConfigureProgram;

        [FindsBy(How = How.XPath,Using = "//div[@id='accordion']/descendant::div[@id='rendered'][position()=3]//input[@data-control='TEXTBOX_DATA_1']")]
        private IWebElement MaximumPointsAllowed;

        [FindsBy(How = How.XPath,Using = "//div[@id='accordion']/descendant::div[@id='rendered'][position()=3]//input[@data-control='TEXTBOX_DATA_2']")]
        private IWebElement PointsExpire;

        [FindsBy(How = How.XPath,Using = "//div[@id='accordion']/descendant::div[@id='rendered'][position()=3]//input[@data-control='TEXTBOX_DATA_3']")]
        private IWebElement MyPointsMessage;

        [FindsBy(How = How.XPath,Using = "//div[@id='PointTypesSection']/descendant::select[position()=1]")]
        private IWebElement PointType;

        [FindsBy(How = How.Name,Using = "pointAllocationPrimary")]
        private IWebElement PointAllocation;

        [FindsBy(How = How.XPath,Using = "//div[@id='accordion']/descendant::div[@id='rendered'][position()=3]/button")]
        private IWebElement ConfigureProgramNext;

        public void AddPoints(string maxPointAllow, string pointExpire, string myPointMsg)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(ConfigureProgram);
            GenericHelper.WaitForLoadingMask();
            JavaScriptExecutorHelper.ScrollElementAndClick(MaximumPointsAllowed);
            MaximumPointsAllowed.Clear();
            MaximumPointsAllowed.SendKeys(maxPointAllow);
            JavaScriptExecutorHelper.ScrollElementAndClick(PointsExpire);
            PointsExpire.Clear();
            PointsExpire.SendKeys(pointExpire);
            JavaScriptExecutorHelper.ScrollElementAndClick(MyPointsMessage);
            MyPointsMessage.Clear();
            MyPointsMessage.SendKeys(myPointMsg);
        }

        public void AddPoints(string maxPointAllow, string pointExpire)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(ConfigureProgram);
            GenericHelper.WaitForLoadingMask();
            JavaScriptExecutorHelper.ScrollElementAndClick(MaximumPointsAllowed);
            MaximumPointsAllowed.Clear();
            MaximumPointsAllowed.SendKeys(maxPointAllow);
            JavaScriptExecutorHelper.ScrollElementAndClick(PointsExpire);
            PointsExpire.Clear();
            PointsExpire.SendKeys(pointExpire);
        }

        public void AddPointType(string type, string poitAlloc)
        {
            PointAllocation.Clear();
            PointAllocation.SendKeys(poitAlloc);
            JavaScriptExecutorHelper.ScrollElementAndClick(PointType);
            DropDownHelper.SelectByVisibleText(PointType, type);
            Thread.Sleep(1000);
            ConfigureProgramNext.Click();
            GenericHelper.WaitForLoadingMask();
            ConfigureProgram.Click();
            GenericHelper.WaitForLoadingMask();
        }


    }
}
