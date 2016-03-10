using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Park_and_Company.BaseClasses;
using Park_and_Company.ComponentHelper;
using Park_and_Company.ExtensionClass.WebElementExtClass;
using Park_and_Company.Settings;

namespace Park_and_Company.PageObject.Learn.Library
{
    public class LibraryViewPage : PageBase
    {

        #region Field

        private IWebDriver _driver;

        #endregion

        #region Constructor

        public LibraryViewPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }


        #endregion

        #region WebElements

        [FindsBy(How = How.XPath, Using = "//div[@id='content_DivTag']/following-sibling::div[1]//input[@placeholder='Search']")]
        public IWebElement SearchTextBox;

        [FindsBy(How = How.XPath, Using = "//div[@class='modal-content']//button[text()='Close']")]
        public IWebElement ModelDialogCloseBtn;

        #endregion

        #region Internal

        internal string GetAssetContainerXpath(int index)
        {
            return "//div[@id='user-assets-container']/view-assets/div/div[" + index + "]";
        }

        #endregion

        #region Public

        public void SelectViewBy(string value)
        {
            DropDownHelper.SelectFromKendoDropDown(By.XPath(LocatorRepository.SelectButtonXpath), value);
            Thread.Sleep(2000);

            if (GenericHelper.IsElementPresentQuick(By.XPath(LocatorRepository.WarningXpath)))
            {
                ModelDialogCloseBtn.ScrollElementAndClick();
                Thread.Sleep(2000);
            }

            GenericHelper.WaitForLoadingMask();
        }

        public void Search(string @text, string @viewBy)
        {
            SearchTextBox.SendKeys(text);
            SelectViewBy(viewBy);
        }

        public bool IsViewButtonHidden(int index)
        {
            return
                GenericHelper.IsElementPresentQuick(
                    By.XPath(GetAssetContainerXpath(index) +
                             "//div[@class='actions']/button[contains(@class,'ng-hide')]"));
        }

        public bool IsViewButtonVisisble(int index)
        {
            return !IsViewButtonHidden(index);
        }

        #endregion
    }
}
