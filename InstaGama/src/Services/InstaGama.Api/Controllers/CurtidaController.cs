using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaGama.Application.AppCurtida.Interface;
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

    }
}
