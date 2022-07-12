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

        public async Task<List<MovimientoResultDTO>> ConsultaMovimiento(MovimientoEntradaDTO realizamovi)
        {
            List<MovimientoResultDTO> listMov = new List<MovimientoResultDTO>();

            var result = await _movimientoRepository.ConsultaMovimiento(new Core.Entities.MovimientoEntrada()
            {
                Identificacion = realizamovi.Identificacion,
                FechaInicio = realizamovi.FechaInicio,
                FechaFinal=realizamovi.FechaFinal,

            });

            foreach (var item in result)
            {
                listMov.Add(new MovimientoResultDTO()
                {
                    Cliente = item.Cliente,
                    estado = item.estado,
                    fecha = item.fecha,
                    Movimiento = item.Movimiento,
                    NumeroCuenta = item.NumeroCuenta,
                    SaldoDisponible = item.SaldoDisponible,
                    saldoinicial= item.saldoinicial,
                    Tipo=item.Tipo

                });
            }
            return listMov;
        }
    }
}
