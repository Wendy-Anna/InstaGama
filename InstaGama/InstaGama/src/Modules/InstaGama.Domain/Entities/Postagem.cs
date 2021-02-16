using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Domain.Entities
{
    public class Postagem
    {
            public Postagem(
                Usuario usuarioId,
                string texto,
                string foto,
                string video,
                DateTime dataCriacao)
            {
                UsuarioId = usuarioId;
                Texto = texto;
                Foto = foto;
                Video = video;
                DataCriacao = dataCriacao;
            }

            public int Id { get; private set; }

            public Usuario UsuarioId { get; private set; }

            public string Texto { get; private set; }

            public string Foto { get; private set; }

            public string Video { get; private set; }

        public DateTime DataCriacao { get; private set; }

            public bool isvalid()
            {
                bool valido = true;
                if (string.IsNullOrEmpty(Texto))
                {
                    valido = false;
                }
                return valido;
            }

            public void SetId(int id)
            {
                Id = id;
            }
        }

}
