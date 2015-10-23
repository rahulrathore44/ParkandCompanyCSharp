using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;

namespace Park_and_Company.PageObject
{
   public class ManageIncentivePrograms : PageBase
    {
        private IWebDriver driver;

        public ManageIncentivePrograms(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.XPath,Using = "//a[contains(text(),'Column options')]")]
        private IWebElement Columnoptions;

        [FindsBy(How = How.XPath, Using = "//span[text()='select']")]
        private IWebElement DownArrow;

        [FindsBy(How = How.XPath, Using = "//select[@data-role='dropdownlist']")]
        private IWebElement ItemPerPage;

        [FindsBy(How = How.XPath, Using = "//button[text()='+ New Program']")]
        private IWebElement NewProgram;

       

        public void ClickColumnoptions()
        {
            Columnoptions.Click();
            GenericHelper.WaitForElement(By.Name("columnOptionsForm"));
        }

        public NewProgram ClickNewProgram()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(NewProgram);
            GenericHelper.WaitForLoadingMask();
		    return new NewProgram(driver);
        }

        public void SelectItemPerList(string number)
        {
            DropDownHelper.SelectItemPerList(number);

        }

        /**
         * @param gridXpath //div[@id='ManageIncentiveProgramsGrid']/div/child::div[position()=3]
         * using which one can reach to table tag
         * @throws InterruptedException 
         */

        public void VerifyIncentiveGridEntry(string gridXpath, string program, string startDate, string endDate, string status)
        {
            SelectItemPerList("100");
            GenericHelper.WaitForLoadingMask();
            //GridHelper.VerifyIncentiveGridEntry(gridXpath,program,startDate,endDate,startDate);
        }
    }
}

