using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTTData.Application.Interfaces.IServices;
using NTTData.Core.DTOS;

namespace NTTDATA.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientosServices _movimientosServices;
        public MovimientosController(IMovimientosServices movimientosServices)
        {
            _movimientosServices = movimientosServices;
        }

        [HttpPost]
        [Route("Post")]
        [ActionName("RealizarMovimientos")]
        [ProducesResponseType(200, Type = typeof(MovimientoRealizaEntradaDTO))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CrearMovimiento(MovimientoRealizaEntradaDTO Movimiento)
        {
            string mensaje = string.Empty;
            var data = _movimientosServices.CrearMovimiento(Movimiento);

            return Ok(data);

        }

        [HttpPost]
        [Route("Post")]
        [ActionName("ConsultarMovimientos")]
        [ProducesResponseType(200, Type = typeof(MovimientoEntradaDTO))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ConsultaMovimiento(MovimientoEntradaDTO Movimiento)
        {
            var data = _movimientosServices.ConsultaMovimiento(Movimiento);

            return Ok(data);

        }


    }
}
