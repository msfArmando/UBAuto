using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace UBAuto
{
    public class Automations : Custom
    {
        public static IWebElement? CpfInput { get; private set; }
        public static IWebElement? SubmitButton { get; private set; }
        public static string Cpf => Program.Cpf;

        public void OpenDriver()
        {
            Driver.Navigate().GoToUrl("https://vestibular.grupounibra.com/TWluaGEgcGlwYQ==/login");
            Driver.Manage().Window.Maximize();
        }

        public static void Cadastro()
        {
            try
            {
                Thread.Sleep(1000);

                TryFindElementByXpathWithAttempts(5, 2, Paths.RegisterButton).Click();

                TryFindElementByXpathWithAttempts(5, 2, Paths.NomeCompleto).SendKeys("Armando Monsão da Silva Filho");
                TryFindElementByXpathWithAttempts(5, 2, Paths.Cpf).SendKeys(Cpf);
                TryFindElementByXpathWithAttempts(5, 2, Paths.Contato).SendKeys("81983906576");
                TryFindElementByXpathWithAttempts(5, 2, Paths.Email).SendKeys("armandomonsaof@gmail.com");
                TryFindElementByXpathWithAttempts(5, 2, Paths.DataNascimento).SendKeys("03042004");

                var docIdentificacao = TryFindElementByXpathWithAttempts(5, 2, Paths.DocIdentificação);
                TryClickElement(5, 5, docIdentificacao);

                var selectRG = TryFindElementByXpathWithAttempts(5, 2, Paths.SelecionarRg);
                selectRG.Click();

                TryFindElementByXpathWithAttempts(5, 2, Paths.NumRG).SendKeys("10199738");
                TryFindElementByXpathWithAttempts(5, 2, Paths.DataEmissao).SendKeys("21122021");
                TryFindElementByXpathWithAttempts(5, 2, Paths.OrgaoEmissor).SendKeys("SDS");
                TryFindElementByXpathWithAttempts(5, 2, Paths.Interesses).Click();

                var ingresso = TryFindElementByXpathWithAttempts(5, 2, Paths.SelecionarInteresse);
                TryClickElement(5, 5, ingresso);
                TryFindElementByXpathWithAttempts(5, 2, Paths.Agendamento).Click();
                var agendamento = TryFindElementByXpathWithAttempts(5, 2, Paths.SelectAgendamento);
                TryClickElement(5, 5, agendamento);

                var primeiraOpcao = TryFindElementByXpathWithAttempts(5, 2, Paths.PrimeiraOpcao);
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", primeiraOpcao);
                TryClickElement(5, 5, primeiraOpcao);

                var btnDireito = TryFindElementByXpathWithAttempts(5, 2, Paths.BtnDireito);
                TryClickElement(5, 5, btnDireito);

                Thread.Sleep(2000);

                var segundaOpcao = TryFindElementByXpathWithAttempts(5, 2, Paths.SegundaOpcao);
                TryClickElement(5, 5, segundaOpcao);

                var btnBiomedicina = TryFindElementByXpathWithAttempts(5, 2, Paths.BtnBiomedicina);
                TryClickElement(5, 5, btnBiomedicina);

                var turnos = TryFindElementByXpathWithAttempts(5, 2, Paths.Turnos);
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", turnos);
                TryClickElement(5, 5, turnos);

                TryFindElementByXpathWithAttempts(5, 2, Paths.SelectNoite).Click();
                TryFindElementByXpathWithAttempts(5, 2, Paths.BtnOk).Click();

                var checkBox = TryFindElementByXpathWithAttempts(5, 2, Paths.CheckBox);
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", checkBox);
                TryClickElement(5, 5, checkBox);

                var fimInscBtn = TryFindElementByXpathWithAttempts(5, 2, Paths.FinalizarInscBtn);
                TryClickElement(5, 5, fimInscBtn);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void Login(string cpf)
        {
            try
            {
                CpfInput = TryFindElementByXpathWithAttempts(5, 2, Paths.CpfInput);
                SubmitButton = TryFindElementByXpathWithAttempts(5, 2, Paths.ButtonSubmitPathLogin);

                CpfInput.SendKeys(cpf);

                //ToDo
                //TryClickElement();
                SubmitButton.Click();

                PassQuest();

                if (!VerifyLogin())
                {
                    Cadastro();
                    var btnBackToLogin = TryFindElementByXpathWithAttempts(5, 5, Paths.ReturnToLoginButton);
                    TryClickElement(5, 5, btnBackToLogin);
                }
                Login(cpf);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool VerifyLogin()
        {
            if(TryFindElementByXpathWithAttemptsThrowNull(5, 2, Paths.NullUserError) != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void PassQuest()
        {
            string htmlText = TryFindElementByXpathWithAttempts(5, 2, Paths.SumPath).Text;
            string[] expression = htmlText.Split(new char[] { '+', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string firstNum = expression[0];
            string secondNum = expression[1];
            long result = Convert.ToInt64(firstNum) + Convert.ToInt64(secondNum);

            TryFindElementByXpathWithAttempts(5, 2, Paths.ResultInput).SendKeys(result.ToString());
            TryFindElementByXpathWithAttempts(5, 2, Paths.ResultButton).Click();
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
