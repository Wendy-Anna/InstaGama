using InstaGama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Application.UsuarioApp.Output
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Genero Genero { get; set; }
        public string Foto { get; set; }
    }
}
