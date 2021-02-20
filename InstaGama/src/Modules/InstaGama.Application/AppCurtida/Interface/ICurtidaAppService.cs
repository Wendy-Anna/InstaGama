using InstaGama.Application.AppCurtida.Input;
using InstaGama.Application.AppCurtida.Output;
using System.Threading.Tasks;

namespace InstaGama.Application.AppCurtida.Interface
{
    public interface ICurtidaAppService
    {
       Task<CurtidaModelView> InserirAsync(CurtidaInput curtida); 
       
       Task<int> PegarQuantidadeCurtidasIdAsync(int postagemId);
    }
}
