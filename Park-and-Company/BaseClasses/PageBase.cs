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

        protected List<IWebElement> GetAllHyperLinks()
        {
            var hyperlinkList = _driver.FindElements(By.TagName("a"));
            return hyperlinkList.ToList();
        }

        protected void TakeScreenShotofPage(IWebElement element,string name)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(element);
            GenericHelper.WaitForLoadingMask();
            GenericHelper.TakeSceenShot(name);
            BrowserHelper.GoBack();
            GenericHelper.WaitForLoadingMask();
        }

        protected void TakeScreenShot(string name)
        {
            GenericHelper.TakeSceenShot(name);
        }
    }
}
