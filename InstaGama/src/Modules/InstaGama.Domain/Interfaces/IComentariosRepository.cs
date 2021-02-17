using InstaGama.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstaGama.Domain.Interfaces
{
    public interface IComentariosRepository
    {

        Task<int> InserirAsync(Comentario comentario);
        Task<List<Comentario>> PegarPostagemIdAsync(int postagemId);

    }
}
