using InstaGama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Domain.Interfaces
{
    public interface IPostagemRepository
    {
        Task<int> InserirAsync(Postagem postagem);
        Task<List<Postagem>> ObterListaPostagemPorUsuarioIdAsync(int usuarioId);
        Task AtualizarAsync(int id, Postagem postagem);
        Task<Postagem> PegarPostagemIdAsync(int postagemId);
        Task DeleteAsync(int id);
        Task<List<Postagem>> ObterListaPostagem();
    }
}
