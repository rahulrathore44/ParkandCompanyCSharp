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
        private readonly CreateNewGroup grp;

        [FindsBy(How = How.XPath, Using = "//button[text()='Create']")]
        private IWebElement Create;

        [FindsBy(How = How.XPath, Using = "//button[text()='Duplicate Group']")]
        private IWebElement duplicatBtn;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Create a Group')]")]
        private IWebElement createGrp;
        
        public ManageUserGroups(IWebDriver drive) : base(drive)
        {
            this._driver = drive;
            grpPage = new GrpNameDetailPage(_driver);
            grp = new CreateNewGroup(_driver);
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
            grp.CreateGroup(grpName,isSmartGroup);
            grp.ClickOk();
            Thread.Sleep(500);
            GenericHelper.WaitForLoadingMask();
        }

        public void ClickCreateAndCancel(string scrShotName)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(Create);
            GenericHelper.WaitForLoadingMask();
            GenericHelper.WaitForElement(By.Id("GroupName"));
            Thread.Sleep(200);
            TakeScreenShot(scrShotName);
            grp.ClickCancel();
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

        public void SelectGroup(string gridXpath, int row, int column)
        {
            var element = GridHelper.GetGridElement(gridXpath, row, column);
            element.Click();
        }

        public void CreateGrpOfGroup(string grpName,string grpDes)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(createGrp);
            GenericHelper.WaitForLoadingMask();
            GenericHelper.WaitForElement(By.XPath("//h3[text()='Create a Group Of Groups']"));
            grp.CreateGrpOfGroup(grpName,grpDes);
            grp.ClickOk();
            GenericHelper.WaitForLoadingMask();
            Thread.Sleep(500);
        }

        /// <summary>
        /// Select multiple grp, then click on create a grp button, take the scr shot and then hit cancel
        /// </summary>
        /// <param name="name"></param>
        public void CreateGrpOfGrpAndCancel(string name)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(createGrp);
            GenericHelper.WaitForLoadingMask();
            GenericHelper.WaitForElement(By.XPath("//h3[text()='Create a Group Of Groups']"));
            Thread.Sleep(200);
            TakeScreenShot(name);
            grp.ClickCancel();
            GenericHelper.WaitForLoadingMask();
            Thread.Sleep(100);
        }
    }
}
