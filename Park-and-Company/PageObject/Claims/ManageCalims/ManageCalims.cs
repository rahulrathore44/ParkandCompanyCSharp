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
using Park_and_Company.ExtensionClass.WebElementExtClass;
using Park_and_Company.PageObject.Claims.ManageCalims.AddProduct;

namespace Park_and_Company.PageObject.Claims.ManageCalims
{
    public class ManageCalims : PageBase
    {
        private IWebDriver _driver;
        private AddProducts _addProduct;

        public ManageCalims(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            _addProduct = new AddProducts(_driver);
        }

        [FindsBy(How = How.Name, Using = "programs")] private IWebElement ProgramName;

        [FindsBy(How = How.XPath, Using = "//div[@name='linktodetails']/descendant::i[position()=1]")]
        private IWebElement ArrowBtn;

        [FindsBy(How = How.Name, Using = "claimDataREFERENCE_NUMBER")]
        private IWebElement ReferenceNum;

        [FindsBy(How = How.Name, Using = "claimDataBILL_DATE")]
        private IWebElement BillDate;

        [FindsBy(How = How.Name, Using = "claimDataSHIP_DATE")]
        private IWebElement ShipDate;

        [FindsBy(How = How.Name, Using = "claimDataEMPLOYEE_ID")]
        private IWebElement EmployId;

        [FindsBy(How = How.Name, Using = "claimDataORDER_NUMBER")]
        private IWebElement OrderNo;

        [FindsBy(How = How.Name, Using = "claimDataINVOICE_DATE")]
        private IWebElement InvoiceDate;

        [FindsBy(How = How.Name, Using = "claimDataINVOICE_NUMBER")]
        private IWebElement InvoiceNo;

        [FindsBy(How = How.Name, Using = "claimDataINVOICE_AMOUNT")]
        private IWebElement InvoiceAmt;

        [FindsBy(How = How.Name, Using = "claimDataPO_NUMBER")]
        private IWebElement PoNumber;

        [FindsBy(How = How.Name, Using = "claimDataORDER_DATE")]
        private IWebElement OrderDate;

        [FindsBy(How = How.Name, Using = "claimDataQUOTE_NUMBER")]
        private IWebElement QuoteNo;


        /// <summary>
        /// I have added the required element. But if you want to do for all element in page. Add in this class just like rest of WebElemet
        /// and Assert in this method.
        /// </summary>
        public void ValidateAllElements()
        {
            Assert.IsTrue(GenericHelper.IsElementPresent(GetLocatorOfWebElement("ProgramName")));
            Assert.IsTrue(GenericHelper.IsElementPresent(GetLocatorOfWebElement("ArrowBtn")));
            Assert.IsTrue(GenericHelper.IsElementPresent(GetLocatorOfWebElement("ReferenceNum")));
            Assert.IsTrue(GenericHelper.IsElementPresent(GetLocatorOfWebElement("BillDate")));
            Assert.IsTrue(GenericHelper.IsElementPresent(GetLocatorOfWebElement("ShipDate")));
            Assert.IsTrue(GenericHelper.IsElementPresent(GetLocatorOfWebElement("EmployId")));
            Assert.IsTrue(GenericHelper.IsElementPresent(GetLocatorOfWebElement("OrderNo")));
            Assert.IsTrue(GenericHelper.IsElementPresent(GetLocatorOfWebElement("InvoiceDate")));
            Assert.IsTrue(GenericHelper.IsElementPresent(GetLocatorOfWebElement("InvoiceAmt")));
            Assert.IsTrue(GenericHelper.IsElementPresent(GetLocatorOfWebElement("PoNumber")));
            Assert.IsTrue(GenericHelper.IsElementPresent(GetLocatorOfWebElement("OrderDate")));
            Assert.IsTrue(GenericHelper.IsElementPresent(GetLocatorOfWebElement("QuoteNo")));
        }

        public void SelectProgram(string name)
        {
            DropDownHelper.SelectByVisibleText(ProgramName,name);
            ArrowBtn.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
        }

        public void ClickViewInGrid(string gridXpath, int row)
        {
            var view = GridHelper.GetGridElement(gridXpath, row, 6);
            view?.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
        }

        public void ClickAddProductAndTakeScrShot(string name)
        {
            _addProduct.ClickAddProductAndTakeScrShot(name);
        }

    }
}
