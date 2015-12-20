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
    public class SelectProgramPage : PageBase
    {
        public SelectProgramPage(IWebDriver _driver) : base(_driver)
        {
        }

        [FindsBy(How = How.XPath,Using = "//a[text()='Select Program Name']")]
        private IWebElement SelectProgram;

        [FindsBy(How = How.Name,Using = "DATA_1")]
        private IWebElement ProgramName;

        [FindsBy(How = How.Name,Using = "DATA_2")]
        private IWebElement ProgramDesc;

        [FindsBy(How = How.XPath,Using = "//div[@id='accordion']/descendant::div[@id='rendered'][position()=1]/button")]
        private IWebElement SelectProgramNext;

        public void SelectProgramName(string pName, string pDesc)
        {
            GenericHelper.WaitForLoadingMask();
            SelectProgram.Click();
            GenericHelper.WaitForElement(ProgramName);
            ProgramName.SendKeys(pName);
            ProgramDesc.SendKeys(pDesc);
            SelectProgramNext.Click();
            GenericHelper.WaitForLoadingMask();
            SelectProgram.Click();
            GenericHelper.WaitForLoadingMask();
            Thread.Sleep(500);
        }

        public void SelectProgramAndClickNext()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(SelectProgram);
            GenericHelper.WaitForLoadingMask();
            TakeScreenShot($"SelectProgramName-{DateTime.UtcNow.ToString("hh-mm-ss")}");
            JavaScriptExecutorHelper.ScrollElementAndClick(SelectProgramNext);
            GenericHelper.WaitForLoadingMask();
            JavaScriptExecutorHelper.ScrollElementAndClick(SelectProgram);
            GenericHelper.WaitForLoadingMask();
        }
    }
}
