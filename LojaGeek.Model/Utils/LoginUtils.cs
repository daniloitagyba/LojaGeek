using LojaGeek.Model.DB;
using LojaGeek.Model.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LojaGeek.Model.Utils
{
    public class LoginUtils
    {
        public static Cliente Cliente
        {
            get
            {
                if (HttpContext.Current.Session["Usuario"] != null)
                {
                    return (Cliente)HttpContext.Current.Session["Usuario"];
                }
                else
                    return null;
            }
        }

        public static void Logar(string email, string senha)
        {
            var cliente = DbFactory.Instance.ClienteRepository.Login(email, senha);
            if (cliente != null)
            {
                HttpContext.Current.Session["Usuario"] = cliente;
            }
        }

        public static void Deslogar()
        {
            HttpContext.Current.Session["Usuario"] = null;
            HttpContext.Current.Session.Remove("Usuario");
        }
    }
}
