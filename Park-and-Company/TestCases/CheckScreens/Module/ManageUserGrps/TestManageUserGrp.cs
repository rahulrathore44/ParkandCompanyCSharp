using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Park_and_Company.BaseClasses.LoginBaseClass;
using Park_and_Company.ComponentHelper;
using Park_and_Company.PageObject;
using Park_and_Company.Settings;

namespace Park_and_Company.TestCases.CheckScreens.Module.ManageUserGrps
{
    [TestClass]
    public class TestManageUserGrp : LoginBase
    {
        [TestMethod]
        public void TestManageUserGrpScreen()
        {
            var mPage = HPage.OpenManageUserGroups();
            mPage.ClickOnUserGrp(Properties.Settings.Default.UserGroupGrid, "test group", 1,2);
            GenericHelper.TakeSceenShot("Static User Grp");
            mPage.NavigateToHome();
            HPage.OpenManageUserGroups();
            mPage.ClickOnUserGrp(Properties.Settings.Default.UserGroupGrid, "Test11/11/2015 5:34:13 PM", 2, 2);
            GenericHelper.TakeSceenShot("Smart User Grp");
            mPage.Logout();
        }

        [TestMethod]
        public void TestClickCreateAndCancel()
        {
            var mPage = HPage.OpenManageUserGroups();
            mPage.ClickCreateAndCancel("Create Group");
            mPage.Logout();
        }

        [TestMethod]
        public void TestCreateGrpOfGrpAndCancel()
        {
            var mPage = HPage.OpenManageUserGroups();
            mPage.SelectGroup(Properties.Settings.Default.UserGroupGrid, 1, 1);
            mPage.SelectGroup(Properties.Settings.Default.UserGroupGrid, 2, 1);
            mPage.CreateGrpOfGrpAndCancel("Grp of Grp Screen Shot");
            mPage.Logout();
        }
    }
}
