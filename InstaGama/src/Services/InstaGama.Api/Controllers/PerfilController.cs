using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaGama.Application.AppAmigo.Interfaces;
using InstaGama.Application.AppComentario.Interface;
using InstaGama.Application.AppCurtida.Interface;
using InstaGama.Application.AppPerfil.Interface;
using InstaGama.Application.AppPostagem.Interfaces;
using InstaGama.Application.UsuarioApp.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaGama.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilAppService _perfilAppService;
        
        public PerfilController(IPerfilAppService perfilAppService)
        {
            _perfilAppService = perfilAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var perfil = await _perfilAppService
                                .ObterPerfilPorIdUsarioAsync(id)
                                .ConfigureAwait(false);

            if (perfil is null)
                return NotFound();

            return Ok(perfil);
        }

    }
}
