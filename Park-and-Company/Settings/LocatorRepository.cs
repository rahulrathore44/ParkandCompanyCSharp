using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Park_and_Company.Settings
{
    public class LocatorRepository
    {
        public const string LogoutXpath = "//div[@id='bergerModal']/following-sibling::div[position()=1]/descendant::span[position()=2]";
        public const string LogOffXpath = "//a[contains(text(),'Log Off')]";
        public const string LoginPageLogoXpath = "//div[@class='loginWrapper']";

        public static By SelectButtonXpath => By.XPath("//span[text()='select']");

        public static By SelectKendoDropDownXpath => By.XPath("//span[text()='Select One']/following-sibling::span//span[text()='select']");

        public const string LoadingMaskXpath = "//div[@id='loadingIndicatorContainer' and contains(@style,'display: none;')]";
        public const string WarningXpath = "//label[text()='Warning']";

    }
}
