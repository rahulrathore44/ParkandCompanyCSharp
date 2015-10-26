using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Park_and_Company.PageObject;
using Park_and_Company.Settings;

namespace Park_and_Company.TestCases.Module.UserGroups
{
    [TestClass]
    public class TestGroupofGroups
    {
        [TestMethod]
        public void TestGroup()
        {
            // Modify the grp name,row,column accordingly
            var grpName = "Grp-" + DateTime.UtcNow.ToString("yy-MM-dd-HH-mm");
            var lpage = new LoginPage(ObjectRepository.Driver);
            var hPage = lpage.LoginApplication(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            var mUiPage = hPage.OpenManageUserGroups();
            mUiPage.SelectGroup("//div[@id='UserGroupsGrid']", 1, 1);
            mUiPage.SelectGroup("//div[@id='UserGroupsGrid']", 2, 1);
            mUiPage.CreateGrpOfGroup(grpName,grpName);
            mUiPage.Logout();
        }

    }
}
