using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcVictoria2020.Controllers
{
    public class ReservaController : Controller
    {
        ReservaManager man = new ReservaManager();

        public ActionResult Index()
        {
            return View(man.Listar());
        }

        public ActionResult DropVistas()
        {
            ViewBag.Habitaciones = man.Habitaciones();
            ViewBag.Clientes = man.Clientes();
            return View();
        }
    }
}