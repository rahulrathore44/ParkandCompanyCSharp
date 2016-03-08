using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Park_and_Company.Interfaces;
using Park_and_Company.Settings;


namespace Park_and_Company.Configuration
{
    public class AppConfigReader : IConfig
    {
        public BrowserType? GetBrowser()
        {
            var browser = ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
            try
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int GetImplicitElementLoadTimeout()
        {
            var timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.ImplicitElementLoadTimeout);
            return timeout == null ? 30 : Convert.ToInt32(timeout);
        }

        public int GetExplicitElementLoadTimeout()
        {
            var timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.ExplicitElementLoadTimeout);
            return timeout == null ? 30 : Convert.ToInt32(timeout);
        }

        public int GetPageLoadTimeOut()
        {
            var timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.PageLoadTimeout);
            return timeout == null ? 30 : Convert.ToInt32(timeout);
        }

        public string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Password);
        }

        public string GetUsername()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Username);
        }

        public string GetWebsite()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Website);
        }
    }
}
