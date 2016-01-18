using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Park_and_Company.BaseClasses.LoginBaseClass;
using Park_and_Company.PageObject;
using Park_and_Company.Settings;

namespace Park_and_Company.TestCases.Shop
{
    [TestClass]
    public class TestRewardPoints : LoginBase
    {

        [TestMethod]
        public void TestRPoints()
        {
            var cPage = hPage.NavigateToCardStore();
            var vPage = cPage.ClickOpenPrePaid();
            var detailPage = vPage.ClickSelectButton(1);
            detailPage.SetPointAmount("10");
            detailPage.SetQuantity("5");
            detailPage.ClickAddToBasket();
            vPage.Logout();
        }
    }
}
