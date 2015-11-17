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
    public class TestActivityIncentiveTemplate : BaseClass
    {
        [TestMethod]
        public void TestActivityIncentiveTemp()
        {
            LoginPage lpage = new LoginPage(ObjectRepository.Driver);
            HomePage hPage = lpage.LoginApplication(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            hPage.ClickOnLink();
            ManageIncentivePrograms mIPage = hPage.OpenManageIncentivePrograms();
            NewProgram npPage = mIPage.ClickNewProgram();
            ActivityIncentiveTemplate aiPage =  npPage.CreateActivityIncentiveTemplate();
            aiPage.SelectProgramName("Test", "Test");
            aiPage.SelectProgramVisibilityStartDate("28", "October", "2015");
            aiPage.SelectProgramVisibilityEndDate("01", "October", "2002");
            aiPage.SelectProgramStartDate("26", "April", "2002");
            aiPage.SelectProgramEndDate("30", "November", "2015");
            aiPage.SelectProgramLastSubmitDate("01", "December", "2015");
            aiPage.SelectProgramCloseDates("31", "December", "2015");
            aiPage.AddPoints("1001", "22", "Hello1");
            aiPage.AddPointType("test", "100");
            aiPage.AddProgramIncentive("CODE1", "TPE1", "TesTing", "100");
            aiPage.AddEligibleGroup("test");
            aiPage.CheckValidationField(true, false, true, false, false);
            aiPage.ClickFinish();
            mIPage.SelectItemPerList("100");
            mIPage.VerifyIncentiveGridEntry("//div[@id='ManageIncentiveProgramsGrid']/div/div[position()=3]", "Test", "24/04/2002","01/10/2002","Pending");
            Thread.Sleep(1000);
            Logout();
        }
    }
}
