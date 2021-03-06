﻿using System;
namespace InstaGama.Domain.Entities
{
    public class Comentario
    {
        public Comentario(int postagemId,
                         int usuarioId,
                         string texto)
        {
            PostagemId = postagemId;
            UsuarioId = usuarioId;
            Texto = texto;

            Criacao = DateTime.Now;
        }
                public Comentario(int id,
                         int postagemId,
                         int usuarioId,
                         string texto,
                         DateTime creacao)
        {
            Id = id;
            PostagemId = postagemId;
            UsuarioId = usuarioId;
            Texto = texto;
            Criacao = creacao;
        }

        public int Id { get; private set; }
        public int PostagemId { get; private set; }
        public int UsuarioId { get; private set; }
        public string Texto { get; private set; }
        public DateTime Criacao { get; private set; }

        public void SetId(int id)
        {
            Id = id;
        }

        public bool IsValid()
        {
            if (Texto is null)
            {
                return false;
            }
            else return true;
        }




    }
}
