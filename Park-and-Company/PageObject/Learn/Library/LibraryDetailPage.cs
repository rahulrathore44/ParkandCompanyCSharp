using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;

namespace Park_and_Company.PageObject.Learn.Library
{
    public class LibraryDetailPage : PageBase
    {

        #region Fields

        private IWebDriver _driver;

        #endregion

        #region Constructo

        public LibraryDetailPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #endregion


        #region WebElements

        [FindsBy(How = How.Name, Using = "Filepath")]
        public IWebElement Asset;

        [FindsBy(How = How.Id, Using = "dropbox")]
        public IWebElement DropBox;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Upload')]")]
        public IWebElement UploadBtn;

        [FindsBy(How = How.Name, Using = "Name")]
        public IWebElement Name;

        [FindsBy(How = How.XPath, Using = "//textarea[@name='Description' and @type='text']")]
        public IWebElement Description;

        [FindsBy(How = How.Name, Using = "IsActive")]
        public IWebElement IsActive;

        [FindsBy(How = How.Id, Using = "thumbnailFile")]
        public IWebElement Browse;

        [FindsBy(How = How.Name, Using = "EligibleGroup")]
        public IWebElement EligibleGroup;

        [FindsBy(How = How.Name, Using = "NativeLanguage")]
        public IWebElement Language;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Search Tags')]/following-sibling::div[position()=1]//input")]
        public IWebElement SearchTags;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Add Tag')]")]
        public IWebElement AddTag;

        [FindsBy(How = How.XPath, Using = "//select[@name='AssetFamily']")]
        public IWebElement ChooseFamily;

        [FindsBy(How = How.XPath, Using = "//input[@name='AssetFamily']")]
        public IWebElement CreateNewFamily;

        [FindsBy(How = How.Name, Using = "IsDownloadable")]
        public IWebElement IsDownloadable;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Save')]")]
        public IWebElement Save;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Cancel')]")]
        public IWebElement Cancel;

        #endregion

    }
}
