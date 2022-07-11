using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTTData.Application.Interfaces.IServices;
using NTTData.Core.DTOS;

namespace NTTDATA.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaServices _cuentaServices;

        public CuentaController(ICuentaServices cuentaServices)
        {
            _cuentaServices = cuentaServices;
        }

        [HttpPost]
        [Route("Post")]
        [ActionName("Post")]
        [ProducesResponseType(200, Type = typeof(List<CuentaEntradaDTO>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostActualizarCuenta(CuentaEntradaDTO cuenta)
        {
            string mensaje = string.Empty;
            var data = _cuentaServices.ActualizarCuenta(cuenta, ref mensaje);

            return Ok(new { mensaje = mensaje, resul = data });

        }

        [HttpPost]
        [Route("PostIngreso")]
        [ActionName("PostIngreso")]
        [ProducesResponseType(200, Type = typeof(List<CuentaEntradaDTO>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostInsertarCuenta(CuentaEntradaDTO cuenta)
        {
            string mensaje = string.Empty;
            var data = _cuentaServices.IngresarCuenta(cuenta, ref mensaje);

            return Ok(new { mensaje = mensaje, resul = data });

        }

    }
}
