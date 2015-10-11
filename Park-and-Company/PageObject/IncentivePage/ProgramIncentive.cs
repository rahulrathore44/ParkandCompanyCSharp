using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;

namespace Park_and_Company.PageObject.IncentivePage
{
    public class ProgramIncentive : PageBase 
    {
        public ProgramIncentive(IWebDriver _driver) : base(_driver)
        {
        }

        [FindsBy(How = How.XPath,Using = "//label[text()='ACTIVITY_CODE']/following-sibling::div/input")]
        private IWebElement Activity_Code;

        [FindsBy(How = How.XPath,Using = "//label[text()='ACTIVITY_TYPE']/following-sibling::div/input")]
        private IWebElement Activity_Type;

        [FindsBy(How = How.XPath,Using = "//label[text()='DESCRIPTION']/following-sibling::div/input")]
        private IWebElement Description;

        [FindsBy(How = How.XPath,Using = "//label[text()='POINTS']/following-sibling::div/input")]
        private IWebElement Points;

        [FindsBy(How = How.XPath,Using = "//button[@type='submit' and text()='Submit']")]
        private IWebElement Submit;

        public void AddProgramIncentive(string acCode, string acType, string desc, string points)
        {
            Activity_Code.SendKeys(acCode);
            Activity_Type.SendKeys(acType);
            Description.SendKeys(desc);
            Points.SendKeys(points);
            Submit.Click();
        }
    }
}
