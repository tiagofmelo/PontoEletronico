using System;
using System.Net;
using System.Web.Mvc;
using PontoEletronico.Models;
using PontoEletronico.Session;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using PontoEletronico.Service;

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
                if (Request.Cookies["tokenModel"] == null)
                {
                    if (ModelState.IsValid)
                    {
                        var response = APIService.PostAPI(loginModel, "Accounts");

                        if (response.IsSuccessStatusCode)
                        {
                            string serializeObject = response.Content.ReadAsStringAsync().Result;

                            TokenModel post = JsonConvert.DeserializeObject<TokenModel>(serializeObject);

                            Response.AppendCookie(PontoEletronico.Session.Session.ArmazenaToken(post));

                            return RedirectToAction("Index", "Home");
                        }
                    }
                    return RedirectToAction("Login", "Home");
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Erro ao realizar login \n" + erro.Message;
                return RedirectToAction("Login", "Home");
            }
        }
    }
}