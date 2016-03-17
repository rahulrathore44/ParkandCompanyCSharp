using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Park_and_Company.BaseClasses.LoginBaseClass;
using Park_and_Company.ExtensionClass.ScreenShotExtClass;

namespace Park_and_Company.TestCases.CheckScreens.Module.Program.ManageCalims
{
    [TestClass]
    public class TestManageCalims : LoginBase
    {
        [TestMethod]
        public void TestManageCalimsScr()
        {
            var mclaimPage = HPage.OpeManageCalimsPage();
            mclaimPage.SelectProgram("Test expire");
            mclaimPage.CaptureScreenShot($"ProgramName-{DateTime.UtcNow.ToString("hh-mm-ss")}");
            mclaimPage.ClickViewInGrid(Properties.Settings.Default.ManualApprovalGrid,1);
            mclaimPage.ValidateAllElements(); // Method for validation
            mclaimPage.CaptureScreenShot($"ProgramNameView-{DateTime.UtcNow.ToString("hh-mm-ss")}");
            mclaimPage.ClickAddProductAndTakeScrShot($"AddEditProduct-{ DateTime.UtcNow.ToString("hh-mm-ss")}");
            mclaimPage.Logout();
        }

    }
}
