using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Park_and_Company.ComponentHelper;

namespace Park_and_Company.PageObject.Configuration.StoreMaintenance.Catlog
{
    public class StoreMarkups : TabPanel
    {
        #region Constructor

        public StoreMarkups(IWebDriver driver) : base(driver)
        {
        }

        #endregion

        #region WebElement

        


        #endregion

        #region Public

        public void ValidateElements()
        {
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("Previous")));
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("Cancel")));
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("Save")));
        }

        #endregion
    }
}
