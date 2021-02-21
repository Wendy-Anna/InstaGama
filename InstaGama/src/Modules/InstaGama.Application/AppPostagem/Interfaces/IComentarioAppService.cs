using InstaGama.Application.AppPostagem.Input;
using InstaGama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Application.AppPostagem.Interfaces
{
    public interface IComentarioAppService
    {
        Task<Comentario> InserirAsync(int postagemId, ComentarioInput input);
        Task<List<Comentario>> PegarPostagemIdAsync(int postagemId);
        Task DeleteAsync(int id);
    }
}
