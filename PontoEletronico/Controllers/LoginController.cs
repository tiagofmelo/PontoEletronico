using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PontoEletronico.Models;

namespace PontoEletronico.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Login", "Home");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Erro ao realizar login \n" + erro.Message;
                return RedirectToAction("Index");
            }
        }
    }
}