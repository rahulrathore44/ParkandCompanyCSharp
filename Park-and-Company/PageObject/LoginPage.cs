using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
