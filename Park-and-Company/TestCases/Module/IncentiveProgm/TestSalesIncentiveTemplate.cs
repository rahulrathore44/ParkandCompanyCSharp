using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Park_and_Company.BaseClasses;
using Park_and_Company.PageObject;
using Park_and_Company.Settings;

namespace Park_and_Company.TestCases.Module.IncentiveProgm
{
    [TestClass]
    public class TestSalesIncentiveTemplate : BaseClass
    {
        public void TestSalesIncentiveTemp()
        {
            LoginPage lpage = new LoginPage(ObjectRepository.Driver);
            HomePage hPage = lpage.LoginApplication(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            ManageIncentivePrograms mIPage = hPage.OpenManageIncentivePrograms();
            NewProgram npPage = mIPage.ClickNewProgram();
            SalesIncentiveTemplateBasic sitPage = npPage.CreateSalesIncentiveTemplate();
        }
    }
}
