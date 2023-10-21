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
            List<string> listaCPFs = new List<string>
        {
            "35737691870", "33554507822", "26050431850", "4450232950",
            "32175417824", "25221816881", "35445900851", "33441877837",
            "15681075877", "11142760812", "5221555964", "18219822821",
            "11063139424"
        };

            foreach (string cpf in listaCPFs)
            {
                Automations auto = new Automations();
                auto.OpenDriver();

                do
                {
                    try
                    {
                        //Cpf = Console.ReadLine();
                        Cpf = cpf;
                        Automations.Login(Cpf);

                    }
                    catch (Exception)
                    {
                        LoginTries++;
                    }
                } while (LoginTries < 10);
            }
        }
    }
}