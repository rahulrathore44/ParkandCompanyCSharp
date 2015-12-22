using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Park_and_Company.PageObject;
using Park_and_Company.Settings;

namespace Park_and_Company.BaseClasses.LoginBaseClass
{
    public class LoginBase
    {
        protected LoginPage lpage;
        protected HomePage hPage;
      
        public LoginBase()
        {
            lpage = new LoginPage(ObjectRepository.Driver);
            hPage = lpage.LoginApplication(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
        }
    }
}
