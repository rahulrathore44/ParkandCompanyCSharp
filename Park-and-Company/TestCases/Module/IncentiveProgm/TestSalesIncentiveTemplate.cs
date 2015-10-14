using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }
    }
}
