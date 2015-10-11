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
using Park_and_Company.Settings;

namespace Park_and_Company.PageObject
{
    public class HomePage : PageBase
    {
        private IWebDriver driver;

        public HomePage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }


        [FindsBy(How = How.XPath,Using = "//div[@id='header4']/descendant::a[text()='Programs ']")]
        private IWebElement Programs;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='User ']")]
        private IWebElement User;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Partner ']")]
        private IWebElement Partner;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='File ']")]
        private IWebElement File;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Communication ']")]
        private IWebElement Communication;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Configuration ']")]
        private IWebElement Configuration;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Reports']")]
        private IWebElement Reports;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Onboarding ']")]
        private IWebElement Onboarding;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Manage Incentive Programs']")]
        private IWebElement ManageIncentivePrograms;



        public ManageIncentivePrograms OpenManageIncentivePrograms()
        {
            Programs.Click();
            GenericHelper.WaitForElement(ManageIncentivePrograms);
            ManageIncentivePrograms.Click();
            GenericHelper.WaitForElement(By.Id("titleDiv"));
            Assert.IsTrue(GenericHelper.IsElementPresent(By.Id("titleDiv")), ErrorMessage.PageLoadErrMsg + "Manage Incentive Programs Page");
            GenericHelper.WaitForLoadingMask();
            return new ManageIncentivePrograms(driver);
        }
    }
}
