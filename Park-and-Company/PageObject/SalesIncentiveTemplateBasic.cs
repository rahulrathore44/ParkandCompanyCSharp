using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Park_and_Company.BaseClasses;
using OpenQA.Selenium;

namespace Park_and_Company.PageObject
{
    public class SalesIncentiveTemplateBasic : PageBase
    {
        private IWebDriver driver;
        public SalesIncentiveTemplateBasic(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

    }
}
