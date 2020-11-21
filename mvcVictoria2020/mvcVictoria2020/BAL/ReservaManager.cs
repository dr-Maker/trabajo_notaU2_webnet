using Models;
using mvcVictoria2020.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace BAL
{
    public class ReservaManager
    {
        BaseManager db = new BaseManager();

        public List<ReservaModel> Listar()
        {
            var lista = (from r in db.reserva
                         join h in db.habitacion on r.idhabitacion equals h.idhabitacion
                         join c in db.cliente on r.idcliente equals c.idcliente
                         select new ReservaModel
                         {
                             idreserva = r.idreserva,
                             idhabitacion = r.idhabitacion,
                             idcliente = r.idcliente,
                             fecha = r.fecha,
                             numdias = r.numdias,
                             fechaout = r.fechaout,
                             total = r.total,
                             estado = r.estado,
                             // Habitación
                             numhab = h.numhab,
                             detalle = h.detalle,
                             valordia = h.valordia,
                             // Cliente
                             nombres = c.nombres,
                             apellidos = c.apellidos,
                             email = c.email,
                             telefono = c.telefono
                         }).ToList();
            return lista;
        }

        public ReservaModel Buscar(int id)
        {
            var obj = (from r in db.reserva
                         join h in db.habitacion on r.idhabitacion equals h.idhabitacion
                         join c in db.cliente on r.idcliente equals c.idcliente
                         where r.idreserva == id
                         select new ReservaModel
                         {
                             idreserva = r.idreserva,
                             idhabitacion = r.idhabitacion,
                             idcliente = r.idcliente,
                             fecha = r.fecha,
                             numdias = r.numdias,
                             fechaout = r.fechaout,
                             total = r.total,
                             estado = r.estado,
                             // Habitación
                             numhab = h.numhab,
                             detalle = h.detalle,
                             valordia = h.valordia,
                             // Cliente
                             nombres = c.nombres,
                             apellidos = c.apellidos,
                             email = c.email,
                             telefono = c.telefono
                         }).FirstOrDefault();
            return obj;
        }


        public int Crear(ReservaModel obj)
        {
            { 
                try
                {
                    var entidad = new reserva();
                    entidad.idhabitacion = obj.idhabitacion;
                    entidad.idcliente = obj.idcliente;
                    entidad.fecha = obj.fecha;
                    entidad.numdias = generarNumdias(obj.fecha, obj.fechaout);
                    entidad.fechaout = obj.fechaout;
                    var habitacion = obtHabitacion(obj.idhabitacion);
                    entidad.total = generarTotal(habitacion.valordia, generarNumdias(obj.fecha, obj.fechaout));
                    entidad.estado = 0;

                    db.reserva.AddOrUpdate(entidad);
                    db.SaveChanges();
                    return entidad.idreserva;
                }

                catch (Exception exe)
                {
                    return 0;
                }
            }
        }


        public int Editar(ReservaModel obj)
        {
            try
            {
                var entidad = db.reserva.Find(obj.idreserva);
                entidad.idhabitacion = obj.idhabitacion;
                entidad.idcliente = obj.idcliente;
                entidad.fecha = obj.fecha;
                entidad.numdias = generarNumdias(obj.fecha, obj.fechaout);
                entidad.fechaout = obj.fechaout;

                var habitacion = obtHabitacion(obj.idhabitacion);
                entidad.total = generarTotal(habitacion.valordia, generarNumdias(obj.fecha, obj.fechaout));
                entidad.estado = 0;
                db.reserva.AddOrUpdate(entidad);
                db.SaveChanges();
                return entidad.idreserva;
            }
            catch (Exception exe)
            {
                return 0;
            }
        }

        public int Borrar(int id)
        {
            try
            {
                var entidad = db.reserva.Find(id);
                db.reserva.Remove(entidad);
                db.SaveChanges();
                return entidad.idreserva;
            }
            catch (Exception exe)
            {
                return 0;
            }
        }


        public int generarNumdias(DateTime fechainicial, DateTime fechafinal )
        {
            TimeSpan tdias = fechafinal - fechainicial;

            int dias = tdias.Days;

            return dias;
        }

        public int generarTotal(int valorHabitacion, int dias)
        {
            int total = dias * valorHabitacion;

            return total;
        }


        public habitacion obtHabitacion(int id)
        {
           return db.habitacion.Find(id);
        }

        public List<ListasModel> Habitaciones()
        {
            var man = new ListasManager();
            return man.Habitaciones();
        }

        public List<ListasModel> Clientes()
        {
            var man = new ListasManager();
            return man.Clientes();
        }
    }
}