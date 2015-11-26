using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Park_and_Company.BaseClasses;
using Park_and_Company.PageObject;
using Park_and_Company.Settings;

namespace Park_and_Company.TestCases.Module.IncentiveProgm
{
    [TestClass]
    public class TestSalesIncentiveTemplate : BaseClass
    {
        //Should be called in sequence

        [TestMethod]
        public void TestSalesIncentiveTemp()
        {
            LoginPage lpage = new LoginPage(ObjectRepository.Driver);
            HomePage hPage = lpage.LoginApplication(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            ManageIncentivePrograms mIPage = hPage.OpenManageIncentivePrograms();
            NewProgram npPage = mIPage.ClickNewProgram();
            SalesIncentiveTemplateBasic sitPage = npPage.CreateSalesIncentiveTemplate();
            sitPage.SelectProgramName("Test", "Test");
            sitPage.SelectProgramVisibilityStartDate("05", "April", "2002");
            sitPage.SelectProgramVisibilityEndDate("01", "October", "2002");
            sitPage.SelectProgramStartDate("26", "April", "2002");
            sitPage.SelectProgramEndDate("30", "November", "2015");
            sitPage.SelectProgramLastSubmitDate("01", "December", "2015");
            sitPage.SelectProgramCloseDates("31", "December", "2015");
            sitPage.AddPoints("1001", "22"); 
            sitPage.AddPointType("test", "100");
            sitPage.AddProdProgramIncentive("10","prodSku","ProdDesc","PordFamily","ProdClass","ProdLine","ProdType","unitSoldMAx","unitSoldMin");
            sitPage.AddEligibleGroup("test",true,"test");
            sitPage.OpenValidationField();
            sitPage.AddInvoiceNoValidation(true,true,true);
            // Similarly for other validation
            sitPage.AddClaimAuditValidation(true,"100",true);
            Thread.Sleep(4000);

        }
    }
}
