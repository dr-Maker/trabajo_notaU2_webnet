using Models;
using mvcVictoria2020.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace BAL
{
    public class PagoManager
    {
        BaseManager db = new BaseManager();

        public List<PagoModel> Listar()
        {
            var lista = (from r in db.reserva
                         join h in db.habitacion on r.idhabitacion equals h.idhabitacion
                         join c in db.cliente on r.idcliente equals c.idcliente
                         join p in db.pago on r.idreserva equals p.idreserva
                         select new PagoModel
                         {
                             idpago = p.idpago,
                             montopago = p.montopago,
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

        public PagoModel Buscar(int id)
        {
            var obj = (from r in db.reserva
                         join h in db.habitacion on r.idhabitacion equals h.idhabitacion
                         join c in db.cliente on r.idcliente equals c.idcliente
                         join p in db.pago on r.idreserva equals p.idreserva
                         where p.idpago == id
                         select new PagoModel
                         {
                             idpago = p.idpago,
                             montopago = p.montopago,
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

        public int Crear(PagoModel obj)
        {
            try
            {
                var entidad = new pago();
                entidad.idreserva = obj.idreserva;
                entidad.montopago = obj.montopago;
                entidad.estado = 0 ;
                db.pago.AddOrUpdate(entidad);
                db.SaveChanges();

                ActualizarEstadoReserva(obj.idreserva);

                return entidad.idpago;
            }
            catch (Exception exe)
            {
                return 0;
            }
        }

        public int Editar(PagoModel obj)
        {
            try
            {
                var entidad = db.pago.Find(obj.idpago);
                entidad.montopago = obj.montopago;
                entidad.estado = 0;
                db.pago.AddOrUpdate(entidad);
                db.SaveChanges();
                return entidad.idpago;
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
                var entidad = db.pago.Find(id);
                db.pago.Remove(entidad);
                db.SaveChanges();
                return entidad.idpago;
            }
            catch (Exception exe)
            {
                return 0;
            }
        }

        public void ActualizarEstadoReserva(int id)
        {
            var entidad = db.reserva.Find(id);
            entidad.estado = 1;
            db.reserva.AddOrUpdate(entidad);
            db.SaveChanges();
        }

        public List<ListasModel> Reservas()
        {
            var man = new ListasManager();
            return man.Reservas();
        }
    }
}