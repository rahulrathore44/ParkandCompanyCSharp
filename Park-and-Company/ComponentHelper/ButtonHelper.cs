using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
