using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Park_and_Company.PageObject;
using Park_and_Company.Settings;

namespace Park_and_Company.TestCases.Module.ScreenShot
{
    [TestClass]
    public class ProgramPageScreenShot
    {
        [TestMethod]
        public void ProgramPageSrcShot()
        {
            var lpage = new LoginPage(ObjectRepository.Driver);
            var hPage = lpage.LoginApplication(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            hPage.TakeHomePageScrShot("Home Page");
            hPage.TakeManageIncentScrShot("Manage Incentive Page");
            hPage.TakeManageClaimsScrShot("Manage Claims");
            hPage.TakeManualPointAdjScrShot("Manual Point Adjustment");
            hPage.TakeManageUserGrpScrShot("Manage User Groups");
            hPage.TakeManageUserScrShot("Manage Users");
            hPage.Logout();
        }

        [TestMethod]
        public void PartnerPageSrcShot()
        {
            var lpage = new LoginPage(ObjectRepository.Driver);
            var hPage = lpage.LoginApplication(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            hPage.TakeManagePartnerScrShot("Manage Partner");
            hPage.TakePatnerGrpScrShot("Partner Groups");
            hPage.TakeFileLoaderScrShot("File Loader");
            hPage.TakeFileStatusScrShot("File Status");
            hPage.TakeManageNotificationScrShot("Manage Notification Template");
            hPage.TakeManageNotiTriggerScrShot("Manage Notification Trigger");
            hPage.TakeManageSchedMsgScrShot("Manage Schedule Message");
            hPage.TakeEmailAnalyticsScrShot("Email Analytics");
            hPage.TakeReportsScrShot("Reports");
            hPage.Logout();
        }

        [TestMethod]
        public void ConfigurationPageSrcShot()
        {
            var lpage = new LoginPage(ObjectRepository.Driver);
            var hPage = lpage.LoginApplication(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            hPage.TakeManageRolesScrShot("Manage Roles");
            hPage.TakeCustomeProfScrShot("Custome Profile");
            hPage.TakeCustomeAttributeScrShot("Custome Attribute");
            hPage.TakeManageCustomerContentScrShot("Manage Customer Content");
            hPage.Logout();
        }
    }
}
