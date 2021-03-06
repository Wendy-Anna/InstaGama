﻿using InstaGama.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq;


namespace InstaGama.Domain.Core
{
    public class Logado : ILogado
    {
        private readonly IHttpContextAccessor _accessor;

        public Logado(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public int PegarLoginUsuarioId()
        {
            var id = _accessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "jti").Value;

            return int.Parse(id);
        }
    }
}
