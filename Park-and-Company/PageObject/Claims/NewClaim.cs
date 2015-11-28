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

namespace Park_and_Company.PageObject.Claims
{
    public class NewClaim : PageBase
    {
        private IWebDriver _driver;

        public NewClaim(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
            TakeScreenShot(_driver.Title);
        }

        [FindsBy(How =How.Id,Using = "incentiveInstanceId")]
        private IWebElement SelectPrmDropDown;

        [FindsBy(How = How.XPath, Using = "//button[text()='Go']")]
        private IWebElement GoBtn;

        [FindsBy(How = How.Name, Using = "claimDataINVOICE_NUMBER")]
        private IWebElement InvoiceNumber;

        [FindsBy(How = How.Name, Using = "claimDataORDER_NUMBER")]
        private IWebElement OrderNumber;

        [FindsBy(How = How.Name, Using = "claimDataQUOTE_NUMBER")]
        private IWebElement QuotaNo;

        [FindsBy(How = How.Name, Using = "claimDataREFERENCE_NUMBER")]
        private IWebElement RefrenceNo;

        [FindsBy(How = How.XPath, Using = "//div[@title='Order Date']/child::span/descendant::button")]
        private IWebElement OrderDate;

        [FindsBy(How = How.XPath, Using = "//div[@title='Invoice Date']/child::span/descendant::button")]
        private IWebElement InvoiceDate;

        [FindsBy(How = How.XPath, Using = "//div[@title='Bill Date']/child::span/descendant::button")]
        private IWebElement BillDate;

        [FindsBy(How = How.XPath, Using = "//div[@title='Ship Date']/child::span/descendant::button")]
        private IWebElement ShipDate;

        [FindsBy(How = How.Name, Using = "claimDataEMPLOYEE_ID")]
        private IWebElement EmployeeId;

        [FindsBy(How = How.Name, Using = "claimDataPO_NUMBER")]
        private IWebElement PONumber;

        [FindsBy(How = How.Name, Using = "claimDataINVOICE_AMOUNT")]
        private IWebElement InvoiceAmount;

        [FindsBy(How = How.Name, Using = "claimDataPRODUCT_SKU_NUMBER")]
        private IWebElement ProductSKUNumber;

        [FindsBy(How = How.Name, Using = "claimDataPRODUCT_SERIAL_NUMBER")]
        private IWebElement ProductSerialNo;

        [FindsBy(How = How.Name, Using = "claimDataQUANTITY")]
        private IWebElement Quantity;

        [FindsBy(How = How.XPath, Using = "//form[@id='productForm']/descendant::i")]
        private IWebElement AddBtn;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Calculate')]")]
        private IWebElement CalculateBtn;

        [FindsBy(How = How.XPath, Using = "//button[text()='Submit']")]
        private IWebElement SubmitBtn;

        public void SelectNewClaim(string claimName)
        {
            DropDownHelper.SelectByVisibleText(SelectPrmDropDown,claimName);
            GoBtn.Click();
            GenericHelper.WaitForLoadingMask();
        }

        public void InsertNumber(string invoiceNo = null, string orderNo = null, string quoteNo=null, string refrenceNo=null)
        {
            if(!string.IsNullOrEmpty(invoiceNo))
                InvoiceNumber.SendKeys(invoiceNo);
            if (!string.IsNullOrEmpty(orderNo))
                OrderNumber.SendKeys(orderNo);
            if (!string.IsNullOrEmpty(quoteNo))
                QuotaNo.SendKeys(quoteNo);
            if (!string.IsNullOrEmpty(refrenceNo))
                RefrenceNo.SendKeys(refrenceNo);
        }

        public void InsertEmpPoInvoiceNo(string empId = null, string poNo = null, string invoiceNo = null)
        {
            if (!string.IsNullOrEmpty(empId))
                EmployeeId.SendKeys(empId);
            if (!string.IsNullOrEmpty(poNo))
                PONumber.SendKeys(poNo);
            if (!string.IsNullOrEmpty(invoiceNo))
                InvoiceAmount.SendKeys(invoiceNo);
        }

        public void SelectOrderDate(string day, string month, string year)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(OrderDate);
            GenericHelper.WaitForElement(By.XPath("//div[@title='Order Date']//table[@role='grid']"));
            CalenderHelper.SelectDate("//div[@title='Order Date']//table[@role='grid']", day, month, year);
            GenericHelper.WaitForLoadingMask();
        }

        public void SelectInvoiceDate(string day, string month, string year)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(InvoiceDate);
            GenericHelper.WaitForElement(By.XPath("//div[@title='Invoice Date']//table[@role='grid']"));
            CalenderHelper.SelectDate("//div[@title='Invoice Date']//table[@role='grid']", day, month, year);
            GenericHelper.WaitForLoadingMask();
        }

        public void SelectBillDate(string day, string month, string year)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(BillDate);
            GenericHelper.WaitForElement(By.XPath("//div[@title='Bill Date']//table[@role='grid']"));
            CalenderHelper.SelectDate("//div[@title='Bill Date']//table[@role='grid']", day, month, year);
            GenericHelper.WaitForLoadingMask();
        }

        public void SelectShipDate(string day, string month, string year)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(ShipDate);
            GenericHelper.WaitForElement(By.XPath("//div[@title='Ship Date']//table[@role='grid']"));
            CalenderHelper.SelectDate("//div[@title='Ship Date']//table[@role='grid']", day, month, year);
            GenericHelper.WaitForLoadingMask();
        }

        public void EnterProductDetails(string skuNo = null, string srialNo = null, string qty = null)
        {
            if (!string.IsNullOrEmpty(skuNo))
                ProductSKUNumber.SendKeys(skuNo);
            if (!string.IsNullOrEmpty(srialNo))
                ProductSerialNo.SendKeys(srialNo);
            if (!string.IsNullOrEmpty(qty))
                Quantity.SendKeys(qty);
            JavaScriptExecutorHelper.ScrollElementAndClick(AddBtn);
            GenericHelper.WaitForLoadingMask();
            Thread.Sleep(200);
            JavaScriptExecutorHelper.ScrollToElement(CalculateBtn);
            CalculateBtn.Click();
            GenericHelper.WaitForLoadingMask();

        }

        public void ClickVerifyBtnInGrid(string gridXpath,int row,int column)
        {
            GridHelper.ClickVerifyBtnInGrid(gridXpath,row,column);
        }

        public void ClickDeleteBtnInGrid(string gridXpath,int row,int column)
        {
            GridHelper.ClickDeleteBtnInGrid(gridXpath,row,column);
        }

        public void VerifyEstimatedTotalPts(string expValue)
        {
            var actualValue = GenericHelper.GetText(
                By.XPath("//label[text()='Estimated Total Points']/parent::div/following-sibling::div[position()=1]"));
            Assert.AreEqual(expValue,actualValue);
        }

        public string SubmitClaim()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(SubmitBtn);
            GenericHelper.WaitForLoadingMask();
            var claimNoStr = GenericHelper.GetText(By.XPath("//form[@id='newClaimForm']/div[2]/div/div"));
            var claimNo = claimNoStr.Split(' ');
            return claimNo[claimNo.Length - 1];
        }
    }
}
