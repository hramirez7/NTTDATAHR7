using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTTData.Application.Interfaces.IServices;
using NTTData.Core.DTOS;

namespace NTTDATA.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _clienteServices;
        public ClienteController(IClienteServices clienteServices)
        {

            _clienteServices = clienteServices;

        }

        [HttpGet]
        [Route("Get")]
        [ActionName("ConsultaUsuario")]
        [ProducesResponseType(200, Type = typeof(List<PersonaResultDTO>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> getAccount(string? identificacion)
        {
            var data = await _clienteServices.ObtenerPersona(identificacion);

            return Ok(data);

        }

        [HttpPost]
        [Route("Post")]
        [ActionName("RegistrarUsuario")]
        [ProducesResponseType(200, Type = typeof(List<PersonaResultDTO>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostRegistarUsuario(PersonaResultDTO Persona)
        {
            string mensaje = string.Empty;
            var data = _clienteServices.InsertarPersona(Persona, ref mensaje);

            return Ok(new { mensaje = mensaje,resul = data });

        }

        [HttpPut]
        [Route("Put")]
        [ActionName("ActualizarUsuario")]
        [ProducesResponseType(200, Type = typeof(List<PersonaResultDTO>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarUsuario(PersonaResultDTO Persona)
        {
            string mensaje = string.Empty;
            var data = _clienteServices.ActualizarPersona(Persona, ref mensaje);

            return Ok(new { mensaje = mensaje, resul = data });

        }

        [HttpDelete]
        [Route("Delete")]
        [ActionName("EliminarUsuario")]
        [ProducesResponseType(200, Type = typeof(List<PersonaResultDTO>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult EliminarUsuario(string? identificacion, bool? estado)
        {
            string mensaje = string.Empty;
            var data = _clienteServices.EliminarPersona(identificacion, estado, ref mensaje);

            return Ok(new { mensaje = mensaje, resul = data });

        }

    }
}
