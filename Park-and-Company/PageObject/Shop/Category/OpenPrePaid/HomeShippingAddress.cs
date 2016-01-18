using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Park_and_Company.PageObject.Shop.Category.OpenPrePaid
{
    public class HomeShippingAddress : CardStores
    {
        private IWebDriver _driver;

        public HomeShippingAddress(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }
    }
}
