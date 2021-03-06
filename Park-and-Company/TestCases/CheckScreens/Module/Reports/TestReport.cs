﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Park_and_Company.BaseClasses.LoginBaseClass;
using Park_and_Company.ExtensionClass.ScreenShotExtClass;

namespace Park_and_Company.TestCases.CheckScreens.Module.Reports
{
    [TestClass]
    public class TestReport : LoginBase
    {
        [TestMethod]
        public void TestReportPage()
        {
            HPage.ValidateElements();
            var rPage = HPage.NavigateToReportsPage();
            rPage.CaptureScreenShot("Check");
            rPage.PartnerDetailReportScrShot($"PartnerDetailReport-{DateTime.UtcNow.ToString("hh-mm-ss")}");
            rPage.PointBalanceDetailReportScrShot($"PointBalanceDetailReport-{DateTime.UtcNow.ToString("hh-mm-ss")}");
            rPage.IncentiveClaimDetailReportScrShot($"IncentiveClaimDetailReport-{DateTime.UtcNow.ToString("hh-mm-ss")}");
            rPage.UserDetailReportScrShot($"UserDetailReport-{DateTime.UtcNow.ToString("hh-mm-ss")}");
            rPage.IncentivePerformanceSummaryScrShot($"IncentivePerformanceSummary-{DateTime.UtcNow.ToString("hh-mm-ss")}");
            rPage.Logout();
        }
    }
}
