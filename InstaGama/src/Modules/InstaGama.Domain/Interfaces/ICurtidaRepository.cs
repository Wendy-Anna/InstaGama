﻿using System;
using InstaGama.Domain.Entities;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Domain.Interfaces
{
    public interface ICurtidaRepository
    {
        Task<int> InserirAsync(Curtida curtida);
        Task ApagarAsync(int id);
        Task<int> PegarQuantidadeCurtidasIdAsync(int postagemId);
        
        Task<Postagem> ObterPostagemPorIdAsync(int postagemId);

    }
}
