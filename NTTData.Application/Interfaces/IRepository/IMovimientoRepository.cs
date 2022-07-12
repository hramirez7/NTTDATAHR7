using NTTData.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Application.Interfaces.IRepository
{
    public interface IMovimientoRepository
    {
        MovimientoRealizaResult CrearMovimiento(MovimientoRealizaEntrada realizamovi);
        Task<List<MovimientoResult>> ConsultaMovimiento(MovimientoEntrada realizamovi);


    }
}
