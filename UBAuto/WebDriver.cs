using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;

namespace UBAuto
{
    public class WebDriver
    {
        public static IWebDriver Driver = new ChromeDriver();   
    }
}
