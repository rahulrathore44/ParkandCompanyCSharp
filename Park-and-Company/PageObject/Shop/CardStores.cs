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
using Park_and_Company.PageObject.Shop.Category.OpenPrePaid;

namespace Park_and_Company.PageObject.Shop
{
    public class CardStores : PageBase
    {
        private IWebDriver _driver;

        public CardStores(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        [FindsBy(How = How.Id, Using = "categoryDropdownMenu")] public IWebElement Category;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Open Prepaid')]")] public IWebElement OpenPre;

        [FindsBy(How = How.XPath, Using = "//button[contains(.,'CHECKOUT')]")] private IWebElement CheckOut;

        [FindsBy(How = How.Id, Using = "quickTextBox")]
        private IWebElement QuickTextBox;

        protected void ClickUpArrow(string label)
        {
            var  element = GenericHelper.GetElement(
                By.XPath(
                    "//span[contains(.,'" + label + "')]/following-sibling::div//span[contains(text(),'Increase value')]"));
            element.ScrollElementAndClick();
        }

        public void QuickSearch(string search)
        {
            QuickTextBox.ScrollElementAndClick();
            QuickTextBox.SendKeys(search);
        }

        public ViewItems ClickOpenPrePaid()
        {
            Category.ScrollElementAndClick();
            GenericHelper.WaitForElement(OpenPre);
            OpenPre.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
            return new ViewItems(_driver);
        }

        public HomeShippingAddress ClickCheckOut()
        {
            CheckOut.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
            return new HomeShippingAddress(_driver);
        }

    }
}
