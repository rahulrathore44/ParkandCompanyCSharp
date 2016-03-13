using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Park_and_Company.ComponentHelper
{
    public class GridHelper
    {
        #region Internal

        internal static string GetGridHeaderXpath(string gridXpath, int row, int column)
        {
            return string.Format("{0}//table//thead//tr[{1}]//th[{2}]", gridXpath, row, column);
        }

        internal static string GetGridElementXpath(string gridXpath, int row, int column)
        {
            return string.Format("{0}//table//tbody//tr[{1}]//td[{2}]", gridXpath, row, column);
        }

        #endregion

        #region Public

        public static void VerifyIncentiveGridEntry(string gridXpath, string program, string startDate, string endDate,
            string status)
        {
            for (var i = 1; i <= 100; i++)
            {
                if (!GenericHelper.IsElementPresentQuick(By.XPath(gridXpath + "//table//tbody//tr[" + i + "]//td[1]/a")))
                    continue;

                Assert.AreEqual(
                    GenericHelper.GetText(By.XPath(gridXpath + "//table//tbody//tr[" + i + "]//td[1]/a")), program);
                Assert.AreEqual(
                    GenericHelper.GetText(By.XPath(gridXpath + "//table//tbody//tr[" + i + "]//td[2]")), startDate);
                Assert.AreEqual(
                    GenericHelper.GetText(By.XPath(gridXpath + "//table//tbody//tr[" + i + "]//td[3]")), endDate);
                Assert.AreEqual(
                    GenericHelper.GetText(By.XPath(gridXpath + "//table//tbody//tr[" + i + "]//td[4]/span")), status);
            }
        }

        public static IWebElement GetGridHeaderElement(string gridXpath, int row, int column)
        {
               return GenericHelper.IsElementPresentQuick(
                    By.XPath(GetGridHeaderXpath(gridXpath,row,column))) ? GenericHelper.GetElement(By.XPath(GetGridHeaderXpath(gridXpath, row, column))) : null;

        }

        public static string GetGridHeaderText(string gridXpath, int row, int column)
        {
            return GetGridHeaderElement(gridXpath, row, column).Text;
        }

        public static string GetGridElementText(string gridXpath, int row, int column)
        {
            return GetGridElement(gridXpath, row, column).Text;
        }

        public static IWebElement GetGridElement(string gridXpath, int row, int column)
        {
            if (
                GenericHelper.IsElementPresentQuick(
                    By.XPath(GetGridElementXpath(gridXpath,row,column) + "/a")))
            {
                return GenericHelper.GetElement(By.XPath(GetGridElementXpath(gridXpath, row, column) + "/a"));
            }

            if (
                GenericHelper.IsElementPresentQuick(
                    By.XPath(GetGridElementXpath(gridXpath, row, column) + "/span")))
            {
                return GenericHelper.GetElement(By.XPath(GetGridElementXpath(gridXpath, row, column) + "/span"));
            }

            if (
               GenericHelper.IsElementPresentQuick(
                   By.XPath(GetGridElementXpath(gridXpath, row, column) + "/input")))
            {
                return GenericHelper.GetElement(By.XPath(GetGridElementXpath(gridXpath, row, column) + "/input"));
            }

            return GenericHelper.IsElementPresentQuick(
                By.XPath(GetGridElementXpath(gridXpath, row, column))) ? GenericHelper.GetElement(By.XPath(GetGridElementXpath(gridXpath, row, column))) : null;
        }

        public static void VerifyInGridEntry(string gridXpath, string value, int row,int column)
        {
            var element = GetGridElement(gridXpath, row, column);
            if (element != null)
            {
                Assert.AreEqual(element.Text,value);
            }
            else
            {
                Assert.Fail("Expected Value Not Found : {0}",value);
            }
        }
        
        public static void ClickVerifyBtnInGrid(string gridXpath, int row, int column)
        {
            if (!GenericHelper.IsElementPresentQuick(
                By.XPath(GetGridElementXpath(gridXpath, row, column) + "//i[2]")))
                return;

            var element =
                GenericHelper.GetElement(
                    By.XPath(GetGridElementXpath(gridXpath, row, column) + "//i[2]"));
            element.Click();
            GenericHelper.WaitForLoadingMask();
        }

        public static void ClickDeleteBtnInGrid(string gridXpath, int row, int column)
        {
            var element = GetGridElement(gridXpath, row, column);
            element?.Click();
            GenericHelper.WaitForLoadingMask();               
        }

        #endregion

    }
}
