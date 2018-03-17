using LojaGeek.Model.DB;
using LojaGeek.Model.DB.Model;
using LojaGeek.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaGeek.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult CadastrarCliente()
        {
            return View(new Cliente());
        }

        public ActionResult EntrarCliente()
        {
            return View();
        }

        public ActionResult Logar(string email, string senha)
        {
            LoginUtils.Logar(email, senha);

            if (LoginUtils.Cliente != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("EntrarCliente");
            }
        }

        public ActionResult DeslogarCliente()
        {
            LoginUtils.Deslogar();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult GravarCliente(Cliente cliente)
        {
                DbFactory.Instance.ClienteRepository.SaveOrUpdate(cliente);
                return RedirectToAction("EntrarCliente");
        }
    }
}