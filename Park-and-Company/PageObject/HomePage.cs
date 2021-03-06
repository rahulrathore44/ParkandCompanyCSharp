﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;
using Park_and_Company.ExtensionClass.WebElementExtClass;
using Park_and_Company.PageObject.Claims;
using Park_and_Company.PageObject.Claims.ManageCalims;
using Park_and_Company.PageObject.Configuration.CustomeAttribute;
using Park_and_Company.PageObject.Configuration.ManageRoles;
using Park_and_Company.PageObject.Configuration.StoreMaintenance;
using Park_and_Company.PageObject.Learn.Library;
using Park_and_Company.PageObject.Partner.PartnerGrp;
using Park_and_Company.PageObject.Programs.ManualPointAdjustment;
using Park_and_Company.PageObject.Reports;
using Park_and_Company.PageObject.Shop;
using Park_and_Company.PageObject.Shop.Orders;
using Park_and_Company.PageObject.UserGroups;
using Park_and_Company.Settings;

namespace Park_and_Company.PageObject
{
    public class HomePage : PageBase
    {
        private IWebDriver driver;

        public HomePage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }


        [FindsBy(How = How.XPath,Using = "//div[@id='header4']/descendant::a[text()='Programs ']")]
        private IWebElement Programs;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[contains(text(),'Learn')]")]
        private IWebElement _learn;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[contains(text(),'Library')]")]
        private IWebElement _library;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='User ']")]
        private IWebElement User;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Partner ']")]
        private IWebElement Partner;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='File ']")]
        private IWebElement File;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Communication ']")]
        private IWebElement Communication;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Configuration ']")]
        private IWebElement Configuration;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Store Maintenance']")]
        private IWebElement StoreMaintenance;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Reports']")]
        private IWebElement Reports;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Onboarding ']")]
        private IWebElement Onboarding;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Manage Incentive Programs']")]
        private IWebElement ManageIncentivePrograms;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Manage Claims']")]
        private IWebElement ManageClaims;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Manual Point Adjustment']")]
        private IWebElement ManualPointAdj;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Manage User Groups']")]
        private IWebElement ManageUserGroups;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Manage Users']")]
        private IWebElement ManageUser;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Partner Groups']")]
        private IWebElement PartnerGroups;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Manage Partners']")]
        private IWebElement ManagePartners;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='File Loader']")]
        private IWebElement FileLoader;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='File Status']")]
        private IWebElement FileStatus;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Manage Notification Templates']")]
        private IWebElement ManageNotificationTemplates;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Manage Notification Triggers']")]
        private IWebElement ManageNotificationTriggers;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Manage Scheduled Messages']")]
        private IWebElement ManageScheduledMessages;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Email Analytics']")]
        private IWebElement EmailAnalytics;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Manage Roles']")]
        private IWebElement ManageRoles;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Customer Profile']")]
        private IWebElement CustomerProfile;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Custom Attributes']")]
        private IWebElement CustomAttributes;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='Manage Customer Content']")]
        private IWebElement ManageCustomerContent;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='New Customer']")]
        private IWebElement NewCustomer;

        [FindsBy(How = How.XPath, Using = "//div[@id='header4']/descendant::a[text()='SFDC Configuration']")]
        private IWebElement SFDCConfiguration;

        [FindsBy(How = How.XPath, Using = "//h6[@class='footerLinks']/a[1]")]
        private IWebElement PrivacyPolicy;

        [FindsBy(How = How.XPath, Using = "//div[@class='incentive-modal-content']//button[text()='Ok']")]
        private IWebElement Ok;

        [FindsBy(How = How.XPath, Using = "//h6[@class='footerLinks']/a[2]")]
        private IWebElement TermsandConditions;

        [FindsBy(How = How.XPath, Using = "//div[@class='incentive-modal-content']//button[text()='Close']")]
        private IWebElement Close;

        [FindsBy(How = How.XPath, Using = "//h6[@class='footerLinks']/a[3]")]
        private IWebElement ContactUs;

        [FindsBy(How = How.XPath, Using = "//button[text()='Submit']")]
        private IWebElement Submit;

        [FindsBy(How = How.XPath, Using = "//h6[@class='footerLinks']/a[4]")]
        private IWebElement FAQ;

        [FindsBy(How = How.XPath, Using = "//div[@class='dropdown mainNavDropCont']/button[contains(text(),'Claims')]")]
        private IWebElement Claims;

        [FindsBy(How = How.LinkText, Using = "New Claim")]
        private IWebElement NewClaims;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Shop')]")] public IWebElement Shop;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Card Store')]")] public IWebElement CardStore;


        #region Private

        private string GetSubMenuItemXpath(string name)
        {
            return "//a[contains(text(),'" + name + "')]";
        }

        #endregion

        /// <summary>
        /// Supply the Name of Element which you want to validate. The element should be in same class
        // Similarly for other element which u want to validate. Supply name as string
        ///  </summary>
        public void ValidateElements()
        {
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("Programs")),"Element Not Found"); 
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("User")), "Element Not Found");
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("Partner")), "Element Not Found");
            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("File")), "Element Not Found");
        }

        private void ScreenShotofLink(IWebElement element, IWebElement button,string name)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(element);
            GenericHelper.WaitForElement(button);
            GenericHelper.TakeSceenShot(name);
            JavaScriptExecutorHelper.ScrollElementAndClick(button);
            Thread.Sleep(200);
        }

        public ManageIncentivePrograms OpenManageIncentivePrograms()
        {
            Programs.Click();
            GenericHelper.WaitForElement(ManageIncentivePrograms);
            ManageIncentivePrograms.Click();
            GenericHelper.WaitForElement(By.Id("titleDiv"));
            Assert.IsTrue(GenericHelper.IsElementPresent(By.Id("titleDiv")), ErrorMessage.PageLoadErrMsg + "Manage Incentive Programs Page");
            GenericHelper.WaitForLoadingMask();
            return new ManageIncentivePrograms(driver);
        }

        public ManageUserGroups OpenManageUserGroups()
        {
            User.Click();
            GenericHelper.WaitForElement(ManageUserGroups);
            ManageUserGroups.Click();
            GenericHelper.WaitForElement(By.Id("titleDiv"));
            Assert.IsTrue(GenericHelper.IsElementPresent(By.Id("titleDiv")), ErrorMessage.PageLoadErrMsg + "Manage Incentive Programs Page");
            GenericHelper.WaitForLoadingMask();
            return new ManageUserGroups(driver);
        }

        public NewClaim OpeNewClaimPage()
        {
            Claims.Click();
            GenericHelper.WaitForElement(NewClaims);
            NewClaims.Click();
            GenericHelper.WaitForLoadingMask();
            GenericHelper.WaitForElement(By.Id("titleDiv"));
            return new NewClaim(driver);
        }

        public ManageCalims OpeManageCalimsPage()
        {
            Programs.Click();
            GenericHelper.WaitForElement(ManageClaims);
            ManageClaims.Click();
            GenericHelper.WaitForLoadingMask();
            GenericHelper.WaitForElement(By.Id("titleDiv"));
            return new ManageCalims(driver);
        }

        public void TakeHomePageScrShot(string name)
        {
            GenericHelper.TakeSceenShot(name);
        }

        public void TakeManageIncentScrShot(string name)
        {
            Programs.Click();
            GenericHelper.WaitForElement(ManageIncentivePrograms);
            TakeScreenShotofPage(ManageIncentivePrograms,name);
        }
        public void TakeManageClaimsScrShot(string name)
        {
            Programs.Click();
            GenericHelper.WaitForElement(ManageClaims);
            TakeScreenShotofPage(ManageClaims, name);
        }
        public void TakeManualPointAdjScrShot(string name)
        {
            Programs.Click();
            GenericHelper.WaitForElement(ManualPointAdj);
            TakeScreenShotofPage(ManualPointAdj, name);
        }

        public void TakeManageUserGrpScrShot(string name)
        {
            User.Click();
            GenericHelper.WaitForElement(ManageUserGroups);
            TakeScreenShotofPage(ManageUserGroups, name);
        }
        public void TakeManageUserScrShot(string name)
        {
            User.Click();
            GenericHelper.WaitForElement(ManageUser);
            TakeScreenShotofPage(ManageUser, name);
        }

        public void TakePatnerGrpScrShot(string name)
        {
            Partner.Click();
            GenericHelper.WaitForElement(PartnerGroups);
            TakeScreenShotofPage(PartnerGroups, name);
        }
        public void TakeManagePartnerScrShot(string name)
        {
            Partner.Click();
            GenericHelper.WaitForElement(ManagePartners);
            TakeScreenShotofPage(ManagePartners, name);
        }

        public void TakeFileLoaderScrShot(string name)
        {
            File.Click();
            GenericHelper.WaitForElement(FileLoader);
            TakeScreenShotofPage(FileLoader, name);
        }
        public void TakeFileStatusScrShot(string name)
        {
            File.Click();
            GenericHelper.WaitForElement(FileStatus);
            TakeScreenShotofPage(FileStatus, name);
        }

        public void TakeManageNotificationScrShot(string name)
        {
            Communication.Click();
            GenericHelper.WaitForElement(ManageNotificationTemplates);
            TakeScreenShotofPage(ManageNotificationTemplates, name);
        }
        public void TakeManageNotiTriggerScrShot(string name)
        {
            Communication.Click();
            GenericHelper.WaitForElement(ManageNotificationTriggers);
            TakeScreenShotofPage(ManageNotificationTriggers, name);
        }

        public void TakeManageSchedMsgScrShot(string name)
        {
            Communication.Click();
            GenericHelper.WaitForElement(ManageScheduledMessages);
            TakeScreenShotofPage(ManageScheduledMessages, name);
        }
        public void TakeEmailAnalyticsScrShot(string name)
        {
            Communication.Click();
            GenericHelper.WaitForElement(EmailAnalytics);
            TakeScreenShotofPage(EmailAnalytics, name);
        }

        public void TakeReportsScrShot(string name)
        {
            Reports.Click();
            GenericHelper.WaitForLoadingMask();
            GenericHelper.TakeSceenShot(name);
            BrowserHelper.GoBack();
            GenericHelper.WaitForLoadingMask();
        }

        public void TakeManageRolesScrShot(string name)
        {
            Configuration.Click();
            GenericHelper.WaitForElement(ManageRoles);
            TakeScreenShotofPage(ManageRoles, name);
        }

        public void TakeCustomeProfScrShot(string name)
        {
            Configuration.Click();
            GenericHelper.WaitForElement(CustomerProfile);
            TakeScreenShotofPage(CustomerProfile, name);
        }
        public void TakeCustomeAttributeScrShot(string name)
        {
            Configuration.Click();
            GenericHelper.WaitForElement(CustomAttributes);
            TakeScreenShotofPage(CustomAttributes, name);
        }

        public void TakeManageCustomerContentScrShot(string name)
        {
            Configuration.Click();
            GenericHelper.WaitForElement(ManageCustomerContent);
            GenericHelper.TakeSceenShot(name);
            BrowserHelper.GoBack();
            GenericHelper.WaitForLoadingMask();
        }

        public void TakeNewCustomerScrShot(string name)
        {
            Onboarding.Click();
            GenericHelper.WaitForElement(NewCustomer);
            TakeScreenShotofPage(NewCustomer, name);
        }
        public void TakeSfdcConfScrShot(string name)
        {
            Onboarding.Click();
            GenericHelper.WaitForElement(SFDCConfiguration);
            TakeScreenShotofPage(SFDCConfiguration, name);
        }

        public void TakePrivacyPolicyScrShot(string name)
        {
            ScreenShotofLink(PrivacyPolicy, Ok, name);

        }

        public void TakeTermsConditionScrShot(string name)
        {
            ScreenShotofLink(TermsandConditions, Close, name);

        }
        public void TakeContactUsScrShot(string name)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(ContactUs);
            GenericHelper.WaitForLoadingMask();
            GenericHelper.TakeSceenShot(name);
            BrowserHelper.GoBack();
            GenericHelper.WaitForLoadingMask();
        }

        public void TakeFaqScrShot(string name)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(FAQ);
            GenericHelper.WaitForLoadingMask();
            GenericHelper.TakeSceenShot(name);
            BrowserHelper.GoBack();
            GenericHelper.WaitForLoadingMask();
        }

        public ManageRoles ClickManageRoles()
        {
            Configuration.Click();
            GenericHelper.WaitForElement(ManageRoles);
            ManageRoles.Click();
            GenericHelper.WaitForLoadingMask();
            return new ManageRoles(driver);
        }

        public ManagePartnerGrp ClickManagePartnerGrp()
        {
            Partner.Click();
            GenericHelper.WaitForElement(PartnerGroups);
            PartnerGroups.Click();
            GenericHelper.WaitForLoadingMask();
            return new ManagePartnerGrp(driver);
        }

        public CustomAttributes NavigateToCustomeAttribute()
        {
            Configuration.Click();
            GenericHelper.WaitForElement(CustomAttributes);
            CustomAttributes.Click();
            GenericHelper.WaitForLoadingMask();
            return new CustomAttributes(driver);
        }

        public ReportPage NavigateToReportsPage()
        {
            Reports.Click();
            GenericHelper.WaitForLoadingMask();
            return new ReportPage(driver);
        }

        public ManualPointAdjustment NavigateToManualPointAdjustment()
        {
            Programs.Click();
            GenericHelper.WaitForElement(ManualPointAdj);
            ManualPointAdj.Click();
            GenericHelper.WaitForLoadingMask();
            return new ManualPointAdjustment(driver);
        }

        public CardStores NavigateToCardStore(string subMenuItem)
        {
            Shop.ScrollElementAndClick();
            var menuItem = GenericHelper.GetElement(By.XPath(GetSubMenuItemXpath(subMenuItem)));
            GenericHelper.WaitForElement(menuItem);
            menuItem.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
            return new  CardStores(driver);
        }

        public MyOrders NavigateToOrders()
        {
            Shop.ScrollElementAndClick();
            var menuItem = GenericHelper.GetElement(By.XPath(GetSubMenuItemXpath("Orders")));
            GenericHelper.WaitForElement(menuItem);
            menuItem.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
            return new MyOrders(driver);
        }

        public LibraryDetailPage NavigateToLibrary()
        {
            _learn.ScrollElementAndClick();
            GenericHelper.WaitForElement(_library);
            _library.Click();
            GenericHelper.WaitForLoadingMask();
            return new LibraryDetailPage(driver);
        }

        public StoreMaintenance NavigateToStoreMaintenance()
        {
            Configuration.Click();
            GenericHelper.WaitForElement(StoreMaintenance);
            StoreMaintenance.Click();
            GenericHelper.WaitForLoadingMask();
            return new StoreMaintenance(driver);
        }
    }
}
