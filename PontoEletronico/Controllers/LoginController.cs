using System;
using System.Web.Mvc;
using PontoEletronico.Models;
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
                if (ModelState.IsValid)
                {
                    var response = APIService.PostAPI(loginModel, "Accounts");

                    if (response.IsSuccessStatusCode)
                    {
                        string serializeObject = response.Content.ReadAsStringAsync().Result;

                        TokenModel post = JsonConvert.DeserializeObject<TokenModel>(serializeObject);

                        Response.AppendCookie(PontoEletronico.Session.Cookie.ArmazenaToken(post));

                        return RedirectToAction("Index", "Home");
                    }
                    TempData["MensagemErro"] = "Usuário ou senha inválido.";
                }
                return RedirectToAction("Login", "Home");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Erro ao realizar login \n" + erro.Message;
                return RedirectToAction("Login", "Home");
            }
        }
    }
}