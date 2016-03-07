using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Park_and_Company.BaseClasses;

namespace Park_and_Company.PageObject.Learn.Library
{
    public class LibrarySearchDetailPage : PageBase
    {

        #region Field

        private IWebDriver _driver;

        #endregion

        #region Constructor

        public LibrarySearchDetailPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }


        #endregion

        #region WebElements

         

        #endregion
    }
}
