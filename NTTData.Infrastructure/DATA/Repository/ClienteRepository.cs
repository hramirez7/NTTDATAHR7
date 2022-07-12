using Microsoft.EntityFrameworkCore;
using NTTData.Application.Interfaces.IRepository;
using NTTData.Core.Entities;
using NTTData.Infrastructure.DATA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Infrastructure.DATA.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly BaseDataContext _context;
        public ClienteRepository(BaseDataContext context)
        {
            _context = context;
        }

        public bool ActualizarPersona(PersonaResult persona, ref string mensaje)
        {
            bool bandera = false;
            if (_context.Personas.Where(x => x.Identificacion == persona.Identificacion).Count() > 0)
            {                            

                var result = _context.Personas.Where(x => x.Identificacion == persona.Identificacion).ToList();

                Persona Itempersona = null;

                foreach (var iperso in result)
                {
                    Itempersona = new Persona()
                    {   Personaid = iperso.Personaid,
                        Dirección = iperso.Dirección,
                        Edad = iperso.Edad,
                        Genero = iperso.Genero,
                        Identificacion = iperso.Identificacion,
                        Nombre = iperso.Nombre,
                        Teléfono = iperso.Teléfono
                    };
                }

                Itempersona.Dirección = persona.Dirección;
                Itempersona.Edad = persona.Edad;
                Itempersona.Genero = persona.Genero;
                Itempersona.Identificacion = persona.Identificacion;
                Itempersona.Nombre = persona.Nombre;
                Itempersona.Teléfono = persona.Teléfono;

                _context.ChangeTracker.Clear();
                _context.Update(Itempersona);
                var dat = _context.SaveChanges();
                if (dat > 0)
                {
                    var resutl2 = (from p in _context.Personas
                                   from c in _context.Clientes
                                   where c.Personaid == p.Personaid && p.Identificacion == persona.Identificacion
                                   select new
                                   {
                                       Clienteid = c.Clienteid

                                   }
                          ).First().Clienteid;
                    int idcliente = resutl2;

                    var result1 = _context.Clientes.Where(x => x.Clienteid == idcliente).ToList();

                    Cliente ItemCliente = null;

                    foreach (var icta in result1)
                    {
                        ItemCliente = new Cliente()
                        {
                            Clienteid = icta.Clienteid,
                            Personaid = icta.Personaid,
                            Contrasena = icta.Contrasena,
                            Estado = icta.Estado
                        };
                    }
                    ItemCliente.Contrasena = persona.Contrasena;

                    _context.ChangeTracker.Clear();
                    _context.Update(ItemCliente);
                    var dat1 = _context.SaveChanges();

                    if (dat > 0)
                    {
                        bandera = true;
                        mensaje = "Se actualizo el usuario";
                        return bandera;
                    }
                    else
                    {
                        bandera = false;
                        mensaje = "Error al actualizar el usuario.....";
                        return bandera;
                    }
                }
                else
                {
                    bandera = false;
                    mensaje = "Error al actualizar el usuario";
                    return bandera;
                }


            }
            else
            {
                mensaje = "Usuario no existe";
                return bandera;
            }
        }

               public bool EliminarPersona(string? identificacion, bool? estado, ref string mensaje)
        {
            bool bandera = false;
            if (_context.Personas.Where(x => x.Identificacion == identificacion).Count() > 0)
            {

                var result = _context.Personas.Where(x => x.Identificacion == identificacion).ToList();

                Persona Itempersona = null;

                foreach (var iperso in result)
                {
                    Itempersona = new Persona()
                    {
                        Personaid = iperso.Personaid,
                        Dirección = iperso.Dirección,
                        Edad = iperso.Edad,
                        Genero = iperso.Genero,
                        Identificacion = iperso.Identificacion,
                        Nombre = iperso.Nombre,
                        Teléfono = iperso.Teléfono
                    };
                }
                _context.ChangeTracker.Clear();
                _context.Update(Itempersona);
                var dat = _context.SaveChanges();
                if (dat > 0)
                {
                    var resutl2 = (from p in _context.Personas
                                   from c in _context.Clientes
                                   where c.Personaid == p.Personaid && p.Identificacion == identificacion
                                   select new
                                   {
                                       Clienteid = c.Clienteid

                                   }
                          ).First().Clienteid;
                    int idcliente = resutl2;

                    var result1 = _context.Clientes.Where(x => x.Clienteid == idcliente).ToList();

                    Cliente ItemCliente = null;

                    foreach (var icta in result1)
                    {
                        ItemCliente = new Cliente()
                        {
                            Clienteid = icta.Clienteid,
                            Personaid = icta.Personaid,
                            Contrasena = icta.Contrasena,
                            Estado = icta.Estado
                        };
                    }
                    ItemCliente.Estado = estado;

                    _context.ChangeTracker.Clear();
                    _context.Update(ItemCliente);
                    var dat1 = _context.SaveChanges();

                    if (dat > 0)
                    {
                        bandera = true;
                        mensaje = "Se elimino el usuario";
                        return bandera;
                    }
                    else
                    {
                        bandera = false;
                        mensaje = "Error al eliminar el usuario.....";
                        return bandera;
                    }
                }
                else
                {
                    bandera = false;
                    mensaje = "Error al eliminar el usuario";
                    return bandera;
                }


            }
            else
            {
                mensaje = "Usuario no existe";
                return bandera;
            }
        }

        public bool InsertarPersona(PersonaResult persona, ref string mensaje)
        {
            bool bandera = false;

            if (_context.Personas.Where(x => x.Identificacion == persona.Identificacion).Count() > 0)
            {
                mensaje = "Usuario ya existe";
                return bandera;
            }
            else
            {
                _context.ChangeTracker.Clear();           

                _context.Add(new Persona() { 
                Dirección = persona.Dirección,
                Edad = persona.Edad,
                Genero = persona.Genero,
                Identificacion = persona.Identificacion,
                Nombre = persona.Nombre,
                Teléfono = persona.Teléfono
                });
                var dat = _context.SaveChanges();

                var request = _context.Personas.Where(x => x.Identificacion == persona.Identificacion);
                var idpersona = request.Select(x => x.Personaid).FirstOrDefault();
                if (dat > 0)
                {

                    _context.ChangeTracker.Clear();
                    _context.Add(new Cliente()
                    {
                       Contrasena = persona.Contrasena,
                       Estado = persona.Estado,
                       Personaid = idpersona
                    });
                    var dat1 = _context.SaveChanges();

                    if (dat1 > 0)
                    {
                        bandera = true;
                        mensaje = "Se creo el Usuario";
                        return bandera;
                    }
                    else
                    {
                        bandera = false;
                        mensaje = "Error al crear Usuario";
                        return bandera;
                    }
                 
                }
                else
                {
                    bandera = false;
                    mensaje = "Error al crear usuario..";
                    return bandera;
                }
               

            }


        }

        public async Task<List<PersonaResult>> ObtenerPersona(string? identificacion)
        {

            var resutl = await (from p in _context.Personas
                          from c in _context.Clientes
                          where c.Personaid == p.Personaid && p.Identificacion == identificacion
                                select new PersonaResult(){
                                    Clienteid = c.Clienteid,
                                    Personaid = p.Personaid,
                                    Identificacion = p.Identificacion,
                                    Nombre = p.Nombre,
                                    Estado = c.Estado,
                                    Contrasena = c.Contrasena,
                                    Dirección  = p.Dirección,
                                    Edad = p.Edad,
                                    Genero = p.Genero,  
                                    Teléfono = p.Teléfono
                                }
                          ).ToListAsync();
         
            return resutl;

        }
    }
}

