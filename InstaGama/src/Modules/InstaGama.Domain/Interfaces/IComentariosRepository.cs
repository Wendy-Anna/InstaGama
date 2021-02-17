using InstaGama.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstaGama.Domain.Interfaces
{
    public interface IComentarioRepository
    {

        Task<int> InsertAsync(Comentario comentario);
        Task<List<Comentario>> GetByPostagemIdAsync(int postagemId);

    }
}
