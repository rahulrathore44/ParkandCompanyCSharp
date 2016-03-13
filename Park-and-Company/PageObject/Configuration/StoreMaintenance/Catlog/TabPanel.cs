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

namespace Park_and_Company.PageObject.Configuration.StoreMaintenance.Catlog
{
    public abstract class TabPanel : PageBase
    {
        #region Constructor


        protected TabPanel(IWebDriver driver) : base(driver)
        {
        }

        #endregion

        #region WebElement

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'General Information')]")]
        public IWebElement GeneralInformationTab;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Configuration')]")]
        public IWebElement ConfigurationTab;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Inventory')]")]
        public IWebElement InventoryTab;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Markups')]")]
        public IWebElement MarkupsTab;

        [FindsBy(How = How.XPath, Using = "//button[text()='Cancel']")]
        public IWebElement Cancel;

        [FindsBy(How = How.XPath, Using = "//button[text()='Next']")]
        public IWebElement Next;

        [FindsBy(How = How.XPath, Using = "//button[text()='Previous']")]
        public IWebElement Previous;

        [FindsBy(How = How.XPath, Using = "//button[text()='Save']")]
        public IWebElement Save;

        #endregion

        #region Public

        public TabPanel ClickNext(Type classType)
        {
            Next.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
            return GetTypeObjet(classType.Name);
        }

        public TabPanel ClickPrevious(Type classType)
        {
            Previous.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
            return GetTypeObjet(classType.Name);
        }

        public StoreMaintenance ClickCancel()
        {
            Cancel.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
            return new StoreMaintenance(Driver);
        }

        private TabPanel GetTypeObjet(string name)
        {
            if(name.Equals("GeneralInformation"))
                return new GeneralInformation(Driver);

            if(name.Equals("ConfigurationSettings"))
                return new ConfigurationSettings(Driver);

            if (name.Equals("StoreInventory"))
                return new StoreInventory(Driver);

            return (name.Equals("StoreMarkups")) ? 
                new StoreMarkups(Driver) : null;
        }

        #endregion
    }
}
