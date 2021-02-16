using System;
using InstaGama.Domain.Entities;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Domain.Interfaces
{
    public interface ICurtidasRepository
    {
        Task<int> InserirAsync(Curtidas curtidas);
        Task DeletarAsync(int id);
        Task<int> PegarQuantidadeCurtidasIdAsync(int postageId);
        Task<Curtidas> PegarUsuarioIdEPostagemIdAsync(int userId, int postageId);
    }
}
