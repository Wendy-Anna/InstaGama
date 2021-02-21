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
        

        public CurtidaAppService(ICurtidaRepository curtidaRepository,
                                IUsuarioRepository usuarioRepository)
        // ILogadoRepository  logadoRepository)
        {
            _curtidaRepository = curtidaRepository;
            _usuarioRepository = usuarioRepository;
            // _logado = logadoRepository;
        }

        public async Task<CurtidaModelView> InserirAsync(CurtidaInput curtidaInput)
        {
            var postagem = await _curtidaRepository
                                      .ObterPostagemPorIdAsync(curtidaInput.PostagemId)
                                      .ConfigureAwait(false);
            if (postagem is null)
            {
                throw new ArgumentException("Postagem inexistente.");
            }

            //if (Curtida.IsValid())
            //{

            //}
            var curtida = new Curtida(curtidaInput.UsuarioId, curtidaInput.PostagemId);

            var idCurtida = await _curtidaRepository
                                .InserirAsync(curtida)
                                .ConfigureAwait(false);

            if(idCurtida == 0)
            {
                throw new ArgumentException("Postagem inexistente.");
            }

            return new CurtidaModelView()
            {
                Id = idCurtida,
                PostagemId = curtida.PostagemId,
                UsuarioId = curtida.UsuarioId,
            };
        }

        
        public async Task<int> PegarQuantidadeCurtidasIdAsync(int postagemId)
        {
            return await _curtidaRepository
                            .PegarQuantidadeCurtidasIdAsync(postagemId)
                            .ConfigureAwait(false);
        }

        public Task<CurtidaModelView> ObterPostagemPorIdAsync(int postagemId)
        {
            throw new NotImplementedException();
        }

    }
}
