using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Park_and_Company.BaseClasses.LoginBaseClass;
using Park_and_Company.ComponentHelper;
using Park_and_Company.ExtensionClass.WebElementExtClass;

namespace Park_and_Company.TestCases.Learn.Library
{
    [TestClass]
    public class TestManageLibrary : LoginBase
    {

        [TestMethod]
        [DeploymentItem("Resources")]
        public void ManageLibrary()
        {
            var myLibPage = hPage.NavigateToLibrary();
            myLibPage.DropBox.ScrollElementAndClick();
            myLibPage.FileUpload(@"TestDataFiles\Title.docx");
            Thread.Sleep(1000);
            //myLibPage.UploadBtn.ScrollElementAndClick();
            myLibPage.Name.SendKeys("TestDocFile");
            myLibPage.Description.SendKeys("TestDocDescription");
            myLibPage.Browse.Click();
            myLibPage.FileUpload(@"TestDataFiles\Thub.png"); 
            
            DropDownHelper.SelectByVisibleText(myLibPage.EligibleGroup, "AssetGroup");
            DropDownHelper.SelectByVisibleText(myLibPage.Language, "Afrikaans");
            myLibPage.SearchTags.SendKeys("TestOne");
            DropDownHelper.SelectByVisibleText(myLibPage.ChooseFamily,"test");
            myLibPage.CreateNewFamily.SendKeys("New Family");
            myLibPage.IsDownloadable.ScrollElementAndClick();
            Thread.Sleep(5000);
            myLibPage.Logout();
           
        }
    }
}
