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
            LoginPage lpage = new LoginPage(ObjectRepository.Driver);
            HomePage hPage = lpage.LoginApplication(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            var mUIPage = hPage.OpenManageUserGroups();
            mUIPage.CreateGroup("grpName",true);
            Thread.Sleep(5000);
        }
    }
}
