using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Application.UsuarioApp.Input
{
    public class UsuarioInput
    {

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public DateTime DataNascimento { get; set; }

        public int GeneroId { get; set; }

        public string Foto { get; set; }
    }
}
