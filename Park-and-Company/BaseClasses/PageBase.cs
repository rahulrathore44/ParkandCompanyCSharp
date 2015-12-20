using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        [FindsBy(How = How.XPath,Using = "//div[@class='homeProgramsNav']/a[position()=1]")]
        private IWebElement Homebtn;


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

        public void NavigateToHome()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(Homebtn);
            GenericHelper.WaitForLoadingMask();
        }

        protected By GetLocatorOfWebElement(string elementName)
        {
            var T = GetClassType();
            var field = T.GetField(elementName, BindingFlags.Instance | BindingFlags.NonPublic);
            var cusAttri = field.GetCustomAttribute(typeof(FindsByAttribute));
            var ele = (FindsByAttribute)cusAttri;
            return GetElementLocator(ele.How, ele.Using);
        }

        public PageBase GetPageBaseObject()
        {
            return new PageBase(_driver);
        }
    }
}
