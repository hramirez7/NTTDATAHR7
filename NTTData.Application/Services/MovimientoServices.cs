using NTTData.Application.Interfaces.IRepository;
using NTTData.Application.Interfaces.IServices;
using NTTData.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Application.Services
{
    public class MovimientoServices : IMovimientosServices
    {
        private readonly IMovimientoRepository _movimientoRepository;
        public MovimientoServices(IMovimientoRepository movimientoRepository)
        {
            _movimientoRepository = movimientoRepository;
        }

        public MovimientoRealizaResultDTO CrearMovimiento(MovimientoRealizaEntradaDTO realizamovi)
        {

            var result = _movimientoRepository.CrearMovimiento(new Core.Entities.MovimientoRealizaEntrada()
            {
                Identificaccion = realizamovi.Identificaccion,
                MovimientoValor = realizamovi.MovimientoValor,
                TipoCuenta = realizamovi.TipoCuenta,
                TipoMovimiento = realizamovi.TipoMovimiento

            } );
            return new MovimientoRealizaResultDTO() { Mensaje= result.mensaje,Modigo = result.codigo};

        }
    }
}
