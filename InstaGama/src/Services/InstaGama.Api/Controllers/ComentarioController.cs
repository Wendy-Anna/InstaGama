using System;
using System.Threading.Tasks;
using InstaGama.Application.AppComentario.Input;
using InstaGama.Application.AppComentario.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InstaGama.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioAppService _comentarioAppService;

        public ComentarioController(IComentarioAppService comentarioAppService)
        {
            _comentarioAppService = comentarioAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ComentarioInput comentarioInput)
        {
            try
            {
                var comentario = await _comentarioAppService
                            .InserirAsync(comentarioInput)
                            .ConfigureAwait(false);
                return Created("", comentario);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("{idPostagem}")]
        public async Task<IActionResult> Get([FromRoute] int idPostagem)
        {
            var comentario = await _comentarioAppService
                                   .ObterListaComentarioPorPostagemIdAsync(idPostagem)
                                   .ConfigureAwait(false);

            if (comentario is null)
                return NotFound();

            return Ok(comentario);
        }



        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _comentarioAppService
                      .DeletarComentario(id)
                      .ConfigureAwait(false);

            return NoContent();
        }
    }
}
