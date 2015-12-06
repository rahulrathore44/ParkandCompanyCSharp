using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Park_and_Company.ComponentHelper;
using Park_and_Company.PageObject;
using Park_and_Company.Settings;

namespace Park_and_Company.TestCases.CheckScreens.Module.ManageRoles
{
    [TestClass]
    public class TestManageRoles
    {
        [TestMethod]
        public void TestManageRolesScreen()
        {
            var lpage = new LoginPage(ObjectRepository.Driver);
            var hPage = lpage.LoginApplication(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            var mPage = hPage.ClickManageRoles();
            var rdetailPage = mPage.ClickOnRoleName(Properties.Settings.Default.ManageRolesGrid, 1, 3); // Provide the row and column based on the role name to click
            rdetailPage.ClickSaveWithScreenShot("Roles Details 1");
            GenericHelper.WaitForElement(By.XPath(Properties.Settings.Default.ManageRolesGrid));
            rdetailPage = mPage.ClickOnRoleName(Properties.Settings.Default.ManageRolesGrid, 2, 3); // Provide the row and column based on the role name to click
            rdetailPage.ClickSaveWithScreenShot("Roles Details 2");
            rdetailPage.Logout();
        }
    }
}
