using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Domain.Entities
{
    public class Curtida
    {
        public Curtida(int postagemId,
                        int usuarioId)
        {
            PostagemId = postagemId;
            UsuarioId = usuarioId;
        }

        public Curtida(int id,
                        int postagemId,
                        int usuarioId)
        {
            Id = id;
            PostagemId = postagemId;
            UsuarioId = usuarioId;
        }

        public int Id { get; private set; }
        public int PostagemId { get; private set; }
        public int UsuarioId { get; private set; }
    }
}
