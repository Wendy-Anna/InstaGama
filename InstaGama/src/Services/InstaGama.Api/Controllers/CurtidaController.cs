using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaGama.Application.AppCurtida.Input;
using InstaGama.Application.AppCurtida.Interface;
using InstaGama.Application.AppCurtida.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaGama.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidaController : ControllerBase
    {
        private readonly ICurtidaAppService _curtidaAppService;

        public CurtidaController(ICurtidaAppService curtidaAppService)
        {
            _curtidaAppService = curtidaAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var qtdCurtidas = await _curtidaAppService
                                .PegarQuantidadeCurtidasIdAsync(id)
                                .ConfigureAwait(false);

            if (qtdCurtidas != 0)
            { 
                return NotFound();
            }
            return Ok(qtdCurtidas);

        }


        [HttpGet]
        [Route("{usuarioId}/{postagemId}")]
        public async Task<IActionResult>PegarUsuarioIdEPostagemIdAsync([FromRoute] int usuarioId, int postagemId)
        {
            var curtida = await _curtidaAppService
                                .PegarUsuarioIdEPostagemIdAsync(usuarioId, postagemId )
                                .ConfigureAwait(false);

         

            return Ok(curtida);

        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> ApagarAsync([FromRoute] int id)
        {
            await _curtidaAppService
                                    .ApagarAsync(id)
                                    .ConfigureAwait(false);

            return NoContent();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> InserirAsync([FromBody] int postagemId)
        {
            try
            {
                var curtida = await _curtidaAppService
                                    .InserirAsync(postagemId)
                                    .ConfigureAwait(false);

                return Created("", curtida);
            }
            catch (ArgumentException arg)
            {
                return BadRequest(arg.Message);
            }
        }
    }
}
