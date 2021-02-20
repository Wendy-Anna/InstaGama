using InstaGama.Application.UsuarioApp.Input;
using InstaGama.Application.UsuarioApp.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaGama.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioInput usuarioInput)
        {
            try
            {
                var usuario = await _usuarioAppService
                                    .InserirAsync(usuarioInput)
                                    .ConfigureAwait(false);

                return Created("", usuario);
            }
            catch (ArgumentException arg)
            {
                return BadRequest(arg.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var usuario = await _usuarioAppService
                                .PegarId(id)
                                .ConfigureAwait(false);

            if (usuario is null)
                return NotFound();

            return Ok(usuario);
        } 

    } 
}
