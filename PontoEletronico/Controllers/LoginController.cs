using System;
using System.Net;
using System.Web.Mvc;
using PontoEletronico.Models;
using PontoEletronico.Session;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace PontoEletronico.Controllers
{
    public class LoginController : Controller
    {
        string url = System.Configuration.ConfigurationManager.AppSettings["urlApi"];

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string serializeObject = responsePost(loginModel, "Accounts");

                    TokenModel post = JsonConvert.DeserializeObject<TokenModel>(serializeObject);

                    HttpContext.Response.SetCookie(PontoEletronico.Session.Session.ArmazenaToken(post));

                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Login", "Home");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Erro ao realizar login \n" + erro.Message;
                return RedirectToAction("Login", "Home");
            }
        }

        public string responsePost(object serializeObject, string endPoint)
        {
            var postLoginModel = JsonConvert.SerializeObject(serializeObject);

            var dados = Encoding.UTF8.GetBytes(postLoginModel);
            var requisicaoWeb = WebRequest.CreateHttp(url + endPoint);
            requisicaoWeb.Method = "POST";
            requisicaoWeb.ContentType = "application/json";
            requisicaoWeb.ContentLength = dados.Length;

            using (var stream = requisicaoWeb.GetRequestStream())
            {
                stream.Write(dados, 0, dados.Length);
                stream.Close();
            }

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();

                streamDados.Close();
                resposta.Close();

                return objResponse.ToString();
            }
        }
    }
}