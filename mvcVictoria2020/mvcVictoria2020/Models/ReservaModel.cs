using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class ReservaModel
    {
        public int idreserva { get; set; }

        public int idhabitacion { get; set; }

        public int idcliente { get; set; }

        public DateTime fecha { get; set; }

        public int numdias { get; set; }

        public DateTime fechaout { get; set; }

        public int total { get; set; }

        public int estado { get; set; }

        //Habitación

        public int numhab { get; set; }

        public string detalle { get; set; }

        public int valordia { get; set; }

        public string NumValordia
        {
            get
            {
                return "Hab. #" + numhab +" - $" + valordia;
            }
        }

        //Cliente

        public string nombres { get; set; }

        public string apellidos { get; set; }

        public string email { get; set; }

        public long telefono { get; set; }

        public string NombreCliente
        {
            get
            {
                return nombres + " " + apellidos;
            }
        }
    }
}