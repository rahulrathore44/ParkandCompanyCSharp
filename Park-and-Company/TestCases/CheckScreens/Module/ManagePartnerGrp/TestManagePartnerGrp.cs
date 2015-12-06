using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Park_and_Company.BaseClasses.LoginBaseClass;
using Park_and_Company.ComponentHelper;

namespace Park_and_Company.TestCases.CheckScreens.Module.ManagePartnerGrp
{
    [TestClass]
    public class TestManagePartnerGrp : LoginBase
    {
        [TestMethod]
        public void TestManagePartnerGrpScr()
        {
            var partPage = hPage.ClickManagePartnerGrp();
            partPage.ClickOnUserGrp(Properties.Settings.Default.PartenrGrpGrid,"test",1,2);
            GenericHelper.TakeSceenShot("Partner Static Grp");
            partPage.NavigateToHome();
            partPage = hPage.ClickManagePartnerGrp();
            partPage.ClickOnUserGrp(Properties.Settings.Default.PartenrGrpGrid, "test1", 2, 2);
            GenericHelper.TakeSceenShot("Partner Smart Grp");
            partPage.Logout();

        }

        [TestMethod]
        public void TestCreateAnCancelScrShot()
        {
            var partPage = hPage.ClickManagePartnerGrp();
            partPage.ClickCreateAndTakeSrcShot("Create Partner Grp");
            partPage.Logout();
        }

        [TestMethod]
        public void TestCreateGrpOfGrpAndCancel()
        {
            var partPage = hPage.ClickManagePartnerGrp();
            partPage.SelectGroup(Properties.Settings.Default.PartenrGrpGrid, 1, 1);
            partPage.SelectGroup(Properties.Settings.Default.PartenrGrpGrid, 2, 1);
            partPage.CreateGrpOfGrpAndCancel("Partner Grp of Grp Screen Shot");
            partPage.Logout();
        }

    }
}
