using Tools;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BAL
{
    public class ListasManager
    {

        BaseManager db = new BaseManager();

        public List<ListasModel> Habitaciones()
        {
            var lista = (from t in db.habitacion     
                         select new ListasModel
                         {
                             texto = "Hab. #" + t.numhab.ToString() + " - $" + t.valordia,
                             valor = t.idhabitacion.ToString()
                         }).ToList();
            return lista;
        }

        public List<ListasModel> Clientes()
        {
            var lista = (from t in db.cliente
                         select new ListasModel
                         {
                             texto = t.nombres + " " + t.apellidos,
                             valor = t.idcliente.ToString()
                         }).ToList();
            return lista;
        }




        public List<ListasModel> Reservas()
        {
            var lista = (from r in db.reserva
                         join h in db.habitacion on r.idhabitacion equals h.idhabitacion
                         join c in db.cliente on r.idcliente equals c.idcliente
                         where r.estado == 0
                         select new ListasModel
                         {
                             texto = "habitación # " + h.numhab + " Cliente " + c.nombres + " " + c.apellidos + " Total a pagar $ " + r.total,
                             valor = r.idreserva.ToString()
                         }).ToList();
            return lista;


        }
    }
}