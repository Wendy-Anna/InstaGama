using InstaGama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Domain.Interfaces
{
    interface IPostagemRespository
    {
        public interface IPostageRepository
        {
            Task<int> InserirtAsync(Postagem postage);
            Task<List<Postagem>> PegarPostagemPorUsuarioIdAsync(int userId);
        }
    }
}
