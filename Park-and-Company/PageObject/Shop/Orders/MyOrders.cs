using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;
using Park_and_Company.ExtensionClass.WebElementExtClass;

namespace Park_and_Company.PageObject.Shop.Orders
{
    public class MyOrders : PageBase
    {
        public MyOrders(IWebDriver driver) : base(driver)
        {
            
        }


        #region Private

        private string GetOrderNoXpath()
        {
            return "//div[@class='SelectedOrderDetails']/div[2]/table/tbody/tr[1]/td[1]";
        }

        private string GetOrderDateXpath()
        {
            return "//div[@class='SelectedOrderDetails']/div[2]/table/tbody/tr[2]/td[1]";
        }

        #endregion


        #region Public

        public void ClickViewInGrid(int row,int column)
        {
            var element = GridHelper.GetGridElement(Properties.Settings.Default.MyOrdersGrid, row, column);
            element.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
        }

        public void VerifyOrderNumber(string orderNo)
        {
            var element = GenericHelper.GetElement(By.XPath(GetOrderNoXpath()));
            element.ScrollToElement();
            Assert.AreEqual(orderNo,element.Text);
        }

        public void VerifyOrderDate(string orderDate)
        {
            var element = GenericHelper.GetElement(By.XPath(GetOrderDateXpath()));
            element.ScrollToElement();
            Assert.AreEqual(orderDate, element.Text);
        }

        #endregion
    }
}
