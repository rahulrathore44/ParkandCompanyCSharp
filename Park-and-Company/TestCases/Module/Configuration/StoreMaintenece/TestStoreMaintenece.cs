﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Park_and_Company.BaseClasses.LoginBaseClass;
using Park_and_Company.ComponentHelper;
using Park_and_Company.ExtensionClass.LoggerExtClass;
using Park_and_Company.ExtensionClass.WebElementExtClass;
using Park_and_Company.PageObject.Configuration.StoreMaintenance.Catlog;
using Park_and_Company.Settings;

namespace Park_and_Company.TestCases.Module.Configuration.StoreMaintenece
{
    [TestClass]
    public class TestStoreMaintenece : LoginBase
    {
        private readonly string[] _gridHeading = { "Markup", "Flat Fee", "% Fee",
            "Markup Fee", "Markup %", "Miscellaneous Fee", "Miscellaneous %" };

       private  readonly string[,] _multiMerchant =  {
            {"MXFDPD", "MAX MasterCard® Prepaid Card"},
            {"VMAXPD", "MAX Visa® Prepaid Card"},
            {"VMAXPD", "MAX Visa® Prepaid Card"},
            {"VGASPD", "Gas Visa® Prepaid Card"}
        };

        private readonly string[,] _openPrepaid =
        {
            {"DUGCPD", "Universal Discover® Gift Card"},
            {"UNIVPR", "Universal Visa® Prepaid Card- w/ATM"},
            {"UNIAPR_seastar", "OnBoard Rewards Visa® Prepaid Card"},
            {"MCPPPD", "Universal MasterCard® Prepaid Card"},
            {"UNIAPR", "Universal Visa® Prepaid Card"}
        };

        private readonly string[,] _singleMerchant =
        {
            {"LandrysBrands" ,"Landry's" }, 
            {"Walmart" , "Walmart" },
            {"Brookstone"  , "Brookstone®" },
            {"Cabelas" , "Cabela's®" },
            { "BuffaloWildWings" ,"Buffalo Wild Wings®"}

        };


        /// <summary>
        /// Make sure your test should inherite form "LoginBase" class
        /// Write the test case in Try catch block
        /// And use the Logger object as follow
        /// </summary>

        [TestMethod]
        [Description("Example to Use Logger in Test")]
        public void TestLoggerExample()
        {
            try
            {
                var smPage = HPage.NavigateToStoreMaintenance().ClickAddButton();
                Logger.Info("Navigate to GeneralInformation Page"); // Logger Object
                smPage.SelectCustomer("cit");
                Logger.Info("Select the Customer");
                smPage.StoreNameInput.SendKeys(string.Format("TestStore{0}", DateTime.UtcNow.ToString("yyyy-MM-dd-hh-mm-ss")));
                smPage.SelectStatus("Active");
                smPage.SelectPointType("Visa");
                smPage.SelectLanguage("English (United States)");
                smPage.SetPointMonetaryValue("1");

                var configPage = (ConfigurationSettings)smPage.ClickNext(typeof(ConfigurationSettings));
                Logger.Info("Clicking on Next to Open Configuration Page"); // Logger Object
                configPage.WishListLabel.Click();
                configPage.CartLabel.Click();

                var invetPage = (StoreInventory)configPage.ClickNext(typeof(StoreInventory));
                invetPage.SelectLanguage("United States");
                invetPage.MultiMerchantChk.Click();
                GenericHelper.WaitForLoadingMask();
                GridHelper.GetGridElement(Properties.Settings.Default.StoreInventoryAvaliableItems, 1, 1).Click();
                GenericHelper.WaitForLoadingMask();

                var markUpPage = (StoreMarkups)configPage.ClickNext(typeof(StoreMarkups));
                //markUpPage.Save.ScrollElementAndClick(); // Will save the created store
                markUpPage.Logout();
            }
            catch (Exception exception)
            {
                Logger.LogException(exception);
                throw;
            }
            

        }

        [TestMethod]
        [Description("End to end flow for creating the Store Configuration")]
        public void TestCreateStore()
        {
            var smPage = HPage.NavigateToStoreMaintenance().ClickAddButton();
            smPage.SelectCustomer("cit");
            smPage.StoreNameInput.SendKeys(string.Format("TestStore{0}",DateTime.UtcNow.ToString("yyyy-MM-dd-hh-mm-ss")));
            smPage.SelectStatus("Active");
            smPage.SelectPointType("Visa");
            smPage.SelectLanguage("English (United States)");
            smPage.SetPointMonetaryValue("1");

            var configPage = (ConfigurationSettings) smPage.ClickNext(typeof (ConfigurationSettings));
            configPage.WishListLabel.Click();
            configPage.CartLabel.Click();

            var invetPage = (StoreInventory)configPage.ClickNext(typeof (StoreInventory));
            invetPage.SelectLanguage("United States");
            invetPage.MultiMerchantChk.Click();
            GenericHelper.WaitForLoadingMask();
            GridHelper.GetGridElement(Properties.Settings.Default.StoreInventoryAvaliableItems,1,1).Click();
            GenericHelper.WaitForLoadingMask();

            var markUpPage = (StoreMarkups)configPage.ClickNext(typeof(StoreMarkups));
            //markUpPage.Save.ScrollElementAndClick(); // Will save the created store
            markUpPage.Logout();

        }

        [TestMethod]
        public void TestGeneralInfoPage()
        {
            var smPage = HPage.NavigateToStoreMaintenance().ClickAddButton();
            //smPage.SelectCustomer("cit"); // For Selecting the customer
            //smPage.StoreNameInput.SendKeys("Test"); //For Providing the Store Name
            //smPage.SelectStatus("Active"); //For Selecting the Status
            //smPage.SelectPointType("Visa"); //For Selecting the Point type
            //smPage.SelectLanguage("English (United States)"); //For Selecting the language
            //smPage.SetPointMonetaryValue("1"); //For Selecting the Point Monetry Value
            smPage.ValidateElement(); //Validate the elements
            smPage.Logout();
        }

        [TestMethod]
        public void TestConfigurationPage()
        {
            var smPage = HPage.NavigateToStoreMaintenance().ClickAddButton();
            var configPage = (ConfigurationSettings)smPage.ClickNext(typeof(ConfigurationSettings)); // Click on next
            GenericHelper.WaitForLoadingMask();
            configPage.MaritzLabel.Click();
            GenericHelper.WaitForElement(configPage.MaritzClientId);
            Console.WriteLine("Client Id : {0}", configPage.MaritzClientId.Text);
            configPage.ValidateMaritzClientElements();
            configPage.MaritzLabel.Click();
            Thread.Sleep(1000);

            configPage.AutoFulLabel.Click();
            GenericHelper.WaitForElement(configPage.ParticipantCanAutoFulfillLabel);
            configPage.ValidateAutoFillElements();
            configPage.AutoFulLabel.Click();
            Thread.Sleep(1000);

            configPage.ValidateElements();
            smPage.Logout();
        }

        [TestMethod]
        public void TestStoreInventoryPage()
        {
            var smPage = HPage.NavigateToStoreMaintenance().ClickAddButton();
            var config = (ConfigurationSettings)smPage.ClickNext(typeof(ConfigurationSettings));
            var invePage = (StoreInventory)config.ClickNext(typeof(StoreInventory));
            invePage.SelectLanguage("United States");
            invePage.MultiMerchantChk.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();

            for (var i = 0; i < _multiMerchant.GetLength(0); i++)
            {
                Assert.AreEqual(_multiMerchant[i,0],GridHelper.GetGridElementText(Properties.Settings.Default.StoreInventoryAvaliableItems,(i+1),2));
                Assert.AreEqual(_multiMerchant[i, 1],GridHelper.GetGridElementText(Properties.Settings.Default.StoreInventoryAvaliableItems, (i + 1), 3));
            }

            invePage.MultiMerchantChk.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();

            invePage.OpenPrepaidChk.Click();
            GenericHelper.WaitForLoadingMask();

            for (var i = 0; i < _openPrepaid.GetLength(0); i++)
            {
                Assert.AreEqual(_openPrepaid[i, 0], GridHelper.GetGridElementText(Properties.Settings.Default.StoreInventoryAvaliableItems, (i + 1), 2));
                Assert.AreEqual(_openPrepaid[i, 1], GridHelper.GetGridElementText(Properties.Settings.Default.StoreInventoryAvaliableItems, (i + 1), 3));
            }

            invePage.OpenPrepaidChk.Click();
            GenericHelper.WaitForLoadingMask();

            invePage.SingleMerchantChk.Click();
            GenericHelper.WaitForLoadingMask();

            for (var i = 0; i < _singleMerchant.GetLength(0); i++)
            {
                Assert.AreEqual(_singleMerchant[i, 0], GridHelper.GetGridElementText(Properties.Settings.Default.StoreInventoryAvaliableItems, (i + 1), 2));
                Assert.AreEqual(_singleMerchant[i, 1], GridHelper.GetGridElementText(Properties.Settings.Default.StoreInventoryAvaliableItems, (i + 1), 3));
            }

            invePage.SingleMerchantChk.Click();
            GenericHelper.WaitForLoadingMask();

            invePage.Logout();
        }

        [TestMethod]
        public void TestMarkupsPage()
        {
            var smPage = HPage.NavigateToStoreMaintenance().ClickAddButton();
            var config = (ConfigurationSettings)smPage.ClickNext(typeof(ConfigurationSettings));
            var invePage = (StoreInventory)config.ClickNext(typeof(StoreInventory));
            var markupPage = (StoreMarkups)invePage.ClickNext(typeof(StoreMarkups));
            markupPage.ValidateElements();
            Assert.IsTrue(GenericHelper.IsElementPresent(By.XPath(Properties.Settings.Default.StoreMarkups)), "Store Markups Grid Not Found");
            for (var i = 0; i < _gridHeading.Length; i++)
            {
                Assert.AreEqual(_gridHeading[i],GridHelper.GetGridHeaderText(Properties.Settings.Default.StoreMarkups,1,(i+1)));
            }
            markupPage.Logout();
        }
    }
}
