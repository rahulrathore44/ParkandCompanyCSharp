using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;
using Park_and_Company.Settings;

namespace Park_and_Company.PageObject
{
    public class LoginPage : PageBase
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.Id,Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement login;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Forgot Username')]")]
        private IWebElement ForgotUser;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Forgot Password')]")]
        private IWebElement ForgotPass;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Open Register')]")]
        private IWebElement OpenReg;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Cancel')]")]
        private IWebElement Cancel;

        private void ScreenShotofForgotLink(IWebElement element,string name)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(element);
            GenericHelper.WaitForElement(Cancel);
            GenericHelper.TakeSceenShot(name);
            JavaScriptExecutorHelper.ScrollElementAndClick(Cancel);
            Thread.Sleep(200);
        }

        public HomePage LoginApplication(string urname, string pass)
        {
            Logout();
            Assert.IsTrue(GenericHelper.IsElementPresent(By.XPath("//div[@class='loginWrapper']")), ErrorMessage.PageLoadErrMsg + "Login");

            username.SendKeys(urname);
            password.SendKeys(pass);
            login.Click();
            GenericHelper.WaitForElement(By.CssSelector(".homeProgramsNav"));

            Assert.IsTrue(GenericHelper.IsElementPresent(By.CssSelector(".homeProgramsNav")), ErrorMessage.PageLoadErrMsg + "Home Page");
            return new HomePage(driver);
        }

        public void ScreenShotofForgotUserName(string name)
        {
            ScreenShotofForgotLink(ForgotUser, name);
        }

        public void ScreenShotofForgotPassword(string name)
        {
            ScreenShotofForgotLink(ForgotPass, name);
        }

        public void ScreenShotofOpenReg(string name)
        {
            TakeScreenShotofPage(OpenReg,name);
        }
    }
}
