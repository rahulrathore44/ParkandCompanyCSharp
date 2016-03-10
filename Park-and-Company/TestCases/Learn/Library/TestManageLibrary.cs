using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Park_and_Company.BaseClasses.LoginBaseClass;
using Park_and_Company.ComponentHelper;
using Park_and_Company.ExtensionClass.WebElementExtClass;
using Park_and_Company.Settings;

namespace Park_and_Company.TestCases.Learn.Library
{
    [TestClass]
    public class TestManageLibrary : LoginBase
    {

        [TestMethod]
        [DeploymentItem("Resources")]
        public void TestManageLibraryUpload()
        {
            var myLibPage = hPage.NavigateToLibrary();
            myLibPage.DropBox.ScrollElementAndClick();
            myLibPage.FileUpload(@"TestDataFiles\Title.docx");
            Thread.Sleep(1000);
            //myLibPage.UploadBtn.ScrollElementAndClick(); // click the upload button, commented as upload button is throwing exception
            myLibPage.Name.SendKeys("TestDocFile");
            myLibPage.Description.SendKeys("TestDocDescription");
            myLibPage.Browse.Click();
            myLibPage.FileUpload(@"TestDataFiles\Thub.png"); 
            DropDownHelper.SelectByVisibleText(myLibPage.EligibleGroup, "AssetGroup");
            myLibPage.SelectVisibilityStartDate("15","December","2018");
            myLibPage.SelectVisibilityEndDate("15", "April", "2019");
            DropDownHelper.SelectByVisibleText(myLibPage.Language, "Afrikaans");
            myLibPage.SearchTags.SendKeys("TestOne");
            DropDownHelper.SelectByVisibleText(myLibPage.ChooseFamily,"test");
            //myLibPage.CreateNewFamily.SendKeys("New Family"); // For creating the new Family
            myLibPage.IsDownloadable.ScrollElementAndClick();
            //myLibPage.Save.Click(); // Will click on save button
            //myLibPage.Cancel.Click(); // will click on save button
            Thread.Sleep(5000);
            myLibPage.Logout();
           
        }

        [TestMethod]
        [DeploymentItem("Resources")]
        public void TestCsvFile()
        {
            var myLibPage = hPage.NavigateToLibrary();
            myLibPage.DropBox.ScrollElementAndClick();
            myLibPage.FileUpload(@"TestDataFiles\Inventorylist1.csv");
            Thread.Sleep(1000);
            Assert.AreEqual(ErrorMessage.CsvErrMessage, GenericHelper.GetElement(By.XPath("//div[@id='dropbox']/following-sibling::div[position()=1]")).Text.Trim());
            myLibPage.Logout();

        }

        [TestMethod]
        [DeploymentItem("Resources")]
        public void TestWithBigThumbnailImage()
        {
            var myLibPage = hPage.NavigateToLibrary();
            myLibPage.DropBox.ScrollElementAndClick();
            myLibPage.FileUpload(@"TestDataFiles\Title.docx");
            Thread.Sleep(1000);
            //myLibPage.UploadBtn.ScrollElementAndClick(); // click the upload button, commented as upload button is throwing exception
            myLibPage.Name.SendKeys("TestDocFile");
            myLibPage.Description.SendKeys("TestDocDescription");
            myLibPage.Browse.Click();
            myLibPage.FileUpload(@"TestDataFiles\InvalidThub.png");
            Thread.Sleep(1000);
            Assert.AreEqual(ErrorMessage.ThumbnailErrorMsg, GenericHelper.GetElement(By.XPath("//input[@id='thumbnailFile']/following-sibling::div[position()=1]/span")).Text.Trim());
            myLibPage.Logout();

        }

        [TestMethod]
        [DeploymentItem("Resources")]
        public void TestEditAsset()
        {
            var myLibPage = hPage.NavigateToLibrary();
            myLibPage.EditAsset(3);
            Thread.Sleep(1000);
            myLibPage.Save.ScrollElementAndClick();
            GenericHelper.WaitForLoadingMask();
            Thread.Sleep(1000);
            Assert.IsTrue(GenericHelper.IsTextPresent("Asset saved successfully")," Success Message not found ");
            myLibPage.Logout();

        }

        [TestMethod]
        [DeploymentItem("Resources")]
        public void TestDeleteAsset()
        {
            var myLibPage = hPage.NavigateToLibrary();
            myLibPage.DeleteAsset(3);
            Thread.Sleep(1000);
            GenericHelper.WaitForLoadingMask();
            Thread.Sleep(1000);
            myLibPage.Logout();

        }

        [TestMethod]
        [Description("Test case for searching the pptx file")]
        public void TestSearchPptx()
        {
            var myLibPage = hPage.NavigateToLibrary();
            myLibPage.Search("pptx");
            GenericHelper.WaitForLoadingMask();
            // Suplly the index value to check the asset
            Assert.IsTrue(myLibPage.ValiateIsAssetPresent(1),"Asset Not Found ");
            // Suplly the index value to check the asset title
            Assert.AreEqual(myLibPage.GetAssetName(1), "Presentation2.pptx");
            // Suplly the index value to check the asset description
            Assert.AreEqual(myLibPage.GetAssetDescription(1), "PPTTest");
            myLibPage.Logout();
        }

        [TestMethod]
        [Description("Test case for searching the docx file")]
        public void TestSearchDocx()
        {
            var myLibPage = hPage.NavigateToLibrary();
            // use this method to suppply the search parameter : "search text","sort by","view by"
            // If you don't supply any thing it will use "docx","Last Created Date","Document"
            myLibPage.Search("docx", "Start Date", "Documents");
            GenericHelper.WaitForLoadingMask();
            Assert.IsTrue(myLibPage.ValiateIsAssetPresent(1), "Asset Not Found ");
            Assert.AreEqual(myLibPage.GetAssetName(1), "Test3.docx");
            myLibPage.Logout();
        }

        [TestMethod]
        public void TestUserView()
        {
            var viewPage = hPage.NavigateToLibrary().NavigateToLibrarySearch();
            viewPage.SelectViewBy("Documents");
            // Specify the "Search String" & "View by"
            //viewPage.Search("adas","Documents");
            Assert.IsTrue(viewPage.IsViewButtonHidden(1)," View Button is <Visible> Expected is <Hidden>");
            Assert.IsTrue(viewPage.IsViewButtonHidden(2), " View Button is <Visible> Expected is <Hidden>");
            Assert.IsTrue(viewPage.IsViewButtonVisible(3), " View Button is <Hidden> Expected is <Visible>");
            Assert.IsTrue(viewPage.IsDownloadButtonVisible(3), " Download Button is <Hidden> Expected is <Visible>");
            Assert.IsTrue(viewPage.IsDownloadButtonHidden(4), " Download Button is <Visible> Expected is <Hidden>");
            // To click on download button in asset container
            viewPage.ClickDownloadButton(3);
            // To click on View button in asset container
            viewPage.ClickViewButton(3);
            viewPage.Logout();
        }
    }
}
