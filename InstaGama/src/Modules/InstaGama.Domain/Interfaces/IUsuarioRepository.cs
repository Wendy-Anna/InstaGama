﻿
using InstaGama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<int> InserirAsync(Usuario  usuario);

        Task<Usuario> PegarLoginAsync(string login);

        Task<Usuario> PegarId(int id);

        Task AlterarUsuario(Usuario usuario);

        Task DeleteUsuario(int id);


    }
}
