using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Domain.Entities
{
    public class Postagem
    {
        public Postagem(string texto, int usuarioId)
        {
            Texto = texto;
            UsuarioId = usuarioId;
            Criacao = DateTime.Now;
        }

        public Postagem(int id, string texto, DateTime criacao, int usuarioId)
        {
            Id = id;
            Texto = texto;
            UsuarioId = usuarioId;
            Criacao = criacao;
        }

        public int Id { get; private set; }
        public int UsuarioId { get; private set; }
        public string Texto { get; private set; }
        public DateTime Criacao { get; private set; }

        
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Texto) || UsuarioId<=0)
            {
                return false;
            }
            return true;
        }

    }
}
