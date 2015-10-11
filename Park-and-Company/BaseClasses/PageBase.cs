using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.ComponentHelper;

namespace Park_and_Company.BaseClasses
{
    public class PageBase : BaseClass
    {
        private IWebDriver _driver;

        public PageBase(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        
    }
}
