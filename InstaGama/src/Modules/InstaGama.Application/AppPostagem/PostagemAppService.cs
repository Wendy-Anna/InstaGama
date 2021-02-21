using InstaGama.Application.AppPostagem.Input;
using InstaGama.Application.AppPostagem.Interfaces;

using InstaGama.Domain.Core.Interfaces;
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

        private readonly ILogado _logado;
        private readonly IPostagemRepository _postagemRepository;

        public PostagemAppService(ILogado logado, IPostagemRepository postagemRepository)
        {
            _logado = logado;
            _postagemRepository = postagemRepository;
        }

        public async Task<Postagem> AtualizarAsync(int id, PostagemInput postageInput)
        {
            var postagem = await _postagemRepository
                               .PegarPostagemIdAsync(id)
                               .ConfigureAwait(false);
            if (postagem is null)
            {
                throw new Exception("Sentimos muito, sua postagem não foi encontrada");
            }



            return new Postagem(postagem.Texto, postagem.UsuarioId);
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _postagemRepository
                         .ObterListaPostagemPorUsuarioIdAsync(id)
                         .ConfigureAwait(false);
            if (usuario is null)
            {
                throw new Exception("Sentimos muito, sua postagem não foi encontrada");
            }

            await _postagemRepository
              .DeleteAsync(id)
              .ConfigureAwait(false);
        }

        public async Task<Postagem> InserirtAsync(PostagemInput input)
        {
            var usuarioId = _logado.PegarLoginUsuarioId();

            var postagem = new Postagem(input.Texto, usuarioId);


            var id = await _postagemRepository
                             .InserirAsync(postagem)
                             .ConfigureAwait(false);

            postagem.SetId(id);

            return postagem;
        }

        public async Task<List<Postagem>> ObterListaPostagem()
        {
            var usuarioId = _logado.PegarLoginUsuarioId();

            var postagem = await _postagemRepository
                                   .ObterListaPostagem()
                                    .ConfigureAwait(false);
            return postagem;
        }

        public Task<List<Postagem>> PegarPostagemUsuarioIdAsync()
        {
            throw new NotImplementedException();
        }
    }  
}
