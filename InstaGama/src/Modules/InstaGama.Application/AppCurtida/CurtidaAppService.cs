using InstaGama.Application.AppCurtida.Interface;
using InstaGama.Application.AppCurtida.Output;
using InstaGama.Domain.Core.Interfaces;
using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using System.Threading.Tasks;

namespace InstaGama.Application.AppPostage
{
    public class CurtidaAppService : ICurtidaAppService
    {
        private readonly ICurtidaRepository _curtidaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogado _logado;
        

        public CurtidaAppService(ICurtidaRepository curtidaRepository,
                                IUsuarioRepository usuarioRepository,
                                 ILogado  logado)
        {
            _curtidaRepository = curtidaRepository;
            _usuarioRepository = usuarioRepository;
            _logado = logado;
        }

        public Task ApagarAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CurtidaModelView> InserirAsync(int postagemId)
        {
            var usuarioId = _logado.PegarLoginUsuarioId();

            var curtidaExistForPostage = await _curtidaRepository
                                                .PegarUsuarioIdEPostagemIdAsync(usuarioId, postagemId)
                                                .ConfigureAwait(false);
            if (curtidaExistForPostage != null)
            {
                await _curtidaRepository
                         .ApagarAsync(curtidaExistForPostage.Id)
                         .ConfigureAwait(false);
            }

            var curtida = new Curtida(postagemId, usuarioId);
            

            await _curtidaRepository
                    .InserirAsync(curtida)
                    .ConfigureAwait(false);

            return new CurtidaModelView()
            {
                PostagemId = postagemId,
                UsuarioId = usuarioId
            };
        }

        public async Task<int> PegarQuantidadeCurtidasIdAsync(int postagemId)
        {
            return await _curtidaRepository
                            .PegarQuantidadeCurtidasIdAsync(postagemId)
                            .ConfigureAwait(false);
        }

        public Task<CurtidaModelView> PegarUsuarioIdEPostagemIdAsync(int usuarioId, int postagemId)
        {
            throw new System.NotImplementedException();
        }
    }
}
