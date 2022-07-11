using NTTData.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Application.Interfaces.IServices
{
    public interface IClienteServices
    {
        Task<List<PersonaResultDTO>> ObtenerPersona(string ? identificacion);
        bool InsertarPersona(PersonaResultDTO persona, ref string mensaje);
        bool ActualizarPersona(PersonaResultDTO persona, ref string mensaje);
        bool EliminarPersona(PersonaResultDTO persona, ref string mensaje);

    }
}
