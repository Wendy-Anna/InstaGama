using InstaGama.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstaGama.Domain.Interfaces
{
    public interface IComentarioRepository
    {
        Task<int> InserirAsync(Comentario comentario);
        Task<List<Comentario>> ObterListaComentarioPorPostagemIdAsync(int postagemId);

        Task DeletarComentario(int idComentario);

    }
}
