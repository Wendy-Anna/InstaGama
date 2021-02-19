using InstaGama.Application.AppCurtida.Input;
using InstaGama.Application.AppCurtida.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Application.AppCurtida.Interface
{
    public interface ICurtidaAppService
    {
        Task InserirAsync(int postagemId);
        Task<CurtidaSaida> PegarQuantidadeCurtidasIdAsync(int postagemId);
    }
}
