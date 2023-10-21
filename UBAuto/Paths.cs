using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBAuto
{
    public class Paths
    {
        public static string CpfInput = "//input[contains(@name, 'CPF')]";
        public static string EmailPath = "//input[contains(@placeholder, 'Seu email')]";
        public static string PasswordPath = "//input[contains(@placeholder, 'Senha')]";
        public static string ButtonSubmitPathLogin = "/html/body/app-root/ion-app/ion-router-outlet/app-login/ion-content/div/div/div/form/ion-button[1]";
        public static string VerifyHtml = "//h1[contains(., 'Meu Painel')]";
        public static string TicketInputPath = "//input[contains(@id, 'pesquisa-site')]";
        public static string NavTab = "//ul[contains(@class, 'nav nav-tabs')]";
        public static string SumPath = "//div[contains(@class, 'instruction')]/span";
        public static string ResultInput = "//ion-input[contains(@type, 'number')]/input";
        public static string ResultButton = "//*[@id=\"ion-overlay-1\"]/app-modal-login/ion-content/div/ion-button";
        public static string RegisterButton = "//ion-button[contains(., 'INSCREVA-SE')]";

        public static string LogOutButton = "//ion-icon[contains(@name, 'log-out-outline')]";

        public static string NomeCompleto = "//input[contains(@placeholder, 'Nome Completo')]";
        public static string Cpf = "//ion-input[contains(@formcontrolname, 'CPF')]/input[contains(@placeholder, '000.000.000-00')]";
        public static string Contato = "//ion-input[contains(@formcontrolname, 'TELEFONE')]/input[contains(@aria-labelledby, 'ion-input-4-lbl')]";
        public static string Email = "//input[contains(@placeholder, 'seuemail@exemplo.com')]";
        public static string DataNascimento = "//input[contains(@placeholder, 'dd/mm/yyyy')]";
        public static string DocIdentificação = "//ion-select[contains(@formcontrolname, 'DOCIDENTIFICACAO')]";
        public static string SelecionarRg = "//button[contains(., 'RG')]";
        public static string NumRG = "//input[contains(@placeholder, 'NÚMERO DO RG')]";
        public static string DataEmissao = "//ion-input[contains(@formcontrolname, 'DATAEMISSAO')]/input";
        public static string OrgaoEmissor = "//ion-input[contains(@formcontrolname, 'ORGAOEMISSOR')]/input";
        public static string Interesses = "//ion-select[contains(@placeholder, 'Forma de ingresso')]";
        public static string SelecionarInteresse = "//button[contains(., 'Vestibular Online')]";
        public static string Agendamento = "//ion-select[contains(@placeholder, 'Agendamentos')]";
        public static string SelectAgendamento = "//button[contains(., '[22/10] MEGA VESTIBULAR')]";
        public static string PrimeiraOpcao = "//ion-select[contains(@formcontrolname, 'CURSOUM')]";
        public static string SegundaOpcao = "//ion-select[contains(@formcontrolname, 'CURSODOIS')]";
        public static string BtnDireito = "//button[contains(., 'DIREITO')]";
        public static string BtnBiomedicina = "//button[contains(., 'BIOMEDICINA')]";
        public static string Turnos = "//ion-select[contains(@formcontrolname, 'TURNOS')]";
        public static string SelectNoite = "//button[contains(., 'Noite')]";
        public static string BtnOk = "//button[contains(., 'OK')]";
        public static string CheckBox = "//ion-checkbox[contains(@formcontrolname, 'IDTERMOSACEITE')]";
        public static string FinalizarInscBtn = "//ion-button[contains(., 'Finalizar Inscrição')]";
        public static string ReturnToLoginButton = "//ion-button[contains(., 'Ir para login')]";

        public static string BtnContinue = "//ion-button[contains(., 'Continuar')]";
        public static string BtnFazerProva = "//ion-button[contains(., 'FAZER PROVA')]";
        public static string Questions = "//section[contains(@class, 'questao')]/div[contains(@class, 'alternativas')]/div[contains(@class, 'alternativa')]/label/span";
    }
}
