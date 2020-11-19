using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class HabitacionModel
    {
        public int idhabitacion { get; set; }

        public int numhab { get; set; }

        public string detalle { get; set; }

        public int valordia { get; set; }

        public string NumValordia
        {
            get
            {
                return "Hab. #" + numhab + " - $" + valordia;
            }
        }

    }
}