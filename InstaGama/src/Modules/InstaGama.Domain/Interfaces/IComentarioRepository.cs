using InstaGama.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstaGama.Domain.Interfaces
{
    public interface IComentarioRepository
    {

        Task<int> InserirAsync(Comentario comentario);
        Task<List<Comentario>> PegarPostagemIdAsync(int postagemId);
        Task DeleteAsync(int id);
        Task<Comentario> PegarComentarioIdAsync(int id);

    }
}
