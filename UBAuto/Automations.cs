using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Linq.Expressions;
using System.Xml.Linq;
using System.Net;
using System.Globalization;

namespace UBAuto
{
    public class Automations : Custom
    {
        public static IWebElement? CpfInput { get; private set; }
        public static IWebElement? SubmitButton { get; private set; }
        public static string Cpf => Program.Cpf;
        public static string CpfRequest { get; set; }

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

                var orgaoEmissor = TryFindElementByXpathWithAttempts(5, 2, Paths.OrgaoEmissor);
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", orgaoEmissor);
                orgaoEmissor.SendKeys("SDS");

                var interesses = TryFindElementByXpathWithAttempts(5, 2, Paths.Interesses);
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", interesses);
                TryClickElement(5, 5, interesses);

                var ingresso = TryFindElementByXpathWithAttempts(5, 2, Paths.SelecionarInteresse);
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", ingresso);
                TryClickElement(5, 5, ingresso);

                var agendamento = TryFindElementByXpathWithAttempts(5, 2, Paths.Agendamento);
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", agendamento);
                TryClickElement(5, 5, agendamento);

                Thread.Sleep(2000);

                var selectAgendamento = TryFindElementByXpathWithAttempts(5, 2, Paths.SelectAgendamento);
                TryClickElement(5, 5, selectAgendamento);

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

                Thread.Sleep(1000);

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

                SubmitButton.Click();

                PassQuest();

                if (!VerifyLogin())
                {
                    Cadastro();
                    var btnBackToLogin = TryFindElementByXpathWithAttempts(5, 5, Paths.ReturnToLoginButton);
                    TryClickElement(5, 5, btnBackToLogin);
                }
                else if (Driver.PageSource.Contains("Bem-vindo (a)") ||
                    Driver.PageSource.Contains("Seja bem-vindo(a) a trilha UNIBRA"))
                {
                    ProcessoVestibular();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool VerifyLogin()
        {
            if(TryFindElementByXpathWithAttemptsThrowNull(5, 2, Paths.LogOutButton) == null &&
                !Driver.PageSource.Contains("Seja bem-vindo(a) a trilha UNIBRA"))
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

        public static void ProcessoVestibular()
        {
            if (TryFindElementByXpathWithAttemptsThrowNull(7, 1, Paths.BtnContinue) != null)
            {
                var btnContinue = TryFindElementByXpathWithAttempts(5, 1, Paths.BtnContinue);
                TryClickElement(5, 5, btnContinue);
            }

            if (TryFindElementByXpathWithAttempts(7, 1, Paths.BtnFazerProva) != null)
            {
                var btnFazerProva = TryFindElementByXpathWithAttempts(5, 1, Paths.BtnFazerProva);
                TryClickElement(5, 5, btnFazerProva);
            }

            List<IWebElement> Questions = new List<IWebElement>();
            Questions = (List<IWebElement>)TryFindElementByXpathWithAttemptsThrowNull(5, 2, Paths.Questions);
        }

        public string SendPostRequest()
        {
            CookieContainer cookieContainer = AutomationCookies.GetCookies();

            string cpfForm = "acao=gerar_cpf&pontuacao=N&cpf_estado=";

            byte[] cpfBytes = Encoding.ASCII.GetBytes(cpfForm);

            try
            {
                HttpWebRequest requestWeb = (HttpWebRequest)HttpWebRequest.Create("https://www.4devs.com.br/ferramentas_online.php ");
                requestWeb.Method = "POST";
                requestWeb.ProtocolVersion = new Version(1, 1);
                requestWeb.Host = "www.4devs.com.br";
                requestWeb.KeepAlive = true;
                requestWeb.ContentLength = 38;
                requestWeb.Headers.Add("sec-ch-ua", "Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Opera GX\";v=\"102");
                requestWeb.Accept = "*/*";
                requestWeb.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                requestWeb.Headers.Add("X-Requested-With", "XMLHttpRequest");
                requestWeb.Headers.Add("sec-ch-ua-mobile", "?0");
                requestWeb.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36 OPR/102.0.0.0");
                requestWeb.Headers.Add("sec-ch-ua-platform", "Windows");
                requestWeb.Headers.Add("Origin", "https://www.4devs.com.br");
                requestWeb.Headers.Add("Sec-Fetch-Site", "same-origin");
                requestWeb.Headers.Add("Sec-Fetch-Mode", "cors");
                requestWeb.Headers.Add("Sec-Fetch-Dest", "empty");
                requestWeb.Referer = "https://www.4devs.com.br/gerador_de_cpf";
                requestWeb.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                requestWeb.Headers.Add(HttpRequestHeader.AcceptLanguage, "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");
                requestWeb.AutomaticDecompression = DecompressionMethods.GZip;

                requestWeb.CookieContainer = cookieContainer;

                using (var stream = requestWeb.GetRequestStream())
                {
                    stream.Write(cpfBytes, 0, cpfBytes.Length);
                }

                WebResponse response = requestWeb.GetResponse();

                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                throw new Exception("HTTPREQUESTERROR");
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
