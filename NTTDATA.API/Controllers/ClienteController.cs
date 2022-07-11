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
        [ActionName("Get")]
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
        [ActionName("Post")]
        [ProducesResponseType(200, Type = typeof(List<PersonaResultDTO>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostRegistarUsuario(PersonaResultDTO Persona)
        {
            string mensaje = string.Empty;
            var data = _clienteServices.InsertarPersona(Persona, ref mensaje);

            return Ok(new { mensaje = mensaje,resul = data });

        }

    }
}
