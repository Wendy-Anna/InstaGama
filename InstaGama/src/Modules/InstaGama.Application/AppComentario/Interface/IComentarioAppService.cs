﻿using InstaGama.Application.AppComentario.Input;
using InstaGama.Application.AppComentario.Output;
using InstaGama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Application.AppComentario.Interface
{
    public interface IComentarioAppService
    {
        Task<ComentarioViewModel> InserirAsync(ComentarioInput comentarioInput);
        Task<List<ComentarioViewModel>> ObterListaComentarioPorPostagemIdAsync(int postagemId);

        Task DeletarComentario(int id);

    

    }
}
