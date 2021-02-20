using InstaGama.Application.AppCurtida.Input;
using InstaGama.Application.AppCurtida.Output;
using InstaGama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Application.AppCurtida.Input
{
    public class CurtidaInput
    {
        public int PostagemId { get; set; }
        public int UsuarioId { get; set; }
    }
}
