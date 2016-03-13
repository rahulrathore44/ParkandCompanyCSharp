using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.ComponentHelper;
using Park_and_Company.Settings;

namespace Park_and_Company.PageObject.Configuration.StoreMaintenance.Catlog
{
    public class StoreInventory : TabPanel
    {
        #region Constructor

        public StoreInventory(IWebDriver driver) : base(driver)
        {
        }

        #endregion

        #region Internal

        #endregion

        #region WebElement

        [FindsBy(How = How.XPath, Using = "//span[text()='Multi-Merchant']/preceding-sibling::span[1]//input[@type='checkbox']")]
        public IWebElement MultiMerchantChk;

        [FindsBy(How = How.XPath, Using = "//span[text()='Open Prepaid']/preceding-sibling::span[1]//input[@type='checkbox']")]
        public IWebElement OpenPrepaidChk;

        [FindsBy(How = How.XPath, Using = "//span[text()='Single Merchant']/preceding-sibling::span[1]//input[@type='checkbox']")]
        public IWebElement SingleMerchantChk;

        #endregion

        #region Public

        public void SelectLanguage(string language)
        {
            DropDownHelper.SelectFromKendoDropDown(LocatorRepository.SelectKendoDropDownXpath,language);
        }

        #endregion
    }
}
