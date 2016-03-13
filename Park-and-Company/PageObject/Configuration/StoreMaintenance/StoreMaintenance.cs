using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;
using Park_and_Company.ExtensionClass.WebElementExtClass;
using Park_and_Company.PageObject.Configuration.StoreMaintenance.Catlog;

namespace Park_and_Company.PageObject.Configuration.StoreMaintenance
{
    public class StoreMaintenance : PageBase
    {
       #region Constructor

        public StoreMaintenance(IWebDriver driver) : base(driver)
        {
        }

        #endregion

        #region WebElements

        [FindsBy(How = How.Id, Using = "resetButton")]
        public IWebElement ResetButton;

        [FindsBy(How = How.Id, Using = "updateButton")]
        public IWebElement UpdateButton;

        [FindsBy(How = How.Id, Using = "addButton")]
        public IWebElement AddButton;

        #endregion

        #region Public

        public GeneralInformation ClickAddButton()
        {
            AddButton.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
            return new GeneralInformation(Driver);
        }

        #endregion

    }
}
