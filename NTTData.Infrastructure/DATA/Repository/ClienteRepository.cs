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
            throw new NotImplementedException();
        }

        public bool EliminarPersona(PersonaResult persona, ref string mensaje)
        {
            throw new NotImplementedException();
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
                        mensaje = "Se creo el usuario y cliente";
                        return bandera;
                    }
                    else
                    {
                        bandera = false;
                        mensaje = "Error al crear cliente";
                        return bandera;
                    }
                 
                }
                else
                {
                    bandera = false;
                    mensaje = "Error al crear usuario";
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
                                    Teléfono = p.Dirección
                                }
                          ).ToListAsync();
         
            return resutl;

        }
    }
}

