using NTTData.Application.Interfaces.IRepository;
using NTTData.Application.Interfaces.IServices;
using NTTData.Core.DTOS;
using NTTData.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Application.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteServices(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool ActualizarPersona(PersonaResultDTO persona, ref string mensaje)
        {
            throw new NotImplementedException();
        }

        public bool EliminarPersona(PersonaResultDTO persona, ref string mensaje)
        {
            throw new NotImplementedException();
        }

        public  bool InsertarPersona(PersonaResultDTO persona, ref string mensaje)
        {
            var bandera = false;
            
            if (!string.IsNullOrEmpty(persona.Identificacion))
            {
                var result = _clienteRepository.InsertarPersona(new PersonaResult()
                {
                    Nombre = persona.Nombre,
                    Estado = persona.Estado,
                    Clienteid = persona.Clienteid,
                    Contrasena = persona.Contrasena,
                    Dirección = persona.Dirección,
                    Edad = persona.Edad,
                    Genero = persona.Genero,
                    Identificacion = persona.Identificacion,
                    Personaid = persona.Personaid,
                    Teléfono = persona.Teléfono

                },ref mensaje);

           
                    bandera = result;
                
            }

            return bandera;
        }

        public async Task<List<PersonaResultDTO>> ObtenerPersona(string? identificacion)
        {
            List<PersonaResultDTO> listCLIE = new List<PersonaResultDTO>();

            var result = await _clienteRepository.ObtenerPersona(identificacion);

            foreach (var item in result)
            {
                listCLIE.Add(new PersonaResultDTO() { 
                Clienteid = item.Clienteid,
                Contrasena = item.Contrasena,
                Identificacion = item.Identificacion,
                    Personaid = item.Personaid,
                    Dirección = item.Dirección,
                    Teléfono = item.Teléfono,
                    Genero=  item.Genero,
                    Edad = item.Edad,
                    Estado = item.Estado,
                    Nombre = item.Nombre                    

                });
            }

            return listCLIE;
        }



    }
}
