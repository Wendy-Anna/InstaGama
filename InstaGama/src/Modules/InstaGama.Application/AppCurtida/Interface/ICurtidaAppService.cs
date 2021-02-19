using System.Threading.Tasks;

namespace InstaGama.Application.AppCurtida.Interface
{
    public interface ICurtidaAppService
    {
        Task InserirAsync(int postagemId);
        Task<int> PegarQuantidadeCurtidasIdAsync(int postagemId);
    }
}
