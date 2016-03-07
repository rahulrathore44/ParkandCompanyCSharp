using OpenQA.Selenium;
using Park_and_Company.Settings;

namespace Park_and_Company.ComponentHelper
{
    public class ButtonHelper
    {
        public static void ClickButton(By @by)
        {
            ObjectRepository.Driver.FindElement(by).Click();
        }
    }
}
