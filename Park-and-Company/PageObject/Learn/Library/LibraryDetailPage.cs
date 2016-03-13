using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;
using Park_and_Company.ExtensionClass.WebElementExtClass;
using Park_and_Company.Settings;

namespace Park_and_Company.PageObject.Learn.Library
{
    public class LibraryDetailPage : PageBase
    {

        

        #region Constructo

        public LibraryDetailPage(IWebDriver driver) : base(driver)
        {
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

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Visibility Start Date ')]/following-sibling::p/span//button")]
        public IWebElement VisibilityStartDate;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Visibility End Date ')]/following-sibling::p/span//button")]
        public IWebElement VisibilityEndDate;

        [FindsBy(How = How.XPath, Using = "//div[@class='homeProgramsNav']/a[contains(text(),'Library')]")]
        public IWebElement LibrarySearchPage;

        [FindsBy(How = How.XPath, Using = "//div[@id='content_DivTag']/following-sibling::div[1]//input[@placeholder='Search']")]
        public IWebElement SearchTextBox;

        [FindsBy(How = How.XPath, Using = "//select[contains(@ng-model,'selectedAssetType')]")]
        public IWebElement ViewBy;

        [FindsBy(How = How.XPath, Using = "//select[contains(@ng-model,'selectedSortType')]")]
        public IWebElement SortBy;

        #endregion

        #region internal

        internal string GetCalanderXpath(string label)
        {
            return "//label[contains(text(),'" + label +  "')]/following-sibling::p//div[@role='application']//table[@role='grid']";
        }

        internal string GetAssetXpath(int index)
        {
            return "//div[@id='AssetList']//fieldset/div[" + index + "]";
        }

        #endregion

        #region Public

        public void SelectVisibilityStartDate(string day,string month,string year)
        {
            VisibilityStartDate.ScrollElementAndClick();
            GenericHelper.WaitForElement(By.XPath(GetCalanderXpath(LabelRepository.VisibilityStartDate)));
            CalenderHelper.SelectDate(GetCalanderXpath(LabelRepository.VisibilityStartDate), day, month, year);
            GenericHelper.WaitForLoadingMask();
        }

        public void SelectVisibilityEndDate(string day, string month, string year)
        {
            VisibilityEndDate.ScrollElementAndClick();
            GenericHelper.WaitForElement(By.XPath(GetCalanderXpath(LabelRepository.VisibilityEndDate)));
            CalenderHelper.SelectDate(GetCalanderXpath(LabelRepository.VisibilityEndDate), day, month, year);
            GenericHelper.WaitForLoadingMask();
        }

        public void EditAsset(int index)
        {
            var element = GenericHelper.GetElement(By.XPath(GetAssetXpath(index) + "//div[@class='assetEdit']/a[1]"));
            element.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
        }

        public void DeleteAsset(int index)
        {
            var element = GenericHelper.GetElement(By.XPath(GetAssetXpath(index) + "//div[@class='assetEdit']/a[2]"));
            element.ScrollElementAndClick();
            GenericHelper.AcceptAlert();
            GenericHelper.WaitForLoadingMask();
        }

        public string GetAssetName(int index)
        {
            var element = GenericHelper.GetElement(By.XPath(GetAssetXpath(index) + "//div[@class='assetContent']/span//a"));
            element.ScrollToElement();
            return element.Text;
        }

        public string GetAssetDescription(int index)
        {
            var element = GenericHelper.GetElement(By.XPath(GetAssetXpath(index) + "//div[@class='assetContent']/div[@class='assetDesc']//p"));
            element.ScrollToElement();
            return element.Text;
        }

        public void Search(string text = "docx", string sortBy = "Last Created Date", string viewBy = "Documents")
        {
            DropDownHelper.SelectByVisibleText(SortBy,sortBy);
            GenericHelper.WaitForLoadingMask();
            DropDownHelper.SelectByVisibleText(ViewBy,viewBy);
            GenericHelper.WaitForLoadingMask();
            SearchTextBox.SendKeys(text);
            ObjectRepository.Driver.FindElement(By.XPath("//h2[contains(text(),'New/Edit')]")).Click();
            GenericHelper.WaitForLoadingMask();
        }

        public bool ValiateIsAssetPresent(int index)
        {
            return GenericHelper.IsElementPresentQuick(By.XPath(GetAssetXpath(index)));
        }

        public LibraryViewPage NavigateToLibrarySearch()
        {
            LibrarySearchPage.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
            return new LibraryViewPage(Driver);
        }

        #endregion

    }
}
