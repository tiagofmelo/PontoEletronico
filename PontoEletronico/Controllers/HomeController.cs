using System;
using System.Collections.Generic;
using System.Linq;
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

                        timesheetModels.AddRange(pagination.items);

                        Response.AppendCookie(PontoEletronico.Session.Session.ArmazenaTimesheet(pagination.items.OrderByDescending(x => x.id).FirstOrDefault()));
                    }

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

        [HttpPost]
        public ActionResult LogOut()
        {
            Request.Cookies.Clear();

            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult Update()
        {
            try
            {
                if (Request.Form["evento"] != null && Request.Cookies["tokenModel"] != null)
                {
                    TokenModel tokenModel = PontoEletronico.Session.Session.RetornaToken(Request.Cookies["tokenModel"]);
                    TimesheetModel timesheetModel = PontoEletronico.Session.Session.RetornaTimesheet(Request.Cookies["timesheetModel"]);

                    switch (Request.Form["evento"])
                    {
                        case "1":
                            TimesheetModel newTimesheet = new TimesheetModel
                            {
                                start = DateTime.Now,
                            };

                            var response = APIService.PostAPI(tokenModel, "Timesheet", newTimesheet);

                            if (response.IsSuccessStatusCode)
                            {
                                var serializeObject = response.Content.ReadAsStringAsync().Result;
                            }
                            break;
                        case "2":
                            timesheetModel.startLunch = DateTime.Now;

                            response = APIService.PutAPI(tokenModel, "Timesheet", timesheetModel);

                            if (response.IsSuccessStatusCode)
                            {
                                var serializeObject = response.Content.ReadAsStringAsync().Result;
                            }
                            break;
                        case "3":
                            timesheetModel.endLunch = DateTime.Now;

                            response = APIService.PutAPI(tokenModel, "Timesheet", timesheetModel);

                            if (response.IsSuccessStatusCode)
                            {
                                var serializeObject = response.Content.ReadAsStringAsync().Result;
                            }
                            break;
                        case "4":
                            timesheetModel.end = DateTime.Now;

                            response = APIService.PutAPI(tokenModel, "Timesheet", timesheetModel);

                            if (response.IsSuccessStatusCode)
                            {
                                var serializeObject = response.Content.ReadAsStringAsync().Result;
                            }
                            break;
                    }
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Login", "Home");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Erro ao registrar o ponto \n" + erro.Message;
                return RedirectToAction("Login", "Home");
            }
        }
    }
}