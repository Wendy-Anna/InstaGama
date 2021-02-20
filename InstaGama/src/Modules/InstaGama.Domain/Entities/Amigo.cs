using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Domain.Entities
{
    public class Amigo
    {
        public Amigo(int usuarioId, int usuarioAmigoId){
            UsuarioId=usuarioId;
            UsuarioAmigoId=usuarioAmigoId;
        }

        public Amigo(int usuarioId, int usuarioAmigoId, int id)
        {
            UsuarioId = usuarioId;
            UsuarioAmigoId = usuarioAmigoId;
            Id = id;
        }

        public int Id { get; private set; }
	    public int UsuarioId { get; private set; }
	    public int UsuarioAmigoId { get; private set; }
    
        
        public void SetId(int id)
        {
            Id = id;
        }

        public bool IsValid()
        {
            if (UsuarioAmigoId <= 0 || UsuarioId <= 0)
            {
                return false;
            }
            else return true;
        }

     }
}
