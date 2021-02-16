using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Domain.Entities
{
    class Postagem
    {
            public Postagem(
                //Usuario usuarioId,
                string texto,
                string media,
                DateTime dataCriacao)
            {
                //UsuarioId = usuarioId
                Texto = texto;
                Media = media;
                DataCriacao = dataCriacao;
            }

            public int Id { get; private set; }

            public Usuario UsuarioId { get; private set; }

            public string Texto { get; private set; }

            public string Media { get; private set; }

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
