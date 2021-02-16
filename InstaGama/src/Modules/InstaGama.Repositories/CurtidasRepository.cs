using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using System;
using System.Threading.Tasks;


namespace InstaGama.Repositories
{
    public class CurtidasRepository : ICurtidasRepository
    {

        public Task ApagarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InserirAsync(Curtidas curtidas)
        {
            throw new NotImplementedException();
        }

        public Task<int> PegarQuantidadeCurtidasIdAsync(int postagemId)
        {
            throw new NotImplementedException();
        }

        public Task<Curtidas> PegarUsuarioIdEPostagemIdAsync(int usuarioId, int postagemId)
        {
            throw new NotImplementedException();
        }
    }
}
