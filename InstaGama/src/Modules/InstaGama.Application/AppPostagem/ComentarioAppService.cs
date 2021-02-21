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
    public class ComentarioAppService : IComentarioAppService
    {
        private readonly IComentarioRepository _comentarioRepository;
        private readonly ILogado _logado;
        
        public ComentarioAppService(IComentarioRepository comentarioRepository,
                                  ILogado logado)
        {
            _comentarioRepository = comentarioRepository;
            _logado = logado;
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _comentarioRepository
                         .PegarComentarioIdAsync(id)
                         .ConfigureAwait(false);
            if (usuario is null)
            {
                throw new Exception("Sentimos muito, seu comentário não foi encontrado!");
            }

            await _comentarioRepository
              .DeleteAsync(id)
              .ConfigureAwait(false);
        }

        public async Task<List<Comentario>> PegarPostagemIdAsync(int postagemId)
        {
            var comentario = await _comentarioRepository
                              .PegarPostagemIdAsync(postagemId)
                              .ConfigureAwait(false);

            return comentario;
        }

        public async Task<Comentario> InserirAsync(int postagemId, ComentarioInput input)
        {
            var usuarioId = _logado.PegarLoginUsuarioId();

            var comentario = new Comentario(postagemId, usuarioId, input.Texto);


            var numId = await _comentarioRepository
                              .InserirAsync(comentario)
                              .ConfigureAwait(false);

            comentario.SetId(numId);

            return comentario;
        }
    }
}
