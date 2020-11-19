using BAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers
{
    public class ClienteController : Controller
    {
        ClienteManager man = new ClienteManager();

        public ActionResult Index()
        {
            return View(man.Listar());
        }

        public ActionResult Crear()
        {
     
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ClienteModel obj)
        {
      
            man.Crear(obj);
            return RedirectToAction("Index");
        }


        public ActionResult Editar(int id)
        {
            var obj = man.Buscar(id); 
            return View(obj);
        }

        [HttpPost]
        public ActionResult Editar(int id, ClienteModel obj)
        {
            obj.idcliente = id;
            man.Editar(obj);
            return RedirectToAction("Index");
        }

        public ActionResult Borrar(int id)
        {
            var obj = man.Buscar(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Borrar(int id, ClienteModel obj)
        {

            man.Borrar(id);
            return RedirectToAction("Index");
        }
    }
}