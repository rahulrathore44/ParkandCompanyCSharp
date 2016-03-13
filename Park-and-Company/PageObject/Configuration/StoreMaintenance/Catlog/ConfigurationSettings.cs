using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.ComponentHelper;

namespace Park_and_Company.PageObject.Configuration.StoreMaintenance.Catlog
{
    public class ConfigurationSettings : TabPanel
    {
        #region Constructor

         public ConfigurationSettings(IWebDriver driver) : base(driver) { }

        #endregion

        #region WebElements

        [FindsBy(How = How.XPath, Using = "//label[text()='Maritz Store']")]
        public IWebElement MaritzLabel;

        [FindsBy(How = How.Id, Using = "maritzCheckBox")]
        public IWebElement MaritzCheckBox;

        [FindsBy(How = How.XPath, Using = "//input[@id='maritzCheckBox']/following-sibling::p[1]")]
        public IWebElement MaritzClientId;

        [FindsBy(How = How.Id, Using = "USACampaignCodeInput")]
        public IWebElement UsaCampaignCodeInput;

        [FindsBy(How = How.Id, Using = "CANCampaignCodeInput")]
        public IWebElement CanCampaignCodeInput;

        [FindsBy(How = How.Id, Using = "InternationalCampaignCodeInput")]
        public IWebElement InternationalCampaignCodeInput;

        [FindsBy(How = How.XPath, Using = "//label[text()='Auto-Fulfill']")]
        public IWebElement AutoFulLabel;

        [FindsBy(How = How.Id, Using = "autoFulfillCheckBox")]
        public IWebElement AutoFulfillCheckBox;

        [FindsBy(How = How.XPath, Using = "//label[text()='Make Store Available to Participants']")]
        public IWebElement ParticipantCanAutoFulfillLabel;

        [FindsBy(How = How.Id, Using = "participantCanAutoFulfillCheckBox")]
        public IWebElement ParticipantCanAutoFulfillCheckBox;

        [FindsBy(How = How.XPath, Using = "//label[text()='Uses Wish List']")]
        public IWebElement WishListLabel;

        [FindsBy(How = How.Id, Using = "wishListCheckBox")]
        public IWebElement WishListCheckBox;

        [FindsBy(How = How.XPath, Using = "//label[text()='Uses Basket']")]
        public IWebElement CartLabel;

        [FindsBy(How = How.Id, Using = "cartCheckBox")]
        public IWebElement CartCheckBox;

        #endregion

        #region Public

        public void ValidateMaritzClientElements()
        {
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("MaritzCheckBox")));
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("MaritzClientId")));
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("UsaCampaignCodeInput")));
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("CanCampaignCodeInput")));
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("InternationalCampaignCodeInput")));
        }

        public void ValidateAutoFillElements()
        {
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("AutoFulfillCheckBox")));
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("ParticipantCanAutoFulfillCheckBox")));
        }

        public void ValidateElements()
        {
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("WishListCheckBox")));
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("CartCheckBox")));
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("Next")));
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("Previous")));
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("Cancel")));
        }

        #endregion
    }
}
