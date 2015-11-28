using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Park_and_Company.ComponentHelper;
using Park_and_Company.PageObject;
using Park_and_Company.Settings;

namespace Park_and_Company.TestCases.Module.Claims
{
    [TestClass]
    public class TestClaims
    {
        [TestMethod]
        public void TestNewClaim()
        {
            var lpage = new LoginPage(ObjectRepository.Driver);
            var hPage = lpage.LoginApplication(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            var clPage = hPage.OpeNewClaimPage();
            clPage.SelectNewClaim("Test expire");
            clPage.InsertNumber("10","10","11","12"); // pass null if field is not at page
            clPage.SelectOrderDate("10", "April", "2014"); // Do not call if field is not at page
            clPage.SelectBillDate("11", "April", "2015"); // Do not call if field is not at page
            clPage.SelectShipDate("12", "April", "2015"); // Do not call if field is not at page
            clPage.SelectInvoiceDate("11", "April","2015"); // Do not call if field is not at page
            clPage.InsertEmpPoInvoiceNo("1", "1", "122"); // pass null if field is not at page
            clPage.EnterProductDetails("SKU1", "1","1");
            GridHelper.VerifyInGridEntry(Properties.Settings.Default.ClaimDataGrid, "SKU1", 1,1); // verify in gird Similarly for other column
           // clPage.ClickVerifyBtnInGrid(Properties.Settings.Default.ClaimDataGrid,1,7); // for Verify button in grid
            //clPage.ClickDeleteBtnInGrid(Properties.Settings.Default.ClaimDataGrid,1,8); // for delete button in grid
            //clPage.VerifyEstimatedTotalPts("100"); // for verifying the total esmt points
            var claimNo = clPage.SubmitClaim(); // will give u the claim no
            Console.WriteLine($"Claim No is : {claimNo}");
            clPage.Logout();
        }
    }
}
