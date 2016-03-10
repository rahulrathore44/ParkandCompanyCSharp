using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;
using Park_and_Company.Settings;

namespace Park_and_Company.PageObject.Learn.Library
{
    public class LibraryViewPage : PageBase
    {

        #region Field

        private IWebDriver _driver;

        #endregion

        #region Constructor

        public LibraryViewPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }


        #endregion

        #region WebElements

        public void SelectViewBy(string value)
        {
            DropDownHelper.SelectFromKendoDropDown(By.XPath(LocatorRepository.SelectButtonXpath), value);
            GenericHelper.WaitForLoadingMask();
        }
         

        #endregion
    }
}
