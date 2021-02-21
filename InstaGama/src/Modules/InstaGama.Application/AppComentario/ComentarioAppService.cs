using InstaGama.Application.AppComentario.Input;
using InstaGama.Application.AppComentario.Interface;
using InstaGama.Application.AppComentario.Output;
using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace InstaGama.Application.AppComentario
{
    public class ComentarioAppService : IComentarioAppService
    {
        private readonly IUsuarioRepository _usuarioRespository;
        private readonly IComentarioRepository _comentarioRepository;
        private readonly IPostagemRepository _postagemRepository;

        public ComentarioAppService(IComentarioRepository comentarioRepository,
                            IUsuarioRepository usuarioRepository,
                            IPostagemRepository postagemRepository)
        {
            _usuarioRespository = usuarioRepository;
            _comentarioRepository = comentarioRepository;
            _postagemRepository = postagemRepository;
        }

        
        public async Task<ComentarioViewModel> InserirAsync(ComentarioInput comentarioInput)
        {
            
            var comentario = new Comentario(comentarioInput.PostagemId,
                                                comentarioInput.UsuarioId,
                                                comentarioInput.Texto);

            comentario.IsValid();

            var usuario = await _usuarioRespository
                                    .PegarId(comentario.UsuarioId)
                                    .ConfigureAwait(false);

            if (usuario is null)
            {
                throw new ArgumentException("Usuario não encontrado.");
            }

            /*var postagem = await _postagemRepository
                                    .ObterListaPostagemPorUsuarioIdAsync(comentario.UsuarioId)
                                    .ConfigureAwait(false);
            if (postagem is null)
            {
                throw new ArgumentException("Postagem não encontrada.");
            }*/

            var id = await _comentarioRepository
                                .InserirAsync(comentario)
                                .ConfigureAwait(false);


            return new ComentarioViewModel()
            {
                Id = id,
                PostagemId = comentario.PostagemId,
                UsuarioId = comentario.UsuarioId,
                NomeUsuario = usuario.Nome,
                Texto = comentario.Texto,
                Criacao = comentario.Criacao
            };
        }

        public async Task<List<ComentarioViewModel>> ObterListaComentarioPorPostagemIdAsync(int postagemId)
        {
            Postagem postagem = await _postagemRepository
                                        .ObterPostagemPorIdAsync(postagemId)
                                        .ConfigureAwait(false);

            if (postagem is null)
            {
                throw new ArgumentException("Postagens não encontrada!");
            }

            List<Comentario> listaComentarios = await _comentarioRepository
                                        .ObterListaComentarioPorPostagemIdAsync(postagem.Id)
                                        .ConfigureAwait(false);

            if (listaComentarios is null)
            {
                throw new ArgumentException("Comentarios não encontrados.");
            }


            var ComentariPostagemMV = new List<ComentarioViewModel>();

            foreach (var comentario in listaComentarios)
            {
                Usuario usuario = await _usuarioRespository.PegarId(postagem.UsuarioId);



                ComentarioViewModel postagemMV = new ComentarioViewModel()
                {
                    Id = comentario.Id,
                    PostagemId = comentario.PostagemId,
                    UsuarioId = comentario.UsuarioId,
                    NomeUsuario = usuario.Nome,
                    Texto = comentario.Texto,
                    Criacao = comentario.Criacao

                };

                ComentariPostagemMV.Add(postagemMV);
            }

            return ComentariPostagemMV;
        }


        public async Task DeletarComentario(int id)
        {
            await _comentarioRepository
                    .DeletarComentario(id)
                    .ConfigureAwait(false);
        }
    }

}

        
    

