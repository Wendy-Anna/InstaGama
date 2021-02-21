﻿using InstaGama.Application.AppPostagem.Input;
using InstaGama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Application.AppPostagem.Interfaces
{
    public interface IPostagemAppService
    {

        Task<Postagem> InserirtAsync(PostagemInput input);
        Task<List<Postagem>> PegarPostagemUsuarioIdAsync();
        Task<Postagem> AtualizarAsync(int id, PostagemInput postageInput);
        Task DeleteAsync(int id);
        Task<List<Postagem>> ObterListaPostagem();

    }
}
