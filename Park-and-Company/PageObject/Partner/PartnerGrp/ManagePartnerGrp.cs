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
using Park_and_Company.PageObject.UserGroups;

namespace Park_and_Company.PageObject.Partner.PartnerGrp
{
    public class ManagePartnerGrp : PageBase
    {
        private IWebDriver _driver;
        private CreateNewGroup grp;
        private GrpNameDetailPage grpPage;

        [FindsBy(How = How.XPath, Using = "//button[text()='Create']")]
        private IWebElement Create;

        [FindsBy(How = How.XPath, Using = "//button[text()='Duplicate Group']")]
        private IWebElement duplicatBtn;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Create a Group')]")]
        private IWebElement createGrp;

        public ManagePartnerGrp(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            grpPage = new GrpNameDetailPage(_driver);
            grp = new CreateNewGroup(_driver);
        }

        /// <summary>
        /// Click on the create button, take the screen shot and click cancel
        /// </summary>
        /// <param name="scrShotName"></param>
        public void ClickCreateAndTakeSrcShot(string scrShotName)
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

        /// <summary>
        /// This will select the grp based on the row and column value supplied
        /// </summary>
        /// <param name="gridXpath"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void SelectGroup(string gridXpath, int row, int column)
        {
            var element = GridHelper.GetGridElement(gridXpath, row, column);
            element.Click();
        }

        public void ClickOnUserGrp(string gridXpath, string grpName, int row, int column)
        {
            var gridElement = GridHelper.GetGridElement(gridXpath, row, column);
            if (gridElement != null)
            {
                JavaScriptExecutorHelper.ScrollElementAndClick(gridElement);
            }
            else
            {
                Assert.Fail("Grid Element not found : ", grpName);
            }
            GenericHelper.WaitForLoadingMask();
            grpPage.WaitForSaveButton();
        }
    }
}
