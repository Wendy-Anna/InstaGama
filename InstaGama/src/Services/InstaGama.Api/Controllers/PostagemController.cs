using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaGama.Application.AppPostagem.Input;
using InstaGama.Application.AppPostagem.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaGama.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostagemController : ControllerBase
    {
        private readonly IPostagemAppService _postagemAppService;

        public PostagemController(IPostagemAppService postagemAppService)
        {
            _postagemAppService = postagemAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostagemInput amigoInput)
        {
            try
            {
                var postagem = await _postagemAppService
                    .InserirAsync(amigoInput)
                    .ConfigureAwait(false);
                return Created("", postagem);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var postagem = await _postagemAppService
                                .ObterListaPostagemPorUsuarioIdAsync(id)
                                .ConfigureAwait(false);

            if (postagem is null)
                return NotFound();

            return Ok(postagem);
        }

    }
}
