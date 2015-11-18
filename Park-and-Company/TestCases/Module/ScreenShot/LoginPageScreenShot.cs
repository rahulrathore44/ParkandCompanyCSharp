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
    public class LoginPageScreenShot
    {
        [TestMethod]
        public void LoginScrShot()
        {
            var lpage = new LoginPage(ObjectRepository.Driver);
            lpage.ScreenShotofForgotPassword("Forgot Username");
            lpage.ScreenShotofForgotUserName("Forgot Password");
            lpage.ScreenShotofOpenReg("Open Register");
        }
    }
}
