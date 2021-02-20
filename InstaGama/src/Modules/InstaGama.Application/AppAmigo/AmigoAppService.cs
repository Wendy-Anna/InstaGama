using InstaGama.Application.AppAmigo.Input;
using InstaGama.Application.AppAmigo.Interfaces;
using InstaGama.Application.AppAmigo.Output;
using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Application.AppAmigos
{
    public class AmigoAppService : IAmigoAppService
    {
        //preciso verificar se o id do usuario e do amigo existe? questionar
        //private readonly IUsuarioRepository _usuarioRespository;
        private readonly IAmigoRepository _amigoRepository;

        public AmigoAppService(IAmigoRepository amigoRepository)
            //IUsuarioRepository usuarioRepository)
        {
            //_usuarioRespository = usuarioRepository;
            _amigoRepository = amigoRepository;
        }

        public async Task<List<Amigo>> GetListaAmigoByUsuarioIdAsync(int usuarioId)
        {
            List<Amigo> listaAmigos = await _amigoRepository
                              .ObterListaAmigoPorIdAsync(usuarioId)
                              .ConfigureAwait(false);

            foreach (var amigo in listaAmigos)
            {
                 new AmigoViewModel()
                {
                    Id = amigo.Id,
                    UsuarioId = amigo.UsuarioId,
                    UsuarioAmigoId = amigo.UsuarioAmigoId

                };
            }
                return listaAmigos; 
            
            
        }

        public async Task<AmigoViewModel> InsertAsync(AmigoInput inputAmigo)
        {
            //validar se os usuário existem utilizando a pesquisa por IdUsuario

            var amigo = new Amigo(inputAmigo.UsuarioId,
                                  inputAmigo.UsuarioAmigoId);

           var id = await _amigoRepository
                                .InserirAsync(amigo)
                                .ConfigureAwait(false);

            return new AmigoViewModel()
            {
                Id = id,
                UsuarioId = amigo.UsuarioId,
                UsuarioAmigoId = amigo.UsuarioAmigoId
                
            };
        }
    }
    
}
