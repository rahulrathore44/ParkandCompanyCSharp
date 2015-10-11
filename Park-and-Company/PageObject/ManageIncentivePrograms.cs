﻿using System;
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
            JavaScriptExecutorHelper.ScrollElementAndClick(DownArrow);
            var list = GenericHelper.GetElement(By.XPath("//li[text()='" + number + "']"));
            list.Click();
            GenericHelper.WaitForLoadingMask();
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
		    for(int i = 1; i <= 100; i++){
			    if(GenericHelper.IsElementPresent(By.XPath(gridXpath + "//table//tbody//tr[" + i + "]//td[1]/a"))){
				Assert.AreEqual(GenericHelper.GetText(By.XPath(gridXpath + "//table//tbody//tr[" + i + "]//td[1]/a")), program);
				Assert.AreEqual(GenericHelper.GetText(By.XPath(gridXpath + "//table//tbody//tr[" + i + "]//td[2]")), startDate);
				Assert.AreEqual(GenericHelper.GetText(By.XPath(gridXpath + "//table//tbody//tr[" + i + "]//td[3]")), endDate);
				Assert.AreEqual(GenericHelper.GetText(By.XPath(gridXpath + "//table//tbody//tr[" + i + "]//td[4]/span")), status);
			}
}
	}
    }
}
