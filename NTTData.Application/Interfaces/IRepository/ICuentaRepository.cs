﻿using NTTData.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Application.Interfaces.IRepository
{
    public interface ICuentaRepository
    {
        bool ActualizarCuenta(CuentaEntrada cuenta, ref string mensaje);

        bool IngresarCuenta(CuentaEntrada cuenta, ref string mensaje);

    }
}
