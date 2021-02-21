using InstaGama.Application.AppPostagem.Output;
using InstaGama.Application.UsuarioApp.Output;
using InstaGama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Application.AppPerfil.Output
{
    public class PerfilViewModel
    {
        public UsuarioViewModel Usuario { get; set; }

        public List<PostagemViewModel> ListaPostagens { get; set; }

}
}
