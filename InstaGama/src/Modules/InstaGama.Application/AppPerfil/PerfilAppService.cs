using InstaGama.Application.AppComentario.Interface;
using InstaGama.Application.AppComentario.Output;
using InstaGama.Application.AppPerfil.Interface;
using InstaGama.Application.AppPerfil.Output;
using InstaGama.Application.AppPostagem;
using InstaGama.Application.AppPostagem.Interfaces;
using InstaGama.Application.UsuarioApp;
using InstaGama.Application.UsuarioApp.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Application.AppPerfil
{
    public class PerfilAppService : IPerfilAppService
    {
        private IPostagemAppService _postagemAppService;
        private IUsuarioAppService _usuarioAppService;
        private IComentarioAppService _comentarioAppService;

        public PerfilAppService(IPostagemAppService postagemAppService,
                    IUsuarioAppService usuarioAppService,
                    IComentarioAppService comentarioAppService)
        {
            _postagemAppService = postagemAppService;
            _usuarioAppService = usuarioAppService;
            _comentarioAppService = comentarioAppService;
        }
        
        public async Task<PerfilViewModel> ObterPerfilPorIdUsarioAsync(int id)
        {
            var usuarioInput  = await _usuarioAppService
                                .PegarId(id)
                                .ConfigureAwait(false);

            if (usuarioInput is null)
            {
                throw new ArgumentException("Usúario não cadastado.");
            }

            var usuario = await _usuarioAppService
                                    .PegarId(id)
                                    .ConfigureAwait(false);

            var listaPostagem = await _postagemAppService
                                   .ObterListaPostagemPorUsuarioIdAsync(id)
                                   .ConfigureAwait(false);
            List<ComentarioViewModel> cometarios = new List<ComentarioViewModel>();
            foreach (var postagem in listaPostagem)
            {
                var comentarioLis = await _comentarioAppService
                        .ObterListaComentarioPorPostagemIdAsync(postagem.Id)
                        .ConfigureAwait(false);

                if(postagem.listaComentario is null)
                {
                    postagem.listaComentario = new List<ComentarioViewModel>();
                }

                if (comentarioLis!= null)
                {
                    foreach (var comentario in comentarioLis)
                    {
                        if(comentario != null)
                        {
                           postagem.listaComentario.Add(comentario);
                        }
                        
                        
                    }
                }
                

                
            }
                


            return new PerfilViewModel()
            {
                Usuario = usuario,
                ListaPostagens = listaPostagem
            };

            
        }
    }
}
