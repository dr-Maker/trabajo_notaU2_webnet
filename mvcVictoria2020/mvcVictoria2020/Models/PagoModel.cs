using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tools;

namespace Models
{
    public class PagoModel
    {
        public int idpago { get; set; }

        public int idreserva { get; set; }

        public int montopago { get; set; }

        public int estado { get; set; }

        //Reserva

        public int idhabitacion { get; set; }

        public int idcliente { get; set; }

        public DateTime fecha { get; set; }

        public int numdias { get; set; }

        public DateTime fechaout { get; set; }

        public int total { get; set; }


        public string FechaInTxt
        {
            get
            {
                string dia = Rutinas.right(fecha.Day.ToString(), 2);
                string mes = Rutinas.right(fecha.Month.ToString(), 2);
                string anno = Rutinas.right(fecha.Year.ToString(), 4);

                return dia + "-" + mes + "-" + anno;
            }
        }

        public string FechaOutTxt
        {
            get
            {
                string dia = Rutinas.right(fechaout.Day.ToString(), 2);
                string mes = Rutinas.right(fechaout.Month.ToString(), 2);
                string anno = Rutinas.right(fechaout.Year.ToString(), 4);

                return dia + "-" + mes + "-" + anno;
            }
        }

        public int numhab { get; set; }

        public string detalle { get; set; }

        public int valordia { get; set; }

        public string NumValordia
        {
            get
            {
                return "Hab. #" + numhab + " - $" + valordia.ToString("N0");
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

        //Habitacion 

        //Cliente

        //fecha entrada - salida - numeros de dias
        // numero de habitacion y cliente
    }
}