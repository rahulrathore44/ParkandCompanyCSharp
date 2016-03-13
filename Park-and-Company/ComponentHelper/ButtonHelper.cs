using log4net;
using OpenQA.Selenium;
using Park_and_Company.Settings;

namespace Park_and_Company.ComponentHelper
{
    public class ButtonHelper
    {
        private static readonly ILog Logger = LoggerHelper.GetLogger(typeof(ButtonHelper));
        public static void ClickButton(By @by)
        {
            ObjectRepository.Driver.FindElement(by).Click();
            Logger.Info(" Click on Element " + by);
        }
    }
}
