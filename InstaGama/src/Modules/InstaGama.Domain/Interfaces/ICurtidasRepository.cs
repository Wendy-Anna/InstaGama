using InstaGama.Domain.Entities;
using System.Threading.Tasks;

namespace InstaGama.Domain.Interfaces
{
    public interface ICurtidasRepository
    {
        Task<int> InsertAsync(Curtidas curtidas);
        Task DeleteAsync(int id);
        Task<int> GetQuantityOfCurtidasByPostagemIdAsync(int postagemId);
        Task<Curtidas> GetByUsuarioIdAndPostagemIdAsync(int usuarioId, int postagemId);
    }
}
