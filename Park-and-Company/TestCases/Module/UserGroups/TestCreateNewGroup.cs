using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Park_and_Company.PageObject;
using Park_and_Company.Settings;

namespace Park_and_Company.TestCases.Module.UserGroups
{
    [TestClass]
    public class TestCreateNewGroup
    {
        [TestMethod]
        public void TestCreateGroup()
        {
            // Modify the grp name,row,column accordingly
            LoginPage lpage = new LoginPage(ObjectRepository.Driver);
            HomePage hPage = lpage.LoginApplication(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            var mUiPage = hPage.OpenManageUserGroups();
            string name = "Test" + DateTime.UtcNow;
            mUiPage.CreateGroup(name, true);
            mUiPage.VerifyCreateGroup(Properties.Settings.Default.UserGroupGrid, "StaticStage1",1,3);
            mUiPage.ClickOnUserGrp(Properties.Settings.Default.UserGroupGrid, "StaticStage1", 1,3);
            mUiPage.AddToGroup(Properties.Settings.Default.AllUserGrid,1,1);
            mUiPage.DeleteFrmGroup("//div[@id='GroupUsersGrid']", 1, 1);
            mUiPage.ClickSave();
            mUiPage.Logout();
            Thread.Sleep(5000);
        }
    }
}
