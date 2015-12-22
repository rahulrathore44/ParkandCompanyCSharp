using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Park_and_Company.PageObject.Claims
{
    public partial class NewClaim
    {
        [FindsBy(How = How.Id, Using = "incentiveInstanceId")]
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

        [FindsBy(How = How.XPath, Using = "//form[@id='productForm']//input[@name='claimDataPRODUCT_SKU_NUMBER']")]
        private IWebElement ProductSKUNumber;

        [FindsBy(How = How.XPath, Using = "//form[@id='productForm']//input[@name='claimDataPRODUCT_SERIAL_NUMBER']")]
        private IWebElement ProductSerialNo;

        [FindsBy(How = How.XPath, Using = "//form[@id='productForm']//input[@name='claimDataQUANTITY']")]
        private IWebElement Quantity;

        [FindsBy(How = How.XPath, Using = "//form[@id='productForm']/descendant::i")]
        private IWebElement AddBtn;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Calculate')]")]
        private IWebElement CalculateBtn;

        [FindsBy(How = How.XPath, Using = "//button[text()='Submit']")]
        private IWebElement SubmitBtn;
    }
}
