using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Newtonsoft.Json;
using PontoEletronico.Models;
using PontoEletronico.Service;

namespace PontoEletronico.Controllers
{
    public class HomeController : Controller
    {
        Pagination pagination;
        List<TimesheetModel> timesheetModels = new List<TimesheetModel>();

        public ActionResult Index()
        {
            try
            {
                if (Request.Cookies["tokenModel"] != null)
                {
                    TokenModel tokenModel = PontoEletronico.Session.Session.RetornaToken(Request.Cookies["tokenModel"]);

                    var response = APIService.GetAPI(tokenModel, "Timesheet");

                    if (response.IsSuccessStatusCode)
                    {
                        var serializeObject = response.Content.ReadAsStringAsync().Result;

                        pagination = JsonConvert.DeserializeObject<Pagination>(serializeObject);
                    }

                    timesheetModels.AddRange(pagination.items);

                    return View(timesheetModels);
                }
                return RedirectToAction("Login", "Home");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Erro ao carregar a página \n" + erro.Message;
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult Login()
        {
            if (Request.Cookies["tokenModel"] == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}