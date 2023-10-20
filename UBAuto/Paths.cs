using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBAuto
{
    public class Paths
    {
        public static string CorpPath = "//input[contains(@placeholder, 'Conta')]";
        public static string EmailPath = "//input[contains(@placeholder, 'Seu email')]";
        public static string PasswordPath = "//input[contains(@placeholder, 'Senha')]";
        public static string ButtonSubmitPath = "//button[contains(@type, 'submit')]";
        public static string VerifyHtml = "//h1[contains(., 'Meu Painel')]";
        public static string TicketInputPath = "//input[contains(@id, 'pesquisa-site')]";
        public static string NavTab = "//ul[contains(@class, 'nav nav-tabs')]";
    }
}
