using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Domain.Interfaces

    public interface IComentarioRepository
    {

        Task <int> InsertAsync(Comentarios comentario);
        Task <List<Comentarios>> GetByPostagemIdAsync(int postagemId);

    }
}
