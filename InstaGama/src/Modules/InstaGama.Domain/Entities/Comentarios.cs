using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Domain.Entities
{
    public class Comentarios
    {
        public Comentarios(int postagemId,
                         int usuarioId,
                         string texto)
        {
            PostagemId = postagemId;
            UsuarioId = usuarioId;
            Texto = texto;

            Creacao = DateTime.Now;
        }

        public Comentarios(int id,
                         int postagemId,
                         int usuarioId,
                         string texto,
                         DateTime creacao)
        {
            Id = id;
            PostagemId = postagemId;
            UsuarioId = usuarioId;
            Texto = texto;
            Creacao = creacao;
        }

        public int Id { get; private set; }
        public int PostagemId { get; private set; }
        public int UsuarioId { get; private set; }
        public string Texto { get; private set; }
        public DateTime Creacao { get; private set; }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
