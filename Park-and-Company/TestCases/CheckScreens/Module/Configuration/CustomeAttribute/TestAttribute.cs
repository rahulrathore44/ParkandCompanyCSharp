using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Park_and_Company.BaseClasses.LoginBaseClass;
using Park_and_Company.ComponentHelper;

namespace Park_and_Company.TestCases.CheckScreens.Module.Configuration.CustomeAttribute
{
    [TestClass]
    public class TestAttribute : LoginBase
    {
        [TestMethod]
        public void TestCustomeAttribute()
        {
            var caPage = hPage.NavigateToCustomeAttribute();
            caPage.ClickOnCustomeAttribute();
            GenericHelper.TakeSceenShot($"CustomeAttribute-{DateTime.UtcNow.ToString("hh-mm-ss")}");
            caPage.ClickOnUserAttribute();
            GenericHelper.TakeSceenShot($"UserAttribute-{DateTime.UtcNow.ToString("hh-mm-ss")}");
            caPage.ClickOnPartnerAttribute();
            GenericHelper.TakeSceenShot($"PartnerAttribute-{DateTime.UtcNow.ToString("hh-mm-ss")}");
            caPage.Logout();
        }

        [TestMethod]
        public void TestNewAttributeScrShot()
        {
            var caPage = hPage.NavigateToCustomeAttribute();
            caPage.ClickOnCustomeAttribute();
            caPage.ClickOnNewAndTakeScrShot($"NewAttribute-{DateTime.UtcNow.ToString("hh-mm-ss")}");
            caPage.Logout();
        }

        [TestMethod]
        public void TestEditAttributeScrShot()
        {
            var caPage = hPage.NavigateToCustomeAttribute();
            caPage.ClickOnCustomeAttribute();
            caPage.ClickEditAndTakeScrShot(Properties.Settings.Default.CustomAttGrid,1,1, $"EditAttribute-{DateTime.UtcNow.ToString("hh-mm-ss")}");
            caPage.Logout();
        }
    }
}
