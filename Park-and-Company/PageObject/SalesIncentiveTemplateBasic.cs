using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Park_and_Company.BaseClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.ComponentHelper;
using Park_and_Company.PageObject.IncentivePage;

namespace Park_and_Company.PageObject
{
    public class SalesIncentiveTemplateBasic : PageBase
    {
        private IWebDriver driver;
        private Validation val;
        public SalesIncentiveTemplateBasic(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
            val = new Validation(driver);
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Program Incentive']")]
        private IWebElement ProgramIncentive;

        [FindsBy(How = How.XPath, Using = "//button[text()='Add']")]
        private IWebElement Add;

        [FindsBy(How = How.XPath, Using = "//a[text()='Validation']")]
        private IWebElement Validation;

        [FindsBy(How = How.XPath, Using = "//div[@id='accordion']/descendant::div[@id='rendered'][position()=6]/button")]
        private IWebElement ValidationNext;

        [FindsBy(How = How.XPath, Using = "//a[text()='Finish']")]
        private IWebElement Finish;

        [FindsBy(How = How.XPath, Using = "//div[@id='accordion']/descendant::div[@id='rendered'][position()=4]/button")]
        private IWebElement ProgramIncentiveNext;

        

        public void SelectProgramName(string pName, string pDesc)
        {
            SelectProgramPage spPage = new SelectProgramPage(driver);
            spPage.SelectProgramName(pName, pDesc);
        }


        public void SelectProgramVisibilityStartDate(string day, string month,
                string year)
        {
            SelectProgramDatesPage spdPage = new SelectProgramDatesPage(driver);
            spdPage.SelectProgramVisibilityStartDate(day, month, year);
        }


        public void SelectProgramVisibilityEndDate(string day, string month,
                string year)
        {
            SelectProgramDatesPage spdPage = new SelectProgramDatesPage(driver);
            spdPage.SelectProgramVisibilityEndDate(day, month, year);

        }


        public void SelectProgramStartDate(string day, string month,
                string year)
        {
            SelectProgramDatesPage spdPage = new SelectProgramDatesPage(driver);
            spdPage.SelectProgramStartDate(day, month, year);

        }


        public void SelectProgramEndDate(string day, string month,
                string year)
        {
            SelectProgramDatesPage spdPage = new SelectProgramDatesPage(driver);
            spdPage.SelectProgramEndDate(day, month, year);

        }


        public void SelectProgramLastSubmitDate(string day, string month,
                string year)
        {
            SelectProgramDatesPage spdPage = new SelectProgramDatesPage(driver);
            spdPage.SelectProgramLastSubmitDate(day, month, year);

        }


        public void SelectProgramCloseDates(string day, string month,
                string year)
        {
            SelectProgramDatesPage spdPage = new SelectProgramDatesPage(driver);
            spdPage.SelectProgramCloseDates(day, month, year);

        }

        public void AddPoints(string maxPointAllow, string pointExpire)
        {
            ConfigureProgramPage cpPage = new ConfigureProgramPage(driver);
            cpPage.AddPoints(maxPointAllow, pointExpire);
        }


        public void AddPointType(string type, string poitAlloc)
        {
            ConfigureProgramPage cpPage = new ConfigureProgramPage(driver);
            cpPage.AddPointType(type, poitAlloc);

        }

        public void AddProdProgramIncentive(string points, string prodSku, string prdDescp, string prodFamily, string prodClass,
            string prodLine, string prodType, string unitSoldMax, string unitSoldMin)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(ProgramIncentive);
            GenericHelper.WaitForLoadingMask();
            GenericHelper.WaitForElement(Add);
            Add.Click();
            ProgramIncentive addInc = new ProgramIncentive(driver);
            addInc.AddProgramIncentive(points, prodSku, prdDescp, prodFamily, prodClass, prodLine, prodType, unitSoldMax, unitSoldMin);
            Thread.Sleep(500);
            ProgramIncentiveNext.Click();
            JavaScriptExecutorHelper.ScrollElementAndClick(ProgramIncentive);
            GenericHelper.WaitForLoadingMask();
        }

        public void AddEligibleGroup(string grpName, bool useNomination, string nominationGrpName)
        {
            EligibleGroupPage egPage = new EligibleGroupPage(driver);
            egPage.AddEligibleGroup(grpName,useNomination,nominationGrpName);

        }

        public void OpenValidationField()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(Validation);
            GenericHelper.WaitForLoadingMask();
            JavaScriptExecutorHelper.ScrollElementAndClick(ValidationNext);
            Validation.Click();
            GenericHelper.WaitForLoadingMask();
        }

        public void AddInvoiceNoValidation(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            val.InvoiceNumberValidation(validate,claimLimitation,displayOnclaimForm);
        }

        public void AddOrderNoValidation(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            val.OrderNumberValidation(validate, claimLimitation, displayOnclaimForm);
        }

        public void AddQuoteNoValidation(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            val.QuoteNumber(validate, claimLimitation, displayOnclaimForm);
        }

        public void AddRefrenceNoValidation(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            val.ReferenceNumber(validate, claimLimitation, displayOnclaimForm);
        }

        public void AddOrderDateValidation(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            val.OrderDate(validate, claimLimitation, displayOnclaimForm);
        }

        public void AddInvoiceDateValidation(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            val.InvoiceDate(validate, claimLimitation, displayOnclaimForm);
        }

        public void AddBillDateValidation(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            val.BillDate(validate, claimLimitation, displayOnclaimForm);
        }

        public void AddShipDateValidation(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            val.ShipDate(validate, claimLimitation, displayOnclaimForm);
        }

        public void AddProductSkuNoValidation(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            val.ProductSkuNumber(validate, claimLimitation, displayOnclaimForm);
        }
        public void AddProductSerialNoValidation(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            val.ProductSerialNumber(validate, claimLimitation, displayOnclaimForm);
        }

        public void AddProductQtyValidation(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            val.ProductQty(validate, claimLimitation, displayOnclaimForm);
        }

        public void AddPoNumberValidation(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            val.PoNumber(validate, claimLimitation, displayOnclaimForm);
        }

        public void AddInvoiceAmtValidation(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            val.InvoiceAmount(validate, claimLimitation, displayOnclaimForm);
        }

        public void AddEmployeeIdValidation(bool validate, bool claimLimitation, bool displayOnclaimForm)
        {
            val.EmployeeId(validate, claimLimitation, displayOnclaimForm);
        }

        //TODO for  other validations RSR

        public void CloseValidationField()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(ValidationNext);
            Validation.Click();
            GenericHelper.WaitForLoadingMask();
        }

    }
}
