using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.ComponentHelper;
using Park_and_Company.ExtensionClass.WebElementExtClass;

namespace Park_and_Company.PageObject.Shop.Category.OpenPrePaid
{
    public class HomeShippingAddress : CardStores
    {
        private IWebDriver _driver;

        public HomeShippingAddress(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #region WebElement

        [FindsBy(How = How.XPath,Using = "//button[contains(.,'ADD NEW ADDRESS')]")]
        public IWebElement AddNewAddress;

        [FindsBy(How = How.Id, Using = "sameAsProfileInput")]
        public IWebElement ProfileChkBox;

        [FindsBy(How = How.Id, Using = "saveButton")]
        public IWebElement AddBtn;

        [FindsBy(How = How.XPath, Using = "//button[contains(.,'Ignore')]")]
        public IWebElement Ignore;

        #endregion

        #region Private

        private string GetAddressXpath(int index)
        {
            return
                "//h1[contains(.,'Home Shipping Address Book')]/following-sibling::div/div[" + index + "]/descendant::button[text()='USE THIS ADDRESS']";
        }

        #endregion

        #region Public

        public void AddExisitngAddress()
        {
            AddNewAddress.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
            AddBtn.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
            if (GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("Ignore")))
            {
                Ignore.ScrollElementAndClick();
                GenericHelper.WaitForLoadingMask();
            }
        }

        public OrderSummary UseThisAddress(int index)
        {
            var element = GenericHelper.GetElement(By.XPath(GetAddressXpath(index)));
            element.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
            return  new OrderSummary(_driver);
        }


        #endregion
    }
}
