using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.ComponentHelper;
using Park_and_Company.ExtensionClass.WebElementExtClass;

namespace Park_and_Company.PageObject.Shop.Category.OpenPrePaid
{
    public class OrderSummary : CardStores
    {
        private IWebDriver _driver;

        public OrderSummary(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #region Private

        private string GetConfirmationXpath()
        {
            return "//div[@id='example']//span[contains(.,'Your order has been successfully submitted')]";
        }
            #endregion

        #region WebElements

        [FindsBy(How = How.Id, Using = "submitOrderButton")]
        public IWebElement Ignore;

        #endregion

        #region Public

        public void PlaceOrder()
        {
            Ignore.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
        }

        public void VerifyOrderConfirmation()
        {
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(By.XPath(GetConfirmationXpath())));
        }

        #endregion
    }
}
