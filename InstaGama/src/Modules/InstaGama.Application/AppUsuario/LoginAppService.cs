using InstaGama.Application.AppUsuario.Interface;
using InstaGama.Application.UsuarioApp.Output;
using InstaGama.Domain.Interfaces;
using System;

using System.Threading.Tasks;

namespace InstaGama.Application.AppUsuario
{
    public class LoginAppService : ILoginAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;

            public LoginAppService(IUsuarioRepository usuarioRepository)
            {
                _usuarioRepository = usuarioRepository;
            }

            public async Task<UsuarioViewModel> LoginAsync(string login, string senha)
            {
                var usuario = await _usuarioRepository
                                    .PegarLoginAsync(login)
                                    .ConfigureAwait(false);

                if (usuario is null)
                {
                    throw new Exception("Usuário não encontrado");
                }

                if (!usuario.ComparaSenha(senha))
                {
                    return default;
                }

                return new UsuarioViewModel()
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    DataNascimento = usuario.DataNascimento,
                    Email = usuario.Email,
                    Genero = usuario.Genero,
                    Foto = usuario.Foto
                };
            }
        
    }
}
