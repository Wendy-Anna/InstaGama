using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace InstaGama.Repositories
{
    public class CurtidaRepository : ICurtidaRepository
    {

                public Task ApagarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InserirAsync(Curtida curtida)
        {
            throw new NotImplementedException();
        }

        public Task<int> PegarQuantidadeCurtidasIdAsync(int postagemId)
        {
            throw new NotImplementedException();
        }

        public Task<Curtida> PegarUsuarioIdEPostagemIdAsync(int usuarioId, int postagemId)
        {
            throw new NotImplementedException();
        }
    }
}
