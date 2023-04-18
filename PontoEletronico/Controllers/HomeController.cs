using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PontoEletronico.Models;

namespace PontoEletronico.Controllers
{
    public class HomeController : Controller
    {
        List<TimesheetModel> timesheetModels;

        public ActionResult Index()
        {
            timesheetModels = new List<TimesheetModel>()
            {
                new TimesheetModel()
                {
                    id= 1,
                    start= DateTime.Now,
                    startLunch= DateTime.Now,
                    endLunch= DateTime.Now,
                    end = DateTime.Now
                }
            };

            return View(timesheetModels);
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}