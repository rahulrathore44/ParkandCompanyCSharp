using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;
using Park_and_Company.PageObject.IncentivePage;

namespace Park_and_Company.PageObject
{
    public class ActivityIncentiveTemplate : PageBase
    {
        private IWebDriver driver;

        public ActivityIncentiveTemplate(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.XPath,Using = "//a[text()='Program Incentive']")]
        private IWebElement ProgramIncentive;

        [FindsBy(How = How.XPath,Using = "//button[text()='Add']")]
        private IWebElement Add;


        [FindsBy(How = How.XPath,Using = "//a[text()='Validation']")]
        private IWebElement Validation;

        [FindsBy(How = How.XPath,Using = "//div[@id='accordion']/descendant::div[@id='rendered'][position()=6]/button")]
        private IWebElement ValidationNext;

        [FindsBy(How = How.XPath,Using = "//a[text()='Finish']")]
        private IWebElement Finish;

        public void AddProgramIncentive(string acCode, string acType, string desc, string points)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(ProgramIncentive);
            GenericHelper.WaitForLoadingMask();
            GenericHelper.WaitForElement(Add);
            Add.Click();
            ProgramIncentive addInc = new ProgramIncentive(driver);
            addInc.AddProgramIncentive(acCode, acType, desc, points);
            JavaScriptExecutorHelper.ScrollElementAndClick(ProgramIncentive);
            GenericHelper.WaitForLoadingMask();
        }


        public void checkValidationField(bool fName, bool lName, bool eMail, bool acCode, bool date) 
        {

            JavaScriptExecutorHelper.ScrollElementAndClick(Validation);
            GenericHelper.WaitForLoadingMask();
            Validation val = new Validation(driver);
            val.CheckValidationField(fName, lName, eMail, acCode, date);
            JavaScriptExecutorHelper.ScrollElementAndClick(ValidationNext);
            Validation.Click();
            GenericHelper.WaitForLoadingMask();

        }

        public void ClickFinish()
        {
            Finish.Click();
        }


        public void SelectProgramName(string pName, string pDesc)
        {
            SelectProgramPage spPage = new SelectProgramPage(driver);
            spPage.SelectProgramName(pName, pDesc);
        }


        public void SelectProgramVisibilityStartDate(string day, string month,
                string year)
        {
            SelectProgramDatesPage spdPage = new SelectProgramDatesPage(driver);
            spdPage.SelectProgramVisibilityStartDate(day, month, year);
        }


        public void SelectProgramVisibilityEndDate(string day, string month,
                string year)
        {
            SelectProgramDatesPage spdPage = new SelectProgramDatesPage(driver);
            spdPage.SelectProgramVisibilityEndDate(day, month, year);

        }


        public void SelectProgramStartDate(string day, string month,
                string year) 
        {
            SelectProgramDatesPage spdPage = new SelectProgramDatesPage(driver);
            spdPage.SelectProgramStartDate(day, month, year);

        }


        public void SelectProgramEndDate(string day, string month,
                string year)
        {
            SelectProgramDatesPage spdPage = new SelectProgramDatesPage(driver);
            spdPage.SelectProgramEndDate(day, month, year);

        }


        public void SelectProgramLastSubmitDate(string day, string month,
                string year)
        {
            SelectProgramDatesPage spdPage = new SelectProgramDatesPage(driver);
            spdPage.SelectProgramLastSubmitDate(day, month, year);

        }


        public void SelectProgramCloseDates(string day, string month,
                string year)
        {
            SelectProgramDatesPage spdPage = new SelectProgramDatesPage(driver);
            spdPage.SelectProgramCloseDates(day, month, year);

        }


        public void AddPoints(string maxPointAllow, string pointExpire, string myPointMsg)
        {
            ConfigureProgramPage cpPage = new ConfigureProgramPage(driver);
            cpPage.AddPoints(maxPointAllow, pointExpire, myPointMsg);
        }


        public void AddPointType(string type, string poitAlloc) 
        {
            ConfigureProgramPage cpPage = new ConfigureProgramPage(driver);
            cpPage.AddPointType(type, poitAlloc);

        }


        public void AddEligibleGroup(string grpName) 
        {
            EligibleGroupPage egPage = new EligibleGroupPage(driver);
            egPage.AddEligibleGroup(grpName);

        }
    }
}
