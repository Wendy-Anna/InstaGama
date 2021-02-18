using InstaGama.Domain.Entities;
using System.Threading.Tasks;

namespace InstaGama.Domain.Interfaces
{
    public interface ICurtidasRepository
    {
        Task<int> InserirAsync(Curtida curtidas);
        Task ApagarAsync(int id);
        Task<int> PegarQuantidadeCurtidasIdAsync(int postagemId);
        Task<Curtida> PegarUsuarioIdEPostagemIdAsync(int usuario, int postagemId);
    }
}
