using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.PageObjects;

namespace Park_and_Company
{

    public class A
    {
        public virtual Type GetClassType()
        {
            return GetType();
        }
    }
    [TestClass]
    public class Class1 : A
    {
        [TestMethod]
        public void TestMethod()
        {
            var T = Type.GetType("Park_and_Company.PageObject.HomePage");
            var fields =  T.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var f in fields)
            {
                if (!f.Name.Contains("driver"))
                {
                    Console.WriteLine("Name : {0}, Attributes : {1}", f.Name, f.GetCustomAttributes(typeof(FindsByAttribute)));
                    var cusAttri = f.GetCustomAttributes(typeof (FindsByAttribute));
                    var ele = (FindsByAttribute)cusAttri.ElementAtOrDefault(0);
                    if (ele != null)
                    {
                        var a = Enum.Parse(typeof(How), ele.How.ToString());
                    }
                }
            }
            var T2 = GetClassType();
            Console.WriteLine("Full Name : {0}, Name : {1}",T2.FullName,T2.Name);

        }
        
    }
}
