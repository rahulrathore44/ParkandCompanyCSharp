using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Park_and_Company.ComponentHelper
{
    public class GridHelper
    {
        public static void VerifyIncentiveGridEntry(string gridXpath, string program, string startDate, string endDate,
            string status)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (GenericHelper.IsElementPresent(By.XPath(gridXpath + "//table//tbody//tr[" + i + "]//td[1]/a")))
                {
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
        }

        public static void VerifyInGridEntry(string gridXpath, string value, int row,int column)
        {
            Assert.AreEqual(GenericHelper.GetText(By.XPath(gridXpath + "//table//tbody//tr[" + row + "]//td[" + column + "]/span")), value);
        }


    }
}
