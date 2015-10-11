using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;

namespace Park_and_Company.PageObject.IncentivePage
{
    public class Validation : PageBase
    {
        public Validation(IWebDriver _driver) : base(_driver)
        {
        }

        [FindsBy(How = How.Name,Using = "FIRST_NAME")]
        private IWebElement FirstName;

        [FindsBy(How = How.Name,Using = "LAST_NAME")]
        private IWebElement Lastname;

        [FindsBy(How = How.Name,Using = "EMAIL")]
        private IWebElement Email;

        [FindsBy(How = How.Name,Using = "ACTIVITY_CODE")]
        private IWebElement ActivityCode;

        [FindsBy(How = How.Name,Using = "DATE")]
        private IWebElement Date;

        public void CheckValidationField(bool fName, bool lName, bool eMail, bool acCode, bool date)
        {

            if (fName)
                FirstName.Click();
            if (lName)
                Lastname.Click();
            if (eMail)
                Email.Click();
            if (acCode)
                ActivityCode.Click();
            if (date)
                Date.Click();
        }

    }
}
