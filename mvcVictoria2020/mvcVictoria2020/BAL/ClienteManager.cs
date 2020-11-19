using Models;
using mvcVictoria2020.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace BAL
{
    public class ClienteManager
    {

        BaseManager db = new BaseManager();

        public List<ClienteModel> Listar()
        {
            var lista = (from c in db.cliente

                         select new ClienteModel
                         {
                             idcliente = c.idcliente,
                             nombres = c.nombres,
                             apellidos = c.apellidos,
                             email = c.email,
                             telefono = c.telefono
                         }).ToList();
            return lista;
        }

        public ClienteModel Buscar(int id)
        {
            var obj = (from c in db.cliente
                       where c.idcliente == id
                         select new ClienteModel
                         {
                             idcliente = c.idcliente,
                             nombres = c.nombres,
                             apellidos = c.apellidos,
                             email = c.email,
                             telefono = c.telefono
                         }).FirstOrDefault();
            return obj;
        }

        public int Crear(ClienteModel obj)
        {
            try
            {
                var entidad = new cliente(); 
                entidad.nombres = obj.nombres;
                entidad.apellidos = obj.apellidos;
                entidad.email = obj.email;
                entidad.telefono = obj.telefono;

                db.cliente.AddOrUpdate(entidad);
                db.SaveChanges();
                return entidad.idcliente;
            }
            catch (Exception exe)
            {
                return 0;
            }
        }

        public int Editar(ClienteModel obj)
        {
            try
            {
                var entidad = db.cliente.Find(obj.idcliente);
                entidad.nombres = obj.nombres;
                entidad.apellidos = obj.apellidos;
                entidad.email = obj.email;
                entidad.telefono = obj.telefono;

                db.cliente.AddOrUpdate(entidad);
                db.SaveChanges();
                return entidad.idcliente;
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
                var entidad = db.cliente.Find(id);
                db.cliente.Remove(entidad);
                db.SaveChanges();
                return entidad.idcliente;
            }
            catch (Exception exe)
            {
                return 0;
            }
        }

    }
}