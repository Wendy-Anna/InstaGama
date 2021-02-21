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
        Task<Postagem> ObterPostagemPorIdAsync(int postagemId);

    }
}
