using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using System.ComponentModel.DataAnnotations;

namespace UBAuto
{
    public class Program
    {
        public static int LoginTries = 0;
        public static string Cpf = string.Empty;
        public static void Main(string[] args)
        {
            try
            {
                List<string> listaCPFs = new List<string>();
                Automations auto = new Automations();

                for (int i = 0; i < 300; i++)
                {
                    listaCPFs.Add(auto.SendPostRequest());
                }

                foreach (string cpf in listaCPFs)
                {
                    auto.SendPostRequest();
                    auto.OpenDriver();

                    do
                    {
                        try
                        {
                            Cpf = cpf;
                            Automations.Login(Cpf);
                            continue;
                        }
                        catch (Exception)
                        {
                            LoginTries++;
                        }
                    } while (LoginTries < 10);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}