using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Application.AppAmigo.Output
{
    public class AmigoViewModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public string NomeUsuario { get; set; }
        public int UsuarioAmigoId { get; set; }
        public string NomeUsuarioAmigo { get; set; }


    }
}
