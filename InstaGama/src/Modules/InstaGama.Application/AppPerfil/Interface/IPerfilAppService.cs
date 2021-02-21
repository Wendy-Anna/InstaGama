using InstaGama.Application.AppPerfil.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Application.AppPerfil.Interface
{
    public interface IPerfilAppService
    {
        Task<PerfilViewModel> ObterPerfilPorIdUsarioAsync(int id);
    }
}
