using InstaGama.Application.AppCurtida.Input;
using InstaGama.Application.AppCurtida.Interface;
using InstaGama.Application.AppCurtida.Output;
using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using System.Threading.Tasks;

namespace InstaGama.Application.AppPostage
{
    public class CurtidaAppService : ICurtidaAppService
    {
        private readonly ICurtidaRepository _curtidaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        //private readonly ILogado _logado;
        

        public CurtidaAppService(ICurtidaRepository curtidaRepository,
                                IUsuarioRepository usuarioRepository)
        // ILogadoRepository  logadoRepository)
        {
            _curtidaRepository = curtidaRepository;
            _usuarioRepository = usuarioRepository;
            // _logado = logadoRepository;
        }

        public Task<CurtidaModelView> InserirAsync(CurtidaInput curtida)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> PegarQuantidadeCurtidasIdAsync(int postagemId)
        {
            return await _curtidaRepository
                            .PegarQuantidadeCurtidasIdAsync(postagemId)
                            .ConfigureAwait(false);
        }

        
        
    }
}
