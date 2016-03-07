using System;
using System.Threading;
using OpenQA.Selenium;
using Park_and_Company.Settings;

namespace Park_and_Company.ComponentHelper
{
    public class CalenderHelper
    {
        private static void ClickHeader(string tableXPath)
        {
            ObjectRepository.Driver.FindElement(By.XPath(tableXPath + "/thead/tr[1]//strong")).Click();
            Thread.Sleep(500);
        }

        private static void SelectMonth(string tableXPath, string month)
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    if (GenericHelper.IsElementPresentQuick(By.XPath(tableXPath + "/tbody/tr[" + i + "]/td[" + j + "]//span")))
                    {
                        string aMonth = ObjectRepository.Driver.FindElement(By.XPath(tableXPath + "/tbody/tr[" + i + "]/td[" + j + "]//span")).Text;
                        if (month.Equals(aMonth,StringComparison.OrdinalIgnoreCase))
                        {
                            ObjectRepository.Driver.FindElement(By.XPath(tableXPath + "/tbody/tr[" + i + "]/td[" + j + "]//span")).Click();
                            return;
                        }
                    }
                }
            }
        }

        private static void SelectYear(string tableXPath, string year)
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    if (GenericHelper.IsElementPresentQuick(By.XPath(tableXPath + "/tbody/tr[" + i + "]/td[" + j + "]//span")))
                    {
                        string aYear = ObjectRepository.Driver.FindElement(By.XPath(tableXPath + "/tbody/tr[" + i + "]/td[" + j + "]//span")).Text;
                        if (year.Equals(aYear,StringComparison.OrdinalIgnoreCase))
                        {
                            ObjectRepository.Driver.FindElement(By.XPath(tableXPath + "/tbody/tr[" + i + "]/td[" + j + "]//span")).Click();
                            return;
                        }
                    }
                }
            }
        }

        private static void SelectDay(string tableXPath, string day)
        {
            for (int i = 1; i <= 6; i++)
            {
                for (int j = 2; j <= 8; j++)
                {
                    if (GenericHelper.IsElementPresentQuick(By.XPath(tableXPath + "/tbody/tr[" + i + "]/td[" + j + "]//span")))
                    {
                        var xpath = tableXPath + "/tbody/tr[" + i + "]/td[" + j + "]//span";
                        var aday = ObjectRepository.Driver.FindElement(By.XPath(xpath)).Text;
                        if (day.Equals(aday,StringComparison.OrdinalIgnoreCase))
                        {
                            if (
                                !ObjectRepository.Driver.FindElement(By.XPath(xpath))
                                    .GetAttribute("class")
                                    .Contains("text-muted"))
                            {
                                ObjectRepository.Driver.FindElement(By.XPath(xpath)).Click();
                                return;
                            }
                               
                        }
                    }
                }
            }
        }

        public static void SelectDate(string tableXPath, string day, string month, string year) 
        {
            ClickHeader(tableXPath);
            Thread.Sleep(500);
            ClickHeader(tableXPath);
            Thread.Sleep(500);
            SelectYear(tableXPath, year);
            Thread.Sleep(500);
            SelectMonth(tableXPath, month);
            Thread.Sleep(500);
            SelectDay(tableXPath, day);
            Thread.Sleep(500);

        }
    }
}
