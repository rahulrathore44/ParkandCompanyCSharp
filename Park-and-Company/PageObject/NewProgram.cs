using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;


namespace Park_and_Company.PageObject
{
    public class NewProgram : PageBase
    {
        private IWebDriver driver;

        public NewProgram(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.Name,Using = "IncentiveTemplate")]
        private IWebElement DefineYourProgram;

        [FindsBy(How = How.XPath, Using = "//button[text()='Build']")]
        private IWebElement Build;

        public ActivityIncentiveTemplate CreateActivityIncentiveTemplate()
        {

            DropDownHelper.SelectByVisibleText(By.Name("IncentiveTemplate"), "Activity Incentive Template");
            GenericHelper.WaitForLoadingMask();
            Build.Click();
            GenericHelper.WaitForLoadingMask();
            return new ActivityIncentiveTemplate(driver);

        }

        public SalesIncentiveTemplateBasic CreateSalesIncentiveTemplate()
        {
            DropDownHelper.SelectByVisibleText(By.Name("IncentiveTemplate"), "Sales Incentive Template - Basic");
            GenericHelper.WaitForLoadingMask();
            Build.Click();
            GenericHelper.WaitForLoadingMask();
            return new SalesIncentiveTemplateBasic(driver);
        }
    }
}
