using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Park_and_Company.BaseClasses.LoginBaseClass;
using Park_and_Company.ComponentHelper;
using Park_and_Company.PageObject.IncentivePage;

namespace Park_and_Company.TestCases.CheckScreens.Module.Program.ManageIncentivePrograms
{
    [TestClass]
    public class TestManageIncentivePrograms : LoginBase
    {
        [TestMethod]
        public void TestManageIncentiveProgramsScr()
        {
            var pAdjPage = hPage.OpenManageIncentivePrograms();
            pAdjPage.SelectItemPerList("100");
            pAdjPage.ClickElemetInGrid(Properties.Settings.Default.ManageIncentiveProgramsGrid,20,1);
            pAdjPage.SelectProgramNameClickNext();
            pAdjPage.SelectProgramDatesClickNext();
            pAdjPage.SelectConfigurePrgsClickNext();
            pAdjPage.SelectProgramIncetiveClickNext();
            pAdjPage.SelectEligibelGrpClickNext();
            pAdjPage.SelectValidationClickNext();
            pAdjPage.SelectBundelSetupClickNext();
            pAdjPage.SelectOverlaySetupClickNext();
            ButtonHelper.ClickButton(By.XPath("//button[text()='Finish']"));
            GenericHelper.WaitForLoadingMask();
            pAdjPage.Logout();
        }
    }
}
