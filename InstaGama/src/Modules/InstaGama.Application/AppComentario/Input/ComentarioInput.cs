﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Application.AppComentario.Input
{
    class ComentarioInput
    {
        public int Id { get; set; }
        public int PostagemId { get; set; }
        public int UsuarioId { get; set; }
        public string Texto { get; set; }
        public DateTime Criacao { get; set; }

    }
}
