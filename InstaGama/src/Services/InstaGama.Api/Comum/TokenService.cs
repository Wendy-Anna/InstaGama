using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InstaGama.Domain.Entities;
using InstaGama.Application.UsuarioApp.Output;
using Microsoft.IdentityModel.Tokens;

namespace InstaGama.Api.Comum
{
    public class TokenService
    {
        public static string GenerateToken(UsuarioViewModel usuario, string secrets)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secrets);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Genero.Descricao),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString())

                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler
                            .CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
