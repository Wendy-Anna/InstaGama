
using InstaGama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Domain.Interfaces
{
    public interface IAmigoRepository
    {
        Task<int> InserirAsync(Amigo inserirAmigo);
        Task<List<Amigo>> ObterListaAmigoPorUsuarioIdAsync(int usuarioId);
    }
}
