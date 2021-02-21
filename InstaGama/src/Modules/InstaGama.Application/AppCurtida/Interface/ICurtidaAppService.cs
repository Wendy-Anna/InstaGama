using InstaGama.Application.AppCurtida.Input;
using InstaGama.Application.AppCurtida.Output;
using System.Threading.Tasks;

namespace InstaGama.Application.AppCurtida.Interface
{
    public interface ICurtidaAppService
    {
       Task<CurtidaModelView> InserirAsync(int postagemId); 
       
       Task<int>PegarQuantidadeCurtidasIdAsync(int postagemId);

       Task<CurtidaModelView>PegarUsuarioIdEPostagemIdAsync(int usuarioId, int postagemId);

       Task ApagarAsync(int id);
    }
}
