using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;

namespace Park_and_Company.PageObject.IncentivePage
{
    public class Validation : PageBase
    {
        public Validation(IWebDriver _driver) : base(_driver)
        {
        }

        [FindsBy(How = How.Name,Using = "FIRST_NAME")]
        private IWebElement FirstName;

        [FindsBy(How = How.Name,Using = "LAST_NAME")]
        private IWebElement Lastname;

        [FindsBy(How = How.Name,Using = "EMAIL")]
        private IWebElement Email;

        [FindsBy(How = How.Name,Using = "ACTIVITY_CODE")]
        private IWebElement ActivityCode;

        [FindsBy(How = How.Name,Using = "DATE")]
        private IWebElement Date;

        [FindsBy(How = How.Name, Using = "INVOICE_NUMBER_VALIDATE")]
        private IWebElement InvoiceNoValidate;

        [FindsBy(How = How.Name, Using = "INVOICE_NUMBER_CLAIM_LIMIT")]
        private IWebElement InvoiceClaimLimit;

        [FindsBy(How = How.Name, Using = "INVOICE_NUMBER_DISPLAY_ON_CLAIM_FORM")]
        private IWebElement InvoiceDisplayOnForm;

        [FindsBy(How = How.Name, Using = "ORDER_NUMBER_VALIDATE")]
        private IWebElement OrderNoValidate;

        [FindsBy(How = How.Name, Using = "ORDER_NUMBER_CLAIM_LIMIT")]
        private IWebElement OrderClaimLimit;

        [FindsBy(How = How.Name, Using = "ORDER_NUMBER_DISPLAY_ON_CLAIM_FORM")]
        private IWebElement OrderDisplayOnForm;

        [FindsBy(How = How.Name, Using = "QUOTE_NUMBER_VALIDATE")]
        private IWebElement QuoteNoValidate;

        [FindsBy(How = How.Name, Using = "QUOTE_NUMBER_CLAIM_LIMIT")]
        private IWebElement QuoteClaimLimit;

        [FindsBy(How = How.Name, Using = "QUOTE_NUMBER_DISPLAY_ON_CLAIM_FORM")]
        private IWebElement QuoteDisplayOnForm;

        [FindsBy(How = How.Name, Using = "REFERENCE_NUMBER_VALIDATE")]
        private IWebElement RefernceNoValidate;

        [FindsBy(How = How.Name, Using = "REFERENCE_NUMBER_CLAIM_LIMIT")]
        private IWebElement RefernceClaimLimit;

        [FindsBy(How = How.Name, Using = "REFERENCE_NUMBER_DISPLAY_ON_CLAIM_FORM")]
        private IWebElement RefernceDisplayOnForm;

        [FindsBy(How = How.Name, Using = "ORDER_DATE_VALIDATE")]
        private IWebElement OrderDateValidate;

        [FindsBy(How = How.Name, Using = "ORDER_DATE_CLAIM_LIMIT")]
        private IWebElement OrdeDateClaimLimit;

        [FindsBy(How = How.Name, Using = "ORDER_DATE_DISPLAY_ON_CLAIM_FORM")]
        private IWebElement OrderDateDisplayOnForm;

        [FindsBy(How = How.Name, Using = "INVOICE_DATE_VALIDATE")]
        private IWebElement InvoiceDateValidate;

        [FindsBy(How = How.Name, Using = "INVOICE_DATE_CLAIM_LIMIT")]
        private IWebElement InvoiceDateClaimLimit;

        [FindsBy(How = How.Name, Using = "INVOICE_DATE_DISPLAY_ON_CLAIM_FORM")]
        private IWebElement InvoiceDateDisplayOnForm;

        [FindsBy(How = How.Name, Using = "BILL_DATE_VALIDATE")]
        private IWebElement BillDateValidate;

        [FindsBy(How = How.Name, Using = "BILL_DATE_CLAIM_LIMIT")]
        private IWebElement BillDateClaimLimit;

        [FindsBy(How = How.Name, Using = "BILL_DATE_DISPLAY_ON_CLAIM_FORM")]
        private IWebElement BillDateDisplayOnForm;

        [FindsBy(How = How.Name, Using = "SHIP_DATE_VALIDATE")]
        private IWebElement ShipDateValidate;

        [FindsBy(How = How.Name, Using = "SHIP_DATE_CLAIM_LIMIT")]
        private IWebElement ShipDateClaimLimit;

        [FindsBy(How = How.Name, Using = "SHIP_DATE_DISPLAY_ON_CLAIM_FORM")]
        private IWebElement ShipDateDisplayOnForm;

        [FindsBy(How = How.Name, Using = "PRODUCT_SKU_NUMBER_VALIDATE")]
        private IWebElement ProductSkuValidate;

        [FindsBy(How = How.Name, Using = "PRODUCT_SKU_NUMBER_CLAIM_LIMIT")]
        private IWebElement ProductSkuClaimLimit;

        [FindsBy(How = How.Name, Using = "PRODUCT_SKU_NUMBER_DISPLAY_ON_CLAIM_FORM")]
        private IWebElement ProductSkuDisplayOnForm;

        [FindsBy(How = How.Name, Using = "PRODUCT_SERIAL_NUMBER_VALIDATE")]
        private IWebElement ProductSerialValidate;

        [FindsBy(How = How.Name, Using = "PRODUCT_SERIAL_NUMBER_CLAIM_LIMIT")]
        private IWebElement ProductSerialClaimLimit;

        [FindsBy(How = How.Name, Using = "PRODUCT_SERIAL_NUMBER_DISPLAY_ON_CLAIM_FORM")]
        private IWebElement ProductSerialDisplayOnForm;

        [FindsBy(How = How.Name, Using = "QUANTITY_VALIDATE")]
        private IWebElement ProductQtyValidate;

        [FindsBy(How = How.Name, Using = "QUANTITY_CLAIM_LIMIT")]
        private IWebElement ProductQtyClaimLimit;

        [FindsBy(How = How.Name, Using = "QUANTITY_DISPLAY_ON_CLAIM_FORM")]
        private IWebElement ProductQtyDisplayOnForm;

        [FindsBy(How = How.Name, Using = "PO_NUMBER_VALIDATE")]
        private IWebElement PoNumberValidate;

        [FindsBy(How = How.Name, Using = "PO_NUMBER_CLAIM_LIMIT")]
        private IWebElement PoNumberClaimLimit;

        [FindsBy(How = How.Name, Using = "PO_NUMBER_DISPLAY_ON_CLAIM_FORM")]
        private IWebElement PoNumberDisplayOnForm;

        [FindsBy(How = How.Name, Using = "INVOICE_AMOUNT_VALIDATE")]
        private IWebElement InvoiceAmtValidate;

        [FindsBy(How = How.Name, Using = "INVOICE_AMOUNT_CLAIM_LIMIT")]
        private IWebElement InvoiceAmtClaimLimit;

        [FindsBy(How = How.Name, Using = "INVOICE_AMOUNT_DISPLAY_ON_CLAIM_FORM")]
        private IWebElement InvoiceAmtDisplayOnForm;

        [FindsBy(How = How.Name, Using = "EMPLOYEE_ID_VALIDATE")]
        private IWebElement EmpyIdValidate;

        [FindsBy(How = How.Name, Using = "EMPLOYEE_ID_CLAIM_LIMIT")]
        private IWebElement EmpyIdClaimLimit;

        [FindsBy(How = How.Name, Using = "EMPLOYEE_ID_DISPLAY_ON_CLAIM_FORM")]
        private IWebElement EmpyIdDisplayOnForm;

        [FindsBy(How = How.Name, Using = "PENDING_DAYS_SELECTION")]
        private IWebElement PendingDaysSelection;

        [FindsBy(How = How.XPath, Using = "//label[text()='Program Sales Data']/parent::div/parent::div/following-sibling::div/descendant::input[position()=1]")]
        private IWebElement PrgSalDataNo;

        [FindsBy(How = How.XPath, Using = "//label[text()='Program Sales Data']/parent::div/parent::div/following-sibling::div/descendant::input[position()=2]")]
        private IWebElement PrgSalDataYes;

        [FindsBy(How = How.XPath, Using = "//label[text()='Claim Auto Complete']/parent::div/parent::div/following-sibling::div/descendant::input[position()=1]")]
        private IWebElement ClamAutoNo;

        [FindsBy(How = How.XPath, Using = "//label[text()='Claim Auto Complete']/parent::div/parent::div/following-sibling::div/descendant::input[position()=2]")]
        private IWebElement ClamAutoYes;

        [FindsBy(How = How.XPath, Using = "//label[text()='Allow Pending Claims']/parent::div/parent::div/following-sibling::div/descendant::input[position()=1]")]
        private IWebElement AllowPendingClaimNo;

        [FindsBy(How = How.XPath, Using = "//label[text()='Allow Pending Claims']/parent::div/parent::div/following-sibling::div/descendant::input[position()=2]")]
        private IWebElement AllowPendingClaimYes;

        [FindsBy(How = How.XPath, Using = "//label[text()='Partner Type']/parent::div/parent::div/following-sibling::div/descendant::input[position()=1]")]
        private IWebElement PartnerTypeNo;

        [FindsBy(How = How.XPath, Using = "//label[text()='Partner Type']/parent::div/parent::div/following-sibling::div/descendant::input[position()=2]")]
        private IWebElement PartnerTypeYes;

        [FindsBy(How = How.XPath, Using = "//label[text()='Job Function Claim Limit']/parent::div/parent::div/following-sibling::div/descendant::input[position()=1]")]
        private IWebElement JobFunctionNo;

        [FindsBy(How = How.XPath, Using = "//label[text()='Job Function Claim Limit']/parent::div/parent::div/following-sibling::div/descendant::input[position()=2]")]
        private IWebElement JobFunctionYes;

        [FindsBy(How = How.XPath, Using = "//label[text()='Claim Audit']/parent::div/parent::div/following-sibling::div/descendant::input[position()=1]")]
        private IWebElement ClaimAuditNo;

        [FindsBy(How = How.XPath, Using = "//label[text()='Claim Audit']/parent::div/parent::div/following-sibling::div/descendant::input[position()=2]")]
        private IWebElement ClaimAuditYes;

        [FindsBy(How = How.Name, Using = "JOB_FUNCTION_CLAIM_LIMIT_SELECTION")]
        private IWebElement JobFunctionSelection;

        [FindsBy(How = How.Name, Using = "CLAIM_AUDIT_VALUE")]
        private IWebElement CalimAuditValue;

        [FindsBy(How = How.XPath, Using = "//input[@title='Percentage']")]
        private IWebElement ClaimAuditPercentage;
        
        [FindsBy(How = How.XPath, Using = "//input[@title='Amount']")]
        private IWebElement ClaimAuditAmount;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eleValidat"></param>
        /// <param name="validate"></param>
        /// <param name="eleClainLimitation"></param>
        /// <param name="claimLimitation"></param>
        /// <param name="eleDisplayOnClaimForm"></param>
        /// <param name="displayOnclaimForm"></param>
        private void CheckValidationWithWebElement(IWebElement eleValidat,bool validate, IWebElement eleClainLimitation,bool claimLimitation, IWebElement eleDisplayOnClaimForm,bool displayOnclaimForm)
        {
            if (validate)
            {
                JavaScriptExecutorHelper.ScrollElementAndClick(eleValidat);
            }
            if (claimLimitation)
                eleClainLimitation.Click();
            if (!validate && displayOnclaimForm)
                eleDisplayOnClaimForm.Click();
        }

        private void CheckRadioValidationWebElement(IWebElement eleYes, bool yes, IWebElement eleNo)
        {
            if (yes)
            {
                JavaScriptExecutorHelper.ScrollElementAndClick(eleYes);
                GenericHelper.WaitForLoadingMask();
            }
            else
            {
                JavaScriptExecutorHelper.ScrollElementAndClick(eleNo);
                GenericHelper.WaitForLoadingMask();
            }
        }

        public void CheckValidationField(bool fName, bool lName, bool eMail, bool acCode, bool date)
        {

            if (fName)
            {
                JavaScriptExecutorHelper.ScrollElementAndClick(FirstName);
            }
            if (lName)
                Lastname.Click();
            if (eMail)
                Email.Click();
            if (acCode)
                ActivityCode.Click();
            if (date)
                Date.Click();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="claimLimitation"></param>
        /// <param name="displayOnclaimForm"></param>
        public void InvoiceNumberValidation(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            CheckValidationWithWebElement(InvoiceNoValidate, validate, InvoiceClaimLimit, claimLimitation,
                InvoiceDisplayOnForm, displayOnclaimForm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="claimLimitation"></param>
        /// <param name="displayOnclaimForm"></param>
        public void OrderNumberValidation(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            CheckValidationWithWebElement(OrderNoValidate, validate, OrderClaimLimit, claimLimitation,
                OrderDisplayOnForm, displayOnclaimForm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="claimLimitation"></param>
        /// <param name="displayOnclaimForm"></param>
        public void QuoteNumber(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            CheckValidationWithWebElement(QuoteNoValidate, validate, QuoteClaimLimit, claimLimitation,
                QuoteDisplayOnForm, displayOnclaimForm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="claimLimitation"></param>
        /// <param name="displayOnclaimForm"></param>
        public void ReferenceNumber(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            CheckValidationWithWebElement(RefernceNoValidate, validate, RefernceClaimLimit, claimLimitation,
                RefernceDisplayOnForm, displayOnclaimForm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="claimLimitation"></param>
        /// <param name="displayOnclaimForm"></param>
        public void OrderDate(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
           
            CheckValidationWithWebElement(OrderDateValidate, validate, OrdeDateClaimLimit, claimLimitation,
                OrderDateDisplayOnForm, displayOnclaimForm);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="claimLimitation"></param>
        /// <param name="displayOnclaimForm"></param>
        public void InvoiceDate(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            CheckValidationWithWebElement(InvoiceDateValidate, validate, InvoiceDateClaimLimit, claimLimitation,
                InvoiceDateDisplayOnForm, displayOnclaimForm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="claimLimitation"></param>
        /// <param name="displayOnclaimForm"></param>
        public void BillDate(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            CheckValidationWithWebElement(BillDateValidate, validate, BillDateClaimLimit, claimLimitation,
                BillDateDisplayOnForm, displayOnclaimForm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="claimLimitation"></param>
        /// <param name="displayOnclaimForm"></param>
        public void ShipDate(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            CheckValidationWithWebElement(ShipDateValidate, validate, ShipDateClaimLimit, claimLimitation,
                ShipDateDisplayOnForm, displayOnclaimForm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="claimLimitation"></param>
        /// <param name="displayOnclaimForm"></param>
        public void ProductSkuNumber(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            CheckValidationWithWebElement(ProductSkuValidate, validate, ProductSkuClaimLimit, claimLimitation,
                ProductSkuDisplayOnForm, displayOnclaimForm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="claimLimitation"></param>
        /// <param name="displayOnclaimForm"></param>
        public void ProductSerialNumber(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
       
            CheckValidationWithWebElement(ProductSerialValidate, validate, ProductSerialClaimLimit, claimLimitation,
                ProductSerialDisplayOnForm, displayOnclaimForm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="claimLimitation"></param>
        /// <param name="displayOnclaimForm"></param>
        public void ProductQty(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            CheckValidationWithWebElement(ProductQtyValidate, validate, ProductQtyClaimLimit, claimLimitation,
               ProductQtyDisplayOnForm, displayOnclaimForm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="claimLimitation"></param>
        /// <param name="displayOnclaimForm"></param>
        public void PoNumber(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            CheckValidationWithWebElement(PoNumberValidate, validate, PoNumberClaimLimit, claimLimitation,
               PoNumberDisplayOnForm, displayOnclaimForm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="claimLimitation"></param>
        /// <param name="displayOnclaimForm"></param>
        public void InvoiceAmount(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            CheckValidationWithWebElement(InvoiceAmtValidate, validate, InvoiceAmtClaimLimit, claimLimitation,
               InvoiceAmtDisplayOnForm, displayOnclaimForm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="claimLimitation"></param>
        /// <param name="displayOnclaimForm"></param>
        public void EmployeeId(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            CheckValidationWithWebElement(EmpyIdValidate, validate, EmpyIdClaimLimit, claimLimitation,
               EmpyIdDisplayOnForm, displayOnclaimForm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yes"></param>
        public void ProgramSalesData(bool yes)
        {
            CheckRadioValidationWebElement(PrgSalDataYes, yes, PrgSalDataNo);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yes"></param>
        public void ClaimAutoComplete(bool yes)
        {
            CheckRadioValidationWebElement(ClamAutoYes, yes, ClamAutoNo);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yes"></param>
        /// <param name="days"></param>
        public void AllowPendingClaims(bool yes,string days)
        {
            CheckRadioValidationWebElement(AllowPendingClaimYes, yes, AllowPendingClaimNo);
            GenericHelper.WaitForElement(PendingDaysSelection);
            DropDownHelper.SelectByVisibleText(PendingDaysSelection,days);
            GenericHelper.WaitForLoadingMask();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yes"></param>
        public void PartnerType(bool yes)
        {
            CheckRadioValidationWebElement(PartnerTypeYes, yes, PartnerTypeNo);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yes"></param>
        /// <param name="jobFunction"></param>
        public void JobFunctionClaimLimit(bool yes,string jobFunction)
        {
            CheckRadioValidationWebElement(JobFunctionYes, yes, JobFunctionNo);
            GenericHelper.WaitForElement(JobFunctionSelection);
            DropDownHelper.SelectByVisibleText(JobFunctionSelection, jobFunction);
            GenericHelper.WaitForLoadingMask();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yes"></param>
        /// <param name="calimAuditValue"></param>
        /// <param name="percentage"></param>
        public void ClaimAudit(bool yes, string calimAuditValue, bool percentage)
        {
            CheckRadioValidationWebElement(ClaimAuditYes, yes, ClaimAuditNo);
            GenericHelper.WaitForElement(CalimAuditValue);
            CalimAuditValue.SendKeys(calimAuditValue);
            GenericHelper.WaitForLoadingMask();
        }

    }
}
