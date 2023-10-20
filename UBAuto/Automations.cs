using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace UBAuto
{
    public class Automations : Custom
    {
        public static IWebElement? CorpInput { get; private set; }
        public static IWebElement? EmailInput { get; private set; }
        public static IWebElement? PassWord { get; private set; }
        public static IWebElement? SubmitButton { get; private set; }

        public void OpenDriver()
        {
            Driver.Navigate().GoToUrl("https://painel.tomticket.com/painel.html#!/");
            Driver.Manage().Window.Maximize();
        }

        public void Login(string corp, string email, string password)
        {
            try
            {
                CorpInput = TryFindElementByXpathWithAttempts(5, 2, Paths.CorpPath);
                EmailInput = TryFindElementByXpathWithAttempts(5, 2, Paths.EmailPath);
                PassWord = TryFindElementByXpathWithAttempts(5, 2, Paths.PasswordPath);
                SubmitButton = TryFindElementByXpathWithAttempts(5, 2, Paths.ButtonSubmitPath);

                CorpInput.SendKeys(corp);
                EmailInput.SendKeys(email);
                PassWord.SendKeys(password);

                //ToDo
                //TryClickElement();
                SubmitButton.Click();

                VerifyLogin();
            }
            catch (Exception ex)
            {
                CorpInput?.Clear();
                EmailInput?.Clear();
                PassWord?.Clear();
                throw new Exception(ex.Message);
            }
        }

        public void VerifyLogin()
        {
            try
            {
                TryFindElementByXpathWithAttempts(5, 2, Paths.VerifyHtml);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao tentar efetuar Login!");
            }
        }

        public void SearchTicket(string numTicket)
        {
            try
            {
                var inputTicket = TryFindElementByXpathWithAttempts(5, 2, Paths.TicketInputPath);
                inputTicket.SendKeys(numTicket);
                inputTicket.SendKeys(Keys.Enter);

                WaitForLoadPage(Paths.NavTab);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            Driver.Dispose();
            Driver.Quit();
        }

        public void Quit()
        {
            Driver.Close();
        }
    }
}
