using InstaGama.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace InstaGama.Domain.Interfaces
{
    public interface IGeneroRepository
    {
        Task<Genero> PegarIdAsync(int id);
    }
}
