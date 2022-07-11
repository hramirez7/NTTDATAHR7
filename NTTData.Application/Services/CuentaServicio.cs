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
    public class CuentaServicio : ICuentaServices
    {
        private readonly ICuentaRepository _cuentaRepository;
        public CuentaServicio(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        public bool ActualizarCuenta(CuentaEntradaDTO cuenta, ref string mensaje)
        {
            var bandera = false;

            if (!string.IsNullOrEmpty(cuenta.Identificacion))
            {
                var result = _cuentaRepository.ActualizarCuenta(new CuentaEntrada()
                {
                   Estado = cuenta.Estado,
                   Identificacion = cuenta.Identificacion,
                   numerocuenta = cuenta.numerocuenta,
                   saldoInicial=cuenta.saldoInicial,
                   tipocuenta=cuenta.tipocuenta
                }, ref mensaje);


                bandera = result;

            }
            return bandera;
        }

        public bool IngresarCuenta(CuentaEntradaDTO cuenta, ref string mensaje)
        {
            var bandera = false;

            if (!string.IsNullOrEmpty(cuenta.Identificacion))
            {
                var result = _cuentaRepository.IngresarCuenta(new CuentaEntrada()
                {
                    Estado = cuenta.Estado,
                    Identificacion = cuenta.Identificacion,
                    numerocuenta = cuenta.numerocuenta,
                    saldoInicial = cuenta.saldoInicial,
                    tipocuenta = cuenta.tipocuenta

                }, ref mensaje);


                bandera = result;

            }
            return bandera;
        }
    }
}
