using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;

namespace Park_and_Company.PageObject.Programs.ManualPointAdjustment
{
    public class ManualPointAdjustment : PageBase
    {
        private IWebDriver _driver;
        private readonly PointTypeDetail _detail;

        [FindsBy(How = How.Id,Using = "PointTypes")]
        private IWebElement PointType;

        [FindsBy(How = How.Id, Using = "IncentiveInstance")]
        private IWebElement ProgramNames;

        [FindsBy(How = How.XPath, Using = "//a[text()='Go To File Management']")]
        private IWebElement FileManagment;

        [FindsBy(How = How.XPath, Using = "//button[text()='Point Adjustment']")]
        private IWebElement PointAdjustmet;

        public ManualPointAdjustment(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            _detail = new PointTypeDetail(_driver);
        }

        public void SelectPointAndProgram(string pointTy,string programName)
        {
            //DropDownHelper.SelectByVisibleText(PointType, pointTy);
            DropDownHelper.SelectFromDropDownWithLabel("Point Types", pointTy);
            Thread.Sleep(200);
            //DropDownHelper.SelectByVisibleText(ProgramNames, programName);
            DropDownHelper.SelectFromDropDownWithLabel("Program Names", programName);
            Thread.Sleep(2000);
            GenericHelper.WaitForLoadingMask();
        }

        public void SelectPointTypInGrid(string gridXpath, int row, int column)
        {
            var element = GridHelper.GetGridElement(gridXpath, row, column);
            JavaScriptExecutorHelper.ScrollElementAndClick(element);
        }

        public void ClickPointToAdjust()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(PointAdjustmet);
        }

        public void ClickPointAdjTakeScrShot(string name)
        {
            ClickPointToAdjust();
            _detail.WaitForModalDialog();
            Thread.Sleep(300);
            TakeScreenShot(name);
            _detail.ClickClose();
            Thread.Sleep(100);
        }
    }
}
