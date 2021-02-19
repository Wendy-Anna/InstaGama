using InstaGama.Application.UsuarioApp.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Application.AppUsuario.Interface
{
    public interface ILoginAppService
    {
        Task<UsuarioViewModel> LoginAsync(string login, string senha);
    }
}
