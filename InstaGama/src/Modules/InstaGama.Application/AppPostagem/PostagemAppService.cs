using InstaGama.Application.AppPostagem.Input;
using InstaGama.Application.AppPostagem.Interfaces;
using InstaGama.Application.AppPostagem.Output;
using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Application.AppPostagem
{
    public class PostagemAppService : IPostagemAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPostagemRepository _postagemRepository;

        public PostagemAppService(IUsuarioRepository usuarioRepository, IPostagemRepository postagemRepository)
        {
            _usuarioRepository = usuarioRepository;
            _postagemRepository = postagemRepository;
        }

        public async Task<PostagemViewModel> InserirAsync(PostagemInput postagemInput)
        {
            // validando a existencia do usuário
            Usuario usuarioBanco = await _usuarioRepository.PegarId(postagemInput.UsuarioId);
            if(usuarioBanco is null)
            {
                throw new ArgumentException("Usuário inválido");
            }
            
            var postagem = new Postagem(postagemInput.Texto, postagemInput.UsuarioId);

            if (!postagem.IsValid())
            {
                throw new ArgumentException("Dados obrigatórios não preenchidos");
            }

            var idPostagem = await _postagemRepository.
                                           InserirAsync(postagem)
                                           .ConfigureAwait(false);

            return new PostagemViewModel()
            {
                Id = idPostagem,
                UsuarioId = usuarioBanco.Id,
                NomeUsuario = usuarioBanco.Nome,
                Texto = postagem.Texto,
                Criacao = postagem.Criacao
            };


        }

        public Task<List<PostagemViewModel>> ObterListaPostagemPorUsuarioIdAsync(int usuarioId)
        {
            
            throw new NotImplementedException();
        }
    }
}
