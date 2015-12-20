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
    public class SelectProgramDatesPage : PageBase
    {
        public SelectProgramDatesPage(IWebDriver _driver) : base(_driver)
        {
        }

        [FindsBy(How = How.XPath,Using = "//a[text()='Select Program Dates']")]
        private IWebElement SelectPrograDates;

        [FindsBy(How = How.XPath,Using = "//div[@id='accordion']/descendant::div[@id='rendered'][position()=2]/button")]
        private IWebElement SelectDatesNext;
        
        [FindsBy(How = How.XPath,Using = "//button[@data-control='BUTTON_DATA_1']")]
        private IWebElement VisibilityStartDate;

        [FindsBy(How = How.XPath,Using = "//button[@data-control='BUTTON_DATA_2']")]
        private IWebElement VisibilityEndDate;

        [FindsBy(How = How.XPath,Using = "//button[@data-control='BUTTON_DATA_3']")]
        private IWebElement StartDate;

        [FindsBy(How = How.XPath,Using = "//button[@data-control='BUTTON_DATA_4']")]
        private IWebElement EndDate;

        [FindsBy(How = How.XPath,Using = "//button[@data-control='BUTTON_DATA_5']")]
        private IWebElement LastSubmitDate;

        [FindsBy(How = How.XPath,Using = "//button[@data-control='BUTTON_DATA_6']")]
        private IWebElement CloseDate;

        public void SelectProgramVisibilityStartDate(string day, string month, string year)
        {

            JavaScriptExecutorHelper.ScrollElementAndClick(SelectPrograDates);
            GenericHelper.WaitForLoadingMask();
            VisibilityStartDate.Click();

            GenericHelper.WaitForElement(By.XPath("//div[@data-control='DATA_1']//table[@role='grid']"));
            /* VisibilityStartDate  */
            CalenderHelper.SelectDate("//div[@data-control='DATA_1']//table[@role='grid']", day, month, year);
            GenericHelper.WaitForLoadingMask();

        }

        public void SelectProgramVisibilityEndDate(string day, string month, string year)
        {

            JavaScriptExecutorHelper.ScrollElementAndClick(VisibilityEndDate);
            GenericHelper.WaitForElement(By.XPath("//div[@data-control='DATA_2']//table[@role='grid']"));
            /* VisibilityEndDate  */
            CalenderHelper.SelectDate("//div[@data-control='DATA_2']//table[@role='grid']", day, month, year);
            GenericHelper.WaitForLoadingMask();

        }

        public void SelectProgramStartDate(string day, string month, string year)
        {

            JavaScriptExecutorHelper.ScrollElementAndClick(StartDate);
            GenericHelper.WaitForElement(By.XPath("//div[@data-control='DATA_3']//table[@role='grid']"));
            /* StartDate  */
            CalenderHelper.SelectDate("//div[@data-control='DATA_3']//table[@role='grid']", day, month, year);
            GenericHelper.WaitForLoadingMask();

        }

        public void SelectProgramEndDate(string day, string month, string year) 
        {

            JavaScriptExecutorHelper.ScrollElementAndClick(EndDate);
            GenericHelper.WaitForElement(By.XPath("//div[@data-control='DATA_4']//table[@role='grid']"));
            /* StartDate  */
            CalenderHelper.SelectDate("//div[@data-control='DATA_4']//table[@role='grid']", day, month, year);
            GenericHelper.WaitForLoadingMask();
        }

        public void SelectProgramLastSubmitDate(string day, string month, string year) 
        {

            JavaScriptExecutorHelper.ScrollElementAndClick(LastSubmitDate);
            GenericHelper.WaitForElement(By.XPath("//div[@data-control='DATA_5']//table[@role='grid']"));
            /* LastSubmitDate  */
            CalenderHelper.SelectDate("//div[@data-control='DATA_5']//table[@role='grid']", day, month, year);
            GenericHelper.WaitForLoadingMask();
        }

        public void SelectProgramCloseDates(string day, string month, string year) 
        {

            JavaScriptExecutorHelper.ScrollElementAndClick(CloseDate);
            GenericHelper.WaitForElement(By.XPath("//div[@data-control='DATA_6']//table[@role='grid']"));
            /* CloseDate  */
            CalenderHelper.SelectDate("//div[@data-control='DATA_6']//table[@role='grid']", day, month, year);
            GenericHelper.WaitForLoadingMask();

            JavaScriptExecutorHelper.ScrollElementAndClick(SelectDatesNext);
            GenericHelper.WaitForLoadingMask();

            JavaScriptExecutorHelper.ScrollElementAndClick(SelectPrograDates);
            GenericHelper.WaitForLoadingMask();
        }

        public void SelectProgramDatesAndClickNext()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(SelectPrograDates);
            GenericHelper.WaitForLoadingMask();
            TakeScreenShot($"SelectPrograDates-{DateTime.UtcNow.ToString("hh-mm-ss")}");
            JavaScriptExecutorHelper.ScrollElementAndClick(SelectDatesNext);
            GenericHelper.WaitForLoadingMask();
            JavaScriptExecutorHelper.ScrollElementAndClick(SelectPrograDates);
            GenericHelper.WaitForLoadingMask();
        }
    }
}
