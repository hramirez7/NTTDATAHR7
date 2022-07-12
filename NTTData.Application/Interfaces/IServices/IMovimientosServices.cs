using NTTData.Core.DTOS;
using NTTData.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Application.Interfaces.IServices
{
    public interface IMovimientosServices
    {
        MovimientoRealizaResultDTO CrearMovimiento(MovimientoRealizaEntradaDTO realizamovi);
        Task<List<MovimientoResultDTO>> ConsultaMovimiento(MovimientoEntradaDTO realizamovi);

    }
}
