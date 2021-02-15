using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Domain.Entities
{
   public class Comentario
    {

        public Comentario(int usuarioId, int postagemId, string texto, DateTime data)
        {
            UsuarioId = usuarioId;
            PostagemId = postagemId;
            Texto = texto;
            Data = data;
        }

        public int Id {get; private set; }
        public int UsuarioId { get; set; }
        public int PostagemId { get; set; }
        public string Texto { get; set; }
        public DateTime Data { get; set; }


         public string validaTexto(string texto)
        {
            
            if (texto.Length >=10 && texto.Length <= 300 )
            {

                return texto;

            }

            else {
                return ("Capriche num texto de 10 a 300 caracteres");
                }


        }
               
    }
}
