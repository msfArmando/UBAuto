using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;

namespace UBAuto
{
    public class Program
    {
        public static int LoginTries = 0;
        public static void Main(string[] args)
        {
            Automations auto = new Automations();
            auto.OpenDriver();

            do
            {
                try
                {
                    Console.WriteLine("Corporação: ");
                    var corp = Console.ReadLine();
                    Console.WriteLine("Email: ");
                    var email = Console.ReadLine();
                    Console.WriteLine("Senha: ");
                    var senha = Console.ReadLine();

                    auto.Login(corp, email, senha);

                    Console.WriteLine("Ticket: ");
                    var ticketNum = Console.ReadLine();
                    auto.SearchTicket(ticketNum);
                }
                catch (Exception)
                {
                    LoginTries++;
                }
            } while (LoginTries < 10);
        }
    }
}