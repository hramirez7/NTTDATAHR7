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

        [HttpGet]
        [Route("Get")]
        [ActionName("ConsultarCuenta")]
        [ProducesResponseType(200, Type = typeof(List<CuentaEntradaDTO>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConsultarCuenta(string? identificacion, string ? nuemroCuenta)
        {
            var data = await _cuentaServices.ConsultarCuenta(identificacion, nuemroCuenta);

            return Ok(data);

        }

        [HttpPost]
        [Route("PostIngreso")]
        [ActionName("IngresarCuenta")]
        [ProducesResponseType(200, Type = typeof(List<CuentaEntradaDTO>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostInsertarCuenta(CuentaEntradaDTO cuenta)
        {
            string mensaje = string.Empty;
            var data = _cuentaServices.IngresarCuenta(cuenta, ref mensaje);

            return Ok(new { mensaje = mensaje, resul = data });

        }

        [HttpPut]
        [Route("Put")]
        [ActionName("ActualizarCuenta")]
        [ProducesResponseType(200, Type = typeof(List<CuentaEntradaDTO>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostActualizarCuenta(CuentaEntradaDTO cuenta)
        {
            string mensaje = string.Empty;
            var data = _cuentaServices.ActualizarCuenta(cuenta, ref mensaje);

            return Ok(new { mensaje = mensaje, resul = data });

        }

        [HttpDelete]
        [Route("Delete")]
        [ActionName("EliminarCuenta")]
        [ProducesResponseType(200, Type = typeof(List<CuentaEntradaDTO>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult EliminarCuenta(string? identificacion, string? numeroCuenta, bool? estado)
        {
           string mensaje = string.Empty;
            var data = _cuentaServices.EliminarCuenta(identificacion, numeroCuenta, estado, ref mensaje);

            return Ok(new { mensaje = mensaje, resul = data });

        }

    }
}
