using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Application.AppComentario.Output
{
    public class ComentarioViewModel
    {
        public int Id { get; set; }
        public int PostagemId { get; set; }
        public String TextoPostagemId { get; set; }
        public int UsuarioId { get; set; }

        public string NomeUsuario { get; set; }

        public string Texto { get; set; }
        public DateTime Criacao { get; set; }

    }
}
