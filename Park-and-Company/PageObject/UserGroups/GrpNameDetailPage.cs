using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;

namespace Park_and_Company.PageObject.UserGroups
{
    public class GrpNameDetailPage : PageBase
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//button[text()='Save']")]
        private IWebElement Save;


        [FindsBy(How = How.Id, Using = "btnAddUsersToGroup")]
        private IWebElement addToGrp;

        [FindsBy(How = How.Id, Using = "btnDeleteUsersFromGroup")]
        private IWebElement deleteGrp;

        public GrpNameDetailPage(IWebDriver drive) : base(drive)
        {
            this._driver = drive;
        }
        /// <summary>
        /// 
        /// </summary>
        public void WaitForSaveButton()
        {
            GenericHelper.WaitForElement(Save);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridXpath"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void AddToGrop(string gridXpath, int row, int column)
        {
            DropDownHelper.SelectItemPerList("100");
            var element = GridHelper.GetGridElement(gridXpath, row, column);
            JavaScriptExecutorHelper.ScrollElementAndClick(element);
            GenericHelper.WaitForLoadingMask();
            JavaScriptExecutorHelper.ScrollElementAndClick(addToGrp);
            GenericHelper.WaitForLoadingMask();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridXpath"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void DeleteFromGrop(string gridXpath, int row, int column)
        {
            DropDownHelper.SelectItemPerList("100");
            var element = GridHelper.GetGridElement(gridXpath, row, column);
            JavaScriptExecutorHelper.ScrollElementAndClick(element);
            GenericHelper.WaitForLoadingMask();
            JavaScriptExecutorHelper.ScrollElementAndClick(deleteGrp);
            GenericHelper.WaitForLoadingMask();
        }

        public void ClickSave()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(Save);
            GenericHelper.WaitForLoadingMask();
            if (GenericHelper.IsAlertPresent())
            {
                _driver.SwitchTo().Alert().Accept();
            }
            GenericHelper.WaitForLoadingMask();
        }

    }
}
