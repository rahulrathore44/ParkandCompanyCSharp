using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using Park_and_Company.ComponentHelper;
using Park_and_Company.Configuration;
using Park_and_Company.CustomException;
using Park_and_Company.Settings;


namespace Park_and_Company.BaseClasses
{
    [TestClass]
    public class InitializeWebDriver
    {
        #region Fields

        private static readonly ILog Logger = LoggerHelper.GetLogger(typeof (InitializeWebDriver));

        #endregion

        private static FirefoxProfile GetFirefoxptions()
        {
            var profile = new FirefoxProfile();
            profile.AddExtension(@"C:\downloads\FirefoxGoogleAnalytics.xpi");
            Logger.Info("Using FirefoxProfile");
            return profile;
        }
        private static ChromeOptions GetChromeOptions()
        {
            var option = new ChromeOptions();
            option.AddArgument("start-maximized");
            option.AddExtension(@"C:\downloads\GoogleAnalytics.crx");
            option.Proxy = null;
            Logger.Info("Using ChromeOptions");
            return option;
        }

        private static InternetExplorerOptions GetIeOptions()
        {
            var options = new InternetExplorerOptions()
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                EnsureCleanSession = true,
                ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom
            };
            Logger.Info("Using InternetExplorerOptions Profile");
            return options;
        }


        private static FirefoxDriver GetFirefoxDriver()
        {
            var driver = new FirefoxDriver(GetFirefoxptions());
            return driver;
        }

        private static ChromeDriver GetChromeDriver()
        {
            var driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static InternetExplorerDriver GetIeDriver()
        {
            var driver = new InternetExplorerDriver(GetIeOptions());
            return driver;
        }

        private static PhantomJSDriver GetPhantomJsDriver()
        {
            var driver = new PhantomJSDriver(GetPhantomJsDrvierService());

            return driver;
        }

        private static PhantomJSOptions GetPhantomJsptions()
        {
            var option = new PhantomJSOptions();
            option.AddAdditionalCapability("handlesAlerts", true);
            Logger.Info("Using PhantomJSOptions");
            return option;
        }

        private static PhantomJSDriverService GetPhantomJsDrvierService()
        {
            var service = PhantomJSDriverService.CreateDefaultService();
            service.LogFile = string.Format("TestPhantomJS_{0}.log",DateTime.UtcNow.ToString("yyyy_MM_dd"));
            service.HideCommandPromptWindow = true;
            service.LoadImages = true;
            Logger.Info("Using PhantomJSDriverService");
            return service;
        }


        [AssemblyInitialize]
        public static void InitWebdriver(TestContext tc)
        {
            ObjectRepository.Config = new AppConfigReader();

            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFirefoxDriver();
                    Logger.Info(string.Format(" Browser : {0}", BrowserType.Firefox));
                    break;

                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    Logger.Info(string.Format(" Browser : {0}", BrowserType.Chrome));
                    break;

                case BrowserType.IExplorer:
                    ObjectRepository.Driver = GetIeDriver();
                    Logger.Info(string.Format(" Browser : {0}", BrowserType.IExplorer));
                    break;

                case BrowserType.PhantomJs:
                    ObjectRepository.Driver = GetPhantomJsDriver();
                    Logger.Info(string.Format(" Browser : {0}", BrowserType.PhantomJs));
                    break;

                default:
                    throw new NoSutiableDriverFound("Driver Not Found : " + ObjectRepository.Config.GetBrowser().ToString());
            }
            ObjectRepository.Driver.Manage()
                .Timeouts()
                .SetPageLoadTimeout(TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut()));
            ObjectRepository.Driver.Manage().
                Timeouts().
                ImplicitlyWait(TimeSpan.FromSeconds(ObjectRepository.Config.GetImplicitElementLoadTimeout()));
            GenericHelper.WindowMaximize();
            ObjectRepository.Driver.Navigate().GoToUrl(ObjectRepository.Config.GetWebsite());

            if (GenericHelper.IsElementPresentQuick(By.Id("overridelink")))
            {
                ObjectRepository.Driver.FindElement(By.Id("overridelink")).Click();
            }
               
        }


        [AssemblyCleanup]
        public static void TearDown()
        {

            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Quit();
                Logger.Info("Stopping the Webdriver");
            }
        }
    }
}
