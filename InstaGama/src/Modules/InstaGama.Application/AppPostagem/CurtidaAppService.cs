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
    public class CurtidaAppService : ICurtidaAppService
    {


        private readonly ICurtidaRepository _curtidaRepository;
        private readonly ILogado _logado;

        public CurtidaAppService(ICurtidaRepository curtidaRepository,
                            ILogado logado)
        {
            _curtidaRepository = curtidaRepository;
            _logado = logado;
        }

        public async Task InserirtAsync(int postagemId)
        {
            var usuarioId = _logado.PegarLoginUsuarioId();

            var existeCurtidaEmPostagem = await _curtidaRepository
                                                .PegarUsuarioIdEPostagemIdAsync(usuarioId, postagemId)
                                                .ConfigureAwait(false);
            if (existeCurtidaEmPostagem != null)
            {
                await _curtidaRepository
                         .ApagarAsync(existeCurtidaEmPostagem.Id)
                         .ConfigureAwait(false);
            }

            var curtida = new Curtida(postagemId, usuarioId);
           

            await _curtidaRepository
                    .InserirAsync(curtida)
                    .ConfigureAwait(false);
        }

        public async Task<int> PegarQuantidadeCurtidasEPostageIdAsync(int postagemId)
        {
            return await _curtidaRepository
                     .PegarQuantidadeCurtidasIdAsync(postagemId)
                     .ConfigureAwait(false);
        }
    }
}
