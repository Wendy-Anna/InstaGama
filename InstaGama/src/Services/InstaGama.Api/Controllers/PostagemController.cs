using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaGama.Application.AppPostagem.Input;
using InstaGama.Application.AppPostagem.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace InstaGama.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostagemController : ControllerBase
    {
        private readonly IPostagemAppService _postagemAppService;
        private readonly IComentarioAppService _comentarioAppService;
        private readonly ICurtidaAppService _curtidaAppService;
        public PostagemController(IPostagemAppService postagemAppService,
        IComentarioAppService comentarioAppService,
        ICurtidaAppService curtidaAppService)
        {
            _postagemAppService = postagemAppService;
            _comentarioAppService = comentarioAppService;
            _curtidaAppService = curtidaAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostagemInput postagemInput)
        {
            try
            {
                var postagem = await _postagemAppService
                    .InserirtAsync(postagemInput)
                    .ConfigureAwait(false);

                return Created("", postagem);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var postages = await _postagemAppService
                                    .PegarPostagemUsuarioIdAsync()
                                    .ConfigureAwait(false);

            if (postages is null)
                return NoContent();

            return Ok(postages);
        }

        [HttpPost]
        [Route("{id}/Comentario")]
        public async Task<IActionResult> PostCommetario([FromRoute] int id, [FromBody] ComentarioInput comentarioInput)
        {
            try
            {
                var usuario = await _comentarioAppService
                                    .InserirAsync(id, comentarioInput)
                                    .ConfigureAwait(false);

                return Created("", usuario);
            }
            catch (ArgumentException arg)
            {
                return BadRequest(arg.Message);
            }
        }

        [HttpGet]
        [Route("{id}/Commentarios")]
        public async Task<IActionResult> GetCommentarios([FromRoute] int id)
        {
            var commentarios = await _comentarioAppService
                                    .PegarPostagemIdAsync(id)
                                    .ConfigureAwait(false);

            if (commentarios is null)
                return NoContent();

            return Ok(commentarios);
        }

        [HttpPost]
        [Route("{id}/Curtida")]
        public async Task<IActionResult> PostCurtida([FromRoute] int id)
        {
            try
            {
                await _curtidaAppService
                            .InserirtAsync(id)
                            .ConfigureAwait(false);

                return Created("", "");
            }
            catch (ArgumentException arg)
            {
                return BadRequest(arg.Message);
            }
        }

        [HttpGet]
        [Route("{id}/Cutidas")]
        public async Task<IActionResult> GetCurtidas([FromRoute] int id)
        {
            try
            {
                var curtidas = await _curtidaAppService
                                        .PegarQuantidadeCurtidasEPostageIdAsync(id)
                                        .ConfigureAwait(false);

                return Ok(curtidas);
            }
            catch (ArgumentException arg)
            {
                return BadRequest(arg.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _postagemAppService
                                 .DeleteAsync(id)
                                 .ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete]
        [Route("{id}/comentario")]
        public async Task<IActionResult> DeleteComentario([FromRoute] int id)
        {
            try
            {
                await _comentarioAppService
                                 .DeleteAsync(id)
                                 .ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

    }
}   
