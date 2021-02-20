using InstaGama.Application.UsuarioApp.Input;
using InstaGama.Application.UsuarioApp.Interface;
using InstaGama.Application.UsuarioApp.Output;
using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace InstaGama.Application.UsuarioApp
{
    public class UsuarioAppService : IUsuarioAppService
    {

        private readonly IGeneroRepository _generoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioAppService(IGeneroRepository generoRepository, IUsuarioRepository usuarioRepository) {
            _generoRepository = generoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioViewModel> PegarId(int id)
        {
            var usuario = await _usuarioRepository
                                .PegarId(id)
                                .ConfigureAwait(false);

            if (usuario is null)
                return default;

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

        public async Task<UsuarioViewModel> InserirAsync(UsuarioInput input)
        {
            var genero = await _generoRepository
                            .PegarIdAsync(input.GeneroId)
                            .ConfigureAwait(false);

            if(genero is null)
            {
                throw new ArgumentException("Esse genero não existe!");
            }

            var usuario = new Usuario(input.Nome, input.Email, input.Senha, input.DataNascimento, 
                                        new Genero(genero.Id, genero.Descricao), input.Foto);

            if (!usuario.SeValido())
            {
                throw new ArgumentException("Existem dados obrigatórios que não foram preenchidos");
            }

            var id = await _usuarioRepository
                                .InserirAsync(usuario)
                                .ConfigureAwait(false);

            return new UsuarioViewModel()
            {
                Id = id,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Genero = usuario.Genero,
                Foto = usuario.Foto
            };
        }

        
    }
}
