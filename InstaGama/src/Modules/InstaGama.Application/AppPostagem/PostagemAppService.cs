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

        public async Task<List<PostagemViewModel>> ObterListaPostagemPorUsuarioIdAsync(int postagemId)
        {
            
            List<Postagem> listaPostagem = await _postagemRepository
                            .ObterListaPostagemPorUsuarioIdAsync(postagemId)
                          .ConfigureAwait(false);

            if (listaPostagem is null)
            {
              throw new ArgumentException("Lista de postagens não encontrada!");
            }



           var listaPostagemMV = new List<PostagemViewModel>();

           foreach (var postagem in listaPostagem)
           {
                Usuario usuarioBanco = await _usuarioRepository.PegarId(postagem.UsuarioId);
                
                PostagemViewModel postagemMV = new PostagemViewModel()
                {
                        Id = postagem.Id,
                        UsuarioId = usuarioBanco.Id,
                        NomeUsuario = usuarioBanco.Nome,
                        Texto = postagem.Texto,
                        Criacao = postagem.Criacao

                 };

                 listaPostagemMV.Add(postagemMV);
            }

            return listaPostagemMV;
        }



        public async Task<PostagemViewModel> ObterPostagemPorIdAsync(int postagemId)
        {
            Postagem postagem = await _postagemRepository
                            .ObterPostagemPorIdAsync(postagemId)
                          .ConfigureAwait(false);

            if (postagem is null)
            {
                throw new ArgumentException("Lista de postagens não encontrada!");
            }

            Usuario usuarioBanco = await _usuarioRepository.PegarId(postagem.UsuarioId);

            return new PostagemViewModel()
            {
                Id = postagem.Id,
                UsuarioId = usuarioBanco.Id,
                NomeUsuario = usuarioBanco.Nome,
                Texto = postagem.Texto,
                Criacao = postagem.Criacao

            };
        }    
    }
}
