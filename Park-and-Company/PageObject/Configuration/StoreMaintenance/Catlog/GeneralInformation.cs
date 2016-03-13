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
using Park_and_Company.ExtensionClass.WebElementExtClass;
using Park_and_Company.Settings;

namespace Park_and_Company.PageObject.Configuration.StoreMaintenance.Catlog
{
    public class GeneralInformation : TabPanel
    {
       

        #region Constructor

        public GeneralInformation(IWebDriver driver) : base(driver)
        {
        }

        #endregion

        #region WebElement

        [FindsBy(How = How.Id, Using = "StoreNameInput")]
        public IWebElement StoreNameInput;

        [FindsBy(How = How.XPath, Using = "//input[@id='pointMonetaryValue']/preceding-sibling::input[1]")]
        public IWebElement PointMonetaryValue;

        [FindsBy(How = How.Id, Using = "pointMonetaryValue")]
        public IWebElement PointMonetaryValueTextBox;

        #endregion

        #region Public

        public void SelectCustomer(string cust)
        {
            DropDownHelper.SelectFromDropDownWithLabel("Customer", cust);
            GenericHelper.WaitForLoadingMask();
        }

        public void SelectStatus(string status)
        {
            DropDownHelper.SelectFromDropDownWithLabel("Status", status);
            GenericHelper.WaitForLoadingMask();
        }

        public void SelectPointType(string type)
        {
            DropDownHelper.SelectFromDropDownWithLabel("Point Type", type);
            GenericHelper.WaitForLoadingMask();
        }

        public void SelectLanguage(string language)
        {
            DropDownHelper.SelectFromDropDownWithLabel("Language", language);
            GenericHelper.WaitForLoadingMask();
        }

        public void SetPointMonetaryValue(string value)
        {
            PointMonetaryValue.ScrollElementAndClick();
            Thread.Sleep(200);
            PointMonetaryValueTextBox.SendKeys(value);
        }

        public void ValidateElement()
        {
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("StoreNameInput")));
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("PointMonetaryValue")));
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("Next")));
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("Cancel")));
        }
        #endregion

    }
}
