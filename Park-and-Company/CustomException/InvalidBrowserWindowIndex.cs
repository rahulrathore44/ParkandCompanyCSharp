using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_and_Company.CustomException
{
    public class InvalidBrowserWindowIndex : Exception
    {
        public InvalidBrowserWindowIndex(string msg) : base(msg) { }
    }
}
