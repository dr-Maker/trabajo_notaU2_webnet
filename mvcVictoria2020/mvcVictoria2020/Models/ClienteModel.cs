using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class ClienteModel
    {
        public int idcliente { get; set; }

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