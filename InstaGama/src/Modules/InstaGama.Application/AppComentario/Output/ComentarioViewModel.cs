using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Application.AppComentario.Output
{
    public class ComentarioViewModel
    {
        public int IdComentario { get; set; }
        public int IdPostagem { get; set; }
        public String Comentario { get; set; }
        public int UsuarioId { get; set; }

        public string NomeUsuario { get; set; }

        public DateTime Criacao { get; set; }

    }
}
