using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Park_and_Company.BaseClasses.LoginBaseClass;
using Park_and_Company.ComponentHelper;
using Park_and_Company.ExtensionClass.ScreenShotExtClass;
using Park_and_Company.PageObject.Shop.Orders;

namespace Park_and_Company.TestCases.Shop
{
    [TestClass]
    public class TestMyOrders : LoginBase
    {
        [TestMethod]
        public void TestMethodMyOrders()
        {
            var cPage = hPage.NavigateToOrders();
            DropDownHelper.SelectItemPerList("100"); // used to select the 100 item in the grid
            cPage.ClickViewInGrid(2,7); // supply the row and column to clcik on view button of the order
            cPage.VerifyOrderNumber("Order Number: 215"); // should specify in this format "Order Number: 215", "Order Number: 216", "Order Number: 210" so on.
            cPage.VerifyOrderDate("Order Date: Jan 20, 2016"); // should specify in this format "Order Date: Jan 20, 2016", "Order Date: Jan 21, 2016", "Order Date: Jan 20, 2017" so on.
            cPage.CaptureScreenShot(); // will take the screen shot
            cPage.Logout();
        }
    }
}
