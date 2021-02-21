using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Application.AppPostagem.Interfaces
{
    public interface ICurtidaAppService
    {
        Task InserirtAsync(int postagemId);
        Task<int> PegarQuantidadeCurtidasEPostageIdAsync(int postagemId);
    }
}
