using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Park_and_Company.BaseClasses.LoginBaseClass;
using Park_and_Company.ExtensionClass.LoggerExtClass;

namespace Park_and_Company.TestCases.CheckScreens.Module.Program.ManualPointAdjustment
{
    [TestClass]
    public class TestPointAdjustment : LoginBase
    {
        [TestMethod]
        public void TestPointAdjustmentScr()
        {
            try
            {
                var pAdjPage = HPage.NavigateToManualPointAdjustment();
                pAdjPage.SelectPointAndProgram("Visa", "Test Activity"); // Provide unique Point Type and Programe Name
                pAdjPage.SelectPointTypInGrid(Properties.Settings.Default.ManualPointAdjustmentGrid, 1, 1);
                pAdjPage.ClickPointAdjTakeScrShot($"ManualPointAdjustment-{DateTime.UtcNow.ToString("hh-mm-ss")}");
                pAdjPage.Logout();
            }
            catch (Exception exception)
            {
                Logger.LogException(exception);
                throw;
            }
           
        }
    }
}
