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
    public class CurtidasRepository : ICurtidasRepository
    {

                public Task DeletarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InserirAsync(Curtidas curtidas)
        {
            throw new NotImplementedException();
        }

        public Task<int> PegarQuantidadeCurtidasIdAsync(int postageId)
        {
            throw new NotImplementedException();
        }

        public Task<Curtidas> PegarUsuarioIdEPostagemIdAsync(int userId, int postageId)
        {
            throw new NotImplementedException();
        }
    }
}
