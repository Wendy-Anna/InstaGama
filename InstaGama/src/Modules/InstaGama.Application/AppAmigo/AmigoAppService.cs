using InstaGama.Application.AppAmigo.Input;
using InstaGama.Application.AppAmigo.Interfaces;
using InstaGama.Application.AppAmigo.Output;
using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Application.AppAmigos
{
    public class AmigoAppService : IAmigoAppService
    {
        private readonly IUsuarioRepository _usuarioRespository;
        private readonly IAmigoRepository _amigoRepository;

        public AmigoAppService(IAmigoRepository amigoRepository, 
            IUsuarioRepository usuarioRepository)
        {
            _usuarioRespository = usuarioRepository;
            _amigoRepository = amigoRepository;
        }

        

        public async Task<List<AmigoViewModel>> GetListaAmigoByUsuarioIdAsync(int usuarioId)
        {
            List<Amigo> listaAmigos = await _amigoRepository
                              .ObterListaAmigoPorIdAsync(usuarioId)
                              .ConfigureAwait(false);

            if (listaAmigos is null)
            {
                throw new ArgumentException("Lista de amigos não encontrada!");
            }

            var listaAmigosMV = new List<AmigoViewModel>();
           

            foreach (var amigo in listaAmigos)
            {
                
                Usuario usuarioAmigo = await _usuarioRespository
                                        .PegarId(amigo.UsuarioAmigoId)
                                        .ConfigureAwait(false);
                
                Usuario usuario = await _usuarioRespository
                                        .PegarId(amigo.UsuarioId)
                                        .ConfigureAwait(false);

                AmigoViewModel amigosMV = new AmigoViewModel()
                {
                    Id = amigo.Id,
                    UsuarioId = amigo.UsuarioId,
                    NomeUsuario = usuario.Nome,
                    UsuarioAmigoId = amigo.UsuarioAmigoId,
                    NomeUsuarioAmigo = usuarioAmigo.Nome,

                };

                listaAmigosMV.Add(amigosMV);


            }

            if (listaAmigosMV is null)
            {
                throw new ArgumentException("Lista de amigos não encontrada!");
            }
        return listaAmigosMV;
        }

        public async Task<AmigoViewModel> InsertAsync(AmigoInput inputAmigo)
        {
            
            var amigo = new Amigo(inputAmigo.UsuarioId,
                                  inputAmigo.UsuarioAmigoId);

            if (amigo is null)
            {
                throw new ArgumentException("Amigo não encontrada.");
            }

            var id = await _amigoRepository
                                .InserirAsync(amigo)
                                .ConfigureAwait(false);

            Usuario usuarioAmigo = await _usuarioRespository
                                        .PegarId(amigo.UsuarioAmigoId)
                                        .ConfigureAwait(false);

            Usuario usuario = await _usuarioRespository
                                    .PegarId(amigo.UsuarioId)
                                    .ConfigureAwait(false);

            return new AmigoViewModel()
            {
                Id = id,
                UsuarioId = amigo.UsuarioId,
                NomeUsuario = usuario.Nome,
                UsuarioAmigoId = amigo.UsuarioAmigoId,
                NomeUsuarioAmigo = usuarioAmigo.Nome,
                
            };
        }

        public async Task<List<AmigoViewModel>> ObterListaAmigoAsync()
        {
            List<Amigo> listaAmigos = await _amigoRepository
                              .ObterListaAmigoAsync()
                              .ConfigureAwait(false);

            if (listaAmigos is null)
            {
                throw new ArgumentException("Lista de amigos não encontrada!");
            }

            var listaAmigosMV = new List<AmigoViewModel>();


            foreach (var amigo in listaAmigos)
            {

                Usuario usuarioAmigo = await _usuarioRespository
                                        .PegarId(amigo.UsuarioAmigoId)
                                        .ConfigureAwait(false);

                Usuario usuario = await _usuarioRespository
                                        .PegarId(amigo.UsuarioId)
                                        .ConfigureAwait(false);

                AmigoViewModel amigosMV = new AmigoViewModel()
                {
                    Id = amigo.Id,
                    UsuarioId = amigo.UsuarioId,
                    NomeUsuario = usuario.Nome,
                    UsuarioAmigoId = amigo.UsuarioAmigoId,
                    NomeUsuarioAmigo = usuarioAmigo.Nome,

                };

                listaAmigosMV.Add(amigosMV);


            }

            if (listaAmigosMV is null)
            {
                throw new ArgumentException("Lista de amigos não encontrada.");
            }
            return listaAmigosMV;
        }

        
        public async Task<int> DeletarVinculoAmizade(int idUsuario, int idVinculo)
        {
            var usuario = await _usuarioRespository
                                .PegarId(idUsuario)
                                .ConfigureAwait(false);
            if (usuario is null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }

            var amizada = await _amigoRepository
                                .DeletarVinculoAmizade(idUsuario, idVinculo)
                                .ConfigureAwait(false);

            if (amizada <= 0)
            {
                throw new ArgumentException("Vinculo.");
            }

            
                     

            else return amizada;




        }
    }
    
}
