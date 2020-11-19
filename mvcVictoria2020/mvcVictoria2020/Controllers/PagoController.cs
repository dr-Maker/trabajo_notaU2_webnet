using BAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers
{
    public class PagoController : Controller
    {
        PagoManager man = new PagoManager();

        // GET: Pago
        public ActionResult Index()
        {
            return View(man.Listar());
        }

        public ActionResult Crear()
        {
            ViewBag.Reserva = man.Reservas();
            return View();
        }

        [HttpPost]
        public ActionResult Crear(PagoModel obj)
        {
            ViewBag.Reserva = man.Reservas();
            man.Crear(obj);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            ViewBag.Reserva = man.Reservas();
            var obj = man.Buscar(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Editar(int id, PagoModel obj)
        {
            ViewBag.Reserva = man.Reservas();
            obj.idreserva = id;
            man.Editar(obj);
            return RedirectToAction("Index");
        }


        public ActionResult Borrar(int id)
        {
            var obj = man.Buscar(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Borrar(int id, ReservaModel obj)
        {

            man.Borrar(id);
            return RedirectToAction("Index");
        }
    }
}