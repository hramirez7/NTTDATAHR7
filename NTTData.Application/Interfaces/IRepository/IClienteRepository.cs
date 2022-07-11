using NTTData.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Application.Interfaces.IRepository
{
    public interface IClienteRepository
    {
        Task<List<PersonaResult>> ObtenerPersona(string? identificacion);
        bool InsertarPersona(PersonaResult persona, ref string mensaje);
        bool ActualizarPersona(PersonaResult persona, ref string mensaje);
        bool EliminarPersona(PersonaResult persona, ref string mensaje);



    }
}
