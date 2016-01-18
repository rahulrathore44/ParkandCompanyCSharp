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
    public class CardDetailPage : CardStores
    {
        private IWebDriver _driver;

        public CardDetailPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        [FindsBy(How = How.Id, Using = "redemptionAmountTextBox")]
        private IWebElement PointAmount;

        [FindsBy(How = How.Id, Using = "QuantityTextBox")]
        private IWebElement Quantity;

        [FindsBy(How = How.Id, Using = "AddToBasketButton")]
        private IWebElement AddToBasketBtn;

        public void SetPointAmount(string amt)
        {
            ClickUpArrow("Point Amount");
            GenericHelper.WaitForElement(PointAmount);
            PointAmount.ScrollElementAndClick();
            PointAmount.Clear();
            PointAmount.SendKeys(amt);
        }

        public void SetQuantity(string qty)
        {
            ClickUpArrow("Quantity");
            Quantity.ScrollElementAndClick();
            Quantity.Clear();
            Quantity.SendKeys(qty);
        }

        public ReviewBasket ClickAddToBasket()
        {
            AddToBasketBtn.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
            return new ReviewBasket(_driver);
        }
    }
}
