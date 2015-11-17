using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Park_and_Company.Settings;

namespace Park_and_Company.ComponentHelper
{
    public class BrowserHelper
    {
        public static void GoBack()
        {
            ObjectRepository.Driver.Navigate().Back();
        }
    }
}
