using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;
using Park_and_Company.Settings;

namespace Park_and_Company.PageObject.UserGroups
{
    public class ManageUserGroups : PageBase
    {
        private IWebDriver _driver;
        private readonly GrpNameDetailPage grpPage;

        [FindsBy(How = How.XPath, Using = "//button[text()='Create']")] private IWebElement Create;
        [FindsBy(How = How.XPath, Using = "//*[text()='Duplicate Group']")]
        private IWebElement duplicatBtn;


        public ManageUserGroups(IWebDriver drive) : base(drive)
        {
            this._driver = drive;
            grpPage = new GrpNameDetailPage(_driver);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grpName"></param>
        /// <param name="isSmartGroup"></param>
        public void CreateGroup(string grpName,bool isSmartGroup)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(Create);
            GenericHelper.WaitForLoadingMask();
            GenericHelper.WaitForElement(By.Id("GroupName"));
            var grp = new CreateNewGroup(_driver);
            grp.CreateGroup(grpName,isSmartGroup);
            grp.ClickOk();
            Thread.Sleep(500);
            GenericHelper.WaitForLoadingMask();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridXpath"></param>
        /// <param name="value"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void VerifyCreateGroup(string gridXpath, string value, int row, int column)
        {
            DropDownHelper.SelectItemPerList("100");
            GenericHelper.WaitForLoadingMask();
            GridHelper.VerifyInGridEntry(gridXpath,value,row,column);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridXpath"></param>
        /// <param name="grpName"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void ClickOnUserGrp(string gridXpath, string grpName, int row, int column)
        {
            var gridElement = GridHelper.GetGridElement(gridXpath, row, column);
            if (gridElement != null)
            {
                JavaScriptExecutorHelper.ScrollElementAndClick(gridElement);
            }
            else
            {
                Assert.Fail("Grid Element not found : ",grpName);
            }
            GenericHelper.WaitForLoadingMask();
            grpPage.WaitForSaveButton();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridXpath"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void AddToGroup(string gridXpath, int row, int column)
        {
            grpPage.AddToGrop(gridXpath,row,column);   
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridXpath"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void DeleteFrmGroup(string gridXpath, int row, int column)
        {
            grpPage.DeleteFromGrop(gridXpath, row, column);
        }

        public void ClickSave()
        {
            grpPage.ClickSave();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridXpath"></param>
        /// <param name="row"></param>
        /// <param name="column">Column index should be always 1 for check box</param>
        public void DuplicateGrp(string gridXpath, int row, int column)
        {
            var element = GridHelper.GetGridElement(gridXpath, row, column);
            element.Click();
            JavaScriptExecutorHelper.ScrollElementAndClick(duplicatBtn);
            GenericHelper.WaitForAlert();
            if (GenericHelper.IsAlertPresent())
            {
                ObjectRepository.Driver.SwitchTo().Alert().Accept();
            }
            GenericHelper.WaitForLoadingMask();
        }
    }
}
