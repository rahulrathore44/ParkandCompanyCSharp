using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Park_and_Company.ComponentHelper;
using Park_and_Company.PageObject;
using Park_and_Company.Settings;

namespace Park_and_Company.BaseClasses.LoginBaseClass
{
    public class LoginBase
    {
        protected ILog Logger;
        protected LoginPage Lpage;
        protected HomePage HPage;
      
        public LoginBase()
        {
            Logger = LoggerHelper.GetLogger(GetType());
            Lpage = new LoginPage(ObjectRepository.Driver);
            HPage = Lpage.LoginApplication(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            Logger.Info("Test Execution Started");
        }
    }
}
