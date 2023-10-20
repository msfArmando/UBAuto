using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace UBAuto
{
    public class Custom : WebDriver
    {
        public static IWebElement TryFindElementByXpathWithAttempts(int tries, int secs, string path)
        {
            var times = 0;
            do
            {
                try
                {
                    return Driver.FindElement(By.XPath(path));
                }
                catch (Exception)
                {
                    times++;
                    Thread.Sleep(secs*1000);
                }
            } while (times < tries);
            throw new Exception("Elemento não encontrado");
        }

        public static void WaitForLoadPage(string path)
        {
            //TODO
            //WAITFORLOADPAGE
        }
    }
}
