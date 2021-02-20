using InstaGama.Application.UsuarioApp.Input;
using InstaGama.Application.UsuarioApp.Output;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InstaGama.Application.UsuarioApp.Interface
{
    public interface IUsuarioAppService
    {
        Task<UsuarioViewModel> InserirAsync(UsuarioInput input);

        Task<UsuarioViewModel> PegarId(int id);
        Task<UsuarioViewModel> UpdateUsuario(UsuarioInput input, int id);

        Task DeleteUsuario(int id);
    }
}
