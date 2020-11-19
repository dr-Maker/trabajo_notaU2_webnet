using Models;
using mvcVictoria2020.Data;
using System;
using System.Collections.Generic;
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