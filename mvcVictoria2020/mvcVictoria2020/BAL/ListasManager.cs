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
                             texto = "Hab. #" + t.numhab.ToString() + " - $" + t.valordia.ToString(),
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

    }
}