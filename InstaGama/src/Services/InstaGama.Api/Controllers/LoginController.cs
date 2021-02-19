using System;
using InstaGama.Api.Comum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaGama.Application.AppUsuario.Interface;
using InstaGama.Application.AppUsuario.Input;

namespace InstaGama.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginAppService _loginAppService;
        private readonly IConfiguration _configuration;
        public LoginController(ILoginAppService loginAppService,
                                IConfiguration configuration)
        {
            _loginAppService = loginAppService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<object> Post([FromBody] LoginInput input)
        {
            try
            {
                var logado = await _loginAppService
                                    .LoginAsync(input.Login, input.Senha)
                                    .ConfigureAwait(false);

                if (logado != null)
                {
                    var token = TokenService.GenerateToken(logado, _configuration.GetSection("Secrets").Value);

                    return new
                    {
                        authenticated = true,
                        accessToken = token,
                        message = "OK"
                    };
                }

                return Unauthorized("Sentimos muito, você não tem permissão");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " " + ex.InnerException);
            }
        }
    }
}
