using InstaGama.Application.AppCurtida.Input;
using InstaGama.Application.AppCurtida.Interface;
using InstaGama.Application.AppCurtida.Output;
using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace InstaGama.Application.AppPostage
{
    public class CurtidaAppService : ICurtidaAppService
    {
        private readonly ICurtidaRepository _curtidaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        //private readonly ILogado _logado;
        //private ILogado logado;

        public CurtidaAppService(ICurtidaRepository curtidaRepository,
                                IUsuarioRepository usuarioRepository)
        // ILogadoRepository  logadoRepository)
        {
            _curtidaRepository = curtidaRepository;
            _usuarioRepository = usuarioRepository;
            // _logado = logadoRepository;
        }

        public async Task<int> PegarQuantidadeCurtidasIdAsync(int postagemId)
        {
            return await _curtidaRepository
                            .PegarQuantidadeCurtidasIdAsync(postagemId)
                            .ConfigureAwait(false);
        }

        public async Task InserirAsync(int postagemId)
        {
            var usuarioId = 1; //_logado.PegarUsuarioLogadoId(); o NUMERO 1 PRECISA SER RETIRADO E DESCPMENTAR O LOGADO

            var curtidaExistForPostagem = await _curtidaRepository
                                                .PegarUsuarioIdEPostagemIdAsync(usuarioId, postagemId)
                                                .ConfigureAwait(false);
            if (curtidaExistForPostagem != null)
            {
                await _curtidaRepository
                         .ApagarAsync(curtidaExistForPostagem.Id)
                         .ConfigureAwait(false);
            }

            var curtida = new Curtida(postagemId, usuarioId);
            //Validar os dados obrigatorios..

            await _curtidaRepository
                    .InserirAsync(curtida)
                    .ConfigureAwait(false);
        }

        public Task InserirAsync(CurtidaEntrada postagemId)
        {
            throw new NotImplementedException();
        }

        Task<CurtidaSaida> ICurtidaAppService.PegarQuantidadeCurtidasIdAsync(int postagemId)
        {
            throw new NotImplementedException();
        }
    }
}
