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

namespace Park_and_Company.PageObject.Configuration.CustomeAttribute
{
    public class CustomAttributes : PageBase
    {
        private IWebDriver _driver;
        private readonly AddEditCustAttributeDetailPage _add;

        [FindsBy(How = How.XPath,Using = "//a[text()='Custom Attribute']")]
        private IWebElement CustomeAttribute;

        [FindsBy(How = How.XPath, Using = "//a[@href='#usersAttributes']")]
        private IWebElement usersAttributes;

        [FindsBy(How = How.XPath, Using = "//a[@href='#partnersAttributes']")]
        private IWebElement partnersAttributes;

        [FindsBy(How = How.XPath, Using = "//div[@id='CustomAttributeGrid']/button")]
        private IWebElement newAttribute;

        public CustomAttributes(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            _add = new AddEditCustAttributeDetailPage(_driver);
        }

        public void ClickOnCustomeAttribute()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(CustomeAttribute);
            GenericHelper.WaitForLoadingMask();
        }

        public void ClickOnUserAttribute()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(usersAttributes);
            GenericHelper.WaitForLoadingMask();
        }

        public void ClickOnPartnerAttribute()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(partnersAttributes);
            GenericHelper.WaitForLoadingMask();
        }

        public void ClickOnNewAndTakeScrShot(string name)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(CustomeAttribute);
            JavaScriptExecutorHelper.ScrollElementAndClick(newAttribute);
            _add.WaitForHeader();
            Thread.Sleep(200);
            TakeScreenShot(name);
            _add.ClickOnCancel();
            GenericHelper.WaitForLoadingMask();
        }

        public void ClickEditInGrid(string gridXpath, int row, int column)
        {
            var edit =
                GenericHelper.GetElement(By.XPath(gridXpath + "//table//tbody//tr[" + row + "]//td[" + column + "]//button[1]"));
            if(edit != null)
            { 
                JavaScriptExecutorHelper.ScrollElementAndClick(edit);
            }
            else
            {
                Assert.Fail($"Edit Button not fount at {row},{column}");
            }
        }

        public void ClickEditAndTakeScrShot(string gridXpath, int row, int column,string name)
        {
            ClickEditInGrid(gridXpath,row,column);
            _add.WaitForHeader();
            Thread.Sleep(500);
            TakeScreenShot(name);
            _add.ClickOnCancel();
            GenericHelper.WaitForLoadingMask();

        }

    }
}
