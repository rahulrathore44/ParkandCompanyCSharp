using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.ComponentHelper;

namespace Park_and_Company.BaseClasses
{
    public class PageBase : BaseClass
    {
        private static readonly ILog Logger = LoggerHelper.GetLogger(typeof(PageBase));
        protected IWebDriver Driver;

        [FindsBy(How = How.XPath,Using = "//div[@class='homeProgramsNav']/a[position()=1]")]
        private IWebElement Homebtn;

        public PageBase(IWebDriver driver)
        {
            if (driver == null)
            {
                throw new NullReferenceException("Driver Object is null");
            }
            PageFactory.InitElements(driver, this);
            Driver = driver;
        }


        protected List<IWebElement> GetAllHyperLinks()
        {
            var hyperlinkList = Driver.FindElements(By.TagName("a"));
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
            var field = T.GetField(elementName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var cusAttri = field.GetCustomAttribute(typeof(FindsByAttribute));
            var ele = (FindsByAttribute)cusAttri;
            Logger.Info(string.Format(" Locator of {0} is {1} : {2}",elementName,ele.How,ele.Using));
            return GetElementLocator(ele.How, ele.Using);
        }

        public PageBase GetPageBaseObject()
        {
            return new PageBase(Driver);
        }

        

    }
}
