using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Application.AppPostagem.Output
{
    public class PostagemViewModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public string Texto { get; set; }
        public DateTime Criacao { get;  set; }
    }
}
