using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;
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
    }
}
