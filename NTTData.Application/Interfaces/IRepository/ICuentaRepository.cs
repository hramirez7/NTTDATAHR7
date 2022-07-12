using NTTData.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Application.Interfaces.IRepository
{
    public interface ICuentaRepository
    {
        Task<List<CuentaResult>> ConsultarCuenta(string? identificacion, string? numeroCuenta);
        bool ActualizarCuenta(CuentaEntrada cuenta, ref string mensaje);
        bool IngresarCuenta(CuentaEntrada cuenta, ref string mensaje);
        bool EliminarCuenta(string? identificacion, string? numeroCuenta, bool? estado, ref string mensaje);


    }
}
