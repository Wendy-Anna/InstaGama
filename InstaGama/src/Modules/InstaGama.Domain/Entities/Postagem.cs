using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Domain.Entities
{
    public class Postagem
    {
        public Postagem(string texto,
                        int usuarioId)
        {
            Texto = texto;
            UsuarioId = usuarioId;

            Creacao = DateTime.Now;
        }

        public Postagem(int id,
                        string texto,
                        int usuarioId,
                        DateTime creacao)
        {
            Id = id;
            Texto = texto;
            UsuarioId = usuarioId;
            Creacao = creacao;
        }

        public int Id { get; private set; }
        public int UsuarioId { get; private set; }
        public string Texto { get; private set; }
        public DateTime Creacao { get; private set; }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
