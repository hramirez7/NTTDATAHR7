using NTTData.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Application.Interfaces.IServices
{
    public interface ICuentaServices
    {
        bool ActualizarCuenta(CuentaEntradaDTO cuenta, ref string mensaje);
        bool IngresarCuenta(CuentaEntradaDTO cuenta, ref string mensaje);
        bool EliminarCuenta(string ? identificacion, string? numeroCuenta, bool ? estado, ref string mensaje);
        Task<List<CuentaResultDTO>> ConsultarCuenta(string? identificacion, string? numeroCuenta);




    }
}
